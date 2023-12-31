using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
             builder.ToTable("Pais");

            builder.Property(p => p.Id)
            .IsRequired();
        
            builder.Property(n => n.Nombre)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();
        }
    }
}