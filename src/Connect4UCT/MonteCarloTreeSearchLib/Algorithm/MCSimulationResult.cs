using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class MCSimulationResult
    {
        public GamePhase Phase { get; private set; }
        public float Player1Reward { get; private set; }
        public float Player2Reward { get; private set; }

        public MCSimulationResult(GameState state)
        {
            Phase = state.Phase;
            Player1Reward = state.GetWinScore(1);
            Player2Reward = state.GetWinScore(2);
        }

        public float GetReward(int leafPlayer)
        {
            if (leafPlayer == 1)
            {
                return Player1Reward;
            }
            else
            {
                return Player2Reward;
            }
        }
    }
}
