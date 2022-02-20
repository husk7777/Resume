using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DatabaseAccess.Models;

namespace DatabaseAccess.Context
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ResumeDB.db");
        } 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<EndUser>().ToTable("EndUser");
            //modelBuilder.Entity<EndUser>().HasOne(e=>e.EndUserDetails).WithOne(e=>e.EndUser).HasPrincipalKey<EndUser>(eu=>eu.Id);
            modelBuilder.Entity<ErrorLog>().ToTable("ErrorLog");
            modelBuilder.Entity<Position>().ToTable("Position");
            modelBuilder.Entity<PositionType>().ToTable("PositionType");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Responsibility>().ToTable("Responsibility");
            modelBuilder.Entity<UserType>().ToTable("UserType");
            modelBuilder.Entity<Candidate>().ToTable("Candidate");
            modelBuilder.Entity<Skill>().ToTable("Skill");
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<EndUser> EndUser { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<PositionType> PositionType { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Responsibility> Responsibility { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }
    }
}
