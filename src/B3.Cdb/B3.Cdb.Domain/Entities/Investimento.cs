
namespace B3.Cdb.Domain.Entities
{
    public class Investimento
    {
        public decimal ValorInicial { get; private set; }
        public int Meses { get; private set; }

        public Investimento(decimal valorInicial, int meses)
        {
            ValorInicial = valorInicial;
            Meses = meses;
        }
    }
}
