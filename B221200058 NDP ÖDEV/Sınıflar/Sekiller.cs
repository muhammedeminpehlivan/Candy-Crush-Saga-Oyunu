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
    public class Sekiller
    {
        public string Isim { get; set; }
        public Image Simge { get; set; }
        public bool JokerMi { get; set; }
        public JokerTuru? JokerYetenegi { get; set; }
        public string ResimYolu { get; set; } 

        public Sekiller(string isim, string resimYolu, bool jokerMi = false, JokerTuru? yetenek = null)
        {
            Isim = isim;
            ResimYolu = resimYolu;
            JokerMi = jokerMi;
            JokerYetenegi = yetenek;

            try
            {
                Simge = Image.FromFile(resimYolu);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HATA] Şekil Simgesi yüklenemedi: {resimYolu}, {ex.Message}");
            }
        }

        public enum JokerTuru
        {
            Gokkusagi,   // Gökkuşağı
            Helikopter,  // Helikopter
            Roket,       // Roket
            YanginMuslugu // Yangın Musluğu
        }
    }
}
