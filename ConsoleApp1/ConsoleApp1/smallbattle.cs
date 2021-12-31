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
        public int check_zero_and_kill(bool defence_check)
        {
            int have_zero=0;
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
                    have_zero++;
                    killingid.Append(i);
                }
            }
            for (int j = 0; j < killingid.Length; j++)
            {
                checking[killingid[j]].dead_unit(checking[killingid[j]].ID);
            }
            return have_zero;
        }
        public void fighti(bool defence_check,int phase)
        {
            var checking = this.attack; // 공격
            var checking_n = this.defence; // 방어
            if (defence_check)
            {
                checking = this.defence;
                checking_n = this.attack;
            }
            if (checking_n.Length == 1&& checking.Length==1)
            {
                checking_n[0].got_atk(checking[0].atp[phase]);
            }
            else if (checking_n.Length == 1&& checking.Length != 1)
            {
                int damagesum = 0;
                for (int i = 0;i < checking.Length; i++)
                {
                   damagesum += checking[i].atp[phase];
                }
                checking_n[0].got_atk(damagesum);
            }
            else if (checking_n.Length != 1 && checking.Length == 1)
            {
                for (int i = 0; i < checking_n.Length; i++)
                {

                }
            }
            else
            {
                Console.WriteLine("ERROR! , 매칭이 잘못됨. >> 다수vs다수가 진행됨. checking후 dameging과정에서 발생. 201.");
            }


        }

    }
}
