using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watermark
{
    class islemler
    {
        public Int32 maxDegerHesapla (int resimYuksekligi, int resimGenisligi)
        {
            //if text == 0111;
            Int32 sonuc = (resimYuksekligi * resimGenisligi) - 4;
            return sonuc;
        }
    }
}
