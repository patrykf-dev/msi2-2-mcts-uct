using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class MCNode
    {
        public GameState GameState { get; private set; }
        public MCNode Parent { get; private set; }
        public int VisitsCount { get; private set; } = 0;
        public float AveragePrize { get; private set; } = 0f;
        public List<MCNode> Children { get; private set; }
        public bool HasChildren => Children != null && Children.Count > 0;

        private float _score = 0;

        public MCNode(GameState state)
        {
            GameState = state;
        }

        public MCNode GetRandomChild()
        {
            if (HasChildren == false)
            {
                throw new ArgumentException("This node doesn't have child nodes.");
            }
            else
            {
                int index = RandomUtils.GetRandomInt(0, Children.Count);
                return Children[index];
            }
        }

        public void AddChildByMove(IGameMove move)
        {
            if (Children == null)
            {
                Children = new List<MCNode>();
            }
            var tmpState = GameState.GetDeepCopy();
            tmpState.ApplyMove(move);
            var child = new MCNode(tmpState);
            Children.Add(child);
            child.Parent = this;
        }

        public void AddReward(float reward)
        {
            _score += reward;
            AveragePrize = _score / VisitsCount;
        }

        public void MarkVisit()
        {
            VisitsCount++;
        }

        public MCNode FindBestUCTChildNode(float expParam)
        {
            MCNode best = Children[0];
            for (int i = 1; i < Children.Count; i++)
            {
                if (best.UCTValue(expParam, VisitsCount) < Children[i].UCTValue(expParam, VisitsCount))
                {
                    best = Children[i];
                }
            }
            return best;
        }

        private float UCTValue(float explorationParameter, int parentVisits)
        {
            int visits = VisitsCount;
            float winScore = _score;
            if (visits == 0)
            {
                return 100000f; // won't 2 be enough?
            }
            else
            {
                float val = (winScore / (float)visits) + explorationParameter * (float)Math.Sqrt(Math.Log(parentVisits) / (double)visits);
                return val;
            }
        }

        public MCNode GetChildWithMaxAveragePrize()
        {
            MCNode best = Children[0];
            for (int i = 1; i < Children.Count; i++)
            {
                if (best.AveragePrize < Children[i].AveragePrize)
                {
                    best = Children[i];
                }
            }
            return best;
        }

        public MCNode GetChildWithMaxVisitsCount()
        {
            MCNode best = Children[0];
            for (int i = 1; i < Children.Count; i++)
            {
                if (best.VisitsCount < Children[i].VisitsCount)
                {
                    best = Children[i];
                }
            }
            return best;
        }
    }
}
