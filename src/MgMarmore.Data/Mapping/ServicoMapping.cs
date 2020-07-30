using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MgMarmore.Data.Mapping
{
    public class ServicoMapping : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(s =>s.Id);

            builder.Property(s => s.Descricao)
                .IsRequired()
                .HasColumnType("VARCHAR(250)");

            builder.Property(s => s.Valor)
                .IsRequired()
                .HasColumnType("DECIMAL(10,3)");            

            builder.ToTable("Servicos");
        }
    }
}
