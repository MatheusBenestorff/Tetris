using System;
using Tetris.Core;
using Tetris.Entities;

namespace Tetris.UI
{
    public class ConsoleRenderer
    {
        private const int HUD_START_X = 28;

        public void DrawScreen(Board board, Tetromino currentPiece, int score, int level, int lines)
        {
            DrawBoard(board, currentPiece);
            DrawHUD(score, level, lines);
        }

        private void DrawBoard(Board board, Tetromino currentPiece)
        {
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < Board.Height; y++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("<!");

                for (int x = 0; x < Board.Width; x++)
                {
                    bool drewPiece = false;

                    if (currentPiece != null)
                    {
                        int pieceX = x - currentPiece.X;
                        int pieceY = y - currentPiece.Y;

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
                        int gridValue = board.GetTileAt(x, y);
                        if (gridValue == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(" .");
                        }
                        else
                        {
                            Console.ForegroundColor = (ConsoleColor)gridValue;
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

        private void DrawHUD(int score, int level, int lines)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(HUD_START_X, 2);
            Console.Write("=== TETRIS ===");

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(HUD_START_X, 5);
            Console.Write($"LEVEL: {level:D2}");

            Console.SetCursorPosition(HUD_START_X, 7);
            Console.Write($"SCORE: {score:D6}");

            Console.SetCursorPosition(HUD_START_X, 9);
            Console.Write($"LINES: {lines:D3}");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(HUD_START_X, 13);
            Console.Write("Controlos:");
            Console.SetCursorPosition(HUD_START_X, 14);
            Console.Write("[<] [>] Mover");
            Console.SetCursorPosition(HUD_START_X, 15);
            Console.Write("[ ^ ]   Rodar");
            Console.SetCursorPosition(HUD_START_X, 16);
            Console.Write("[ v ]   Acelerar");

            Console.ResetColor();
        }
    }
}