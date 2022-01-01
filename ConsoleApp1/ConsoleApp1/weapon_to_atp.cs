﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal partial class weapon_to_atp
    {
        public int[] String_to_ATP(string atk_weapn , string def_weapn,string atk_scope)
        {
            
            bool atk_nearwep = atk_weapn == "식칼" || atk_weapn == "창" || atk_weapn == "야구배트";
            bool atk_handgun = atk_weapn == "권총" || atk_weapn == "리볼버" || atk_weapn == "자동권총";
            bool atk_civilgun = atk_weapn == "산탄총" || atk_weapn == "볼트액션 소총" || atk_weapn == "민수용 반자동소총";
            bool atk_millitagun = atk_weapn == "기관단총" || atk_weapn == "자동소총" || atk_weapn == "지정사수소총";

            bool def_nearwep = def_weapn == "식칼" || def_weapn == "창" || def_weapn == "야구배트";
            bool def_handgun = def_weapn == "권총" || def_weapn == "리볼버" || def_weapn == "자동권총";
            bool def_civilgun = def_weapn == "산탄총" || def_weapn == "볼트액션 소총" || def_weapn == "민수용 반자동소총";
            bool def_millitagun = def_weapn == "기관단총" || def_weapn == "자동소총" || def_weapn == "지정사수소총";

            bool have_scope = atk_scope != "없음";
            int[] make_via(int min_damage, int max_damage,int order)
            {
                Random r = new Random();
                int delta = max_damage - min_damage;
                int damage = r.Next(delta) + min_damage;
                int[] via = { 0, 0, 0 };
                for (int i = 2;i >= order; i--)
                    via[i] = damage;
                return via;
            }
            if (atk_nearwep & def_nearwep)
            {
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

        }
    }
}
