namespace Hotel_Management_System.Models
{
    using Microsoft.EntityFrameworkCore;

    namespace Hotel.Models
    {
        public class HotelDBContext : DbContext
        {
            public HotelDBContext(DbContextOptions<HotelDBContext> options)
                : base(options)
            { }

            public DbSet<Booking> Bookings { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Guest> Guests { get; set; }
            public DbSet<Payment> Payments { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<Room> Rooms { get; set; }
        }
    }

}
