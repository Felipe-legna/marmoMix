using MgMarmore.Business.Models;
using MgMarmore.Site.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MgMarmore.Site.ViewModels
{
    public class MaterialViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "É necessário selecionar uma Categoria")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Imagem do Material")]
        public IFormFile ImagemUpload { get; set; }
        public string Imagem { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Custo { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        public CategoriaViewModel Categoria { get; set; }
              
     
    }
}