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
    public partial class BookingForm : Form
    {
       private GuestController guestController;
        private Collection<Guest> guests;
        public bool bookingFormClosed = false;
        private GuestMDIParent mdiParentForm;
        private BookingController bookingController;
        private Collection<Booking> bookings;
        private string myState = "view";
        private bool available = true;
        private Booking currentBooking;
        private GuestForm guestForm;
        private AccountDB accountDB;

        public BookingForm(GuestController guestController, BookingController controller, AccountDB acctDB)
        {
            InitializeComponent();
            this.guestController = guestController;
            guests = guestController.AllGuests;
            bookingController = controller;
            bookings = bookingController.AllBookings;
            accountDB = acctDB;
            endDateDateTimePicker.Enabled = false;
            this.Load += BookingForm_Load;
            this.Activated += BookingForm_Activated;
            this.FormClosed += BookingForm_FormClosed;
            currentBooking = bookings[0];
            for(int i = 0; i < guests.Count(); i++)
            {
                guestComboBox.Items.Add(guests[i].GuestID+") "+guests[i].FirstName +" "+ guests[i].Surname);
            }

        }

        private void populateComboBox()
        {
            guestComboBox.Items.Clear();
            for (int i = 0; i < guests.Count(); i++)
            {
                guestComboBox.Items.Add(guests[i].GuestID + ") " + guests[i].FirstName + " " + guests[i].Surname);
            }
        }



        private void CreateNewGuestForm()
        {
            guestForm = new GuestForm(guestController,accountDB);
            guestForm.MdiParent = GuestMDIParent.ActiveForm;
            guestForm.StartPosition = FormStartPosition.CenterParent;




        }



        private void BookingForm_Load(object sender, EventArgs e)
        {
            mdiParentForm = (GuestMDIParent)this.MdiParent;
            bookingListView.View = View.Details;
            setUpBookingListView();


        }

        private void BookingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            bookingFormClosed = true;
        }

        private void BookingForm_Activated(object sender, EventArgs e)
        {
            bookingListView.View = View.Details;
            setUpBookingListView();
        }

        public void setUpBookingListView()
        {
            ListViewItem bookingDetails;
            bookingListView.Clear();
            bookingListView.Columns.Insert(0, "Booking Ref", 120, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(1, "Room", 120, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(2, "Arrival Date", 140, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(3, "Leave Date", 140, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(4, "Guest ID", 120, HorizontalAlignment.Left);

            foreach(Booking booking in bookings)
            {
                bookingDetails = new ListViewItem();
                bookingDetails.Text = booking.BookingRef.ToString();
                bookingDetails.SubItems.Add(booking.Room.ToString());
                bookingDetails.SubItems.Add(booking.Date.ToShortDateString());
                bookingDetails.SubItems.Add(booking.EndDate.ToShortDateString());
                bookingDetails.SubItems.Add(booking.Guest.GuestID.ToString());
                bookingListView.Items.Add(bookingDetails);

            }

            bookingListView.Refresh();
            bookingListView.GridLines = true;


        }


        private Booking PopulateBooking()
        {
            Booking booking = new Booking();
            booking.BookingRef = Convert.ToInt32(bookingNoTextBox.Text);
            booking.Room = Convert.ToInt32(roomNumberTextBox.Text);
            booking.Date = arrivalDateTimePicker.Value;
            booking.EndDate = endDateDateTimePicker.Value;
            string toconv = guestComboBox.SelectedItem + "";
            int pos = toconv.IndexOf(')');
            string id = toconv.Substring(0, pos);

            booking.Guest = guestController.FindByID(id);





            return booking;
        }

        public void FormDisplay(string stateValue)
        {
            myState = stateValue;
            switch (myState)
            {
                case "view":
                    EnableEntries(false);
                    //deleteButton.Enabled = false;
                    submitButton.Enabled = false;
                    endDateDateTimePicker.Enabled = false;
                    DisplayDetails(currentBooking);
                    //Stuff
                    break;
                case "add":
                    EnableEntries(true);
                    submitButton.Enabled = false;
                    guestComboBox.Enabled = false;
                    guestButton.Enabled = false;
                    endDateDateTimePicker.Enabled = false;
                    int highest = (bookings.Count() + 1);
                    for(int i = 0; i < bookings.Count; i++)
                    {
                        if (highest == bookings[i].BookingRef)
                        {
                            highest++;
                        }
                    }
                    bookingNoTextBox.Text = highest + "";

                    break;
                case "edit":
                    EnableEntries(true);
                    submitButton.Enabled = false;
                    guestComboBox.Enabled = false;
                    guestButton.Enabled = false;
                    break;

            }


        }

        private void EnableEntries(bool value)
        {
            roomNumberTextBox.Enabled = false;
            bookingNoTextBox.Enabled = false;
            arrivalDateTimePicker.Enabled = value;
            endDateDateTimePicker.Enabled = value;
            availabilityButton.Enabled = value;
            guestComboBox.Enabled = value;
            guestButton.Enabled = value;
            submitButton.Enabled = value;
            deleteButton.Enabled = value;

        }

        private void DisplayDetails(Booking booking)
        {
            roomNumberTextBox.Text = booking.Room.ToString();
            bookingNoTextBox.Text = booking.BookingRef.ToString();
            arrivalDateTimePicker.Value = booking.Date;
            endDateDateTimePicker.Value = booking.EndDate;
            try
            {
                guestComboBox.SelectedIndex = guestController.FindIndex(currentBooking.Guest);
            }
            catch
            {
                this.Close();
            }
       

        }

        private void BookingListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bookingListView.SelectedItems.Count > 0)
            {
                currentBooking = bookingController.Find(Convert.ToInt32(bookingListView.SelectedItems[0].Text));
                DisplayDetails(currentBooking);
                if (myState == "view")
                {
                    deleteButton.Enabled = true;
                }
            }
        }

        private void AvailabilityButton_Click(object sender, EventArgs e)
        {
            int roomno=-1;
            if (myState == "add")
            {
                roomno = bookingController.getAvailibilityRoomNumber(arrivalDateTimePicker.Value, endDateDateTimePicker.Value);
            }
            if (myState == "edit")
            {
                bookingController.removeBooking(currentBooking.Date, currentBooking.EndDate, currentBooking.Room);
                roomno = bookingController.getAvailibilityRoomNumber(arrivalDateTimePicker.Value, endDateDateTimePicker.Value);

            }
            if (roomno == -1)
            {
                available = false;
                messageTextBox.Text = "No rooms available For these dates";
            }
            else
            {
                messageTextBox.Text = "Room number " + roomno + " is available. Please select Guest";
                roomNumberTextBox.Text = roomno + "";

                guestComboBox.Enabled = true;
                guestButton.Enabled = true;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = default(DialogResult);
            switch (myState)
            {
                case "add":
                    currentBooking = PopulateBooking();
                    double newAmount = accountDB.newAmount(currentBooking.Date, currentBooking.EndDate);
                    int index = accountDB.FindIndex(currentBooking.Guest.GuestID);
                    accountDB.AllAccounts[index].AmountDue += newAmount;
                    bookingController.Add(currentBooking);
                    bookingController.makeBooking(currentBooking.Date, currentBooking.EndDate, currentBooking.Room);
                    setUpBookingListView();
                    guests = guestController.AllGuests;
                    messageTextBox.Text = "";
                    FormDisplay("view");
                    break;
                case "edit":
                    currentBooking = PopulateBooking();
                    int index1 = currentBooking.BookingRef;
                    double oldAmt = accountDB.oldAmt(index1);
                    int index2 = accountDB.FindIndex(currentBooking.Guest.GuestID);
                    accountDB.AllAccounts[index2].AmountDue -= oldAmt;
                    if (accountDB.AllAccounts[index2].AmountDue < 0)
                    {
                        accountDB.AllAccounts[index2].AmountDue = 0;
                    }
                    newAmount = accountDB.newAmount(currentBooking.Date, currentBooking.EndDate);
                    index = accountDB.FindIndex(currentBooking.Guest.GuestID);
                    accountDB.AllAccounts[index].AmountDue += newAmount;
                    bookingController.Edit(currentBooking);
                    bookingController.makeBooking(currentBooking.Date, currentBooking.EndDate, currentBooking.Room);
                    setUpBookingListView();
                    messageTextBox.Text = "";
                    FormDisplay("view");
                    break;
            }



        }

        private void GuestComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (available)
            {
                submitButton.Enabled = true;
            }
        }

        private void GuestButton_Click(object sender, EventArgs e)
        {
            if (guestForm == null)
            {
                CreateNewGuestForm();
            }
            if (guestForm.guestFormClosed)
            {
                CreateNewGuestForm();
            }
            guestForm.Display(GuestForm.FormState.Add);
            guestForm.Show();
            this.Close();


        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int index1 = currentBooking.BookingRef;
            double oldAmt = accountDB.oldAmt(index1);
            int index2 = accountDB.FindIndex(currentBooking.Guest.GuestID);
            accountDB.AllAccounts[index2].AmountDue -= oldAmt;
            if (accountDB.AllAccounts[index2].AmountDue < 0)
            {
                accountDB.AllAccounts[index2].AmountDue = 0;
            }
            accountDB.DatabaseEdit(accountDB.AllAccounts[index2]);
            bookingController.Delete(currentBooking);
            bookingController.removeBooking(currentBooking.Date, currentBooking.EndDate, currentBooking.Room);
            setUpBookingListView();
        }

        private void ArrivalDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            endDateDateTimePicker.Enabled = true;
            endDateDateTimePicker.MinDate = arrivalDateTimePicker.Value.AddDays(1);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
