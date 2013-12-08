using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Project_3A
{
    class Program
    {
        static Random r = new Random();
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
                                case 2:
                                    Console.Write("Bilgileri güncellenecek kişinin adını giriniz: ");
                                    string kisiAdi = Console.ReadLine();
                                    if (elemanlar.ara(elemanlar.getRoot(), kisiAdi) != null)
                                    {
                                        //TODO Eleman guncelleme (Ağaç + Heap'deki referanslar) (Kişi adı değişimine göre ağaç güncellenmeli)
                                    }
                                    else
                                        Console.WriteLine("Kişi sisteme kayıtlı değil!");
                                    break;
                                case 3:
                                    Console.Write("Silinecek kişinin adını giriniz: ");
                                    TreeNode node = elemanlar.ara(elemanlar.getRoot(), Console.ReadLine());
                                    if (node != null)
                                    {
                                        Eleman e = node.eleman;
                                        foreach (Heap item in e.basvurduguIsIlanlari)
                                        {
                                            item.kisiyiIlandanCikar(e);
                                        }
                                        elemanlar.delete(e.KisiAdi);
                                    }
                                    else Console.WriteLine("Kişi sisteme kayıtlı değil!");
                                    break;
                                case 4:
                                    IsIlaninaBasvurma(sirketler, elemanlar);
                                    break;
                            }
                            break;
                        }
                    case 2:
                        {
                            switch (altMenu(secim))
                            {
                                case 1:
                                    YeniSirketEkle(sirketler);
                                    break;
                                case 2:
                                    SirketGuncelleme(sirketler);
                                    break;
                                case 3:
                                    Console.Write("İş ilanı verecek şirketi giriniz: ");
                                    Sirket srkt = (Sirket)sirketler[Console.ReadLine()];
                                    if (srkt != null)
                                    {
                                        Console.Write("İş ilanı açılan pozisyonun adı: ");
                                        Heap isIlani = new Heap(30, srkt, Console.ReadLine());
                                        srkt.isIlanlari.Add(isIlani);
                                    }
                                    else Console.WriteLine("Şirket sistemde kayıtlı değil!");
                                    break;
                                case 4:
                                    IseBasvuranAdaylariGoruntule(sirketler);
                                    break;
                                case 5:
                                    UygunAdayiIseAl(sirketler);
                                    break;
                                case 6:
                                    IlaniSistemdenKaldir(sirketler);
                                    break;
                            }
                            break;
                        }
                    case 3:
                        switch (altMenu(secim))
                        {
                            case 1:
                                KisiListele(elemanlar);
                                break;
                            case 2:
                                elemanlar.notOrt90Uzeri(elemanlar.getRoot());
                                break;
                            case 3: elemanlar.ingilizceBilenler(elemanlar.getRoot());
                                break;
                            case 4: //TODO
                                break;
                        }
                        break;
                }
            } while (secim != 4);


            Console.Read();
        }

        private static void SirketGuncelleme(Hashtable sirketler)
        {
            Console.Write("Bilgilerini güncellemek istediğiniz şirketin adını giriniz: ");
            Sirket s = (Sirket)sirketler[Console.ReadLine()];
            if (s != null)
            {
                Console.WriteLine("Şirketin...");
                string[] sirketOzellikleri = { "Tam Adresi", "Telefon", "Faks", "E-Posta" };
                string[] sirketBilgileri = { s.TamAdresi, s.TelefonNo, s.Faks, s.EPosta };
                for (int i = 0; i < sirketOzellikleri.Length; i++)
                {
                    Console.WriteLine("[" + i + "] " + sirketOzellikleri[i]);
                }
                Console.Write("Değiştirmek istediğiniz bilginin indeksini giriniz: (Cikis icin " + sirketOzellikleri.Length + ") ");
                int degistirilcekIndeks = SayiAl(0, sirketOzellikleri.Length);
                while (degistirilcekIndeks != sirketOzellikleri.Length)
                {
                    Console.WriteLine("Eski " + sirketOzellikleri[degistirilcekIndeks] + ": " + sirketBilgileri[degistirilcekIndeks]);
                    Console.Write("Yeni " + sirketOzellikleri[degistirilcekIndeks] + " giriniz: ");
                    sirketBilgileri[degistirilcekIndeks] = Console.ReadLine();
                    Console.Write("Değiştirmek istediğini bilginin indeksini giriniz: (Cikis icin " + sirketOzellikleri.Length + ") ");
                    degistirilcekIndeks = SayiAl(0, sirketOzellikleri.Length);
                }
                s.TamAdresi = sirketBilgileri[0];
                s.TelefonNo = sirketBilgileri[1];
                s.Faks = sirketBilgileri[2];
                s.EPosta = sirketBilgileri[3];
            }
            else Console.WriteLine("Şirket sistemde kayıtlı değil");
        }

        private static void IlaniSistemdenKaldir(Hashtable sirketler)
        {
            Console.Write("İş ilanını çekmek istediğiniz şirketin adını giriniz: ");
            Sirket sirket = (Sirket)sirketler[Console.ReadLine()];
            if (sirket != null)
            {
                if (sirket.isIlanlari.Count > 0)
                {
                    int indeks = 0;
                    Console.WriteLine(String.Format("{0,-7}{1,-20}{2,-21}{3,-17}", "İndeks", "Pozisyon", "Başvuran Kişi Sayısı", "Max Kişi Sayısı")); ;
                    foreach (Heap item in sirket.isIlanlari)
                    {
                        Console.WriteLine(String.Format("{0,-7}{1,-20}{2,-21}{3,-17}", indeks++, item.IsPozisyonu, item.CurrentSize, item.MaxSize));
                    }
                    Console.WriteLine();
                    Console.Write("Kaldırmak istediğiniz ilanın indeksini giriniz: ");
                    int silinecekIndeks = SayiAl(0, --indeks);
                    sirket.isIlanlari[silinecekIndeks].ilaniSistemdenCikar(); //ilan heap'i boşaltılır ve her düğümdeki elemanların başvurdukları ilanlardan çıkarılır
                    sirket.isIlanlari.RemoveAt(silinecekIndeks); //şirketin ilan listesinden ilan kaldırılır
                    Console.WriteLine("İlan kaldırıldı.");
                }
                else Console.WriteLine("Şirketin sistemde kayıtlı iş ilanı yok!");
            }
            else Console.WriteLine("Şirket sistemde kayıtlı değil!");
        }

        private static void UygunAdayiIseAl(Hashtable sirketler)
        {
            Console.Write("İşe alınacak iş ilanının ait olduğu şirketin adını giriniz: ");
            Sirket srk = (Sirket)sirketler[Console.ReadLine()];
            if (srk != null)
            {
                if (srk.isIlanlari.Count > 0)
                {
                    int indeks = 0;
                    Console.WriteLine(String.Format("{0,-7}{1,-20}{2,-21}{3,-17}", "İndeks", "Pozisyon", "Başvuran Kişi Sayısı", "Max Kişi Sayısı")); ;
                    foreach (Heap item in srk.isIlanlari)
                    {
                        Console.WriteLine(String.Format("{0,-7}{1,-20}{2,-21}{3,-17}", indeks++, item.IsPozisyonu, item.CurrentSize, item.MaxSize));
                    }
                    Console.WriteLine();
                    Console.Write("İşe eleman almak istediğiniz ilanın tablodaki indeksini giriniz: ");
                    int basvurulanIndeks = SayiAl(0, --indeks);
                    HeapNode nde = srk.isIlanlari[basvurulanIndeks].ilaniSistemdenCikar(); // ilandaki en yüksek uygunluğa sahip kişi döndürülür - ilandaki herkesin başvurduğu işlerden ilan çıkarılır
                    Console.WriteLine("İşe alınan eleman: " + nde.Eleman.KisiAdi);
                    Console.WriteLine("Uygunluk: " + nde.Uygunluk);
                    srk.isIlanlari.RemoveAt(basvurulanIndeks); //ilan şirketin ilan listesinden kaldırılır
                    foreach (Heap item in nde.Eleman.basvurduguIsIlanlari)
                    {
                        item.kisiyiIlandanCikar(nde.Eleman); //işe alınan kişi başvurduğu diğer ilanlardan çıkarılır
                    }
                }
                else Console.WriteLine("Şirketin sistemde kayıtlı iş ilanı mevcut değil!");

            }
            else Console.WriteLine("Şirket sistemde kayıtlı değil!");
        }

        private static void KisiListele(Tree elemanlar)
        {
            Console.Write("Aramak istediğiniz kişinin adını giriniz: ");
            TreeNode nd = elemanlar.ara(elemanlar.getRoot(), Console.ReadLine());
            if (nd != null)
            {
                Eleman e = nd.eleman;
                Console.WriteLine("Adı soyadi: " + e.KisiAdi);
                Console.WriteLine("Adresi: " + e.ElemanAdresi);
                Console.WriteLine("Telefonu: " + e.Telefon);
                Console.WriteLine("E-Posta: " + e.EPosta);
                Console.WriteLine("Uyruğu: " + e.Uyruk);
                Console.WriteLine("Doğum Yeri: " + e.DogumYeri);
                Console.WriteLine("Doğum Tarihi: " + e.DogumTarihi);
                Console.WriteLine("Medeni Durum: " + e.MedeniDurum);
                Console.WriteLine("Yabancı Dil: " + e.YabanciDil);
                Console.WriteLine("İlgi Alanları: " + e.IlgiAlanlari);
                Console.WriteLine("Referans olan kişiler: " + e.ReferansOlanKisiler);


                Console.WriteLine("Mezun olduğu okullar: ");
                Console.WriteLine(String.Format("{0,-20}{1,-11}{2,-12}{3,-11}{4,-8}", "Adı", "Bölümü", "Bşlngç Yılı", "Bitiş Yılı", "Not Ort"));
                foreach (EgitimDurumu item in e.egitimler)
                {
                    Console.WriteLine(String.Format("{0,-20}{1,-11}{2,-12}{3,-11}{4,-8}", item.OkulAdi, item.Bolumu, item.BaslangicTarihi, item.BitisTarihi, item.NotOrtalamasi));
                }

                Console.Write("Çalıştığı işyerleri: ");
                if (e.isDeneyimleri.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(String.Format("{0,-20}{1,-11}{2,-20}", "Adı", "Adresi", "Pozisyon veya görevi"));
                    foreach (IsDeneyimi item in e.isDeneyimleri)
                    {
                        Console.WriteLine(String.Format("{0,-20}{1,-11}{2,-20}", item.SirketAdi, item.Adres, item.Pozisyon));
                    }
                }
                else Console.Write("Yok.\n");
                Console.WriteLine("Başvurduğu iş ilanları: ");
                if (e.basvurduguIsIlanlari.Count > 0)
                {
                    Console.WriteLine(String.Format("{0,-11}{1,-20}{2,-21}{3,-17}", "Şirket Adı", "Pozisyon", "Başvuran Kişi Sayısı", "Max Kişi Sayısı")); ;
                    foreach (Heap item in e.basvurduguIsIlanlari)
                    {
                        Console.WriteLine(String.Format("{0,-11}{1,-20}{2,-21}{3,-17}", item.Sirket.SirketAdi, item.IsPozisyonu, item.CurrentSize, item.MaxSize));
                    }
                }
                else Console.Write("Yok.\n");
            }
            else Console.WriteLine("Aranılan kişinin sistemde kaydı yok!");
        }

        private static void IseBasvuranAdaylariGoruntule(Hashtable sirketler)
        {
            Console.Write("Başvuran adaylarını görüntülemek istedğiniz şirketin adını giriniz: ");
            Sirket sirket = (Sirket)sirketler[Console.ReadLine()];
            if (sirket != null)
            {
                if (sirket.isIlanlari.Count != 0)
                {
                    int indeks = 0;

                    Console.WriteLine(String.Format("{0,-7}{1,-11}{2,-20}{3,-21}{4,-17}", "İndeks", "Şirket Adı", "Pozisyon", "Başvuran Kişi Sayısı", "Max Kişi Sayısı")); ;
                    foreach (Heap item in sirket.isIlanlari)
                    {

                        Console.WriteLine(String.Format("{0,-7}{1,-11}{2,-20}{3,-21}{4,-17}", indeks++, item.Sirket.SirketAdi, item.IsPozisyonu, item.CurrentSize, item.MaxSize));
                    }
                    Console.WriteLine();
                    Console.Write("İşe başvuranları görmek istediğiniz ilanın tablodaki indeksini giriniz: ");
                    int basvurulanIndeks = SayiAl(0, --indeks);
                    sirket.isIlanlari[basvurulanIndeks].displayHeap();
                }
                else Console.WriteLine("Şirketin sistemde kayıtlı iş ilanı mevcut değil!");
            }
            else Console.WriteLine("Şirket sistemde kayıtlı değil!");
        }

        private static void IsIlaninaBasvurma(Hashtable sirketler, Tree elemanlar)
        {
            IDictionaryEnumerator enumerator = sirketler.GetEnumerator();
            int indeks = 0; //ekrana yazdırılan tablonun indeksi -> listede tutulan iş ilanlarına erişimi sağlar
            List<Heap> sistemdekiAktifIlanlar = new List<Heap>();
            Console.WriteLine(String.Format("{0,-7}{1,-11}{2,-20}{3,-21}{4,-17}", "İndeks", "Şirket Adı", "Pozisyon", "Başvuran Kişi Sayısı", "Max Kişi Sayısı")); ;
            while (enumerator.MoveNext())
            {
                if (((Sirket)enumerator.Value).isIlanlari != null)
                {
                    foreach (Heap item in ((Sirket)enumerator.Value).isIlanlari)
                    {
                        sistemdekiAktifIlanlar.Add(item); //hashtable dolaşılarak aktif iş ilanları listeye atılıyor
                        Console.WriteLine(String.Format("{0,-7}{1,-11}{2,-20}{3,-21}{4,-17}", indeks++, item.Sirket.SirketAdi, item.IsPozisyonu, item.CurrentSize, item.MaxSize));
                    }
                }
            }
            Console.WriteLine();
            Console.Write("Başvurmak istediğiniz ilanın tablodaki indeksini giriniz: ");
            int basvurulanIndeks = SayiAl(0, --indeks);

            Console.Write("İşe başvuracak kişinin ismini giriniz: ");
            TreeNode nd = elemanlar.ara(elemanlar.getRoot(), Console.ReadLine());

            if (nd != null)
            {
                Eleman e = nd.eleman;
                if (!e.basvurduguIsIlanlari.Contains(sistemdekiAktifIlanlar[basvurulanIndeks])) //kişinin bu işe daha önce başvurmadığı kontrol ediliyor
                {
                    double uygunluk;
                    Console.Write("Uygunluk değerini kendiniz girmek için 0'ı\nRastgele üretilmesi için herhangi bir değeri tuşlayınız: ");
                    if (SayiAl() == 0)
                    {
                        Console.Write("0.0-10.0 aralığında bir sayı tuşlayınız: ");
                        uygunluk = SayiAl(0.0, 10.0);
                    }
                    else
                    {
                        uygunluk = r.NextDouble() * 10; //0,0-10,0
                        Console.WriteLine("Uygunluk değeri: " + uygunluk);
                    }
                    sistemdekiAktifIlanlar[basvurulanIndeks].insert(uygunluk, e);
                    e.basvurduguIsIlanlari.Add(sistemdekiAktifIlanlar[basvurulanIndeks]);
                    Console.WriteLine(e.KisiAdi + " isimli kullanıcı ilana başvurdu.");
                }
                else Console.WriteLine("Kişi daha önce bu ilana başvurmuş!");
            }
            else Console.WriteLine("Kişi sistemde bulunamadı!");
        }

        private static void YeniSirketEkle(Hashtable sirketler)
        {
            Sirket srkt = new Sirket();
            Console.WriteLine("Eklenecek işyerinin...");
            Console.Write("Adı: ");
            srkt.SirketAdi = Console.ReadLine();
            Console.Write("Tam Adresini: ");
            srkt.TamAdresi = Console.ReadLine();
            Console.Write("Telefonu: ");
            srkt.TelefonNo = Console.ReadLine();
            Console.Write("Faks: ");
            srkt.Faks = Console.ReadLine();
            Console.Write("E-Posta: ");
            srkt.EPosta = Console.ReadLine();
            sirketler.Add(srkt.SirketAdi, srkt);
            Console.WriteLine(srkt.SirketAdi + " isimli şirket sisteme eklendi.");
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
                Console.Write("Okuldaki not ortalaması: ");
                egt.NotOrtalamasi = SayiAl(1, 100);
                yeniEleman.egitimler.Add(egt);

                Console.Write("Başka mezun olduğu okul var mı? (Varsa 0 yoksa herhangi bir sayı): ");
            }
            while (SayiAl() == 0);

            Console.Write("İş deneyimi mecvut mu? (Varsa 0 yoksa herhangi bir sayı): ");
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
                Console.Write("Başka iş deneyimi mecvut mu? (Varsa 0 yoksa herhangi bir sayı): ");

            }
            elemanlar.insert(yeniEleman);
            Console.WriteLine(yeniEleman.KisiAdi + " isimli kişi sisteme eklendi.");
        }
        public static int altMenu(int ustMenuSecim)
        {
            Console.WriteLine();
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
                    Console.WriteLine("2.Sistemdeki bilgilerini güncelleme");
                    Console.WriteLine("3.Yeni bir iş ilanı verme (ve yayınlama)");
                    Console.WriteLine("4.İşe başvuran tüm adayların bilgilerini listeleme");
                    Console.WriteLine("5.En uygun adayı işe alma");
                    Console.WriteLine("6.İş ilanını sistemden kimseyi işe almadan geri çekme");
                    Console.WriteLine("7.Üst menüye dön");
                    Console.Write("Lutfen seciminizi giriniz:");
                    return SayiAl(1, 7);
                case 3:
                    Console.WriteLine("1.Adından kişi arama, tüm bilgilerini listeleme (başvurduğu işlerle birlikte).");
                    Console.WriteLine("2.Not ortalamalarından en az birisi, 90’ın üzerinde olan kişilerin adlarının listelenmesi.");
                    Console.WriteLine("3.İngilizce bilen kişilerin adlarının listelenmesi.");
                    Console.WriteLine("4.İkili arama ağacındaki tüm kişilerin adlarını düzeyleri ile birlikte Listeleme. Ağacın derinliğini ve eleman sayısını yazdırma. ");
                    Console.WriteLine("5.Üst menüye dön");
                    Console.Write("Lutfen seciminizi giriniz:");
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
        private static double SayiAl(double a, double u)
        {
            bool hatali;
            double secim = 0;
            do
            {
                hatali = true;

                try
                {
                    secim = Double.Parse(Console.ReadLine());
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

