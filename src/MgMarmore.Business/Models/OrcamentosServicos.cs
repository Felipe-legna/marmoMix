using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Models
{
    public class OrcamentoServico : Entity
    {
        public Guid OrcamentoId { get; set; }
        public Orcamento Orcamento { get; set; }
        public Guid ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}
