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

            ArrayList otopark = new ArrayList();
            CircularList ustKat = new CircularList();
            Queue<string> zeminKat = new Queue<string>();
            Stack<string> ortaKat = new Stack<string>();

            otopark.Add(zeminKat);
            otopark.Add(ortaKat);
            otopark.Add(ustKat);
            Random r = new Random();
            KatlariDoldur(otopark, r);
            //DaireselListeTest();
            Console.Read();
        }

        private static void KatlariDoldur(ArrayList otopark, Random r)
        {
            string[] renkler = { "Siyah", "Gümüş", "Gri", "Beyaz", "Kırmızı", "Bordo", "Mor", "Yeşil", "Sarı", "Turuncu", "Mavi", "Lacivert" };
            string rastgeleRenk = renkler[r.Next(0, renkler.Length)];

            for (int i = 0; i < 9; i++)
            {
                ((CircularList)otopark[2]).insertBegin(rastgeleRenk);
                ((Queue<string>)otopark[0]).Enqueue(rastgeleRenk);
                ((Stack<string>)otopark[1]).Push(rastgeleRenk);
            }
        }

        private static void DaireselListeTest()
        {

            CircularList cl = new CircularList();
            cl.insertBegin("arba");
            cl.insertEnd("asdasda");
            cl.insertEnd("son");
            cl.yazdir();
            cl.Atla(3);
        }
    }
}
