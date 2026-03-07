namespace Tetris.Core
{
    public class GameManager
    {
        private Board _board;

        public GameManager()
        {
            _board = new Board();
        }

        public void Start()
        {
            Console.Clear();
            Console.CursorVisible = false;

            _board.Draw();
        }
    }
}