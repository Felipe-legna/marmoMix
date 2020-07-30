using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Data.Mapping
{
    public class ServicosItensMapping : IEntityTypeConfiguration<ServicosItens>
    {
        public void Configure(EntityTypeBuilder<ServicosItens> builder)
        {
            builder.HasKey(si => new { si.ServicoId, si.ItemId });

            builder.HasOne(si => si.Servico)
                .WithMany(si => si.ServicosItens)
                .HasForeignKey(si => si.ServicoId);

            builder.HasOne(si => si.Item)
                .WithMany(si => si.ServicosItens)
                .HasForeignKey(si => si.ItemId);

            builder.ToTable("ServicosItens");
        }
    }
}
