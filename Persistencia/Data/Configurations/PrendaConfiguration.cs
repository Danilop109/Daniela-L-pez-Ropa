using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
    {
        public void Configure(EntityTypeBuilder<Prenda> builder)
        {
             builder.ToTable("Prenda");

            builder.Property(p => p.Id)
            .IsRequired();
        
            builder.Property(n => n.IdPrenda)
            .HasColumnType("int")
            .IsRequired();

            builder.Property(n => n.Nombre)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(n => n.ValorUnitCop)
            .HasColumnType("double")
            .IsRequired();

            builder.Property(n => n.ValorUnitUsd)
            .HasColumnType("double")
            .IsRequired();
            
             builder.HasOne(t => t.Estado)
            .WithMany(t => t.Prendas)
            .HasForeignKey(t => t.IdEstadoFk);

             builder.HasOne(t => t.TipoProteccion)
            .WithMany(t => t.Prendas)
            .HasForeignKey(t => t.IdTipoProteccionFk);

             builder.HasOne(t => t.Genero)
            .WithMany(t => t.Prendas)
            .HasForeignKey(t => t.IdGeneroFk);
        }
    }
}