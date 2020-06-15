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
        public int[] ColumnHeights { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int TokensPlaced { get; private set; }

        public int[,] GetBoard() { return Board; }

        public ConnectFourBoard(int width = 7, int height = 6)
        {
            Width = width;
            Height = height;
            TokensPlaced = 0;
            Board = new int[height, width];
            ColumnHeights = new int[width];
            CurrentPlayer = 1;
            Phase = GamePhase.InProgress;
        }

        public GamePhase PerformMove(int column)
        {
            if (column < 0 || column > Width || ColumnFull(column) || Phase != GamePhase.InProgress)
                throw new ArgumentException($"Invalid move, cannot fill column {column}");

            Board[ColumnHeights[column], column] = CurrentPlayer;
            ColumnHeights[column]++;
            TokensPlaced++;
            SwitchCurrentPlayer();

            Phase = CheckMoveResult(column);
            return Phase;
        }

        public string SerializeHeights()
        {
            string rc = "";
            foreach (var height in ColumnHeights)
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
            board.TokensPlaced = TokensPlaced;

            for (int i = 0; i < Width; i++)
            {
                board.ColumnHeights[i] = ColumnHeights[i];
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
                if (ColumnHeights[i] < nextBoard.ColumnHeights[i])
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

        public bool ColumnFull(int hole)
        {
            return ColumnHeights[hole] == Height;
        }

        private bool BoardFull()
        {
            return TokensPlaced == Width * Height;
        }

        private void SwitchCurrentPlayer()
        {
            CurrentPlayer = PlayerHelpers.GetOpposingPlayer(CurrentPlayer);
        }

        private GamePhase CheckMoveResult(int column)
        {
            int playerIndex = PlayerHelpers.GetOpposingPlayer(CurrentPlayer);

            // Horizontal check
            int horCount = 1;
            int horIndex = column + 1;
            while (horIndex < Width && Board[ColumnHeights[column] - 1, horIndex] == playerIndex)
            {
                horCount++;
                horIndex++;
            }
            horIndex = column - 1;
            while (horIndex >= 0 && Board[ColumnHeights[column] - 1, horIndex] == playerIndex)
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
            int verIndex = ColumnHeights[column];
            while (verIndex < Height && Board[verIndex, column] == playerIndex)
            {
                verCount++;
                verIndex++;
            }
            verIndex = ColumnHeights[column] - 2;
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
            int ascDiagRowIndex = ColumnHeights[column];
            while (ascDiagRowIndex < Height &&
                ascDiagColIndex < Width &&
                Board[ascDiagRowIndex, ascDiagColIndex] == playerIndex)
            {
                ascDiagCount++;
                ascDiagColIndex++;
                ascDiagRowIndex++;
            }
            ascDiagColIndex = column - 1;
            ascDiagRowIndex = ColumnHeights[column] - 2;
            while (ascDiagRowIndex >= 0 &&
                ascDiagColIndex >= 0 &&
                 Board[ascDiagRowIndex, ascDiagColIndex] == playerIndex)
            {
                ascDiagCount++;
                ascDiagColIndex--;
                ascDiagRowIndex--;
            }

            if (ascDiagCount >= 4)
            {
                return PlayerHelpers.GetPhaseOnPlayerWin(playerIndex);
            }

            // Descending diagonal check
            int descDiagCount = 1;
            int descDiagColIndex = column + 1; // ++
            int descDiagRowIndex = ColumnHeights[column] - 2; // --
            while (descDiagColIndex < Width &&
                descDiagRowIndex >= 0 &&
                Board[descDiagRowIndex, descDiagColIndex] == playerIndex)
            {
                descDiagCount++;
                descDiagColIndex++;
                descDiagRowIndex--;
            }

            descDiagColIndex = column - 1; // --
            descDiagRowIndex = ColumnHeights[column]; // ++
            while (descDiagColIndex >= 0 &&
                 descDiagRowIndex < Height &&
                  Board[descDiagRowIndex, descDiagColIndex] == playerIndex)
            {
                descDiagCount++;
                descDiagColIndex--;
                descDiagRowIndex++;
            }

            if (descDiagCount >= 4)
            {
                return PlayerHelpers.GetPhaseOnPlayerWin(playerIndex);
            }

            if (BoardFull())
            {
                return GamePhase.Draw;
            }

            return GamePhase.InProgress;
        }
    }
}
