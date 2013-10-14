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
            int yil1=1995, yil2=1997;

            int n = 50;
            for (int k = 0; k < 10; k++)
            {

                DateTime[] bDays=nRandomBDayGenerator(r, yil1, yil2, n);
                for (int i = yil1; i <= yil2; i++)
                {
                    Console.Write("Yil: "+i+" Deney: ");
                    Console.WriteLine(k+1);
                    Console.Write(String.Format("{0,-10}", ""));
                    for (int o = 0; o < 31; o++)
                    {
                       
                        Console.Write(o + 1);
                        if (o < 10)
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                    int[][] yildakiDGunleri = new int[12][];
                    for (int z = 0; z < 12; z++)
                    {
                        yildakiDGunleri[z]= new int [DateTime.DaysInMonth(i,z+1)];
                        
                 
                    }
                    for (int j = 0; j < bDays.Length; j++)
                    {
                        if(bDays[j].Year==i)
                            yildakiDGunleri[bDays[j].Month-1][bDays[j].Day-1]++;
                    }
                    for (int t = 0; t < 12; t++)
                    {
                        
                       Console.Write(String.Format("{0,-10}",CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(t+1)+" "));
                       for (int l = 0; l < DateTime.DaysInMonth(i, t + 1); l++)
                       {
                           Console.Write(yildakiDGunleri[t][l] + " ");
                       }
                       Console.WriteLine();
                    } Console.WriteLine();
                }
                
                if (k<9)
                {
                    Console.WriteLine("Sonraki deneye geçmek için bir tuşa basın...");
                    Console.ReadLine();  
                } 
            }
  
            Console.Read();
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
