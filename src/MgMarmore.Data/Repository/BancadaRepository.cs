using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Data.Repository
{
    public class BancadaRepository :  Repository<Bancada>, IBancadaRepository
    {
        public BancadaRepository(MgContext context): base(context)
        {
            
        }
        
    }
}
