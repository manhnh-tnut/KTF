using KTF.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace KTF.Shared.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<StaplerReport> StaplerReports { get; set; }
        public virtual DbSet<StaplerHistory> StaplerHistories { get; set; }
        public virtual DbSet<ScaleReport> ScaleReports { get; set; }
        public virtual DbSet<ScaleHistory> ScaleHistories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=ktf.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaplerHistory>(entity =>
            {
                entity.ToTable("StaplerHistory");

                entity.HasKey(x => x.Id);
                entity.Property(e => e.Line)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrentCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Created)
                    .IsRequired();

                entity.HasIndex(e => e.Created);
            });

            modelBuilder.Entity<StaplerReport>(entity =>
            {
                entity.ToTable("StaplerReport");

                entity.HasKey(x => x.Id);
                entity.Property(e => e.Line)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Created)
                    .IsRequired();

                entity.HasIndex(e => e.Created);
            });

            modelBuilder.Entity<ScaleHistory>(entity =>
            {
                entity.ToTable("ScaleHistory");

                entity.HasKey(x => x.Id);
                entity.Property(e => e.Line)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Created)
                    .IsRequired();

                entity.HasIndex(e => e.Created);
            });

            modelBuilder.Entity<ScaleReport>(entity =>
            {
                entity.ToTable("ScaleReport");

                entity.HasKey(x => x.Id);
                entity.Property(e => e.Line)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Created)
                    .IsRequired();

                entity.HasIndex(e => e.Created);
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.ToTable("Machine");

                entity.HasKey(x => x.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Created)
                    .IsRequired();

                entity.HasIndex(e => e.Created);
            });

            modelBuilder.Entity<Line>(entity =>
            {
                entity.ToTable("Line");

                entity.HasKey(x => x.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Created)
                    .IsRequired();

                entity.HasIndex(e => e.Created);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
