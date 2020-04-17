using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasy_System.Entities
{
   public class Day
    {
        //0 represents available
        //1 represents taken


        private DateTime dayOfYear;
        private int[] rooms;

        public Day(DateTime dayOfYear, int[] rooms)
        {
            this.dayOfYear = dayOfYear;
            this.Rooms = rooms;
        }
        public Day()
        {
            Rooms = new int[5];
            for(int i = 0; i < Rooms.Length; i++)
            {
                Rooms[i] = 0;
            }

        }



        public DateTime DayOfYear { get => dayOfYear; set => dayOfYear = value; }
        public int[] Rooms { get => rooms; set => rooms = value; }
    }
}
