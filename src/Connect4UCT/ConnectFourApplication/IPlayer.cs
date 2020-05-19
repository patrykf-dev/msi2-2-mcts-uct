using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourApplication
{
    public interface IPlayer
    {
        void SetColor(Color color);
        Color GetColor();
        string GetName();
        void PerformMove(int column);
    }
}
