using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Project2._1
{
    class Program
    {

        static void Main(string[] args)
        {
            Random r = new Random();
            Console.Write("N değerini giriniz:");
            int n = SayiAl();
            ArrayList otopark = new ArrayList();



            KatlariDoldur(otopark, r, n);
            Console.WriteLine("1) Josephus");
            Console.WriteLine("2) İşlem Süresi");
            Console.WriteLine("Seçiminiz:");
            int secim = SayiAl();
            switch (secim)
            {
                case 1:
                    {
                        KatlariYazdir(otopark);
                        TumArabalariCikar(otopark);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("3 saniyede yapılan işlem sayısı: " + IslemSay(r, otopark, n));
                        break;
                    }

            }




            Console.Read();
        }

        private static int IslemSay(Random r, ArrayList otopark, int n)
        {

            int sayac = 0;
            int start, end;

            start = DateTime.Now.Second;
            end = (start + 3) % 60;

            do
            {
                KatlariDoldur(otopark, r, n);
                for (int i = 0; i < 27; i++)
                {

                    BirArabayiCikar(otopark);

                }


                start = DateTime.Now.Second;
                sayac++;
            } while (start != end);
            return sayac;
        }

        private static void TumArabalariCikar(ArrayList otopark)
        {
            KatlariYazdir(otopark);

            Console.WriteLine("Son çıkacak olan araba (Yığının en altındaki araba): " + ((Stack<string>)otopark[1]).ElementAt(8));
            for (int i = 0; i < 27; i++)
            {

                KatlariYazdir(otopark);
                Console.WriteLine("Otoparktan çıkan araba: " + BirArabayiCikar(otopark));
                if (i < 26)
                {
                    Console.WriteLine("\nSonraki tur için bir tuşa basınız...");
                    Console.ReadKey();
                }
            }
        }

        private static string BirArabayiCikar(ArrayList otopark)
        {

            string cikanAraba = ((Queue<string>)otopark[0]).Dequeue();
            if (((Stack<string>)otopark[1]).Count != 0)
                ((Queue<string>)otopark[0]).Enqueue(((Stack<string>)otopark[1]).Pop());
            if (!((CircularList)otopark[2]).isEmpty())
                ((Stack<string>)otopark[1]).Push(((CircularList)otopark[2]).Cikar());

            return cikanAraba;

        }

        private static void KatlariYazdir(ArrayList otopark)
        {
            Console.WriteLine("Birinci kat:");
            if (((Queue<string>)otopark[0]).Count == 0)
                Console.WriteLine("Katta araba yok");
            for (int i = 0; i < ((Queue<string>)otopark[0]).Count; i++)
            {
                Console.WriteLine(i + 1 + ") " + ((Queue<string>)otopark[0]).ElementAt(i));
            }

            Console.WriteLine("\nİkinci kat:");
            if (((Stack<string>)otopark[1]).Count == 0)
                Console.WriteLine("Katta araba yok");
            for (int i = 0; i < ((Stack<string>)otopark[1]).Count; i++)
            {
                Console.WriteLine(i + 1 + ") " + ((Stack<string>)otopark[1]).ElementAt(i));
            }

            Console.WriteLine("\nÜçüncü kat:");
            if (((CircularList)otopark[2]).isEmpty())
                Console.WriteLine("Katta araba yok");
            ((CircularList)otopark[2]).yazdir();
        }

        private static void KatlariDoldur(ArrayList otopark, Random r, int n)
        {
            CircularList ustKat = new CircularList(n);
            Queue<string> zeminKat = new Queue<string>();
            Stack<string> ortaKat = new Stack<string>();
            otopark.Clear();
            otopark.Add(zeminKat);
            otopark.Add(ortaKat);
            otopark.Add(ustKat);
            string[] renkler = { "Siyah", "Gümüş", "Gri", "Beyaz", "Kırmızı", "Bordo", "Mor", "Yeşil", "Sarı", "Turuncu", "Mavi", "Lacivert" };

            for (int i = 0; i < 9; i++)
            {
                ((Queue<string>)otopark[0]).Enqueue(renkler[r.Next(0, renkler.Length)]);
                ((Stack<string>)otopark[1]).Push(renkler[r.Next(0, renkler.Length)]);
                ((CircularList)otopark[2]).insertBegin(renkler[r.Next(0, renkler.Length)]);
            }
        }

        private static int SayiAl()
        {
            bool hatali;
            int secim = 0;
            do
            {
                hatali = true;
                try
                {
                    secim = Int32.Parse(Console.ReadLine());
                    hatali = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Hatalı değer girdiniz!");
                }
            } while (hatali);
            return secim;
        }




    }
}
