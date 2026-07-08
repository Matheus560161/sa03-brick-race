using System;
using System.IO;

public partial class Jogo
{
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
}