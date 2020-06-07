using MonteCarloTreeSearchLib.Algorithm;
using MonteCarloTreeSearchLib.ConnectFour;
using System.Drawing;

namespace ConnectFourApplication
{
    public class ComputerPlayer : IPlayer
    {
        private string _name;
        private PlayerType _type;
        public Color Color { get; set; }

        public ComputerPlayer(string name, PlayerType type)
        {
            _name = name;
            _type = type;
        }

        public string GetName()
        {
            return _name;
        }

        public void PerformMove(int column)
        {
        }

        public int GetPlayerDecision(ConnectFourBoard board)
        {
            AgentDecider decider = new AgentDecider(_type.GetAgentStrategy());
            return decider.PerformDecision(board);
        }
    }
}
