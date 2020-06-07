using MonteCarloTreeSearchLib.ConnectFour;
using System;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class AgentDecider
    {
        private AgentStrategy _strategy;

        public AgentDecider(AgentStrategy strategy)
        {
            _strategy = strategy;
        }

        public int PerformDecision(ConnectFourBoard board)
        {
            switch (_strategy)
            {
                case AgentStrategy.UCB1:
                    return PerformUCTDecision(board, new UCB1Decider(1.41f));
                case AgentStrategy.UCB_M:
                    return PerformUCTDecision(board, new UCBMDecider(8.4f, 1.8f));
                case AgentStrategy.UCB_V:
                    return PerformUCTDecision(board, new UCBVDecider(1.68f, 0.54f));
                case AgentStrategy.GREEDY:
                    break;
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
