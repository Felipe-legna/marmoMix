using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Business.Interfaces
{
    public interface ICategoriaMaterialRepository :  IRepository<CategoriaMaterial>
    {
        Task<CategoriaMaterial> ObterCategoriaMateriais(Guid id);
    }
}
