using MgMarmore.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Models
{
    public class ModeloBancada : Entity, IItem
    {
        public TipoBancada Categoria { get; set; }
        public string Metodo { get; set; }
        public string Imagem { get; set; }
        public int QuantidadePecas { get; set; }
    }
}
