using System;
using System.Threading.Tasks;
using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MgMarmore.Data.Repository
{
    public class PecaRepository : Repository<Peca>, IPecaRepository
    {
        public PecaRepository(MgContext db) : base(db){ }        

        public async Task<Peca> ObterPecaPorItem(Guid itemId)
        {
            return await Db.Pecas.AsNoTracking()
                .FirstOrDefaultAsync(p => p.ItemId == itemId);
        }
    }
}
