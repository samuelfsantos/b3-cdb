using B3.Cdb.Domain.Entities;

namespace B3.Cdb.Domain.Services
{
    public class CalculadoraDeInvestimento : ICalculadoraDeInvestimento
    {
        private const decimal CDI = 0.009m; // CDI como taxa mensal, 0.9% por mês
        private const decimal TB = 1.08m;   // 108%

        public (decimal valorBruto, decimal valorLiquido) Calcular(Investimento investimento)
        {
            if (investimento.ValorInicial <= 0 || investimento.PrazoMeses <= 1)
            {
                return (0, 0);
            }

            decimal valorFinal = investimento.ValorInicial;
            for (int i = 0; i < investimento.PrazoMeses; i++)
            {
                valorFinal *= (1 + (CDI * TB));
            }

            decimal valorBruto = valorFinal;
            decimal imposto = CalcularImposto(investimento.PrazoMeses, valorBruto - investimento.ValorInicial);
            decimal valorLiquido = valorBruto - imposto;

            return (valorBruto, valorLiquido);
        }

        private decimal CalcularImposto(int meses, decimal rendimento)
        {
            decimal aliquota = meses <= 6 ? 0.225m :
                               meses <= 12 ? 0.20m :
                               meses <= 24 ? 0.175m : 0.15m;

            return rendimento * aliquota;
        }
    }
}
