using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MgMarmore.Data.Repository
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(MgContext context): base(context) { }
        
    }
}
