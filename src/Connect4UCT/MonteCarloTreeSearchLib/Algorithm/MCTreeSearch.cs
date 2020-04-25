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

        private readonly float WIN_REWARD = 1f;
        private readonly float DRAW_REWARD = 0.5f;
        private readonly float LOSE_REWARD = 0f;

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
            return ExtractResultMove();
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
        /// Starts from root R and selects successive child nodes (based on UCB formula in our case) until a leaf node L is reached.
        /// </summary>
        private MCNode Selection()
        {
            var tmpNode = _root;
            while(tmpNode.HasChildren)
            {
                tmpNode = FindBestChildNode(tmpNode);
            }
            return tmpNode;
        }

        /// <summary>
        /// Executes 2nd stage of MCTS.
        /// Unless L ends the game, creates one(or more) child nodes and chooses node C from one of them.
        /// </summary>
        private void Expansion(MCNode node)
        {
            var possibleMoves = node.GetAllPossibleMoves();
            foreach (var move in possibleMoves)
            {
                node.AddChildByMove(move);
            }
        }

        /// <summary>
        /// Executes 3rd stage of MCTS.
        /// Complete a random playout from node C.
        /// </summary>
        private MCSimulationResult Simulation(MCNode leaf)
        {
            var tmpState = leaf.GameState.GetDeepCopy();
            var tmpPhase = leaf.GameState.Phase;

            while(tmpPhase == GamePhase.InProgress)
            {
                tmpState.PerformRandomMove();
                tmpPhase = tmpState.Phase;
            }
            return new MCSimulationResult(tmpState);
        }

        /// <summary>
        /// Executes 4th stage of MCTS.
        /// Uses the result of the playout to update information in the nodes on the path from C to R.
        /// </summary>
        private void Backpropagation(MCNode leaf, MCSimulationResult simulationResult)
        {
            int leafPlayer = leaf.GameState.CurrentPlayer;
            float reward = CalculateReward(simulationResult, leafPlayer);
            var tmpNode = leaf;
            while (tmpNode != _root)
            {
                tmpNode.MarkVisit();
                if (tmpNode.GameState.CurrentPlayer == leafPlayer)
                {
                    tmpNode.AddReward(reward);
                }
                tmpNode = tmpNode.Parent;
            }
            _root.MarkVisit();
        }

        private float CalculateReward(MCSimulationResult simulationResult, int leafPlayer)
        {
            float reward = LOSE_REWARD;
            if (simulationResult.Phase == GamePhaseMethods.GetPhaseOnPlayerWin(leafPlayer))
            {
                reward = WIN_REWARD;
            }
            else if (simulationResult.Phase == GamePhase.Draw)
            {
                reward = DRAW_REWARD;
            }
            else
            {
                reward = simulationResult.GetReward(leafPlayer);
            }
            return reward;
        }

        private MCNode FindBestChildNode(MCNode node)
        {
            // UCT GOES HERE
            throw new NotImplementedException();
        }

        private IGameMove ExtractResultMove()
        {
            throw new NotImplementedException();
        }
    }
}
