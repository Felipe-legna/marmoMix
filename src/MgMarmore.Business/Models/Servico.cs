
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Models
{
    public class Servico : Entity
    {       
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        /*EF Relational*/
        public List<ServicosItens> ServicosItens { get; set; }
        public IEnumerable<OrcamentoServico> OrcamentosServicos { get; set; }  
        
    }
}
