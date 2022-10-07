using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CustomerManagementSystem.Models
{
    public partial class custmanagementContext : DbContext
    {
        public custmanagementContext()
        {
        }

        public custmanagementContext(DbContextOptions<custmanagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Dependancy> Dependancy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=10.3.117.39;Database=custmanagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Custid);

                entity.ToTable("customer");

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dependancy>(entity =>
            {
                entity.HasKey(e => e.Deptid);

                entity.ToTable("dependancy");

                entity.Property(e => e.Deptid).HasColumnName("deptid");

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.Depententname)
                    .HasColumnName("depententname")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Feature)
                    .HasColumnName("feature")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Dependancy)
                    .HasForeignKey(d => d.Custid)
                    .HasConstraintName("FK__dependanc__custi__25869641");
            });
        }
    }
}
