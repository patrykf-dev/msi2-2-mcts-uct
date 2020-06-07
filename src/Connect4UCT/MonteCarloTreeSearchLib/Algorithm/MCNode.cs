using System;
using System.Collections.Generic;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class MCNode
    {
        public GameState GameState { get; private set; }
        public MCNode Parent { get; private set; }
        public int VisitsCount { get; private set; } = 0;
        public float AveragePrize { get; private set; } = 0f;
        public List<MCNode> Children { get; private set; }
        public float Score { get; private set; }
        public float Variance => _varianceCalculator.Value;
        public bool HasChildren => Children != null && Children.Count > 0;

        private VarianceCalculator _varianceCalculator;

        public MCNode(GameState state)
        {
            GameState = state;
            _varianceCalculator = new VarianceCalculator();
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
            Score += reward;
            AveragePrize = Score / VisitsCount;
            _varianceCalculator.AddValue(reward);
        }

        public void MarkVisit()
        {
            VisitsCount++;
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
    }
}
