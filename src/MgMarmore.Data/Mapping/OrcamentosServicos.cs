using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Data.Mapping
{
    public class OrcamentosServicos : IEntityTypeConfiguration<OrcamentoServico>
    {
        public void Configure(EntityTypeBuilder<OrcamentoServico> builder)
        {
            builder.HasKey(os => new { os.OrcamentoId, os.ServicoId});

            builder.HasOne(os => os.Orcamento)
                .WithMany(os => os.OrcamentosServicos)
                .HasForeignKey(os => os.OrcamentoId);

            builder.HasOne(os => os.Servico)
                .WithMany(os => os.OrcamentosServicos)
                .HasForeignKey(os => os.ServicoId);

            builder.ToTable("OrcamentosServicos");
        }
    }
}
