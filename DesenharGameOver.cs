    using System;

public partial class Jogo
{
    static void DesenharGameOver()
    {
        LimparTela();
        Console.SetCursorPosition(0, 0);

        int obstaculosDesviados = pontos;

        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("║                               FIM DE JOGO                                ║");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════╣");
        Console.WriteLine("║                                                                          ║");

        Console.WriteLine($"║     Pontuacao final      : {pontos.ToString("000000")}                                        ║");
        Console.WriteLine($"║     Nivel alcancado      : {nivel.ToString("000")}                                           ║");
        Console.WriteLine($"║     Obstaculos desviados : {obstaculosDesviados.ToString("000")}                                           ║");

        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════╣");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("║                  Pressione qualquer tecla para sair...                   ║");
        Console.WriteLine("║                                                                          ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");

        Console.ReadKey(true);
    }
}