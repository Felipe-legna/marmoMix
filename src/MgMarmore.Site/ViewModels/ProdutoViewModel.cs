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
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [HiddenInput]
        public Guid OrcamentoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]      
        public decimal Custo { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }   
        
        public Orcamento Orcamento { get; set; }
    }
}
