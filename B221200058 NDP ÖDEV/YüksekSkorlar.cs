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

namespace NdpOdev
{
    public partial class YüksekSkorlar : Form
    {
        public YüksekSkorlar()
        {
            InitializeComponent();
            YuksekSkorlarıGoster();
        }

        private void YuksekSkorlarıGoster()
        {
            var highScores = SkorYonetimi.EnYuksek5SkoruGetir();

            listViewHighScores.Items.Clear();

            foreach (var score in highScores)
            {
                ListViewItem item = new ListViewItem(score.OyuncuAdı);
                item.SubItems.Add(score.Skor.ToString());
                listViewHighScores.Items.Add(item);
            }
        }
    }
}
