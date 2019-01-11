using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TrainingCentreManagement.Models.EntityModels;

namespace TrainingCentreManagement.DatabaseContext.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder .UseSqlServer("Server=MAMUN-LAPTOP-XI;Database=TrainingCenterDB;Trusted_Connection=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
       
            modelBuilder.Entity<CourseCategory>().HasKey(c => c.CourseId);
            modelBuilder.Entity<CourseCategory>().HasKey(c => c.CategoryId);


        }

        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Category> Categories { get; set; }
          
    }
}
