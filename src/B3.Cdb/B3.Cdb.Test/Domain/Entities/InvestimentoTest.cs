using B3.Cdb.Domain.Entities;
using B3.Cdb.Domain.Notifications;
using B3.Cdb.Domain.Validators;
using B3.Cdb.IoC;
using System.Linq;
using Xunit;

namespace B3.Cdb.Test.Domain.Entities
{
    [Collection("B3.Cdb.Test")]
    public class InvestimentoTest
    {
        private readonly IInvestimentoValidator _validator;
        private readonly INotifier _notifier;

        public InvestimentoTest()
        {
            // Configurar o IoC reutilizando a configuração do projeto IoC
            var container = IocConfig.RegisterDependenciesTest();

            _validator = container.GetInstance<IInvestimentoValidator>();
            _notifier = container.GetInstance<INotifier>();
        }

        [Fact]
        public void Deve_Validar_Investimento_Corretamente()
        {
            // Arrange
            var investimento = new Investimento(1000, 12);

            // Act
            var result = _validator.Validar(investimento);

            // Assert
            Assert.True(result.Errors.Count == 0);
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Erro_Se_ValorInicial_For_Negativo()
        {
            // Arrange
            var investimento = new Investimento(-1000, 12);

            // Act
            var result = _validator.Validar(investimento);

            // Assert
            var valido = result.Errors.Count > 0
                && result.Errors.FirstOrDefault(x => x.ErrorMessage.Contains("O valor inicial deve ser maior que zero.")) != null;

            Assert.True(valido);
        }
        [Fact]
        public void Deve_Retornar_Notificacao_Erro_Se_ValorInicial_For_Zero()
        {
            // Arrange
            var investimento = new Investimento(0, 12);

            // Act
            var result = _validator.Validar(investimento);

            // Assert
            var valido = result.Errors.Count > 0
                && result.Errors.FirstOrDefault(x => x.ErrorMessage.Contains("O valor inicial deve ser maior que zero.")) != null;

            Assert.True(valido);
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Erro_Se_PrazoMeses_For_Negativo()
        {
            // Arrange
            var investimento = new Investimento(1000, -10);

            // Act
            var result = _validator.Validar(investimento);

            // Assert
            var valido = result.Errors.Count > 0
                && result.Errors.FirstOrDefault(x => x.ErrorMessage.Contains("O prazo em meses deve ser maior que 1.")) != null;

            Assert.True(valido);
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Erro_Se_PrazoMeses_For_Zero()
        {
            // Arrange
            var investimento = new Investimento(1000, 0);

            // Act
            var result = _validator.Validar(investimento);

            // Assert
            var valido = result.Errors.Count > 0
                && result.Errors.FirstOrDefault(x => x.ErrorMessage.Contains("O prazo em meses deve ser maior que 1.")) != null;

            Assert.True(valido);
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Erro_Se_PrazoMeses_For_Um()
        {
            // Arrange
            var investimento = new Investimento(1000, 1);

            // Act
            var result = _validator.Validar(investimento);

            // Assert
            var valido = result.Errors.Count > 0
                && result.Errors.FirstOrDefault(x => x.ErrorMessage.Contains("O prazo em meses deve ser maior que 1.")) != null;

            Assert.True(valido);
        }
    }
}
