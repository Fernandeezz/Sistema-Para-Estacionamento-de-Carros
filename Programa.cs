using SistemaEstacionamento;

// sistema para estacionamento
//      adicionar veiculo
//      remover veiculo e dar o preço 
//      listar veículos estacionados
//valor que vai determinar as ações do programa
int entrada3 = 0; 

Console.WriteLine("Bem vindo ao sistema de estacionamento!");
Console.WriteLine("Digite o preço inicial: "); 

//preço cobrado só por estacionar armazenado como int em entradaPreco
string inputPreco = Console.ReadLine();

//conversão segura com TryParse, vai ter uma dessa para todos valores entrados pelo usuário
bool convert1 = int.TryParse(inputPreco, out int entradaPreco);

if (convert1) 
{
    //preço por hora armazenado como int em entradaPrecoHoras;
    Console.WriteLine("Agora digite o preço por hora: ");  
    string inputPrecoHora = Console.ReadLine();
    bool convert2 = int.TryParse(inputPrecoHora, out int entradaPrecoHoras);
    if (convert2)
    {
        Console.Clear();
        //criar um estacionamento com as caracteristicas inputadas pelo usuário(preco e preco por hora)
        Estacionamento estacionamento = new Estacionamento(entradaPreco, entradaPrecoHoras);
        
        //a interação ciclica do programa com o usuário
        while (entrada3 != 4)
        {
                Console.WriteLine("Digite a sua opção: \n1 - Cadastrar veículo\n2 - Remover veículo\n3 - Listar veículos\n4 - Encerrar");
                string input3 = Console.ReadLine();
                bool convert3 = int.TryParse(input3, out entrada3);
                
                if (convert3)
                {
                    if (entrada3 == 1)
                    {
                        Console.WriteLine("Digite a placa do veículo para estacionar:  (XXX-0000)");
                        string placaVeiculo = Console.ReadLine();
                        
                        //criar um novo Veículo e atribuir a sua propriedade Placa com a string inputada pelo usuário
                        Veículos carro1 = new Veículos();
                        carro1.Placa = placaVeiculo;
                        
                        //adicionar o carro criado na lista de carros do estacionamento
                        estacionamento.listaVeiculos.Add(carro1);
                        
                        Console.WriteLine("Pressione uma tecla para continuar");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (entrada3 == 2)
                    {
                        Console.WriteLine("Digite a placa do veículo para remover: (XXX-0000)");
                        string placaVeiculo = Console.ReadLine();
                        
                        //chama o Método VeiculoEstacionado da classe Estacionamento, cuja saida é bool. 
                        //Vai checar se a placa inputada se encontra na lista de carros do estacionamento
                        if (estacionamento.VeiculoEstacionado(placaVeiculo))
                        {
                            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                            string horasEstacionado = Console.ReadLine();
                            bool convert4 = int.TryParse(horasEstacionado, out int horas);

                            if (convert4)
                            {
                                int preco = (horas * entradaPrecoHoras) + entradaPreco;
                                Console.Clear();
                                Console.WriteLine($"O veículo {placaVeiculo} foi removido e o preço total foi de: R$ {preco}\n");
                            }
                            else
                            {
                                Console.WriteLine("Por favor digite um número válido!");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"O veículo {placaVeiculo} não está no estacionamento!");
                        }
                    }
                    else if (entrada3 == 3)
                    {
                        //Foreach para verificar todos os Veículos na lista de carros do estacionamento
                        Console.WriteLine("Os veículos estacionados são: ");
                        foreach (Veículos v in estacionamento.listaVeiculos)
                        {
                            Console.WriteLine(v.Placa);
                        }
                        Console.WriteLine("Pressione uma tecla para continuar\n");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Digite um número válido entre 1 e 4!");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor digite um número válido!");
                }
        }
    }
    else
    {
        Console.WriteLine("Por favor digite um número válido!");
    }
}
else
{
    Console.WriteLine("Por favor digite um número válido!");
}
