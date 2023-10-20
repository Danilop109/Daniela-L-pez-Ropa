using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");

            builder.Property(p => p.Id)
            .IsRequired();
            
            builder.Property(n => n.Nit)
            .HasColumnType("int")
            // .IsUnicode(true)
            .IsRequired();

            builder.Property(n => n.RazonSocial)
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(300);

            builder.Property(n => n.RepresentanteLegal)
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(300);

            builder.Property(n => n.FechaCreacion)
            .HasColumnType("Date")
            .IsRequired();

            builder.HasOne(t => t.Municipio)
            .WithMany(t => t.Empresas)
            .HasForeignKey(t => t.IdMunicipioFk);
        }
    }
}