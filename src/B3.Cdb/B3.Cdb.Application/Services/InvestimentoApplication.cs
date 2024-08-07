using B3.Cdb.Application.Interfaces;
using B3.Cdb.Application.Requests;
using B3.Cdb.Application.Responses;
using B3.Cdb.Domain.Entities;
using B3.Cdb.Domain.Notifications;
using B3.Cdb.Domain.Services;
using B3.Cdb.Domain.Validators;
using System;

namespace B3.Cdb.Application.Services
{
    public class InvestimentoApplication : IInvestimentoApplication
    {
        private readonly ICalculadoraDeInvestimento _calculadoraDeInvestimento;
        private readonly IInvestimentoValidator _investimentoValidator;
        private readonly INotifier _notifier;

        public InvestimentoApplication(ICalculadoraDeInvestimento calculadoraDeInvestimento, IInvestimentoValidator investimentoValidator, INotifier notifier)
        {
            _calculadoraDeInvestimento = calculadoraDeInvestimento;
            _investimentoValidator = investimentoValidator;
            _notifier = notifier;
        }

        public CalculoInvestimentoResponse Calcular(CalculoInvestimentoRequest request)
        {
            var investimento = new Investimento(request.ValorInicial, request.PrazoMeses);

            _notifier.NotifyErrors(_investimentoValidator.Validar(investimento));

            if (!_notifier.HasNotifications())
            {
                var (bruto, liquido) = _calculadoraDeInvestimento.Calcular(investimento);

                return new CalculoInvestimentoResponse
                {
                    ValorInicial = request.ValorInicial,
                    PrazoMeses = request.PrazoMeses,
                    ValorBruto = bruto,
                    ValorLiquido = liquido,
                    HorarioCalculo = DateTime.Now
                };
            }

            return null;
        }
    }
}
