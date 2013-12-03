using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_3A
{
    class EgitimDurumu
    {
        private string okulAdi;

        public string OkulAdi
        {
            get { return okulAdi; }
            set { okulAdi = value; }
        }
        private string bolumu;

        public string Bolumu
        {
            get { return bolumu; }
            set { bolumu = value; }
        }
        private string baslangicTarihi;

        public string BaslangicTarihi
        {
            get { return baslangicTarihi; }
            set { baslangicTarihi = value; }
        }
        private string bitisTarihi;

        public string BitisTarihi
        {
            get { return bitisTarihi; }
            set { bitisTarihi = value; }
        }
        private int notOrtalamasi;

        public int NotOrtalamasi
        {
            get { return notOrtalamasi; }
            set { notOrtalamasi = value; }
        }
    }
}
