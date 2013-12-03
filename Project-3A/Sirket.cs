using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_3A
{
    class Sirket
    {
        string sirketAdi;

        public string SirketAdi
        {
            get { return sirketAdi; }
            set { sirketAdi = value; }
        }
        string tamAdresi;

        public string TamAdresi
        {
            get { return tamAdresi; }
            set { tamAdresi = value; }
        }
        string telefonNo;

        public string TelefonNo
        {
            get { return telefonNo; }
            set { telefonNo = value; }
        }
        string faks;

        public string Faks
        {
            get { return faks; }
            set { faks = value; }
        }
        string ePosta;

        public string EPosta
        {
            get { return ePosta; }
            set { ePosta = value; }
        }
        public override string ToString()
        {
            return sirketAdi + " " + tamAdresi + " " + telefonNo + " " + faks + " " + ePosta;
        }
    }
}
