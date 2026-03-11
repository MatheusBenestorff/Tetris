using System;
using Tetris.Core;
using Tetris.Entities;

namespace Tetris.UI
{
    public class ConsoleRenderer
    {
        private const int HUD_START_X = 28;

        public void DrawScreen(Board board, Tetromino currentPiece, Tetromino nextPiece, int score, int level, int lines)
        {
            DrawBoard(board, currentPiece);
            DrawHUD(score, level, lines, nextPiece); 
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

        private void DrawHUD(int score, int level, int lines, Tetromino nextPiece)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(HUD_START_X, 1);
            Console.Write("=== TETRIS ===");

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(HUD_START_X, 4);
            Console.Write($"LEVEL: {level:D2}");

            Console.SetCursorPosition(HUD_START_X, 6);
            Console.Write($"SCORE: {score:D6}");

            Console.SetCursorPosition(HUD_START_X, 8);
            Console.Write($"LINES: {lines:D3}");

            int nextPieceStartY = 10; 

            DrawNextPiece(nextPiece, nextPieceStartY);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(HUD_START_X, 15);
            Console.Write("Controls:");
            Console.SetCursorPosition(HUD_START_X, 17);
            Console.Write("[<] [>] Move");
            Console.SetCursorPosition(HUD_START_X, 18);
            Console.Write("[ ^ ]   Rotate");
            Console.SetCursorPosition(HUD_START_X, 19);
            Console.Write("[ v ]   Accelerate");
            
            Console.ResetColor();
        }

        private void DrawNextPiece(Tetromino nextPiece, int nextPieceStartY)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(HUD_START_X, nextPieceStartY);
            Console.Write("NEXT PIECE:");

            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(HUD_START_X, nextPieceStartY + 2 + i);
                Console.Write("            "); 
            }

            if (nextPiece != null)
            {
                Console.ForegroundColor = nextPiece.Color;
                
                for (int row = 0; row < nextPiece.Shape.GetLength(0); row++)
                {
                    Console.SetCursorPosition(HUD_START_X, nextPieceStartY + 2 + row);
                    
                    for (int col = 0; col < nextPiece.Shape.GetLength(1); col++)
                    {
                        if (nextPiece.Shape[row, col] == 1)
                        {
                            Console.Write("[]");
                        }
                        else
                        {
                            Console.Write("  "); 
                        }
                    }
                }
            }
        }
    }
}