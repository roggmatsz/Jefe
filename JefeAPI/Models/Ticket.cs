using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JefeAPI.Models
{
    public class Ticket {
        public int id { get; set; }
        public int GameID { get; set; }
        public int Slot { get; set; }
        public int Value { get; set; }
        
        public Ticket() {}
    }
}
