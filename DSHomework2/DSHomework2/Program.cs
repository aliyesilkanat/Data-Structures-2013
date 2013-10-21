using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSHomework2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matris = { { 1, 2, 3, 4 }, { 4, 3, 2, 1 }, { 2, 5, 7, 11 }, { 13, 17, 19, 23 } };
            int[] dizi = new int[4];
            Ltopla(matris, dizi);
            foreach (int item in dizi)
            {
                Console.Write(item+" ");
            }
            Console.ReadKey(); 
        }

        private static void Ltopla(int[,] matris, int[] dizi)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    dizi[i] += matris[i, j];
                    dizi[i] += matris[j, i];
                }
                dizi[i] += matris[i, i];
            }
        }
    }
}
