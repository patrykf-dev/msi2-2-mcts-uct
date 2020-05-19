using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourApplication
{
    public class ComputerPlayer :IPlayer
    {
        private string _name;
        private Color _color;
        public ComputerPlayer(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetColor(Color color)
        {
            _color = color;
        }

        public Color GetColor()
        {
            return _color;
        }
        public void PerformMove(int column)
        {

        }
    }
}
