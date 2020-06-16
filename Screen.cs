using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cPro2
{
    class Screen
    {
        public void DisplayMessage(string p)
        {
            Console.WriteLine(p);
        }
        public void DisplayMessageLine(string p)
        {
            Console.WriteLine(p);
        }
        public void DisplayDollaramount(decimal amount)
        {
            Console.WriteLine("$%,.3f", amount);
        }
    }
}
