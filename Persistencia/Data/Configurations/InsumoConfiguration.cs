using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
    {
        public void Configure(EntityTypeBuilder<Insumo> builder)
        {
             builder.ToTable("Insumo");

            builder.Property(p => p.Id)
            .IsRequired();
        
            builder.Property(n => n.Nombre)
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);
            
            builder.Property(n => n.ValorUnit)
            .HasColumnType("double")
            .IsRequired();

            builder.Property(n => n.StockMin)
            .HasColumnType("int")
            .IsRequired();

            builder.Property(n => n.StockMax)
            .HasColumnType("int")
            .IsRequired();
        
        }
    }
}