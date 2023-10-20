using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class InsumoProveedorConfiguration : IEntityTypeConfiguration<InsumoProveedor>
    {
        public void Configure(EntityTypeBuilder<InsumoProveedor> builder)
        {
            builder.ToTable("InsumoProveedor");

            builder.Property(p => p.Id)
            .IsRequired();
        
            
             builder.HasOne(t => t.Insumo)
            .WithMany(t => t.InsumoProveedores)
            .HasForeignKey(t => t.IdInsumoFk);

             builder.HasOne(t => t.Proveedor)
            .WithMany(t => t.InsumoProveedores)
            .HasForeignKey(t => t.IdProveedorFk);
        }
    }
}