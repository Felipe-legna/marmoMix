using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MgMarmore.Business.Models
{
    public class Peca : Entity
    {              
        public Guid ProdutoId { get; set; }

        public decimal LarguraPeca { get; set; }

        public TipoSustentacao ApoioLargura { get; set; }

        public decimal TotalLarguraPeca { get; set; }

        public decimal ComprimentoPeca { get; set; }

        public TipoSustentacao ApoioComprimento { get; set; }
        
        public decimal ComprimentoFogaoEmbutido { get; set; }
        
        public TipoBase Base { get; set; }

        public decimal AlturaDaBase { get; set; }

        public decimal TotalComprimentoPeca { get; set; }

        public decimal MetroQuadradoPeca { get; set; }


        /*  EF Relational */

        public Produto Produto { get; set; }
      
    }
}