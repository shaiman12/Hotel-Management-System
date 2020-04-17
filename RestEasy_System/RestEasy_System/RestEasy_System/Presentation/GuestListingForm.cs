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
    public partial class GuestListingForm : Form
    {
        public Boolean listFormClosed = false;
        private GuestMDIParent mdiParentForm;
        private GuestController guestController;
        private Collection<Guest> guests;
        private GuestForm guestForm;
        private AccountDB accountDB;


        public GuestListingForm(GuestController aController, AccountDB acctDB)
        {
            InitializeComponent();
            guestController = aController;
            this.Load += GuestListingForm_Load;
            this.FormClosed += GuestListingForm_FormClosed;
            this.Activated += GuestListingForm_Activated;
            accountDB = acctDB;
        }


        private void GuestListingForm_Load(object sender, EventArgs e)
        {
            mdiParentForm = (GuestMDIParent)this.MdiParent;
            guestListView.View = View.Details;
            setUpGuestListView();

        }

        private void GuestListingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            listFormClosed = true;
        }

        private void GuestListingForm_Activated(object sender, EventArgs e)
        {
            listFormClosed = false;
            guestListView.View = View.Details;
            setUpGuestListView();

        }

        public void setUpGuestListView()
        {
            ListViewItem guestDetails;
            //students = null;
            guests = null;
            guests = guestController.AllGuests;
            guestListView.Clear();
            guestListView.Columns.Insert(0, "GuestID", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(1, "First Name", 140, HorizontalAlignment.Left);
            guestListView.Columns.Insert(2, "Surname", 140, HorizontalAlignment.Left);
            guestListView.Columns.Insert(3, "Email", 150, HorizontalAlignment.Left);
            guestListView.Columns.Insert(4, "Phone Number", 140, HorizontalAlignment.Left);
            guestListView.Columns.Insert(5, "Address", 170, HorizontalAlignment.Left);
            foreach(Guest guest in guests)
            {
                

                guestDetails = new ListViewItem();

                guestDetails.Text = guest.GuestID.ToString();
                guestDetails.SubItems.Add(guest.FirstName);
                guestDetails.SubItems.Add(guest.Surname);
                guestDetails.SubItems.Add(guest.Email);
                guestDetails.SubItems.Add(guest.PhoneNumber);
                guestDetails.SubItems.Add(guest.Address);
                guestListView.Items.Add(guestDetails);
            }

            guestListView.Refresh();
            guestListView.GridLines = true;


        }

        private void GuestListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guest guest;
            if (mdiParentForm.currentGuestForm == null)
            {
                guestForm = new GuestForm(guestController, accountDB);
                mdiParentForm.currentGuestForm = guestForm;
            }

            else
            {
                if (mdiParentForm.currentGuestForm.guestFormClosed)
                {
                    guestForm = new GuestForm(guestController, accountDB);
                    mdiParentForm.currentGuestForm = guestForm;
                }
                else
                {
                    guestForm = mdiParentForm.currentGuestForm;
                }

            }

            guest = guestController.FindByID(guestListView.FocusedItem.Text);
            guestForm.MdiParent = (GuestMDIParent)this.MdiParent;
            guestForm.Show();
            guestForm.Display(guest, GuestForm.FormState.Edit);
            guestListView.Refresh();


        }
    }
}
