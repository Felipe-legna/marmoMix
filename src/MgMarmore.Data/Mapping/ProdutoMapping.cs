using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MgMarmore.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(s =>s.Id);

            builder.Property(s => s.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(250)");

            builder.Property(s => s.Descricao)
              .IsRequired()
              .HasColumnType("VARCHAR(250)");

            builder.Property(s => s.Valor)
              .IsRequired()
              .HasColumnType("DECIMAL(10,2)");

            builder.HasOne(p => p.CategoriaProduto)
                .WithMany(cp => cp.Produtos)
                .HasForeignKey(p => p.CategoriaProdutoId);

            builder.Property(p => p.TipoProduto)
                .HasConversion<string>();

            builder.ToTable("Produtos");
        }
    }
}
