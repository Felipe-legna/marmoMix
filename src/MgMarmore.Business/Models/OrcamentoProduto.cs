using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Models
{
    public class OrcamentoProduto : Entity
    {
        public Guid OrcamentoId { get; set; }
        public Orcamento Orcamento { get; set; }

        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
        public Decimal Valor { get; set; }
        public Decimal Desconto { get; set; }
    }
}
