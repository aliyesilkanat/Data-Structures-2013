using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project2._2
{
    class OncelikKuyrugu
    {
        public List<Araba> alist;

        public OncelikKuyrugu()
        {
            alist = new List<Araba>();
        }

        public void ekle(Araba ar)
        {
            alist.Add(ar);
        }

        public Araba cikar()
        {
            alist.Sort();

            Araba temp = alist[0];
            alist.RemoveAt(0);
            return temp;
        }
    }
}
