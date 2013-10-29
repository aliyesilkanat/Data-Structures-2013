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
            kontenjanSayilariniAl(r, ulkeListesi);

            List<Ogrenci> ogrenciListesi = new List<Ogrenci>();
            ogrenciOlusturma(r, ogrenciListesi);
            ogrencileriYerlestir(ulkeListesi, ogrenciListesi);
            Console.Read();
        }
        private static int SayiAl()
        {
            bool hatali;
            int secim = 0;
            do
            {
                hatali = true;
                try
                {
                    secim = Int32.Parse(Console.ReadLine());
                    hatali = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Hatalı değer girdiniz!");
                }
            } while (hatali);
            return secim;
        }

        private static int SayiAl(int a, int u)
        {
            bool hatali;
            int secim = 0;
            do
            {
                hatali = true;

                try
                {
                    secim = Int32.Parse(Console.ReadLine());
                    if (secim <= u && secim >= a)
                        hatali = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Hatalı değer girdiniz!");
                }
            } while (hatali);
            return secim;
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

            //for (int i = 0; i < totalOgrenciSayisi; i++)
            //{
            //    Ulke atanacakUlke = ulkeListesi.OrderBy(item => item.DolulukYuzdesi()).First();
            //    atanacakUlke.Ogrenciler.Add(new Ogrenci(ogrenciListesi[0]));
            //    ogrenciListesi.RemoveAt(0);
            //    ogrenciListesi.RemoveAll(item => item == null);
            //    if (--bosKontenjan == 0)
            //        break;
            //}
            //Hedef Oran
            //float hedeflenenOran = (float)totalOgrenciSayisi / totalKontenjan;
            //foreach (Ulke u in ulkeListesi)
            //{
            //    for (int i = 0; i < Math.Round(hedeflenenOran * u.Kontenjan); i++)
            //    {
            //        u.Ogrenciler.Add(new Ogrenci(ogrenciListesi[0]));
            //        ogrenciListesi.RemoveAt(0);
            //        ogrenciListesi.RemoveAll(item => item == null);
            //        if (--bosKontenjan == 0 || ogrenciListesi.Count==0)
            //            break;
            //    }
            //    if (bosKontenjan == 0 || ogrenciListesi.Count == 0)
            //        break;
            //}
            //if (bosKontenjan > 0 && ogrenciListesi.Count > 0)
            //{
            //    Ulke minOranUlke = null;
            //    float minOran = 100;
            //    foreach (Ulke u in ulkeListesi)
            //    {
            //        if (minOran > (float)(u.Ogrenciler.Count + 1) / u.Kontenjan)
            //        {
            //            minOran = (float)(u.Ogrenciler.Count + 1) / u.Kontenjan;
            //            minOranUlke = u;
            //        }
            //    }
            //    minOranUlke.Ogrenciler.Add(new Ogrenci(ogrenciListesi[0]));
            //    ogrenciListesi.RemoveAt(0);
            //    ogrenciListesi.RemoveAll(item => item == null);

            //}
            //Bir sonraki min
            //if (totalKontenjan <= ogrenciListesi.Count)
            //{
            //    for (int i = 0; i < totalOgrenciSayisi; i++)
            //    {
            //        Ulke atanacakUlke = ulkeListesi.OrderBy(item => item.DolulukYuzdesi()).First();
            //        atanacakUlke.Ogrenciler.Add(new Ogrenci(ogrenciListesi[0]));
            //        ogrenciListesi.RemoveAt(0);
            //        ogrenciListesi.RemoveAll(item => item == null);
            //        if (--bosKontenjan == 0)
            //            break;
            //    }
            //}
            //else
            //{
                //for (int i = 0; i < totalOgrenciSayisi; i++)
                //{
                //    Ulke minOranUlke = null;
                //    float minOran = 1;
                //    minOranUlke = ulkeListesi[0];
                //    foreach (Ulke u in ulkeListesi)
                //    {
                //        if (minOran > (float)(u.Ogrenciler.Count + 1) / u.Kontenjan)
                //        {
                //            minOran = (float)(u.Ogrenciler.Count + 1) / u.Kontenjan;
                //            minOranUlke = u;
                //        }
                //    }
                //    minOranUlke.Ogrenciler.Add(new Ogrenci(ogrenciListesi[0]));
                //    ogrenciListesi.RemoveAt(0);
                //    ogrenciListesi.RemoveAll(item => item == null);
                //    if (--bosKontenjan == 0)
                //        break;
                //}
               

            //}
            float hedeflenenOran = (float)totalOgrenciSayisi / totalKontenjan;
            if (totalOgrenciSayisi>=totalKontenjan) //Ülkede doluluk oranın taşmaması için
            {
                hedeflenenOran = 1.0f;
            }
            foreach (Ulke u in ulkeListesi)
                {
                for (int i = 0; i < Math.Round(hedeflenenOran * u.Kontenjan); i++)
                {
                    u.Ogrenciler.Add(new Ogrenci(ogrenciListesi[0]));
                    ogrenciListesi.RemoveAt(0);
                    ogrenciListesi.RemoveAll(item => item == null);
                    if (--bosKontenjan == 0 || ogrenciListesi.Count==0)
                        break;
                }
                if (bosKontenjan == 0 || ogrenciListesi.Count == 0)
                    break;
            }
            if (bosKontenjan > 0 && ogrenciListesi.Count > 0)
            {
                for (int i = totalKontenjan-bosKontenjan; i < totalOgrenciSayisi; i++)
                {
                    
               
                Ulke minOranUlke = null;
                float minOran = 1.0f;
                foreach (Ulke u in ulkeListesi)
                {
                    if (minOran > (float)(u.Ogrenciler.Count + 1) / u.Kontenjan)
                    {
                        minOran = (float)(u.Ogrenciler.Count + 1) / u.Kontenjan;
                        minOranUlke = u;
                    }
                }
                minOranUlke.Ogrenciler.Add(new Ogrenci(ogrenciListesi[0]));
                ogrenciListesi.RemoveAt(0);
                ogrenciListesi.RemoveAll(item => item == null);
                }
            }
            if (ogrenciListesi.Count > 0)
            {
                Console.WriteLine("Yerleştirilemeyen öğrencilerin sayısı:" + ogrenciListesi.Count);
                Console.WriteLine(String.Format("{0,-9}{1,-10}{2,-20}", "İsim", "Soyisim", "Değerlendirme Puanı"));
                foreach (Ogrenci item in ogrenciListesi)
                {
                    Console.WriteLine(String.Format("{0,-9}{1,-10}{2,-20}", item.Ad, item.Soyad, item.DegerlendirmeNotu));
                }
                Console.WriteLine();
            }
            Console.WriteLine("Ülkeler:");
            foreach (Ulke item in ulkeListesi)
            {
                Console.WriteLine(item.Isim + " Kontenjan:" + item.Kontenjan + " Yerleşen Öğrenci Sayısı:" + item.Ogrenciler.Count + " Doluluk Yüzdesi:%" + item.DolulukYuzdesi());
                if (item.Ogrenciler.Count != 0)
                {
                    Console.WriteLine(String.Format("{0,-9}{1,-10}{2,-20}", "İsim", "Soyisim", "Değerlendirme Puanı"));
                    foreach (Ogrenci o in item.Ogrenciler)
                    {
                        Console.WriteLine(String.Format("{0,-9}{1,-10}{2,-20}", o.Ad, o.Soyad, o.DegerlendirmeNotu));
                    }
                }
                Console.WriteLine();
            }


        }

        private static void ogrenciOlusturma(Random r, List<Ogrenci> ogrenciListesi)
        {
            string[] isimler = { "Ali", "Hasan", "Fatma", "Oğuz", "Ayşe", "Zeynep", "Elif", "Merve", "Ece", "Esra", "Kaan", "Özlem", "Yasemin", "Anıl", "Mehmet", "Mustafa", "Ahmet", "Gamze", "Hüseyin", "İbrahim" };
            string[] soyisimler = { "Yıldız", "Yıldırım", "Avcı", "Öztürk", "Kaya", "Erdem", "Aydın", "Özdemir", "Arslan", "Doğan", "Kılıç", "Çetin", "Kara", "Koç", "Uğur", "Kurt", "Özkan", "Eren", "Şimşek", "Yılmaz" };

            int basvuranOgrenciSayisi = 0;
            Console.WriteLine("Başvuran öğrenci sayısını giriniz: (1-150) ");

            basvuranOgrenciSayisi = SayiAl(1, 150);

            for (int i = 0; i < basvuranOgrenciSayisi; i++)
            {
                int degerlendirmeNotu = r.Next(60, 101);
                if (degerlendirmeNotu >= 60)
                    ogrenciListesi.Add(new Ogrenci(isimler[r.Next(20)], soyisimler[r.Next(20)], degerlendirmeNotu));
            }
        }

        private static void kontenjanSayilariniAl(Random r, List<Ulke> ulkeListesi)
        {
            string[] ulkeler = { "ENG", "GER", "FRE", "ITA", "ESP", "USA", "JAP", "CHN", "RUS" };
            bool kontenjanGirisi = true;
            Console.WriteLine("Kontenjanları girmek için 0'ı:\nRastgele kontenjan değerleri(0-10) atamak için herhangi bir değeri tuşlayınız: ");
            kontenjanGirisi = SayiAl() == 0 ? true : false;

            if (kontenjanGirisi)
            {
                for (int i = 0; i < ulkeler.Length; i++)
                {
                    Console.Write(ulkeler[i] + " ülkesi için kontenjan sayısını giriniz: ");
                    int kont = SayiAl();
                    if (kont != 0)
                        ulkeListesi.Add(new Ulke(kont, ulkeler[i]));

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
