using RestEasy_System.Database;
using RestEasy_System.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestEasy_System.Presentation
{
    public partial class GuestForm : Form
    {

        private GuestMDIParent mdiParentForm;
        public bool guestFormClosed = false;
        private GuestController guestController;
        Guest guest;
        private AccountForm accountForm;
        private AccountDB accountDB;
        private bool isOkay = true;


        public enum FormState
        {
            View = 0,
            Add = 1,
            Edit = 2

        }
        public FormState myState = FormState.View;



        public GuestForm(GuestController aController, AccountDB accDB)
        {
            InitializeComponent();
            guestController = aController;
            accountDB = accDB;
            this.Load += GuestForm_Load;
            this.FormClosed += GuestForm_FormClosed;
            this.Activated += GuestForm_Activated;
            if (myState == FormState.Add)
            {
                int size = aController.AllGuests.Count() + 1;
                idTextBox.Text = size+"";
            }


        }

        private void CreateNewAccountForm()
        {
            accountForm = new AccountForm(accountDB, guestController);
            accountForm.MdiParent = ActiveForm;
            accountForm.StartPosition = FormStartPosition.CenterParent;


        }



        private void GuestForm_Load(object sender, EventArgs e)
        {
            mdiParentForm = (GuestMDIParent)this.MdiParent;
    

        }

        private void GuestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            guestFormClosed = true;
        }

        private void GuestForm_Activated(object sender, EventArgs e)
        {
            guestFormClosed = false;
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }


        private Guest PopulateGuest()
        {


            Guest aGuest = new Guest();
            aGuest.GuestID = Convert.ToInt32(idTextBox.Text);
            aGuest.FirstName = firstNameTextBox.Text;
            aGuest.Surname = surnameTextBox.Text;
            aGuest.Email = emailTextBox.Text;
            aGuest.PhoneNumber = phoneTextBox.Text;
            aGuest.Address = addressTextBox.Text;

            return aGuest;



        }


        private void FormatForm(FormState stateValue)
        {
            switch (stateValue)
            {
                case FormState.View:
                    this.Text = "View a Guest";
                    break;
                case FormState.Add:
                    this.Text = "Add an Guest";
                    int size = guestController.AllGuests.Count() + 1;
                    idTextBox.Text = size + "";
                    idTextBox.Enabled = false;
                    break;
                case FormState.Edit:
                    this.Text = "Edit a Guest";
                    Enable(true);
                    idTextBox.Enabled = false;
                    break;


            }
        }


        private void Enable(bool value)
        {
            idTextBox.Enabled = value;
            firstNameTextBox.Enabled = value;
            surnameTextBox.Enabled = value;
            emailTextBox.Enabled = value;
            phoneTextBox.Enabled = value;
            addressTextBox.Enabled = value;
            submitButton.Visible = value;
            cancelButton.Visible = value;

        }


        public void PopulateForm(Guest aGuest)
        {
            idTextBox.Text = aGuest.GuestID.ToString();
            firstNameTextBox.Text = aGuest.FirstName;
            surnameTextBox.Text = aGuest.Surname;
            emailTextBox.Text = aGuest.Email;
            phoneTextBox.Text = aGuest.PhoneNumber;
            addressTextBox.Text = aGuest.Address;

        }


        public void Display(FormState stateValue)
        {
            myState = stateValue;
            FormatForm(stateValue);
        }

        public void Display(Guest aGuest, FormState stateValue)
        {
            myState = stateValue;
            guest = aGuest;
            PopulateForm(guest);
            FormatForm(myState);

        }


        private bool ensureSafeProcess()
        {
            bool fine = true;
            string errorMessage = "";
            //First check: No digits in name and surname
            string firstName = firstNameTextBox.Text;
            string surname = surnameTextBox.Text;
            bool namesAreBad = firstNameTextBox.Text.Any(char.IsDigit)||surnameTextBox.Text.Any(char.IsDigit)|| firstNameTextBox.Text.Any(char.IsPunctuation) || surnameTextBox.Text.Any(char.IsPunctuation);
            if (namesAreBad)
            {
                errorMessage = "Error: First Name or Surname cannot contain digits or special characters. ";
            }

            bool isempty = (firstName == "" || surname == "" || String.IsNullOrEmpty(emailTextBox.Text) || String.IsNullOrEmpty(phoneTextBox.Text) || String.IsNullOrEmpty(addressTextBox.Text));
           if (isempty)
            {
                errorMessage += "Error: Cannot have empty fields. ";
            }

            bool badEmail = false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(emailTextBox.Text);

            }
            catch
            {
                badEmail = true;
                errorMessage += "Error: Invalid Email Address. ";
            }

            int errorCounter = Regex.Matches(phoneTextBox.Text, @"[a-zA-Z]").Count;
            bool badPhoneNumber = false;
            if (errorCounter > 0)
            {
                badPhoneNumber = true;
                errorMessage += "Error: Phone number cannot have letters";
            }



            messageTextBox.Text = errorMessage;

            if (namesAreBad||isempty||badEmail||badPhoneNumber)
            {
                fine = false;
            }





            return fine;
        }


        private void SubmitButton_Click(object sender, EventArgs e)
        {
            switch (myState)
            {
                case FormState.Add:
                    bool okayToAdd = ensureSafeProcess();
                    if (okayToAdd) { 
                    guest = PopulateGuest();
                    guestController.Add(guest);
                    if (accountForm == null)
                    {
                        CreateNewAccountForm();
                    }
                    if (accountForm.accountFormClosed)
                    {
                        CreateNewAccountForm();
                    }
                    accountForm.FormDisplay("add");
                    accountForm.Show();
                    this.Close(); }
                    break;
                case FormState.Edit:
                    bool okayToEdit = ensureSafeProcess();
                    if (okayToEdit)
                    {
                        guest = PopulateGuest();
                        guestController.Edit(guest);
                        this.Close();
                    }

                   
                    break;
            }



        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void phoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '+'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') > -1))
            {
                e.Handled = true;
            }
        }
    }
    }
