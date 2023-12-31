using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado");

            builder.Property(p => p.Id)
            .IsRequired();
            
            builder.Property(n => n.IdEmpleado)
            .HasColumnType("int")
            // .IsUnicode(true)
            .IsRequired();

            builder.Property(n => n.Nombre)
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(n => n.FechaIngreso)
            .HasColumnType("Date")
            .IsRequired();

            builder.HasOne(t => t.Cargo)
            .WithMany(t => t.Empleados)
            .HasForeignKey(t => t.IdCargoFk);

            builder.HasOne(t => t.Municipio)
            .WithMany(t => t.Empleados)
            .HasForeignKey(t => t.IdMunicipioFk);
        }
    }
}