using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("Inventario");

            builder.Property(p => p.Id)
            .IsRequired();
        
            builder.Property(n => n.CodInventario)
            .HasColumnType("int")
            .IsRequired();

            builder.Property(n => n.ValorVtaCop)
            .HasColumnType("double")
            .IsRequired();

            builder.Property(n => n.ValorVtaUsd)
            .HasColumnType("double")
            .IsRequired();
            
             builder.HasOne(t => t.Prenda)
            .WithMany(t => t.Inventarios)
            .HasForeignKey(t => t.IdPrendaFk);

        }
    }
}