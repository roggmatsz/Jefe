using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JefeAPI.Models
{
    public class Ticket {       
        public int GameID { get; set; }
        public int Slot { get; set; }
        public int Value { get; set; }
    }
}
