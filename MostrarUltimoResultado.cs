using System;

class MostrarUltimoResultado
{
    public static void Exibir()
    {
        Jogo.LimparTela();

        Console.WriteLine("======= ÚLTIMO RESULTADO =======\n");

        if (Menu.UltimoNivel == 0)
        {
            Console.WriteLine("Nenhuma partida foi jogada.");
        }
        else
        {
            Console.WriteLine($"Pontuação : {Menu.UltimaPontuacao}");
            Console.WriteLine($"Nível     : {Menu.UltimoNivel}");
            Console.WriteLine($"Desvios   : {Menu.UltimosObstaculos}");
        }

        Console.WriteLine("\nPressione qualquer tecla...");
        Console.ReadKey();
    }
}
