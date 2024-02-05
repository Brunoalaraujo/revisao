using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoConsole.Models
{
    public class Carro
    {
        public string Placa { get; set; }

        public string Modelo { get; set; }

        public Carro(string placa, string modelo)
        {
            Placa = placa;
            Modelo = modelo;
        }
    }
}