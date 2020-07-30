using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Data.Repository
{
    public class OrcamentoRepository : Repository<Orcamento>, IOrcamentoRepository
    {
        public OrcamentoRepository(MgContext db) : base(db)
        {}

        public async Task<Orcamento> ObterOrcamentoClienteServicoProdutoItens(Guid id)
        {
            return await Db.Orcamentos.AsNoTracking()
                .Include(o => o.Cliente)                       
                .Include(o => o.Itens)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Orcamento>> ObterOrcamentosPorClienteAsync(Guid clienteId)
        {
            return await Buscar(o => o.ClienteId == clienteId);
        }
    }
}
