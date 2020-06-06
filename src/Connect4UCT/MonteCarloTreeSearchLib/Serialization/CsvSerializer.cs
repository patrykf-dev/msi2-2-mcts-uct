using MonteCarloTreeSearchLib.Algorithm;
using MonteCarloTreeSearchLib.ConnectFour;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloTreeSearchLib.Serialization
{
    public class CsvSerializer
    {
        public static void SaveTree(MCNode root, string path)
        {
            StringBuilder sb = new StringBuilder();
            SerializeNode(root, sb);
            File.WriteAllText(path, sb.ToString());
        }

        private static void SerializeNode(MCNode node, StringBuilder sb)
        {
            int childCount = node.HasChildren ? node.Children.Count : 0;
            string columnHeights = (node.GameState as ConnectFourGameState).Board.SerializeHeights();
            string nodeLine = $"CURRPLAYER: {node.GameState.GetCurrentPlayer()} STATE: {node.GameState.Phase}, {node.VisitsCount}, 0, {node.AveragePrize}, {columnHeights}, {childCount}";
            sb.AppendLine(nodeLine);
            if (node.HasChildren == false)
                return;

            foreach (var child in node.Children)
            {
                SerializeNode(child, sb);
            }
        }
    }
}
