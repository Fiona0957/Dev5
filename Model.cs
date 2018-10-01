using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace Model
{
    public class JobContext : DbContext
    {
        //this is actual entity object linked to the movies in our DB
        public DbSet<Company> Company { get; set; }
        //this is actual entity object linked to the actors in our DB
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<Perform> Perform { get; set; }

        //this method is run automatically by EF the first time we run the application
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //here we define the name of our database
            optionsBuilder.UseNpgsql("User ID=postgres;Password=;Host=localhost;Port=5432;Database=JobDB;Pooling=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perform>()
              .HasKey(t => new { t.TaskNumber, t.StaffSSN });
            modelBuilder.Entity<Perform>()
              .HasOne(p => p.Staff)
              .WithMany(ta => ta.Tasks)
              .HasForeignKey(p => p.StaffSSN);
            modelBuilder.Entity<Perform>()
              .HasOne(p => p.Task)
              .WithMany(ta => ta.Staffs)
              .HasForeignKey(p => p.TaskNumber);
            modelBuilder.Entity<Staff>()
                .HasKey(a => new { a.SSN });
            modelBuilder.Entity<Company>()
            .HasKey(a => new { a.Name });
            modelBuilder.Entity<Task>()
                .HasKey(a => new { a.Number });
        }

    }

    //this is the typed representation of a movie in our project
    public class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Staff> Staffs { get; set; }
    }

    //this is the typed representation of an actor in our project
    public class Staff
    {
        public int SSN { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public int Phone { get; set; }
        public string CompanyName { get; set; }
        public virtual List<Perform> Tasks { get; set; }
    }

    public class Task
    {
        public int Number { get; set; }
        public string Description { get; set; }
        public virtual List<Perform> Staffs { get; set; }
    }
    public class Perform
    {
        public int TaskNumber { get; set; }
        public Task Task { get; set; }
        public int StaffSSN { get; set; }
        public Staff Staff { get; set; }
    }
}