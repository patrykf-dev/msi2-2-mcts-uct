using System;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class MCTreeSearch
    {
        private MCNode _root;
        private int _iterationCount;
        private int _maxIterations;
        private int _playerTurn;

        private readonly float WIN_REWARD = 1f;
        private readonly float DRAW_REWARD = 0.5f;
        private readonly float LOSE_REWARD = 0f;


        public MCTreeSearch(MCNode root, int maxIterations = 18000)
        {
            _root = root;
            _iterationCount = 0;
            _maxIterations = maxIterations;
            _playerTurn = root.GameState.GetCurrentPlayer();
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
            var expandedValidNode = Expansion(promisingNode);
            if (expandedValidNode == false)
            {
                Backpropagation(promisingNode, promisingNode.GameState.Phase);
                return;
            }

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
            while (tmpNode.HasChildren)
            {
                tmpNode = FindBestChildNode(tmpNode);
            }
            return tmpNode;
        }

        /// <summary>
        /// Executes 2nd stage of MCTS.
        /// Unless L ends the game, creates one(or more) child nodes and chooses node C from one of them.
        /// </summary>
        private bool Expansion(MCNode node)
        {
            var possibleMoves = node.GameState.GetAllPossibleMoves();
            var phase = node.GameState.Phase;
            if (phase != GamePhase.InProgress)
            {
                return false;
            }
            else
            {
                foreach (var move in possibleMoves)
                {
                    node.AddChildByMove(move);
                }
                return true;
            }
        }

        /// <summary>
        /// Executes 3rd stage of MCTS.
        /// Complete a random playout from node C.
        /// </summary>
        private GamePhase Simulation(MCNode leaf)
        {
            var tmpState = leaf.GameState.GetDeepCopy();
            var tmpPhase = tmpState.Phase;

            while (tmpPhase == GamePhase.InProgress)
            {
                tmpPhase = tmpState.PerformRandomMove();
            }
            return tmpPhase;
        }

        /// <summary>
        /// Executes 4th stage of MCTS.
        /// Uses the result of the playout to update information in the nodes on the path from C to R.
        /// </summary>
        private void Backpropagation(MCNode leaf, GamePhase playoutFinalPhase)
        {
            int leafPlayer = leaf.GameState.GetCurrentPlayer();
            float reward = CalculateReward(playoutFinalPhase, leafPlayer);
            var tmpNode = leaf;
            while (tmpNode != _root)
            {
                tmpNode.MarkVisit();

                if (playoutFinalPhase == GamePhase.Draw)
                {
                    tmpNode.AddReward(reward);
                }
                else if (tmpNode.GameState.GetCurrentPlayer() == leafPlayer)
                {
                    tmpNode.AddReward(reward);
                }

                tmpNode = tmpNode.Parent;
            }
            _root.MarkVisit();
        }

        private float CalculateReward(GamePhase playoutFinalPhase, int leafPlayer)
        {
            if (playoutFinalPhase == PlayerHelpers.GetPhaseOnPlayerWin(leafPlayer))
                return WIN_REWARD;
            else if (playoutFinalPhase == PlayerHelpers.GetPhaseOnPlayerLose(leafPlayer))
                return LOSE_REWARD;
            else if (playoutFinalPhase == GamePhase.Draw)
                return DRAW_REWARD;
            else
                throw new ArgumentException("Illegal state");
        }

        /// <summary>
        /// Calculates UCT value for children of a given node, with the formula:
        /// uct_value = (win_score / visits) + 1.41 * sqrt(log(parent_visit) / visits)
        /// and returns the most profitable one.
        /// </summary>
        private MCNode FindBestChildNode(MCNode node)
        {
            return node.FindBestUCTChildNode(1.41f, _playerTurn);
        }

        private IGameMove ExtractResultMove()
        {
            MCNode bestChild = _root.GetChildWithMaxAveragePrize();
            return _root.GameState.GetGameMoveLeadingTo(bestChild.GameState);
        }
    }
}
