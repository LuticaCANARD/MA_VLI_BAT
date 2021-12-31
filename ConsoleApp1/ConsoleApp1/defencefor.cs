using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal partial class defencefor
    {
        public static int defencefor_f(int bp)
        {
            int ibp = 0;
            if (bp == 1)
            {
                ibp = 150;
            }
            else if (bp == 2)
            {
                ibp = 300;
            }
            else if (bp == 3)
            {
                ibp = 500;
            }
            else if (bp == 4)
            {
                ibp = 800;
            }
            return ibp;
        }
    }
}
