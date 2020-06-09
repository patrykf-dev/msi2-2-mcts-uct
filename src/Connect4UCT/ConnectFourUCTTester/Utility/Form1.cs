using ConnectFourApplication;
using ConnectFourApplication.GameManager;
using MonteCarloTreeSearchLib.Algorithm;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConnectFourUCTTester
{
    public partial class Form1 : Form
    {
        private static int[] SEEDS_BIG = new int[] {
            93715, 62735, 42394, 12312, 50452,
            22323, 39123, 75675, 12392, 11221,
            13200, 99932, 65651, 83737, 20991,
            87320, 66622, 11201, 80107, 26391,
            80880, 17172, 60432, 87727, 20111,
            10880, 98172, 10432, 17727, 10111,
            12345, 54321, 67890, 19876, 29292,
            24680, 13579, 15937, 24068, 91357
        };

        private static int[] SEEDS = new int[] {
            93715, 62735, 42394, 12312, 50452,
            22323, 39123, 75675, 12392, 11221,
            13200, 99932, 65651, 83737, 20991
        };

        private static int[] SEEDS_SMALL = new int[] {
            93715, 62735, 42394, 12312, 50452,
            22323, 39123, 75675, 12392, 11221
        };

        private static int[] ITERATIONS = new int[] {
            100, 500, 1000, 2500, 5000, 7500, 10000, 12500, 15000, 17500, 20000
        };

        public Form1()
        {
            InitializeComponent();
            TestCell06();
        }


        private void TestCell01()
        {
            foreach (var seed in SEEDS_BIG)
            {
                var testSetup = new TestSetup(seed, PlayerType.UCB_V, PlayerType.UCB_V, "UCBV(2) (0.5)", $"UCBV(1.4) (0.5)");
                testSetup.player1.Decider.ucbvDecider = new UCBVDecider(2f, 0.5f);
                testSetup.player2.Decider.ucbvDecider = new UCBVDecider(1.4f, 0.5f);
                PerformTest(testSetup, "cell_01.csv");
            }
            foreach (var seed in SEEDS_BIG)
            {
                var testSetup = new TestSetup(seed, PlayerType.UCB_V, PlayerType.UCB_V, $"UCBV(1.4) (0.5)", "UCBV(2) (0.5)");
                testSetup.player1.Decider.ucbvDecider = new UCBVDecider(1.4f, 0.5f);
                testSetup.player2.Decider.ucbvDecider = new UCBVDecider(2f, 0.5f);
                PerformTest(testSetup, "cell_01.csv");
            }
        }

        private void TestCell02()
        {
            // UCBV (2) (0.5) vs UCB1 (2)
            foreach (var seed in SEEDS_BIG)
            {
                var testSetup = new TestSetup(seed, PlayerType.UCB_V, PlayerType.UCB1, "UCBV(2) (0.5)", "UCB1 (2)");
                testSetup.player1.Decider.ucbvDecider = new UCBVDecider(2f, 0.5f);
                testSetup.player2.Decider.ucb1Decider = new UCB1Decider(2f);
                PerformTest(testSetup, "cell_02.csv");
            }
            foreach (var seed in SEEDS_BIG)
            {
                var testSetup = new TestSetup(seed, PlayerType.UCB1, PlayerType.UCB_V, "UCB1 (2)", "UCBV(2) (0.5)");
                testSetup.player1.Decider.ucb1Decider = new UCB1Decider(2f);
                testSetup.player2.Decider.ucbvDecider = new UCBVDecider(2f, 0.5f);
                PerformTest(testSetup, "cell_02.csv");
            }
        }

        private void TestCell03()
        {
            // UCBV (2) (0.5) vs UCB1 (1.41)
            foreach (var seed in SEEDS_BIG)
            {
                var testSetup = new TestSetup(seed, PlayerType.UCB_V, PlayerType.UCB1, "UCBV(2) (0.5)", "UCB1 (1.41)");
                testSetup.player1.Decider.ucbvDecider = new UCBVDecider(2f, 0.5f);
                testSetup.player2.Decider.ucb1Decider = new UCB1Decider(1.41f);
                PerformTest(testSetup, "cell_03.csv");
            }
            foreach (var seed in SEEDS_BIG)
            {
                var testSetup = new TestSetup(seed, PlayerType.UCB1, PlayerType.UCB_V, "UCB1 (1.41)", "UCBV(2) (0.5)");
                testSetup.player1.Decider.ucb1Decider = new UCB1Decider(1.41f);
                testSetup.player2.Decider.ucbvDecider = new UCBVDecider(2f, 0.5f);
                PerformTest(testSetup, "cell_03.csv");
            }
        }

        private void TestCell04()
        {
            // UCB1 (1.41) vs UCBV(1.4) (0.5)
            foreach (var seed in SEEDS_BIG)
            {
                var testSetup = new TestSetup(seed, PlayerType.UCB1, PlayerType.UCB_V, "UCB1 (1.41)", "UCBV(1.4) (0.5)");
                testSetup.player1.Decider.ucb1Decider = new UCB1Decider(1.41f);
                testSetup.player2.Decider.ucbvDecider = new UCBVDecider(1.4f, 0.5f);
                PerformTest(testSetup, "cell_04.csv");
            }
            foreach (var seed in SEEDS_BIG)
            {
                var testSetup = new TestSetup(seed, PlayerType.UCB_V, PlayerType.UCB1, "UCBV(1.4) (0.5)", "UCB1 (1.41)");
                testSetup.player1.Decider.ucbvDecider = new UCBVDecider(1.4f, 0.5f);
                testSetup.player2.Decider.ucb1Decider = new UCB1Decider(1.41f);
                PerformTest(testSetup, "cell_04.csv");
            }
        }

        private void TestCell05()
        {
            // UCB1 (1.41) vs UCB1 (2)
            foreach (var seed in SEEDS_BIG)
            {
                var testSetup = new TestSetup(seed, PlayerType.UCB1, PlayerType.UCB1, "UCB1 (1.41)", "UCB1 (2)");
                testSetup.player1.Decider.ucb1Decider = new UCB1Decider(1.41f);
                testSetup.player2.Decider.ucb1Decider = new UCB1Decider(2f);
                PerformTest(testSetup, "cell_05.csv");
            }
            foreach (var seed in SEEDS_BIG)
            {
                var testSetup = new TestSetup(seed, PlayerType.UCB1, PlayerType.UCB1, "UCB1 (2)", "UCB1 (1.41)");
                testSetup.player1.Decider.ucb1Decider = new UCB1Decider(2f);
                testSetup.player2.Decider.ucb1Decider = new UCB1Decider(1.41f);
                PerformTest(testSetup, "cell_05.csv");
            }
        }
        private void TestCell06()
        {
            // UCB1 (2) vs UCBV(1.4) (0.5)
            foreach (var seed in SEEDS_BIG)
            {
                var testSetup = new TestSetup(seed, PlayerType.UCB1, PlayerType.UCB_V, "UCB1 (2)", "UCBV(1.4) (0.5)");
                testSetup.player1.Decider.ucb1Decider = new UCB1Decider(2f);
                testSetup.player2.Decider.ucbvDecider = new UCBVDecider(1.4f, 0.5f);
                PerformTest(testSetup, "cell_06.csv");
            }
            foreach (var seed in SEEDS_BIG)
            {
                var testSetup = new TestSetup(seed, PlayerType.UCB_V, PlayerType.UCB1, "UCBV(1.4) (0.5)", "UCB1 (2)");
                testSetup.player1.Decider.ucbvDecider = new UCBVDecider(1.4f, 0.5f);
                testSetup.player2.Decider.ucb1Decider = new UCB1Decider(2f);
                PerformTest(testSetup, "cell_06.csv");
            }
        }

        private void TestUCB1Iterations()
        {
            foreach (var iterations in ITERATIONS)
            {
                foreach (var seed in SEEDS_SMALL)
                {
                    var testSetup = new TestSetup(seed, PlayerType.GREEDY, PlayerType.UCB1, "GREEDY", $"UCB1 ({2}) ({iterations})");
                    testSetup.player2.Decider.ucb1Decider = new UCB1Decider(2f);
                    testSetup.player2.Decider.MaxIterations = iterations;
                    PerformTest(testSetup, "iterations_ucb1.csv");
                }
            }
        }

        private void TestUCBVIterations()
        {
            foreach (var iterations in ITERATIONS)
            {
                foreach (var seed in SEEDS_SMALL)
                {
                    var testSetup = new TestSetup(seed, PlayerType.GREEDY, PlayerType.UCB_V, "GREEDY", $"UCBV (1.4) (0.5) ({iterations})");
                    testSetup.player2.Decider.ucbvDecider = new UCBVDecider(1.4f, 0.5f);
                    testSetup.player2.Decider.MaxIterations = iterations;
                    PerformTest(testSetup, "iterations_ucbv.csv");
                }
            }
        }

        private void TestUCBMIterations()
        {
            foreach (var iterations in ITERATIONS)
            {
                foreach (var seed in SEEDS_SMALL)
                {
                    var testSetup = new TestSetup(seed, PlayerType.GREEDY, PlayerType.UCB_M, "GREEDY", $"UCBM (11) (1) ({iterations})");
                    testSetup.player2.Decider.ucbmDecider = new UCBMDecider(11f, 1f);
                    testSetup.player2.Decider.MaxIterations = iterations;
                    PerformTest(testSetup, "iterations_ucbm.csv");
                }
            }
        }


        private void TestUCB1Parameters()
        {
            //float[] expParams = new float[] { 
            //    0, 0.01f, 0.1f, 0.8f, 1f, 
            //    1.41f, 2f, 5f, 8f, 1000f ,
            //    3f, 11f, 0.5f, 0.09f, 1.27f};
            float[] expParams = new float[] {
                1.7f, 2.1f, 1.5f, 1.6f, 1.45f};
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
            //var calues = new List<(float, float)>()
            //{
            //    (1f, 1f), (1.1f, 1.1f), (2f, 2f), (0.8f, 0.8f), (0.9f, 1.1f),
            //    (1.68f, 0.54f), (1.8f, 0.8f), (2f, 0.9f), (1.4f, 0.5f), (2f, 0.5f),
            //    (10f, 10f), (0.1f, 0.05f), (120f, 30f), (1.7f, 0.6f), (0.9f, 0.9f)
            //};
            var calues = new List<(float, float)>()
            {
                (1.5f, 0.4f), (1.5f, 0.5f), (1.3f, 0.5f), (1.3f, 0.4f), (1.3f, 0.6f)
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
