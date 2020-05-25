using System.Drawing;

namespace ConnectFourApplication
{
    public class HumanPlayer : IPlayer
    {
        private string _name;
        public Color Color { get; set; }

        public HumanPlayer(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void PerformMove(int column)
        {

        }

        public int GetPlayerDecision()
        {
            throw new System.NotImplementedException();
        }
    }
}
