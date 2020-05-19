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
            return Phase;
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
                if(_columnHeights[i] < nextBoard._columnHeights[i])
                {
                    return i;
                }
            }
            throw new ArgumentException("There are no differences between boards!");
        }

        public List<int> GetFreeHoles()
        {
            var holes = new List<int>();
            for(int i = 0; i < _width; i++)
            {
                if(ColumnFull(i) == false)
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
                return GamePhase.Draw;

            int playerIndex = GetOpposingPlayer(CurrentPlayer);

            // Horizontal check
            int horCount = 1;
            int horIndex = column + 1;
            while (horIndex < _width && _board[_columnHeights[column], horIndex] == playerIndex)
            {
                horCount++;
                horIndex++;
            }
            horIndex = column - 1;
            while (horIndex >= 0 && _board[_columnHeights[column], horIndex] == playerIndex)
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
            int verIndex = _columnHeights[column] + 1;
            while (verIndex < _height && _board[verIndex, column] == playerIndex)
            {
                verCount++;
                verIndex++;
            }
            verIndex = _columnHeights[column] - 1;
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
            // Descending diagonal check
            // TODO!!!!
            return GamePhase.InProgress;
        }
    }
}
