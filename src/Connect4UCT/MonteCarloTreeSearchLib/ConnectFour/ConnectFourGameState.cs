using MonteCarloTreeSearchLib.Algorithm;
using System;
using System.Collections.Generic;

namespace MonteCarloTreeSearchLib.ConnectFour
{
    public class ConnectFourGameState : GameState
    {
        public ConnectFourBoard Board { get; private set; }

        public ConnectFourGameState()
        {
            Board = new ConnectFourBoard();
            Phase = GamePhase.InProgress;
        }

        public ConnectFourGameState(ConnectFourBoard board)
        {
            Board = board;
            Phase = board.Phase;
        }

        public override void ApplyMove(IGameMove move)
        {
            var connectFourMove = move as ConnectFourGameMove; // useless cast...
            Board.PerformMove(connectFourMove.HoleIndex);
            Phase = Board.Phase;
        }

        public override List<IGameMove> GetAllPossibleMoves()
        {
            var moves = new List<IGameMove>();
            foreach (var hole in Board.GetFreeHoles())
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
            Phase = Board.Phase;
            return rc;
        }

        public override int GetCurrentPlayer()
        {
            return PlayerHelpers.GetOpposingPlayer(Board.CurrentPlayer);
        }
    }
}
