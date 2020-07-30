using MgMarmore.Business.Models;
using MgMarmore.Site.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MgMarmore.Site.ViewModels
{
    public class OrcamentoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [HiddenInput ]
        public Guid ClienteId { get; set; }

        [DisplayName("Observações")]
        public string Observacoes { get; set; }

        
        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [DisplayName("Valor Total")]
        public decimal ValorTotal { get; set; }
         
        public ClienteViewModel Cliente { get; set; }
        public IEnumerable<ItemViewModel> Itens { get; set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
        public IEnumerable<ServicoViewModel> Servicos { get; set; }
    }
}