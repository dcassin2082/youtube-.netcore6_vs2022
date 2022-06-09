using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication16.Models
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext()
        {
        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<CompanyJson> CompanyJsons { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<GetStatesThatStartWithM> GetStatesThatStartWithMs { get; set; } = null!;
        public virtual DbSet<Name> Names { get; set; } = null!;
        public virtual DbSet<NameCompanyAddress> NameCompanyAddresses { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentsCours> StudentsCourses { get; set; } = null!;
        public virtual DbSet<TempTable> TempTables { get; set; } = null!;
        public virtual DbSet<Test2> Test2 { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile("appsettings.json", optional: false);
                var config = builder.Build();
                string connectionString = config.GetConnectionString("TestConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.StreetAddress).HasMaxLength(50);
            });

            modelBuilder.Entity<CompanyJson>(entity =>
            {
                entity.ToTable("CompanyJson");

                entity.Property(e => e.CompanyJsonId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Zip).HasMaxLength(50);
            });

            modelBuilder.Entity<GetStatesThatStartWithM>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("get_states_that_start_with_M");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Name>(entity =>
            {
                entity.ToTable("Name");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<NameCompanyAddress>(entity =>
            {
                entity.ToTable("NameCompanyAddress");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State");

                entity.Property(e => e.Abbreviation).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<StudentsCours>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });
            });

            modelBuilder.Entity<TempTable>(entity =>
            {
                entity.ToTable("TempTable");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.StreetAddress).HasMaxLength(50);
            });

            modelBuilder.Entity<Test2>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasColumnName("updated");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
