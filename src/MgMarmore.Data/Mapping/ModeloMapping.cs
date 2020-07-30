using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Data.Mapping
{
    public class ModeloMapping : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Metodo)
                .IsRequired()
               .HasColumnType("VARCHAR(100)");

            builder.Property(b => b.Categoria)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.Property(b => b.Imagem)
              .HasColumnType("VARCHAR(200)");

            builder.Property(b => b.QuantidadePecas)
              .IsRequired()
              .HasColumnType("INT");
            
            builder.ToTable("Modelos");
        }
    }
}
