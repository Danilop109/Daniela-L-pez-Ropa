using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
             builder.ToTable("Cargo");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(n => n.Descripcion)
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(300);

            builder.Property(n => n.SueldoBase)
            .HasColumnType("double")
            .IsRequired();
        }
    }
}