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
        public bool HasChildren => _children != null && _children.Count > 0;

        private List<MCNode> _children;
        private float _score = 0;
        private GameState state;

        public MCNode(GameState state)
        {
            this.state = state;
        }

        public MCNode GetRandomChild()
        {
            if (HasChildren == false)
            {
                throw new ArgumentException("This node doesn't have child nodes.");
            }
            else
            {
                int index = RandomUtils.GetRandomInt(0, _children.Count);
                return _children[index];
            }
        }

        public void AddChildByMove(IGameMove move)
        {
            if (_children == null)
            {
                _children = new List<MCNode>();
            }
            var tmpState = GameState.GetDeepCopy();
            tmpState.ApplyMove(move);
            _children.Add(new MCNode(state));
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
            MCNode best = _children[0];
            for (int i = 1; i < _children.Count; i++)
            {
                if (best.UCTValue(expParam, VisitsCount) < _children[i].UCTValue(expParam, VisitsCount))
                {
                    best = _children[i];
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
                return 10000000f; // won't 2 be enough?
            }
            else
            {
                return (winScore / visits) + explorationParameter * (float)Math.Sqrt(Math.Log(parentVisits) / (float)visits);
            }
        }

        public MCNode GetChildWithMaxAveragePrize()
        {
            MCNode best = _children[0];
            for (int i = 1; i < _children.Count; i++)
            {
                if (best.AveragePrize < _children[i].AveragePrize)
                {
                    best = _children[i];
                }
            }
            return best;
        }
    }
}
