using B3.Cdb.Domain.Entities;

namespace B3.Cdb.Domain.Services
{
    public class CalculadoraDeInvestimento : ICalculadoraDeInvestimento
    {
        private const decimal CDI = 0.9m;
        private const decimal TB = 1.08m; // 108%

        public (decimal valorBruto, decimal valorLiquido) CalcularInvestimento(Investimento investimento)
        {
            decimal valorFinal = investimento.ValorInicial;
            for (int i = 0; i < investimento.Meses; i++)
            {
                valorFinal *= (1 + (CDI * TB));
            }

            decimal valorBruto = valorFinal;
            decimal imposto = CalcularImposto(investimento.Meses, valorBruto - investimento.ValorInicial);
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
