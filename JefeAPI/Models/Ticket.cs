using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace JefeAPI.Models
{
    public class Ticket {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int GameID { get; set; }
        [Required]
        public int Slot { get; set; }
        [Required]
        public int Value { get; set; }
    }
}
