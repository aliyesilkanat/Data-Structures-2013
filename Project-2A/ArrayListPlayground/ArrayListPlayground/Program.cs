using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ArrayListPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();
            List<Urunler> urunler0 = new List<Urunler>();
            List<Urunler> urunler1 = new List<Urunler>();
            List<Urunler> urunler2 = new List<Urunler>();
            List<Urunler> urunler3 = new List<Urunler>();
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:

                        urunler0.Add(new Urunler("Masa", 110));
                        urunler0.Add(new Urunler("Sandalye", 50));
                        urunler0.Add(new Urunler("Dolap", 75));
                        urunler0.Add(new Urunler("Kanepe", 95));

                        break;
                    case 1:
                        urunler1.Add(new Urunler("Süpürge", 80));
                        urunler1.Add(new Urunler("Fırın", 120));
                        urunler1.Add(new Urunler("Bulaşık M.", 450));
                        break;
                    case 2:
                        urunler2.Add(new Urunler("Çamaşır M.", 550));
                        urunler2.Add(new Urunler("Ütü", 50));
                        break;
                    case 3:
                        urunler3.Add(new Urunler("TV", 500));
                        break;
                }
            }
            al.Add(urunler0);
            al.Add(urunler1);
            //Liste içindeki urunler ekrana yazdırıyoruz.
            foreach (Urunler urun in urunler0)
            {
                Console.WriteLine(urun.adi + " " + urun.fiyat);
            }
            foreach (Urunler urun in urunler1)
            {
                Console.WriteLine(urun.adi + " " + urun.fiyat);
            }
            foreach (Urunler urun in urunler2)
            {
                Console.WriteLine(urun.adi + " " + urun.fiyat);
            }
            foreach (Urunler urun in urunler3)
            {
                Console.WriteLine(urun.adi + " " + urun.fiyat);
            }

            foreach (Urunler item in (al[0] as List<Urunler>))
            {
                Console.WriteLine(item.adi);
            }
            Console.ReadLine();
        }   

    }
    class Urunler
    {
        public string adi;
        public int fiyat;
        public Urunler(string adi, int fiyat)
        {
            this.adi = adi;
            this.fiyat = fiyat;
        }
    }
}
