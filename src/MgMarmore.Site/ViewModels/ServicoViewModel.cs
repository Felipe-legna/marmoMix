using MgMarmore.Business.Models;
using MgMarmore.Site.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MgMarmore.Site.ViewModels
{
    public class ServicoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [HiddenInput]
        public Guid OrcamentoId { get; set; }

        [HiddenInput]
        public Guid ItemId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        //[RegularExpression(@"^[1-9\.\,]\d*$", ErrorMessage = "Permitido apenas números maiores que 0.")]
        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }   
        
        public OrcamentoViewModel Orcamento { get; set; }
    }
}
