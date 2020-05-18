using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourApplication
{
    public class HumanPlayer :IPlayer
    {
        private string _name;
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
    }
}
