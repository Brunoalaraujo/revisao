using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using EstacionamentoConsole.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

string precoInicial = "";
string precoPorHora = "";
bool exibirMenu = true;
EstacionamentoServico servico = EstacionamentoServico.GetInstance();

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento estacionamento = CriarEstacionamento();

// Função Recursirva
Estacionamento CriarEstacionamento()
{
    Console.WriteLine("Digite o preço inicial:");
    precoInicial = Console.ReadLine();

    Console.WriteLine("Agora digite o preço por hora:");
    precoPorHora = Console.ReadLine();

    if (precoInicial.Contains(",") || precoPorHora.Contains(","))
    {
        Console.Clear();
        Console.WriteLine("Valor inserido inválido. Exemplo: 0.00");
        return CriarEstacionamento();
    }

    return new Estacionamento(decimal.Parse(precoInicial), decimal.Parse(precoPorHora));
}

void CriarCarro()
{
    Console.WriteLine("Digite a Placa do carro:");
    string placa = Console.ReadLine().ToUpper();

    Console.WriteLine("Digite o modelo do carro:");
    string modelo = Console.ReadLine().ToUpper();

    Carro carro = new Carro(placa.ToUpper(), modelo.ToUpper());

    if (servico.AdicionarCarro(estacionamento, carro))
    {
        Console.WriteLine("Carro cadastrado com sucesso!");
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Carro inválido!");
        Console.WriteLine("Placa incorreta ou veiculo ja cadastrado");
    }
}

void SaidaDeCarro()
{
    Console.WriteLine("Digite a Placa do carro:");
    string placa = Console.ReadLine().ToUpper();

    Console.WriteLine("Digite a quantidade de horas: Exemplo: 1.30");
    string quantidadeHoras = Console.ReadLine().ToUpper();

    if (servico.RemoverCarro(placa, estacionamento))
    {
        Console.WriteLine($"Carro removido com Sucesso. Valor à pagar {servico.ValorAPagar(decimal.Parse(quantidadeHoras), estacionamento):C}");
    }
    else
    {
        Console.WriteLine($"A placa {placa} não foi encontrada");
    }

}

void ListarVeiculos()
{
    if (estacionamento.Carros.Any())
    {
        Console.WriteLine("Os veículos estacionados são:");

        // Realizar um laço de repetição, exibindo os veículos estacionados
        foreach (Carro carro in estacionamento.Carros)
        {
            Console.WriteLine("Carro: " + carro.Placa + " - " + "Modelo: " + carro.Modelo);
        }
    }
    else
    {
        Console.WriteLine("Não há veículos estacionados.");
    }
}
// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            CriarCarro();
            break;

        case "2":
            SaidaDeCarro();
            break;

        case "3":
            ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
