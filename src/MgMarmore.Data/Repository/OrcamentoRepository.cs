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

        public async Task<Orcamento> ObterOrcamentoClienteServicoRevendaItens(Guid id)
        {
            throw new NotImplementedException();
            //return await Db.Orcamentos.AsNoTracking()
            //    .Include(o => o.Cliente)                   

            //    .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Orcamento>> ObterOrcamentosPorClienteAsync(Guid clienteId)
        {
            throw new NotImplementedException();
            //return await Buscar(o => o.ClienteId == clienteId);
        }
    }
}
