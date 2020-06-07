using ConnectFourApplication.GameManager;
using MonteCarloTreeSearchLib.Algorithm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectFourApplication
{
    public partial class GameForm : Form
    {
        public const int BALL_SIZE = 90;
        public event Action<int> OnMovePerformed;
        public event Action<GamePhase> OnGameEnded;
        public List<int> Moves = new List<int>();
        private Game _game;
        private bool _testLaunched = false;

        public GameForm()
        {
            InitializeComponent();
            SetupLocalization();
            SetStartValues();
            ConnectButtons();
            OnMovePerformed += HandleMovePerformed;
        }

        public void PerformTest(ComputerPlayer player1, ComputerPlayer player2)
        {
            _testLaunched = true;
            _game = new Game(player1, player2);
            startButton.PerformClick();
        }

        public new void Dispose()
        {
            base.Dispose();
            OnMovePerformed -= HandleMovePerformed;
        }

        private void ConnectButtons()
        {
            var buttons = new Button[] { button1, button2, button3, button4, button5, button6, button7 };
            foreach (var btn in buttons)
            {
                btn.Click += HandleMoveClick;
            }
        }

        private void HandleMoveClick(object sender, EventArgs e)
        {
            int btnIndex = 0;
            if (sender == button1) btnIndex = 1;
            else if (sender == button2) btnIndex = 2;
            else if (sender == button3) btnIndex = 3;
            else if (sender == button4) btnIndex = 4;
            else if (sender == button5) btnIndex = 5;
            else if (sender == button6) btnIndex = 6;
            else if (sender == button7) btnIndex = 7;
            HandlePlayerDecision(btnIndex);
        }

        private void SetStartValues()
        {
            Enable(StartPanel);
            Disable(gamePanel);
            cbxPlayer1.SelectedIndex = 0;
            cbxPlayer2.SelectedIndex = 0;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Disable(StartPanel);
            Enable(gamePanel);
            if (_testLaunched == false)
            {
                var player1 = PlayerTypeExtensions.GetPlayerType(cbxPlayer1.SelectedIndex);
                var player2 = PlayerTypeExtensions.GetPlayerType(cbxPlayer2.SelectedIndex);
                _game = new Game(player1, player2);
            }
            HandleMovePerformed(-1);
        }

        private void HandleMovePerformed(int move)
        {
            Moves.Add(move);
            if (!(_game.ActualMoving is HumanPlayer) && _game.InProgress)
            {
                int holeIndex = _game.ActualMoving.GetPlayerDecision(_game.Board);
                MakeMove(holeIndex);
                OnMovePerformed?.Invoke(holeIndex);
            }
        }

        private void HandlePlayerDecision(int column)
        {
            column--;
            if (!(_game.ActualMoving is HumanPlayer))
            {
                return;
            }

            if (_game.MoveIsPossible(column))
            {
                MakeMove(column);
            }
        }

        private void MakeMove(int column)
        {
            var result = _game.MakeMove(column);
            _game.InProgress = (result == GamePhase.InProgress);
            gamePanel.Refresh();
            nextMoveBall.Refresh();
            OnMovePerformed?.Invoke(column);
            if (result != GamePhase.InProgress)
            {
                EndGame(result);
            }
        }

        private void EndGame(GamePhase phase)
        {
            OnGameEnded?.Invoke(phase);
            if (_testLaunched)
            {
                Close();
            }
            else
            {
                string msg;
                if (phase == GamePhase.Player1Won)
                    msg = _game.Player1.GetName() + " won!";
                else if (phase == GamePhase.Player2Won)
                    msg = _game.Player2.GetName() + " won!";
                else
                    msg = "DRAW";
                MessageBox.Show(msg);
            }
        }

        private void Enable(Control control)
        {
            foreach (Control c in control.Controls)
                Enable(c);
            control.Enabled = true;
            control.Visible = true;
        }

        private void Disable(Control control)
        {
            foreach (Control c in control.Controls)
                Disable(c);
            control.Enabled = false;
            control.Visible = false;
        }

        private void DrawCircle(Control c, Color color, int x, int y, int r)
        {
            Graphics g = c.CreateGraphics();
            SolidBrush sb = new SolidBrush(color);
            g.FillEllipse(sb, new Rectangle(x - r, y - r, 2 * r, 2 * r));
            sb.Dispose();
            g.Dispose();
        }

        private void gameSplitContainerLeft_Panel2_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(gameSplitContainerLeft.Panel2);
        }

        private void DrawBoard(Control c)
        {
            var board = _game.GetBoard();
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    Color color = Color.Black;
                    if (board[y, x] == 1)
                    {
                        color = _game.Player1.Color;
                    }
                    else if (board[y, x] == 2)
                    {
                        color = _game.Player2.Color;
                    }
                    int circleX = BALL_SIZE / 2 + x * BALL_SIZE;
                    int circleY = 540 - (BALL_SIZE / 2 + y * BALL_SIZE);
                    int circleR = BALL_SIZE / 2;
                    DrawCircle(c, color, circleX, circleY, circleR);
                }
            }
        }

        private void nextMoveBall_Paint_1(object sender, PaintEventArgs e)
        {
            DrawCircle(nextMoveBall, _game.ActualMoving.Color, 70, 70, 70);
        }

        //from https://stackoverflow.com/questions/76993/how-to-double-buffer-net-controls-on-a-form
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private static void SetupLocalization()
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }
    }
}
