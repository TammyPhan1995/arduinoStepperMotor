using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropBoxUI
{
    public partial class SetUpForm : Form
    {
        private const string CLOSED_DOOR_MSG = "CLOSED";
        private const string OPENED_DOOR_MSG = "OPENED";
        private const string ACK_MSG = "ACK";

        private bool isFDConnecting = false;
        private bool isBDConnection = false;
        private bool isScannerConnection = false;
        string[] ports;

        private string FDmsg = "";

        public SetUpForm()
        {
            InitializeComponent();
        }

        private void SetUpForm_Load(object sender, EventArgs e)
        {
            cbBackDoorPort.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFrontDoorPort.DropDownStyle = ComboBoxStyle.DropDownList;
            cbScannerPort.DropDownStyle = ComboBoxStyle.DropDownList;
            gbFD.Enabled = false;
            gbBD.Enabled = false;
        }

        private void btnGetAllPort_Click(object sender, EventArgs e)
        {
            ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cbBackDoorPort.Items.Add(port);
                cbFrontDoorPort.Items.Add(port);
                cbScannerPort.Items.Add(port);
                if (ports[0] != null)
                {
                    cbBackDoorPort.SelectedItem = ports[0];
                    cbFrontDoorPort.SelectedItem = ports[0];
                    cbScannerPort.SelectedItem = ports[0];
                }
            }


        }

        private void btFDConnect_Click(object sender, EventArgs e)
        {
            if (!isFDConnecting)
            {
                connectToFB();
            }
            else
            {
                disconnectFromFB();
            }
        }

        private void AppendTextPlus(RichTextBox txtBox, string text, Color color)
        {
            try
            {
                txtBox.SelectionStart = txtBox.TextLength;
                txtBox.SelectionLength = 0;

                txtBox.SelectionColor = color;
                txtBox.AppendText(text);
                txtBox.SelectionColor = txtBox.ForeColor;
                txtBox.ScrollToCaret();

            }
            catch (Exception)
            {

            }
        }

        private void AppendTextPlus(RichTextBox txtBox, string text)
        {
            txtBox.SelectionStart = txtBox.TextLength;
            txtBox.SelectionLength = 0;

            txtBox.AppendText(text);
            txtBox.SelectionColor = txtBox.ForeColor;
            txtBox.ScrollToCaret();
        }

        private void connectToFB()
        {
            string selectedPort = cbFrontDoorPort.GetItemText(cbFrontDoorPort.SelectedItem);
            serialFrontDoor.PortName = selectedPort;
            serialFrontDoor.BaudRate = 9600;
            serialFrontDoor.Parity = Parity.None;
            serialFrontDoor.DataBits = 8;
            serialFrontDoor.StopBits = StopBits.One;

            try
            {
                serialFrontDoor.Open();
                serialFrontDoor.Write("#CONX\n");
                isFDConnecting = true;
        
            }
            catch (Exception e)
            {
                AppendTextPlus(txtLog, GetCurrentTime() + e.Message + "\n", Color.Red);
            }
            if (isFDConnecting)
            {
                btFDConnect.Text = "Disconnect";
                gbFD.Enabled = true;
                cbFrontDoorPort.Enabled = false;
                AppendTextPlus(txtLog, GetCurrentTime() + "Connected to Front Door\n");
                txtLog.ScrollToCaret();
            }
        }

        private void disconnectFromFB()
        {
            try
            {
                serialFrontDoor.Close();
                isFDConnecting = false;
            }
            catch (Exception e)
            {
                AppendTextPlus(txtLog, GetCurrentTime() + e.Message + "\n", Color.Red);
            }
            btFDConnect.Text = "Connect";
            gbFD.Enabled = false;
            cbFrontDoorPort.Enabled = true;
            AppendTextPlus(txtLog, GetCurrentTime() + "Disconnected from Front Door\n", Color.Red);
        }

        private String GetCurrentTime()
        {
            return DateTime.Parse(DateTime.Now.ToString()).ToString("HH:mm:ss") + ": ";
        }

        private void btFBUp_Click(object sender, EventArgs e)
        {
            if (isFDConnecting)
            {
                serialFrontDoor.Write("#FDOP\n");
            }
        }

        private void btFDDown_Click(object sender, EventArgs e)
        {
            if (isFDConnecting)
            {
                serialFrontDoor.Write("#FDCL\n");
            }
        }

        private void serialFrontDoor_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            this.FDmsg = serialFrontDoor.ReadLine();
            Console.WriteLine(this.FDmsg);
            if (this.FDmsg.Contains(ACK_MSG))
            {
               // AppendTextPlus(txtLog, GetCurrentTime() + "Front Door Acknowledged\n");
            }
            else if(this.FDmsg.Contains(CLOSED_DOOR_MSG))
            {
               // AppendTextPlus(txtLog, GetCurrentTime() + "Front Door Closed\n");
            }
            else if (this.FDmsg.Contains(OPENED_DOOR_MSG))
            {
               // AppendTextPlus(txtLog, GetCurrentTime() + "Front Door Opened\n");
            }

        }
    }
}
