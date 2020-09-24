using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MgMarmore.Data.Mapping
{
    public class CategoriaMaterialMapping : IEntityTypeConfiguration<CategoriaMaterial>
    {
        public void Configure(EntityTypeBuilder<CategoriaMaterial> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.HasMany(c => c.Materiais)
              .WithOne(c => c.CategoriaMaterial)
              .HasForeignKey(p => p.CategoriaMaterialId);
              

            builder.ToTable("CategoriasMateriais");
        }
    }
}
