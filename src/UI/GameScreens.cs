using System;

namespace Tetris.UI
{
    public static class GameScreens
    {
        public static void ShowGameOverScreen(int finalScore, int level, int lines)
        {
            Console.Clear();
            
            int startY = Math.Max(2, (Console.WindowHeight - 20) / 2);

            Console.ForegroundColor = ConsoleColor.Red;
            
            WriteCentered(@" ██████╗  █████╗ ███╗   ███╗███████╗", startY++);
            WriteCentered(@"██╔════╝ ██╔══██╗████╗ ████║██╔════╝", startY++);
            WriteCentered(@"██║  ███╗███████║██╔████╔██║█████╗  ", startY++);
            WriteCentered(@"██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ", startY++);
            WriteCentered(@"╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗", startY++);
            WriteCentered(@" ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝", startY++);
            
            startY++;
            
            WriteCentered(@" ██████╗ ██╗   ██╗███████╗██████╗ ", startY++);
            WriteCentered(@"██╔═══██╗██║   ██║██╔════╝██╔══██╗", startY++);
            WriteCentered(@"██║   ██║██║   ██║█████╗  ██████╔╝", startY++);
            WriteCentered(@"██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗", startY++);
            WriteCentered(@"╚██████╔╝ ╚████╔╝ ███████╗██║  ██║", startY++);
            WriteCentered(@" ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝", startY++);

            startY += 3;

            Console.ForegroundColor = ConsoleColor.White;
            WriteCentered("ESTATÍSTICAS FINAIS", startY++);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            WriteCentered("-------------------", startY++);
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteCentered($"PONTUAÇÃO : {finalScore}", startY++);
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteCentered($"NÍVEL     : {level}", startY++);
            Console.ForegroundColor = ConsoleColor.Green;
            WriteCentered($"LINHAS    : {lines}", startY++);

            startY += 3;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            WriteCentered("Pressione ENTER para voltar ao Menu...", startY++);

            Console.ResetColor();
            
            while (Console.KeyAvailable) Console.ReadKey(true);
            Console.ReadLine(); 
            Console.Clear();
        }

        private static void WriteCentered(string text, int y)
        {
            int centerX = (Console.WindowWidth / 2) - (text.Length / 2);
            if (centerX < 0) centerX = 0; 
            
            Console.SetCursorPosition(centerX, y);
            Console.Write(text);
        }
    }
}