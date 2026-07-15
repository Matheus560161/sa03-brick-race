using System;

class TelaMenu
{
    public static void Mostrar()
    {
        int opcao;

        do
        {
            Jogo.LimparTela();

            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║             BRICK RACE - C#                ║");
            Console.WriteLine("║           Corrida em modo texto            ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ 1 - Iniciar jogo                           ║");
            Console.WriteLine("║ 2 - Instruções                             ║");
            Console.WriteLine("║ 3 - Ver último resultado                   ║");
            Console.WriteLine("║ 0 - Sair                                   ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.Write("\nEscolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("\nOpção inválida!");
                Console.ReadKey();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    Jogo.Iniciar();
                    break;

                case 2:
                    MostrarInstrucoes.Exibir();
                    break;

                case 3:
                    MostrarUltimoResultado.Exibir();
                    break;

                case 0:
                    Console.WriteLine("\nObrigado por jogar!");
                    break;

                default:
                    Console.WriteLine("\nOpção inválida!");
                    Console.ReadKey();
                    break;
            }

        } while (opcao != 0);
    }
}