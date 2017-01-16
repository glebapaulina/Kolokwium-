using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodrozWPF
{
    class Stacja: ICloneable
    {
        private string nazwaStacji;
        private bool oplataKlimatyczna;

        public Stacja(string nazwaStacji, bool oplataKlimatyczna)
        {
            this.nazwaStacji = nazwaStacji;
            this.oplataKlimatyczna = oplataKlimatyczna;          
        }

        public Stacja() { }
        public override string ToString()
        {
            string oplata = "";
            if (oplataKlimatyczna)
            {
                oplata += "Tak";
            }
            else
            {
                oplata += "Nie";
            }
            return string.Format("Stacja: {0}, opłata klimatyczna: {1}", nazwaStacji, oplata);
        }

        public bool JakaOplata()
        {
            return oplataKlimatyczna;
        }

        public Object Clone()
        {
            return MemberwiseClone();
        }

    
    }
}
