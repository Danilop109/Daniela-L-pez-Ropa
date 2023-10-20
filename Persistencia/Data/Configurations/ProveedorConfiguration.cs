using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedor");

            builder.Property(p => p.Id)
            .IsRequired();
            
            builder.Property(n => n.NitProveedor)
            .HasColumnType("int")
            // .IsUnicode(true)
            .IsRequired();

            builder.Property(n => n.Nombre)
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);

            builder.HasOne(t => t.TipoPersona)
            .WithMany(t => t.Proveedores)
            .HasForeignKey(t => t.IdTipoPersonaFk);

            builder.HasOne(t => t.Municipio)
            .WithMany(t => t.Proveedores)
            .HasForeignKey(t => t.IdMunicipioFk);
        }
    }
}