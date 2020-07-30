using MgMarmore.Business.Models;
using MgMarmore.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Data.Repository
{
    public class TipoItemRepository : Repository<TipoItem>
    {
        public TipoItemRepository(MgContext db) : base(db) { }
       
        
    }
}
