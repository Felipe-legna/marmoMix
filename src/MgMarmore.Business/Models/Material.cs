using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MgMarmore.Business.Models
{
    public class Material : Entity
    {
        public Guid CategoriaMaterialId { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }

        public decimal? Custo { get; set; }
            
        public decimal Valor { get; set; }


        /* EF Relations */
        public CategoriaMaterial CategoriaMaterial { get; set; }
       
    }
}