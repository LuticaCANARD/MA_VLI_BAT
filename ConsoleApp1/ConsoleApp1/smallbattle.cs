using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal partial class innerbat
    {
        List<bat_unit> attack; List<bat_unit> defence;
        public innerbat(List<bat_unit> _attack, List<bat_unit> _defence)
        {
            attack = _attack;
            defence = _defence;
        }
        public bool check_zero_count(bool defence_check)
        {
            bool have_zero=false;
            var checking = this.attack;
            if (defence_check)
            {
                checking = this.defence;
            }
            List<int> killingid = new List<int> { };
            for (int i = 0; i < checking.Count; i++)
            {
                if (checking[i].hp <= 0)
                {
                    have_zero=true;
                    killingid.Append(i);
                }
            }
            for (int j = 0; j < killingid.Count; j++)
            {
                checking.RemoveAt(killingid[j]);
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
            if (checking_n.Count == 1&& checking.Count==1)
            {
                checking_n[0].got_atk(checking[0].atp[phase]);
            }
            else if (checking_n.Count == 1&& checking.Count != 1)
            {
                int damagesum = 0;
                for (int i = 0;i < checking.Count; i++)
                {
                   damagesum += checking[i].atp[phase];
                }
                checking_n[0].got_atk(damagesum);
            }
            else if (checking_n.Count != 1 && checking.Count == 1)
            {
                int[] randompic = { };
                Random Rand = new Random();
                for (int i = 0; i < checking_n.Count; i++)
                {
                    randompic.Append(Rand.Next(100));
                }
                int sumofrand = randompic.Sum();
                for (int i = 0; i < checking_n.Count; i++)
                {
                    int damageofran = checking[0].atp[phase] * (randompic[i] / sumofrand);
                    checking_n[i].got_atk(damageofran);
                };
            }
            else
            {
                Console.WriteLine("ERROR! , 매칭이 잘못됨. >> 다수vs다수가 진행됨. checking후 dameging과정에서 발생. 201.");
                Console.WriteLine("내부 전투 수비측 : " + this.defence);
                Console.WriteLine("내부 전투 공격측 : " + this.attack);
            }


        }

    }
}
