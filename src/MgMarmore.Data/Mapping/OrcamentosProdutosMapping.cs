using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Data.Mapping
{
    public class OrcamentosProdutosMapping
    {
        public void Configure(EntityTypeBuilder<OrcamentoProduto> builder)
        {
            builder.HasKey(op => op.Id);

            builder.Property(s => s.Quantidade)
              .IsRequired().HasDefaultValue(1)
              .HasColumnType("decimal(10,2)");

            builder.Property(s => s.Valor)
               .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(s => s.Desconto)
              .IsRequired()
              .HasColumnType("decimal(10,2)");

            builder.ToTable("OrcamentosProdutos");
        }
    }
}
