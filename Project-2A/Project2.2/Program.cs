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
            int bekleme = 0;
            for (int i = 0; i < n; i++)
            {
               int  islemSuresi = rnd.Next(235) + 15;
               if (i == 0)
                   bekleme = islemSuresi;
               else
               {
                   for (int j = i - 1; j >= 0; j--)
                   {
                       bekleme += islemSuresi + kuyruk.ElementAt(j).islemSuresi;
                   }
               }
               
                Araba araba = new Araba(i, islemSuresi,bekleme);   //i sıra no olarak kullanıldı
                kuyruk.Enqueue(araba);
                on.ekle(araba);
               
                
                Console.WriteLine(String.Format("{0,-8}{1,-10}{2,-20}", "Sira No", "İs.Sur", "Bekleme"));
                Console.WriteLine(String.Format("{0,-8}{1,-10}{2,-20}", (kuyruk.ElementAt(i).sira), kuyruk.ElementAt(i).islemSuresi, kuyruk.ElementAt(i).beklemeSuresi));
            }
            
            int[] ilkBeklemeDegerleri = new int[n];
            for (int i = 0; i <kuyruk.Count; i++)
            {                                                                       //kuyrugu islemSuresi ne göre sıraladıgımda beklemeSuresi degerleri değişecek.
                ilkBeklemeDegerleri[i] = kuyruk.ElementAt(i).beklemeSuresi;         //Zaman farkını bulmam için,ilk değerleri de bir yerde saklamam gerekli
            
            }

            int ilkToplam = diziToplamı(ilkBeklemeDegerleri);
            double ilkOrt = ortalamaBul(kuyruk);
           Console.WriteLine("ortalama bekleme suresi: " + ortalamaBul(kuyruk));

            Queue<Araba> sl = new Queue<Araba>();   //sl=sıralanmış liste
          
            for (int i = 0; i < kuyruk.Count; i++)
            {
                sl.Enqueue(on.cikar());
            } int[] sonBeklemeDegerleri = beklemeSuresiBul(sl);
              int sonToplam = diziToplamı(sonBeklemeDegerleri);
           

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
            Console.WriteLine("Arabaların toplam zamandan tasarrufu: "+(ilkToplam-sonToplam));
            Console.WriteLine("Ortalama islem tamamlanma süresindeki kazanc:"+(ilkOrt-ortalamaBul(sl)));
            double yuzde = (ilkOrt - ortalamaBul(sl))*100 / ilkOrt ;
            Console.WriteLine("Yuzde:"+yuzde);

           //UCLU GISE

            Queue<Araba>[] kuyrukdizisi = new Queue<Araba>[3];  //3 kuyrugu bir dizi yaptım.
            for (int i = 0; i < 3; i++)
            {
                kuyrukdizisi[i] = new Queue<Araba>();  
            }
            int[] toplam = new int[3];

            for (int i = 0; i < sl.Count; i++)
            {
                kuyrukdizisi[mini(toplam)].Enqueue(sl.ElementAt(i));
                int sayi = mini(toplam);
                switch(sayi) {
                    case 0:
                        {


                            toplam[0] += sl.ElementAt(i).islemSuresi;

                      
                               
                             break;
                        }
                    case 1:
                        {


                            toplam[1] += sl.ElementAt(i).islemSuresi;
                            
                             break;
                        }
                    case 2:
                        {


                            toplam[2] += sl.ElementAt(i).islemSuresi;
                            
                             break;
                        }
                }
            }


            Console.WriteLine("GISE1");
            Console.WriteLine("---------------");
            kuyrukYazdir(kuyrukdizisi[0]);
            Console.WriteLine("Toplam islem suresi: "+toplam[0]);
            
            Console.WriteLine("\n\nGISE2");
            Console.WriteLine("---------------");
            kuyrukYazdir(kuyrukdizisi[1]);
            Console.WriteLine("Toplam islem suresi: " + toplam[1]);
            
            Console.WriteLine("\n\nGISE3");
            Console.WriteLine("---------------");
            kuyrukYazdir(kuyrukdizisi[2]);
            Console.WriteLine("Toplam islem suresi: " + toplam[2]);

            Console.WriteLine("\n\n\nÜÇLÜ GİŞE VS TEKLİ GİŞE");
            Console.WriteLine("Üçlü gişede toplam işlem süresi:"+toplam[maxi(toplam)]);
            Console.WriteLine("Tekli gişede toplam işlem süresi:"+sonToplam);


            

            


            Console.Read();
        

       }

        public static int[] beklemeSuresiBul(Queue<Araba> kuyruk)  //Bu metodu sadece sıraladıktan sonra arabaların bekleme süresini değiştirirken kullanacağım
        {                                                           //Arguman olarak sadece  sıralanmısListe yi verecegim, return edilen  dizinin elemanlarını, sıralanmısListenin beklemeSurelerine atayacağım.  
            int[] bs = new int[kuyruk.Count];  //bs=arabaların bekleme süresinin listesi
            for (int i = 0; i < kuyruk.Count; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    bs[i] += kuyruk.ElementAt(j).islemSuresi;
                }

            }

            return bs;    // 
        }

        public static void kuyrukYazdir(Queue<Araba> kuyruk) {
            foreach (Araba item in kuyruk)
            {
                Console.WriteLine(item.ToString());
            }
        }


        public static int diziToplamı(int[] dizi) {
            int toplam = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                toplam += dizi[i];
            }
            return toplam;
        
        }

        public static int mini(int[] dizi) {   //3lü gişede işlem süresi en az olan gişeyi bulmak için
           int index=2;

           int min=dizi[2];
          
            if (dizi[1]<= min)
           { index = 1; min = dizi[1]; }
           
            if (dizi[0] <= min)
           { index = 0; min = dizi[0]; }

            
           return index;

           
        }

        public static int maxi(int[] dizi)
        {   //3lü gişede işlem süresi en az olan gişeyi bulmak için
            int index = 2;

            int maxi = dizi[2];

            if (dizi[1] >= maxi)
            { index = 1; maxi = dizi[1]; }

            if (dizi[0] >= maxi)
            { index = 0; maxi = dizi[0]; }


            return index;


        }
        




        public static double ortalamaBul(Queue<Araba> kuyruk)
        {
            int toplam = 0;
            for (int i = 0; i < kuyruk.Count; i++)
            {
                toplam += kuyruk.ElementAt(i).beklemeSuresi;
            }

            return (double)toplam / kuyruk.Count;
        }

    }

}
