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
        private ConnectFourBoard _board;

        public ConnectFourGameState()
        {
            _board = new ConnectFourBoard();
            CurrentPlayer = 1;
            Phase = GamePhase.InProgress;
        }

        public ConnectFourGameState(ConnectFourBoard board)
        {
            _board = board;
            CurrentPlayer = 1;
            Phase = board.Phase;
        }

        public override void ApplyMove(IGameMove move)
        {
            var connectFourMove = move as ConnectFourGameMove; // useless cast...
            _board.PerformMove(connectFourMove.HoleIndex);
            CurrentPlayer = _board.CurrentPlayer;
            Phase = _board.Phase;
        }

        public override List<IGameMove> GetAllPossibleMoves()
        {
            var moves = new List<IGameMove>();
            var freeHoles = _board.GetFreeHoles();
            foreach (var hole in freeHoles)
            {
                moves.Add(new ConnectFourGameMove(hole));
            }
            return moves;
        }

        public override GameState GetDeepCopy()
        {
            ConnectFourGameState state = new ConnectFourGameState();
            state._board = _board.GetDeepCopy();
            state.Phase = _board.Phase;
            state.CurrentPlayer = _board.CurrentPlayer;
            return state;
        }

        public override IGameMove GetGameMoveLeadingTo(GameState gameState)
        {
            ConnectFourGameState connectFourstate = gameState as ConnectFourGameState;
            int differentHole = _board.FindAdditionalHole(connectFourstate._board);
            IGameMove move = new ConnectFourGameMove(differentHole);
            return move;
        }

        public override GamePhase PerformRandomMove()
        {
            var holes = _board.GetFreeHoles();
            int randomHole = holes[RandomUtils.GetRandomInt(0, holes.Count)];
            var rc = _board.PerformMove(randomHole);
            CurrentPlayer = _board.CurrentPlayer;
            Phase = _board.Phase;
            return rc;
        }

        public override float GetWinScore(int player)
        {
            // TODO
            return 0.5f;
        }
    }
}
