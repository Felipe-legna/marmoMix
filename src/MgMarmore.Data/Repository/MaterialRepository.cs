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
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(MgContext db) : base(db)
        {
        }

        public async Task<Material> ObterMaterialPecas(Guid id)
        {
            return await Db.Materiais.AsNoTracking()
                .Include(m => m.Pecas).FirstOrDefaultAsync();
        }

        public async Task<Material> ObterMaterialCategoria(Guid id)
        {
            return await Db.Materiais.AsNoTracking()
                .Include(m => m.Categoria).FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<IEnumerable<Material>> ObterMateriaisCategoria()
        {
            return await Db.Materiais.AsNoTracking()
                .Include(m => m.Categoria).ToListAsync();
        }
    }
}
