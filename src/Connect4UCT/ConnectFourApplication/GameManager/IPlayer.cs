using System.Drawing;

namespace ConnectFourApplication
{
    public interface IPlayer
    {
        Color Color { get; set; }
        string GetName();
        void PerformMove(int column);
        int GetPlayerDecision();
    }
}
