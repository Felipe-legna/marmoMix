using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MgContext db) : base(db){}

        //public async Task<IEnumerable<Produto>> ObterProdutosPorOrcamento(Guid orcamentoId)
        //{
        //    return await Buscar(p => p.OrcamentoId == orcamentoId);

        //    // outrpa opcao
        //    //return await Db.Produtos.AsNoTracking().Where(p => p.OrcamentoId == orcamentoId).ToListAsync();
        //}
    }
}
