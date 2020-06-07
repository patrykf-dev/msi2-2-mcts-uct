using MonteCarloTreeSearchLib.ConnectFour;
using System.Collections.Generic;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class GreedyDecider
    {
        private readonly static int[,] EVALUATION_TABLE = new int[,]
            {{3, 4, 5, 7, 5, 4, 3},
            {4, 6, 8, 10, 8, 6, 4},
            {5, 8, 11, 13, 11, 8, 5},
            {5, 8, 11, 13, 11, 8, 5},
            {4, 6, 8, 10, 8, 6, 4},
            {3, 4, 5, 7, 5, 4, 3}};


        public int PerformDecision(ConnectFourBoard board)
        {
            int playerTurn = board.CurrentPlayer;

            int obviousBlockIndex = FindObviousBlock(board);
            if (obviousBlockIndex != -1)
            {
                return obviousBlockIndex;
            }
            else
            {
                return PerformDecisionWithEvaluation(board, playerTurn);
            }
        }

        private int FindObviousBlock(ConnectFourBoard board)
        {
            int opponent = PlayerHelpers.GetOpposingPlayer(board.CurrentPlayer);

            // Detect row blocks
            for (int row = 0; row < board.Height; row++)
            {
                for (int startCol = 0; startCol < board.Width - 3; startCol++)
                {
                    int emptyColumn = -1;
                    int counter = 0;
                    for (int i = startCol; i < startCol + 4; i++)
                    {
                        if (board.Board[row, i] == opponent)
                            counter++;
                        else if (board.Board[row, i] == 0)
                            emptyColumn = i;
                    }

                    if (counter == 3 && emptyColumn != -1)
                    {
                        if (board.ColumnHeights[emptyColumn] == row)
                        {
                            return emptyColumn;
                        }
                    }

                }
            }

            // Detect column blocks
            for (int column = 0; column < board.Width; column++)
            {
                int colHeight = board.ColumnHeights[column];
                if (colHeight >= 3)
                {
                    if (board.Board[colHeight - 1, column] == opponent &&
                        board.Board[colHeight - 2, column] == opponent &&
                        board.Board[colHeight - 3, column] == opponent &&
                        board.ColumnFull(column) == false)
                    {
                        return column;
                    }
                }
            }
            return -1;
        }

        private int PerformDecisionWithEvaluation(ConnectFourBoard board, int playerTurn)
        {
            var availableHoles = board.GetFreeHoles();
            var holesPrized = new List<(int, int)>();
            foreach (int hole in availableHoles)
            {
                var tmpBoard = board.GetDeepCopy();
                tmpBoard.PerformMove(hole);
                int prize = EvaluateBoard(tmpBoard, playerTurn);
                holesPrized.Add((hole, prize));
            }

            var bestHole = holesPrized[0];
            foreach (var hole in holesPrized)
            {
                if (hole.Item2 > bestHole.Item2)
                {
                    bestHole = hole;
                }
            }

            return bestHole.Item1;
        }

        private int EvaluateBoard(ConnectFourBoard board, int playerTurn)
        {
            int utility = 138;
            int sum = 0;
            for (int i = 0; i < board.Height; i++)
            {
                for (int j = 0; j < board.Width; j++)
                {
                    if (board.Board[i, j] == playerTurn)
                    {
                        sum += EVALUATION_TABLE[i, j];
                    }
                    else
                    {
                        sum -= EVALUATION_TABLE[i, j];
                    }
                }
            }
            return utility + sum;
        }
    }
}
