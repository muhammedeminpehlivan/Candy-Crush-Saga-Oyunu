namespace NdpOdev
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            textBox1 = new TextBox();
            btnPlay = new Button();
            scoreButton = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Khaki;
            label2.Font = new Font("Snap ITC", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(277, 24);
            label2.Name = "label2";
            label2.Size = new Size(265, 48);
            label2.TabIndex = 1;
            label2.Text = "Oyuncu Adı";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ScrollBar;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox1.Location = new Point(294, 76);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(248, 31);
            textBox1.TabIndex = 2;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = SystemColors.Info;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Font = new Font("Snap ITC", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlay.ForeColor = Color.Black;
            btnPlay.Location = new Point(12, 326);
            btnPlay.Margin = new Padding(3, 4, 3, 4);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(206, 101);
            btnPlay.TabIndex = 1;
            btnPlay.Text = "Oyna";
            btnPlay.UseMnemonic = false;
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // scoreButton
            // 
            scoreButton.BackColor = SystemColors.Info;
            scoreButton.FlatAppearance.BorderSize = 0;
            scoreButton.FlatStyle = FlatStyle.Flat;
            scoreButton.Font = new Font("Snap ITC", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            scoreButton.ForeColor = Color.Black;
            scoreButton.Location = new Point(620, 320);
            scoreButton.Margin = new Padding(3, 4, 3, 4);
            scoreButton.Name = "scoreButton";
            scoreButton.Size = new Size(204, 119);
            scoreButton.TabIndex = 1;
            scoreButton.Text = "En Yüksek Skorlar";
            scoreButton.UseMnemonic = false;
            scoreButton.UseVisualStyleBackColor = false;
            scoreButton.Click += scoreButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            BackgroundImage = Properties.Resources.candy_crush_revenue_2018__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(836, 656);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(scoreButton);
            Controls.Add(btnPlay);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox textBox1;
        private Button btnPlay;
        private Button scoreButton;
    }
}
