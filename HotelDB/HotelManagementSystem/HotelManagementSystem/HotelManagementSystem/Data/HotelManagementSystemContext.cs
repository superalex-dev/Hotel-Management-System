using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelManagementSystem.Data
{
    public class HotelManagementSystemContext : DbContext
    {
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=HotelManagementSystem;Trusted_Connection=True;");
        }
    }
}