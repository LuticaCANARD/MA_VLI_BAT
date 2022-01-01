using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal partial class weapon_to_atp
    {
        public static int[] String_to_ATP(string atk_weapn , string def_weapn, string atk_scope)
        {
            
            bool atk_nearwep = atk_weapn == "식칼" || atk_weapn == "창" || atk_weapn == "야구배트";
            bool atk_handgun = atk_weapn == "권총" || atk_weapn == "리볼버" || atk_weapn == "자동권총";
            bool atk_civilgun = atk_weapn == "산탄총" || atk_weapn == "볼트액션 소총" || atk_weapn == "민수용 반자동소총";
            bool atk_millitagun = atk_weapn == "기관단총" || atk_weapn == "자동소총" || atk_weapn == "지정사수소총";
          
            bool def_nearwep = def_weapn == "식칼" || def_weapn == "창" || def_weapn == "야구배트";
            //bool def_handgun = def_weapn == "권총" || def_weapn == "리볼버" || def_weapn == "자동권총";
            //bool def_civilgun = def_weapn == "산탄총" || def_weapn == "볼트액션 소총" || def_weapn == "민수용 반자동소총";
            //bool def_millitagun = def_weapn == "기관단총" || def_weapn == "자동소총" || def_weapn == "지정사수소총";

            bool have_scope = atk_scope != "없음";
            int[] make_via(int min_damage, int max_damage,int order)
            {
                Random r = new Random();
                int delta = max_damage - min_damage;
                int damage = r.Next(delta) + min_damage;
                int[] via = { 0, 0, 0 };
                for (int i = 2; i >= order; i--)
                {
                    via[i] = damage;
                    if (have_scope == true)
                    {
                        via[i] = Convert.ToInt32(via[i] * 1.2);
                    }
                }
                return via;
            }
            if (atk_nearwep & def_nearwep)
            {// 근접 vs 근접
                if(atk_weapn== "야구배트"& def_weapn == "식칼")
                {
                    return make_via(15,25,1);
                }
                else if ( atk_weapn =="창"& def_weapn != "창")
                {
                    return make_via(15, 25,1);
                }
                else if(atk_weapn == "식칼")
                {
                    return make_via(5,10,2);
                }
                else
                {
                    return make_via(15,25,2);
                }

            }
            else if (atk_nearwep & !def_nearwep)
            { // 근접
                if (atk_weapn == "식칼")
                {
                    return make_via(5, 10, 2);
                }
                else
                {
                    return make_via(15, 25, 2);
                }
            }
            else if(atk_handgun)
            { // 권총 vs 근접
                if(atk_weapn == "권총")
                {
                    return (make_via(15, 200, 0));

                }
                else if( atk_weapn == "리볼버")
                {
                    int[] orivia = make_via(35, 250, 0);
                    Random rand = new Random();
                    int pix = rand.Next(100)+20;
                    orivia[2] = pix;
                   return (orivia);
                }
                else
                {
                    return (make_via(15, 290, 0));
                }
            }
            else if (atk_civilgun)
            {
                if (atk_weapn == "산탄총")
                {
                    int[] vax = make_via(50, 290, 1);
                    vax[2] = vax[2] * 3;
                    return (vax);
                }
                else if (atk_weapn == "볼트액션 소총")
                {
                    int[] vax = make_via(20, 320, 0);
                    if (have_scope)
                    {
                        vax[0] = vax[0] * 3;
                        vax[1] = vax[1] * 3;
                        vax[2] = vax[2] * 3;
                    }
                    return (vax);
                }
                else
                {
                    return make_via(25,300,0);
                }
            }
            else if (atk_millitagun)
            {
                if (atk_weapn == "기관단총")
                {
                    int[] vax = make_via(30, 370, 0);
                    vax[0] = (int) vax[0]/2;
                    vax[2] = (int) vax[2]*2;
                    return (vax);
                }
                else if (atk_weapn == "자동소총")
                {
                    return make_via(60,400,0);
                }
                else
                {
                    return make_via(100, 370, 0);
                }
            }
            else
            {
                Console.WriteLine("ERROR! 무장이 제대로 기입되었는지 확인하시오");
                int [] errr = new int[3] { 0 , 0 ,0 };
                return errr;
            }


        }
        public static int ranking_wep(string wepn)
        {
                if(wepn== "식칼")
            {
                return 1;
            }else if (wepn == "창")
            {
                return 3;
            }else if (wepn == "야구배트")
            {
                return 2;
            }
                else
            {
                return 4;
            }
        }

        public static string inverse_rank(int rank)
        {
            string s = "권총";
            if (rank == 1)
            {
                s = "식칼";
            }else if (rank == 2)
            {
                s = "야구배트";
            }else if(rank == 3)
            {
                s = "창";
            }
            return s;
            
        }
    }
    

}
