
public partial class Jogo
{
    public static void DesenharTela()
    {
        
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
}