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

        public void Ekle(Araba araba)
        {
            arabaKuyrugu.Add(araba);
        }

        public Araba Cikar()
        {
            Araba temp = arabaKuyrugu[0];
            arabaKuyrugu.RemoveAt(0);
            return temp;
        }
        public Araba ElementAt(int n)
        {
            return arabaKuyrugu[n];
        }
        public int Count { get { return arabaKuyrugu.Count; } }
    }
}
