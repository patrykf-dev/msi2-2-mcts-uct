using System.Drawing;

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
