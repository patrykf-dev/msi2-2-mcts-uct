using MonteCarloTreeSearchLib.ConnectFour;
using MonteCarloTreeSearchLib.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class UCTDecider
    {
        private UCTVariant _variant;

        public UCTDecider(UCTVariant variant)
        {
            _variant = variant;
        }

        public int PerformDecision(ConnectFourBoard board)
        {
            var state = new ConnectFourGameState(board);
            var root = new MCNode(state);
            var search = new MCTreeSearch(root);
            var abstractMove = search.CalculateNextMove();
            var gameMove = abstractMove as ConnectFourGameMove;
            //CsvSerializer.SaveTree(root, $"tree_newest.csv");
            return gameMove.HoleIndex;
        }
    }

    public enum UCTVariant
    {
        UCB1,
        UCB_M,
        UCB_V,
    }
}
