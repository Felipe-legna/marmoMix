using MgMarmore.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Models
{
    public class Bancada :Entity
    {   
        public Guid ProdutoId { get; set; }       

        public TipoBancada Categoria { get; set; }
        public decimal Frontao { get; set; }
        public decimal Saia { get; set; }
        public string Metodo { get; set; }
        public string Imagem { get; set; }
        public int QuantidadePecas { get; set; }
        public decimal MetroQuadrado { get; set; }


       public Produto  Produto { get; set; }
       public List<Peca> Pecas { get; set; }
    }
}
