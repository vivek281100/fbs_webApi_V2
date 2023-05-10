using Microsoft.EntityFrameworkCore;
using fbs_webApi_v2.DataModels;

namespace fbs_webApi_v2.Data
{
    public class fbscontext : DbContext
    {

        public fbscontext(DbContextOptions<fbscontext> options) : base(options)
        {

            
        }

        public DbSet<Admin> Admins { get; set; }

        //booking functionality pending
        //public DbSet<Booking> bookings { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Passenger> passengers { get; set; }

        public DbSet<Payment> payments { get; set; }

        public DbSet<SeatAllocated> seatAllocateds { get; set; }

        public DbSet<SeatsAvailable> seatsAvailables { get; set; }

        public DbSet<User> users { get; set; }

       
             
    }
}
