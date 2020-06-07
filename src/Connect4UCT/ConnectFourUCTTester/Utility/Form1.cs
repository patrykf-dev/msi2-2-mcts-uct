using ConnectFourApplication;
using ConnectFourApplication.GameManager;
using MonteCarloTreeSearchLib.Algorithm;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConnectFourUCTTester
{
    public partial class Form1 : Form
    {
        private static int[] SEEDS = new int[] {
            93715, 62735, 42394, 12312, 50452,
            22323, 39123, 75675, 12392, 11221,
            13200, 99932, 65651, 83737, 20991
        };

        public Form1()
        {
            InitializeComponent();
            TestUCB1Parameters();
        }

        private void TestUCB1Parameters()
        {
            float[] expParams = new float[] { 
                0, 0.01f, 0.1f, 0.8f, 1f, 
                1.41f, 2f, 5f, 8f, 1000f ,
                3f, 11f, 0.5f, 0.09f, 1.27f};
            foreach (var expParam in expParams)
            {
                foreach (var seed in SEEDS)
                {
                    var testSetup = new TestSetup(seed, PlayerType.GREEDY, PlayerType.UCB1, "GREEDY", $"UCB1 ({expParam})");
                    testSetup.player2.Decider.ucb1Decider = new UCB1Decider(expParam);
                    PerformTest(testSetup, "params_ucb1.csv");
                }
            }
        }

        private void TestUCBMParameters()
        {
            var cValues = new List<(float, float)>()
            {
                (2.5f, 1f), (8.4f, 1.8f), (3f, 2f), (11f, 1f), (1000f, 200f),
                (0.3f, 0.02f), (9.4f, 2.8f), (2.9f, 1.4f), (12f, 5f), (3f, 3f),
                (24f, 6f), (40f, 10f), (40f, 40f), (26f, 26f), (1.8f, 8.4f)
            };

            foreach ((float c1, float c2) in cValues)
            {
                foreach (var seed in SEEDS)
                {
                    var testSetup = new TestSetup(seed, PlayerType.GREEDY, PlayerType.UCB_M, "GREEDY", $"UCBM ({c1}) ({c2})");
                    testSetup.player2.Decider.ucbmDecider = new UCBMDecider(c1, c2);
                    PerformTest(testSetup, "params_ucbm.csv");
                }
            }
        }

        private void TestUCBVParameters()
        {
            var calues = new List<(float, float)>()
            {
                (1f, 1f), (1.1f, 1.1f), (2f, 2f), (0.8f, 0.8f), (0.9f, 1.1f),
                (1.68f, 0.54f), (1.8f, 0.8f), (2f, 0.9f), (1.4f, 0.5f), (2f, 0.5f),
                (10f, 10f), (0.1f, 0.05f), (120f, 30f), (1.7f, 0.6f), (0.9f, 0.9f)
            };

            foreach ((float c, float zeta) in calues)
            {
                foreach (var seed in SEEDS)
                {
                    var testSetup = new TestSetup(seed, PlayerType.GREEDY, PlayerType.UCB_V, "GREEDY", $"UCBV ({c}) ({zeta})");
                    testSetup.player2.Decider.ucbvDecider = new UCBVDecider(c, zeta);
                    PerformTest(testSetup, "params_ucbv.csv");
                }
            }
        }

        private void PerformTest(TestSetup testSetup, string fileName)
        {
            RandomUtils.SetSeed(testSetup.rngSeed);
            using (GameForm form = new GameForm())
            {
                var tracker = new GameTracker(form, testSetup.player1Name, testSetup.player2Name, fileName);
                form.Show();
                form.PerformTest(testSetup.player1, testSetup.player2);
            }
        }
    }
}

public class TestSetup
{
    public int rngSeed;
    public ComputerPlayer player1;
    public ComputerPlayer player2;
    public PlayerType player1Strategy;
    public PlayerType player2Strategy;
    public string player1Name;
    public string player2Name;

    public TestSetup(int rngSeed, PlayerType player1Strategy, PlayerType player2Strategy, string player1Name, string player2Name)
    {
        this.rngSeed = rngSeed;
        this.player1Strategy = player1Strategy;
        this.player2Strategy = player2Strategy;
        this.player1Name = player1Name;
        this.player2Name = player2Name;
        player1 = new ComputerPlayer("PLAYER 1", player1Strategy);
        player2 = new ComputerPlayer("PLAYER 2", player2Strategy);
    }
}
