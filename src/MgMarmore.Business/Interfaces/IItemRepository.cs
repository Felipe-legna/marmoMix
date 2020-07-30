using MgMarmore.Business.Models;
using System;
using System.Threading.Tasks;

namespace MgMarmore.Business.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<Item> ObterItemServicosPecas(Guid id);
        Task<Item> ObterItemServicosPecasMaterial(Guid id);
      
    }
}
