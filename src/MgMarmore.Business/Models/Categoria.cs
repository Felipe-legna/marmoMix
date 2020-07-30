using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;

namespace MgMarmore.Business.Models
{
    public class Categoria : Entity
    {           
        public string Nome { get; set; }

        /*EF Relational*/
        public IEnumerable<Material> Materiais { get; set; }
    }
}