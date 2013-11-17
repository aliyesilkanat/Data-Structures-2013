using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project2._2
{
    class Program
    {


        static void Main(string[] args)
        {

            Random rnd = new Random();
            Console.WriteLine("Kuyruğa eklenecek araba sayısını giriniz: ");
            int n = SayiAl();
            Kuyruk kuyruk = new Kuyruk();
            int[] bs = new int[n];
            OncelikKuyrugu on = new OncelikKuyrugu();
            for (int i = 0; i < n; i++)
            {

                int islemSuresi = rnd.Next(15, 251);
                int bekleme = islemSuresi;
                for (int j = 0; j < i; j++)
                {
                    bekleme += kuyruk.ElementAt(j).islemSuresi;
                }
                Araba araba = new Araba(i, islemSuresi, bekleme);   //i sıra no olarak kullanıldı
                kuyruk.Ekle(araba);
                on.ekle(araba);

                Console.WriteLine(String.Format("{0,-8}{1,-10}{2,-20}", "Sira No", "İs.Sur", "Bekleme"));
                Console.WriteLine(String.Format("{0,-8}{1,-10}{2,-20}", (kuyruk.ElementAt(i).sira), kuyruk.ElementAt(i).islemSuresi, kuyruk.ElementAt(i).beklemeSuresi));
            }

            int[] ilkBeklemeDegerleri = new int[n];

            for (int i = 0; i < kuyruk.Count; i++)
            {                                                                       //Kuyruk işlem süresine göre sıralandığında bekleme süresi değerleri değişir.
                ilkBeklemeDegerleri[i] = kuyruk.ElementAt(i).beklemeSuresi;         //Zaman farkını bulmak için, ilk değerleri de bir yerde saklamak gerekiyor.
            }

            int ilkToplam = ilkBeklemeDegerleri.Sum();
            double ilkOrt = ortalamaBul(kuyruk);
            Console.WriteLine("Ortalama bekleme suresi: " + ortalamaBul(kuyruk));

            Kuyruk sl = new Kuyruk();   //sl=sıralanmış liste

            for (int i = 0; i < kuyruk.Count; i++)
            {
                sl.Ekle(on.cikar());
            }

            int[] sonBeklemeDegerleri = beklemeSuresiBul(sl);
            int sonToplam = sonBeklemeDegerleri.Sum();

            for (int i = 0; i < sl.Count; i++)
            {
                sl.ElementAt(i).beklemeSuresi = sonBeklemeDegerleri[i];
            }
            Console.WriteLine("\n\n\nISLEM SURESI EN KISA OLAN ARABA ONCELİKLİ CIKACAK SEKİLDE KUYRUK OLUSTURULDU.\n\n");

            for (int i = 0; i < sl.Count; i++)
            {
                Console.WriteLine(String.Format("{0,-8}{1,-10}{2,-20}", "Sira No", "İs.Sur", "Bekleme"));
                Console.WriteLine(String.Format("{0,-8}{1,-10}{2,-20}", (sl.ElementAt(i).sira), sl.ElementAt(i).islemSuresi, sl.ElementAt(i).beklemeSuresi));
            }

            Console.WriteLine("ortalama bekleme suresi: " + ortalamaBul(sl));

            Console.WriteLine("\n\nBEKLEME SURESİ DEGİSEN ARABALAR");
            Console.WriteLine("-----------------------------------");

            for (int i = 0; i < n; i++)
            {
                int a = sl.ElementAt(i).sira;
                if (sl.ElementAt(i).beklemeSuresi != ilkBeklemeDegerleri[a])
                {
                    Console.Write(sl.ElementAt(i).ToString());
                    Console.Write("\tEski Bekleme Suresi:" + ilkBeklemeDegerleri[a]);
                    Console.Write("\tZaman farkı:" + Math.Abs((ilkBeklemeDegerleri[a] - sl.ElementAt(i).beklemeSuresi)));
                    Console.WriteLine("\n");
                }
            }

            Console.WriteLine("\n\n\nÖNCELİKLİ KUYRUK VS KUYRUK");
            Console.WriteLine("Arabaların toplam zamandan tasarrufu: " + (ilkToplam - sonToplam));
            Console.WriteLine("Ortalama islem tamamlanma süresindeki kazanc:" + (ilkOrt - ortalamaBul(sl)));
            double yuzde = (ilkOrt - ortalamaBul(sl)) * 100 / ilkOrt;
            Console.WriteLine("Yuzde:" + yuzde);

            //Üç Çıkışlı Otopark
            Kuyruk[] kuyrukdizisi = new Kuyruk[3];  //3 kuyruk bir dizi olarak tutuldu.
            for (int i = 0; i < 3; i++)
            {
                kuyrukdizisi[i] = new Kuyruk();
            }
            int[] toplam = new int[3];

            for (int i = 0; i < sl.Count; i++)
            {
                kuyrukdizisi[mini(toplam)].Ekle(sl.ElementAt(i));
                toplam[mini(toplam)] += sl.ElementAt(i).islemSuresi;
            }
            foreach (Kuyruk item in kuyrukdizisi)
            {
                beklemeSuresiHesapla(item);
            }



            Console.WriteLine("GISE1");
            Console.WriteLine("---------------");
            kuyrukYazdir(kuyrukdizisi[0]);
            Console.WriteLine("Toplam islem suresi: " + toplam[0]);

            Console.WriteLine("\n\nGISE2");
            Console.WriteLine("---------------");
            kuyrukYazdir(kuyrukdizisi[1]);
            Console.WriteLine("Toplam islem suresi: " + toplam[1]);

            Console.WriteLine("\n\nGISE3");
            Console.WriteLine("---------------");
            kuyrukYazdir(kuyrukdizisi[2]);
            Console.WriteLine("Toplam islem suresi: " + toplam[2]);

            Console.WriteLine("\n\n\nÜÇLÜ GİŞE VS TEKLİ GİŞE");
            int giselerdeToplamIslemSuresi = toplam[0] + toplam[1] + toplam[2];
            Console.WriteLine("Üçlü gişede toplam işlem süresi:" + giselerdeToplamIslemSuresi);
            Console.WriteLine("Tekli gişede toplam işlem süresi:" + sonToplam);

            Console.Read();


        }
        public static void beklemeSuresiHesapla(Kuyruk kuyruk)  //Bu metod sadece sıraladıktan sonra arabaların bekleme süresini değiştirirken kullanılır.
        {                                                           //Arguman olarak sadece  sıralanmısListe yi verilir. Return edilen  dizinin elemanları, sıralanmıs listenin bekleme sürelerine atanır.  
            for (int i = 0; i < kuyruk.Count; i++)
            {
                int beklemeSuresi = 0;
                for (int j = i; j >= 0; j--)
                {
                    beklemeSuresi += kuyruk.ElementAt(j).islemSuresi;
                }
                kuyruk.ElementAt(i).beklemeSuresi = beklemeSuresi;
            }

        }

        public static int[] beklemeSuresiBul(Kuyruk kuyruk)  //Bu metod sadece sıraladıktan sonra arabaların bekleme süresini değiştirirken kullanılır.
        {                                                           //Arguman olarak sadece  sıralanmısListe yi verilir. Return edilen  dizinin elemanları, sıralanmıs listenin bekleme sürelerine atanır.  
            int[] bs = new int[kuyruk.Count];  //bs=arabaların bekleme süresinin listesi
            for (int i = 0; i < kuyruk.Count; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    bs[i] += kuyruk.ElementAt(j).islemSuresi;
                }
            }
            return bs;
        }


        public static void kuyrukYazdir(Kuyruk kuyruk)
        {
            foreach (Araba item in kuyruk.arabaKuyrugu)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static int mini(int[] dizi)  //3lü gişede işlem süresi en az olan gişeyi bulmak için kullanılır.
        {

            int index = 2;
            int min = dizi[2];

            if (dizi[1] <= min)
            {
                index = 1;
                min = dizi[1];
            }

            if (dizi[0] <= min)
            {
                index = 0;
                min = dizi[0];
            }
            return index;
        }

        public static int maxi(int[] dizi) //3lü gişede işlem süresi en fazla olan gişeyi bulmak için kullanılır.
        {
            int index = 2;
            int maxi = dizi[2];

            if (dizi[1] >= maxi)
            {
                index = 1;
                maxi = dizi[1];
            }

            if (dizi[0] >= maxi)
            {
                index = 0;
                maxi = dizi[0];
            }
            return index;
        }

        public static double ortalamaBul(Kuyruk kuyruk)
        {
            int toplam = 0;
            for (int i = 0; i < kuyruk.Count; i++)
            {
                toplam += kuyruk.ElementAt(i).beklemeSuresi;
            }

            return (double)toplam / kuyruk.Count;
        }
        public static int Menu()
        {
            int secim;
            Console.WriteLine("1. Kuyruk");
            Console.WriteLine("2. Oncelik kuyrugu");
            Console.WriteLine("3. 3 cikisli otopark");
            Console.WriteLine("4.Cikis");
            Console.Write("Lutfen seciminizi giriniz:");
            secim = SayiAl(1, 4);
            return secim;
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
        private static int SayiAl(int a, int u)
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
