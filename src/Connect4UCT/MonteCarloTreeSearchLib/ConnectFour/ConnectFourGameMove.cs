using MonteCarloTreeSearchLib.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.ConnectFour
{
    public class ConnectFourGameMove : IGameMove
    {
        public int HoleIndex { get; private set; }

        public ConnectFourGameMove(int holeIndex)
        {
            HoleIndex = holeIndex;
        }
    }
}
