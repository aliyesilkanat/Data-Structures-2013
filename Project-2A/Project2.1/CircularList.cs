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
        private Node sonCikan;

        public CircularList()
        {
            ilk = null;
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
                tp.Sonraki=yeni;
            }
            yeni.Sonraki=ilk;

            sonCikan = yeni;
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
                tp.Sonraki=yeni2;
                yeni2.Sonraki=ilk;
            }
            ilk = yeni2;
        }

        public Node cikart()
        {
            Node cikar = null;
            if (!isEmpty())
            {
                if (sonCikan.Sonraki== ilk)
                    ilk = ilk.Sonraki;

                cikar = sonCikan.Sonraki;

                if (sonCikan.Sonraki == sonCikan)
                    ilk = null;

                sonCikan.Sonraki=sonCikan.Sonraki.Sonraki;
            }

            return cikar;
        }

        public void Atla(int n)
        {
            int count = 1;
            while ( count != n)
            {
                count++;
                sonCikan = sonCikan.Sonraki;
                
            }
        }

        public void yazdir()
        {
            Node etkin = ilk;

            if (!isEmpty())
            {
                do
                {
                    Console.Write(etkin.Renk +" ");
                    etkin = etkin.Sonraki;
                } while (etkin != ilk);
            }
        }
    }
}


