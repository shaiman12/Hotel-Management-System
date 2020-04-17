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
    public partial class EnquiryForm : Form
    {
        private GuestController guestController;
        private Collection<Guest> guests;
        public bool enquiryFormClosed = false;
        private GuestMDIParent mdiParentForm;
        private BookingController bookingController;
        private Collection<Booking> bookings;
        private AccountDB accountDB;
        private Collection<Account> accounts;
        private Guest currentGuest;



        public EnquiryForm(GuestController guestController, BookingController controller, AccountDB acctDB)
        {
            InitializeComponent();

            this.guestController = guestController;
            guests = guestController.AllGuests;
            bookingController = controller;
            bookings = bookingController.AllBookings;
            accountDB = acctDB;
            accounts = acctDB.AllAccounts;
            for (int i = 0; i < guests.Count(); i++)
            {
                guestComboBox.Items.Add(guests[i].GuestID + ") " + guests[i].FirstName + " " + guests[i].Surname);
            }
            this.Load += EnquiryForm_Load;
            this.Activated += EnquiryForm_Activated;
            this.FormClosed += EnquiryForm_FormClosed;
            currentGuest = guests[0];



        }


        private void EnquiryForm_Load(object sender, EventArgs e)
        {
            mdiParentForm = (GuestMDIParent)this.MdiParent;
           bookingListView.View = View.Details;
            accountsListView.View = View.Details;
           setUpBookingListView();
            setUpAccountListView();

        }

        private void EnquiryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            enquiryFormClosed = true;
        }

        private void EnquiryForm_Activated(object sender, EventArgs e)
        {
            bookingListView.View = View.Details;
            accountsListView.View = View.Details;
            setUpBookingListView();
            setUpAccountListView();
        }

        private void GuestComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string toconv = guestComboBox.SelectedItem + "";
            int pos = toconv.IndexOf(')');
            string id = toconv.Substring(0, pos);
            currentGuest = guestController.FindByID(id);
            setUpBookingListView();
            setUpAccountListView();

        }


        public void setUpBookingListView()
        {
            int guestID = currentGuest.GuestID;
            Collection<Booking> tempBookings = new Collection<Booking>();
            foreach(Booking booking in bookings)
            {
                if(booking.Guest.GuestID == guestID)
                {
                    tempBookings.Add(booking);
                }
            }


                ListViewItem bookingDetails;
                bookingListView.Clear();
                bookingListView.Columns.Insert(0, "Booking Ref", 120, HorizontalAlignment.Left);
                bookingListView.Columns.Insert(1, "Room", 120, HorizontalAlignment.Left);
                bookingListView.Columns.Insert(2, "Arrival Date", 140, HorizontalAlignment.Left);
                bookingListView.Columns.Insert(3, "Leave Date", 140, HorizontalAlignment.Left);
                bookingListView.Columns.Insert(4, "Guest ID", 120, HorizontalAlignment.Left);

                foreach (Booking booking in tempBookings)
                {
                    bookingDetails = new ListViewItem();
                    bookingDetails.Text = booking.BookingRef.ToString();
                    bookingDetails.SubItems.Add(booking.Room.ToString());
                    bookingDetails.SubItems.Add(booking.Date.ToShortDateString());
                    bookingDetails.SubItems.Add(booking.EndDate.ToShortDateString());
                    bookingDetails.SubItems.Add(booking.Guest.GuestID.ToString());
                    bookingListView.Items.Add(bookingDetails);

                }
            if (tempBookings.Count == 0)
            {
                MessageBox.Show("The Selected Guest Has Not Yet Made Any Bookings");
            }



                bookingListView.Refresh();
                bookingListView.GridLines = true;
            
            

        }


        public void setUpAccountListView()
        {
            ListViewItem accountDetails;
            accountsListView.Clear();
            accountsListView.Columns.Insert(0, "Account ID", 120, HorizontalAlignment.Left);
            accountsListView.Columns.Insert(1, "Guest Fullname", 150, HorizontalAlignment.Left);
            accountsListView.Columns.Insert(2, "Amount Due", 130, HorizontalAlignment.Left);
            accountsListView.Columns.Insert(3, "Original Amount Due", 150, HorizontalAlignment.Left);
            accountsListView.Columns.Insert(4, "Deposit Paid", 150, HorizontalAlignment.Left);
            Account acc = new Account();
            foreach(Account account in accounts)
            {
                if (account.Guest.GuestID == currentGuest.GuestID)
                {
                    acc = account;
                    break;
                }
            }
            

                accountDetails = new ListViewItem();
                accountDetails.Text = acc.AccountNo.ToString();
                string fullname = acc.Guest.FirstName + " " + acc.Guest.Surname;
                accountDetails.SubItems.Add(fullname);
                accountDetails.SubItems.Add(acc.AmountDue.ToString());
                double amtDue = acc.AmountDue;
                double originalAmount = accountDB.originalAmount(acc.Guest.GuestID);
                
                accountDetails.SubItems.Add(originalAmount.ToString());
                bool depositPaid = false;
                if (amtDue < (originalAmount - 0.1 * originalAmount))
                {
                    depositPaid = true;
                }
                else
                {
                    depositPaid = false;
                }

                accountDetails.SubItems.Add(depositPaid.ToString());
                accountsListView.Items.Add(accountDetails);

            
            accountsListView.Refresh();
            accountsListView.GridLines = true;




        }
    }
}
