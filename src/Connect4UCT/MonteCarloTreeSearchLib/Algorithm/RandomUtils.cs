using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class RandomUtils
    {
        private static Random _rand = new Random(123123);
        public static int GetRandomInt(int startInclusive, int endExclusive)
        {
            return _rand.Next(startInclusive, endExclusive);
        }
    }
}
