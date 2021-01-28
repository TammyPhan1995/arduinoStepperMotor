using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DropBoxUI.Models;
using DropBoxUI.Processors;
using DropBoxUI.Utils;

namespace DropBoxUI
{
    public partial class ReturnForm : Form
    {

        enum DoorStatus {
             FRONT_OPENED,
             FRONT_OPENING,
             FRONT_CLOSED,
             FRONT_CLOSING,
             BACK_OPENED,
             BACK_OPENING,
             BACK_CLOSED,
             BACK_CLOSING,
        }

        enum BookStatus
        {
            RETURNED,
            INVALID,
            OVERDUE
        }

        enum ProcessStatus
        {
            START,
            ERROR,
            RETURNED,
            RESET,
            ERROR_NO_BOOK
        }

        enum ButtonText
        {
            START,
            DONE
        }

        private ProcessStatus processStatus;
        private string portFont;
        private string portBack;
        private string fontMsg;
        private string backMsg;

        private DoorStatus frontDoorStatus = DoorStatus.FRONT_CLOSED;
        private DoorStatus backDoorStatus = DoorStatus.BACK_CLOSED;

        private int sesionTime;
        private string bookRfid;
        private int numberOfBookScanned = 0;



        public ReturnForm(string portFont, string portBack)
        {
            InitializeComponent();
            this.portFont = portFont;
            this.portBack = portBack;

        }

        private void ReturnForm_Load(object sender, EventArgs e)
        {
            //connectToSerialPortBackDoor(portBack);
            connectToSerialPortFrontDoor(portFont);
            resetState();
           
        }


        private void connectToSerialPortFrontDoor(string portName)
        {
            serialFrontDoor.PortName = portName;
            serialFrontDoor.BaudRate = 9600;
            serialFrontDoor.Parity = Parity.None;
            serialFrontDoor.DataBits = 8;
            serialFrontDoor.StopBits = StopBits.One;

            try
            {
                serialFrontDoor.Open();
                serialFrontDoor.Write("#CONX\n");
                Console.WriteLine("Connected to front port");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void connectToSerialPortBackDoor(string portName)
        {
            serialBackDoor.PortName = portName;
            serialBackDoor.BaudRate = 9600;
            serialBackDoor.Parity = Parity.None;
            serialBackDoor.DataBits = 8;
            serialBackDoor.StopBits = StopBits.One;

            try
            {
                serialBackDoor.Open();
                serialBackDoor.Write("#CONX\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }




        //get response from back door arduino to change UI state
        private void serialBackDoor_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
           
            //backMsg = serialBackDoor.ReadLine();
            //if (backMsg.Contains(ArduinoMessage.RP_BACK_OPENED))
            //{
            //    backDoorStatus = DoorStatus.BACK_OPENED;
            //}else if (backMsg.Contains(ArduinoMessage.RP_BACK_CLOSED))
            //{
            //    backDoorStatus = DoorStatus.BACK_CLOSED;
            //}
        }

        //get response from front door arduino to change UI state
        private void serialFontDoor_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {           
        }



        private void timerSession_Tick(object sender, EventArgs e)
        {
            sesionTime -= 1;
            lbsession.Text = "SESSION TIMEOUT: " + this.sesionTime;
            if (sesionTime == 0)
            {
                timerSession.Stop();
                timerSession.Enabled = false;
                //reset lại từ đầu
            }
        }

        private void resetState()
        {
            pnFlow.Controls.Clear();
            frontDoorStatus = DoorStatus.FRONT_CLOSED;
            backDoorStatus = DoorStatus.BACK_CLOSED;
            timerSession.Enabled = false;
            timerCountBook.Enabled = false;
            sesionTime = Constant.PROCESS_SESSION_TIME_OUT;
            spiner.Hide();
            txtBookRfid.Text = "";
            txtBookRfid.Enabled = false;
            numberOfBookScanned = 0;
            bookRfid = "";
            btStart.Enabled = true;
            btStart.Text = ButtonText.START.ToString();
            lbMessage.Text = "Click start to begin return";
            lbsession.Hide();
        }

        private async void callReturnAPI()
        {
            timerSession.Enabled = false;
            spiner.Show();
            //call here
            ReturnResponseModel rs = await BookProcessor.returnBook(bookRfid);
            spiner.Hide();
            timerSession.Enabled = true;
            if (rs.isSuccess)
            {
                if (rs.book.status.Contains(BookStatus.RETURNED.ToString()))
                {
                    processStatus = ProcessStatus.RETURNED;
                    btStart.Text = ButtonText.DONE.ToString();
                    btStart.Enabled = true;

                    //openBackDoor();
                }
                else if (rs.book.status.Contains(BookStatus.INVALID.ToString()))
                {
                    processStatus = ProcessStatus.ERROR;
                    openFrontDoor();
                }
                else if (rs.book.status.Contains(BookStatus.OVERDUE.ToString()))
                {
                    processStatus = ProcessStatus.ERROR;
                    openFrontDoor();
                }
                BookReturnItem item = new BookReturnItem(rs.book);
                item.Width = pnFlow.Width - 10;
                pnFlow.Controls.Add(item);
            }
            else
            {
                lbMessage.Text = rs.errorMessage;
                processStatus = ProcessStatus.ERROR;
                openFrontDoor();
            }

        }

        private void txtBookRfid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter 
                && backDoorStatus == DoorStatus.BACK_CLOSED
                && frontDoorStatus == DoorStatus.FRONT_CLOSED)
            {
                bookRfid = txtBookRfid.Text.Trim();
                if(bookRfid.Length == Constant.TID_LENGTH)
                {
                    numberOfBookScanned++;
                }
                else
                {
                    lbMessage.Text = "Message: Invalid item. Open front door";
                }
                txtBookRfid.Text = "";
                txtBookRfid.Focus();
            }
        }

        //call when close front door to scan
        private void timerCountBook_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("het count");
            timerCountBook.Stop();
            timerCountBook.Enabled = false;
            Console.WriteLine("stop conter");
            txtBookRfid.Text = "";
            txtBookRfid.Enabled = false;
            if (numberOfBookScanned < 1)
            {
                Console.WriteLine("No item. Cancel return");
                lbMessage.Text = "No item. Cancel return"; //hien message trong vài giây r reset
                processStatus = ProcessStatus.RESET;
            }
            else if (numberOfBookScanned > 1)
            {
                lbMessage.Text = "Message: Only one item per time. Open front door";
                processStatus = ProcessStatus.ERROR;
                openFrontDoor();
            }
            else
            {
                callReturnAPI();
            }

        }

        //bat dau tu day
        private void btStart_Click(object sender, EventArgs e)
        {
            if(btStart.Text == ButtonText.START.ToString())
            {
                btStart.Enabled = false;
                lbMessage.Text = "Place 1 book to when door opens";
                processStatus = ProcessStatus.START;
                timerSession.Enabled = true;
                lbsession.Show();
                openFrontDoor();
            }else if (btStart.Text == ButtonText.DONE.ToString())
            {
                //reset
                resetState();
            }



        }

        private void openFrontDoor()
        {
            if (serialFrontDoor.IsOpen)
            {
                lbMessage.Text = "Opening Front Door";
                serialFrontDoor.Write(ArduinoMessage.RQ_FONT_OPEN);
                frontDoorStatus = DoorStatus.FRONT_OPENING;
            }
            while (serialFrontDoor.IsOpen )
            {
                fontMsg = serialFrontDoor.ReadExisting();
                Console.WriteLine("--------" + fontMsg);
                if (fontMsg.Contains(ArduinoMessage.RP_FONT_OPENED))
                {
                    frontDoorStatus = DoorStatus.FRONT_OPENED;
                }
                else if (fontMsg.Contains(ArduinoMessage.RP_FONT_CLOSED))
                {
                    frontDoorStatus = DoorStatus.FRONT_CLOSED;
                    if (processStatus == ProcessStatus.START)
                    {
                        Console.WriteLine("bắt đầu scan");
                        enableScanner();
                        timerCountBook.Enabled = true;
                    }
                    else if (processStatus == ProcessStatus.ERROR)
                    {
                        resetState();
                    }
                    break;
                }
                Thread.Sleep(1000);
            }
        }

        private void openBackDoor()
        {
            if (serialBackDoor.IsOpen)
            {
                serialBackDoor.Write(ArduinoMessage.RQ_BACK_OPEN);
                backDoorStatus = DoorStatus.BACK_OPENING;
            }
        }

        private void enableScanner()
        {
            txtBookRfid.Text = "";
            txtBookRfid.Enabled = true;
            txtBookRfid.Focus();
        }

    }
}
