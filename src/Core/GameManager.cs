using Tetris.Entities;
using Tetris.Utils;
using Tetris.UI;

namespace Tetris.Core
{
    public class GameManager
    {
        private Board _board;
        private Tetromino _currentPiece;
        private bool _isGameOver;

        public GameManager()
        {
            _board = new Board();
            SpawnNewPiece();
        }

        private void SpawnNewPiece()
        {
            Random rand = new Random();
            TetrominoShape randomShape = (TetrominoShape)rand.Next(0, 7); 
            
            _currentPiece = new Tetromino(randomShape);
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
                _board.Draw(_currentPiece);

                // Input
                while (Console.KeyAvailable) 
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if(key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        return;
                    }

                    HandleInput(key);
                }

                // Gravity
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

                        SpawnNewPiece();

                        // Se a peça nova já nascer batendo em algo, a torre chegou no limite do teto
                        if (!_board.IsValidPosition(_currentPiece, _currentPiece.X, _currentPiece.Y))
                        {
                            _isGameOver = true;
                        }
                    }
                }

                // Tick
                Thread.Sleep(50); 
            }
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