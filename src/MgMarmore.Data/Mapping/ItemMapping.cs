using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MgMarmore.Data.Mapping
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(b => b.Id);

            //builder.Property(i => i.Saia)
            //    .HasColumnType("DECIMAL(10,3)");

            //builder.Property(i => i.Frontao)
            //    .HasColumnType("DECIMAL(10,3)");

            //builder.Property(i => i.Profundidade)
            //    .HasColumnType("DECIMAL(10,3)");

            //builder.Property(i => i.Borda)
            //    .HasColumnType("DECIMAL(10,3)");

            //builder.Property(i => i.Tampao)
            //    .HasColumnType("DECIMAL(10,3)");

            //builder.Property(i => i.Rodape)
            //    .HasColumnType("DECIMAL(10,3)");

            //builder.Property(i => i.RodapeComprimento)
            //   .HasColumnType("DECIMAL(10,3)");

            //builder.Property(i => i.RodapeTotal)
            //   .HasColumnType("DECIMAL(10,3)");           

            builder.Property(i => i.Descricao)
                .IsRequired()
                .HasColumnType("VARCHAR(250)");

            builder.Property(i => i.MetroQuadradoTotal)
                .IsRequired()
                .HasColumnType("DECIMAL(10,3)");

            builder.Property(i => i.QuantidadeItens)
                .IsRequired()
                .HasColumnType("INTEGER");

            builder.Property(i => i.ValorUnitario)
                .IsRequired()
                .HasColumnType("DECIMAL(10,3)");

            builder.Property(i => i.ValorTotal)
                .IsRequired()
                .HasColumnType("DECIMAL(10,3)");

            //builder.HasMany(i => i.Pecas)
            //    .WithOne(p => p.Item)
            //    .HasForeignKey(p => p.ItemId);

          

            builder.ToTable("Itens");

        }
    }
}
