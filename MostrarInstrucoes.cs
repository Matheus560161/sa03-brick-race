using System;

class MostrarInstrucoes
{
    public static void Exibir()
    {
        Jogo.LimparTela(); 

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
}