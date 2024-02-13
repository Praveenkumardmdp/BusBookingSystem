using Microsoft.EntityFrameworkCore;
using BusBookingApp.bus;

namespace BusBookingApp.Connections
{
    public class Context : DbContext
    {
        public DbSet<Login>? logins { get; set; }
        public DbSet<BusDetail>? busDetails { get; set; }
        public DbSet<Ratting>? busRatting { get; set; }
        public DbSet<BusName>? busNames { get; set; }
        public DbSet<User>? user { get; set; }
        
        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}

