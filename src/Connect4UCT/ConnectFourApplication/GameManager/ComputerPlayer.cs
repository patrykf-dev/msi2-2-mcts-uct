using MonteCarloTreeSearchLib.Algorithm;
using MonteCarloTreeSearchLib.ConnectFour;
using System;
using System.Drawing;

namespace ConnectFourApplication
{
    public class ComputerPlayer : IPlayer
    {
        private string _name;
        private PlayerType _type;
        private AgentDecider _decider;
        public Color Color { get; set; }

        public ComputerPlayer(string name, PlayerType type, UCB1Decider ucb1Decider, UCBMDecider ucbmDecider, UCBVDecider ucbvDecider)
        {
            _name = name;
            _type = type;
            _decider = new AgentDecider(
                _type.GetAgentStrategy(),
                ucb1Decider,
                ucbmDecider,
                ucbvDecider);
        }

        public ComputerPlayer(string name, PlayerType type)
        {
            _name = name;
            _type = type;
            _decider = new AgentDecider(
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
            return _decider.PerformDecision(board);
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
