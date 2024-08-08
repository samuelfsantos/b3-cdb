using B3.Cdb.Application.Interfaces;
using B3.Cdb.Application.Requests;
using B3.Cdb.Application.Services;
using B3.Cdb.Domain.Entities;
using B3.Cdb.Domain.Notifications;
using B3.Cdb.Domain.Validators;
using B3.Cdb.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Moq;

namespace B3.Cdb.Test.Application
{
    [Collection("B3.Cdb.Test")]
    public class InvestimentoApplicationTest
    {
        private readonly IInvestimentoApplication _investimentoApp;
        private readonly INotifier _notifier;
        public InvestimentoApplicationTest()
        {
            // Configurar o IoC reutilizando a configuração do projeto IoC
            var container = IocConfig.RegisterDependenciesTest();

            _investimentoApp = container.GetInstance<IInvestimentoApplication>();
            _notifier = container.GetInstance<INotifier>();
        }

        [Fact]
        public void Deve_Calcular_Investimento_Valido_Valor_1000()
        {
            // Arrange
            var request = new CalculoInvestimentoRequest { ValorInicial = 1000, PrazoMeses = 12 };

            // Act
            var response = _investimentoApp.Calcular(request);

            // Assert
            response.Should().NotBeNull();
            response.ValorBruto.Should().Be(1123.0820949653057631841036240M);
            response.ValorLiquido.Should().Be(1098.4656759722446105472828992M);
            response.ValorInicial.Should().Be(request.ValorInicial);
            response.PrazoMeses.Should().Be(request.PrazoMeses);
            _notifier.HasNotifications().Should().BeFalse();
        }

        [Fact]
        public void Deve_Calcular_Investimento_Valido_Valor_2000()
        {
            // Arrange
            var request = new CalculoInvestimentoRequest { ValorInicial = 2000, PrazoMeses = 12 };

            // Act
            var response = _investimentoApp.Calcular(request);

            // Assert
            response.Should().NotBeNull();
            response.ValorBruto.Should().Be(2246.1641899306115263682072483M);
            response.ValorLiquido.Should().Be(2196.9313519444892210945657986M);
            response.ValorInicial.Should().Be(request.ValorInicial);
            response.PrazoMeses.Should().Be(request.PrazoMeses);
            _notifier.HasNotifications().Should().BeFalse();
        }

        [Fact]
        public void Nao_Deve_Calcular_Investimento_Se_ValorInicial_For_Negativo()
        {
            // Arrange
            var request = new CalculoInvestimentoRequest { ValorInicial = -850, PrazoMeses = 8 };

            // Act
            var response = _investimentoApp.Calcular(request);

            // Assert
            response.Should().BeNull();
            _notifier.GetNotifications().Any(x => x.Message.Contains("O valor inicial deve ser maior que zero.")).Should().BeTrue();
        }

        [Fact]
        public void Nao_Deve_Calcular_Investimento_Se_ValorInicial_For_Zero()
        {
            // Arrange
            var request = new CalculoInvestimentoRequest { ValorInicial = 0, PrazoMeses = 8 };

            // Act
            var response = _investimentoApp.Calcular(request);

            // Assert
            response.Should().BeNull();
            _notifier.GetNotifications().Any(x => x.Message.Contains("O valor inicial deve ser maior que zero.")).Should().BeTrue();
        }

        [Fact]
        public void Nao_Deve_Calcular_Investimento_Se_PrazoMeses_For_Negativo()
        {
            // Arrange
            var request = new CalculoInvestimentoRequest { ValorInicial = 710, PrazoMeses = -15 };

            // Act
            var response = _investimentoApp.Calcular(request);

            // Assert
            response.Should().BeNull();
            _notifier.GetNotifications().Any(x => x.Message.Contains("O prazo em meses deve ser maior que 1.")).Should().BeTrue();
        }

        [Fact]
        public void Nao_Deve_Calcular_Investimento_Se_PrazoMeses_For_Zero()
        {
            // Arrange
            var request = new CalculoInvestimentoRequest { ValorInicial = 710, PrazoMeses = 0 };

            // Act
            var response = _investimentoApp.Calcular(request);

            // Assert
            response.Should().BeNull();
            _notifier.GetNotifications().Any(x => x.Message.Contains("O prazo em meses deve ser maior que 1.")).Should().BeTrue();
        }

        [Fact]
        public void Nao_Deve_Calcular_Investimento_Se_PrazoMeses_For_Um()
        {
            // Arrange
            var request = new CalculoInvestimentoRequest { ValorInicial = 710, PrazoMeses = 1 };

            // Act
            var response = _investimentoApp.Calcular(request);

            // Assert
            response.Should().BeNull();
            _notifier.GetNotifications().Any(x => x.Message.Contains("O prazo em meses deve ser maior que 1.")).Should().BeTrue();
        }
    }
}
