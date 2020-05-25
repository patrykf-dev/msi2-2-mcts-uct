using MonteCarloTreeSearchLib.Algorithm;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectFourApplication
{
    public partial class Form1 : Form
    {
        public const int BALL_SIZE = 90;
        private Game _game;
        private Timer _timer = new Timer();
        private int _timeToMove;

        public Form1()
        {
            InitializeComponent();
            SetStartValues();
        }

        private void SetStartValues()
        {
            Enable(StartPanel);
            Disable(gamePanel);
            gameModeCombobox.DataSource = ModeConverter.GetModeConverter().GetAllStrings();
            gameModeCombobox.SelectedIndex = 0;
            _timer = new Timer();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Disable(StartPanel);
            Enable(gamePanel);
            Mode mode = ModeConverter.GetModeConverter().GetMode(gameModeCombobox.SelectedItem.ToString());
            int secondsForMove = (int)timeForMove.Value;
            _game = new Game(mode, secondsForMove);
            SetTimer(_game.SecondsPerMove);
        }

        private void SetTimer(int seconds)
        {
            _timer.Stop();
            _timer = new Timer();
            _timer.Tick += new EventHandler(_timer_Tick);
            _timeToMove = seconds;
            _timer.Interval = 1000;
            _timer.Start();
            UpdatePrintedTime();
        }

        private void TryMakeMove(int column)
        {
            column--;
            if (!(_game.ActualMoving is HumanPlayer))
            {
                return;
            }

            if (_game.MoveIsPossible(column))
            {
                _timer.Stop();
                MakeMove(column);
            }
            gamePanel.Refresh();
            nextMoveBall.Refresh();
        }

        private void MakeMove(int column)
        {
            var result = _game.MakeMove(column);
            if (result == GamePhase.InProgress)
            {
                SetTimer(_game.SecondsPerMove);
            }
            else
            {
                EndGame(result);
            }
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _timeToMove--;
            UpdatePrintedTime();
            if (_timeToMove <= 0)
            {
                EndGame();
            }
        }

        private void ShowEndWindow()
        {
            Disable(gamePanel);
        }

        private void EndGame()
        {
            ShowEndWindow();
        }

        private void EndGame(GamePhase phase)
        {
            ShowEndWindow();
            string msg;
            if (phase == GamePhase.Player1Won)
                msg = _game.Player1.GetName() + " won!";
            else if (phase == GamePhase.Player2Won)
                msg = _game.Player2.GetName() + " won!";
            else
                msg = "DRAW";
            MessageBox.Show(msg);
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
                for (int y = 0; y < 6; y++)
                {
                    Color color = Color.Black;
                    if (board[y, x] == 1)
                    {
                        color = _game.Player1.GetColor();
                    }
                    else if (board[y, x] == 2)
                    {
                        color = _game.Player2.GetColor();
                    }
                    DrawCircle(c, color,
                        BALL_SIZE / 2 + x * BALL_SIZE, 540 - (BALL_SIZE / 2 + y * BALL_SIZE), BALL_SIZE / 2);
                }
        }

        private void nextMoveBall_Paint_1(object sender, PaintEventArgs e)
        {
            DrawCircle(nextMoveBall, _game.ActualMoving.GetColor(), 70, 70, 70);
        }

        private void UpdatePrintedTime()
        {
            timeScore.Text = _timeToMove.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            TryMakeMove(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TryMakeMove(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TryMakeMove(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TryMakeMove(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TryMakeMove(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TryMakeMove(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TryMakeMove(7);
        }
    }
}
