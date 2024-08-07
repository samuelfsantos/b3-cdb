using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B3.Cdb.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace B3.Cdb.Domain.Validators
{
    public class InvestimentoValidator : AbstractValidator<Investimento>, IInvestimentoValidator
    {
        public InvestimentoValidator()
        {
            RuleFor(i => i.ValorInicial)
                .GreaterThan(0).WithMessage("O valor inicial deve ser maior que zero.");

            RuleFor(i => i.PrazoMeses)
                .GreaterThan(1).WithMessage("O prazo em meses deve ser maior que 1.");
        }

        public ValidationResult Validar(Investimento instance)
        {
            return Validate(instance);
        }
    }
}
