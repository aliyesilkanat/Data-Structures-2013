using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int yil1=1995, yil2=1997;

            int n = 50;
            nRandomBDayGenerator(r, yil1, yil2, n);

            Console.Read();
        }

        private static void nRandomBDayGenerator(Random r, int yil1, int yil2, int n)
        {
            for (int i = 0; i < n; i++)
            {
                randomBDayGeneratorBetweenTwoYears(r, yil1, yil2);
            }
        }

        private static DateTime randomBDayGeneratorBetweenTwoYears(Random r, int yil1, int yil2)
        {
            DateTime dt1 = new DateTime(yil2, 12, 31);
            DateTime dt2 = new DateTime(yil1, 1, 1);

            int yil = r.Next(yil1, yil2 + 1);
            int ay = r.Next(1, 13);
            int gun = r.Next(DateTime.DaysInMonth(yil, ay)+1);
            return new DateTime(yil, ay, gun);
        }
    }
}
