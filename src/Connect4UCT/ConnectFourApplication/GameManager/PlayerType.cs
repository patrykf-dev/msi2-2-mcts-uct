using MonteCarloTreeSearchLib.Algorithm;
using System;

namespace ConnectFourApplication
{
    public enum PlayerType
    {
        HUMAN,
        GREEDY,
        UCB1,
        UCB_M,
        UCB_V,
        RANDOM
    }

    public static class PlayerTypeExtensions
    {
        /// <summary>
        /// This function needs to cast enum representing nearly same values 
        /// between two projects in order to avoid circular dependency
        /// </summary>
        public static AgentStrategy GetAgentStrategy(this PlayerType type)
        {
            if (type == PlayerType.UCB1)
                return AgentStrategy.UCB1;
            else if (type == PlayerType.UCB_M)
                return AgentStrategy.UCB_M;
            else if (type == PlayerType.UCB_V)
                return AgentStrategy.UCB_V;
            else if (type == PlayerType.GREEDY)
                return AgentStrategy.GREEDY;
            else if (type == PlayerType.RANDOM)
                return AgentStrategy.RANDOM;
            else
                throw new ArgumentException("Incorrect type passed");
        }

        public static PlayerType GetPlayerType(int index)
        {
            switch (index)
            {
                case 0:
                    return PlayerType.HUMAN;
                case 1:
                    return PlayerType.GREEDY;
                case 2:
                    return PlayerType.UCB1;
                case 3:
                    return PlayerType.UCB_M;
                case 4:
                    return PlayerType.UCB_V;
                case 5:
                    return PlayerType.RANDOM;
                default:
                    return PlayerType.HUMAN;
            }
        }
    }
}
