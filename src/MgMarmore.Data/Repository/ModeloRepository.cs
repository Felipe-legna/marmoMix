using MgMarmore.Business.Models;
using MgMarmore.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Data.Repository
{
    public class ModeloRepository : Repository<Modelo>
    {
        public ModeloRepository(MgContext db) : base(db) { }
        
    }
}
