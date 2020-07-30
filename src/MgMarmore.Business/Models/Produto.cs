using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MgMarmore.Business.Models
{
    public class Produto : Entity
    {        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal? Custo { get; set; }      
        public decimal Valor { get; set; }       
        public IEnumerable<OrcamentoProduto> OrcamentosProdutos { get; set; }
    }
}