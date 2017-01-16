using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodrozWPF
{
    class LastMinute: Podroz
    {
        public override double KosztPoRabacie()
        {
            return 0.5 * koszt;
        }

        public override string ToString()
        {
            string result = "Podróż: " + Environment.NewLine;
            foreach (var element in stacje)
            {
                result += (element.ToString() + Environment.NewLine);
            }
            result += (KosztPoRabacie() + Environment.NewLine + "LastMinute");
            return result;
        }
    }
}
