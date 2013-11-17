using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project2._1
{
    public class Node
    {
        private String renk;

        public String Renk
        {
            get { return renk; }
            set { renk = value; }
        }
        private Node sonraki;

        public Node Sonraki
        {
            get { return sonraki; }
            set { sonraki = value; }
        }

        public Node(string r)
        {
            renk = r;
            sonraki = null;
        }
    }
    class CircularList
    {
        private Node ilk;
        private Node cikacak;
        private int n;
        public int GetBoyut()
        {
            int boyut = 0;
            if (ilk == null)
                return 0;
            else
            {
                boyut = 1;
                Node gecici = ilk.Sonraki;
                while (gecici == ilk)
                {
                    boyut++;
                    gecici = gecici.Sonraki;
                }
                return boyut;
            }
         
        }
        public int N
        {
            get { return n; }
            set { n = value; }
        }


        public CircularList(int n)
        {
            cikacak = null;
            ilk = null;
            this.n = n;

        }

        public Boolean isEmpty()
        {
            return ilk == null;
        }

        public void insertEnd(String re)
        {
            Node yeni = new Node(re);

            if (isEmpty())
            {
                ilk = yeni;
            }
            else
            {
                Node tp = ilk;
                while (tp.Sonraki != ilk)
                {
                    tp = tp.Sonraki;
                }
                tp.Sonraki = yeni;
            }
            yeni.Sonraki = ilk;

            cikacak = yeni;
        }

        public void insertBegin(String re)
        {
            Node yeni2 = new Node(re);

            if (isEmpty())
            {
                yeni2.Sonraki = yeni2;
            }
            else
            {
                Node tp = ilk;
                while (tp.Sonraki != ilk)
                {
                    tp = tp.Sonraki;
                }
                tp.Sonraki = yeni2;
                yeni2.Sonraki = ilk;
            }
            ilk = yeni2;
        }

        public string Cikar() //Balon problemine benzer şekilde n adet araba atlanarak çıkarma işlemi yapılır.
        {
            Atla(n);
            Node cikarilan = null;
            if (!isEmpty())
            {
                if (cikacak == ilk)
                    ilk = ilk.Sonraki;

                cikarilan = cikacak;

                if (cikacak.Sonraki == cikacak)
                    ilk = null;
                else
                {
                    Node gecici = ilk;
                    while (gecici.Sonraki != cikacak)
                        gecici = gecici.Sonraki;
                    gecici.Sonraki = gecici.Sonraki.Sonraki;
                }

            }

            return cikarilan.Renk;
        }

        private void Atla(int n) //Kullanıcıdan alınan n değerine göre balon problemine benzer şekilde n adet araba atlanarak 
        {
            if (cikacak == null)
            {
                cikacak = ilk;

            } if (n != 1)
                for (int i = 1; i < n; i++)
                {
                    cikacak = cikacak.Sonraki;
                }
        }

        public void yazdir() //Dairesel bağlaçlı listedeki arabaları yazdırır.
        {
            Node etkin = ilk;

            if (!isEmpty())
            {
                int sayac = 1;
                do
                {
                    Console.WriteLine(sayac++ +") "+etkin.Renk);
                    etkin = etkin.Sonraki;
                } while (etkin != ilk);
            }
        }
    }
}


