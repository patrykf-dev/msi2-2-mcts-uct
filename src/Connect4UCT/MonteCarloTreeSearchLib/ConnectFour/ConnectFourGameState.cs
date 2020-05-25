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
        }

        public ConnectFourGameState(ConnectFourBoard board)
        {
            _board = board;
        }

        public override void ApplyMove(IGameMove move)
        {
            var connectFourMove = move as ConnectFourGameMove; // useless cast...
            _board.PerformMove(connectFourMove.HoleIndex);
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
            return state;
        }

        public override IGameMove GetGameMoveLeadingTo(GameState gameState)
        {
            ConnectFourGameState connectFourstate = gameState as ConnectFourGameState;
            int differentHole = _board.FindAdditionalHole(connectFourstate._board);
            IGameMove move = new ConnectFourGameMove(differentHole);
            return move;
        }

        public override void PerformRandomMove()
        {
            var holes = _board.GetFreeHoles();
            int randomHole = holes[RandomUtils.GetRandomInt(0, holes.Count)];
            _board.PerformMove(randomHole);
        }

        public override float GetWinScore(int player)
        {
            throw new NotImplementedException();
        }
    }
}
