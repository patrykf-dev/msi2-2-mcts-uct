﻿using System;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class UCB1Decider : UCBBaseDecider
    {
        private float _explorationParam;

        public UCB1Decider(float explorationParam)
        {
            _explorationParam = explorationParam;
        }

        public MCNode FindBestUCTChildNode(MCNode node, int currentMoving)
        {
            MCNode best = node.Children[0];
            for (int i = 1; i < node.Children.Count; i++)
            {
                if (UCTValue(best, node.VisitsCount, currentMoving) < UCTValue(node.Children[i], node.VisitsCount, currentMoving))
                {
                    best = node.Children[i];
                }
            }
            return best;
        }

        private float UCTValue(MCNode node, int parentVisits, int currentMoving)
        {
            int visits = node.VisitsCount;
            if (visits == 0)
            {
                return 100000f; // won't 2 be enough?
            }
            else
            {
                float prize = (node.GameState.GetCurrentPlayer() == currentMoving) ? node.AveragePrize : -node.AveragePrize;
                float val = prize + _explorationParam * (float)Math.Sqrt(Math.Log(parentVisits) / (double)visits);
                return val;
            }
        }
    }
}
