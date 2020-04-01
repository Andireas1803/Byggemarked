using HomeDepotWebApp.Models;
using System.Data.Entity;

namespace HomeDepotWebApp.Storage
{
    public class HomeDepotContext : DbContext
    {
        public HomeDepotContext() : base("HomeDepotDb")
        {

        }

        public DbSet<Tool> Tools { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}