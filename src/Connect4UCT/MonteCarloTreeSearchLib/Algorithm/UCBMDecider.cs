using System;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class UCBMDecider : UCBBaseDecider
    {
        private float _c1;
        private float _c2;

        public UCBMDecider(float c1, float c2)
        {
            _c1 = c1;
            _c2 = c2;
        }

        public MCNode FindBestUCTChildNode(MCNode node, int currentMoving)
        {
            MCNode best = node.Children[0];
            for (int i = 1; i < node.Children.Count; i++)
            {
                if (UCBMValue(best, node.VisitsCount, currentMoving) < UCBMValue(node.Children[i], node.VisitsCount, currentMoving))
                {
                    best = node.Children[i];
                }
            }
            return best;
        }

        private float UCBMValue(MCNode node, int parentVisits, int currentMoving)
        {
            int visits = node.VisitsCount;
            if (visits == 0)
            {
                return 100000f; // won't 2 be enough?
            }
            else
            {
                float prize = (node.GameState.GetCurrentPlayer() == currentMoving) ? node.AveragePrize : -node.AveragePrize;
                float val = prize + (_c1 / (float)Math.Pow((float)visits, _c2));
                return val;
            }
        }
    }
}
