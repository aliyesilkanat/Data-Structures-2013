using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project2._2
{
    class Kuyruk
    {
        public List<Araba> arabaKuyrugu;

        public Kuyruk()
        {
            arabaKuyrugu = new List<Araba>();
        }

        public void ekle(Araba araba)
        {
            arabaKuyrugu.Add(araba);
        }

        public Araba cikar()
        {
            Araba temp = arabaKuyrugu[0];
            arabaKuyrugu.RemoveAt(0);
            return temp;
        }
    }
}
