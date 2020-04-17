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
    public partial class OccupancyReport : Form
    {

        private GuestController guestController;
        private Collection<Guest> guests;
        public bool reportFormClosed = false;
        private GuestMDIParent mdiParentForm;
        private BookingController bookingController;
        private Collection<Booking> bookings;
        private AccountDB accountDB;
        private Collection<Account> accounts;
       
    


        public OccupancyReport(GuestController guestController, BookingController controller, AccountDB acctDB)
        {
            InitializeComponent();
            this.Text = "Occupancy Report";
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


        }

        private void ReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            reportFormClosed = true;
        }

        private void ReportForm_Activated(object sender, EventArgs e)
        {
           
        }

        private void StartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            endDateTimePicker.Enabled = true;
            endDateTimePicker.MinDate = startDateTimePicker.Value.AddDays(1);
        }

        private void EndDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            submitButton.Enabled = true;
        }


        private int totalGuests(DateTime start, DateTime end)
        {
            Collection<int> guestIDs = new Collection<int>();
            foreach(Booking booking in bookings)
            {
                if ((booking.Date>=start&&booking.Date<=end)||
                    (booking.EndDate>=start&&booking.EndDate<=end)||
                    (booking.Date>=start&&booking.EndDate<=end))
                {
                    if (guestIDs.IndexOf(booking.Guest.GuestID) == -1)
                    {
                        guestIDs.Add(booking.Guest.GuestID);

                    }
                }
            }

         
            return guestIDs.Count;


        }



        private void SubmitButton_Click(object sender, EventArgs e)
        {
            DateTime start = startDateTimePicker.Value;
            DateTime end = endDateTimePicker.Value;
            totalGuestsTextBox.Text = totalGuests(start, end)+"";
            roomsOccupiedTextBox.Text = Math.Round(bookingController.occupancyAveragePercentage(start, end),2)+"%";
            averageRoomsTextBox.Text = Math.Round(bookingController.averageRoomsPerDay(start, end), 2) + "";
            longestGuestTextBox.Text = bookingController.longestStayName(start,end);
            longStayLengthTextBox.Text = bookingController.longStayLength+"";
            shortestStayTextBox.Text = bookingController.shortestStayName(start, end);
            shortStayLengthTextBox.Text = bookingController.shortStayLength + "";
            averageStayTextBox.Text = bookingController.averageStayLength(start, end)+"";





        }
    }
}
