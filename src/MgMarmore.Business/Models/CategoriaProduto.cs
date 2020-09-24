using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Models
{
    public class CategoriaProduto : Entity
    {
        public string   Nome { get; set; }

        /*EF Relational*/
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
