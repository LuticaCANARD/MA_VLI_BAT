using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    internal partial class Zero_check
    {

            
            

            //[ [ [공1 , 공2 ] , [수1] ] , [ [공3] , [수2] ] ]
            void bat_check_zero(bat_unit[][][] batlist,bool defmode,bat_unit[]source_list)
        {
            int checkmo;
            int checkmo_n;
            if (defmode)
            {
                checkmo = 1;
                checkmo_n = 0;
            }
            else
            {
                checkmo = 0;
                checkmo_n = 1;
            }

                int i;
            for (i=0; i<batlist.Length; i++)
            {
                int j = 0;
                for (j = 0; j < batlist[i][checkmo].Length; j++) {
                    if (batlist[i][checkmo][j].hp == 0)
                    {

                    }
                }
            };
        }
    }
}
