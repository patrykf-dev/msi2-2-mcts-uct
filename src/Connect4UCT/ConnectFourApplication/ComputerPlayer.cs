using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourApplication
{
    public class ComputerPlayer :IPlayer
    {
        private string _name;
        public ComputerPlayer(string name)
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
