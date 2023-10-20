using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetalleVenta");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(n => n.Cantidad)
            .HasColumnType("int")
            .IsRequired();

            builder.Property(n => n.ValorUnit)
            .HasColumnType("double")
            .IsRequired();

            builder.HasOne(t => t.Venta)
            .WithMany(t => t.DetalleVentas)
            .HasForeignKey(t => t.IdVentaFk);

            builder.HasOne(t => t.Producto)
            .WithMany(t => t.DetalleVentas)
            .HasForeignKey(t => t.IdProductoFk);

            builder.HasOne(t => t.Talla)
            .WithMany(t => t.DetalleVentas)
            .HasForeignKey(t => t.IdTallaFk);
            
        }
    }
}