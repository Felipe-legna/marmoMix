using FluentValidation;
using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Validation
{
    public class ItemValidation : AbstractValidator<Item>
    {
        public ItemValidation()
        {
            RuleFor(i => i.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(i => i.MetroQuadradoTotal)
               .GreaterThan(0);

            RuleFor(i => i.QuantidadeItens)
               .GreaterThan(0);

            RuleFor(i => i.ValorUnitario)
                .GreaterThan(0);

            RuleFor(i => i.ValorTotal)
                .GreaterThan(0);
        }

    }
}
