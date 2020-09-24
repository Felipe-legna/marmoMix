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
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(MgContext db) : base(db){}

        public async Task<Item> ObterItemServicosPecas(Guid id)
        {
            return await Db.Itens.AsNoTracking()                      
                        //.Include(i => i.Pecas)                        
                        .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Item> ObterItemServicosPecasMaterial(Guid id)
        {
            return await Db.Itens.AsNoTracking()                        
                        //.Include(i => i.Pecas)                        
                        .FirstOrDefaultAsync(i => i.Id == id);
        }        
    }
}
