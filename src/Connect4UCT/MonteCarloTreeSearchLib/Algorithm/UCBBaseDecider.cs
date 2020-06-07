namespace MonteCarloTreeSearchLib.Algorithm
{
    public interface UCBBaseDecider
    {
        MCNode FindBestUCTChildNode(MCNode node, int playerTurn);
    }
}
