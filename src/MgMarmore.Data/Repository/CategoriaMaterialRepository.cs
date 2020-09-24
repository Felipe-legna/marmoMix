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
    public class CategoriaMaterialRepository : Repository<CategoriaMaterial>, ICategoriaMaterialRepository
    {
        public CategoriaMaterialRepository(MgContext db) : base(db)
        {
        }

        public Task<CategoriaMaterial> ObterCategoriaMateriais(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
