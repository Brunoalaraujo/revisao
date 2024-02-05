using System.Text.RegularExpressions;

namespace EstacionamentoConsole.Models
{
    public sealed class EstacionamentoServico
    {
        // design pattern Singleton - 
        private static EstacionamentoServico _instance;

        // Validação da placa com Regex
        private Regex _modeloPlacaAntiga = new Regex(@"^[A-Z]{3}-\d{4}$"); // ABC-1234
        private Regex _modeloPlacaMercosul = new Regex(@"^[A-Z]{3}\d{1}[A-Z]{1}\d{2}$"); // ABC1D23

        private EstacionamentoServico() { }

        public static EstacionamentoServico GetInstance()
        {
            if (_instance == null)
            {
                _instance = new EstacionamentoServico();
            }
            return _instance;
        }

        private bool ValidarCarro(Carro carro)
        {
            if (carro.Modelo == null)
            {
                return false;
            }
            if (_modeloPlacaAntiga.IsMatch(carro.Placa) || _modeloPlacaMercosul.IsMatch(carro.Placa))
            {
                return true;
            }
            return false;
        }

        public bool AdicionarCarro(Estacionamento estacionamento, Carro carro)
        {
            if (ValidarCarro(carro))
            {
                List<Carro> carros = estacionamento.Carros;

                if (!carros.Any(x => x.Placa.ToUpper().Equals(carro.Placa.ToUpper())))
                {
                    estacionamento.Carros.Add(carro);
                    return true;
                }
                return false;
            }
            return false;
        }


        public bool RemoverCarro(string placa, Estacionamento estacionamento)
        {
            List<Carro> carros = estacionamento.Carros;

            if (carros.Any(x => x.Placa.ToUpper().Equals(placa.ToUpper())))
            {
                carros.Remove(carros.Find(x => x.Placa.Equals(placa.ToUpper())));
                return true;
            }

            return false;
        }

        public decimal ValorAPagar(decimal horas, Estacionamento estacionamento)
        {
            if (horas <= 1)
            {
                return estacionamento.PrecoInicial;
            }

            return estacionamento.PrecoInicial + (estacionamento.PrecoPorHora * (horas - 1));
        }
    }
}
