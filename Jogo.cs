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

                    if (pontos > Menu.UltimaPontuacao)
                    {
                        Menu.UltimaPontuacao = pontos;
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
            }

            nivel = (pontos / 10) + 1;

            int passosDeVelocidade = pontos / 10;
            if (passosDeVelocidade <= 8)
            {
                velocidade = 120 - (passosDeVelocidade * 10);   
            }
            else
            {
                int passosExtras = passosDeVelocidade - 8;
                velocidade = 40 - (passosExtras * 2);
                if (velocidade < 10)
                    velocidade = 10;
            }

            Thread.Sleep(velocidade);
        }

        if (pontos > Menu.UltimaPontuacao)
        {
            Menu.UltimaPontuacao = pontos;
        }

        Menu.UltimoNivel = nivel;
        Menu.UltimosObstaculos = pontos;
        Menu.UltimaVelocidade = velocidade;

        Console.CursorVisible = true;

        DesenharGameOver();
    }
}