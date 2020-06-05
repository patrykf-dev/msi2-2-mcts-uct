using MonteCarloTreeSearchLib.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.ConnectFour
{
    public class ConnectFourGameState : GameState
    {
        public ConnectFourBoard Board { get; private set; }

        public ConnectFourGameState()
        {
            Board = new ConnectFourBoard();
            CurrentPlayer = 1;
            Phase = GamePhase.InProgress;
        }

        public ConnectFourGameState(ConnectFourBoard board)
        {
            Board = board;
            CurrentPlayer = 1;
            Phase = board.Phase;
        }

        public override void ApplyMove(IGameMove move)
        {
            var connectFourMove = move as ConnectFourGameMove; // useless cast...
            Board.PerformMove(connectFourMove.HoleIndex);
            CurrentPlayer = Board.CurrentPlayer;
            Phase = Board.Phase;
        }

        public override List<IGameMove> GetAllPossibleMoves()
        {
            var moves = new List<IGameMove>();
            var freeHoles = Board.GetFreeHoles();
            foreach (var hole in freeHoles)
            {
                moves.Add(new ConnectFourGameMove(hole));
            }
            return moves;
        }

        public override GameState GetDeepCopy()
        {
            ConnectFourGameState state = new ConnectFourGameState();
            state.Board = Board.GetDeepCopy();
            state.Phase = Board.Phase;
            state.CurrentPlayer = Board.CurrentPlayer;
            return state;
        }

        public override IGameMove GetGameMoveLeadingTo(GameState gameState)
        {
            ConnectFourGameState connectFourstate = gameState as ConnectFourGameState;
            int differentHole = Board.FindAdditionalHole(connectFourstate.Board);
            IGameMove move = new ConnectFourGameMove(differentHole);
            return move;
        }

        public override GamePhase PerformRandomMove()
        {
            var holes = Board.GetFreeHoles();
            int randomHole = holes[RandomUtils.GetRandomInt(0, holes.Count)];
            var rc = Board.PerformMove(randomHole);
            CurrentPlayer = Board.CurrentPlayer;
            Phase = Board.Phase;
            return rc;
        }
    }
}
