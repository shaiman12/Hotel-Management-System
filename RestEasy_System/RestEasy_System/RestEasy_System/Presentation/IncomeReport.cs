using RestEasy_System.Database;
using RestEasy_System.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestEasy_System.Presentation
{
    public partial class IncomeReport : Form
    {

        private GuestController guestController;
        private Collection<Guest> guests;
        public bool reportFormClosed = false;
        private GuestMDIParent mdiParentForm;
        private BookingController bookingController;
        private Collection<Booking> bookings;
        private AccountDB accountDB;
        private Collection<Account> accounts;
        public IncomeReport(GuestController guestController, BookingController controller, AccountDB acctDB)
        {
            InitializeComponent();
            this.Text = "Income Report";
            this.guestController = guestController;
            guests = guestController.AllGuests;
            bookingController = controller;
            bookings = bookingController.AllBookings;
            accountDB = acctDB;
            accounts = acctDB.AllAccounts;
            this.Load += ReportForm_Load;
            this.Activated += ReportForm_Activated;
            this.FormClosed += ReportForm_FormClosed;


        }



        private void ReportForm_Load(object sender, EventArgs e)
        {
            mdiParentForm = (GuestMDIParent)this.MdiParent;
            highDebtorsListView.View = View.Details;


        }

        private void ReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            reportFormClosed = true;
        }

        private void ReportForm_Activated(object sender, EventArgs e)
        {
            highDebtorsListView.View = View.Details;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            totalAmountTextBox.Text = "R" + Math.Round(accountDB.totalDue(),2);
            highestAmountOwedTextBox.Text = "R"+ Math.Round(accountDB.highestAmountOwed(),2);
            highDebtorNameTextBox.Text = accountDB.highestAmountOwedName();
            lowestAmountOwedTextBox.Text =  "R" + Math.Round(accountDB.minAmountOwed(), 2);
            lowestNameTextBox.Text = accountDB.minAmountOwedName();
            aveAmountOwedTextBox.Text = "R" + Math.Round(accountDB.getAverage(), 2);
            depositTextBox.Text = Math.Round(accountDB.percentDepositsPaid(), 2) + "%";
            Collection<Account> highAccs = accountDB.getHigherAccounts();
            setUpAccountListView(highAccs);


        }


        private void setUpAccountListView(Collection<Account> accs)
        {
            ListViewItem accountDetails;
            highDebtorsListView.Clear();
            highDebtorsListView.Columns.Insert(0, "Account ID", 170, HorizontalAlignment.Left);
            highDebtorsListView.Columns.Insert(1, "Guest Fullname", 200, HorizontalAlignment.Left);
            highDebtorsListView.Columns.Insert(2, "Total Amount Due", 200, HorizontalAlignment.Left);

            foreach (Account acc in accs)
            {
                accountDetails = new ListViewItem();
                accountDetails.Text = acc.AccountNo.ToString();
                string fullname = acc.Guest.FirstName + " " + acc.Guest.Surname;
                accountDetails.SubItems.Add(fullname);
                accountDetails.SubItems.Add("R"+acc.AmountDue.ToString());

                highDebtorsListView.Items.Add(accountDetails);

            }
            highDebtorsListView.Refresh();
            highDebtorsListView.GridLines = true;




        }
    }
}
