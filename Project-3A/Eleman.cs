using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_3A
{
    class Eleman
    {
        public Eleman()
        {
            isDeneyimleri = new List<IsDeneyimi>();
            egitimler = new List<EgitimDurumu>();
            basvurduguIsIlanlari = new List<Heap>();
        }
        private string kisiAdi;

        public string KisiAdi
        {
            get { return kisiAdi; }
            set { kisiAdi = value; }
        }

        private string elemanAdresi;

        public string ElemanAdresi
        {
            get { return elemanAdresi; }
            set { elemanAdresi = value; }
        }
        private string telefon;

        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }
        private string uyruk;

        public string Uyruk
        {
            get { return uyruk; }
            set { uyruk = value; }
        }
        private string ePosta;

        public string EPosta
        {
            get { return ePosta; }
            set { ePosta = value; }
        }

        private string dogumYeri;

        public string DogumYeri
        {
            get { return dogumYeri; }
            set { dogumYeri = value; }
        }
        private string dogumTarihi;

        public string DogumTarihi
        {
            get { return dogumTarihi; }
            set { dogumTarihi = value; }
        }

        private string medeniDurum;

        public string MedeniDurum
        {
            get { return medeniDurum; }
            set { medeniDurum = value; }
        }
        private string yabanciDil;

        public string YabanciDil
        {
            get { return yabanciDil; }
            set { yabanciDil = value; }
        }
        private string ilgiAlanlari;

        public string IlgiAlanlari
        {
            get { return ilgiAlanlari; }
            set { ilgiAlanlari = value; }
        }
        private string referansOlanKisiler;

        public string ReferansOlanKisiler
        {
            get { return referansOlanKisiler; }
            set { referansOlanKisiler = value; }
        }
        public List<IsDeneyimi> isDeneyimleri;
        public List<EgitimDurumu> egitimler;
        public List<Heap> basvurduguIsIlanlari;
        public void egitimleriListele()
        {
            Console.WriteLine(String.Format("{0,-7}{1,-20}{2,-11}{3,-12}{4,-11}{5,-8}", "İndeks", "Adı", "Bölümü", "Bşlngç Yılı", "Bitiş Yılı", "Not Ort"));

            for (int i = 0; i < egitimler.Count; i++)
            {
                Console.WriteLine(String.Format("{0,-7}{1,-20}{2,-11}{3,-12}{4,-11}{5,-8}", "[" + i + "]", egitimler[i].OkulAdi, egitimler[i].Bolumu, egitimler[i].BaslangicTarihi, egitimler[i].BitisTarihi, egitimler[i].NotOrtalamasi));
            }
            Console.WriteLine();
        }
        public void isDeneyimleriniListele()
        {
            Console.WriteLine(String.Format("{0,-7}{1,-20}{2,-11}{3,-20}", "İndeks", "Adı", "Adresi", "Pozisyon veya görevi"));
            for (int i = 0; i < isDeneyimleri.Count; i++)
            {
                Console.WriteLine(String.Format("{0,-7}{1,-20}{2,-11}{3,-20}", "[" + i + "]", isDeneyimleri[i].SirketAdi, isDeneyimleri[i].Adres, isDeneyimleri[i].Pozisyon));
            } 
            Console.WriteLine();
        }
    }
}
