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
   public class GuestDB: DB
    {
        #region Data Members
        private string table1 = "Guests";
        private string sql_SELECT1 = "SELECT * FROM Guests";
        private Collection<Guest> guests;
        #endregion


        #region Property Methods

        public Collection<Guest> AllGuests
        {
            get
            {
                return guests;
            }
        }


        #endregion


        #region Constructor  

        public GuestDB() : base()
        {

            guests = new Collection<Guest>();
            ReadDataFromTable(sql_SELECT1, table1);
        }
        #endregion



        #region Data Reader
        private void FillGuests(SqlDataReader reader, string dataTable, Collection<Guest> guests)
        {

            Guest guest;
            while (reader.Read())
            {
                guest = new Guest();
                guest.GuestID = reader.GetInt32(0);
                guest.FirstName = reader.GetString(1).Trim();
                guest.Surname = reader.GetString(2).Trim();
                guest.Email = reader.GetString(3).Trim();
                guest.PhoneNumber = reader.GetString(4).Trim();
                guest.Address = reader.GetString(5).Trim();

                guests.Add(guest);
            }
        }

        #region ReadDataFromTable

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
                    FillGuests(reader, table, guests);
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

        #endregion


        #endregion

        private string GetValueString(Guest tempGuest)
        {
            string aStr;

            aStr = tempGuest.GuestID + 
                ", ' " + tempGuest.FirstName + " ' ," +
                " ' " + tempGuest.Surname + " ' ," +
                " ' " + tempGuest.Email + " ' ," +
                " ' " + tempGuest.PhoneNumber + " ' ," +
                " ' " + tempGuest.Address + " ' ";

            return aStr;
        }


        public void DatabaseAdd(Guest aGuest)
        {
            string strSQL;
            strSQL = "INSERT INTO Guests(GuestID, [First Name], Surname, " +
                "Email, [Phone Number], Address)" +
                "VALUES (" + GetValueString(aGuest) + ")";
            UpdateDataSource(new SqlCommand(strSQL, cnMain));

        }

        public void DatabaseEdit(Guest tempGuest)
        {
            string sqlString = "";
            sqlString = "Update Guests Set [First Name] = '" + tempGuest.FirstName.Trim() + "'," +
                            "Surname = '" + tempGuest.Surname.Trim() + "'," +
                            "Email = '" + tempGuest.Email.Trim() + "'," +
                            "[Phone Number] = '" + tempGuest.PhoneNumber.Trim() + "'," +
                            "Address = '" + tempGuest.Address.Trim() + "'" +
                             "WHERE GuestId = '" + tempGuest.GuestID + "'";

            UpdateDataSource(new SqlCommand(sqlString, cnMain));

        }




    }
}
