using RestEasy_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace RestEasy_System.Database
{
    public class BookingDB : DB
    {

        private string table1 = "Bookings";
        private string sql_SELECT1 = "SELECT * FROM Bookings";
        private GuestController guestController;
        private Collection<Booking> bookings;



        public Collection<Booking> AllBookings
        {
            get
            {
                return bookings;
            }
        }


        public BookingDB(GuestController controller) : base()
        {
            bookings = new Collection<Booking>();
            guestController = controller;
            ReadDataFromTable(sql_SELECT1, table1);


        }


        private void fillBookings(SqlDataReader reader, string dataTable)
        {
            Booking booking;
            while (reader.Read())
            {
                booking = new Booking();
                booking.BookingRef = reader.GetInt32(0);
                booking.Room = reader.GetInt32(1);
                booking.Date = reader.GetDateTime(2);
                booking.EndDate = reader.GetDateTime(3);
                string guestID = reader.GetInt32(4) + "";
                booking.Guest = guestController.FindByID(guestID);
                bookings.Add(booking);


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
                    fillBookings(reader, table);
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


        private string GetValueString(Booking tempBooking)
        {
            string aStr;
            aStr = tempBooking.BookingRef + ",  " + tempBooking.Room + " ," +
             "  '" + tempBooking.Date.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'  ," +
             "  '" + tempBooking.EndDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'  , " +
                              "  " + tempBooking.Guest.GuestID + "  ";



            return aStr;
        }

        public void DatabaseAdd(Booking tempBooking)
        {
            string sqlString = "";
            sqlString = "INSERT INTO Bookings(BookingRef, RoomNo, [Start Date], [End Date], GuestID) VALUES (" + GetValueString(tempBooking) + ")";
            UpdateDataSource(new SqlCommand(sqlString, cnMain));



        }

        public void DatabaseDelete(Booking tempBooking)
        {
            string sqlString = "";
            sqlString = "DELETE FROM Bookings WHERE BookingRef = " + tempBooking.BookingRef;
            UpdateDataSource(new SqlCommand(sqlString, cnMain));
        }

        public void DatabaseEdit(Booking aBooking)
        {
            string sqlString = "Update Bookings Set " +
                "RoomNo = " + aBooking.Room + ", " +
                              "[Start Date] = '" + aBooking.Date.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " +
                              "[End Date] = '" + aBooking.EndDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " +
                              "GuestID = " + aBooking.Guest.GuestID + " " +
                               "WHERE BookingRef = '" + aBooking.BookingRef + "'";

            UpdateDataSource(new SqlCommand(sqlString, cnMain));
        }





    }
}
