using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
    {
        public void Configure(EntityTypeBuilder<DetalleOrden> builder)
        {
            builder.ToTable("DetalleOrden");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(n => n.CantidadProducir)
            .HasColumnType("int")
            .IsRequired();

            builder.Property(n => n.CantidadProducida)
            .HasColumnType("int")
            .IsRequired();

            builder.HasOne(t => t.Orden)
            .WithMany(t => t.DetalleOrdenes)
            .HasForeignKey(t => t.IdOrdenFk);

            builder.HasOne(t => t.Prenda)
            .WithMany(t => t.DetalleOrdenes)
            .HasForeignKey(t => t.IdPrendaFk);

            builder.HasOne(t => t.ColorDetalle)
            .WithMany(t => t.DetalleOrdenes)
            .HasForeignKey(t => t.IdColorDetalleFk);

            builder.HasOne(t => t.Estado)
            .WithMany(t => t.DetalleOrdenes)
            .HasForeignKey(t => t.IdEstadoFk);
        }
    }
}