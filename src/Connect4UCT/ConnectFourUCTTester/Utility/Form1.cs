using ConnectFourApplication;
using ConnectFourApplication.GameManager;
using MonteCarloTreeSearchLib.Algorithm;
using System.Windows.Forms;

namespace ConnectFourUCTTester
{
    public partial class Form1 : Form
    {
        private static int[] SEEDS = new int[] { 93715, 62735, 42394, 12312, 50452, 22323, 39123, 75675, 12392, 11221 };
        
        public Form1()
        {
            InitializeComponent();
            TestUCB1Parameters();
        }

        private void TestUCB1Parameters()
        {
            float[] expParams = new float[] { 0, 0.01f, 0.1f, 0.8f, 1f, 1.41f, 2f, 5f, 8f, 1000f};
            foreach (var expParam in expParams)
            {
                foreach (var seed in SEEDS)
                {
                    var testSetup = new TestSetup(seed, PlayerType.GREEDY, PlayerType.UCB1, "GREEDY", $"UCB1 ({expParam})");
                    testSetup.player2.Decider.ucb1Decider = new UCB1Decider(expParam);
                    PerformTest(testSetup);
                }
            }
        }

        private void PerformTest(TestSetup testSetup)
        {
            RandomUtils.SetSeed(testSetup.rngSeed);
            using (GameForm form = new GameForm())
            {
                var tracker = new GameTracker(form, testSetup.player1Name, testSetup.player2Name, "params_ucb1.csv");
                form.Show();
                form.PerformTest(testSetup.player1, testSetup.player2, testSetup.player1Strategy, testSetup.player2Strategy);
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
