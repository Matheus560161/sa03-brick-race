using System;

class Menu
{
    public static int UltimaPontuacao = 0;
    public static int UltimoNivel = 0;
    public static int UltimosObstaculos = 0;

    public static void ExibirMenu()
    {
        int opcao;

        do
        {
            Console.Clear();

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
                    MostrarInstrucoes();
                    break;

                case 3:
                    MostrarUltimoResultado();
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

    static void MostrarInstrucoes()
    {
        Console.Clear();

        Console.WriteLine("========== INSTRUÇÕES ==========\n");

        Console.WriteLine("OBJETIVO:");
        Console.WriteLine("Desvie dos obstáculos trocando entre");
        Console.WriteLine("a pista esquerda e a pista direita.\n");

        Console.WriteLine("CONTROLES:");
        Console.WriteLine("A ou ← = Esquerda");
        Console.WriteLine("D ou → = Direita");
        Console.WriteLine("ESC = Sair da partida\n");

        Console.WriteLine("REGRAS:");
        Console.WriteLine("- Você começa com 3 vidas.");
        Console.WriteLine("- Cada obstáculo desviado vale pontos.");
        Console.WriteLine("- Ao bater perde 1 vida.");
        Console.WriteLine("- Quando as vidas acabam o jogo termina.");

        Console.WriteLine("\nPressione qualquer tecla...");
        Console.ReadKey();
    }

    static void MostrarUltimoResultado()
    {
        Console.Clear();

        Console.WriteLine("======= ÚLTIMO RESULTADO =======\n");

        if (UltimoNivel == 0)
        {
            Console.WriteLine("Nenhuma partida foi jogada.");
        }
        else
        {
            Console.WriteLine($"Pontuação : {UltimaPontuacao}");
            Console.WriteLine($"Nível     : {UltimoNivel}");
            Console.WriteLine($"Desvios   : {UltimosObstaculos}");
        }

        Console.WriteLine("\nPressione qualquer tecla...");
        Console.ReadKey();
    }
}