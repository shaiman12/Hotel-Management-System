using RestEasy_System.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasy_System.Database
{
   public class AccountDB: DB
    {
        private static string table1 = "Accounts";

        private string sql_SELECT1 = "SELECT * FROM Accounts";

        private Collection<Account> accounts;

        private GuestController guestController;
        private BookingController bookingController;


        public Collection<Account> AllAccounts
        {
            get
            {
                return accounts;
            }
        }

        public void setBookingController(BookingController aController)
        {
            this.bookingController = aController;
        }

        public BookingController getBookingController()
        {
            return bookingController;
        }

        public AccountDB(GuestController controller):
            base()
        {
            guestController = controller;
            accounts = new Collection<Account>();
            ReadDataFromTable(sql_SELECT1, table1);
        }

        private void FillAccounts(SqlDataReader reader, string dataTable)
        {
            Account account;
            while (reader.Read())
            {
                
                account = new Account();
                account.AccountNo = reader.GetInt32(0);
                
                string guestID = reader.GetInt32(1)+"";
                
                account.Guest = guestController.FindByID(guestID);
                
                account.AmountDue = reader.GetFloat(2);

                account.CardNo = reader.GetString(3).Trim();
                account.CardName = reader.GetString(4).Trim();
                account.ExpMonth = reader.GetInt32(5);
                account.ExpYear = reader.GetInt32(6);
                accounts.Add(account); 

            }




        }



        private string ReadDataFromTable(string selectString, string table)
        {
            SqlDataReader reader;
            SqlCommand command;
            try
            {

                command = new SqlCommand(selectString, cnMain);
                cnMain.Open();
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    FillAccounts(reader, table);
                }
                reader.Close();
                cnMain.Close();
                return "success";
            }

            catch (Exception ex)
            {
                return (ex.ToString());
            }
        }
        
        private string GetValueString(Account account)
        {
            string aStr;
            aStr = account.AccountNo + ", ' " + account.Guest.GuestID + " ' ," +
               " ' " + account.AmountDue + " ' ," +
               " ' " + account.CardNo + " ' ," +
               " ' " + account.CardName + " ' ," +
               " ' " + account.ExpMonth + " ' , " +
                                " ' " + account.ExpYear + " ' ";


            return aStr;
        }




        public void DatabaseAdd(Account account)
        {
            string sqlString = "";
            sqlString = "INSERT INTO Accounts(AccountNo, GuestID, AmtDue, CardNo, CardName, ExpMonth, ExpYear)"+
                "VALUES (" + GetValueString(account) + ")";
            UpdateDataSource(new SqlCommand(sqlString, cnMain));
        }


        public void DatabaseEdit(Account account)
        {
            string sqlString = "";
            string amt = Math.Round(account.AmountDue, 2) + "";
           amt = amt.Replace(',', '.');

            sqlString = "Update Accounts Set " +
                "AmtDue = "+ amt + ", " +
                              "CardNo = '" + account.CardNo.Trim() + "', " +
                              "CardName = '" + account.CardName.Trim() + "', " +
                              "ExpMonth = " + account.ExpMonth + ", " +
                              "ExpYear = " + account.ExpYear + " " +
                               "WHERE AccountNo = '" + account.AccountNo + "'";

            UpdateDataSource(new SqlCommand(sqlString, cnMain));

        }

        public int FindIndex(int guestID)
        {
            int index = 0;
            bool found = (accounts[index].Guest.GuestID == guestID);
            while (!(found) && (index < accounts.Count() - 1))
            {
                index += 1;
                found = (accounts[index].Guest.GuestID == guestID);
            }



            return index;
        }


        public double newAmount(DateTime start, DateTime end)
        {
            double amt = 0;
            DateTime lowSeasonCutoff = new DateTime(2019, 12, 7);
            DateTime midSeasonCutoff = new DateTime(2019, 12, 15);
            int numDays = Convert.ToInt32(Math.Floor((end - start).TotalDays));
            for (int i = 0; i < numDays; i++)
            {
                DateTime current = start.AddDays(i);

                if (current.DayOfYear <= lowSeasonCutoff.DayOfYear)
                {
                    amt += 550;
                }
                else if (current.DayOfYear <= midSeasonCutoff.DayOfYear)
                {
                    amt += 750;
                }
                else
                {
                    amt += 995;
                }
            }

                return amt;
        }

        public double oldAmt(int bID)
        {
            int index = bookingController.FindIndex(bID);
            DateTime start = bookingController.AllBookings[index].Date;
            DateTime end = bookingController.AllBookings[index].EndDate;
            return newAmount(start, end);
        }



        public double originalAmount(int guestID)
        {
            double amt = 0;
            Collection<Booking> bookings = bookingController.AllBookings;
            Collection<Booking> tempBookings = new Collection<Booking>();
            for(int i = 0; i < bookings.Count; i++)
            {
                if (bookings[i].Guest.GuestID == guestID)
                {
                    tempBookings.Add(bookings[i]);
                }
            }
            DateTime lowSeasonCutoff = new DateTime(2019, 12, 7);
            DateTime midSeasonCutoff = new DateTime(2019, 12, 15);
            foreach (Booking booking in tempBookings)
            {
                int numDays = Convert.ToInt32(Math.Floor((booking.EndDate - booking.Date).TotalDays));
                for(int i = 0; i < numDays; i++)
                {
                    DateTime current = booking.Date.AddDays(i);

                    if (current.DayOfYear <= lowSeasonCutoff.DayOfYear)
                    {
                        amt += 550;
                    }
                    else if (current.DayOfYear <= midSeasonCutoff.DayOfYear)
                    {
                        amt += 750;
                    }
                    else
                    {
                        amt += 995;
                    }
                }


            }




            return amt;
        }


        public double totalDue()
        {
            double sum = 0;
            foreach(Account acc in accounts)
            {
                sum += acc.AmountDue;
            }


            return sum;
        }

        public string highestAmountOwedName()
        {
            string ans = "";
            double max = 0;
            foreach (Account acc in accounts)
            {
                if (acc.AmountDue >max)
                {
                    ans = acc.Guest.FirstName + " " + acc.Guest.Surname;
                    max = acc.AmountDue;
                }



            }


            return ans;
        }

        public string minAmountOwedName()
        {
            string ans = "";
            double min = 10000000;
            foreach (Account acc in accounts)
            {
                if (acc.AmountDue < min)
                {
                    ans = acc.Guest.FirstName + " " + acc.Guest.Surname;
                    min = acc.AmountDue;
                }



            }


            return ans;
        }
        public double minAmountOwed()
        {
            double ans = 0;
            double min = 10000000;
            foreach (Account acc in accounts)
            {
                if (acc.AmountDue < min)
                {
                    ans = acc.AmountDue;
                    min = acc.AmountDue;
                }



            }


            return ans;
        }


        public double highestAmountOwed()
        {
            double ans = 0;
            double max = 0;
            foreach (Account acc in accounts)
            {
                if (acc.AmountDue > max)
                {
                    ans = acc.AmountDue;
                    max = acc.AmountDue;
                }



            }


            return ans;
        }


        public double getAverage()
        {
            double sum = 0;
            foreach(Account acc in accounts)
            {
                sum += acc.AmountDue;
            }



            return sum/accounts.Count;
        }



        public double percentDepositsPaid()
        {
            double count = 0;
            foreach(Account acc in accounts)
            {
                double original = originalAmount(acc.Guest.GuestID);
                if (acc.AmountDue < original - 0.1 * original)
                {
                    count += 1;
                }
            }



            return count / accounts.Count * 100;
        }

        public Collection<Account> getHigherAccounts()
        {
            Collection<Account> tempAccounts = new Collection<Account>();
            foreach(Account acc in accounts)
            {
                if (acc.AmountDue >= getAverage())
                {
                    tempAccounts.Add(acc);
                }

            }



            return tempAccounts;
        }


    }
}
