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
    public partial class AccountForm : Form
    {
        public Boolean accountFormClosed = false;
        private GuestMDIParent mdiParentForm;
        private AccountDB accountDB;
        private Collection<Account> accounts;
        private Account currentAccount;
        private String myState = "view";
        private GuestController guestController;
        private bool added = false;


        public AccountForm(AccountDB accountDB, GuestController aController)
        {
            InitializeComponent();
            this.Text = "Accounts";
            this.Load += AccountForm_Load;
            this.Activated += AccountForm_Activated;
            this.FormClosed += AccountForm_FormClosed;
            this.accountDB = accountDB;
            accounts = accountDB.AllAccounts;
            currentAccount = accounts[0];
            guestController = aController;

        }



        private void AccountForm_Load(object sender, EventArgs e)
        {
            mdiParentForm = (GuestMDIParent)this.MdiParent;
            accountsListView.View = View.Details;
            setUpAccountListView();


        }

        private void AccountForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            accountFormClosed = true;
        }

        private void AccountForm_Activated(object sender, EventArgs e)
        {
            accountsListView.View = View.Details;
            setUpAccountListView();
        }

        public void setUpAccountListView()
        {
            ListViewItem accountDetails;
            accountsListView.Clear();
            accountsListView.Columns.Insert(0, "Account ID",120, HorizontalAlignment.Left);
            accountsListView.Columns.Insert(1, "Guest ID", 120, HorizontalAlignment.Left);
            accountsListView.Columns.Insert(2, "Guest Fullname", 150, HorizontalAlignment.Left);
            accountsListView.Columns.Insert(3, "Amount Due", 120, HorizontalAlignment.Left);
            accountsListView.Columns.Insert(4, "Cardholder Name", 150, HorizontalAlignment.Left);
            accountsListView.Columns.Insert(5, "Card Number", 120, HorizontalAlignment.Left);

            foreach(Account acc in accounts)
            {
                accountDetails = new ListViewItem();
                accountDetails.Text = acc.AccountNo.ToString();
                accountDetails.SubItems.Add(acc.Guest.GuestID.ToString());
                string fullname = acc.Guest.FirstName + " " + acc.Guest.Surname;
                accountDetails.SubItems.Add(fullname);
                accountDetails.SubItems.Add(acc.AmountDue.ToString());
                accountDetails.SubItems.Add(acc.CardName);
                accountDetails.SubItems.Add(acc.CardNo);

                accountsListView.Items.Add(accountDetails);

            }
            accountsListView.Refresh();
            accountsListView.GridLines = true;




        }



        private Account PopulateAccount()
        {
            Account account = new Account();
            account.AccountNo = Convert.ToInt32(accountNumberTextBox.Text);
            String guestID = guestIDTextBox.Text;
            account.Guest = guestController.FindByID(guestID);
            account.AmountDue = Convert.ToDouble(amtDueTextBox.Text);
            account.CardNo = cardNoTextBox.Text;
            account.CardName = cardNameTextBox.Text;

            account.ExpYear = Decimal.ToInt32(expYearUpDown.Value);

            account.ExpMonth = Decimal.ToInt32(expMonthUpDown.Value);





            return account;
        }


        public void FormDisplay(string stateValue)
        {
            myState = stateValue;
            switch (myState)
            {
                case "add":
                    EnableEntries(true);
                    cancelButton.Enabled = false;
                    accountNumberTextBox.Text = (accounts.Count() + 1) + "";
                    guestIDTextBox.Text = (guestController.AllGuests.Count()) + "";
                    
                    amtDueTextBox.Text = 0+"";
                    cardNameTextBox.Text = "";
                    cardNoTextBox.Text = "";
                    


                break;
                case "edit":
                    EnableEntries(true);

                    submitButton.Enabled = true;
                    paymentButton.Enabled = true;

                    break;

                case "view":
                    EnableEntries(false);
                    submitButton.Enabled = false;
                    paymentButton.Enabled = false;
                    DisplayDetails(currentAccount);

                    break;



            }






        }


        private void EnableEntries(bool value)
        {
            cardNoTextBox.Enabled = value;
            cardNameTextBox.Enabled = value;
            expMonthUpDown.Enabled = value;
            expYearUpDown.Enabled = value;
            paymentTextBox.Enabled = value;
        }

        private bool IsDigitOnly(string str)
        {
            foreach(char c in str)
            {

                if (c < '0' || c > '9')
                    if (c != ',' && c != '.')
                    {
                        return false;
                    }
            }
            return true;

        }


        private bool inputCorrectSubmit()
        {
            bool correct = true;
            string errorMessage = "";

            bool cardNoOkay = IsDigitOnly(cardNoTextBox.Text);
            if (!cardNoOkay)
            {
                errorMessage += "Error: Card Number can only have digits. ";
            }

            bool cardNameOkay = cardNameTextBox.Text.All(Char.IsLetter)|| cardNameTextBox.Text.Any(Char.IsWhiteSpace);
            if (!cardNameOkay)
            {
                errorMessage += "Error: Card Holder Name can only have letters (no digits or special characters). ";
            }

            bool inputsEmpty = false;
            if (string.IsNullOrEmpty(cardNameTextBox.Text) || string.IsNullOrEmpty(cardNoTextBox.Text))
            {
                inputsEmpty = true;
                errorMessage = "Error: Inputs cannot be left empty. ";
            }

            errorTextBox.Text = errorMessage;
            
            if (!cardNoOkay||!cardNameOkay||inputsEmpty)
            {
                correct = false;
            }


            return correct;
        }






        private void SubmitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = default(DialogResult);
            bool x = inputCorrectSubmit();
            if (x)
            {
                switch (myState)
                {
                    case "add":
                        currentAccount = PopulateAccount();

                        accounts.Add(currentAccount);
                        accountDB.DatabaseAdd(currentAccount);
                        added = true;
                        this.Close();
                        break;
                    case "edit":
                        currentAccount = PopulateAccount();
                        accounts.RemoveAt(FindIndex(currentAccount.AccountNo));
                        accounts.Add(currentAccount);
                        accountDB.DatabaseEdit(currentAccount);
                        setUpAccountListView();

                        break;
                }
                myState = "view";
                FormDisplay(myState);
            }

        }

        private int FindIndex(int accID)
        {
            int index = 0;
            bool found = (accounts[index].AccountNo == accID);
            while (!(found) && (index < accounts.Count() - 1))
            {
                index += 1;
                found= (accounts[index].AccountNo == accID);
            }



            return index;
        }

        private Account Find(int accID)
        {
            int index = 0;
            bool found = (accounts[index].AccountNo == accID);
            while (!(found) && (index < accounts.Count() - 1))
            {
                index += 1;
                found = (accounts[index].AccountNo == accID);
            }



            return accounts[index];
        }


        private void DisplayDetails(Account account)
        {
            accountNumberTextBox.Text = account.AccountNo.ToString();
            guestIDTextBox.Text = account.Guest.GuestID.ToString();
            amtDueTextBox.Text = account.AmountDue.ToString();
            cardNoTextBox.Text = account.CardNo;
            cardNameTextBox.Text = account.CardName;
            expMonthUpDown.Value = account.ExpMonth;
            expYearUpDown.Value = account.ExpYear;
            originalAmtTextBox.Text = accountDB.originalAmount(account.Guest.GuestID) + "";

            if (Convert.ToDouble(amtDueTextBox.Text) < Convert.ToDouble(originalAmtTextBox.Text) - 0.1 * Convert.ToDouble(originalAmtTextBox.Text))
            {
                depositCheckBox.Checked = true;
            }
            else
            {
                depositCheckBox.Checked = false;
            }

        }

        private void AccountsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (accountsListView.SelectedItems.Count > 0)
            {
                currentAccount = Find(Convert.ToInt32(accountsListView.SelectedItems[0].Text));
                DisplayDetails(currentAccount);
            }
        }


        private bool paymentCorrect()
        {
            bool correct = true;
            string errorMessage = "";


            if (string.IsNullOrEmpty(paymentTextBox.Text))
            {
                correct = false;
                errorMessage += "Error: Cannot have empty payment. ";
            }
            else
            {

                if (!IsDigitOnly(paymentTextBox.Text))
                {
                    correct = false;
                    errorMessage += "Error: Cannot have letters or special characters in payments box. ";
                }
                else
                {
                    string str = paymentTextBox.Text;
                    if (str.IndexOf('.') > -1)
                    {
                        str = str.Replace('.', ',');
                    }


                    double amt = Convert.ToDouble(str);
                    double amtDue = Convert.ToDouble(amtDueTextBox.Text);

                    if (amt > amtDue)
                    {
                        correct = false;
                        errorMessage += "Error: Amount requested to be paid is higher than the amount due for this account. ";
                    }
                }
            }
            errorTextBox.Text = errorMessage;

            return correct;
        }




        private void PaymentButton_Click(object sender, EventArgs e)
        {
            bool paymentOkay = paymentCorrect();
            if (paymentOkay)
            {
                if (!String.IsNullOrEmpty(paymentTextBox.Text))
                {
                    string str = paymentTextBox.Text;
                    if (str.IndexOf('.') > -1)
                    {
                        str = str.Replace('.', ',');
                    }


                    double amt = Convert.ToDouble(str);


                    amtDueTextBox.Text = (currentAccount.AmountDue - amt) + "";
                    currentAccount = PopulateAccount();

                    accounts.RemoveAt(FindIndex(currentAccount.AccountNo));
                    accounts.Add(currentAccount);
                    accountDB.DatabaseEdit(currentAccount);
                    setUpAccountListView();
                    paymentTextBox.Text = "";
                    if (Convert.ToDouble(amtDueTextBox.Text) <Convert.ToDouble(originalAmtTextBox.Text)- 0.1 * Convert.ToDouble(originalAmtTextBox.Text))
                    {
                        depositCheckBox.Checked = true;
                    }
                    else
                    {
                        depositCheckBox.Checked = false;
                    }





                }
            }
                
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (myState == "add")
            {
                errorTextBox.Text = "Cannot Exit Without Creating Account. ";
            }
            else
            {
                this.Close();
            }
        }

        private void AccountForm_Load_1(object sender, EventArgs e)
        {

        }

        private void AccountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myState == "add") { 
            if (added == false)
            {
                    if (MessageBox.Show("You cannot close this window without creating an account for a guest", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) {
                        e.Cancel = true; }
            }
        }
           
        }
    }
}
