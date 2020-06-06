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
        public int[,] Board { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        private int[] _columnHeights;
        private int _tokensPlaced;

        public int[,] GetBoard() { return Board; }

        public ConnectFourBoard(int width = 7, int height = 6)
        {
            Width = width;
            Height = height;
            _tokensPlaced = 0;
            Board = new int[height, width];
            _columnHeights = new int[width];
            CurrentPlayer = 1;
            Phase = GamePhase.InProgress;
        }

        public GamePhase PerformMove(int column)
        {
            if (column < 0 || column > Width || ColumnFull(column) || Phase != GamePhase.InProgress)
                throw new ArgumentException($"Invalid move, cannot fill column {column}");

            Board[_columnHeights[column], column] = CurrentPlayer;
            _columnHeights[column]++;
            _tokensPlaced++;
            SwitchCurrentPlayer();

            Phase = CheckMoveResult(column);
            return Phase;
        }

        public string SerializeHeights()
        {
            string rc = "";
            foreach (var height in _columnHeights)
            {
                rc += $"{height}|";
            }
            return rc;
        }

        public void PrintBoard()
        {
            Console.WriteLine("=======================================");
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Console.Write($"{Board[row, col]} ");
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
            board.Width = Width;
            board.Height = Height;
            board._tokensPlaced = _tokensPlaced;

            for (int i = 0; i < Width; i++)
            {
                board._columnHeights[i] = _columnHeights[i];
                for (int j = 0; j < Height; j++)
                {
                    board.Board[j, i] = Board[j, i];
                }
            }

            return board;
        }

        public int FindAdditionalHole(ConnectFourBoard nextBoard)
        {
            for (int i = 0; i < Width; i++)
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
            for (int i = 0; i < Width; i++)
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
            return _tokensPlaced == Width * Height;
        }

        private void SwitchCurrentPlayer()
        {
            CurrentPlayer = PlayerHelpers.GetOpposingPlayer(CurrentPlayer);
        }

        private bool ColumnFull(int hole)
        {
            return _columnHeights[hole] == Height;
        }

        private GamePhase CheckMoveResult(int column)
        {
            if (BoardFull())
            {
                return GamePhase.Draw;
            }

            int playerIndex = PlayerHelpers.GetOpposingPlayer(CurrentPlayer);

            // Horizontal check
            int horCount = 1;
            int horIndex = column + 1;
            while (horIndex < Width && Board[_columnHeights[column] - 1, horIndex] == playerIndex)
            {
                horCount++;
                horIndex++;
            }
            horIndex = column - 1;
            while (horIndex >= 0 && Board[_columnHeights[column] - 1, horIndex] == playerIndex)
            {
                horCount++;
                horIndex--;
            }

            if (horCount >= 4)
            {
                return PlayerHelpers.GetPhaseOnPlayerWin(playerIndex);
            }

            // Vertical check
            int verCount = 1;
            int verIndex = _columnHeights[column];
            while (verIndex < Height && Board[verIndex, column] == playerIndex)
            {
                verCount++;
                verIndex++;
            }
            verIndex = _columnHeights[column] - 2;
            while (verIndex >= 0 && Board[verIndex, column] == playerIndex)
            {
                verCount++;
                verIndex--;
            }

            if (verCount >= 4)
            {
                return PlayerHelpers.GetPhaseOnPlayerWin(playerIndex);
            }

            // Ascending diagonal check
            int ascDiagCount = 1;
            int ascDiagColIndex = column + 1;
            int ascDiagRowIndex = _columnHeights[column];
            while (ascDiagRowIndex < Height &&
                ascDiagColIndex < Width &&
                Board[ascDiagRowIndex, ascDiagColIndex] == playerIndex)
            {
                ascDiagCount++;
                ascDiagColIndex++;
                ascDiagRowIndex++;
            }
            ascDiagColIndex = column - 1;
            ascDiagRowIndex = _columnHeights[column] - 2;
            while (ascDiagRowIndex >= 0 &&
                ascDiagColIndex >= 0 &&
                 Board[ascDiagRowIndex, ascDiagColIndex] == playerIndex)
            {
                ascDiagCount++;
                ascDiagColIndex--;
                ascDiagRowIndex--;
            }

            //Console.WriteLine($"asc diag count for player {playerIndex} is {ascDiagCount}");
            if (ascDiagCount >= 4)
            {
                return PlayerHelpers.GetPhaseOnPlayerWin(playerIndex);
            }

            // Descending diagonal check
            int descDiagCount = 1;
            int descDiagColIndex = column + 1; // ++
            int descDiagRowIndex = _columnHeights[column] - 2; // --
            while (descDiagColIndex < Width &&
                descDiagRowIndex >= 0 &&
                Board[descDiagRowIndex, descDiagColIndex] == playerIndex)
            {
                descDiagCount++;
                descDiagColIndex++;
                descDiagRowIndex--;
            }

            descDiagColIndex = column - 1; // --
            descDiagRowIndex = _columnHeights[column]; // ++
            while (descDiagColIndex >= 0 &&
                 descDiagRowIndex < Height &&
                  Board[descDiagRowIndex, descDiagColIndex] == playerIndex)
            {
                descDiagCount++;
                descDiagColIndex--;
                descDiagRowIndex++;
            }

            //Console.WriteLine($"desc diag count for player {playerIndex} is {descDiagCount}");
            if (descDiagCount >= 4)
            {
                return PlayerHelpers.GetPhaseOnPlayerWin(playerIndex);
            }

            return GamePhase.InProgress;
        }
    }
}
