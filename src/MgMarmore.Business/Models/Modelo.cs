using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Models
{
    public class Modelo : Entity
    {
        public TipoBancada Categoria { get; set; }
        public string Metodo { get; set; }
        public string Imagem { get; set; }
        public int QuantidadePecas { get; set; }
    }
}
