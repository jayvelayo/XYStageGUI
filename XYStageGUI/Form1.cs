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
using System.Threading;
using System.Collections.Concurrent;


namespace XYStageGUI
{
    public partial class Form1 : Form
    {
        string indata;
        const int XLim =200;
        const int YLim = 500;
        bool sentHome = false;
        const double probeDistance = 6.5;

        ConcurrentQueue<int> intSemaphore = new ConcurrentQueue<int>();

        private static Semaphore _semaphore;
        

        private void waitEnd()
        {
            //wait until the semaphore is empty
            while (!intSemaphore.IsEmpty) ;

            lstSerialOutput.Items.Add("Command complete");
            lstSerialOutput.TopIndex = lstSerialOutput.Items.Count - 1;
        }

        //defined function that converts string into its equivalent ASCII for sending
        private byte[] convertToAscii(string s)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            return bytes;
        }

        //sends the string to serial port
        private void sendCommand(string s)
        {
            s += "\n";
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
                cmbSetX.Enabled = true;
                cmbSetY.Enabled = true;
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
                cmbSetX.Enabled = false;
                cmbSetY.Enabled = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
            enableButtons(false);
            _semaphore = new Semaphore(0, 2);
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
                _semaphore.Release(1);
               // if(indata == "ok") { int outnum; intSemaphore.TryDequeue(out outnum); }
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
                if (item == "ok")
                {
                    
                }
                else
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

        
        private void movePosition(string strXIndex, string strYIndex)
        {

            //sets the position of the stage
            string gcode = "G0 X" + strXIndex + " Y" + strYIndex;
            sendCommand(gcode);
            _semaphore.WaitOne();
            //intSemaphore.Enqueue(1);

            sendCommand("G4 P0.01");
            _semaphore.WaitOne();
            //intSemaphore.Enqueue(1);

            //while (!intSemaphore.IsEmpty) ;
            this.Invoke(new EventHandler(displayComplete));

        }

        private void displayComplete(object sender, EventArgs e)
        {
            lstSerialOutput.Items.Add("Command complete");
            lstSerialOutput.TopIndex = lstSerialOutput.Items.Count - 1;
        }

        private void btnSendPosition_Click(object sender, EventArgs e)
        {

            // Y = A, B, C, ... , W
            // X = 1, 2, 3, ... , 45
            
            double yIndex = (char.ToUpper(cmbSetY.Text[0]) - 65)*probeDistance;
            double xIndex = (Convert.ToDouble(cmbSetX.Text) -1)* probeDistance;

            string strYIndex = Convert.ToString(yIndex);
            string strXIndex = Convert.ToString(xIndex);


            
            /*
            //sets the position of the stage
            string gcode = "G0 X" + strXIndex + " Y" + strYIndex;
            sendCommand(gcode);
            _semaphore.WaitOne();

            sendCommand("G4 P0.01");
            _semaphore.WaitOne();

            lstSerialOutput.Items.Add("Command complete");
            lstSerialOutput.TopIndex = lstSerialOutput.Items.Count - 1;*/


            // intSemaphore.Enqueue(1);
            
            Thread threadwait = new Thread(() =>movePosition(strXIndex, strYIndex));
            threadwait.Start();
            



        }

        private void btnHomePos_Click(object sender, EventArgs e)
        {
            //sends a homing command
            sentHome = true;
            sendCommand("$H");
            sendCommand("g92 x3 y3");
            sendCommand("G0 X4.3 Y3.6");
            sendCommand("g92 x0 y0");
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
