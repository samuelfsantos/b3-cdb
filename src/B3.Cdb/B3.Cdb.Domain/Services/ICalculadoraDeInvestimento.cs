using B3.Cdb.Domain.Entities;

namespace B3.Cdb.Domain.Services
{
    public interface ICalculadoraDeInvestimento
    {
        (decimal valorBruto, decimal valorLiquido) Calcular(Investimento investimento);
    }
}
