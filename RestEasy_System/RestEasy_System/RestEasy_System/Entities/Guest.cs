using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasy_System.Entities
{
   public class Guest
    {

        #region fields
        private string firstName; 
       private string surname;
       private string email;
       private string phoneNumber;
       private int guestID;
        private string address;

       


        #endregion

        #region property methods
        public string Surname { get => surname; set => surname = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int GuestID { get => guestID; set => guestID = value; }
        public string Address { get => address; set => address = value; }
        #endregion

        #region constructor


        public Guest()
        {
            firstName = "";
            surname = "";
            email = "";
            phoneNumber = "";
            guestID = 0;
                
        }

        public Guest(string firstName, string surname, string email, string phoneNumber, int guestID, string address)
        {
            this.firstName = firstName;
            this.surname = surname;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.guestID = guestID;
            this.address = address;
        }




        #endregion



        public string toString()
        {
            return firstName + " " + surname + " " + email;
        }








    }
}
