using MonteCarloTreeSearchLib.Algorithm;
using MonteCarloTreeSearchLib.ConnectFour;
using System.Drawing;

namespace ConnectFourApplication
{
    public class Game
    {
        public IPlayer Player1 { get; private set; }
        public IPlayer Player2 {get; private set;}

        public IPlayer ActualMoving { get; private set; }
        public IPlayer ActualNotMoving { get; private set; }

        private ConnectFourBoard _board;

        public Game(PlayerType player1, PlayerType player2)
        {
            Player1 = CreatePlayer(player1);
            Player2 = CreatePlayer(player2);
            ActualMoving = Player1;
            ActualNotMoving = Player2;
            _board = new ConnectFourBoard();
            Player1.SetColor(Color.Yellow);
            Player2.SetColor(Color.Red);
        }

        public bool MoveIsPossible(int column)
        {
            var possibleColumns = _board.GetFreeHoles();
            return possibleColumns.Contains(column);
        }

        public GamePhase MakeMove(int column)
        {
            var moveResult = _board.PerformMove(column);
            SwitchMovingPlayer();
            return moveResult;
        }

        private IPlayer CreatePlayer(PlayerType type)
        {
            // TODO
            return new HumanPlayer("ASD");
        }

        public void SwitchMovingPlayer()
        {
            IPlayer p = ActualMoving;
            ActualMoving = ActualNotMoving;
            ActualNotMoving = p;
        }

        public int[,] GetBoard()
        {
            return _board.GetBoard();
        }
    }
}
