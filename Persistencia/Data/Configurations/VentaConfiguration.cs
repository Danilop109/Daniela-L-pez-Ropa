using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("Venta");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(n => n.Fecha)
            .HasColumnType("Date")
            .IsRequired();

             builder.HasOne(t => t.Empleado)
            .WithMany(t => t.Ventas)
            .HasForeignKey(t => t.IdEmpleadoFk);

             builder.HasOne(t => t.Cliente)
            .WithMany(t => t.Ventas)
            .HasForeignKey(t => t.IdClienteFk);

            builder.HasOne(t => t.FormaPago)
            .WithMany(t => t.Ventas)
            .HasForeignKey(t => t.IdFormaPagoFk);

        }
    }
}