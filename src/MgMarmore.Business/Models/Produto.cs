using MgMarmore.Business.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Models
{
    public class Produto : Entity
    {
        public Guid CategoriaProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public bool Ativo { get; set; }

        /*EF Relation */
        public CategoriaProduto CategoriaProduto { get; set; }

    }
}
