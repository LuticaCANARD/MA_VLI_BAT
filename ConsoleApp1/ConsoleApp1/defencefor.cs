using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal partial class defencefor
    {
        public static int defencefor_f(string bp)
        {
            int ibp = 0;
            if (bp == "NIJ II")
            {
                ibp = 150;
            }
            else if (bp == "NIJ IIIA")
            {
                ibp = 300;
            }
            else if (bp == "NIJ III")
            {
                ibp = 500;
            }
            else if (bp == "NIJ IV")
            {
                ibp = 800;
            }
            return ibp;
        }
    }
}
