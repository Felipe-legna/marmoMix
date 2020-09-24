using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MgMarmore.Data.Mapping
{
    public class PecaMapping : IEntityTypeConfiguration<Peca>
    {
        public void Configure(EntityTypeBuilder<Peca> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.ApoioLargura)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(s => s.AlturaDaBase)               
               .HasColumnType("DECIMAL(10,3)");

            builder.Property(s => s.LarguraPeca)
                .IsRequired()
                .HasColumnType("DECIMAL(10,3)");

            builder.Property(s => s.ApoioComprimento)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(s => s.ComprimentoPeca)
                .IsRequired()
                .HasColumnType("DECIMAL(10,3)");

            builder.Property(s => s.ComprimentoFogaoEmbutido)                
                .HasColumnType("DECIMAL(10,3)");
         

            builder.Property(s => s.TotalComprimentoPeca)                
                .HasColumnType("DECIMAL(10,3)");

            builder.Property(s => s.TotalLarguraPeca)              
              .HasColumnType("DECIMAL(10,3)");

            builder.Property(s => s.MetroQuadradoPeca)
            .IsRequired()
            .HasColumnType("DECIMAL(10,3)");


            builder.ToTable("Pecas");
        }
    }
}
