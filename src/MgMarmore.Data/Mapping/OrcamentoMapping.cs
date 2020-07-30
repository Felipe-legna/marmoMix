using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MgMarmore.Data.Mapping
{
    public class OrcamentoMapping : IEntityTypeConfiguration<Orcamento>
    {
        public void Configure(EntityTypeBuilder<Orcamento> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Observacoes)
                .HasColumnType("VARCHAR(300)");

            builder.Property(o => o.ValorTotal)
                .IsRequired()
                .HasColumnType("DECIMAL(10,3)");

            builder.HasOne(o => o.Cliente)
                .WithMany(o => o.Orcamentos)
                .HasForeignKey(o => o.ClienteId);

            builder.HasMany(o => o.Itens)
                .WithOne(i => i.Orcamento)
                .HasForeignKey(i => i.OrcamentoId);                                        
     
                

            builder.ToTable("Orcamentos");

        }
    }
}
