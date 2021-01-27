using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropBoxUI
{
    public partial class ReturnForm : Form
    {
        string portFD;
        string portBD;

        public ReturnForm(string portFD, string portBD)
        {
            InitializeComponent();
            this.portFD = portFD;
            this.portBD = portBD;
        }
    }
}
