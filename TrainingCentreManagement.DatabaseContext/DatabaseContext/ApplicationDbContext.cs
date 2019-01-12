using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TrainingCentreManagement.Models.EntityModels;
using TrainingCentreManagement.Models.EntityModels.Batches;
using TrainingCentreManagement.Models.EntityModels.Categories;
using TrainingCentreManagement.Models.EntityModels.Courses;
using TrainingCentreManagement.Models.EntityModels.IdentityEntities;
using TrainingCentreManagement.Models.EntityModels.Institues;
using TrainingCentreManagement.Models.EntityModels.Tags;
using TrainingCentreManagement.Models.EntityModels.Trainees;
using TrainingCentreManagement.Models.EntityModels.Trainers;
using TrainingCentreManagement.Models.EntityModels.Trainings;

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

                optionsBuilder .UseSqlServer("Server=PENCILBOX;Database=TrainingCenterDB;Trusted_Connection=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
       
            modelBuilder.Entity<TrainingCategory>().HasKey(c => c.TrainingId);
            modelBuilder.Entity<TrainingCategory>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<TrainingTag>().HasKey(c => c.TrainingId);
            modelBuilder.Entity<TrainingTag>().HasKey(c => c.TagId);
            modelBuilder.Entity<Training>().HasOne(c => c.TrainingSchedule)
                .WithOne(c => c.Training)
                .HasForeignKey<Training>(c=>c.TrainingScheduleId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Batch>().HasOne(c => c.BatchSchedule)
                .WithOne(c => c.Batch)
                .HasForeignKey<Batch>(c => c.BatchScheduleId)
                .OnDelete(DeleteBehavior.SetNull);


        }

        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Category> Categories { get; set; }
          
    }
}
