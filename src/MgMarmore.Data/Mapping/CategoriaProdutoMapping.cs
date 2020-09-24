using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MgMarmore.Data.Mapping
{
    public class CategoriaProdutoMapping : IEntityTypeConfiguration<CategoriaProduto>
    {
        public void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.HasMany(c => c.Produtos)
              .WithOne(c => c.CategoriaProduto)
              .HasForeignKey(p => p.CategoriaProdutoId);
              

            builder.ToTable("CategoriasProdutos");
        }
    }
}
