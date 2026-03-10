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

        public int GetTileAt(int x, int y)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                return _grid[y, x];
            }
            return 0;
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

        public void LockPiece(Tetromino piece)
        {
            for (int row = 0; row < piece.Shape.GetLength(0); row++)
            {
                for (int col = 0; col < piece.Shape.GetLength(1); col++)
                {
                    if (piece.Shape[row, col] == 1)
                    {
                        int boardX = piece.X + col;
                        int boardY = piece.Y + row;

                        if (boardY >= 0 && boardY < Height && boardX >= 0 && boardX < Width)
                        {
                            _grid[boardY, boardX] = (int)piece.Color;
                        }
                    }
                }
            }
        }

        public int ClearFullLines()
        {
            int linesCleared = 0;

            for (int y = Height - 1; y >= 0; y--)
            {
                bool isFull = true;
                for (int x = 0; x < Width; x++)
                {
                    if (_grid[y, x] == 0) // Se tiver pelo menos um buraco, não está cheia
                    {
                        isFull = false;
                        break;
                    }
                }

                if (isFull)
                {
                    for (int moveY = y; moveY > 0; moveY--)
                    {
                        for (int x = 0; x < Width; x++)
                        {
                            _grid[moveY, x] = _grid[moveY - 1, x];
                        }
                    }

                    for (int x = 0; x < Width; x++)
                    {
                        _grid[0, x] = 0;
                    }

                    linesCleared++;

                    y++;
                }
            }

            return linesCleared;
        }
    }
}