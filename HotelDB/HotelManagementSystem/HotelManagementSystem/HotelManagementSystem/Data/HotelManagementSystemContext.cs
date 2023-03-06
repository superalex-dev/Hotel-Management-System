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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany()
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Guest)
                .WithMany()
                .HasForeignKey(r => r.GuestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.RoomType)
                .WithMany()
                .HasForeignKey(r => r.RoomTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Room>()
                .HasIndex(r => r.RoomNumber)
                .IsUnique();

            // define the room types
            var roomTypes = new List<RoomType>
            {
                new RoomType
                {
                    RoomTypeId = 1,
                    Name = "Single",
                    Description = "Single room",
                },
                new RoomType
                {
                    RoomTypeId = 2,
                    Name = "Double",
                    Description = "Double room",
                },
                new RoomType
                {
                    RoomTypeId = 3,
                    Name = "Suite",
                    Description = "Suite room",
                }
            };

            // add room types to model and set default rate to 0
            modelBuilder.Entity<RoomType>()
                .HasData(roomTypes.Select(rt => new
                {
                    rt.RoomTypeId,
                    rt.Name,
                    rt.Description,
                }));
        }
    }
}