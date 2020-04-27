﻿using System;
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
            Int32 max = ((goruntuGenisligi / 8) * goruntuYuksekligi) * 3;
            //şifreleme
            sifreYokLabel.Text = "Max : " + (max - 1).ToString();
            sifreAsciiLabel.Text = "Max : " + (max - 1).ToString();
            sifreStegLabel.Text = "Max : " + (max - 1).ToString();
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
            tumPikselLabel.Text = "Max : " + (max - 1).ToString();
            tekPikselLabel.Text = "Max : " + (max / 2 - 1).ToString();
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
            tumPaletLabel.Text = "Max : " + (max - 1).ToString();
            kirmiziPaletLabel.Text = "Max : " + (max / 3 - 1).ToString();
            yesilPaletLabel.Text = kirmiziPaletLabel.Text;
            maviPaletLabel.Text = kirmiziPaletLabel.Text;
            if (tumPaletRadioButton.Checked == true)
            {
                //5.px = 0
                //6.px = 0
                maxDegerLabel.Text = string.Format("{0:0,0}", tumPaletLabel.Text).Replace(",", ".");
                metinRichTextBox.MaxLength = (max - 1);
                metinRichTextBox.Enabled = true;
            }
            else if (kirmiziPaletRadioButton.Checked == true)
            {
                //kirmiziPaletLabel.Text = "Max : " + (max / 3).ToString();
                //5.px = 0
                //6.px = 1
                max = max / 3;
                maxDegerLabel.Text = string.Format("{0:0,0}", kirmiziPaletLabel.Text).Replace(",", ".");
                metinRichTextBox.MaxLength = (max - 1);
                metinRichTextBox.Enabled = true;
            }
            else if (yesilPaletRadioButton.Checked == true)
            {
                //5.px = 1
                //6.px = 0
                max = max / 3;
                maxDegerLabel.Text = string.Format("{0:0,0}", yesilPaletLabel.Text).Replace(",", ".");
                metinRichTextBox.MaxLength = (max - 1);
                metinRichTextBox.Enabled = true;
            }
            else if (maviPaletRadioButton.Checked == true)
            {
                //5.px = 1
                //6.px = 1
                max = max / 3;
                maxDegerLabel.Text = string.Format("{0:0,0}", maviPaletLabel.Text).Replace(",", ".");
                metinRichTextBox.MaxLength = (max - 1);
                metinRichTextBox.Enabled = true;
            }
            // En anlamsız 2 bit işlemleri duruma göre yapılacak.. Standart şuan aktif olan LSB 1 Bit.
        }

        private void islemeBaslaButon_Click(object sender, EventArgs e)
        {
            string metin = metinRichTextBox.Text;
            
            //binary çevir
            string result = string.Empty;
            string binaryText = string.Empty;
            foreach (char ch in metin)
            {
                string binary = string.Empty;
                result += Convert.ToString((int)ch, 2) + "\t";
                binary = Convert.ToString((int)ch, 2);

                //çevirilen binary uzunluğuna göre ekleme yapılmalı 0000-00-0 gibi
                if (binary.Length < 5)
                {
                    binaryText += "0000" + binary;
                }
                else if (binary.Length < 7)
                {
                    binaryText += "00" + binary;
                }
                else if (binary.Length < 8)
                {
                    binaryText += "0" + binary;
                }
                else
                {
                    binaryText += binary;
                }
                    
            }
            MessageBox.Show("Karakter bazlı Listeleme : " + result.Length + " Karakter \n\n" +  result + "\n\nKarakter bazlı 8 Bite Tamamlanmış Listeleme : " +binaryText.Length + " Karakter \n\n" + binaryText);

            /// Checkkontrolü
            /// 
            string ilk8Piksel = checkBox_kontrolu();


            /// Görüntüye ekleme işlemi
            /// 

            metniGoruntuyeGizle(ilk8Piksel);





            //metne çevir
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < binaryText.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(binaryText.Substring(i, 8), 2));
            }
            MessageBox.Show(Encoding.ASCII.GetString(byteList.ToArray()));
        }

        private void metniGoruntuyeGizle(string ilk8piksel)
        {

        }

        private string checkBox_kontrolu()
        {
            int birinciPx = 0, ikinciPx = 0, ucuncuPx = 0, dorduncuPx = 0, besinciPx = 0, altinciPx = 1;
            //panel1
            if (sifreYokRadioButton.Checked == true)
            {
                birinciPx = 0;
                ikinciPx = 0;
            }
            else if (sifreAsciiRadioButton.Checked == true)
            {
                birinciPx = 1;
                ikinciPx = 0;
            }
            else if(sifreStegRadioButton.Checked == true)
            {
                birinciPx = 1;
                ikinciPx = 1;
            }
            //panel2
            if (tumPikselRadioButton.Checked == true)
            {
                ucuncuPx = 1;
                dorduncuPx = 0;
            }
            else if (tekPikselRadioButton.Checked == true)
            {
                ucuncuPx = 0;
                dorduncuPx = 0;
            }
            else if (ciftPikselRadioButton.Checked == true)
            {
                ucuncuPx = 0;
                dorduncuPx = 1;
            }
            //panel3
            if (tumPaletRadioButton.Checked == true)
            {
                besinciPx = 0;
                altinciPx = 0;
            }
            else if (kirmiziPaletRadioButton.Checked == true)
            {
                besinciPx = 0;
                altinciPx = 1;
            }
            else if (yesilPaletRadioButton.Checked == true)
            {
                besinciPx = 1;
                altinciPx = 0;
            }
            else if (maviPaletRadioButton.Checked == true)
            {
                besinciPx = 1;
                altinciPx = 1;
            }
            string ilk8piksel = Convert.ToString(birinciPx) + Convert.ToString(ikinciPx) + Convert.ToString(ucuncuPx) + Convert.ToString(dorduncuPx) + Convert.ToString(besinciPx) + Convert.ToString(altinciPx) + "00";
            MessageBox.Show("İlk 8 piksel : " + ilk8piksel);
            return ilk8piksel;
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
