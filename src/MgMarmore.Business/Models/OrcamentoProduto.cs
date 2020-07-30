using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Models
{
    public class OrcamentoProduto
    {
        public Guid OrcamentoId { get; set; }
        public Orcamento Orcamento { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
