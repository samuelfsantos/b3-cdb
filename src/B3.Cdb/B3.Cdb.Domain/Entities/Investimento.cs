
namespace B3.Cdb.Domain.Entities
{
    public class Investimento
    {
        public decimal ValorInicial { get; private set; }
        public int PrazoMeses { get; private set; }

        public Investimento(decimal valorInicial, int prazoMeses)
        {
            ValorInicial = valorInicial;
            PrazoMeses = prazoMeses;
        }
    }
}
