using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1._2
{
    class Ulke
    {
        public Ulke()
        {

        }
        public Ulke(int k,string i)
        {
            kontenjan = k;
            isim = i;
        }
        int kontenjan;

        public int Kontenjan
        {
            get { return kontenjan; }
            set { kontenjan = value; }
        }
        string isim;

        public string Isim
        {
            get { return isim; }
            set { isim = value; }
        }
        public override string ToString()
        {
            return isim + " " + kontenjan;
        }


    }
}
