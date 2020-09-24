using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Data.Repository
{
    public class ModeloBancadaRepository : Repository<ModeloBancada>, IModeloBancadaRepository
    {
        public ModeloBancadaRepository(MgContext db) : base(db) { }
        
    }
}
