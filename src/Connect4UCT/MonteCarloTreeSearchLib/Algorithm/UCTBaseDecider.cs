using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public interface UCTBaseDecider
    {
        MCNode FindBestUCTChildNode(MCNode node, int playerTurn);
    }
}
