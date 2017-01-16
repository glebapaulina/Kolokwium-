using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PodrozWPF
{
    class Podroz : IStacja
    {
        protected Queue<Stacja> stacje = new Queue<Stacja>();

        protected double koszt = 100;

        public Podroz()
        { }

        public virtual double KosztPoRabacie()
        {
            return 0.9 * koszt;
        }

        public override string ToString()
        {
            string result = "Podróż: " + Environment.NewLine; 
            foreach(var element in stacje)
            {
                result += (element.ToString() + Environment.NewLine);
            }
            result += ("Koszt po rabacie: "+ KosztPoRabacie());
            return result;
        }

        public void DodajStacje(string nazwa, bool oplata)
        {
            stacje.Enqueue(new Stacja(nazwa, oplata));
            if (oplata)
            {
                koszt += 15;
            }
        }

        public void UsunStacje()
        {           
                stacje.Dequeue();          
        }

        public void Powrot()
        {
            Stacja stacja1 = stacje.Peek();
            Stacja stacja2 = new Stacja();
            stacja2 = (Stacja)stacja1.Clone();
            stacje.Enqueue(stacja2);
        }

        public void ZapiszPodroz()
        {
            using (StreamWriter sw = new StreamWriter("podroz.txt"))
            {
                sw.Write(ToString());                
            }
        }
    }
}
