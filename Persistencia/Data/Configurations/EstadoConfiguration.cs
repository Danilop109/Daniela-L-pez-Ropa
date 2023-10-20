using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("Estado");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(n => n.Descripcion)
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(300);

            builder.HasOne(t => t.TipoEstado)
            .WithMany(t => t.Estados)
            .HasForeignKey(t => t.IdTipoEstadoFk);
        }
    }
}