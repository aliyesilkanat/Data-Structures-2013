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
        public int beklemeSuresi;



        public Araba(int sira, int iss,int beklemeSuresi)
        {
            this.sira = sira;
            this.islemSuresi = iss;
            this.beklemeSuresi = beklemeSuresi;
        }

        public int CompareTo(Araba ar)
        {
            return this.islemSuresi.CompareTo(ar.islemSuresi);
        }
       


        public override String ToString() {

            return "Sıra no:" + sira + "\t İslem suresi:" + islemSuresi+"\t Bekleme Suresi:"+beklemeSuresi
                ;
        }
    }
}
