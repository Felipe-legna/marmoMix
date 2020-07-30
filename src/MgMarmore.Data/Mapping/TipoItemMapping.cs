using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Data.Mapping
{
    public class TipoItemMapping : IEntityTypeConfiguration<TipoItem>
    {
        public void Configure(EntityTypeBuilder<TipoItem> builder)
        {
            builder.Property(m => m.Descricao)
                .HasColumnType("VARCHAR(200)");

            builder.Property(m => m.Imagem)
                    .HasColumnType("VARCHAR(200)");

            builder.ToTable("TiposItens");

            builder.HasMany(ti => ti.Bancadas)
                .WithOne(ba => ba.TipoItem);
        }
    }
}
