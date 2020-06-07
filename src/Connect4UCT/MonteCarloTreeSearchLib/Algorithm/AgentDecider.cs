using MonteCarloTreeSearchLib.ConnectFour;
using System;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class AgentDecider
    {
        private AgentStrategy _strategy;
        private UCB1Decider _ucb1Decider;
        private UCBMDecider _ucbmDecider;
        private UCBVDecider _ucbvDecider;

        public AgentDecider(AgentStrategy strategy, UCB1Decider ucb1Decider, UCBMDecider ucbmDecider, UCBVDecider ucbvDecider)
        {
            _strategy = strategy;
            _ucb1Decider = ucb1Decider;
            _ucbmDecider = ucbmDecider;
            _ucbvDecider = ucbvDecider;
        }

        public int PerformDecision(ConnectFourBoard board)
        {
            switch (_strategy)
            {
                case AgentStrategy.UCB1:
                    return PerformUCTDecision(board, _ucb1Decider);
                case AgentStrategy.UCB_M:
                    return PerformUCTDecision(board, _ucbmDecider);
                case AgentStrategy.UCB_V:
                    return PerformUCTDecision(board, _ucbvDecider);
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
            var abstractMove = new MCTreeSearch(root, decider).CalculateNextMove();
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
