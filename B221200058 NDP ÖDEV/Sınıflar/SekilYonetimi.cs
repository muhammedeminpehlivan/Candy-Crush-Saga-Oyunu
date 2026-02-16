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




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace NdpOdev.Sınıflar
{
    public class SekilYonetimi
    {
        public static List<Sekiller> NormalSekiller { get; private set; } = new List<Sekiller>();
        public static List<Sekiller> JokerSekiller { get; private set; } = new List<Sekiller>();

        static SekilYonetimi()
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resimler");

            // Normal Taşlar
            NormalSekiller.Add(new Sekiller("Üzüm", Path.Combine(basePath, "elma.png")));
            NormalSekiller.Add(new Sekiller("Elma", Path.Combine(basePath, "armut.png")));
            NormalSekiller.Add(new Sekiller("Muz", Path.Combine(basePath, "muz.png")));
            NormalSekiller.Add(new Sekiller("Armut", Path.Combine(basePath, "üzüm.png")));

            // Joker Taşlar
            JokerSekiller.Add(new Sekiller("Gökkuşağı", Path.Combine(basePath, "gokkusagi.png"), true, Sekiller.JokerTuru.Gokkusagi));
            JokerSekiller.Add(new Sekiller("Helikopter", Path.Combine(basePath, "helikopter.png"), true, Sekiller.JokerTuru.Helikopter));
            JokerSekiller.Add(new Sekiller("Roket", Path.Combine(basePath, "roket.png"), true, Sekiller.JokerTuru.Roket));
            JokerSekiller.Add(new Sekiller("Yangın Musluğu", Path.Combine(basePath, "yangın.png"), true, Sekiller.JokerTuru.YanginMuslugu));
        }

        public static Sekiller RastgeleSekilGetir()
        {
            Random random = new Random();

            if (random.Next(1, 21) == 1) // %5 Joker Olasılığı
            {
                return JokerSekiller[random.Next(JokerSekiller.Count)];
            }
            else
            {
                return NormalSekiller[random.Next(NormalSekiller.Count)];
            }
        }
    }
}
