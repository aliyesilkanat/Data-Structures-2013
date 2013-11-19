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
            int n = SayiAl(); //Balon problemi için kullanıcıdan n değeri alır.
            ArrayList otopark = new ArrayList();
            int secim;
            do
            {
                Console.WriteLine("1) Josephus");
                Console.WriteLine("2) İşlem Süresi");
                Console.WriteLine("3) Cıkış");
                Console.Write("Seçiminiz:");
                secim = SayiAl();
                switch (secim) //Kullanıcının seçimine göre işlem yapılır.
                {
                    case 1:
                        {
                            KatlariDoldur(otopark, r, n); //Otoparkın 3 katında bulunan veri yapılarına 9'ar adet araba yerleştirir.
                            TumArabalariCikar(otopark);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("3 saniyede yapılan işlem sayısı: " + IslemSay(r, otopark, n));
                            break;
                        }
                }
            }
            while (secim != 3);
        }

        private static int IslemSay(Random r, ArrayList otopark, int n) //3 saniyede ortalama kaç adet otopark işlemi çözebildiğini hesaplar.
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

        private static void TumArabalariCikar(ArrayList otopark)//Tüm arabalar bitene kadar bir arabanın çıkarılması işlemi tekrarlanır.
        {
            KatlariYazdir(otopark);
            Console.WriteLine();
            Console.WriteLine("Son çıkacak olan araba (Yığının en altındaki araba): " + ((Stack<string>)otopark[1]).ElementAt(8));
            for (int i = 0; i < 27; i++)
            {
                Console.WriteLine(i + 1 + ". tur:");
                Console.WriteLine("Otoparktan çıkan araba: " + BirArabayiCikar(otopark));
                KatlariYazdir(otopark);
                if (i < 26)
                {
                    Console.WriteLine("\nSonraki tur için bir tuşa basınız...");
                    Console.ReadKey();
                }
            }
        }

        private static string BirArabayiCikar(ArrayList otopark)//Arabalar sadece 1. kattan çıkabilmektedir ve 1 adet araba kaza testi için otoparktan alınmaktadır.
        {
            string cikanAraba = ((Queue<string>)otopark[0]).Dequeue();
            if (((Stack<string>)otopark[1]).Count != 0)
                ((Queue<string>)otopark[0]).Enqueue(((Stack<string>)otopark[1]).Pop());//Ardından 2. kattaki yığıttan bir araba 1. kata inmektedir.
            if (!((CircularList)otopark[2]).isEmpty())
                ((Stack<string>)otopark[1]).Push(((CircularList)otopark[2]).Cikar());//3. kattaki bağlaçlı listeden de bir araba 2. kata inmektedir.

            return cikanAraba;
        }

        private static void KatlariYazdir(ArrayList otopark) //Katlara yerleştirilen arabaları ekrana yazdırır.
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

        private static void KatlariDoldur(ArrayList otopark, Random r, int n) // Tüm veri yapılarına 9'ar adet araba yerleştirir.
        {
            CircularList ustKat = new CircularList(n);
            Queue<string> zeminKat = new Queue<string>();
            Stack<string> ortaKat = new Stack<string>();
            otopark.Clear();
            otopark.Add(zeminKat);
            otopark.Add(ortaKat);
            otopark.Add(ustKat);
            string[] renkler = { "Siyah", "Gümüş", "Gri", "Beyaz", "Kırmızı", "Bordo", "Mor", "Yeşil", "Sarı", "Turuncu", "Mavi", "Lacivert" };

            for (int i = 0; i < 9; i++) //Tüm veri yapılarında bulunan arabalara rastgele birer renk ataması yapılır.
            {
                ((Queue<string>)otopark[0]).Enqueue(renkler[r.Next(0, renkler.Length)]);
                ((Stack<string>)otopark[1]).Push(renkler[r.Next(0, renkler.Length)]);
                ((CircularList)otopark[2]).Ekle(renkler[r.Next(0, renkler.Length)]);
            }
        }

        private static int SayiAl() //Try catch ile hata yakalayarak yapılmış sayısal methodu string girişine izin vermez.
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
        private static int SayiAl(int a, int u)//Belirtilen aralıkta sayı alır, Try catch ile hata yakalayarak yapılmış sayısal methodu string girişine izin vermez.
        {
            bool hatali;
            int secim = 0;
            do
            {
                hatali = true;

                try
                {
                    secim = Int32.Parse(Console.ReadLine());
                    if (secim <= u && secim >= a)
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
