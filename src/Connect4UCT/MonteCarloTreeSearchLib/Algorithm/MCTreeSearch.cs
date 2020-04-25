using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class MCTreeSearch
    {
        private MCNode _root;
        private int _iterationCount;
        private int _maxIterations;


        public MCTreeSearch(MCNode root, int maxIterations = 200)
        {
            _root = root;
            _iterationCount = 0;
            _maxIterations = maxIterations;
        }

        public IGameMove CalculateNextMove()
        {
            while (_iterationCount < _maxIterations)
            {
                PerformAlgorithmIteration();
                _iterationCount++;
            }
            return SelectResultNode();
        }

        private void PerformAlgorithmIteration()
        {
            var promisingNode = Selection();
            Expansion(promisingNode);
            MCNode leafToExplore = promisingNode;
            if (promisingNode.HasChildren)
            {
                leafToExplore = leafToExplore.GetRandomChild();
            }
            var simulationResult = Simulation(leafToExplore);
            Backpropagation(leafToExplore, simulationResult);
        }

        /// <summary>
        /// Executes 1st stage of MCTS.
        /// Starts from root R and selects successive child nodes until a leaf node L is reached.
        /// </summary>
        private MCNode Selection()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Executes 2nd stage of MCTS.
        /// Unless L ends the game, creates one(or more) child nodes and chooses node C from one of them.
        /// </summary>
        private void Expansion(MCNode node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Executes 3rd stage of MCTS.
        /// Complete a random playout from node C.
        /// </summary>
        private MCSimulationResult Simulation(MCNode leaf)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Executes 4th stage of MCTS.
        /// Uses the result of the playout to update information in the nodes on the path from C to R.
        /// </summary>
        private void Backpropagation(MCNode leaf, MCSimulationResult simulationResult)
        {
            throw new NotImplementedException();
        }

        private IGameMove SelectResultNode()
        {
            throw new NotImplementedException();
        }
    }
}
