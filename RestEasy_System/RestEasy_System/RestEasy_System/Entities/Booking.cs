using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasy_System.Entities
{
   public class Booking
    {
    


        #region fields
        private int bookingRef;
        private int room;
        private DateTime date;
        private DateTime endDate;
        private Guest guest;




        #endregion


        #region Constructor
        public Booking(int bookingRef, int room, DateTime date, DateTime endDate, Guest guest)
        {
            this.bookingRef = bookingRef;
            this.room = room;
            this.date = date;
            this.endDate = endDate;
            this.guest = guest;
        }


        public Booking()
        {
            bookingRef = 0;
            room = 0;
            guest = null;
           
        }

        #endregion


        #region property methods
        public int BookingRef { get => bookingRef; set => bookingRef = value; }
        public int Room { get => room; set => room = value; }
        public DateTime Date { get => date; set => date = value; }
        public Guest Guest { get => guest; set => guest = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }

        #endregion

    }
}
