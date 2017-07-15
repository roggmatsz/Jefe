using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JefeAPI.Models
{
    public class Tally {
        public int id { get; set; }
        public int DayID { get; set; }
        public int TicketID { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Count => Start + End;
        public int Sales { get; set; }

        static int computeSales(int value, int count) {
            return value * count;
        }
    }
}
