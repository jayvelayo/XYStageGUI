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
    }
}
