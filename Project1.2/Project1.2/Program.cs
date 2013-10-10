using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Project1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            
            List<Ulke> ulkeListesi = new List<Ulke>();
            kontenjanSayilariniAl(r,ulkeListesi);

            List<Ogrenci> ogrenciListesi = new List<Ogrenci>();
            ogrenciOlusturma(r, ogrenciListesi);

            ogrencileriYerlestir(ulkeListesi, ogrenciListesi);
           
            Console.Read();
        }

        private static void ogrencileriYerlestir(List<Ulke> ulkeListesi, List<Ogrenci> ogrenciListesi)
        {


            int totalKontenjan = 0;
            foreach (Ulke item in ulkeListesi)
            {
                item.Ogrenciler = new List<Ogrenci>();
                totalKontenjan += item.Kontenjan;
            }

            if (totalKontenjan < ogrenciListesi.Count) //Kontenjan öğrenci sayısından az ise 
            {
                ogrenciListesi.Sort();
                ogrenciListesi.Reverse();
            }

            int bosKontenjan = totalKontenjan;
            int totalOgrenciSayisi = ogrenciListesi.Count;
            for (int i = 0; i < totalOgrenciSayisi; i++)
            {
                Ulke atanacakUlke = ulkeListesi.OrderBy(item => item.DolulukYuzdesi()).First();
                atanacakUlke.Ogrenciler.Add(new Ogrenci(ogrenciListesi[0]));
                ogrenciListesi.RemoveAt(0);
                ogrenciListesi.RemoveAll(item => item == null);
                if (--bosKontenjan == 0)
                    break;
            }
            if (ogrenciListesi.Count > 0)
            {
                Console.WriteLine("Yerleştirilemeyen öğrencilerin sayısı:" + ogrenciListesi.Count);
                Console.WriteLine("İsim\tSoyisim\tDeğerlendirme Puanı");
                foreach (Ogrenci item in ogrenciListesi)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Ülkeler:");
            foreach (Ulke item in ulkeListesi)
            {
                Console.WriteLine(item.Isim+ " Kontenjan:" +item.Kontenjan+ " Doluluk Yüzdesi:%"+item.DolulukYuzdesi());
                foreach (Ogrenci o in item.Ogrenciler)
                {
                    Console.WriteLine("İsim\tSoyisim\tDeğerlendirme Puanı");
                    Console.WriteLine(o);
                }
                Console.WriteLine();
            }


        }

        private static void ogrenciOlusturma(Random r, List<Ogrenci> ogrenciListesi)
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

        private static void kontenjanSayilariniAl(Random r,List<Ulke> ulkeListesi)
        {
            string[] ulkeler = { "ENG", "GER", "FRE", "ITA", "ESP", "USA", "JAP", "CHN", "RUS" };
            bool hatali = true;
            bool kontenjanGirisi = true;
            do
            {
                Console.WriteLine("Kontenjanları girmek için 0'ı:\nRastgele kontenjan değerleri(0-10) atamak için herhangi bir değeri tuşlayınız: ");
                try
                {
                    kontenjanGirisi = Int32.Parse(Console.ReadLine()) == 0 ? true : false;
                    hatali = false;
                }
                catch (FormatException)
                { Console.WriteLine("Hatalı değer girdiniz lütfen tekrar deneyiniz!\n"); }

            } while (hatali == true);
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
                            if (kont != 0)
                                ulkeListesi.Add(new Ulke(kont, ulkeler[i]));
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
                for (int i = 0; i < 9; i++)
                {
                    int kont = r.Next(11);
                    if (kont != 0)
                    ulkeListesi.Add(new Ulke(kont, ulkeler[i]));
                }
            }

            return;
        }
        
    }
}
