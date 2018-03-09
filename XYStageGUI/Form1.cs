using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections.Concurrent;

namespace XYStageGUI
{
    public partial class Form1 : Form
    {
        ConcurrentQueue<string> stringQueue = new ConcurrentQueue<string>();
        string indata;

        //defined function that converts string into its equivalent ASCII for sending
        private byte[] convertToAscii(string s)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            return bytes;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void cmbPort_DropDown(object sender, EventArgs e)
        {
            //populate list with available COM Ports
            cmbPort.Items.Clear();
            cmbPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames().ToArray());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serCOM.Close();
        }

        private void cmbBaud_DropDown(object sender, EventArgs e)
        {
            cmbBaud.Items.Clear();
            string[] baudRates = new string[] { "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            cmbBaud.Items.AddRange(baudRates);
        }


        private void btnConnectDisconnect_Click(object sender, EventArgs e)
        {

            //open = port is active; close = port is inactive
            if (serCOM.IsOpen)
            {
                serCOM.Close();
                if (!serCOM.IsOpen) {
                    btnConnectDisconnect.Text = "Connect";
                    cmbPort.Enabled = true;
                    cmbBaud.Enabled = true;
                }
            }
            else
            {
                
                serCOM.Parity = Parity.None;
                serCOM.DataBits = 8;
                serCOM.StopBits = StopBits.One;

                try
                {
                    serCOM.PortName = cmbPort.SelectedItem.ToString();
                    serCOM.BaudRate = Convert.ToInt32(cmbBaud.SelectedItem);
                    serCOM.Open();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error! Can not open port");
                }
                if (serCOM.IsOpen) {
                    btnConnectDisconnect.Text = "Disconnect";
                    cmbPort.Enabled = false;
                    cmbBaud.Enabled = false;
                }

            }
            
        }

        private void serCOM_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            indata += serCOM.ReadExisting();
            if (indata.EndsWith("\r\n"))
            {
                this.Invoke(new EventHandler(DisplayText));
                indata = String.Empty;
            }

            //TODO: Depending on data input, change the machine status

            //error handling
            if (indata.Contains("error"))
            {
                //send a stop command
                Byte[] stopCmd = { 0x21 };
                serCOM.Write(stopCmd, 0, stopCmd.Length);
            }

            stringQueue.Enqueue(indata);
            
        }

        //event handler for handling new lines of serial input
        private void DisplayText(object sender, EventArgs e)
        {
            string[] arr = indata.Replace("\n\r", "\r\n").Replace("\r\n", "\n").Trim('\n').Split('\n');
            foreach (string item in arr)
            {
                if (item != "ok")
                {
                    lstSerialOutput.Items.Add(item);
                    lstSerialOutput.TopIndex = lstSerialOutput.Items.Count - 1;
                }
            }
        }

        private void tmrDataProcess_Tick(object sender, EventArgs e)
        {
            lstSerialOutput.BeginUpdate();

            if (!stringQueue.IsEmpty)
            {
                for (int i = 0; i < stringQueue.ToArray().Length; i++)
                {
                    stringQueue.TryDequeue(out string outString);
                    lstSerialOutput.Items.Add(outString);
                }
            }
            lstSerialOutput.SelectedIndex = lstSerialOutput.Items.Count - 1;
            lstSerialOutput.EndUpdate();
            lstSerialOutput.Refresh();
        }

        private void btnResetZero_Click(object sender, EventArgs e)
        {
            lblXPosition.Text = "0";
            lblYPosition.Text = "0";
        }

        private void z(object sender, EventArgs e)
        {

        }

        private void btnSendPosition_Click(object sender, EventArgs e)
        {
            //sets the position of the stage
            string gcode = "g0 x" + txtSetXVal + " y" + txtSetYVal;
            serCOM.Write(gcode);
        }

        private void btnHomePos_Click(object sender, EventArgs e)
        {
            //sends a homing command
            serCOM.Write("$H");
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            //sends a machine status request
            serCOM.Write("?");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //send the command line
            serCOM.Write(txtCmdLine.Text);
            txtCmdLine.Text = "";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //send a stop command
            Byte[] stopCmd = { 0x21 };
            serCOM.Write(stopCmd, 0, stopCmd.Length);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // send a soft reset command
            Byte[] softResetCmd = { 0x18 };
            serCOM.Write(softResetCmd, 0, softResetCmd.Length);
        }

        private void txtCmdLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtCmdLine.Text += "\r\n";
                Byte[] toSend = convertToAscii(txtCmdLine.Text);
                serCOM.Write(toSend, 0, toSend.Length);
                txtCmdLine.Text = "";
            }
        }
    }
}
