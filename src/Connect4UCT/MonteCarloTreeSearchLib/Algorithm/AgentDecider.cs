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
                    return PerformUCB1Decision(board);
                case AgentStrategy.UCB_M:
                    return PerformUCBMDecision(board);
                case AgentStrategy.UCB_V:
                    return PerformUCBVDecision(board);
                case AgentStrategy.GREEDY:
                    break;
                case AgentStrategy.RANDOM:
                    break;
                default:
                    break;
            }
            return 0;
        }

        private int PerformUCB1Decision(ConnectFourBoard board)
        {
            var root = new MCNode(new ConnectFourGameState(board));
            var decider = new UCB1Decider(1.41f);
            var abstractMove = new MCTreeSearch(root, decider).CalculateNextMove();
            var gameMove = abstractMove as ConnectFourGameMove;
            return gameMove.HoleIndex;
        }

        private int PerformUCBMDecision(ConnectFourBoard board)
        {
            var root = new MCNode(new ConnectFourGameState(board));
            var decider = new UCBMDecider(8.4f, 1.8f);
            var abstractMove = new MCTreeSearch(root, decider).CalculateNextMove();
            var gameMove = abstractMove as ConnectFourGameMove;
            return gameMove.HoleIndex;
        }

        private int PerformUCBVDecision(ConnectFourBoard board)
        {
            var root = new MCNode(new ConnectFourGameState(board));
            var decider = new UCBVDecider(1.68f, 0.54f);
            var abstractMove = new MCTreeSearch(root, decider).CalculateNextMove();
            var gameMove = abstractMove as ConnectFourGameMove;
            return gameMove.HoleIndex;
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
