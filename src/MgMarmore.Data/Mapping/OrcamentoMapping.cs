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

            builder.Property(o => o.DataCriacao).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();

            builder.Property(o => o.ValorTotal)
                .IsRequired()
                .HasColumnType("DECIMAL(10,3)");
         

            builder.Property(o => o.Observacao)
               .IsRequired()
               .HasColumnType("VARCHAR(550)");

            builder.HasMany(o => o.Itens)
                .WithOne(i => i.Orcamento);

            builder.ToTable("Orcamentos");

        }
    }
}
