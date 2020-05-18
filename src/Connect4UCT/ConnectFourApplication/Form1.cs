using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFourApplication
{
    public partial class Form1 : Form
    {
        private Game _game;
        const int BALL_SIZE = 90;
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
            gameModeCombobox.SelectedIndex = 1;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Disable(StartPanel);
            Enable(gamePanel);
            Mode mode = ModeConverter.GetModeConverter().GetMode(gameModeCombobox.SelectedItem.ToString());
            _game = new Game(mode,60);
            InitializeArea();
        }

        private void InitializeArea()
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

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
            g.FillEllipse(sb, new Rectangle(x-r, y-r, 2*r, 2*r));
            sb.Dispose();
            g.Dispose();
        }

        private void gameSplitContainerLeft_Panel2_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(gameSplitContainerLeft.Panel2);
        }

        private void DrawBoard(Control c)
        {
            for (int x = 0; x < 7; x++)
                for (int y = 0; y < 6; y++)
                    DrawCircle(c, Color.Black, BALL_SIZE/2 + x * BALL_SIZE, BALL_SIZE/2 + y * BALL_SIZE, BALL_SIZE / 2);
        }
        private void nextMoveBall_Paint_1(object sender, PaintEventArgs e)
        {
            DrawCircle(nextMoveBall, Color.Yellow, 97, 72, 52);
        }
    }
}
