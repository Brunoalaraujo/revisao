using EstacionamentoConsole.Models;
using Xunit;

namespace EstacionamentoTestes
{
    public class EstacionamentoServicoTestes
    {
        [Fact]
        public void TestAdicionarCarroTrue()
        {
            // Arrange
            var estacionamento = new Estacionamento(precoInicial: 5.0M, precoPorHora: 2.0M);
            var carro = new Carro(placa: "ABC-1234", modelo: "CarroTeste");
            var _servicoTeste = EstacionamentoServico.GetInstance();

            // Act
            bool resultado = _servicoTeste.AdicionarCarro(estacionamento, carro);

            // Assert
            Assert.True(resultado);
            Assert.Contains(carro, estacionamento.Carros);
        }

        [Fact]
        public void TestAdicionarCarroFalse()
        {
            // Arrange
            var estacionamento = new Estacionamento(precoInicial: 5.0M, precoPorHora: 2.0M);
            var carro = new Carro(placa: "ABC1234", modelo: "CarroTeste");
            var _servicoTeste = EstacionamentoServico.GetInstance();

            // Act
            bool resultado = _servicoTeste.AdicionarCarro(estacionamento, carro);

            // Assert
            Assert.False(resultado);
            Assert.DoesNotContain(carro, estacionamento.Carros);
        }

        [Fact]
        public void TestRemoverCarroTrue()
        {
            // Arrange
            var estacionamento = new Estacionamento(precoInicial: 5.0M, precoPorHora: 2.0M);
            var carro = new Carro(placa: "ABC-1234", modelo: "CarroTeste");
            var _servicoTeste = EstacionamentoServico.GetInstance();
            estacionamento.Carros.Add(carro);

            // Act
            bool resultado = _servicoTeste.RemoverCarro("ABC-1234", estacionamento);

            // Assert
            Assert.True(resultado);
            Assert.DoesNotContain(carro, estacionamento.Carros);
        }

        [Fact]
        public void TestRemoverCarroFalse()
        {
            // Arrange
            var estacionamento = new Estacionamento(precoInicial: 5.0M, precoPorHora: 2.0M);
            var carro = new Carro(placa: "ABC-1234", modelo: "CarroTeste");
            var _servicoTeste = EstacionamentoServico.GetInstance();
            estacionamento.Carros.Add(carro);

            // Act
            bool resultado = _servicoTeste.RemoverCarro("OutraPlaca", estacionamento);

            // Assert
            Assert.False(resultado);
            Assert.Contains(carro, estacionamento.Carros);
        }

        [Fact]
        public void TestValorAPagar()
        {
            // Arrange
            var estacionamento = new Estacionamento(precoInicial: 5.0M, precoPorHora: 2.0M);
            var _servicoTeste = EstacionamentoServico.GetInstance();

            // Act
            decimal resultado = _servicoTeste.ValorAPagar(3, estacionamento);

            // Assert
            Assert.Equal(9, resultado);
        }
    }
}
