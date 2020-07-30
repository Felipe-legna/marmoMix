using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MgMarmore.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        //Task<IEnumerable<Produto>> ObterProdutosPorOrcamento(Guid orcamentoId);
    }
}
