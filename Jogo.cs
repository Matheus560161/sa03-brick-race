using System;
using System.Threading;

class Jogo
{
    static int vidas;
    static int pontos;
    static int nivel;
    static int velocidade;

    static int pistaJogador;
    static int pistaInimigo;
    static int linhaInimigo;

    static Random random = new Random();

    public static void Iniciar()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;

        vidas = 3;
        pontos = 0;
        nivel = 1;
        velocidade = 80;

        pistaJogador = 0;
        pistaInimigo = random.Next(2);
        linhaInimigo = -2;

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

            linhaInimigo++;

            if (pistaInimigo == pistaJogador &&
                linhaInimigo + 2 >= 7 &&
                linhaInimigo <= 9)
            {
                vidas--;

                if (vidas <= 0)
                    jogando = false;

                linhaInimigo = -2;
                pistaInimigo = random.Next(2);
            }

            if (linhaInimigo > 9)
            {
                pontos += 1;
                linhaInimigo = -2;
                pistaInimigo = random.Next(2);
            }

            Thread.Sleep(80);
        }

        Console.CursorVisible = true;
    }

    static void DesenharTela()
    {
        Console.Clear();

        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                           BRICK RACE                                     ║");
        Console.WriteLine("╠══════════════════════════════╦═══════════════════════════════════════════╣");
        Console.WriteLine("║ PISTA                        ║ PAINEL                                    ║");
        Console.WriteLine("║ ┌──────────┬──────────┐      ║ Pontos : " + pontos.ToString("0000") + "                             ║");
        Console.WriteLine("║ │          │          │      ║ Nível  : " + nivel.ToString("00") + "                               ║");
        Console.WriteLine("║ │          │          │      ║ Vidas  : " + vidas + "                                ║");
        Console.WriteLine("║ │          │          │      ║ Veloc. : " + velocidade + " ms                            ║");

        for (int i = 0; i < 10; i++)
        {
            string esq = "       ";
            string dir = "       ";

            if (i == linhaInimigo)
            {
                if (pistaInimigo == 0) esq = "   █   ";
                else dir = "   █   ";
            }
            else if (i == linhaInimigo + 1)
            {
                if (pistaInimigo == 0) esq = "  ███  ";
                else dir = "  ███  ";
            }
            else if (i == linhaInimigo + 2)
            {
                if (pistaInimigo == 0) esq = "   █   ";
                else dir = "   █   ";
            }

            if (i == 7)
            {
                if (pistaJogador == 0) esq = "   █   ";
                else dir = "   █   ";
            }
            else if (i == 8)
            {
                if (pistaJogador == 0) esq = "  ███  ";
                else dir = "  ███  ";
            }
            else if (i == 9)
            {
                if (pistaJogador == 0) esq = "  █ █  ";
                else dir = "  █ █  ";
            }

            Console.WriteLine("║ │" + esq + "   │ " + dir + "  │      ║                                           ║");
        }

        Console.WriteLine("║ └──────────┴──────────┘      ║ CONTROLES                                 ║");
        Console.WriteLine("║                              ║ A ou ← = Esquerda                         ║");
        Console.WriteLine("║                              ║ D ou → = Direita                          ║");
        Console.WriteLine("║                              ║ ESC = Sair                                ║");
        Console.WriteLine("╚══════════════════════════════╩═══════════════════════════════════════════╝");
    }
}