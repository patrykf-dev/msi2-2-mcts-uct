using MonteCarloTreeSearchLib.Algorithm;
using System;
using System.IO;
using System.Text;

namespace ConnectFourApplication.GameManager
{
    public class GameTracker : IDisposable
    {
        private static readonly int MIN_WIN_MOVES = 7;
        private static readonly int MAX_WIN_MOVES = 42;
        private static readonly double FIRST_MOVE_IMPORTANCE = 0.2;

        private string _firstPlayer;
        private string _secondPlayer;
        private string _fileName;
        private GameForm _form;

        public GameTracker(GameForm form, string firstPlayer, string secondPlayer, string fileName)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
            _form = form;
            _fileName = fileName;
            _form.OnGameEnded += HandleGameEnded;
        }

        public void Dispose()
        {
            _form.OnGameEnded -= HandleGameEnded;
        }

        private void HandleGameEnded(GamePhase phase)
        {
            int rngSeed = RandomUtils.SEED;
            _form.Moves.RemoveAt(0);
            int result = GetGameResult(phase);
            string log = 
                $"{rngSeed}, {_firstPlayer}, {_secondPlayer}, " +
                $"{result}, {GetMovesString()}, {GetRewardValue(result, _form.Moves.Count)}";
            File.AppendAllText(_fileName, log + Environment.NewLine);
        }

        private double GetRewardValue(int result, int movesCount)
        {
            if(result == 0)
            {
                return 0;
            }
            else if (result == 1)
            {
                double moveReward = (double)(movesCount - MIN_WIN_MOVES) / (double)(MAX_WIN_MOVES - MIN_WIN_MOVES);
                moveReward = 1 - moveReward;
                return (1 - FIRST_MOVE_IMPORTANCE) * moveReward;
            }
            else if(result == -1)
            {
                double movePenalty = (double)(movesCount - MIN_WIN_MOVES) / (double)(MAX_WIN_MOVES - MIN_WIN_MOVES);
                movePenalty -= 1;
                return movePenalty;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private string GetMovesString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int move in _form.Moves)
            {
                sb.Append(move.ToString());
            }
            return sb.ToString();
        }

        private int GetGameResult(GamePhase phase)
        {
            if (phase == GamePhase.Player1Won)
                return 1;
            else if (phase == GamePhase.Player2Won)
                return -1;
            else if (phase == GamePhase.Draw)
                return 0;
            else
                throw new ArgumentOutOfRangeException();
        }
    }
}
