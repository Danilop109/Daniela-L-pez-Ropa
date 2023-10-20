using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
             builder.ToTable("Genero");

            builder.Property(p => p.Id)
            .IsRequired();
        
            builder.Property(n => n.Descripcion)
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(300);
        }
    }
}