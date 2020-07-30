using FluentValidation;
using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Validation
{
    public class PecaValidation : AbstractValidator<Peca>
    {
        public PecaValidation()
        {
            RuleFor(s => s.ApoioLargura.ToString())
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(s => s.LarguraPeca)
                  .GreaterThan(0);

            RuleFor(s => s.ApoioComprimento.ToString())
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(s => s.ComprimentoPeca)
                  .GreaterThan(0);

            RuleFor(s => s.MetroQuadradoPeca)
               .GreaterThan(0);
        }
    }
}
