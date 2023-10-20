using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class MunicipioConfiguration : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
             builder.ToTable("Municipio");

            builder.Property(p => p.Id)
            .IsRequired();
        
            builder.Property(n => n.Nombre)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();
            
             builder.HasOne(t => t.Departamento)
            .WithMany(t => t.Municipios)
            .HasForeignKey(t => t.IdDepartamentoFk);

        }
    }
}