using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Models
{
    public class OrcamentoRevenda : Entity
    {
        public Guid OrcamentoId { get; set; }
        public Orcamento Orcamento { get; set; }
        public Guid RevendaId { get; set; }
        public Revenda Revenda { get; set; }
    }
}
