using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Models
{
    public class Revenda : Entity
    {
        public string Nome { get; set; }


        /*EF Relation */
        public IEnumerable<OrcamentoRevenda> OrcamentosRevendas { get; set; }
    }
}
