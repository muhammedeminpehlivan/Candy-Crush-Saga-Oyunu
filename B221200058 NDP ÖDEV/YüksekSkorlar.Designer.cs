namespace NdpOdev
{
    partial class YüksekSkorlar
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
            lblTitle = new Label();
            listViewHighScores = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Comic Sans MS", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(89, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(303, 45);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "En Yüksek Skorlar";
            // 
            // listViewHighScores
            // 
            listViewHighScores.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewHighScores.Font = new Font("Comic Sans MS", 12F);
            listViewHighScores.FullRowSelect = true;
            listViewHighScores.GridLines = true;
            listViewHighScores.Location = new Point(39, 92);
            listViewHighScores.Name = "listViewHighScores";
            listViewHighScores.Size = new Size(400, 300);
            listViewHighScores.TabIndex = 3;
            listViewHighScores.UseCompatibleStateImageBehavior = false;
            listViewHighScores.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Oyuncu Adı";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Skor";
            columnHeader2.Width = 100;
            // 
            // YüksekSkorlar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 444);
            Controls.Add(listViewHighScores);
            Controls.Add(lblTitle);
            Name = "YüksekSkorlar";
            Text = "YüksekSkorlar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private ListView listViewHighScores;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}