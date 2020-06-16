using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cPro2
{
    class Keypad
    {
        public int GetInput()
        {
            int a;
            a =Convert.ToInt32( Console.ReadLine());
            return a;
        }
    }
}
