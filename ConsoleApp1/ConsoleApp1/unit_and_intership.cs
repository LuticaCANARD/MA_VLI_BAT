using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class bat_unit
    {
        public int ID; public int[] atp; public int hp; public int bp; public string xp; public int cp; public int sp; public string weap;

        public bat_unit(int _ID, int[] _atp, int _hp, int _bp, string _xp, int _cp, int _sp, string _weap)
        // ID, 공격력[3], 체력, 방어력(방탄복), 숙련도,조직수준, 지원장비(전투),무기이름
        {
            ID = _ID; atp = _atp; hp = _hp; bp = _bp; xp = _xp; cp = _cp; sp = _sp; weap = _weap;
        }
        public void got_atk(int damage)
        {
            int sdamage;
            if (damage - bp <= 0)
                sdamage = 0;
            else
                sdamage = damage - bp;

            if (this.hp - sdamage <= 0)
            {
                this.hp = 0;
            }

        }
        public void sync_xp()
        {
            double sigma;
            if (xp == "신병")
            { sigma = 0.85; }
            else if (xp == "기간병")
            { sigma = 1; }
            else if (xp == "전문가")
            { sigma = 1.10; }
            else if (xp == "정예병")
            { sigma = 1.05; }
            else { sigma = 1; }
            atp[0] = Convert.ToInt32(atp[0] * sigma);
            atp[1] = Convert.ToInt32(atp[1] * sigma);
            atp[2] = Convert.ToInt32(atp[2] * sigma);
        }

    };
}
