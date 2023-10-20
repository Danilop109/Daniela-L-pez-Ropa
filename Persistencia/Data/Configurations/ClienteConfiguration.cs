using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.Property(p => p.Id)
            .IsRequired();
            
            builder.Property(n => n.IdCliente)
            .HasColumnType("int")
            // .IsUnicode(true)
            .IsRequired();

            builder.Property(n => n.Nombre)
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(n => n.FechaRegistro)
            .HasColumnType("Date")
            .IsRequired();

            builder.HasOne(t => t.TipoPersona)
            .WithMany(t => t.Clientes)
            .HasForeignKey(t => t.IdTipoPersonaFk);

            builder.HasOne(t => t.Municipio)
            .WithMany(t => t.Clientes)
            .HasForeignKey(t => t.IdMunicipioFk);

        }
    }
}