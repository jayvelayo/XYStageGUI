namespace XYStageGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnectDisconnect = new System.Windows.Forms.Button();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.serCOM = new System.IO.Ports.SerialPort(this.components);
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnResetZero = new System.Windows.Forms.Button();
            this.btnHomePos = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lstSerialOutput = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSetXVal = new System.Windows.Forms.TextBox();
            this.txtSetYVal = new System.Windows.Forms.TextBox();
            this.btnSendPosition = new System.Windows.Forms.Button();
            this.lblXPosition = new System.Windows.Forms.Label();
            this.lblYPosition = new System.Windows.Forms.Label();
            this.lstPrevPositions = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnStatus = new System.Windows.Forms.Button();
            this.txtCmdLine = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSoftReset = new System.Windows.Forms.Button();
            this.tmrDataProcess = new System.Windows.Forms.Timer(this.components);
            this.btnUnlock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM Port:";
            // 
            // btnConnectDisconnect
            // 
            this.btnConnectDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectDisconnect.Location = new System.Drawing.Point(16, 95);
            this.btnConnectDisconnect.Name = "btnConnectDisconnect";
            this.btnConnectDisconnect.Size = new System.Drawing.Size(247, 33);
            this.btnConnectDisconnect.TabIndex = 2;
            this.btnConnectDisconnect.Text = "Connect";
            this.btnConnectDisconnect.UseVisualStyleBackColor = true;
            this.btnConnectDisconnect.Click += new System.EventHandler(this.btnConnectDisconnect_Click);
            // 
            // cmbPort
            // 
            this.cmbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Items.AddRange(new object[] {
            "<select port>"});
            this.cmbPort.Location = new System.Drawing.Point(120, 24);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(143, 28);
            this.cmbPort.TabIndex = 3;
            this.cmbPort.Text = "<select port>";
            this.cmbPort.DropDown += new System.EventHandler(this.cmbPort_DropDown);
            // 
            // serCOM
            // 
            this.serCOM.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serCOM_DataReceived);
            // 
            // cmbBaud
            // 
            this.cmbBaud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Items.AddRange(new object[] {
            "115200"});
            this.cmbBaud.Location = new System.Drawing.Point(120, 61);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(143, 28);
            this.cmbBaud.TabIndex = 4;
            this.cmbBaud.Text = "115200";
            this.cmbBaud.DropDown += new System.EventHandler(this.cmbBaud_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baud Rate:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(12, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Position:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(12, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = "X:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(12, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 24);
            this.label7.TabIndex = 10;
            this.label7.Text = "Y:";
            // 
            // btnResetZero
            // 
            this.btnResetZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetZero.Location = new System.Drawing.Point(12, 267);
            this.btnResetZero.Name = "btnResetZero";
            this.btnResetZero.Size = new System.Drawing.Size(173, 33);
            this.btnResetZero.TabIndex = 12;
            this.btnResetZero.Text = "Reset Zero";
            this.btnResetZero.UseVisualStyleBackColor = true;
            this.btnResetZero.Click += new System.EventHandler(this.z);
            // 
            // btnHomePos
            // 
            this.btnHomePos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomePos.Location = new System.Drawing.Point(244, 306);
            this.btnHomePos.Name = "btnHomePos";
            this.btnHomePos.Size = new System.Drawing.Size(173, 33);
            this.btnHomePos.TabIndex = 13;
            this.btnHomePos.Text = "Home Position";
            this.btnHomePos.UseVisualStyleBackColor = true;
            this.btnHomePos.Click += new System.EventHandler(this.btnHomePos_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(240, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 24);
            this.label9.TabIndex = 14;
            this.label9.Text = "Set Position";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(269, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 24);
            this.label10.TabIndex = 15;
            this.label10.Text = "Message:";
            // 
            // lstSerialOutput
            // 
            this.lstSerialOutput.FormattingEnabled = true;
            this.lstSerialOutput.ItemHeight = 16;
            this.lstSerialOutput.Location = new System.Drawing.Point(273, 44);
            this.lstSerialOutput.Name = "lstSerialOutput";
            this.lstSerialOutput.Size = new System.Drawing.Size(493, 84);
            this.lstSerialOutput.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(240, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 24);
            this.label8.TabIndex = 18;
            this.label8.Text = "Y:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(240, 207);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 24);
            this.label11.TabIndex = 17;
            this.label11.Text = "X:";
            // 
            // txtSetXVal
            // 
            this.txtSetXVal.Location = new System.Drawing.Point(273, 208);
            this.txtSetXVal.Name = "txtSetXVal";
            this.txtSetXVal.Size = new System.Drawing.Size(100, 22);
            this.txtSetXVal.TabIndex = 19;
            // 
            // txtSetYVal
            // 
            this.txtSetYVal.Location = new System.Drawing.Point(273, 233);
            this.txtSetYVal.Name = "txtSetYVal";
            this.txtSetYVal.Size = new System.Drawing.Size(100, 22);
            this.txtSetYVal.TabIndex = 20;
            // 
            // btnSendPosition
            // 
            this.btnSendPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendPosition.Location = new System.Drawing.Point(244, 267);
            this.btnSendPosition.Name = "btnSendPosition";
            this.btnSendPosition.Size = new System.Drawing.Size(173, 33);
            this.btnSendPosition.TabIndex = 21;
            this.btnSendPosition.Text = "Send to Position";
            this.btnSendPosition.UseVisualStyleBackColor = true;
            this.btnSendPosition.Click += new System.EventHandler(this.btnSendPosition_Click);
            // 
            // lblXPosition
            // 
            this.lblXPosition.AutoSize = true;
            this.lblXPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXPosition.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblXPosition.Location = new System.Drawing.Point(37, 207);
            this.lblXPosition.Name = "lblXPosition";
            this.lblXPosition.Size = new System.Drawing.Size(20, 24);
            this.lblXPosition.TabIndex = 22;
            this.lblXPosition.Text = "?";
            // 
            // lblYPosition
            // 
            this.lblYPosition.AutoSize = true;
            this.lblYPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYPosition.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblYPosition.Location = new System.Drawing.Point(37, 231);
            this.lblYPosition.Name = "lblYPosition";
            this.lblYPosition.Size = new System.Drawing.Size(20, 24);
            this.lblYPosition.TabIndex = 23;
            this.lblYPosition.Text = "?";
            // 
            // lstPrevPositions
            // 
            this.lstPrevPositions.FormattingEnabled = true;
            this.lstPrevPositions.ItemHeight = 16;
            this.lstPrevPositions.Location = new System.Drawing.Point(454, 208);
            this.lstPrevPositions.Name = "lstPrevPositions";
            this.lstPrevPositions.Size = new System.Drawing.Size(164, 180);
            this.lstPrevPositions.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(450, 181);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(168, 24);
            this.label12.TabIndex = 24;
            this.label12.Text = "Previous Positions:";
            // 
            // btnStatus
            // 
            this.btnStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.Location = new System.Drawing.Point(12, 306);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(173, 33);
            this.btnStatus.TabIndex = 26;
            this.btnStatus.Text = "Get Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // txtCmdLine
            // 
            this.txtCmdLine.Location = new System.Drawing.Point(156, 141);
            this.txtCmdLine.Name = "txtCmdLine";
            this.txtCmdLine.Size = new System.Drawing.Size(538, 22);
            this.txtCmdLine.TabIndex = 28;
            this.txtCmdLine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCmdLine_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(12, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 24);
            this.label13.TabIndex = 27;
            this.label13.Text = "Command line:";
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendCommand.Location = new System.Drawing.Point(700, 139);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(66, 28);
            this.btnSendCommand.TabIndex = 29;
            this.btnSendCommand.Text = "Send";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(12, 398);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(606, 53);
            this.btnStop.TabIndex = 30;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSoftReset
            // 
            this.btnSoftReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoftReset.Location = new System.Drawing.Point(12, 345);
            this.btnSoftReset.Name = "btnSoftReset";
            this.btnSoftReset.Size = new System.Drawing.Size(173, 33);
            this.btnSoftReset.TabIndex = 31;
            this.btnSoftReset.Text = "Soft Reset";
            this.btnSoftReset.UseVisualStyleBackColor = true;
            this.btnSoftReset.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnlock.Location = new System.Drawing.Point(244, 345);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(173, 33);
            this.btnUnlock.TabIndex = 32;
            this.btnUnlock.Text = "Machine Unlock";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 463);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.btnSoftReset);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSendCommand);
            this.Controls.Add(this.txtCmdLine);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.lstPrevPositions);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblYPosition);
            this.Controls.Add(this.lblXPosition);
            this.Controls.Add(this.btnSendPosition);
            this.Controls.Add(this.txtSetYVal);
            this.Controls.Add(this.txtSetXVal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lstSerialOutput);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnHomePos);
            this.Controls.Add(this.btnResetZero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBaud);
            this.Controls.Add(this.cmbPort);
            this.Controls.Add(this.btnConnectDisconnect);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Blouin Lab: XY Stage GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnectDisconnect;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.IO.Ports.SerialPort serCOM;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnResetZero;
        private System.Windows.Forms.Button btnHomePos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lstSerialOutput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSetXVal;
        private System.Windows.Forms.TextBox txtSetYVal;
        private System.Windows.Forms.Button btnSendPosition;
        private System.Windows.Forms.Label lblXPosition;
        private System.Windows.Forms.Label lblYPosition;
        private System.Windows.Forms.ListBox lstPrevPositions;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.TextBox txtCmdLine;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSoftReset;
        private System.Windows.Forms.Timer tmrDataProcess;
        private System.Windows.Forms.Button btnUnlock;
    }
}

