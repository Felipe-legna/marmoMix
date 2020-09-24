using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Data.Mapping
{
    public class OrcamentosRevendasMapping : IEntityTypeConfiguration<OrcamentoRevenda>
    {
        public void Configure(EntityTypeBuilder<OrcamentoRevenda> builder)
        {
            builder.HasKey(os => new { os.OrcamentoId, os.RevendaId});

            builder.HasOne(os => os.Orcamento)
                .WithMany(os => os.OrcamentosRevendas)
                .HasForeignKey(os => os.OrcamentoId);

            builder.HasOne(os => os.Revenda)
                .WithMany(os => os.OrcamentosRevendas)
                .HasForeignKey(os => os.RevendaId);

            builder.ToTable("OrcamentosRevendas");
        }
    }
}
