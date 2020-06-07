using MonteCarloTreeSearchLib.ConnectFour;
using MonteCarloTreeSearchLib.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var search = new MCTreeSearch(new MCNode(new ConnectFourGameState(board)));
            var abstractMove = search.CalculateNextMove();
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
