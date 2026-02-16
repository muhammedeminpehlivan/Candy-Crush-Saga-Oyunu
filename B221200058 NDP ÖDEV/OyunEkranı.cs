/******************************************************************************
 *                                                                            *
 *                            ÖDEV PROJESİ                                    *
 *                                                                            *
 *               İsim        : MUHAMMED EMİN                                  *
 *               Soyisim     : PEHLİVAN                                       *
 *               Ders        : NESNEYE DAYALI PROGRAMLAMA                     *
 *               Tarih       : 03.01.2025                                     *
 *               Numara      : B221200058                                     *
 *                                                                            *
 ******************************************************************************/


using NdpOdev.Mekanik;
using NdpOdev.Sınıflar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace NdpOdev
{
    public partial class OyunEkranı : Form
    {
        private int timerCount = 90;
        private int skor = 0;
        private string oyuncuAdi;
        private bool isPaused = false;
        public OyunEkranı(string oyuncuAdi)
        {
            InitializeComponent();
            this.oyuncuAdi = oyuncuAdi;
        }

        private void OyunEkranı_Load(object sender, EventArgs e)
        {
            lblPlayer.Text = $"Oyuncu: {oyuncuAdi}";
            InitializeGameBoard();
            timer1.Start();
        }

       private void InitializeGameBoard()
{
    int tileSize = 50; // Her kutucuk boyutu
    for (int row = 0; row < 9; row++)
    {
        for (int col = 0; col < 9; col++)
        {
            try
            {
                Button tile = new Button();
                tile.Size = new Size(tileSize, tileSize);
                tile.Location = new Point(col * tileSize, row * tileSize);
                tile.FlatStyle = FlatStyle.Flat;

                Sekiller shape = SekilYonetimi.RastgeleSekilGetir();

                if (shape == null)
                {
                    throw new InvalidOperationException("RastgeleSekilGetir metodu null döndü.");
                }

                if (shape.Simge != null)
                {
                    tile.BackgroundImage = shape.Simge;
                    tile.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    Console.WriteLine($"[UYARI] Şekil simgesi boş: {shape.Isim}");
                }

                if (shape.JokerMi)
                    tile.BackColor = Color.Gold;

                tile.Tag = shape;
                tile.Click += Tile_Click;

                gamePanel.Controls.Add(tile);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HATA] Buton oluşturulurken hata oluştu: {ex.Message}");
            }
        }
    }
}


        private Button selectedTile = null;

        private async void Tile_Click(object sender, EventArgs e)
        {
            if (isPaused) return;

            Button clickedTile = sender as Button;

            if (clickedTile == null || clickedTile.Tag == null)
            {
                MessageBox.Show("Geçersiz taş seçildi. Lütfen geçerli bir taş seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Sekiller clickedShape = clickedTile?.Tag as Sekiller;

            if (clickedShape != null && clickedShape.JokerMi)
            {
                int jokerScore = await Joker.JokeriAktiflestir(clickedTile, gamePanel);
                skor += jokerScore;
                lblScore.Text = $"Skor: {skor}";

                await OyunMekanigi.EslesmeleriKontrolEtVeIsle(gamePanel, this.BackColor);
                return;
            }

            if (selectedTile == null)
            {
                selectedTile = clickedTile;
                selectedTile.BackColor = Color.Yellow;
            }
            else
            {
                if (OyunMekanigi.YanyanalarMi(selectedTile, clickedTile))
                {
                    OyunMekanigi.TaslariYerDegistir(selectedTile, clickedTile);
                    int gainedScore = await OyunMekanigi.EslesmeleriKontrolEtVeIsle(gamePanel, this.BackColor);

                    skor += gainedScore;
                    lblScore.Text = $"Skor: {skor}";
                }
                else
                {
                    MessageBox.Show("UYGUN OLMAYAN YER DEĞİŞTİRME");
                }

                selectedTile.BackColor = Color.Transparent;
                selectedTile = null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerCount--;
            lblTimer.Text = $"Süre: {timerCount}";
            if (timerCount <= 0)
            {
                timer1.Stop();
                MessageBox.Show($"Oyun Bitti! Toplam Skorunuz: {skor}");

                SkorYonetimi.YuksekSkorEkle(oyuncuAdi, skor);
                SkorYonetimi.YuksekSkorlariYukle();

                YüksekSkorlar yüksekSkorlar = new YüksekSkorlar();
                yüksekSkorlar.ShowDialog();

                this.Close();
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                timer1.Stop();
                isPaused = true;
             
                pauseButton.Text = "";
            }
            else
            {
                timer1.Start();
                isPaused = false;
                pauseButton.Text = "";
            }
        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }
    }
}
