namespace Tetris.Core
{
    public class Board
    {
        public const int Width = 10;
        public const int Height = 20;

        private readonly int[,] _grid;

        public Board()
        {
            _grid = new int[Height, Width];
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < Height; y++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("<!");

                for (int x = 0; x < Width; x++)
                {
                    if (_grid[y, x] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" .");
                    }
                    else
                    {
                        Console.Write("[]");
                    }
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("!>");
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("<!====================!>");
            Console.ResetColor();
        }
    }
}