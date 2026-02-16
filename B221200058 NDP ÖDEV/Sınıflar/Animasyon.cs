using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NdpOdev.Sınıflar
{
    public class Animasyon
    {
        public static async Task BaloncukAnimasyonu(List<Button> tiles, Color backgroundColor)
        {
            foreach (var tile in tiles)
            {
                tile.BackColor = backgroundColor;
                tile.BackgroundImage = null;
                tile.Tag = null;

                // Hafif şeffaf bir baloncuk efekti
                for (int i = 0; i < 3; i++)
                {
                    tile.BackColor = Color.FromArgb(50 + (i * 50), backgroundColor);
                    await Task.Delay(100);
                }

                tile.BackColor = backgroundColor;
            }
        }
    }
}
