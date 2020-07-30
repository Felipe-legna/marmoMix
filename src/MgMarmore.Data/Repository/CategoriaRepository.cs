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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(MgContext db) : base(db)
        {
        }

        public async Task<Categoria> ObterCategoriaMateriais(Guid id)
        {
            return await Db.Categorias.AsNoTracking()
                            .Include(c => c.Materiais).FirstOrDefaultAsync();
        }
    }
}
