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


namespace XYStageGUI
{
    public partial class Form1 : Form
    {
        string indata;
        const int XLim =200;
        const int YLim = 500;
        bool sentHome = false;

        //defined function that converts string into its equivalent ASCII for sending
        private byte[] convertToAscii(string s)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            return bytes;
        }

        //sends the string to serial port
        private void sendCommand(string s)
        {
            s += "\r\n";
            Byte[] toSend = convertToAscii(s);
            serCOM.Write(toSend, 0, toSend.Length);
        }

        //enables/disables buttons depending on status of serial com
        private void enableButtons(bool b)
        {
            if(b)
            {
                btnHomePos.Enabled = true;
                btnResetZero.Enabled = true;
                btnSendPosition.Enabled = true;
                btnSoftReset.Enabled = true;
                btnStatus.Enabled = true;
                btnSendCommand.Enabled = true;
                txtCmdLine.Enabled = true;
                btnUnlock.Enabled = true;
                btnStop.Enabled = true;
                txtSetXVal.Enabled = true;
                txtSetYVal.Enabled = true;
            }
            else
            {
                btnHomePos.Enabled = false;
                btnResetZero.Enabled = false;
                btnSendPosition.Enabled = false;
                btnSoftReset.Enabled = false;
                btnStatus.Enabled = false;
                btnSendCommand.Enabled = false;
                txtCmdLine.Enabled = false;
                btnUnlock.Enabled = false;
                btnStop.Enabled = false;
                txtSetXVal.Enabled = false;
                txtSetYVal.Enabled = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
            enableButtons(false);
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
                    enableButtons(false);
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
                    enableButtons(true);
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

            //TODO WISHLIST: Depending on data input, change the machine status
            
        }

        //event handler for handling new lines of serial input
        private void DisplayText(object sender, EventArgs e)
        {
            string[] arr = indata.Replace("\n\r", "\r\n").Replace("\r\n", "\n").Trim('\n').Split('\n');
            foreach (string item in arr)
            {
                if (item == "ok" && sentHome)
                {
                    lblXPosition.Text = "0";
                    lblYPosition.Text = "0";
                    sentHome = false;
                }
                else
                {
                    lblXPosition.Text = "?";
                    lblYPosition.Text = "?";
                    sentHome = false;
                }
                if (item != "ok")
                {
                    lstSerialOutput.Items.Add(item);
                    lstSerialOutput.TopIndex = lstSerialOutput.Items.Count - 1;
                }
            }
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
            //user input error prevention
            //int xval = 0;
            //int yval = 0;
            //bool resx = Int32.TryParse(txtSetXVal.Text, out xval);
            //bool resy = Int32.TryParse(txtSetYVal.Text, out yval);
            //if (resx == true && xval >= 0 && xval <= XLim)
            //{
            //    if (resy == true && yval >= 0 && yval <= YLim)
            //    {
                    //sets the position of the stage
                    string gcode = "G0 X" + txtSetXVal.Text + " Y" + txtSetYVal.Text;
                    sendCommand(gcode);
            //    }
            //    else
            //    {
            //        MessageBox.Show("YAXIS error. Please input 0 to " + YLim + " only.");
            //        return;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("XAXIS error. Please input 0 to "+ XLim + " only.");
            //    return;
            //}

            
        }

        private void btnHomePos_Click(object sender, EventArgs e)
        {
            //sends a homing command
            sentHome = true;
            sendCommand("$H");
            sendCommand("g92 x3 y3");
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            //sends a machine status request
            serCOM.Write("?");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //send the command line
            sendCommand(txtCmdLine.Text);
            txtCmdLine.Text = "";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // send a soft reset command
            Byte[] softResetCmd = { 0x18 };
            serCOM.Write(softResetCmd, 0, softResetCmd.Length);
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
                sendCommand(txtCmdLine.Text);
                txtCmdLine.Text = "";
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            sendCommand("$X");
        }
    }
}
