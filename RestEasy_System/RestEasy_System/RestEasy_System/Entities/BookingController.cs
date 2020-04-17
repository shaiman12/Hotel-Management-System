using RestEasy_System.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasy_System.Entities
{
    public class BookingController
    {
        private BookingDB bookingDB;
        private Collection<Booking> bookings;
        private Collection<Day> occupancy;
        public int longStayLength = 0;
        public int shortStayLength = 0;

        public Collection<Booking> AllBookings
        {
            get
            {
                return bookings;
            }
        }

        public BookingController(GuestController controller)
        {
            bookingDB = new BookingDB(controller);
            bookings = bookingDB.AllBookings;
            occupancy = createOccupancy();
        }

        private Collection<Day> createOccupancy()
        {
            Collection<Day> days = new Collection<Day>();
            DateTime now = DateTime.Now;
            DateTime end = new DateTime(2020, 1, 1);
            int numDays = Convert.ToInt32(Math.Floor((end - now).TotalDays));
            //Populating each day
            for(int i = 0; i < numDays; i++)
            {
                Day day = new Day();
                day.DayOfYear = now.AddDays(i);
                //go through every booking made
                foreach(Booking booking in bookings)
                {
                    //check if this day lies between the start and end days of a booking
                    if (day.DayOfYear.Date >= booking.Date && day.DayOfYear < booking.EndDate)
                    {
                        int roomNumber = booking.Room;
                        day.Rooms[roomNumber] = 1;
                    }


                }


                days.Add(day);
            }


            return days;
        }

        //Returns room number that is available between two dates
        //returns -1 if no rooms are available
        public int getAvailibilityRoomNumber(DateTime start, DateTime end)
        {
            int roomNo = 0;
            bool available = true;
            end = end.AddDays(-1);
            int numDays = Convert.ToInt32(Math.Floor((end - start).TotalDays));
            //For each room number check every day if that room number is available
            for (int i = 0; i < 5; i++) {

                available = true;
            //Check every day 
            for (int j = 0; j <= numDays; j++)
            {
                    DateTime current = start.AddDays(j);
                    //Need to find position of current in occupancy collection to check 
                    int occupancyPos = convertToOccupancyPosition(current);
                    if (occupancy[occupancyPos].Rooms[i] == 1)
                    {
                        available = false;
                        break;
                        
                    }

                }


                if (available == true)
                {
                    return i;
                }


             }

            return -1;
            
        }

        public void makeBooking(DateTime start, DateTime end, int roomNo)
        {
            int numDays = Convert.ToInt32(Math.Floor((end - start).TotalDays));
            int startPos = convertToOccupancyPosition(start);
            for(int i = 0; i < numDays; i++)
            {
                try
                {
                    occupancy[startPos + i].Rooms[roomNo] = 1;
                }
                catch
                {

                }
            }


        }

        public void removeBooking(DateTime start, DateTime end, int roomNo)
        {
            int numDays = Convert.ToInt32(Math.Floor((end - start).TotalDays));
            int startPos = convertToOccupancyPosition(start);
            for (int i = 0; i < numDays; i++)
            {
                occupancy[startPos + i].Rooms[roomNo] = 0;
            }
        }

        private int convertToOccupancyPosition(DateTime requested)
        {
            int index = 0;
            for(int i = 0; i < occupancy.Count(); i++)
            {
                if (requested.DayOfYear == occupancy[i].DayOfYear.DayOfYear)
                {
                    index = i;
                }
            }
            return index; 
        }

        public Booking Find(int ID)
        {
            int index = 0;
            bool found = (bookings[index].BookingRef == ID);  //check if it is the first student
            int count = bookings.Count;
            while (!(found) && (index < bookings.Count - 1))  //if not "this" student and you are not at the end of the list 
            {
                index = index + 1;
                found = (bookings[index].BookingRef == ID);   // this will be TRUE if found
            }
            return bookings[index];  // this is the one!  
        }

        public int FindIndex(int ID)   // returns the index of the student to be changed
        {
            int index = 0;
            bool found = (bookings[index].BookingRef == ID);  //check if it is the first student
            int count = bookings.Count;
            while (!(found) && (index < bookings.Count - 1))  //if not "this" student and you are not at the end of the list 
            {
                index = index + 1;
                found = (bookings[index].BookingRef == ID);   // this will be TRUE if found
            }
            return index;  // this is the index of the student to be changed  
        }


        public void DatabaseAdd(Booking aBooking)
        {
            bookingDB.DatabaseAdd(aBooking);
        }


        public void Add(Booking aBooking)
        {
            DatabaseAdd(aBooking);
            bookings.Add(aBooking);
        }

        public void DatabaseDelete(Booking aBooking)
        {
            bookingDB.DatabaseDelete(aBooking);
        }

        public void Delete(Booking aBooking)
        {
            DatabaseDelete(aBooking);
            
            bookings.Remove(aBooking);
            
        }

        public void DatabaseEdit(Booking aBooking)
        {
            bookingDB.DatabaseEdit(aBooking);
        }

        public void Edit(Booking aBooking)
        {
            int count = FindIndex(aBooking.BookingRef);
            bookings[count].Room = aBooking.Room;
            bookings[count].Date = aBooking.Date;
            bookings[count].EndDate = aBooking.EndDate;
            bookings[count].Guest = aBooking.Guest;
            DatabaseEdit(aBooking);

        }


        public double occupancyAveragePercentage(DateTime start, DateTime end)
        {
            double sum = 0;
            
            
            int numDays = Convert.ToInt32(Math.Floor((end - start).TotalDays));
            //Loop through each day
            for (int i = 0; i < numDays; i++)
            {
                //convert to occupancy position
                DateTime current = start.AddDays(i);
                int occupancyPos = convertToOccupancyPosition(current);
                //Loop and get amount of rooms occupied on this day
                double countRooms = 0;
                for(int j = 0; j < 5; j++)
                {
                    if (occupancy[occupancyPos].Rooms[j] == 1)
                    {
                        countRooms++;
                    }
                }


                //Do average here
                sum += (countRooms / 5.0);
            }




            return (sum / Convert.ToDouble(numDays)) * 100;
        }


        public double averageRoomsPerDay(DateTime start, DateTime end)
        {
            double sum = 0;


            int numDays = Convert.ToInt32(Math.Floor((end - start).TotalDays));
            //Loop through each day
            for (int i = 0; i < numDays; i++)
            {
                //convert to occupancy position
                DateTime current = start.AddDays(i);
                int occupancyPos = convertToOccupancyPosition(current);
                //Loop and get amount of rooms occupied on this day
                double countRooms = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (occupancy[occupancyPos].Rooms[j] == 1)
                    {
                        countRooms++;
                    }
                }


                //Do average here
                sum += countRooms;
            }

           


            return (sum / Convert.ToDouble(numDays));
        }


        public string longestStayName(DateTime start, DateTime end)
        {
            string ans = "";
            int max = 0;
            foreach(Booking booking in bookings)
            {
                if ((booking.Date >= start && booking.Date <= end) ||
                    (booking.EndDate >= start && booking.EndDate <= end) ||
                    (booking.Date >= start && booking.EndDate <= end))
                {
                    int numDays = Convert.ToInt32(Math.Floor((booking.EndDate - booking.Date).TotalDays));
                    if (numDays > max)
                    {
                        ans = booking.Guest.FirstName + " " + booking.Guest.Surname;

                        longStayLength = numDays;
                        max = longStayLength;
                    }
                }

            }
            


            return ans;
        }

        public string shortestStayName(DateTime start, DateTime end)
        {
            string ans = "";
            int min = 1000;
            foreach (Booking booking in bookings)
            {
                if ((booking.Date >= start && booking.Date <= end) ||
                    (booking.EndDate >= start && booking.EndDate <= end) ||
                    (booking.Date >= start && booking.EndDate <= end))
                {
                    int numDays = Convert.ToInt32(Math.Floor((booking.EndDate - booking.Date).TotalDays));
                    if (numDays < min)
                    {
                        ans = booking.Guest.FirstName + " " + booking.Guest.Surname;
                        shortStayLength = numDays;
                        min = shortStayLength;
                    }
                }

            }

            

            return ans;
        }


        public double averageStayLength(DateTime start, DateTime end)
        {
            double sum = 0;
            double count = 0;

            foreach (Booking booking in bookings)
            {
                if ((booking.Date >= start && booking.Date <= end) ||
                    (booking.EndDate >= start && booking.EndDate <= end) ||
                    (booking.Date >= start && booking.EndDate <= end))
                {
                    int numDays = Convert.ToInt32(Math.Floor((booking.EndDate - booking.Date).TotalDays));
                    sum += numDays;
                    count += 1;
                }

            }




            if (count == 0)
            {
                return 0;
            }
            else
            {
                return sum / count;
            }
        }

    }
}
