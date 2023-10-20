using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class ColorDetalleConfiguration : IEntityTypeConfiguration<ColorDetalle>
    {
        public void Configure(EntityTypeBuilder<ColorDetalle> builder)
        {
             builder.ToTable("ColorDetalle");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(n => n.Descripcion)
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(300);
        }
    }
}