using System;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class UCBVDecider : UCBBaseDecider
    {
        private float _c;
        private float _zeta;

        public UCBVDecider(float c, float zeta)
        {
            _c = c;
            _zeta = zeta;
        }

        public MCNode FindBestUCTChildNode(MCNode node, int currentMoving)
        {
            MCNode best = node.Children[0];
            for (int i = 1; i < node.Children.Count; i++)
            {
                if (UCBVValue(best, node.VisitsCount, currentMoving) < UCBVValue(node.Children[i], node.VisitsCount, currentMoving))
                {
                    best = node.Children[i];
                }
            }
            return best;
        }

        private float UCBVValue(MCNode node, int parentVisits, int currentMoving)
        {
            int visits = node.VisitsCount;
            if (visits == 0)
            {
                return 100000f; // won't 2 be enough?
            }
            else
            {
                float a = (node.GameState.GetCurrentPlayer() == currentMoving) ? node.AveragePrize : -node.AveragePrize;
                float b = (float)Math.Sqrt(((2 * node.Variance * EpsFunction(parentVisits)) / visits));
                float c = 3f * _c * EpsFunction(parentVisits) / visits;
                return a + b + c;
            }
        }

        private float EpsFunction(int parentVisits)
        {
            return _zeta * (float)Math.Log(parentVisits);
        }
    }
}
