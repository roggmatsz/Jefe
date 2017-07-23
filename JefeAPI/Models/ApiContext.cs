using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using JefeAPI.Entities;

namespace JefeAPI.Models
{
    public class ApiContext : DbContext {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) 
        {}
        public DbSet<TicketEntity> Tickets { get; set; }
        //public DbSet<Day> Days { get; set; }
        //public DbSet<Tally> Tallies { get; set; }
    }
}
