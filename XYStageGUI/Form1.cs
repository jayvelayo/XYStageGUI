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
                if (!serCOM.IsOpen) { cmbPort.Enabled = true; }
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
                if (serCOM.IsOpen) { cmbPort.Enabled = false; }

            }
            
        }

        private void serCOM_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string indata = serCOM.ReadExisting();
            //TODO: Depending on data input, change the machine status


            lstSerialOutput.BeginUpdate();
            lstSerialOutput.Items.Add(indata);
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
    }
}
