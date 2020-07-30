
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
    public class ItemViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [HiddenInput]
        public Guid OrcamentoId { get; set; }

        [HiddenInput]
        public Guid MaterialId { get; set; }

        public List<PecaViewModel> Pecas { get; set; }
        public List<ServicoViewModel> Servicos { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        public decimal? Saia { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [DisplayName("Frontão")]
        public decimal? Frontao { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        public decimal? Profundidade { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        public decimal? Borda { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [DisplayName("Tampão")]
        public decimal? Tampao { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [DisplayName("Rodapé")]
        public bool Rodape { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [DisplayName("Comprimento do Rodapé")]
        public decimal? RodapeComprimento { get; set; }

        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [DisplayName("Total Rodapé")]
        public decimal? RodapeTotal { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [DisplayName("Metro Quadrado Total")]
        public decimal MetroQuadradoTotal { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, 9999, ErrorMessage = "Valores permitidos para {0} entre {1} e {2}")]
        [DisplayName("Qtd. Itens")]
        public int QuantidadeItens { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [DisplayName("Valor Unitário")]
        public decimal ValorUnitario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, 99999, ErrorMessage = "Permitido apenas númerios maiores que 0."), DataType(DataType.Currency)]
        [DisplayName("Valor Total")]
        public decimal ValorTotal { get; set; }
                
        public MaterialViewModel Material { get; set; }
    }
}