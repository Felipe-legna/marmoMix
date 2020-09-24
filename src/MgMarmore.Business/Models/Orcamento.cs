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
        public Cliente Cliente { get; set; }

        public DateTime DataCriacao { get; set; }
        
        public decimal ValorTotal { get; set; }     

        public string Observacao { get; set; }

     
        public IEnumerable<OrcamentoProduto> Itens { get; set; }

    }
}