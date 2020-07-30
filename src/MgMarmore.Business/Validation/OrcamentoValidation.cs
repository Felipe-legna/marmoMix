using FluentValidation;
using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Validation
{
    public class OrcamentoValidation : AbstractValidator<Orcamento>
    {
        public OrcamentoValidation()
        {
            RuleFor(o => o.ValorTotal)
                 .GreaterThan(0);
        }
    }
}
