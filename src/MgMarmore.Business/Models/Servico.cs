
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Models
{
    public class Servico : Entity
    {      
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        /*EF Relational*/      
        public IEnumerable<OrcamentoServico> OrcamentosServicos { get; set; }  
        
    }
}
