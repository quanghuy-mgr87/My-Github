using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DemoApiDBFirst.Model
{
    public partial class QLHocSinhDBFirstContext : DbContext
    {
        public QLHocSinhDBFirstContext()
        {
        }

        public QLHocSinhDBFirstContext(DbContextOptions<QLHocSinhDBFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HocSinh> HocSinhs { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=QLHocSinhDBFirst;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<HocSinh>(entity =>
            {
                entity.ToTable("HocSinh");

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HoTen).HasMaxLength(30);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.HasOne(d => d.Lop)
                    .WithMany(p => p.HocSinhs)
                    .HasForeignKey(d => d.LopId)
                    .HasConstraintName("FK_HocSinh_Lop");
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.ToTable("Lop");

                entity.Property(e => e.TenLop).HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
