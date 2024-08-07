using B3.Cdb.Application.Requests;
using B3.Cdb.Application.Responses;

namespace B3.Cdb.Application.Interfaces
{
    public interface IInvestimentoApplication
    {
        CalculoInvestimentoResponse Calcular(CalculoInvestimentoRequest request);
    }
}
