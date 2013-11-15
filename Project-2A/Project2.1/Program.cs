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
            int n=3;
            Random r = new Random();
            ArrayList otopark = new ArrayList();
            CircularList ustKat = new CircularList(n);
            Queue<string> zeminKat = new Queue<string>();
            Stack<string> ortaKat = new Stack<string>();

            otopark.Add(zeminKat);
            otopark.Add(ortaKat);
            otopark.Add(ustKat);


            KatlariDoldur(otopark, r);

            KatlariYazdir(otopark);
  
            DaireselListeTest(n);
            Console.Read();
        }

        private static void KatlariYazdir(ArrayList otopark)
        {
            Console.WriteLine("Birinci kat:");
            foreach (string item in ((Queue<string>)otopark[0]))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nİkinci kat:");
            foreach (string item in ((Stack<string>)otopark[1]))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nÜçüncü kat:");
            ((CircularList)otopark[2]).yazdir();
        }

        private static void KatlariDoldur(ArrayList otopark, Random r)
        {
            string[] renkler = { "Siyah", "Gümüş", "Gri", "Beyaz", "Kırmızı", "Bordo", "Mor", "Yeşil", "Sarı", "Turuncu", "Mavi", "Lacivert" };

            for (int i = 0; i < 9; i++)
            {
                ((Queue<string>)otopark[0]).Enqueue(renkler[r.Next(0, renkler.Length)]);
                ((Stack<string>)otopark[1]).Push(renkler[r.Next(0, renkler.Length)]);
                ((CircularList)otopark[2]).insertBegin(renkler[r.Next(0, renkler.Length)]);
            }
        }

        private static void DaireselListeTest(int n)
        {
            CircularList cl = new CircularList(n);
            cl.insertBegin("arba");
            cl.insertEnd("asdasda");
            cl.insertEnd("son");
            cl.insertBegin("aaaaa");
            cl.yazdir();
            
        }
    }
}
