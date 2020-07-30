using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MgMarmore.Data.Context
{
    public class MgContext : DbContext
    {
        public MgContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Bancada> Bancadas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }

        public DbSet<TipoItem> TiposItens { get; set; }
        public DbSet<OrcamentoProduto> OrcamentosProdutos { get; set; }
        public DbSet<OrcamentoServico> OrcamentosServicos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Para as propriedades do tipo string que não tiverem definidas, serão iniciadas no banco em um coluna com tamnho 100
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.Relational().ColumnType ="VARCHAR(100)";

            //pega todas as classes do MgContext e verifica classes que herdem de IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MgContext).Assembly);

            //Bloqueando a exclusão em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
