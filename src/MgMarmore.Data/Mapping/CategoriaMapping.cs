using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MgMarmore.Data.Mapping
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.HasMany(m => m.Materiais)
                .WithOne(c => c.Categoria)
                .HasForeignKey(c => c.CategoriaId);                

            builder.ToTable("Categorias");
        }
    }
}
