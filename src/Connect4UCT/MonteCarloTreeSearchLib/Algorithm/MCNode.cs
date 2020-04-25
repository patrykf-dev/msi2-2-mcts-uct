using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class MCNode
    {
        public bool HasChildren => true; // FIX
        public GameState GameState { get; private set; }
        public MCNode Parent { get; private set; }

        private MCNode[] _children;
        private int _visitsCount = 0;
        private float _score = 0;
        private float _averagePrize = 0;

        public MCNode GetRandomChild()
        {
            throw new NotImplementedException();
        }

        public List<IGameMove> GetAllPossibleMoves()
        {
            throw new NotImplementedException();
        }

        public void AddChildByMove(IGameMove move)
        {
            throw new NotImplementedException();
        }

        public void AddReward(float reward)
        {
            _score += reward;
            _averagePrize = _score / _visitsCount;
        }

        public void MarkVisit()
        {
            throw new NotImplementedException();
        }
    }
}
