﻿using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User { Id = 1, Email="admin@phtv.com",Password="123",Role="Admin"},
                new User { Id = 2, Email="emp@phtv.com",Password="123",Role="Emp"},
                new User { Id = 3, Email="user@phtv.com",Password="123",Role="User"}
            });
            modelBuilder.Entity<Station>(p =>
            {
                p.HasKey(p => p.Id);
                p.HasData(SeedData.StationData.StationSeedData());
            });
            modelBuilder.Entity<Ticket>(p =>
            {
                p.HasKey(p => p.Id);
            });
            modelBuilder.Entity<Bus>(b =>
            {
                b.HasKey(b => b.Id);
                b.HasIndex(u => u.BusPlate).IsUnique();
            });
            modelBuilder.Entity<Bus>()
                .HasMany(e => e.Stations)
                .WithMany(e => e.Buses)
                .UsingEntity("BusToStationJoinTable");

            modelBuilder.Entity<Seat>(t =>
            {
                t.HasKey(t => t.Id);
                //t.HasData(SeedData.SeatData.seatSeedData());
            });
            modelBuilder.Entity<Trip>(b =>
            {
                b.HasKey(b => b.Id);
                //b.HasData(SeedData.TripData.TripSeedData());
            });
            modelBuilder.Entity<Driver>(b =>
            {
                b.HasKey(b => b.Id);
            });
        }
    }
}
