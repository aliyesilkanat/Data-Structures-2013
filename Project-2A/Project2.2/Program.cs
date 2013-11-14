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
            Console.WriteLine("kac tane araba olusturmak istersiniz");
            int n = Int16.Parse(Console.ReadLine());
            Queue<Araba> kuyruk = new Queue<Araba>();

            for (int i = 0; i < n; i++)
            {
                int a = rnd.Next(235) + 15;
                kuyruk.Enqueue(new Araba(i, a));
                int[] bs = beklemeSuresiBul(kuyruk);
                Console.WriteLine(String.Format("{0,-8}{1,-10}{2,-20}", "Sira No", "İs.Sur", "Bekleme"));
                Console.WriteLine(String.Format("{0,-8}{1,-10}{2,-20}", (kuyruk.ElementAt(i).sira + 1), kuyruk.ElementAt(i).iss, bs[i]));
            }

            Console.WriteLine("ortalama bekleme suresi: " + ortalamaBul(beklemeSuresiBul(kuyruk)));


            Console.Read();
        }

        public static int[] beklemeSuresiBul(Queue<Araba> kuyruk)
        {
            int[] bs = new int[kuyruk.Count];  //bs=arabaların bekleme süresinin listesi
            for (int i = 0; i < kuyruk.Count; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    bs[i] += kuyruk.ElementAt(j).iss;
                }

            }

            return bs;
        }

        public static double ortalamaBul(int[] dizi)
        {
            int toplam = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                toplam += dizi[i];
            }

            return (double)toplam / dizi.Length;
        }

    }

}
