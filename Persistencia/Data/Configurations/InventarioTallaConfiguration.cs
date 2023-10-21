using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class InventarioTallaConfiguration : IEntityTypeConfiguration<InventarioTalla>
    {
        public void Configure(EntityTypeBuilder<InventarioTalla> builder)
        {
             builder.ToTable("InventarioTalla");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(n => n.Cantidad)
            .HasColumnType("int")
            .IsRequired();
            
             builder.HasOne(t => t.Inventario)
            .WithMany(t => t.InventarioTallas)
            .HasForeignKey(t => t.IdInventarioFk);

             builder.HasOne(t => t.Talla)
            .WithMany(t => t.InventarioTallas)
            .HasForeignKey(t => t.IdTallaFk);
        }
    }
}