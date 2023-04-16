using KostRentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KostRentApp.Data
{
    public class MySqlContext : DbContext 
    {
        public MySqlContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; } 
        public DbSet<DataKost> DataKosts { get; set; }
        public DbSet<DataBooking> DataBookings { get; set; }
    }
}
