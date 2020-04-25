using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public abstract class GameState
    {
        public GamePhase Phase { get; private set; }
        public int CurrentPlayer { get; private set; }

        public abstract GameState GetDeepCopy();

        /// <summary>
        /// This method needs to be well optimized - it is run multiple times per algorithm iteration.
        /// </summary>
        public abstract void PerformRandomMove();
    }
}
