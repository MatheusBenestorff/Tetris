using System;
using Tetris.Utils;

namespace Tetris.Entities
{
    public class Tetromino
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public int[,] Shape { get; private set; }
        
        public ConsoleColor Color { get; private set; }
        public TetrominoShape Type { get; private set; }

        public Tetromino(TetrominoShape type)
        {
            Type = type;
            
            X = 3; 
            Y = 0;

            InitializeShapeAndColor();
        }

        private void InitializeShapeAndColor()
        {
            switch (Type)
            {
                case TetrominoShape.I:
                    Color = ConsoleColor.Cyan;
                    Shape = new int[,]
                    {
                        { 0, 0, 0, 0 },
                        { 1, 1, 1, 1 },
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 }
                    };
                    break;
                case TetrominoShape.J:
                    Color = ConsoleColor.Blue;
                    Shape = new int[,]
                    {
                        { 1, 0, 0 },
                        { 1, 1, 1 },
                        { 0, 0, 0 }
                    };
                    break;
                case TetrominoShape.L:
                    Color = ConsoleColor.DarkYellow; 
                    Shape = new int[,]
                    {
                        { 0, 0, 1 },
                        { 1, 1, 1 },
                        { 0, 0, 0 }
                    };
                    break;
                case TetrominoShape.O:
                    Color = ConsoleColor.Yellow;
                    Shape = new int[,]
                    {
                        { 1, 1 },
                        { 1, 1 }
                    };
                    break;
                case TetrominoShape.S:
                    Color = ConsoleColor.Green;
                    Shape = new int[,]
                    {
                        { 0, 1, 1 },
                        { 1, 1, 0 },
                        { 0, 0, 0 }
                    };
                    break;
                case TetrominoShape.T:
                    Color = ConsoleColor.DarkMagenta;
                    Shape = new int[,]
                    {
                        { 0, 1, 0 },
                        { 1, 1, 1 },
                        { 0, 0, 0 }
                    };
                    break;
                case TetrominoShape.Z:
                    Color = ConsoleColor.Red;
                    Shape = new int[,]
                    {
                        { 1, 1, 0 },
                        { 0, 1, 1 },
                        { 0, 0, 0 }
                    };
                    break;
            }
        }

        public void MoveDown() => Y++;
        public void MoveLeft() => X--;
        public void MoveRight() => X++;

        public void Rotate()
        {
            int size = Shape.GetLength(0); 
            int[,] rotated = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    rotated[col, size - 1 - row] = Shape[row, col];
                }
            }

            Shape = rotated;
        }
    }
}