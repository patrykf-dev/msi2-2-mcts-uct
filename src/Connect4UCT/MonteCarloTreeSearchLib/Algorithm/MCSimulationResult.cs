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

        public MCSimulationResult(GameState state)
        {
            Phase = state.Phase;
            throw new NotImplementedException();
        }

        public float GetReward(int leafPlayer)
        {
            throw new NotImplementedException();
        }
    }
}
