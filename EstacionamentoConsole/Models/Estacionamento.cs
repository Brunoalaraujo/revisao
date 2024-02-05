using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoConsole.Models
{
    public class Estacionamento
    {
        public decimal PrecoInicial { get; set; }

        public decimal PrecoPorHora { get; set; }

        public List<Carro> Carros { get; set; }

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
            Carros = new List<Carro>();
        }
    }
}