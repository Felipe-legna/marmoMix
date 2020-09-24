using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MgMarmore.Business.Models
{
    public class Item : Entity
    {
        public Guid OrcamentoId { get; set; }
        //public string ImagemItem { get; set; }
        //public TipoItem TipoItem { get; set; }



        public string Descricao { get; set; }
        public decimal MetroQuadradoTotal { get; set; }
        public int QuantidadeItens { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }




        //public decimal? Saia { get; set; }

        //public decimal? Frontao { get; set; }

       
        //public decimal? Profundidade { get; set; }

       
        //public decimal? Borda { get; set; }

       
        //public decimal? Tampao { get; set; }

      
        //public bool Rodape { get; set; }

     
        //public decimal? RodapeComprimento { get; set; }

        
        //public decimal? RodapeTotal { get; set; }


     

        /* EF Relation */
        public Orcamento Orcamento { get; set; }
        //public List<Peca> Pecas { get; set; }
        //public List<ServicosItens> ServicosItens { get; set; }
    }
}