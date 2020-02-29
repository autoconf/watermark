using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace watermark
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        islemler islem = new islemler();
        private void goruntuSecPictureBox_Click(object sender, EventArgs e)
        {
            int goruntuYuksekligi = 0, goruntuGenisligi = 0;
            try
            { 
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png; *.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    goruntuSecPictureBox.Image = new Bitmap(open.FileName);
                    goruntuYuksekligi = goruntuSecPictureBox.Image.Height;
                    goruntuGenisligi = goruntuSecPictureBox.Image.Width;
                    Int32 max = islem.maxDegerHesapla(goruntuYuksekligi, goruntuGenisligi);
                    metinRichTextBox.Enabled = true;
                    maxDegerLabel.Text = "Max : " + string.Format("{0:0,0}", max).Replace(",", ".");
                    metinRichTextBox.MaxLength = max;
                }
            }
            catch
            {
                MessageBox.Show("Görüntü Seçiminde Hata");
            }
        }

        private void metinRichTextBox_TextChanged(object sender, EventArgs e)
        {
            Int32 max = metinRichTextBox.MaxLength - metinRichTextBox.Text.Length;
            maxDegerLabel.Text = "Max : " + string.Format("{0:0,0}", max).Replace(",", ".");
            if (max < 10)
            {
                maxDegerLabel.ForeColor = Color.Red;
                try
                {
                    if (max < 1)
                    {
                        MessageBox.Show("Bu görüntü için maksimum karakter sınırına ulaştınız, daha fazla karakter girişi yapamazsınız.\nLütfen Metni kısaltın yada Görüntüyü değiştirin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {

                }
            }
            else
            {
                maxDegerLabel.ForeColor = Color.Black;
            }
            
            
        }
    }
}
