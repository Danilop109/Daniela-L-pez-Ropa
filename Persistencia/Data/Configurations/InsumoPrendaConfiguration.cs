using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class InsumoPrendaConfiguration : IEntityTypeConfiguration<InsumoPrenda>
    {
        public void Configure(EntityTypeBuilder<InsumoPrenda> builder)
        {
             builder.ToTable("InsumoPrenda");

            builder.Property(p => p.Id)
            .IsRequired();
        
            builder.Property(n => n.Cantidad)
            .HasColumnType("int")
            .IsRequired();
            
             builder.HasOne(t => t.Insumo)
            .WithMany(t => t.InsumoPrendas)
            .HasForeignKey(t => t.IdInsumoFk);

             builder.HasOne(t => t.Prenda)
            .WithMany(t => t.InsumoPrendas)
            .HasForeignKey(t => t.IdPrendaFk);
        }
    }
}