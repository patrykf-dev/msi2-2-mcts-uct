using MonteCarloTreeSearchLib.ConnectFour;
using System;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class AgentDecider
    {
        public UCB1Decider ucb1Decider { get; set; }
        public UCBMDecider ucbmDecider { get; set; }
        public UCBVDecider ucbvDecider { get; set; }
        public int MaxIterations { get; set; } = 16000;

        private AgentStrategy _strategy;

        public AgentDecider(AgentStrategy strategy, UCB1Decider ucb1Decider, UCBMDecider ucbmDecider, UCBVDecider ucbvDecider)
        {
            _strategy = strategy;
            this.ucb1Decider = ucb1Decider;
            this.ucbmDecider = ucbmDecider;
            this.ucbvDecider = ucbvDecider;
        }

        public int PerformDecision(ConnectFourBoard board)
        {
            if(board.TokensPlaced == 0)
            {
                return 3;
            }

            switch (_strategy)
            {
                case AgentStrategy.UCB1:
                    return PerformUCTDecision(board, ucb1Decider);
                case AgentStrategy.UCB_M:
                    return PerformUCTDecision(board, ucbmDecider);
                case AgentStrategy.UCB_V:
                    return PerformUCTDecision(board, ucbvDecider);
                case AgentStrategy.GREEDY:
                    return PerformGreedyDecision(board);
                case AgentStrategy.RANDOM:
                    return PerformRandomDecision(board);
                default:
                    break;
            }
            return 0;
        }

        private int PerformUCTDecision(ConnectFourBoard board, UCBBaseDecider decider)
        {
            var root = new MCNode(new ConnectFourGameState(board));
            var abstractMove = new MCTreeSearch(root, decider, MaxIterations).CalculateNextMove();
            var gameMove = abstractMove as ConnectFourGameMove;
            return gameMove.HoleIndex;
        }

        private int PerformGreedyDecision(ConnectFourBoard board)
        {
            var decider = new GreedyDecider();
            return decider.PerformDecision(board);
        }

        private int PerformRandomDecision(ConnectFourBoard board)
        {
            var holes = board.GetFreeHoles();
            var index = RandomUtils.GetRandomInt(0, holes.Count);
            return holes[index];
        }
    }

    public enum AgentStrategy
    {
        UCB1,
        UCB_M,
        UCB_V,
        GREEDY,
        RANDOM
    }
}
