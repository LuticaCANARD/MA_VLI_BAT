using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    internal partial class Matching
    {
        public static List<innerbat> matching(List<bat_unit> attacker, List<bat_unit> defender)
        {
            List<innerbat> output = new List<innerbat> { };
            int counter_a = attacker.Count;
            int counter_b = defender.Count;
            List<bat_unit> R_attacker =Randomize(attacker);
            List<bat_unit> R_defender = Randomize(defender);
            int Bigc = counter_a;
            int Smallc = counter_b;
            if(counter_a< counter_b)
            {
                Bigc = counter_b;
                Smallc = counter_a;
            }
            if (counter_a == counter_b)
            {
                for (int i = 0; i < R_attacker.Count; i++)
                {
                    List<bat_unit> atk_n = new List<bat_unit> { R_attacker[i]};
                    List<bat_unit> def_n = new List<bat_unit> { R_defender[i]};
                    innerbat smao = new innerbat(atk_n, def_n);
                    output.Add(smao);
                }
                return output;
            }
            else 
            {

                List<bat_unit> Biglist= new List<bat_unit>();
                if(counter_a < counter_b)
                {
                    Biglist = R_defender;
                }
                else
                {
                    Biglist = R_attacker;
                }

                //문제 x

                List<List< List < bat_unit> >> logicga = new List<List<List<bat_unit>>> ();
                for (int i = 0; i < Smallc; i++)
                {
                    List<bat_unit> atk_n = new List<bat_unit> { R_attacker[i] };
                    List<bat_unit> def_n = new List<bat_unit> { R_defender[i] };
                    List<List<bat_unit>> nomal = new List<List<bat_unit>> { };
                    
                    logicga.Add(nomal);
                    logicga[i].Add(atk_n);
                    logicga[i].Add(def_n);
                }
                Biglist.RemoveRange(0, Smallc);

                int bigkoc = 0;
                if (defender.Count > attacker.Count)
                    bigkoc = 1;
                //여기 문제
                for (int i= 0; i < Biglist.Count; i++)
                {
                    Random r = new Random();
                    int rdx=r.Next(logicga.Count);
                    logicga[rdx][bigkoc].Add(Biglist[i]);
                }
                for (int i= 0;i< logicga.Count;i++)
                {
                    innerbat smao = new innerbat(logicga[i][0], logicga[i][1]);
                    output.Add(smao);
                }
                return output;
            }
          
        }
        public static List<T> Randomize<T>(List<T> list)
        {
            List<T> randomizedList = new List<T>();
            Random rnd = new Random();
            while (list.Count > 0)
            {
                int index = rnd.Next(0, list.Count); //pick a random item from the master list
                randomizedList.Add(list[index]); //place it at the end of the randomized list
                list.RemoveAt(index);
            }
            return randomizedList;
        }
        public void re_match(List<innerbat>allbattle,List<bat_unit>unit_list,bool defencemode)
        {
            int switch_ofk = 0;
            int switch_opk = 1;
            if (defencemode)
            {
                switch_ofk = 1;
                switch_opk = 0;
            }

            for(int i = 0; i < unit_list.Count; i++)
            {
                Random rnd = new Random();
                int r=rnd.Next(allbattle.Count);
                if (defencemode)
                {
                    allbattle[r].add_defence(unit_list[i]);
                }
                else
                {
                    allbattle[r].add_attack(unit_list[i]);
                }
                
            }
        }

    }
}
