using Tetris.Entities;
using Tetris.Utils;

namespace Tetris.Core
{
    public class GameManager
    {
        private Board _board;
        private Tetromino _currentPiece;

        public GameManager()
        {
            _board = new Board();
            _currentPiece = new Tetromino(TetrominoShape.T); 
        }

        public void Start()
        {
            Console.Clear();
            Console.CursorVisible = false;

            _board.Draw(_currentPiece);
        }
    }
}