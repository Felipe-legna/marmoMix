using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MgMarmore.Data.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.HasKey(p => p.Id);


            builder.HasMany(c => c.Orcamentos)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId);

            builder.Property(c => c.Nome)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(p => p.Documento)
               .IsRequired()
               .HasColumnType("varchar(14)");

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(c => c.Telefone)
                    .IsRequired()
                    .HasColumnType("varchar(12)");

            builder.Property(c => c.TipoCliente)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.HasOne(c => c.Endereco)
             .WithOne(e => e.Cliente);
             


            builder.ToTable("Clientes");
        }
    }
}
