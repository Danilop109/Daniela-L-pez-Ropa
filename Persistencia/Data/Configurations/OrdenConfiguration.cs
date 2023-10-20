using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
             builder.ToTable("Orden");

            builder.Property(p => p.Id)
            .IsRequired();
        
            builder.Property(n => n.Fecha)
            .HasColumnType("Date")
            .IsRequired();
            
             builder.HasOne(t => t.Empleado)
            .WithMany(t => t.Ordenes)
            .HasForeignKey(t => t.IdEmpleadoFk);

             builder.HasOne(t => t.Cliente)
            .WithMany(t => t.Ordenes)
            .HasForeignKey(t => t.IdClienteFk);

             builder.HasOne(t => t.Estado)
            .WithMany(t => t.Ordenes)
            .HasForeignKey(t => t.IdEstadoFk);
        }
    }
}