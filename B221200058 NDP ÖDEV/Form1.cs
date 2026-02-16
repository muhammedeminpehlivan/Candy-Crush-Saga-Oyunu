namespace NdpOdev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Lütfen bir oyuncu adý girin!");
                return;
            }

            OyunEkraný oyunEkraný = new OyunEkraný(textBox1.Text);
            this.Hide();
            oyunEkraný.ShowDialog();
            this.Show();
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            YüksekSkorlar yüksekSkorlar = new YüksekSkorlar();
            this.Hide();
            yüksekSkorlar.ShowDialog();
            this.Show();
        }
    }
}
