using System;

namespace B3.Cdb.Application.Responses
{
    public class CalculoInvestimentoResponse
    {
        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }
        public DateTime HorarioCalculo { get; set; }
    }
}
