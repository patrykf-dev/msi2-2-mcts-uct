﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public enum GamePhase
    {
        InProgress,
        Player1Won,
        Player2Won,
        Draw
    }

    public static class GamePhaseMethods
    {
        public static GamePhase GetPhaseOnPlayerWin(int player)
        {
            if (player == 1)
                return GamePhase.Player1Won;
            else if (player == 2)
                return GamePhase.Player2Won;
            else
                throw new IndexOutOfRangeException();
        }

        public static GamePhase GetPhaseOnPlayerLose(int player)
        {
            if (player == 1)
                return GamePhase.Player2Won;
            else if (player == 2)
                return GamePhase.Player1Won;
            else
                throw new IndexOutOfRangeException();
        }

        public static int GetWinnerIndexOnPhase(GamePhase phase)
        {
            if (phase == GamePhase.Player1Won)
                return 1;
            else if (phase == GamePhase.Player2Won)
                return 2;
            else
                throw new IndexOutOfRangeException();
        }
    }
}
