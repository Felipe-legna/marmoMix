using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Data.Mapping
{
    public class BancadaMapping : IEntityTypeConfiguration<Bancada>
    {
        public void Configure(EntityTypeBuilder<Bancada> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Frontao)
               .IsRequired()
               .HasColumnType("DECIMAL(10,3)");

            builder.Property(b => b.Saia)
               .IsRequired()
               .HasColumnType("DECIMAL(10,3)");

            //builder.Property(b => b.Descricao)
            //     .IsRequired()
            //    .HasColumnType("VARCHAR(200)");

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

            builder.Property(b => b.MetroQuadrado)
              .IsRequired()
              .HasColumnType("DECIMAL(10,3)");

            //builder.HasMany(b => b.PecasBancada)
            //    .WithOne(p => (Bancada)p.);
              
                
            
            builder.ToTable("Bancadas");
        }
    }
}
