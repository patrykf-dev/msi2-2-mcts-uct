using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class MCNode
    {
        public bool HasChildren => true; // FIX

        internal MCNode GetRandomChild()
        {
            throw new NotImplementedException();
        }
    }
}
