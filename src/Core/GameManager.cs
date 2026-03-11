using Tetris.Entities;
using Tetris.Utils;
using Tetris.UI;

namespace Tetris.Core
{
    public class GameManager
    {
        private Board _board;
        private Tetromino _currentPiece;
        private Tetromino _nextPiece;
        private ConsoleRenderer _renderer;

        private bool _isGameOver;

        // HUD
        public int Score { get; private set; }
        public int Level { get; private set; } = 1;
        public int Lines { get; private set; }

        public GameManager()
        {
            _board = new Board();
            _renderer = new ConsoleRenderer();

            _nextPiece = GenerateRandomPiece();

            SpawnNewPiece();
        }

        private Tetromino GenerateRandomPiece()
        {
            Random rand = new Random();
            TetrominoShape randomShape = (TetrominoShape)rand.Next(0, 7); 
            return new Tetromino(randomShape);
        }

        private void SpawnNewPiece()
        {
            _currentPiece = _nextPiece;
            
            _nextPiece = GenerateRandomPiece();
        }

        public void Start()
        {

            Menu menu = new Menu();
            int selectedOption = menu.Show();

            if (selectedOption == 2) return; // Sair

            InitializeGameState(selectedOption);

            Console.Clear();
            Console.CursorVisible = false;
            _isGameOver = false;

            int dropTimer = 0;
            int dropInterval = 10;

            while (!_isGameOver)
            {
                _renderer.DrawScreen(_board, _currentPiece, _nextPiece, Score, Level, Lines);

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        return;
                    }
                    HandleInput(key);
                }

                dropTimer++;
                if (dropTimer >= dropInterval)
                {
                    dropTimer = 0;

                    if (_board.IsValidPosition(_currentPiece, _currentPiece.X, _currentPiece.Y + 1))
                    {
                        _currentPiece.MoveDown();
                    }
                    else
                    {
                        _board.LockPiece(_currentPiece);

                        int linesCleared = _board.ClearFullLines();

                        if (linesCleared > 0)
                        {
                            Lines += linesCleared;

                            if (linesCleared == 1) Score += 100 * Level;
                            else if (linesCleared == 2) Score += 300 * Level;
                            else if (linesCleared == 3) Score += 500 * Level;
                            else if (linesCleared == 4) Score += 800 * Level;

                            Level = (Lines / 10) + 1;

                            dropInterval = Math.Max(2, 10 - (Level - 1));
                        }

                        SpawnNewPiece();

                        if (!_board.IsValidPosition(_currentPiece, _currentPiece.X, _currentPiece.Y))
                        {
                            _isGameOver = true;
                        }
                    }
                }

                Thread.Sleep(50);
            }

            GameScreens.ShowGameOverScreen(Score, Level, Lines);
        }

        private void HandleInput(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (_board.IsValidPosition(_currentPiece, _currentPiece.X - 1, _currentPiece.Y))
                        _currentPiece.MoveLeft();
                    break;

                case ConsoleKey.RightArrow:
                    if (_board.IsValidPosition(_currentPiece, _currentPiece.X + 1, _currentPiece.Y))
                        _currentPiece.MoveRight();
                    break;

                case ConsoleKey.DownArrow:
                    if (_board.IsValidPosition(_currentPiece, _currentPiece.X, _currentPiece.Y + 1))
                        _currentPiece.MoveDown();
                    break;

                case ConsoleKey.UpArrow:
                    // Roda a peça primeiro para testar
                    _currentPiece.Rotate();

                    // Se a nova rotação fizer a peça entrar na parede
                    if (!_board.IsValidPosition(_currentPiece, _currentPiece.X, _currentPiece.Y))
                    {
                        // Desfaz a rotação
                        _currentPiece.Rotate();
                        _currentPiece.Rotate();
                        _currentPiece.Rotate();
                    }
                    break;
            }
        }



        private void InitializeGameState(int selectedOption)
        {

            if (selectedOption == 0) // Novo Jogo
            {

            }
            else if (selectedOption == 1) // Continuar
            {

            }
        }
    }
}