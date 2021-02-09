using EventsPlus_LTD.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventsPlusLTD.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Organizer>().ToTable("Organizer");
            modelBuilder.Entity<Attendee>().ToTable("Attendee");
            modelBuilder.Entity<Event>().ToTable("Event");
            //modelBuilder.Entity<Event>().ToTable("Booking");
            //modelBuilder.Entity<Event>().ToTable("Venue");

            //modelBuilder.Entity<Organizer>().HasMany(b=> b.Events).WithOne().OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Attendee>().HasMany(b => b.Bookings).WithOne().OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Event>().HasMany(b => b.Bookings).WithOne().OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Event>().HasMany(b => b.Venues).WithOne().OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
