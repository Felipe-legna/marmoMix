using FluentValidation;
using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Validation
{
    public class BancadaValidation : AbstractValidator<Bancada>
    {
        public BancadaValidation()
        {
            RuleFor(m => m.Metodo)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
             .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

           
            RuleFor(m => m.QuantidadePecas)
                .GreaterThan(0);

        }
    }
}
