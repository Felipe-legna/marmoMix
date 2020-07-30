using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MgMarmore.Data.Mapping
{
    class MaterialMapping : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m =>m.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.Property(m => m.Custo)
             .IsRequired()
             .HasColumnType("DECIMAL(10,3)");

            builder.Property(m => m.Valor)
              .IsRequired()
              .HasColumnType("DECIMAL(10,3)");

            builder.Property(m => m.Imagem)
                .HasColumnType("VARCHAR(200)");

            builder.HasMany(m => m.Pecas)
                .WithOne(m => m.Material)
                .HasForeignKey(m => m.MaterialId);
            
            builder.ToTable("Materiais");
        }
    }
}
