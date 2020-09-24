using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MgMarmore.Data.Repository
{
    public class RevendaRepository : Repository<Revenda>, IRevendaRepository
    {
        public RevendaRepository(MgContext context): base(context) { }
        
    }
}
