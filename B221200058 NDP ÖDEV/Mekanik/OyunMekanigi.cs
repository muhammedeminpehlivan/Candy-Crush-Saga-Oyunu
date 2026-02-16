using NdpOdev.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NdpOdev.Sınıflar.Sekiller;

namespace NdpOdev.Mekanik
{
    public class OyunMekanigi
    {
        public static async Task<int> EslesmeleriKontrolEtVeIsle(Panel oyunPaneli, Color arkaPlanRengi)
        {
            List<Button> eslesenTaslar = new List<Button>();
            int puanArtisi = 0;

            // Yatay kontrol
            for (int satir = 0; satir < 9; satir++)
            {
                for (int sutun = 0; sutun < 7; sutun++)
                {
                    var tas1 = TasAl(oyunPaneli, satir, sutun);
                    var tas2 = TasAl(oyunPaneli, satir, sutun + 1);
                    var tas3 = TasAl(oyunPaneli, satir, sutun + 2);

                    if (tas1.Tag != null && tas1.Tag == tas2.Tag && tas2.Tag == tas3.Tag)
                    {
                        eslesenTaslar.Add(tas1);
                        eslesenTaslar.Add(tas2);
                        eslesenTaslar.Add(tas3);
                    }
                }
            }

            // Dikey kontrol
            for (int sutun = 0; sutun < 9; sutun++)
            {
                for (int satir = 0; satir < 7; satir++)
                {
                    var tas1 = TasAl(oyunPaneli, satir, sutun);
                    var tas2 = TasAl(oyunPaneli, satir + 1, sutun);
                    var tas3 = TasAl(oyunPaneli, satir + 2, sutun);

                    if (tas1.Tag != null && tas1.Tag == tas2.Tag && tas2.Tag == tas3.Tag)
                    {
                        eslesenTaslar.Add(tas1);
                        eslesenTaslar.Add(tas2);
                        eslesenTaslar.Add(tas3);
                    }
                }
            }

            if (eslesenTaslar.Count > 0)
            {
                puanArtisi = eslesenTaslar.Count * 10;
                await Animasyon.BaloncukAnimasyonu(eslesenTaslar, arkaPlanRengi);
                TaslariDusur(oyunPaneli);
                puanArtisi += await EslesmeleriKontrolEtVeIsle(oyunPaneli, arkaPlanRengi); // Yeni eşleşmeleri kontrol et
            }

            return puanArtisi;
        }

        protected static Button TasAl(Panel panel, int satir, int sutun)
        {
            return panel.Controls[satir * 9 + sutun] as Button;
        }

        protected static void TaslariDusur(Panel oyunPaneli)
        {
            for (int sutun = 0; sutun < 9; sutun++)
            {
                for (int satir = 8; satir >= 0; satir--)
                {
                    var mevcutTas = TasAl(oyunPaneli, satir, sutun);
                    if (mevcutTas.Tag == null)
                    {
                        for (int ustSatir = satir - 1; ustSatir >= 0; ustSatir--)
                        {
                            var ustTas = TasAl(oyunPaneli, ustSatir, sutun);
                            if (ustTas.Tag != null)
                            {
                                mevcutTas.Tag = ustTas.Tag;
                                mevcutTas.BackgroundImage = ustTas.BackgroundImage;
                                mevcutTas.BackColor = ustTas.BackColor; // Arka plan rengini taşı

                                ustTas.Tag = null;
                                ustTas.BackgroundImage = null;
                                ustTas.BackColor = Color.Transparent; // Üstteki taşın arka plan rengini temizle
                                break;
                            }
                        }
                    }
                }
            }

            // Boş olan kutucuklara yeni nesneler ekle
            for (int sutun = 0; sutun < 9; sutun++)
            {
                for (int satir = 0; satir < 9; satir++)
                {
                    var tas = TasAl(oyunPaneli, satir, sutun);
                    if (tas.Tag == null)
                    {
                        var yeniSekil = SekilYonetimi.RastgeleSekilGetir();
                        tas.Tag = yeniSekil;
                        tas.BackgroundImage = yeniSekil.Simge;
                        tas.BackColor = yeniSekil.JokerMi ? Color.Gold : Color.Transparent;
                    }
                }
            }
        }

        public static void TaslariYerDegistir(Button tas1, Button tas2)
        {
            var geciciTag = tas1.Tag;
            var geciciResim = tas1.BackgroundImage;
            var geciciArkaPlanRengi = tas1.BackColor;

            tas1.Tag = tas2.Tag;
            tas1.BackgroundImage = tas2.BackgroundImage;
            tas1.BackColor = tas2.BackColor;

            tas2.Tag = geciciTag;
            tas2.BackgroundImage = geciciResim;
            tas2.BackColor = geciciArkaPlanRengi;
        }

        public static bool YanyanalarMi(Button tas1, Button tas2)
        {
            int dx = Math.Abs(tas1.Location.X - tas2.Location.X);
            int dy = Math.Abs(tas1.Location.Y - tas2.Location.Y);

            return (dx == 50 && dy == 0) || (dx == 0 && dy == 50);
        }
    }

    public class Joker : OyunMekanigi
    {
        public static async Task<int> JokeriAktiflestir(Button jokerTas, Panel oyunPaneli)
        {
            Sekiller sekil = jokerTas.Tag as Sekiller;

            if (sekil?.JokerYetenegi == null) return 0;

            int puanArtisi = 0;

            switch (sekil.JokerYetenegi)
            {
                case JokerTuru.Gokkusagi:
                    puanArtisi = GokkusagiEfektiniAktiflestir(oyunPaneli, jokerTas);
                    break;
                case JokerTuru.Helikopter:
                    puanArtisi = HelikopterEfektiniAktiflestir(jokerTas, oyunPaneli);
                    break;
                case JokerTuru.Roket:
                    puanArtisi = RoketEfektiniAktiflestir(jokerTas, oyunPaneli);
                    break;
                case JokerTuru.YanginMuslugu:
                    puanArtisi = YanginMusluguEfektiniAktiflestir(jokerTas, oyunPaneli);
                    break;
            }

            jokerTas.Tag = null;
            jokerTas.BackgroundImage = null;
            jokerTas.BackColor = Color.Transparent;

            await Task.Delay(1000);
            TaslariDusur(oyunPaneli);
            puanArtisi += await EslesmeleriKontrolEtVeIsle(oyunPaneli, Color.Transparent);

            return puanArtisi; // Joker aktivasyonundan elde edilen puan
        }

        /// <summary>
        /// Gökkuşağı (Rainbow) Joker: Belirli renkteki tüm taşları kaldırır.
        /// </summary>
        private static int GokkusagiEfektiniAktiflestir(Panel oyunPaneli, Button jokerTas)
        {
            int puanArtisi = 0;

            Button secilenTas = null;

            void Tas_Click(object sender, EventArgs e)
            {
                secilenTas = sender as Button;
            }

            foreach (Control kontrol in oyunPaneli.Controls)
            {
                if (kontrol is Button tas)
                    tas.Click += Tas_Click;
            }

            // Seçim bekleniyor
            while (secilenTas == null)
            {
                Application.DoEvents();
            }

            Sekiller secilenSekil = secilenTas.Tag as Sekiller;
            if (secilenSekil == null) return 0;

            foreach (Control kontrol in oyunPaneli.Controls)
            {
                if (kontrol is Button tas && tas.Tag is Sekiller tasSekil && tasSekil.Isim == secilenSekil.Isim)
                {
                    tas.Tag = null;
                    tas.BackgroundImage = null;
                    tas.BackColor = Color.Transparent;
                    puanArtisi += 10;
                }
            }

            return puanArtisi;
        }

        /// <summary>
        /// Helikopter Joker: Rastgele bir taşı ve çevresindekileri patlatır.
        /// </summary>
        private static int HelikopterEfektiniAktiflestir(Button jokerTas, Panel oyunPaneli)
        {
            int satir = jokerTas.Location.Y / 50;
            int sutun = jokerTas.Location.X / 50;

            int puanArtisi = 0;

            for (int i = satir; i < satir + 2 && i < 9; i++)
            {
                for (int j = sutun; j < sutun + 2 && j < 9; j++)
                {
                    Button tas = TasAl(oyunPaneli, i, j);
                    if (tas != null && tas.Tag != null)
                    {
                        tas.Tag = null;
                        tas.BackgroundImage = null;
                        tas.BackColor = Color.Transparent;
                        puanArtisi += 10;
                    }
                }
            }

            return puanArtisi;
        }

        /// <summary>
        /// Roket Joker: Yatay bir sıra temizler.
        /// </summary>
        private static int RoketEfektiniAktiflestir(Button jokerTas, Panel oyunPaneli)
        {
            int puanArtisi = 0;

            foreach (Control kontrol in oyunPaneli.Controls)
            {
                if (kontrol is Button tas && (tas.Location.Y == jokerTas.Location.Y))
                {
                    tas.Tag = null;
                    tas.BackgroundImage = null;
                    tas.BackColor = Color.Transparent;
                    puanArtisi += 10;
                }
            }

            return puanArtisi;
        }

        /// <summary>
        /// Yangın Musluğu Joker: Bir sütunu tamamen temizler.
        /// </summary>
        private static int YanginMusluguEfektiniAktiflestir(Button jokerTas, Panel oyunPaneli)
        {
            int sutun = jokerTas.Location.X / 50;
            int puanArtisi = 0;

            for (int satir = 0; satir < 9; satir++)
            {
                Button tas = TasAl(oyunPaneli, satir, sutun);
                if (tas != null && tas.Tag != null)
                {
                    tas.Tag = null;
                    tas.BackgroundImage = null;
                    tas.BackColor = Color.Transparent;
                    puanArtisi += 10;
                }
            }

            return puanArtisi;
        }
    }
}
