using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MgMarmore.Business.Models
{
    public class Orcamento : Entity
    {
        public Guid ClienteId { get; set; }
        public string Observacoes { get; set; }
        public decimal ValorTotal { get; set; }   

        /* EF Relational */
        public Cliente Cliente { get; set; }
        public IEnumerable<Item> Itens { get; set; }    
        public IEnumerable<OrcamentoProduto> OrcamentosProdutos { get; set; }
        public IEnumerable<OrcamentoServico> OrcamentosServicos { get; set; }

    }
}