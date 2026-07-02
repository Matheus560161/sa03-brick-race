using System;
using System.Threading;

class Jogo
{
    static int vidas;
    static int pontos;
    static int nivel;
    static int velocidade;

    // 0 = esquerda | 1 = direita
    static int pistaJogador;

    static Random random = new Random();

    public static void Iniciar()
    {
        vidas = 3;
        pontos = 0;
        nivel = 1;
        velocidade = 300;

        pistaJogador = 0;

        bool jogando = true;

        while (jogando)
        {
            DesenharTela();

            if (Console.KeyAvailable)
            {
                ConsoleKey tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        pistaJogador = 0;
                        break;

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        pistaJogador = 1;
                        break;

                    case ConsoleKey.Escape:
                        jogando = false;
                        break;
                }
            }

            Thread.Sleep(velocidade);
        }
    }

    static void DesenharTela()
    {
        Console.Clear();

        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                           BRICK RACE                                     ║");
        Console.WriteLine("╠══════════════════════════════╦═══════════════════════════════════════════╣");
        Console.WriteLine("║ PISTA                        ║ PAINEL                                    ║");
        Console.WriteLine("║ ┌──────────┬──────────┐      ║ Pontos : " + pontos.ToString("000000") + "                           ║");
        Console.WriteLine("║ │          │          │      ║ Nível  : " + nivel.ToString("00") + "                               ║");
        Console.WriteLine("║ │          │          │      ║ Vidas  : " + vidas + "                                     ║");
        Console.WriteLine("║ │          │          │      ║ Veloc. : " + velocidade + " ms                                      ║");
        Console.WriteLine("║ │          │          │      ║                                       ║");
        Console.WriteLine("║ │          │          │      ║ CONTROLES                                    ║");
        Console.WriteLine("║ │          │          │      ║ A ou ← = Esquerda                                    ║");
        Console.WriteLine("║ │          │          │      ║ D ou → = Direita                          ║");
        Console.WriteLine("║ │          │          │      ║ ESC = Sair                                ║");

        if (pistaJogador == 0)
        {
            Console.WriteLine("║ │   █      │          │      ║                                       ║");
            Console.WriteLine("║ │  ███     │          │      ║                                       ║");
            Console.WriteLine("║ │  █ █     │          │      ║                                       ║");
        }
        else
        {
            Console.WriteLine("║ │          │   █      │      ║                                       ║");
            Console.WriteLine("║ │          │  ███     │      ║                                       ║");
            Console.WriteLine("║ │          │  █ █     │      ║                                       ║");
        }

        Console.WriteLine("║ │          │          │      ║                                           ║");
        Console.WriteLine("║ │          │          │      ║                                           ║");
        Console.WriteLine("║ └──────────┴──────────┘      ║                                           ║");
        Console.WriteLine("╚══════════════════════════════╩═══════════════════════════════════════════╝");
    }
}