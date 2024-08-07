using B3.Cdb.Domain.Entities;
using B3.Cdb.Domain.Services;
using B3.Cdb.Domain.Validators;
using B3.Cdb.IoC;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace B3.Cdb.Test.Domain.Services
{
    [Collection("B3.Cdb.Test")]
    public class CalculadoraDeInvestimentoTest
    {
        private readonly ICalculadoraDeInvestimento _calculadora;
        public CalculadoraDeInvestimentoTest()
        {
            // Configurar o IoC reutilizando a configuração do projeto IoC
            var container = IocConfig.RegisterDependenciesTest();

            _calculadora = container.GetInstance<ICalculadoraDeInvestimento>();
        }

        [Fact]
        public void Deve_Calcular_Valores_Bruto_Liquido_Corretamente_Para_Investimento_Valido()
        {
            // Arrange
            var investimento = new Investimento(1000, 12);

            // Act
            var (valorBruto, valorLiquido) = _calculadora.Calcular(investimento);

            // Assert
            valorBruto.Should().Be(1123.0820949653057631841036240M);
            valorLiquido.Should().Be(1098.4656759722446105472828992M);
        }

        [Fact]
        public void Deve_Retornar_Zero_Para_Valores_Bruto_Liquido_Se_Valor_Inicial_For_Negativo()
        {
            // Arrange
            var investimento = new Investimento(-1000, 12);

            // Act
            var (valorBruto, valorLiquido) = _calculadora.Calcular(investimento);

            // Assert
            valorBruto.Should().Be(0);
            valorLiquido.Should().Be(0);
        }

        [Fact]
        public void Deve_Retornar_Zero_Para_Valores_Bruto_Liquido_Se_Prazo_For_Invalido()
        {
            // Arrange
            var investimento = new Investimento(1000, 0);

            // Act
            var (valorBruto, valorLiquido) = _calculadora.Calcular(investimento);

            // Assert
            valorBruto.Should().Be(0);
            valorLiquido.Should().Be(0);
        }
    }
}
