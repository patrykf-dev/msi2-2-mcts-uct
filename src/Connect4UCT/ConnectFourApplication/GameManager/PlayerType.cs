namespace ConnectFourApplication
{
    public enum PlayerType
    {
        HUMAN,
        GREEDY,
        UCB1,
        UCB_M,
        UCB_V,
        RANDOM
    }

    public static class PlayerTypeExtensions
    {
        public static PlayerType GetPlayerType(int index)
        {
            switch (index)
            {
                case 0:
                    return PlayerType.HUMAN;
                case 1:
                    return PlayerType.GREEDY;
                case 2:
                    return PlayerType.UCB1;
                case 3:
                    return PlayerType.UCB_M;
                case 4:
                    return PlayerType.UCB_V;
                case 5:
                    return PlayerType.RANDOM;
                default:
                    return PlayerType.HUMAN;
            }
        }
    }
}
