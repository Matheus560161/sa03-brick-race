using System;
using System.IO;
using System.Threading;

partial class Jogo
{
    static int vidas;
    static int pontos;
    static int nivel;
    static int velocidade;

    const int ALTURA_PISTA = 20;
    const int LINHA_JOGADOR = ALTURA_PISTA - 3;
    const int MIN_SEPARACAO_INIMIGOS = 8;

    static int pistaJogador;
    static int[] pistasInimigos = new int[3];
    static int[] linhasInimigos = new int[3];

    static Random random = new Random();

    public static void LimparTela()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', Console.WindowWidth * Console.WindowHeight));
            Console.SetCursorPosition(0, 0);
        }
    }

    public static void Iniciar()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;

        vidas = 3;
        pontos = 0;
        nivel = 1;
        velocidade = 120;

        pistaJogador = 0;
        for (int i = 0; i < 3; i++)
        {
            pistasInimigos[i] = random.Next(2);
            linhasInimigos[i] = -3 - (i * MIN_SEPARACAO_INIMIGOS);
        }

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

            for (int i = 0; i < 3; i++)
            {
                linhasInimigos[i]++;

                if (pistasInimigos[i] == pistaJogador &&
                    linhasInimigos[i] + 2 >= LINHA_JOGADOR &&
                    linhasInimigos[i] <= LINHA_JOGADOR + 2)
                {
                    vidas--;
                    if (vidas <= 0)
                    {
                        jogando = false;
                        break;
                    }

                    int menorLinha = int.MaxValue;
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == i) continue;
                        menorLinha = Math.Min(menorLinha, linhasInimigos[j]);
                    }
                    linhasInimigos[i] = Math.Min(-3, menorLinha - MIN_SEPARACAO_INIMIGOS);
                    pistasInimigos[i] = random.Next(2);
                }
                else if (linhasInimigos[i] > ALTURA_PISTA - 1)
                {
                    pontos += 1;
                    int menorLinha = int.MaxValue;
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == i) continue;
                        menorLinha = Math.Min(menorLinha, linhasInimigos[j]);
                    }
                    linhasInimigos[i] = Math.Min(-3, menorLinha - MIN_SEPARACAO_INIMIGOS);
                    pistasInimigos[i] = random.Next(2);
                }
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

    public static void DesenharTela2()
    {
        LimparTela();
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                           BRICK RACE                                     ║");
        Console.WriteLine("╠══════════════════════════════╦═══════════════════════════════════════════╣");
        Console.WriteLine("║ PISTA                        ║ PAINEL                                    ║");
        Console.WriteLine("║ ┌──────────┬──────────┐      ║                                           ║");

        for (int i = 0; i < ALTURA_PISTA; i++)
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
            {
                string velocidadeTexto = velocidade.ToString().PadLeft(3);
                painel = "║ Veloc. : " + velocidadeTexto + " ms                           ║";
            }

            for (int j = 0; j < 3; j++)
            {
                if (i == linhasInimigos[j])
                {
                    if (pistasInimigos[j] == 0) esq = "   █   ";
                    else dir = "   █   ";
                }
                else if (i == linhasInimigos[j] + 1)
                {
                    if (pistasInimigos[j] == 0) esq = "  ███  ";
                    else dir = "  ███  ";
                }
                else if (i == linhasInimigos[j] + 2)
                {
                    if (pistasInimigos[j] == 0) esq = "   █   ";
                    else dir = "   █   ";
                }
            }

            if (i == LINHA_JOGADOR)
            {
                if (pistaJogador == 0) esq = "   █   ";
                else dir = "   █   ";
            }
            else if (i == LINHA_JOGADOR + 1)
            {
                if (pistaJogador == 0) esq = "  ███  ";
                else dir = "  ███  ";
            }
            else if (i == LINHA_JOGADOR + 2)
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
        LimparTela();
        Console.SetCursorPosition(0, 0);

        // Variável com a quantidade de obstáculos (no seu jogo, 1 ponto = 1 obstáculo desviado)
        int obstaculosDesviados = pontos; 

        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("║                               FIM DE JOGO                                ║");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════╣");
        Console.WriteLine("║                                                                          ║");
        
        // O segredo aqui é usar interpolação e formatação para manter os espaços fixos
        Console.WriteLine($"║     Pontuacao final      : {pontos.ToString("000000")}                                        ║");
        Console.WriteLine($"║     Nivel alcancado      : {nivel.ToString("00")}                                            ║");
        Console.WriteLine($"║     Obstaculos desviados : {obstaculosDesviados.ToString("00")}                                            ║");
        
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════╣");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("║                  Pressione qualquer tecla para sair...                   ║");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");

        Console.ReadKey(true);
    }
}
