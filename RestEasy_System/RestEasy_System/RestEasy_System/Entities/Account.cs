using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasy_System.Entities
{
   public class Account
    {
        private int accountNo;
        private Guest guest;
        private double amountDue;
        private string cardNo;
        private string cardName;
        private int expMonth;
        private int expYear;

        public Account(int accountNo, Guest guest, double amountDue, string cardNo, string cardName, int expMonth, int expYear)
        {

            this.AccountNo = accountNo;
            this.guest = guest;
            this.amountDue = amountDue;
            this.cardNo = cardNo;
            this.cardName = cardName;
            this.expMonth = expMonth;
            this.expYear = expYear;
        }


        public Account()
        {
            accountNo = -1;
            guest = null;
            amountDue = 0;
            cardNo = "";
            cardName = "";
            expMonth = 0;
            expYear = 0;



        }

        public Guest Guest { get => guest; set => guest = value; }
        public double AmountDue { get => amountDue; set => amountDue = value; }
        public string CardNo { get => cardNo; set => cardNo = value; }
        public string CardName { get => cardName; set => cardName = value; }
        public int ExpMonth { get => expMonth; set => expMonth = value; }
        public int ExpYear { get => expYear; set => expYear = value; }
        public int AccountNo { get => accountNo; set => accountNo = value; }

        private void MakePayment(double amt)
        {
            amountDue -= amt;
        }

        private void increaseAmtDue(double amt)
        {
            amountDue += amt;
        }


        public String toString()
        {
            return accountNo + " " + guest.GuestID + " " + amountDue + " " + cardName;

        }




    }
}
