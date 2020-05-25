using MonteCarloTreeSearchLib.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.ConnectFour
{
    public class ConnectFourBoard
    {
        public GamePhase Phase { get; private set; }
        public int CurrentPlayer { get; private set; }

        private int[,] _board;
        private int[] _columnHeights;
        private int _width;
        private int _tokensPlaced;
        private int _height;

        public int[,] GetBoard() { return _board; }

        public ConnectFourBoard(int width = 7, int height = 6)
        {
            _width = width;
            _height = height;
            _tokensPlaced = 0;
            _board = new int[height, width];
            _columnHeights = new int[width];
            CurrentPlayer = 1;
            Phase = GamePhase.InProgress;
        }

        public GamePhase PerformMove(int column)
        {
            if (column < 0 || column > _width || ColumnFull(column) || Phase != GamePhase.InProgress)
                throw new ArgumentException("Invalid move");

            _board[_columnHeights[column], column] = CurrentPlayer;
            _columnHeights[column]++;
            _tokensPlaced++;
            SwitchCurrentPlayer();

            Phase = CheckMoveResult(column);
            PrintBoard();
            return Phase;
        }

        private void PrintBoard()
        {
            Console.WriteLine("=======================================");
            for (int row = 0; row < _height; row++)
            {
                for (int col = 0; col < _width; col++)
                {
                    Console.Write($"{_board[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"{Phase}");
            Console.WriteLine("=======================================");
        }

        public ConnectFourBoard GetDeepCopy()
        {
            var board = new ConnectFourBoard();
            board.Phase = Phase;
            board.CurrentPlayer = CurrentPlayer;
            board._width = _width;
            board._height = _height;
            board._tokensPlaced = _tokensPlaced;

            for (int i = 0; i < _width; i++)
            {
                board._columnHeights[i] = _columnHeights[i];
                for (int j = 0; j < _height; j++)
                {
                    board._board[j, i] = _board[j, i];
                }
            }

            return board;
        }

        public int FindAdditionalHole(ConnectFourBoard nextBoard)
        {
            for (int i = 0; i < _width; i++)
            {
                if (_columnHeights[i] < nextBoard._columnHeights[i])
                {
                    return i;
                }
            }
            throw new ArgumentException("There are no differences between boards!");
        }

        public List<int> GetFreeHoles()
        {
            var holes = new List<int>();
            for (int i = 0; i < _width; i++)
            {
                if (ColumnFull(i) == false)
                {
                    holes.Add(i);
                }
            }
            return holes;
        }

        private bool BoardFull()
        {
            return _tokensPlaced == _width * _height;
        }

        private void SwitchCurrentPlayer()
        {
            CurrentPlayer = (CurrentPlayer == 1) ? 2 : 1;
        }

        private int GetOpposingPlayer(int player)
        {
            return player == 1 ? 2 : 1;
        }

        private bool ColumnFull(int hole)
        {
            return _columnHeights[hole] == _height;
        }

        private GamePhase CheckMoveResult(int column)
        {
            if (BoardFull())
            {
                return GamePhase.Draw;
            }

            int playerIndex = GetOpposingPlayer(CurrentPlayer);

            // Horizontal check
            int horCount = 1;
            int horIndex = column + 1;
            while (horIndex < _width && _board[_columnHeights[column] - 1, horIndex] == playerIndex)
            {
                horCount++;
                horIndex++;
            }
            horIndex = column - 1;
            while (horIndex >= 0 && _board[_columnHeights[column] - 1, horIndex] == playerIndex)
            {
                horCount++;
                horIndex--;
            }

            if (horCount >= 4)
            {
                return GamePhaseMethods.GetPhaseOnPlayerWin(playerIndex);
            }

            // Vertical check
            int verCount = 1;
            int verIndex = _columnHeights[column];
            while (verIndex < _height && _board[verIndex, column] == playerIndex)
            {
                verCount++;
                verIndex++;
            }
            verIndex = _columnHeights[column] - 2;
            while (verIndex >= 0 && _board[verIndex, column] == playerIndex)
            {
                verCount++;
                verIndex--;
            }

            if (verCount >= 4)
            {
                return GamePhaseMethods.GetPhaseOnPlayerWin(playerIndex);
            }

            // Ascending diagonal check
            int ascDiagCount = 1;
            int ascDiagColIndex = column + 1;
            int ascDiagRowIndex = _columnHeights[column];
            while (ascDiagRowIndex < _height &&
                ascDiagColIndex < _width &&
                _board[ascDiagRowIndex, ascDiagColIndex] == playerIndex)
            {
                ascDiagCount++;
                ascDiagColIndex++;
                ascDiagRowIndex++;
            }
            ascDiagColIndex = column - 1;
            ascDiagRowIndex = _columnHeights[column] - 2;
            while (ascDiagRowIndex >= 0 &&
                ascDiagColIndex >= 0 &&
                 _board[ascDiagRowIndex, ascDiagColIndex] == playerIndex)
            {
                ascDiagCount++;
                ascDiagColIndex--;
                ascDiagRowIndex--;
            }

            //Console.WriteLine($"asc diag count for player {playerIndex} is {ascDiagCount}");
            if (ascDiagCount >= 4)
            {
                return GamePhaseMethods.GetPhaseOnPlayerWin(playerIndex);
            }

            // Descending diagonal check
            int descDiagCount = 1;
            int descDiagColIndex = column + 1; // ++
            int descDiagRowIndex = _columnHeights[column] - 2; // --
            while (descDiagColIndex < _width &&
                descDiagRowIndex >= 0 &&
                _board[descDiagRowIndex, descDiagColIndex] == playerIndex)
            {
                descDiagCount++;
                descDiagColIndex++;
                descDiagRowIndex--;
            }

            descDiagColIndex = column - 1; // --
            descDiagRowIndex = _columnHeights[column]; // ++
            while (descDiagColIndex >= 0 &&
                 descDiagRowIndex < _height &&
                  _board[descDiagRowIndex, descDiagColIndex] == playerIndex)
            {
                descDiagCount++;
                descDiagColIndex--;
                descDiagRowIndex++;
            }

            //Console.WriteLine($"desc diag count for player {playerIndex} is {descDiagCount}");
            if (descDiagCount >= 4)
            {
                return GamePhaseMethods.GetPhaseOnPlayerWin(playerIndex);
            }

            return GamePhase.InProgress;
        }
    }
}
