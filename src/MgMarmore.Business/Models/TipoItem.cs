using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Models
{
    public class TipoItem : Entity
    {
        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public List<Bancada> Bancadas { get; set; }
    }
}
