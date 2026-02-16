using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NdpOdev.Sınıflar
{
    public class YuksekSkorlar
    {
        public string OyuncuAdı { get; set; }
        public int Skor { get; set; }

        public YuksekSkorlar(string oyuncuAdı, int skor)
        {
            OyuncuAdı = oyuncuAdı;
            Skor = skor;
        }
    }

    public class SkorYonetimi
    {
        private static List<YuksekSkorlar> yuksekSkorlar = new List<YuksekSkorlar>();
        private static readonly string dosyaYolu = "highscores.json";

        public static void YuksekSkorlariYukle()
        {
            if (File.Exists(dosyaYolu))
            {
                string json = File.ReadAllText(dosyaYolu);
                yuksekSkorlar = JsonSerializer.Deserialize<List<YuksekSkorlar>>(json) ?? new List<YuksekSkorlar>();
            }
        }

        /// <summary>
        /// Yüksek skorları dosyaya kaydeder.
        /// </summary>
        public static void YuksekSkorlariKaydet()
        {
            string json = JsonSerializer.Serialize(yuksekSkorlar);
            File.WriteAllText(dosyaYolu, json);
        }

        /// <summary>
        /// Yeni bir yüksek skor ekler.
        /// </summary>
        public static void YuksekSkorEkle(string oyuncuAdi, int skor)
        {
            yuksekSkorlar.Add(new YuksekSkorlar(oyuncuAdi, skor));
            yuksekSkorlar = yuksekSkorlar
                .OrderByDescending(s => s.Skor)
                .Take(5)
                .ToList();

            YuksekSkorlariKaydet();
        }

        /// <summary>
        /// En yüksek 5 skoru getirir.
        /// </summary>
        public static List<YuksekSkorlar> EnYuksek5SkoruGetir()
        {
            return yuksekSkorlar.OrderByDescending(s => s.Skor).Take(5).ToList();
        }

    }
}
