using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
             builder.ToTable("Departamento");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(n => n.Nombre)
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);

            builder.HasOne(t => t.Pais)
            .WithMany(t => t.Departamentos)
            .HasForeignKey(t => t.IdPaisFk);

        }
    }
}