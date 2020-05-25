namespace ConnectFourApplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.StartPanel = new System.Windows.Forms.Panel();
            this.timeForMove = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.gameModeCombobox = new System.Windows.Forms.ComboBox();
            this.gameModeLabel = new System.Windows.Forms.Label();
            this.mainLabel = new System.Windows.Forms.Label();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.gameSplitContainer = new System.Windows.Forms.SplitContainer();
            this.gameSplitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.buttonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.nextMoveBall = new System.Windows.Forms.Panel();
            this.timeScore = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.nextPlayerLabel = new System.Windows.Forms.Label();
            this.nextMoveLabel = new System.Windows.Forms.Label();
            this.StartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeForMove)).BeginInit();
            this.gamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameSplitContainer)).BeginInit();
            this.gameSplitContainer.Panel1.SuspendLayout();
            this.gameSplitContainer.Panel2.SuspendLayout();
            this.gameSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameSplitContainerLeft)).BeginInit();
            this.gameSplitContainerLeft.Panel1.SuspendLayout();
            this.gameSplitContainerLeft.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartPanel
            // 
            this.StartPanel.Controls.Add(this.timeForMove);
            this.StartPanel.Controls.Add(this.label1);
            this.StartPanel.Controls.Add(this.startButton);
            this.StartPanel.Controls.Add(this.gameModeCombobox);
            this.StartPanel.Controls.Add(this.gameModeLabel);
            this.StartPanel.Controls.Add(this.mainLabel);
            this.StartPanel.Location = new System.Drawing.Point(243, 66);
            this.StartPanel.Name = "StartPanel";
            this.StartPanel.Size = new System.Drawing.Size(305, 291);
            this.StartPanel.TabIndex = 0;
            // 
            // timeForMove
            // 
            this.timeForMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeForMove.Location = new System.Drawing.Point(35, 176);
            this.timeForMove.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.timeForMove.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeForMove.Name = "timeForMove";
            this.timeForMove.Size = new System.Drawing.Size(237, 24);
            this.timeForMove.TabIndex = 5;
            this.timeForMove.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(35, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Time for move:";
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startButton.Location = new System.Drawing.Point(78, 215);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(145, 50);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Play!";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // gameModeCombobox
            // 
            this.gameModeCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gameModeCombobox.FormattingEnabled = true;
            this.gameModeCombobox.Location = new System.Drawing.Point(35, 108);
            this.gameModeCombobox.Name = "gameModeCombobox";
            this.gameModeCombobox.Size = new System.Drawing.Size(237, 26);
            this.gameModeCombobox.TabIndex = 2;
            // 
            // gameModeLabel
            // 
            this.gameModeLabel.AutoSize = true;
            this.gameModeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gameModeLabel.Location = new System.Drawing.Point(31, 80);
            this.gameModeLabel.Name = "gameModeLabel";
            this.gameModeLabel.Size = new System.Drawing.Size(120, 24);
            this.gameModeLabel.TabIndex = 1;
            this.gameModeLabel.Text = "Game mode:";
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mainLabel.Location = new System.Drawing.Point(76, 31);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(147, 31);
            this.mainLabel.TabIndex = 0;
            this.mainLabel.Text = "Connect 4";
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gamePanel
            // 
            this.gamePanel.Controls.Add(this.gameSplitContainer);
            this.gamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamePanel.Location = new System.Drawing.Point(0, 0);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(835, 661);
            this.gamePanel.TabIndex = 1;
            // 
            // gameSplitContainer
            // 
            this.gameSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gameSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.gameSplitContainer.Name = "gameSplitContainer";
            // 
            // gameSplitContainer.Panel1
            // 
            this.gameSplitContainer.Panel1.Controls.Add(this.gameSplitContainerLeft);
            // 
            // gameSplitContainer.Panel2
            // 
            this.gameSplitContainer.Panel2.Controls.Add(this.nextMoveBall);
            this.gameSplitContainer.Panel2.Controls.Add(this.timeScore);
            this.gameSplitContainer.Panel2.Controls.Add(this.timeLabel);
            this.gameSplitContainer.Panel2.Controls.Add(this.nextPlayerLabel);
            this.gameSplitContainer.Panel2.Controls.Add(this.nextMoveLabel);
            this.gameSplitContainer.Size = new System.Drawing.Size(835, 661);
            this.gameSplitContainer.SplitterDistance = 630;
            this.gameSplitContainer.TabIndex = 0;
            // 
            // gameSplitContainerLeft
            // 
            this.gameSplitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameSplitContainerLeft.IsSplitterFixed = true;
            this.gameSplitContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.gameSplitContainerLeft.Name = "gameSplitContainerLeft";
            this.gameSplitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // gameSplitContainerLeft.Panel1
            // 
            this.gameSplitContainerLeft.Panel1.Controls.Add(this.buttonPanel);
            // 
            // gameSplitContainerLeft.Panel2
            // 
            this.gameSplitContainerLeft.Panel2.BackColor = System.Drawing.Color.Maroon;
            this.gameSplitContainerLeft.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.gameSplitContainerLeft_Panel2_Paint);
            this.gameSplitContainerLeft.Size = new System.Drawing.Size(630, 661);
            this.gameSplitContainerLeft.SplitterDistance = 116;
            this.gameSplitContainerLeft.TabIndex = 0;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.button1);
            this.buttonPanel.Controls.Add(this.button2);
            this.buttonPanel.Controls.Add(this.button3);
            this.buttonPanel.Controls.Add(this.button4);
            this.buttonPanel.Controls.Add(this.button5);
            this.buttonPanel.Controls.Add(this.button6);
            this.buttonPanel.Controls.Add(this.button7);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(630, 116);
            this.buttonPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 100);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(93, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 100);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(183, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 100);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(273, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 100);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(363, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 100);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(453, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(84, 100);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(543, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(84, 100);
            this.button7.TabIndex = 6;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // nextMoveBall
            // 
            this.nextMoveBall.Location = new System.Drawing.Point(28, 509);
            this.nextMoveBall.Name = "nextMoveBall";
            this.nextMoveBall.Size = new System.Drawing.Size(140, 140);
            this.nextMoveBall.TabIndex = 5;
            this.nextMoveBall.Paint += new System.Windows.Forms.PaintEventHandler(this.nextMoveBall_Paint_1);
            // 
            // timeScore
            // 
            this.timeScore.AutoSize = true;
            this.timeScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeScore.Location = new System.Drawing.Point(3, 370);
            this.timeScore.Name = "timeScore";
            this.timeScore.Size = new System.Drawing.Size(0, 31);
            this.timeScore.TabIndex = 4;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeLabel.Location = new System.Drawing.Point(8, 326);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(185, 31);
            this.timeLabel.TabIndex = 3;
            this.timeLabel.Text = "Time to move:";
            // 
            // nextPlayerLabel
            // 
            this.nextPlayerLabel.AutoSize = true;
            this.nextPlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nextPlayerLabel.Location = new System.Drawing.Point(8, 465);
            this.nextPlayerLabel.Name = "nextPlayerLabel";
            this.nextPlayerLabel.Size = new System.Drawing.Size(0, 31);
            this.nextPlayerLabel.TabIndex = 2;
            // 
            // nextMoveLabel
            // 
            this.nextMoveLabel.AutoSize = true;
            this.nextMoveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nextMoveLabel.Location = new System.Drawing.Point(8, 421);
            this.nextMoveLabel.Name = "nextMoveLabel";
            this.nextMoveLabel.Size = new System.Drawing.Size(151, 31);
            this.nextMoveLabel.TabIndex = 1;
            this.nextMoveLabel.Text = "Next move:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 661);
            this.Controls.Add(this.StartPanel);
            this.Controls.Add(this.gamePanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.StartPanel.ResumeLayout(false);
            this.StartPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeForMove)).EndInit();
            this.gamePanel.ResumeLayout(false);
            this.gameSplitContainer.Panel1.ResumeLayout(false);
            this.gameSplitContainer.Panel2.ResumeLayout(false);
            this.gameSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameSplitContainer)).EndInit();
            this.gameSplitContainer.ResumeLayout(false);
            this.gameSplitContainerLeft.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameSplitContainerLeft)).EndInit();
            this.gameSplitContainerLeft.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel StartPanel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ComboBox gameModeCombobox;
        private System.Windows.Forms.Label gameModeLabel;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.SplitContainer gameSplitContainer;
        private System.Windows.Forms.SplitContainer gameSplitContainerLeft;
        private System.Windows.Forms.FlowLayoutPanel buttonPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label nextPlayerLabel;
        private System.Windows.Forms.Label nextMoveLabel;
        private System.Windows.Forms.Label timeScore;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Panel nextMoveBall;
        private System.Windows.Forms.NumericUpDown timeForMove;
        private System.Windows.Forms.Label label1;
    }
}

