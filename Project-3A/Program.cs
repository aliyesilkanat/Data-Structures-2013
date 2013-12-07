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

            
            elemanlar.delete("Arda Kaya");
            //elemanlar.delete("Tolga Dogan");
            elemanlar.inOrder(elemanlar.getRoot());
            Console.Read();
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
                    //TODO e referansının ağaca atılmasi gerekiyor
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

                    deneyim.Sirket = line[i].ToString();
                    while (line[++i] != '\t')
                        deneyim.Sirket += line[i];

                    deneyim.Adres = line[i].ToString();
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
                //Console.WriteLine(s.ToString());

            }

            file.Close();
        }
    }
}
