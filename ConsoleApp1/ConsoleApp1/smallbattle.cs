using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal partial class innerbat
    {
        public List<bat_unit> attack; public List<bat_unit> defence;
        public innerbat(List<bat_unit> _attack, List<bat_unit> _defence)
        {
            attack = _attack;
            defence = _defence;
        }
        public bool check_zero_count(bool defence_check)
        {
            bool have_zero = false;
            var checking = this.attack;
            if (defence_check==true)
            {
                checking = this.defence;
            }
            List<int> killingid = new List<int> { };
            for (int i = 0; i < checking.Count; i++)
            {
                if (checking[i].hp <= 0)
                {
                    have_zero = true;
                    killingid.Add(i);
                }
            }
            while (! (killingid.Count== 0))
            {
                checking.RemoveAt(killingid[0]);
                killingid.RemoveAt(0);
                for (int i = killingid.Count-1; i >= 0; i--)
                {
                    killingid[i] = killingid[i] - 1;
                }
            }

            return have_zero;
        }
        public void fighti(bool defence_check, int phase)
        {
            var checking = this.attack; // 공격
            var checking_n = this.defence; // 방어
            if (defence_check)
            {
                checking = this.defence;
                checking_n = this.attack;
            }
            if (checking_n.Count == 1 && checking.Count == 1)
            {
                checking_n[0].got_atk(checking[0].atp[phase]);
            }
            else if (checking_n.Count == 1 && checking.Count != 1)
            {
                int damagesum = 0;
                for (int i = 0; i < checking.Count; i++)
                {
                    damagesum += checking[i].atp[phase];
                }
                checking_n[0].got_atk(damagesum);
            }
            else if (checking_n.Count != 1 && checking.Count == 1)
            {
                List<int> randompic = new List<int> { };
                Random Rand = new Random();
                for (int i = 0; i < checking_n.Count; i++)
                {
                    randompic.Add(Rand.Next(100));
                }
                int sumofrand = randompic.Sum();
                for (int i = 0; i < checking_n.Count; i++)
                {
                    int damageofran = checking[0].atp[phase];
                    double mize = ((double)randompic[i] / (double)sumofrand);
                    int damaz = Convert.ToInt32(damageofran * mize);
                    checking_n[i].got_atk(damaz);
                };
            }
            else
            {
                Console.WriteLine("ERROR! , 매칭이 잘못됨. >> 다수vs다수가 진행됨. checking후 dameging과정에서 발생. 201.");
                Console.WriteLine("내부 전투 수비측 : " + this.defence);
                Console.WriteLine("내부 전투 공격측 : " + this.attack);
            }
        }

        public List<int> visuallize(bool defence)
        {
            var check = this.attack;
            if (defence)
            {
                check = this.defence;
            }
            List<int> list = new List<int>();
            for (int i = 0; i < check.Count; i++)
            {
                list.Add(check[i].ID);
            }
            return list;
        }
        public void add_attack(bat_unit unit)
        {
            this.attack.Add(unit);
        }

        public void add_defence(bat_unit unit)
        {
            this.defence.Add(unit);
        }
        public static List<innerbat> fightingk (List<innerbat>allbat,bool defmode,int pha) 
        {
            for (int i = 0; i < allbat.Count; i++)
            {
                allbat[i].fighti(defmode, pha);
            }
            bool shape = false;
            bool stoping = true;
            for (int i = 0; i < allbat.Count; i++)
            {

                shape = allbat[i].check_zero_count(!defmode);
            }
            if (shape)
            { // 완전 사멸된 경우
                for (int i = 0; i < allbat.Count; i++)
                {
                    if (allbat[i].defence.Count >= 0)
                    {
                        stoping = false;
                    }
                }
                prebattle.prebat_remat(allbat, defmode);
                Console.WriteLine("완전사멸 o");
            }
            return allbat;

        }
        public static bool alldied(List<innerbat> allbat,bool defence_che)
        {
            // 다 죽으면 true
            bool die = false;
            
            for (int i = 0;i < allbat.Count; i++)
            {
                var che = allbat[i].attack;
                if (defence_che)
                {
                    che = allbat[i].defence;
                }
                if(che.Count > 0)
                {
                    die = true;
                }
                

            }
            die = !die;
            return die;
        }
        }
    }

         

    

    

