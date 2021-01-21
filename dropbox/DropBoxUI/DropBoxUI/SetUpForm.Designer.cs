namespace DropBoxUI
{
    partial class SetUpForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbBD = new System.Windows.Forms.GroupBox();
            this.btBDDown = new System.Windows.Forms.Button();
            this.btBDUp = new System.Windows.Forms.Button();
            this.btBDConnect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbBackDoorPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbFD = new System.Windows.Forms.GroupBox();
            this.btFDDown = new System.Windows.Forms.Button();
            this.btFBUp = new System.Windows.Forms.Button();
            this.btFDConnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFrontDoorPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnRight = new System.Windows.Forms.Panel();
            this.btnGetAllPort = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.serialFrontDoor = new System.IO.Ports.SerialPort(this.components);
            this.serialBackDoor = new System.IO.Ports.SerialPort(this.components);
            this.serialUHF = new System.IO.Ports.SerialPort(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel3.SuspendLayout();
            this.gbBD.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbFD.SuspendLayout();
            this.pnRight.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.gbBD);
            this.panel3.Controls.Add(this.btBDConnect);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cbBackDoorPort);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 100);
            this.panel3.TabIndex = 2;
            // 
            // gbBD
            // 
            this.gbBD.Controls.Add(this.btBDDown);
            this.gbBD.Controls.Add(this.btBDUp);
            this.gbBD.Location = new System.Drawing.Point(401, 8);
            this.gbBD.Name = "gbBD";
            this.gbBD.Size = new System.Drawing.Size(176, 81);
            this.gbBD.TabIndex = 7;
            this.gbBD.TabStop = false;
            this.gbBD.Text = "BD Controller";
            // 
            // btBDDown
            // 
            this.btBDDown.Location = new System.Drawing.Point(6, 32);
            this.btBDDown.Name = "btBDDown";
            this.btBDDown.Size = new System.Drawing.Size(75, 23);
            this.btBDDown.TabIndex = 5;
            this.btBDDown.Text = "Down";
            this.btBDDown.UseVisualStyleBackColor = true;
            // 
            // btBDUp
            // 
            this.btBDUp.Location = new System.Drawing.Point(95, 32);
            this.btBDUp.Name = "btBDUp";
            this.btBDUp.Size = new System.Drawing.Size(75, 23);
            this.btBDUp.TabIndex = 4;
            this.btBDUp.Text = "Up";
            this.btBDUp.UseVisualStyleBackColor = true;
            // 
            // btBDConnect
            // 
            this.btBDConnect.Location = new System.Drawing.Point(210, 53);
            this.btBDConnect.Name = "btBDConnect";
            this.btBDConnect.Size = new System.Drawing.Size(146, 24);
            this.btBDConnect.TabIndex = 4;
            this.btBDConnect.Text = "Connect";
            this.btBDConnect.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Port:";
            // 
            // cbBackDoorPort
            // 
            this.cbBackDoorPort.FormattingEnabled = true;
            this.cbBackDoorPort.Location = new System.Drawing.Point(67, 52);
            this.cbBackDoorPort.Name = "cbBackDoorPort";
            this.cbBackDoorPort.Size = new System.Drawing.Size(121, 24);
            this.cbBackDoorPort.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Back Door";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(3, 205);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 100);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "UHF Scanner";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.gbFD);
            this.panel1.Controls.Add(this.btFDConnect);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbFrontDoorPort);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 100);
            this.panel1.TabIndex = 0;
            // 
            // gbFD
            // 
            this.gbFD.Controls.Add(this.btFDDown);
            this.gbFD.Controls.Add(this.btFBUp);
            this.gbFD.Location = new System.Drawing.Point(401, 8);
            this.gbFD.Name = "gbFD";
            this.gbFD.Size = new System.Drawing.Size(176, 81);
            this.gbFD.TabIndex = 6;
            this.gbFD.TabStop = false;
            this.gbFD.Text = "FD Controller";
            // 
            // btFDDown
            // 
            this.btFDDown.Location = new System.Drawing.Point(6, 32);
            this.btFDDown.Name = "btFDDown";
            this.btFDDown.Size = new System.Drawing.Size(75, 23);
            this.btFDDown.TabIndex = 5;
            this.btFDDown.Text = "Down";
            this.btFDDown.UseVisualStyleBackColor = true;
            this.btFDDown.Click += new System.EventHandler(this.btFDDown_Click);
            // 
            // btFBUp
            // 
            this.btFBUp.Location = new System.Drawing.Point(95, 32);
            this.btFBUp.Name = "btFBUp";
            this.btFBUp.Size = new System.Drawing.Size(75, 23);
            this.btFBUp.TabIndex = 4;
            this.btFBUp.Text = "Up";
            this.btFBUp.UseVisualStyleBackColor = true;
            this.btFBUp.Click += new System.EventHandler(this.btFBUp_Click);
            // 
            // btFDConnect
            // 
            this.btFDConnect.Location = new System.Drawing.Point(210, 47);
            this.btFDConnect.Name = "btFDConnect";
            this.btFDConnect.Size = new System.Drawing.Size(146, 24);
            this.btFDConnect.TabIndex = 3;
            this.btFDConnect.Text = "Connect";
            this.btFDConnect.UseVisualStyleBackColor = true;
            this.btFDConnect.Click += new System.EventHandler(this.btFDConnect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Port:";
            // 
            // cbFrontDoorPort
            // 
            this.cbFrontDoorPort.FormattingEnabled = true;
            this.cbFrontDoorPort.Location = new System.Drawing.Point(67, 47);
            this.cbFrontDoorPort.Name = "cbFrontDoorPort";
            this.cbFrontDoorPort.Size = new System.Drawing.Size(121, 24);
            this.cbFrontDoorPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Front Door";
            // 
            // pnRight
            // 
            this.pnRight.Controls.Add(this.btnGetAllPort);
            this.pnRight.Controls.Add(this.panel4);
            this.pnRight.Controls.Add(this.panel1);
            this.pnRight.Controls.Add(this.panel2);
            this.pnRight.Controls.Add(this.panel3);
            this.pnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRight.Location = new System.Drawing.Point(0, 0);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(972, 352);
            this.pnRight.TabIndex = 4;
            // 
            // btnGetAllPort
            // 
            this.btnGetAllPort.Location = new System.Drawing.Point(3, 310);
            this.btnGetAllPort.Name = "btnGetAllPort";
            this.btnGetAllPort.Size = new System.Drawing.Size(582, 37);
            this.btnGetAllPort.TabIndex = 4;
            this.btnGetAllPort.Text = "GET PORTS";
            this.btnGetAllPort.UseVisualStyleBackColor = true;
            this.btnGetAllPort.Click += new System.EventHandler(this.btnGetAllPort_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtLog);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(591, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(381, 352);
            this.panel4.TabIndex = 3;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(6, 4);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(368, 342);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // serialFrontDoor
            // 
            this.serialFrontDoor.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialFrontDoor_DataReceived);
            // 
            // SetUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 352);
            this.Controls.Add(this.pnRight);
            this.Name = "SetUpForm";
            this.Text = "Set Up Connection";
            this.Load += new System.EventHandler(this.SetUpForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.gbBD.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbFD.ResumeLayout(false);
            this.pnRight.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbBackDoorPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFrontDoorPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnRight;
        private System.Windows.Forms.Button btnGetAllPort;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btFDConnect;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btBDConnect;
        private System.IO.Ports.SerialPort serialFrontDoor;
        private System.IO.Ports.SerialPort serialBackDoor;
        private System.IO.Ports.SerialPort serialUHF;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btFDDown;
        private System.Windows.Forms.Button btFBUp;
        private System.Windows.Forms.GroupBox gbFD;
        private System.Windows.Forms.GroupBox gbBD;
        private System.Windows.Forms.Button btBDDown;
        private System.Windows.Forms.Button btBDUp;
    }
}

