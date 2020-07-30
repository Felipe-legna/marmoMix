using MgMarmore.Business.Models;
using System;
using System.Threading.Tasks;

namespace MgMarmore.Business.Interfaces
{
    public interface IPecaRepository : IRepository<Peca>
    {        
        Task<Peca> ObterPecaPorItem(Guid itemId);
    }
}
