using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Project1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            
            ArrayList ulkeListesi = new ArrayList();
            
            int[] kontenjan = kontenjanSayilariniAl(r,ulkeListesi);


            ArrayList ogrenciListesi = new ArrayList();
            ogrenciOlusturma(r, ogrenciListesi);
      
            Console.Read();
        }

        private static void ogrenciOlusturma(Random r, ArrayList ogrenciListesi)
        {
            string[] isimler = { "Ali", "Hasan", "Fatma", "Oğuz", "Ayşe", "Zeynep", "Elif", "Merve", "Ece", "Esra", "Kaan", "Özlem", "Yasemin", "Anıl", "Mehmet", "Mustafa", "Ahmet", "Gamze", "Hüseyin", "İbrahim" };
            string[] soyisimler = { "Yıldız", "Yıldırım", "Avcı", "Öztürk", "Kaya", "Erdem", "Aydın", "Özdemir", "Arslan", "Doğan", "Kılıç", "Çetin", "Kara", "Koç", "Uğur", "Kurt", "Özkan", "Eren", "Şimşek", "Yılmaz" };

            bool hatali = true;
            int basvuranOgrenciSayisi = 0;
            do
            {
                Console.WriteLine("Başvuran öğrenci sayısını giriniz: (1-150) ");

                try
                {
                    basvuranOgrenciSayisi = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Hatali deger girdiniz lütfen tekrar deneyiniz!\n");
                    continue;
                }
                if (basvuranOgrenciSayisi > 150 || basvuranOgrenciSayisi < 1)
                {
                    Console.WriteLine("Lütfen belirtilen değer aralığında giriniz: (1-150)");
                }
                else hatali = false;

            } while (hatali == true);

            for (int i = 0; i < basvuranOgrenciSayisi; i++)
            {
                int degerlendirmeNotu = r.Next(40, 101);
                if (degerlendirmeNotu >= 60)
                    ogrenciListesi.Add(new Ogrenci(isimler[r.Next(20)], soyisimler[r.Next(20)], degerlendirmeNotu));
            }
        }

        private static int[] kontenjanSayilariniAl(Random r,ArrayList ulkeListesi)
        {
            string[] ulkeler = { "ENG", "GER", "FRE", "ITA", "ESP", "USA", "JAP", "CHN", "RUS" };        
            int[] kontenjan = new int[9];
           
            bool hatali = true;
            bool kontenjanGirisi=true;
            do{
                Console.WriteLine("Kontenjanları girmek için 0'ı:\nRastgele kontenjan değerleri(0-10) atamak için herhangi bir değeri tuşlayınız: ");
                try{
                   kontenjanGirisi= Int32.Parse(Console.ReadLine())==0?true:false;
                   hatali = false;
            }
            catch (FormatException)
                { Console.WriteLine("Hatalı değer girdiniz lütfen tekrar deneyiniz!\n"); }
                
            }while(hatali==true);
            if (kontenjanGirisi)
            {
                for (int i = 0; i < ulkeler.Length; i++)
                {
                    hatali = true;
                    while (hatali)
                    {
                        try
                        {
                            Console.Write(ulkeler[i] + " ülkesi için kontenjan sayısını giriniz: ");
                            int kont = Int32.Parse(Console.ReadLine());
                            if(kont!=0)
                            ulkeListesi.Add(new Ulke(kont,ulkeler[i]));
                        }
                        catch (FormatException)
                        { 
                            Console.WriteLine("Hatalı değer girdiniz lütfen tekrar deneyiniz!\n");
                            continue;
                        }
                        hatali = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < kontenjan.Length; i++)
                {
                    kontenjan[i] = r.Next(11);
                }
            }



            return kontenjan;
        }

    }
}
