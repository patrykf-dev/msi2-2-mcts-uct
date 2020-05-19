using MonteCarloTreeSearchLib.ConnectFour;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourApplication
{
    public class Game
    {
        public int SecondsPerMove { get; private set; }

        public IPlayer Player1 { get; private set; }
        public Color Player1Color { get; set; }
        public IPlayer Player2 {get; private set;}
        public Color Player2Color { get; set; }

        public IPlayer ActualMoving { get; private set; }
        public IPlayer ActualNotMoving { get; private set; }

        private ConnectFourBoard _board;

        public Game(Mode mode, int secondsPerMove)
        {
            SecondsPerMove = secondsPerMove;
            CreatePlayers(mode);
            ActualMoving = Player1;
            ActualNotMoving = Player2;
            _board = new ConnectFourBoard();
            Player1Color = Color.Yellow;
            Player2Color = Color.Red;
        }

        #region creatingPlayers
        private void CreatePlayers(Mode mode)
        {
            switch (mode)
            {
                case Mode.ComputerVsComputer:
                    Player1 = CreateComputerPlayer("Computer 1");
                    Player2 = CreateComputerPlayer("Computer 2");
                    break;
                case Mode.ComputerVsPlayer:
                    Player1 = CreateComputerPlayer("Computer");
                    Player2 = CreateHumanPlayer("Player");
                    break;
                case Mode.PlayerVsComputer:
                    Player1 = CreateHumanPlayer("Player");
                    Player2 = CreateComputerPlayer("Computer");
                    break;
                case Mode.PlayerVsPlayer:
                    Player1 = CreateHumanPlayer("Player 1");
                    Player2 = CreateHumanPlayer("Player 2");
                    break;
            }
        }

        private IPlayer CreateComputerPlayer(string name)
        {
            return new ComputerPlayer(name);
        }

        private IPlayer CreateHumanPlayer(string name)
        {
            return new HumanPlayer(name);
        }
        #endregion

        public void SwitchMovingPlayer()
        {
            IPlayer p = ActualMoving;
            ActualMoving = ActualNotMoving;
            ActualNotMoving = p;
        }
    }
}
