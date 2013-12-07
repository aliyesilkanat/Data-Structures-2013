using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Project_3A
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable sirketler = new Hashtable();
            Tree elemanlar = new Tree();

            SirketleriOku(sirketler);
            ElemanOku(elemanlar);
            int secim;
            do
            {
                secim = menu();
                switch (secim)
                {
                    case 1:
                        {
                            switch (altMenu(secim))
                            {
                                case 1:

                                    YeniElemanEkle(elemanlar);
                                    break;
                            }
                            break;
                        }
                    case 2:
                        {

                            break;
                        }
                }
            } while (secim != 4);
            elemanlar.inOrder(elemanlar.getRoot());
            Console.Read();
        }

        private static void YeniElemanEkle(Tree elemanlar)
        {
            Eleman yeniEleman = new Eleman();
            Console.WriteLine("Eklenecek kişinin...");
            Console.Write("Adı soyadi: ");
            yeniEleman.KisiAdi = Console.ReadLine();
            Console.Write("Adresi: ");
            yeniEleman.ElemanAdresi = Console.ReadLine();
            Console.Write("Telefonu: ");
            yeniEleman.Telefon = Console.ReadLine();
            Console.Write("E-Posta: ");
            yeniEleman.EPosta = Console.ReadLine();
            Console.Write("Uyruğu: ");
            yeniEleman.Uyruk = Console.ReadLine();
            Console.Write("Doğum Yeri: ");
            yeniEleman.DogumYeri = Console.ReadLine();
            Console.Write("Doğum Tarihi: ");
            yeniEleman.DogumTarihi = Console.ReadLine();
            Console.Write("Medeni Durum: ");
            yeniEleman.MedeniDurum = Console.ReadLine();
            Console.Write("Yabancı Dil: ");
            yeniEleman.YabanciDil = Console.ReadLine();
            Console.Write("İlgi Alanları: ");
            yeniEleman.IlgiAlanlari = Console.ReadLine();
            Console.Write("Referans olan kişiler: ");
            yeniEleman.ReferansOlanKisiler = Console.ReadLine();
            do
            {
                EgitimDurumu egt = new EgitimDurumu();
                Console.WriteLine("Mezun olduğu okulun...");
                Console.Write("Adı: ");
                egt.OkulAdi = Console.ReadLine();
                Console.Write("Bölümü: ");
                egt.Bolumu = Console.ReadLine();
                Console.Write("Başlangıç Yılı: ");
                egt.BaslangicTarihi = Console.ReadLine();
                Console.Write("Bitiş Yılı: ");
                egt.BitisTarihi = Console.ReadLine();
                Console.Write("Okuldaki not ortalaması");
                egt.NotOrtalamasi = SayiAl(1, 100);
                yeniEleman.egitimler.Add(egt);

                Console.WriteLine("Başka mezun olduğu okul var mı? (Varsa 0 yoksa herhangi bir sayı)");
            }
            while (SayiAl() == 0);

            Console.WriteLine("İş deneyimi mecvut mu? (Varsa 0 yoksa herhangi bir sayı)");
            while (SayiAl() == 0)
            {
                IsDeneyimi deneyim = new IsDeneyimi();
                Console.WriteLine("Çalıştığı işyerinin... ");
                Console.Write("Adı: ");
                deneyim.SirketAdi = Console.ReadLine();
                Console.Write("Adresi: ");
                deneyim.Adres = Console.ReadLine();
                Console.Write("Pozisyon veya görevi");
                deneyim.Pozisyon = Console.ReadLine();

                yeniEleman.isDeneyimleri.Add(deneyim);
                Console.WriteLine("Başka iş deneyimi mecvut mu? (Varsa 0 yoksa herhangi bir sayı)");
            }
            elemanlar.insert(yeniEleman);
            Console.WriteLine(yeniEleman.KisiAdi + " isimli kişi sisteme eklendi.");
        }
        public static int altMenu(int ustMenuSecim)
        {
            switch (ustMenuSecim)
            {
                case 1:
                    Console.WriteLine("1.Sisteme kayıt (kendi kişisel bilgilerini girme)");
                    Console.WriteLine("2.Sistemdeki bilgilerini güncelleme");
                    Console.WriteLine("3.Sistemden çıkma (bilgilerini silme)");
                    Console.WriteLine("4.Sistemdeki bir işe başvurma (başvurusu bulunan yere tekrar başvurulamaz");
                    Console.WriteLine("5.Üst menüye dön");
                    Console.Write("Lutfen seciminizi giriniz:");
                    return SayiAl(1, 5);
                case 2:
                    Console.WriteLine("1.Sisteme kayıt (işyeri bilgilerini ekleme)");
                    Console.WriteLine("2.Sistemdeki bilgilerini günleme");
                    Console.WriteLine("3.Yeni bir iş ilanı verme (ve yayınlama)");
                    Console.WriteLine("4.İşe başvuran tüm adayların bilgilerini listeleme");
                    Console.WriteLine("5.En uygun adayı işe alma (Bu kişi Heap’ten çekilecektir)");
                    Console.WriteLine("6.İş ilanını sistemden kimseyi işe almadan geri çekme");
                    Console.WriteLine("7.Üst menüye dön");
                    return SayiAl(1, 7);
                case 3:
                    Console.WriteLine("1.Adından kişi arama, tüm bilgilerini listeleme (başvurduğu işlerle birlikte).");
                    Console.WriteLine("2.Not ortalamalarından en az birisi, 90’ın üzerinde olan kişilerin adlarının listelenmesi.");
                    Console.WriteLine("3.İngilizce bilen kişilerin adlarının listelenmesi.");
                    Console.WriteLine("4.İkili arama ağacındaki tüm kişilerin adlarını düzeyleri ile birlikte Listeleme. Ağacın derinliğini ve eleman sayısını yazdırma. ");
                    Console.WriteLine("5.Üst menüye dön");
                    return SayiAl(1, 5);

            }
            return 0;
        }

        public static int menu()
        {
            Console.WriteLine("1.İş başvurusu yapan kişilerin kullanacağı bölüm");
            Console.WriteLine("2.Eleman arayan şirketlerin kullanacağı bölüm");
            Console.WriteLine("3.Ağaç işlemleri");
            Console.WriteLine("4.Çıkış");
            Console.Write("Lutfen seciminizi giriniz:");
            return SayiAl(1, 4);
        }
        private static void ElemanOku(Tree elemanlar)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Environment.CurrentDirectory + @"\eleman.txt");
            string line;
            Eleman e = null;
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("KİŞİ"))
                {
                    if (e != null)
                        elemanlar.insert(e);
                    e = new Eleman();
                    int i = 5;
                    e.KisiAdi = line[i].ToString();
                    while (line[++i] != '\t')
                        e.KisiAdi += line[i];

                    i = line.IndexOf("Eleman Adresi ") + 13;
                    e.ElemanAdresi = line[++i].ToString();
                    while (line[++i] != '\t')
                        e.ElemanAdresi += line[i];

                    i = line.IndexOf("Telefon ") + 7;
                    e.Telefon = line[++i].ToString();
                    while (line[++i] != '\t')
                        e.Telefon += line[i];

                    e.Uyruk = line[++i].ToString();
                    while (line[++i] != '\t')
                        e.Uyruk += line[i];

                    i = line.IndexOf("E-Posta") + 7;
                    e.EPosta = line[++i].ToString();
                    while (line[++i] != '\t')
                        e.EPosta += line[i];

                    e.DogumYeri = line[++i].ToString();
                    while (line[++i] != '\t')
                        e.DogumYeri += line[i];

                    e.DogumTarihi = line[++i].ToString();
                    while (line[++i] != '\t')
                        e.DogumTarihi += line[i];

                    e.MedeniDurum = line[++i].ToString();
                    while (line[++i] != '\t')
                        e.MedeniDurum += line[i];

                    e.YabanciDil = line[++i].ToString();
                    while (line[++i] != '\t')
                        e.YabanciDil += line[i];

                    e.IlgiAlanlari = line[++i].ToString();
                    while (line[++i] != '\t')
                        e.IlgiAlanlari += line[i];

                    e.ReferansOlanKisiler = line[++i].ToString();
                    while (++i != line.Length)
                        e.ReferansOlanKisiler += line[i];

                }
                else if (line.StartsWith("OKUL"))
                {
                    int i = 5;
                    EgitimDurumu egt = new EgitimDurumu();

                    egt.OkulAdi = line[i].ToString();
                    while (line[++i] != '\t')
                        egt.OkulAdi += line[i];

                    egt.Bolumu = line[++i].ToString();
                    while (line[++i] != '\t')
                        egt.Bolumu += line[i];

                    egt.BaslangicTarihi = line[++i].ToString();
                    while (line[++i] != '\t')
                        egt.BaslangicTarihi += line[i];

                    egt.BitisTarihi = line[++i].ToString();
                    while (line[++i] != '\t')
                        egt.BitisTarihi += line[i];

                    string notOrt = line[++i].ToString();
                    while (++i != line.Length)
                        notOrt += line[i];
                    egt.NotOrtalamasi = Int32.Parse(notOrt);

                    e.egitimler.Add(egt);
                }
                else
                {
                    int i = 8;
                    IsDeneyimi deneyim = new IsDeneyimi();

                    deneyim.SirketAdi = line[i].ToString();
                    while (line[++i] != '\t')
                        deneyim.SirketAdi += line[i];

                    deneyim.Adres = line[++i].ToString();
                    while (line[++i] != '\t')
                        deneyim.Adres += line[i];

                    deneyim.Pozisyon = line[++i].ToString();
                    while (++i != line.Length)
                        deneyim.Pozisyon += line[i];

                    e.isDeneyimleri.Add(deneyim);
                }
            }
        }

        private static void SirketleriOku(Hashtable sirketler)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Environment.CurrentDirectory + @"\sirket.txt");
            string line;
            Sirket s;
            while ((line = file.ReadLine()) != null)
            {
                s = new Sirket();

                int i = 11;
                s.SirketAdi = line[i].ToString();
                while (line[++i] != '\t')
                    s.SirketAdi += line[i];

                i = line.IndexOf("Tam Adresi ") + 10;
                s.TamAdresi = line[++i].ToString();
                while (line[++i] != '\t')
                    s.TamAdresi += line[i];

                i = line.IndexOf("Telefon ") + 7;
                s.TelefonNo = line[++i].ToString();
                while (line[++i] != '\t')
                    s.TelefonNo += line[i];

                i = line.IndexOf("Faks") + 4;
                s.Faks = line[++i].ToString();
                while (line[++i] != '\t')
                    s.Faks += line[i];

                i = line.IndexOf("E-Posta") + 7;
                s.EPosta = line[++i].ToString();
                while (++i != line.Length)
                    s.EPosta += line[i];

                sirketler[s.SirketAdi] = s;
            }

            file.Close();
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
    }

}

