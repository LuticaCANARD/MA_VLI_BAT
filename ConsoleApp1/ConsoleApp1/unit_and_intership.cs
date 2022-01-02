using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    internal partial class bat_unit
    {
        public int ID; public int[] atp; public int hp; public int bp; public string xp; public int cp; public string sp; public string weap; bool dead;

        public bat_unit(int _ID, int[] _atp, int _hp, int _bp, string _xp, int _cp, string _sp, string _weap)
        // ID, 공격력[3], 체력, 방어력(방탄복), 숙련도,조직수준, 지원장비(전투),무기이름
        {
            ID = _ID; atp = _atp; hp = _hp; bp = _bp; xp = _xp; cp = _cp; sp = _sp; weap = _weap; dead = false;
        }
        
        public void got_atk(int damage)
        {
            int sdamage;
            int ibp;
            ibp = defencefor.defencefor_f(bp);

            if (damage - ibp <= 0)
                sdamage = 0;
            else
                sdamage = damage - ibp;
            this.hp = this.hp - sdamage;

            if (this.hp <= 0)
            {
                this.hp = 0;
                this.dead = true;
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
        public void dead_unit(int _ID)
        {
            int[] deadki = new int[3] { 0, 0, 0 };
            ID = _ID; atp = deadki; hp = 0; bp = 0; xp = "사망"; cp = 0; sp = ""; weap = "0";dead = true;
        }

        public void change_atp(int[] atk)
        {
            this.atp = atk;
        }
        public void change_atp_str(bat_unit anemi)
        {
            this.atp = weapon_to_atp.String_to_ATP(this.weap,anemi.weap,this.sp);
        }
        public void change_atp_str_long(List<bat_unit> anemi)
        {
            int rank = 0;
            for (int i = 0; i < anemi.Count; i++)
            {
                rank = weapon_to_atp.ranking_wep(anemi[i].weap);
            }
            string best_wep = weapon_to_atp.inverse_rank(rank);
            this.atp = weapon_to_atp.String_to_ATP(this.weap, best_wep, this.sp);
        }
        public void change_atp_by_an_cp(int cp)
        {
            
        }

    };
}
