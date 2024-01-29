using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Materials_Info.DbModels;

public partial class MaterialDbContext : DbContext
{
    public MaterialDbContext()
    {
    }

    public MaterialDbContext(DbContextOptions<MaterialDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RawMaterial> RawMaterials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-MPQVSOQ;Database=MaterialDB;Trusted_Connection=True;TrustServerCertificate=yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RawMaterial>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK__RawMater__C50610F752AED60F");

            entity.ToTable("RawMaterial");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.MaterialName).HasMaxLength(50);
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Unit).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
