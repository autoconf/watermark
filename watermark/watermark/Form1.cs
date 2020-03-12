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
            try
            { 
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.bmp)|*.png; *.jpg; *.jpeg; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    goruntuSecPictureBox.Image = new Bitmap(open.FileName);
                    panel1LabelDuzenle();
                    if (goruntuSecPictureBox.Image.Height < goruntuSecPictureBox.Height || goruntuSecPictureBox.Image.Width < goruntuSecPictureBox.Width)
                    {
                        goruntuSecPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                    else
                    {
                        goruntuSecPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
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
                    MessageBox.Show("Metin girişi yapılırken hata.");
                }
            }
            else
            {
                maxDegerLabel.ForeColor = Color.Black;
            }          
        }

        private void panel1LabelDuzenle()//checkbox kontrol
        {
            panel1.Enabled = true;
            int goruntuYuksekligi = goruntuSecPictureBox.Image.Height;
            int goruntuGenisligi = goruntuSecPictureBox.Image.Width;
            //int kontrolBitSayisi = 6;
            Int32 max = (goruntuGenisligi * goruntuYuksekligi) * 3;
            //şifreleme
            sifreYokLabel.Text = "Max : " + (max - 6).ToString();
            sifreAsciiLabel.Text = "Max : " + (max - 6).ToString();
            sifreStegLabel.Text = "Max : " + (max - 6).ToString();
            if (sifreYokRadioButton.Checked == true)
            {
                panel2LabelDuzenle(max);
                //1.px = 0
            }
            else if (sifreAsciiRadioButton.Checked == true)
            {
                panel2LabelDuzenle(max);
                 //1.px = 1
                 //2.px = 0
            }
            else if (sifreStegRadioButton.Checked == true)
            {
                panel2LabelDuzenle(max);
                //1.px = 1
                //2.px = 1
            }
            
        }

        private void panel2LabelDuzenle(Int32 max) {
            //piksel gizleme
            panel2.Enabled = true;
            tumPikselLabel.Text = "Max : " + (max - 6).ToString();
            tekPikselLabel.Text = "Max : " + ((max / 2) - 6).ToString();
            ciftPikselLabel.Text = tekPikselLabel.Text;
            if (tumPikselRadioButton.Checked == true)
            {
                panel3LabelDuzenle(max);
                //3.px = 1
            }
            else if (tekPikselRadioButton.Checked == true)
            {
                max = max / 2;
                panel3LabelDuzenle(max);
                //3.px = 0
                //4.px = 0
            }
            else if (ciftPikselRadioButton.Checked == true)
            {
                max = max / 2;
                panel3LabelDuzenle(max);
                //3.px = 0
                //4.px = 1
            }
        }

        private void panel3LabelDuzenle(Int32 max)
        {
            panel3.Enabled = true;
            //palet işlemleri
            tumPaletLabel.Text = "Max : " + (max - 6).ToString();
            kirmiziPaletLabel.Text = "Max : " + ((max / 3) - 6).ToString();
            yesilPaletLabel.Text = kirmiziPaletLabel.Text;
            maviPaletLabel.Text = kirmiziPaletLabel.Text;
            if (tumPaletRadioButton.Checked == true)
            {
                //5.px = 0
                //6.px = 0
                maxDegerLabel.Text = string.Format("{0:0,0}", tumPaletLabel.Text).Replace(",", ".");
                metinRichTextBox.MaxLength = max - 6;
                metinRichTextBox.Enabled = true;
            }
            else if (kirmiziPaletRadioButton.Checked == true)
            {
                //kirmiziPaletLabel.Text = "Max : " + (max / 3).ToString();
                //5.px = 0
                //6.px = 1
                max = max / 3;
                maxDegerLabel.Text = string.Format("{0:0,0}", kirmiziPaletLabel.Text).Replace(",", ".");
                metinRichTextBox.MaxLength = (max / 3) - 6;
                metinRichTextBox.Enabled = true;
            }
            else if (yesilPaletRadioButton.Checked == true)
            {
                //5.px = 1
                //6.px = 0
                max = max / 3;
                maxDegerLabel.Text = string.Format("{0:0,0}", yesilPaletLabel.Text).Replace(",", ".");
                metinRichTextBox.MaxLength = (max / 3) - 6;
                metinRichTextBox.Enabled = true;
            }
            else if (maviPaletRadioButton.Checked == true)
            {
                //5.px = 1
                //6.px = 1
                max = max / 3;
                maxDegerLabel.Text = string.Format("{0:0,0}", maviPaletLabel.Text).Replace(",", ".");
                metinRichTextBox.MaxLength = (max / 3) - 6;
                metinRichTextBox.Enabled = true;
            }
            // En anlamsız 2 bit işlemleri duruma göre yapılacak.. Standart şuan aktif olan LSB 1 Bit.
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void sifreYokRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            panel1LabelDuzenle();
        }

        private void sifreAsciiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            panel1LabelDuzenle();
        }

        private void sifreStegRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            panel1LabelDuzenle();
        }

        private void tumPikselRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            panel1LabelDuzenle();
        }

        private void tekPikselRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            panel1LabelDuzenle();
        }

        private void ciftPikselRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            panel1LabelDuzenle();
        }

        private void tumPaletRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            panel1LabelDuzenle();
        }

        private void kirmiziPaletRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            panel1LabelDuzenle();
        }

        private void yesilPaletRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            panel1LabelDuzenle();
        }

        private void maviPaletRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            panel1LabelDuzenle();
        }
    }
}
