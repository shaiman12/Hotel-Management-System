using RestEasy_System.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasy_System.Entities
{
   public class GuestController
    {
        #region fields
        GuestDB guestDB;
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



        #region Constructors
        public GuestController()
        {
            guestDB = new GuestDB();
            guests = guestDB.AllGuests;
        }



        #endregion

        public void DatabaseAdd(Guest aGuest)
        {
            guestDB.DatabaseAdd(aGuest);
        }

        public void Add(Guest aGuest)
        {
            DatabaseAdd(aGuest);
            guests.Add(aGuest);
        }



        public void DatabaseEdit(Guest aGuest)
        {
            guestDB.DatabaseEdit(aGuest);
        }

        public void Edit(Guest aGuest)
        {
            int count;
            count = FindIndex(aGuest);
            guests[count].FirstName = aGuest.FirstName;
            guests[count].Surname = aGuest.Surname;
            guests[count].Email = aGuest.Email;
            guests[count].PhoneNumber = aGuest.PhoneNumber;
            guests[count].Address = aGuest.Address;
            DatabaseEdit(aGuest);



        }


        public int FindIndex(Guest guest)
        {
            int index = 0;
            bool found = false;
            while (!found && index < guests.Count)
            {
                found = (guests[index].GuestID == guest.GuestID);
                if (!found)
                {
                    index++;
                }
            }
            if (found)
            {
                return index;
            }
            else
            {
                return -1;
            }



        }
        
    public Guest FindByID(String IDvalue)
        {
            int position = 0;
            bool found = (IDvalue == guests[position].GuestID.ToString());
            while (!found && position < guests.Count)
            {
                found = (IDvalue == guests[position].GuestID.ToString());
                if (!found)
                {
                    position += 1;
                }
            }
            if (found)
            {
                return guests[position];
            }
            else
            {
                return null;
            }





        }




    }
}
