using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            bool cikis=true;
            while (cikis)
            {
                switch (AnaMenu())
                {
                    case 1:
                        Console.Write("İlk yılı giriniz: ");
                        int yil1 = SayiAl();
                        Console.Write("İkinci yılı giriniz: ");
                        int yil2 = SayiAl();
                        if (yil1 > yil2)
                        {
                            int temp=yil1;
                            yil1 = yil2;
                            yil2 = temp;

                        }
                        Console.WriteLine("Her deneyi gerçekleştirmek için 1'i\nSadece istatistikleri göstermek için 2'yi tuşlayınız: ");
                        int deney = SayiAl(1, 2);
                        if (deney == 1)
                            HerDeneyiGerceklestir(r, yil1, yil2);
                        else DeneyGerceklestir(r, yil1, yil2);
                        break;
                    case 2:
                        Console.WriteLine("Her deneyi gerçekleştirmek için 1'i\nSadece istatistikleri göstermek için 2'yi tuşlayınız: ");
                        int d = SayiAl(1, 2);
                        if (d == 1)
                            HerDeneyiGerceklestir(r, 1995, 1997);
                        else DeneyGerceklestir(r, 1995, 1997);
                        break;
                    case 3:
                        Console.WriteLine("Her deneyi gerçekleştirmek için 1'i\nSadece istatistikleri göstermek için 2'yi tuşlayınız: ");
                        int de = SayiAl(1, 2);
                        if (de == 1)
                            HerDeneyiGerceklestir(r, 1996, 1996);
                        else DeneyGerceklestir(r, 1996, 1996);
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Tekrar etmek için 1'i çıkmak için 2'yi tuşlayınız: ");
                if (SayiAl(1, 2) == 2)
                    cikis = false;
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

        private static int SayiAl(int a,int u)
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

        private static int AnaMenu()
        {
        
            Console.WriteLine("1) Herhangi iki yıl arasındaki doğumgünlerini üret");
            Console.WriteLine("2) 1995-1997 arasındaki doğumgünlerini üret");
            Console.WriteLine("3) 1996 yılı için doğumgünü üret");
            Console.Write("Seçiminiz (1,2,3):");
           return SayiAl(1, 3);
        }
        private static void HerDeneyiGerceklestir(Random r, int yil1, int yil2)
        {
        int [,] cakismaSayilari= new int[10,4];
            int[] nDizisi = { 50, 100, 500, 1000 };
            foreach (int n in nDizisi)
            {
                Console.WriteLine("Üretilen doğum günü sayısı(n):"+n);
                int deneyIndex = 0;
                switch (n)
                {
                    case 50:
                        deneyIndex = 0;
                        break;
                    case 100:
                        deneyIndex = 1;
                        break;
                    case 500:
                        deneyIndex = 2;
                        break;
                    case 1000:
                        deneyIndex = 3;
                        break;

                    default:
                        break;
                }
                for (int k = 0; k < 10; k++)
                {

                    DateTime[] bDays = nRandomBDayGenerator(r, yil1, yil2, n);
                    for (int i = yil1; i <= yil2; i++)
                    {
                        Console.Write("Yil: " + i + " Deney: ");
                        Console.WriteLine(k + 1);
                        Console.Write(String.Format("{0,-10}", ""));
                        for (int o = 0; o < 31; o++)
                        {

                            Console.Write(o + 1);
                            if (o < 9)
                                Console.Write(" ");
                        }
                        Console.WriteLine();
                        int[][] yildakiDGunleri = new int[12][];
                        for (int z = 0; z < 12; z++)
                        {
                            yildakiDGunleri[z] = new int[DateTime.DaysInMonth(i, z + 1)];


                        }
                        for (int j = 0; j < bDays.Length; j++)
                        {
                            if (bDays[j].Year == i)
                                yildakiDGunleri[bDays[j].Month - 1][bDays[j].Day - 1]++;
                        }
                        for (int t = 0; t < 12; t++)
                        {

                            Console.Write(String.Format("{0,-10}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(t + 1) + " "));
                            for (int l = 0; l < DateTime.DaysInMonth(i, t + 1); l++)
                            {
                                if (yildakiDGunleri[t][l] > 1)
                                    cakismaSayilari[k, deneyIndex] += yildakiDGunleri[t][l] - 1;
                                Console.Write(yildakiDGunleri[t][l] + " ");
                            }
                            Console.WriteLine();
                        } Console.WriteLine();
                    }

                    if (k < 9)
                    {
                        Console.WriteLine("Sonraki deneye geçmek için bir tuşa basın...");
                        Console.ReadLine();  
                    }
                }
            }

            Console.WriteLine(String.Format("{0,37}", "n=50   n=100  n=500  n=1000"));
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(String.Format("{0,-10}", "Deney " + i));

                for (int j = 0; j < 4; j++)
                {
                    Console.Write(String.Format("{0,-7}", cakismaSayilari[i - 1, j]));

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write(String.Format("{0,-10}", "Ortalama"));
            for (int i = 0; i < 4; i++)
            {
                double ort = 0;
                for (int j = 0; j < 10; j++)
                {
                    ort += Convert.ToDouble(cakismaSayilari[j, i]);
                }
                Console.Write(String.Format("{0,-7}", ort / 10));
            }    
        }

        private static void DeneyGerceklestir(Random r, int yil1, int yil2)
        {
            int[,] cakismaSayilari = new int[10, 4];
            int[] nDizisi = { 50, 100, 500, 1000 };
            foreach (int n in nDizisi)
            {    
                int deneyIndex = 0;
                switch (n)
                {
                    case 50:
                        deneyIndex = 0;
                        break;
                    case 100:
                        deneyIndex = 1;
                        break;
                    case 500:
                        deneyIndex = 2;
                        break;
                    case 1000:
                        deneyIndex = 3;
                        break;

                    default:
                        break;
                }
                for (int k = 0; k < 10; k++)
                {

                    DateTime[] bDays = nRandomBDayGenerator(r, yil1, yil2, n);
                    for (int i = yil1; i <= yil2; i++)
                    {
                        int[][] yildakiDGunleri = new int[12][];
                        for (int z = 0; z < 12; z++)
                        {
                            yildakiDGunleri[z] = new int[DateTime.DaysInMonth(i, z + 1)];


                        }
                        for (int j = 0; j < bDays.Length; j++)
                        {
                            if (bDays[j].Year == i)
                                yildakiDGunleri[bDays[j].Month - 1][bDays[j].Day - 1]++;
                        }
                        for (int t = 0; t < 12; t++)
                        {

                            for (int l = 0; l < DateTime.DaysInMonth(i, t + 1); l++)
                            {
                                if (yildakiDGunleri[t][l] > 1)
                                    cakismaSayilari[k, deneyIndex] += yildakiDGunleri[t][l] - 1;
                            }
                        }
                    }

                    
                }
            }

            Console.WriteLine(String.Format("{0,37}", "n=50   n=100  n=500  n=1000"));
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(String.Format("{0,-10}", "Deney " + i));

                for (int j = 0; j < 4; j++)
                {
                    Console.Write(String.Format("{0,-7}", cakismaSayilari[i - 1, j]));

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write(String.Format("{0,-10}", "Ortalama"));
            for (int i = 0; i < 4; i++)
            {
                double ort = 0;
                for (int j = 0; j < 10; j++)
                {
                    ort += Convert.ToDouble(cakismaSayilari[j, i]);
                }
                Console.Write(String.Format("{0,-7}", ort / 10));
            }    

        }

        private static DateTime[] nRandomBDayGenerator(Random r, int yil1, int yil2, int n)
        {
            DateTime[] bDays = new DateTime[n];
            for (int i = 0; i < n; i++)
            {
                bDays[i] = randomBDayGeneratorBetweenTwoYears(r, yil1, yil2);
            }
            return bDays;
        }

        private static DateTime randomBDayGeneratorBetweenTwoYears(Random r, int yil1, int yil2)
        {
            DateTime dt1 = new DateTime(yil2, 12, 31);
            DateTime dt2 = new DateTime(yil1, 1, 1);

            int yil = r.Next(yil1, yil2 + 1);
            int ay = r.Next(1, 13);
            int gun = r.Next(1,DateTime.DaysInMonth(yil, ay)+1);
            return new DateTime(yil, ay, gun);
        }
    }
}
