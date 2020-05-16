﻿using System;
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

        /// <summary>
        /// This method needs to be well optimized - it is run multiple times per algorithm iteration.
        /// </summary>
        public abstract void PerformRandomMove();
        public abstract GameState GetDeepCopy();
        public abstract float GetWinScore(int player);
        public abstract List<IGameMove> GetAllPossibleMoves();
        public abstract void ApplyMove(IGameMove move);
        public abstract IGameMove GetGameMoveLeadingTo(GameState gameState);
    }
}
