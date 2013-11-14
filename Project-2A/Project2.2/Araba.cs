using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project2._2
{
    class Araba: IComparable<Araba>
    {
        public int islemSuresi; // iss=islem suresi
        public int sira;



        public Araba(int sira, int iss)
        {
            this.sira = sira;
            this.islemSuresi = iss;
        }

        public int CompareTo(Araba ar)
        {
            return this.islemSuresi.CompareTo(ar.islemSuresi);
        }
       


        public override String ToString() {

            return "Sıra no:\t" + sira + "İslem suresi:\t" + islemSuresi;
        }
    }
}
