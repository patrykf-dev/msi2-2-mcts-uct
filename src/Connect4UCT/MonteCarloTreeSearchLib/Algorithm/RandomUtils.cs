using System;

namespace MonteCarloTreeSearchLib.Algorithm
{
    public class RandomUtils
    {
        public static int SEED = 123123;
        private static Random _rand = new Random(SEED);
        public static int GetRandomInt(int startInclusive, int endExclusive)
        {
            return _rand.Next(startInclusive, endExclusive);
        }

        public static void SetSeed(int rngSeed)
        {
            SEED = rngSeed;
            _rand = new Random(rngSeed);
        }
    }
}
