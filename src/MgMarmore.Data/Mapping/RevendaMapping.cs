using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MgMarmore.Data.Mapping
{
    public class RevendaMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(s =>s.Id);

            builder.Property(s => s.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(250)");
                

            builder.ToTable("Produtos");
        }
    }
}
