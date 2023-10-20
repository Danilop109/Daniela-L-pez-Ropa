using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class TipoProteccionConfiguration : IEntityTypeConfiguration<TipoProteccion>
    {
        public void Configure(EntityTypeBuilder<TipoProteccion> builder)
        {
            builder.ToTable("TipoProteccion");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(n => n.Descripcion)
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(300);
        }
    }
}