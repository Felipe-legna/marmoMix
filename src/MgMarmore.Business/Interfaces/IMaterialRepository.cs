using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MgMarmore.Business.Interfaces
{
    public interface IMaterialRepository : IRepository<Material>
    {
        Task<Material> ObterMaterialPecas(Guid id);
        Task<Material> ObterMaterialCategoria(Guid id);
        Task<IEnumerable<Material>> ObterMateriaisCategoria();
    }
}
