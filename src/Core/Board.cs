using Tetris.Entities;

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

        public void Draw(Tetromino currentPiece)
        {
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < Height; y++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("<!");

                for (int x = 0; x < Width; x++)
                {
                    bool drewPiece = false;

                    // Verifica se a coordenada atual (x, y) pertence à peça que está caindo
                    if (currentPiece != null)
                    {
                        // Calcula a posição relativa da coordenada dentro da matriz da peça
                        int pieceX = x - currentPiece.X;
                        int pieceY = y - currentPiece.Y;

                        // Se estiver dentro da caixa da peça e for um bloco preenchido (1)
                        if (pieceX >= 0 && pieceX < currentPiece.Shape.GetLength(1) &&
                            pieceY >= 0 && pieceY < currentPiece.Shape.GetLength(0))
                        {
                            if (currentPiece.Shape[pieceY, pieceX] == 1)
                            {
                                Console.ForegroundColor = currentPiece.Color;
                                Console.Write("[]"); 
                                drewPiece = true;
                            }
                        }
                    }

                    if (!drewPiece)
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
                
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("!>");
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("<!====================!>");
            Console.ResetColor();
        }


        public bool IsValidPosition(Tetromino piece, int targetX, int targetY)
        {
            for (int row = 0; row < piece.Shape.GetLength(0); row++)
            {
                for (int col = 0; col < piece.Shape.GetLength(1); col++)
                {
                    if (piece.Shape[row, col] == 1)
                    {
                        int boardX = targetX + col;
                        int boardY = targetY + row;

                        if (boardX < 0 || boardX >= Width || boardY >= Height)
                        {
                            return false;
                        }

                        if (boardY >= 0 && _grid[boardY, boardX] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}