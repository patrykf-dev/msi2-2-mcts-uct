using MonteCarloTreeSearchLib.Algorithm;
using MonteCarloTreeSearchLib.ConnectFour;
using System.Drawing;

namespace ConnectFourApplication
{
    public class Game
    {
        public IPlayer Player1 { get; private set; }
        public IPlayer Player2 { get; private set; }
        public IPlayer ActualMoving { get; private set; }
        public IPlayer ActualNotMoving { get; private set; }
        public ConnectFourBoard Board { get; private set; }
        public bool InProgress { get; set; }

        public Game(PlayerType player1, PlayerType player2)
        {
            Player1 = CreatePlayer(player1, 1);
            Player2 = CreatePlayer(player2, 2);
            ActualMoving = Player1;
            ActualNotMoving = Player2;
            Board = new ConnectFourBoard();
            Player1.Color = Color.Yellow;
            Player2.Color = Color.Red;
            InProgress = true;
        }

        public bool MoveIsPossible(int column)
        {
            var possibleColumns = Board.GetFreeHoles();
            return possibleColumns.Contains(column);
        }

        public GamePhase MakeMove(int column)
        {
            var moveResult = Board.PerformMove(column);
            SwitchMovingPlayer();
            return moveResult;
        }

        private IPlayer CreatePlayer(PlayerType type, int index)
        {
            if (type == PlayerType.HUMAN)
                return new HumanPlayer($"HUMAN PLAYER {index}");
            else
                return new ComputerPlayer($"{type} PLAYER {index}", type);
        }

        public void SwitchMovingPlayer()
        {
            IPlayer p = ActualMoving;
            ActualMoving = ActualNotMoving;
            ActualNotMoving = p;
        }

        public int[,] GetBoard()
        {
            return Board.Board;
        }
    }
}
