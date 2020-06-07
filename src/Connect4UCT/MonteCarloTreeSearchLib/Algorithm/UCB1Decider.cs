using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class UCB1Decider : UCTBaseDecider
    {
        private float _explorationParam = 1.41f;

        public MCNode FindBestUCTChildNode(MCNode node, int currentMoving)
        {
            MCNode best = node.Children[0];
            for (int i = 1; i < node.Children.Count; i++)
            {
                if (UCTValue(node, node.VisitsCount, currentMoving) < UCTValue(node, node.VisitsCount, currentMoving))
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
                //float score = (node.GameState.GetCurrentPlayer() == currentMoving) ? node.: -node.Score;
                //float exploitation = score / (float)visits;
                //float exploration = _explorationParam * (float)Math.Sqrt(Math.Log(parentVisits) / (double)visits);
                //return exploitation + exploration;
            }
            return 0f;
        }
    }
}
