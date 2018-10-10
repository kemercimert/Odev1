using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev1
{
    public partial class Form1 : Form
    {
        Bitmap kaynak, islem;
        public Form1()
        {
            InitializeComponent();
        }

        private void ortalamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;

            islem = new Bitmap(gen, yuk);

            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {
                    Color renkliRenk = kaynak.GetPixel(x, y);
                    int gri = (renkliRenk.R + renkliRenk.G + renkliRenk.B) / 3;
                    Color griRenk = Color.FromArgb(gri, gri, gri);
                    islem.SetPixel(x, y, griRenk);
                }
            }

            pictureBox2.Image = islem;
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PNG|*.png";
            DialogResult sonuc = saveFileDialog1.ShowDialog();
            ImageFormat format = ImageFormat.Png;
            if (sonuc == DialogResult.OK)
            {
                islem.Save(saveFileDialog1.FileName, format);
            }
        }

        private void bT709ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;

            islem = new Bitmap(gen, yuk);

            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {

                    Color renkliRenk = kaynak.GetPixel(x, y);
                    int gri = ((renkliRenk.R * 2125 / 10000) + (renkliRenk.G * 7154 / 10000) + (renkliRenk.B * 72 / 1000));
                    Color griRenk = Color.FromArgb(gri, gri, gri);
                    islem.SetPixel(x, y, griRenk);
                }
            }
            pictureBox2.Image = islem;
        }

        private void lumaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;

            islem = new Bitmap(gen, yuk);

            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {

                    Color renkliRenk = kaynak.GetPixel(x, y);
                    int gri = ((renkliRenk.R * 3 / 10) + (renkliRenk.G * 59 / 100) + (renkliRenk.B * 11 / 100));
                    Color griRenk = Color.FromArgb(gri, gri, gri);
                    islem.SetPixel(x, y, griRenk);
                }
            }
            pictureBox2.Image = islem;
        }

        private void açıklıkYöntemiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gri;
            int gen = kaynak.Width;
            int yuk = kaynak.Height;

            islem = new Bitmap(gen, yuk);

            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {
                    Color renkliRenk = kaynak.GetPixel(x, y);

                    int a = 0;

                    if (renkliRenk.R >= renkliRenk.G)
                        a = renkliRenk.R;
                    if (renkliRenk.R >= renkliRenk.B)
                        a = renkliRenk.R;
                    if (renkliRenk.G >= renkliRenk.R)
                        a = renkliRenk.G;
                    if (renkliRenk.G >= renkliRenk.B)
                        a = renkliRenk.G;
                    if (renkliRenk.B >= renkliRenk.R)
                        a = renkliRenk.B;
                    if (renkliRenk.B >= renkliRenk.G)
                        a = renkliRenk.B;

                    int b = 0;

                    if (renkliRenk.R <= renkliRenk.G)
                        b = renkliRenk.R;
                    if (renkliRenk.R <= renkliRenk.B)
                        b = renkliRenk.R;
                    if (renkliRenk.G <= renkliRenk.R)
                        b = renkliRenk.G;
                    if (renkliRenk.G <= renkliRenk.B)
                        b = renkliRenk.G;
                    if (renkliRenk.B <= renkliRenk.R)
                        b = renkliRenk.B;
                    if (renkliRenk.B <= renkliRenk.G)
                        b = renkliRenk.B;

                    gri = (a + b) / 2;

                    Color griRenk = Color.FromArgb(gri, gri, gri);
                    islem.SetPixel(x, y, griRenk);

                }
            }
            pictureBox2.Image = islem;
        }

        private void kanalÇıkarımıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;

            islem = new Bitmap(gen, yuk);

            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {

                    Color renkliRenk = kaynak.GetPixel(x, y);
                    int gri = (renkliRenk.R | renkliRenk.G | renkliRenk.B);
                    Color griRenk = Color.FromArgb(gri, gri, gri);
                    islem.SetPixel(x, y, griRenk);
                }
            }
            pictureBox2.Image = islem;
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = openFileDialog1.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                kaynak = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = kaynak;
            }
        }
    }
}
