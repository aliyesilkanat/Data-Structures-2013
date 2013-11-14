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
            int[] bs=new int[n];
            OncelikKuyrugu on = new OncelikKuyrugu();
            for (int i = 0; i < n; i++)
            {
                int a = rnd.Next(235) + 15;
                Araba araba = new Araba(i, a);
                kuyruk.Enqueue(araba);
                on.ekle(araba);
               
                //kuyruk.Enqueue(new Araba(i, a));
                bs = beklemeSuresiBul(kuyruk);
                Console.WriteLine(String.Format("{0,-8}{1,-10}{2,-20}", "Sira No", "İs.Sur", "Bekleme"));
                Console.WriteLine(String.Format("{0,-8}{1,-10}{2,-20}", (kuyruk.ElementAt(i).sira ), kuyruk.ElementAt(i).islemSuresi, bs[i]));
            }
            Console.WriteLine("ortalama bekleme suresi: " + ortalamaBul(beklemeSuresiBul(kuyruk)));

            Queue<Araba> sl = new Queue<Araba>();   //sl=sıralanmış liste
            for (int i = 0; i < kuyruk.Count; i++)
            {
                sl.Enqueue(on.cikar());
            }

            int[] slbs = beklemeSuresiBul(sl);  //slbs=sıralı listenin bekleme süresi listesi
            Console.WriteLine("\n\n\nISLEM SURESI EN KISA OLAN ARABA ONCELİKLİ CIKACAK SEKİLDE KUYRUK OLUSTURULDU.\n\n");
            for (int i = 0; i < sl.Count; i++)
            {
                Console.WriteLine(String.Format("{0,-8}{1,-10}{2,-20}", "Sira No", "İs.Sur", "Bekleme"));
                Console.WriteLine(String.Format("{0,-8}{1,-10}{2,-20}", (sl.ElementAt(i).sira ), sl.ElementAt(i).islemSuresi, slbs[i]));
            }

            Console.WriteLine("ortalama bekleme suresi: " + ortalamaBul(beklemeSuresiBul(sl)));

            for (int i = 0; i < n; i++)
            {
                if (sl.ElementAt(i).sira!= i|| slbs[i]!=bs[i]) {
                    Console.WriteLine(kuyruk.ElementAt(i).ToString());
                }
            }

           

            Console.Read();
        }

        public static int[] beklemeSuresiBul(Queue<Araba> kuyruk)
        {
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
