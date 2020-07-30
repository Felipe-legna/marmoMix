using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MgMarmore.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {       
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(250)");


            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("VARCHAR(250)");

            builder.Property(p => p.Custo)
                    .IsRequired()
                    .HasColumnType("DECIMAL(10,3)");

            builder.Property(p => p.Valor)
                    .IsRequired()
                    .HasColumnType("DECIMAL(10,3)");

            builder.ToTable("Produtos");
        }
    }
}
