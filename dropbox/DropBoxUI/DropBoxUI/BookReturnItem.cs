using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DropBoxUI.Models;
using DropBoxUI.Utils;

namespace DropBoxUI
{
    public partial class BookReturnItem : UserControl
    {
        public BookReturnItem(BookReturnModel book)
        {
            InitializeComponent();
            String fullTitle = book.subtitle == "" ? book.title : book.title + ": " + book.subtitle;
            lbTitle.Text = fullTitle.Length <= 50 ? fullTitle : fullTitle.Substring(0, 47) + "...";
            lbEdition.Text = "Edition: " + book.edition;
            lbAuthors.Text = "Author(s): " + (book.authors.Length <= 50 ? book.authors : book.authors.Substring(0, 47) + "...");
            picBook.Load(book.img);
            lbGroup.Text = "Group: " + book.group;
            lbOverdueDay.Text = "Overdue day(s): " + book.overdueDay;
            lbFine.Text = "Fine: " + book.fine + " " + Constant.CURRENCY;
            if (book.status.Contains("OVERDUE"))
            {
                this.lbReturnedAt.Text = "Returned At:";
                this.lbBorrower.Text = "Borrower: " + book.patron;
            }
            else if (book.status.Contains("INVALID"))
            {
                this.lbReturnedAt.Text = "Returned At:";
                this.lbBorrower.Text = "Borrower:";
            }
            else
            {
                this.lbReturnedAt.Text = "Returned At: " + book.returnedAt;
                this.lbBorrower.Text = "Borrower: " + book.patron;
            }

        }
    }
}
