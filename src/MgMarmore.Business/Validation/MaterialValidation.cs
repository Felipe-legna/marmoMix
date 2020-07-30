using FluentValidation;
using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Validation
{
    public class MaterialValidation : AbstractValidator<Material>
    {
        public MaterialValidation()
        {
            RuleFor(m => m.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(m => m.Custo)
                .GreaterThan(0);

            RuleFor(m => m.Valor)
                .GreaterThan(0);
        }
    }
}
