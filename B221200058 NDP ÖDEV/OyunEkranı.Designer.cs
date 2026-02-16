namespace NdpOdev
{
    partial class OyunEkranı
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
            components = new System.ComponentModel.Container();
            lblTimer = new Label();
            lblScore = new Label();
            lblPlayer = new Label();
            gamePanel = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            pauseButton = new Button();
            SuspendLayout();
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font("Snap ITC", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimer.Location = new Point(24, 27);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(126, 27);
            lblTimer.TabIndex = 1;
            lblTimer.Text = "Süre: 90";
            lblTimer.Click += lblTimer_Click;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Snap ITC", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(15, 575);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(107, 27);
            lblScore.TabIndex = 2;
            lblScore.Text = "Skor: 0";
            // 
            // lblPlayer
            // 
            lblPlayer.AutoSize = true;
            lblPlayer.Font = new Font("Snap ITC", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlayer.Location = new Point(360, 27);
            lblPlayer.Name = "lblPlayer";
            lblPlayer.Size = new Size(170, 27);
            lblPlayer.TabIndex = 3;
            lblPlayer.Text = "Oyuncu Adı: ";
            // 
            // gamePanel
            // 
            gamePanel.BackColor = Color.RosyBrown;
            gamePanel.BorderStyle = BorderStyle.FixedSingle;
            gamePanel.Location = new Point(15, 75);
            gamePanel.Margin = new Padding(3, 4, 3, 4);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(458, 453);
            gamePanel.TabIndex = 4;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // pauseButton
            // 
            pauseButton.BackgroundImage = Properties.Resources.stopbuton;
            pauseButton.BackgroundImageLayout = ImageLayout.Zoom;
            pauseButton.Location = new Point(360, 551);
            pauseButton.Margin = new Padding(3, 4, 3, 4);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(165, 51);
            pauseButton.TabIndex = 5;
            pauseButton.Text = "\r\n";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // OyunEkranı
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            BackgroundImage = Properties.Resources.candy_crush_revenue_2018__1_;
            ClientSize = new Size(563, 748);
            Controls.Add(lblScore);
            Controls.Add(pauseButton);
            Controls.Add(gamePanel);
            Controls.Add(lblPlayer);
            Controls.Add(lblTimer);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "OyunEkranı";
            Text = "OyunEkranı";
            Load += OyunEkranı_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTimer;
        private Label lblScore;
        private Label lblPlayer;
        private Panel gamePanel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer timer1;
        private Button pauseButton;
    }
}