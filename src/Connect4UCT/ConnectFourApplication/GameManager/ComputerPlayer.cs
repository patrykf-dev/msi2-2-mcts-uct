using MonteCarloTreeSearchLib.Algorithm;
using MonteCarloTreeSearchLib.ConnectFour;
using System;
using System.Drawing;

namespace ConnectFourApplication
{
    public class ComputerPlayer : IPlayer
    {
        public AgentDecider Decider { get; set; }
        public Color Color { get; set; }
        private string _name;
        private PlayerType _type;

        public ComputerPlayer(string name, PlayerType type)
        {
            _name = name;
            _type = type;
            Decider = new AgentDecider(
                _type.GetAgentStrategy(),
                GetDefaultUCB1Decider(),
                GetDefaultUCBMDecider(),
                GetDefaultUCBVDecider());
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
            return Decider.PerformDecision(board);
        }

        private UCB1Decider GetDefaultUCB1Decider()
        {
            return new UCB1Decider(1.41f);
        }
        private UCBMDecider GetDefaultUCBMDecider()
        {
            return new UCBMDecider(8.4f, 1.8f);
        }
        private UCBVDecider GetDefaultUCBVDecider()
        {
            return new UCBVDecider(1.68f, 0.54f);
        }
    }
}
