using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace watermark
{
    class islemler
    {
        public Bitmap metinGizle(string renkPaleti, Bitmap resim, string binaryMetin)
        {
            Bitmap yenigorsel = new Bitmap(resim);
            if (renkPaleti == "RGB")
            {
                if (binaryMetin.Length % 3 == 1)
                {
                    binaryMetin += "00";
                }
                else if (binaryMetin.Length % 3 == 2)
                {
                    binaryMetin += "0";
                }
                int i = 0;
                for (int y = 0; y < resim.Height; y++)
                {
                    for (int x = 0; x < resim.Width; x++)
                    {
                        if (y == 0 && x == 0)
                        {
                            x = x + 7;
                        }
                        if (i < binaryMetin.Length)
                        {
                            int R = 0, G = 0, B = 0, A = 0;
                            Color piksel = resim.GetPixel(x, y);
                            string binaryR = string.Empty;
                            string binaryG = string.Empty;
                            string binaryB = string.Empty;
                            A = piksel.A;
                            R = piksel.R;
                            G = piksel.G;
                            B = piksel.B;
                            binaryR = Convert.ToString((int)piksel.R, 2);
                            binaryG = Convert.ToString((int)piksel.G, 2);
                            binaryB = Convert.ToString((int)piksel.B, 2);
                            if (binaryR.Last() != binaryMetin[i])
                            {
                                if (R > 0)
                                {
                                    R = R - 1;
                                }
                                else
                                {
                                    R = R + 1;
                                }
                            }
                            if (binaryG.Last() != binaryMetin[i + 1])
                            {
                                if (G > 0)
                                {
                                    G = G - 1;
                                }
                                else
                                {
                                    G = G + 1;
                                }
                            }
                            if (binaryB.Last() != binaryMetin[i + 2])
                            {
                                if (B > 0)
                                {
                                    B = B - 1;
                                }
                                else
                                {
                                    B = B + 1;
                                }
                            }
                            Color DonusenRenk = Color.Empty;
                            DonusenRenk = Color.FromArgb(A, R, G, B);
                            yenigorsel.SetPixel(x, y, DonusenRenk);
                            i += 3;
                        }
                    }
                }
            }
            else
            {
                if (renkPaleti == "R")
                {
                    int i = 0;
                    for (int y = 0; y < resim.Height; y++)
                    {
                        for (int x = 0; x < resim.Width; x++)
                        {
                            if (y == 0 && x == 0)
                            {
                                x = x + 7;
                            }
                            if (i < binaryMetin.Length)
                            {
                                int R = 0, G = 0, B = 0, A = 0;
                                Color piksel = resim.GetPixel(x, y);
                                string binaryR = string.Empty;
                                A = piksel.A;
                                R = piksel.R;
                                G = piksel.G;
                                B = piksel.B;
                                binaryR = Convert.ToString((int)piksel.R, 2);
                                if (binaryR.Last() != binaryMetin[i])
                                {
                                    if (R > 0)
                                    {
                                        R = R - 1;
                                    }
                                    else
                                    {
                                        R = R + 1;
                                    }
                                }
                                Color DonusenRenk = Color.Empty;
                                DonusenRenk = Color.FromArgb(A, R, G, B);
                                yenigorsel.SetPixel(x, y, DonusenRenk);
                                i += 1;
                            }
                        }
                    }
                }
                else if (renkPaleti == "G")
                {
                    int i = 0;
                    for (int y = 0; y < resim.Height; y++) //gorsel.Height
                    {
                        for (int x = 0; x < resim.Width; x++) //gorsel.Width
                        {
                            if (y == 0 && x == 0)
                            {
                                x = x + 7;
                            }
                            if (i < binaryMetin.Length)
                            {
                                int R = 0, G = 0, B = 0, A = 0;
                                Color piksel = resim.GetPixel(x, y);
                                string binaryR = string.Empty;
                                string binaryG = string.Empty;
                                string binaryB = string.Empty;
                                A = piksel.A;
                                R = piksel.R;
                                G = piksel.G;
                                B = piksel.B;
                                binaryG = Convert.ToString((int)piksel.G, 2);
                                if (binaryG.Last() != binaryMetin[i])
                                {
                                    if (G > 0)
                                    {
                                        G = G - 1;
                                    }
                                    else
                                    {
                                        G = G + 1;
                                    }
                                }
                                Color DonusenRenk = Color.Empty;
                                DonusenRenk = Color.FromArgb(A, R, G, B);
                                yenigorsel.SetPixel(x, y, DonusenRenk);
                                i += 1;
                            }
                        }
                    }
                }
                else if (renkPaleti == "B")
                {
                    int i = 0;
                    for (int y = 0; y < resim.Height; y++) //gorsel.Height
                    {
                        for (int x = 0; x < resim.Width; x++) //gorsel.Width
                        {
                            if (y == 0 && x == 0)
                            {
                                x = x + 7;
                            }
                            if (i < binaryMetin.Length)
                            {
                                int R = 0, G = 0, B = 0, A = 0;
                                Color piksel = resim.GetPixel(x, y);
                                string binaryR = string.Empty;
                                string binaryG = string.Empty;
                                string binaryB = string.Empty;
                                A = piksel.A;
                                R = piksel.R;
                                G = piksel.G;
                                B = piksel.B;
                                binaryB = Convert.ToString((int)piksel.B, 2);
                                if (binaryB.Last() != binaryMetin[i])
                                {
                                    if (B > 0)
                                    {
                                        B = B - 1;
                                    }
                                    else
                                    {
                                        B = B + 1;
                                    }
                                }
                                Color DonusenRenk = Color.Empty;
                                DonusenRenk = Color.FromArgb(A, R, G, B);
                                yenigorsel.SetPixel(x, y, DonusenRenk);
                                i += 1;
                            }
                        }
                    }
                }
            }
            return yenigorsel;
        }
        public string metinSifrele(string sifre, string Metin)
        {
            string metin = string.Empty;
            //şifreleme yapılıp metin geri dönecek
            if (sifre == "rAscii")//binary metnin 
            {
                string result = string.Empty;
                string binaryText = string.Empty;
                foreach (char ch in Metin)
                {
                    string binary = string.Empty;
                    result += Convert.ToString((int)ch, 2) + "\t";
                    binary = Convert.ToString(255-((int)ch), 2);
                    if (binary.Length < 3)
                    {
                        binaryText += "000000" + binary;
                    }
                    else if (binary.Length < 4)
                    {
                        binaryText += "00000" + binary;
                    }
                    else if (binary.Length < 5)
                    {
                        binaryText += "0000" + binary;
                    }
                    else if (binary.Length < 6)
                    {
                        binaryText += "000" + binary;
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
                metin = binaryText;
            }
            else if (sifre == "steg")
            {
                //harfin ascii karakter sırasından 5 fazlasını gizleme

                string result = string.Empty;
                string binaryText = string.Empty;
                foreach (char ch in Metin)
                {
                    string binary = string.Empty;
                    result += Convert.ToString((int)ch, 2) + "\t";
                    binary = Convert.ToString(((int)ch - 5), 2);
                    if (binary.Length < 3)
                    {
                        binaryText += "000000" + binary;
                    }
                    else if (binary.Length < 4)
                    {
                        binaryText += "00000" + binary;
                    }
                    else if (binary.Length < 5)
                    {
                        binaryText += "0000" + binary;
                    }
                    else if (binary.Length < 6)
                    {
                        binaryText += "000" + binary;
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
                metin = binaryText;
            }
            else
            {
                string result = string.Empty;
                string binaryText = string.Empty;
                foreach (char ch in Metin)
                {
                    string binary = string.Empty;
                    result += Convert.ToString((int)ch, 2) + "\t";
                    binary = Convert.ToString((int)ch, 2);

                    //çevirilen binary uzunluğuna göre ekleme yapılmalı 0000-00-0 gibi
                    if (binary.Length < 3)
                    {
                        binaryText += "000000" + binary;
                    }
                    else if (binary.Length < 4)
                    {
                        binaryText += "00000" + binary;
                    }
                    else if (binary.Length < 5)
                    {
                        binaryText += "0000" + binary;
                    }
                    else if (binary.Length < 6)
                    {
                        binaryText += "000" + binary;
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
                metin = binaryText;
            }
            return metin;
        }
    }
}
