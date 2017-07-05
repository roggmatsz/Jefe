using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using JefeAPI.Models;

namespace JefeAPI.Models
{
    public class ApiContext : DbContext {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) 
        {}
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Tally> Tallies { get; set; }
    }
}
