using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MgMarmore.Business.Interfaces
{
    public interface IOrcamentoRepository : IRepository<Orcamento>
    {
        Task<IEnumerable<Orcamento>> ObterOrcamentosPorClienteAsync(Guid clienteId);
        Task<Orcamento> ObterOrcamentoClienteServicoRevendaItens(Guid id);        
    }
}
