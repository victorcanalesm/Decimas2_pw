using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_Consultas.Models;

public partial class EjemploContext : DbContext
{
    public EjemploContext()
    {
    }

    public EjemploContext(DbContextOptions<EjemploContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EJEMPLO;Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodProducto);

            entity.ToTable("PRODUCTOS");

            entity.Property(e => e.CodProducto)
                .ValueGeneratedNever()
                .HasColumnName("codProducto");
            entity.Property(e => e.NomProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nomProducto");
            entity.Property(e => e.PrecioProducto).HasColumnName("precioProducto");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta);

            entity.ToTable("VENTA");

            entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.CodProducto).HasColumnName("codProducto");

            entity.HasOne(d => d.CodProductoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CodProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VENTA_PRODUCTOS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
