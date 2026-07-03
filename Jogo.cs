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
        velocidade = 250;

        pistaJogador = 0;
        pistaInimigo = random.Next(2);
        linhaInimigo = -2; 

        bool jogando = true;

        while (jogando)
        {
            linhaInimigo++;

            // Verificação de colisão exata
            if (linhaInimigo == 6 && pistaInimigo == pistaJogador)
            {
                vidas--;

                if (vidas <= 0)
                    jogando = false; // Sai do loop se as vidas acabarem

                linhaInimigo = -2; 
                pistaInimigo = random.Next(2);
            }

            // Passou sem bater (Ponto Feito)
            if (linhaInimigo > 9)
            {
                pontos += 10;
                velocidade -= 15;

                if (velocidade < 50) 
                {
                    velocidade = 50; 
                }

                linhaInimigo = -2; 
                pistaInimigo = random.Next(2);
            }

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
                        jogando = false; // Sai do loop se apertar ESC
                        break;
                }
            }

            Thread.Sleep(velocidade); 
        }

        // --- TELA DE GAME OVER ---
        // Quando sai do 'while', o jogo parou. Chamamos a tela de Game Over aqui!
        DesenharGameOver();

        Console.CursorVisible = true;
    }
    

    static void DesenharTela()
    {
        Console.Clear();

        // Cabeçalho Principal
        Console.WriteLine("╔══════════════════════════════╦═══════════════════════════════════════════╗");
        Console.WriteLine("║                              ║ BRICK RACE                                ║");
        Console.WriteLine("╠══════════════════════════════╬═══════════════════════════════════════════╣");
        Console.WriteLine("║ PISTA                        ║ PAINEL                                    ║");
        
        // Topo da pista alinhado com as primeiras variáveis do painel
        Console.WriteLine("║ ┌──────────┬──────────┐      ║ " + ("PONTOS   : " + pontos.ToString("000000")).PadRight(42) + "║");
        Console.WriteLine("║ │          │          │      ║ " + "RECORDE  : 000500".PadRight(42) + "║");
        Console.WriteLine("║ │          │          │      ║ " + ("NIVEL    : " + nivel.ToString("00")).PadRight(42) + "║");
        Console.WriteLine("║ │          │          │      ║ " + ("VIDAS    : " + vidas).PadRight(42) + "║");

        for (int i = 0; i < 10; i++)
        {
            string esq = "          ";
            string dir = "          ";

            // --- LÓGICA DE RENDERIZAÇÃO DO INIMIGO BASEADO NA LINHA ATUAL (i) ---
            // Se a linha atual do mapa bater com o desenho do inimigo:
            if (i == linhaInimigo) // Topo do obstáculo (Ponta)
            {
                if (pistaInimigo == 0) esq = "    █     ";
                else                   dir = "    █     ";
            }
            else if (i == linhaInimigo + 1) // Meio do obstáculo (Corpo largo)
            {
                if (pistaInimigo == 0) esq = "   ███    ";
                else                   dir = "   ███    ";
            }
            else if (i == linhaInimigo + 2) // Base do obstáculo (Ponta de baixo)
            {
                if (pistaInimigo == 0) esq = "    █     ";
                else                   dir = "    █     ";
            }

            // --- CAMADA DO JOGADOR (CARRO) ---
            if (i == 7)
            {
                if (pistaJogador == 0) esq = "    █     ";
                else                   dir = "    █     ";
            }
            else if (i == 8)
            {
                if (pistaJogador == 0) esq = "   ███    ";
                else                   dir = "   ███    ";
            }
            else if (i == 9)
            {
                if (pistaJogador == 0) esq = "   █ █    ";
                else                   dir = "   █ █    ";
            }

            // --- CONTEÚDO DINÂMICO DO PAINEL DA DIREITA ---
            string painelLinha = "";
            switch (i)
            {
                case 0: painelLinha = $"VELOC.   : {velocidade} ms"; break;
                case 1: painelLinha = ""; break;
                case 2: painelLinha = "CONTROLES"; break;
                case 3: painelLinha = "A ou seta esquerda"; break;
                case 4: painelLinha = "D ou seta direita"; break;
                case 5: painelLinha = "ESC = sair"; break;
                case 6: painelLinha = ""; break;
                case 7: painelLinha = "LEGENDA"; break;
                case 8: painelLinha = "CARRO      = jogador"; break;
                case 9: painelLinha = "OBSTACULO = bloqueio"; break;
            }

            string painelFormatado = painelLinha.PadRight(42);
            Console.WriteLine("║ │" + esq + "│" + dir + "│      ║ " + painelFormatado + "║");
        }

        Console.WriteLine("║ └──────────┴──────────┘      ║                                           ║");
        Console.WriteLine("╚══════════════════════════════╩═══════════════════════════════════════════╝");
    }



    static void DesenharGameOver()
    {
        Console.Clear();

        // Caixa centralizada com a mesma largura do cabeçalho do jogo
        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("║                                GAME OVER                                 ║");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════╣");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine($"║                    PONTUACAO TOTAL : {pontos.ToString("000000")} PONTOS                       ║");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("║                     Pressione qualquer tecla para sair...                ║");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");

        // Trava o console para que o jogador veja a pontuação antes do programa fechar
        Console.ReadKey(true);
    }    
}
