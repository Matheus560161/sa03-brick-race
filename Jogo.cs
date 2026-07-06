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
        velocidade = 120;

        pistaJogador = 0;
        pistaInimigo = random.Next(2);
        linhaInimigo = -3;

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
                linhaInimigo + 2 >= 10 &&
                linhaInimigo <= 12)
            {
                vidas--;

                if (vidas <= 0)
                    jogando = false;

                linhaInimigo = -3;
                pistaInimigo = random.Next(2);
            }

          
            if (linhaInimigo > 13)
            {
                pontos += 1;
                linhaInimigo = -3;
                pistaInimigo = random.Next(2);
            }

           
            nivel = (pontos / 10) + 1;

            
            int passosDeVelocidade = pontos / 5; 
            velocidade = 120 - (passosDeVelocidade * 10);
            if (velocidade < 40)
                velocidade = 40;

            Thread.Sleep(velocidade);
        }

        Menu.UltimaPontuacao = pontos;
        Menu.UltimoNivel = nivel;
        Menu.UltimosObstaculos = pontos;

        Console.CursorVisible = true;

        DesenharGameOver();
    }

    static void DesenharTela()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                           BRICK RACE                                     ║");
        Console.WriteLine("╠══════════════════════════════╦═══════════════════════════════════════════╣");
        Console.WriteLine("║ PISTA                        ║ PAINEL                                    ║");
        Console.WriteLine("║ ┌──────────┬──────────┐      ║ Pontos : " + pontos.ToString("0000") + "                             ║");

        for (int i = 0; i < 14; i++)
        {
            string esq = "       ";
            string dir = "       ";
            string painel = "║                                           ║";

            if (i == 0)
                painel = "║ Pontos : " + pontos.ToString("0000") + "                             ║";
            else if (i == 1)
                painel = "║ Nível  : " + nivel.ToString("00") + "                               ║";
            else if (i == 2)
                painel = "║ Vidas  : " + vidas + "                                ║";
            else if (i == 3)
                painel = "║ Veloc. : " + velocidade + " ms                            ║";

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

            if (i == 10)
            {
                if (pistaJogador == 0) esq = "   █   ";
                else dir = "   █   ";
            }
            else if (i == 11)
            {
                if (pistaJogador == 0) esq = "  ███  ";
                else dir = "  ███  ";
            }
            else if (i == 12)
            {
                if (pistaJogador == 0) esq = "  █ █  ";
                else dir = "  █ █  ";
            }

            Console.WriteLine("║ │" + esq + "   │ " + dir + "  │      " + painel);
        }

        Console.WriteLine("║ └──────────┴──────────┘      ║ CONTROLES                                 ║");
        Console.WriteLine("║                              ║ A ou ← = Esquerda                         ║");
        Console.WriteLine("║                              ║ D ou → = Direita                          ║");
        Console.WriteLine("║                              ║ ESC = Sair                                ║");
        Console.WriteLine("╚══════════════════════════════╩═══════════════════════════════════════════╝");
    }


    static void DesenharGameOver()
    {
        Console.Clear();

        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("║                                GAME OVER                                 ║");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════╣");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine($"║                    PONTUACAO TOTAL : {pontos.ToString("000")} PONTOS                         ║");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("║                     Pressione qualquer tecla para sair...                ║");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");

        Console.ReadKey(true);
    }
}
