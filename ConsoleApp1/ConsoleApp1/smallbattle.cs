using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal partial class innerbat
    {
        bat_unit[] attack; bat_unit[] defence;
        public innerbat(bat_unit[] _attack, bat_unit[] _defence)
        {
            attack = _attack;
            defence = _defence;
        }
        public bool check_zero_and_kill(bool defence_check)
        {
            bool have_zero=false;
            var checking = this.attack;
            if (defence_check)
            {
                checking = this.defence;
            }
            int[] killingid = { };
            for (int i = 0; i < checking.Length; i++)
            {
                if (checking[i].hp <= 0)
                {
                    have_zero = true;
                    killingid.Append(i);
                }
            }
            for (int j = 0; j < killingid.Length; j++)
            {
                checking[killingid[j]] = 0;
            }
            return have_zero;
        }
    }
}
