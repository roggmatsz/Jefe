using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JefeAPI.Models
{
    public class Day {
        public int id;
        public DateTime Date { get; set; }
        public List<Tally> Tallies { get; set; }
        public int TicketsSold { get; set; }
        public int Sales { get; set; }
    }
}
