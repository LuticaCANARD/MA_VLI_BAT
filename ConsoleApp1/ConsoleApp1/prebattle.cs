using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class prebattle
    {
        public void prebattle_cast (List<bat_unit> atk, List<bat_unit> def)
        {

        }
        public static void prebat_remat(List<innerbat> allbattle,bool defencemode)
        {

            List<bat_unit> R_x8 = new List<bat_unit>();
            for (int i = 0; i < allbattle.Count; i++)
            {
                var check = allbattle[i].defence;
                var check_n = allbattle[i].attack;
                if (defencemode==true)
                {
                    check = allbattle[i].attack;
                    check_n = allbattle[i].defence;
                }
                if (check.Count == 0)
                {
                    for (int j = 0; j < check_n.Count; j++)
                    {
                        R_x8.Add(check_n[j]);
                    }
                    allbattle.RemoveAt(i);
                    i--;
                }
            };
            for (int i = 0; i < R_x8.Count; i++)
            {
                Random r = new Random();
                int rdx = r.Next(0, allbattle.Count);
                if (defencemode) { allbattle[rdx].add_defence(R_x8[i]); } 
                else { allbattle[rdx].add_attack(R_x8[i]); }
               
            }
            //넣어보고 allbat에서 다대다 상황에서 분개
            for (int i = 0;i < allbattle.Count; i++)
            {
                bool have_problem = ((allbattle[i].attack.Count >= 2) && (allbattle[i].defence.Count >= 2));
                if (have_problem)
                {
                    List<bat_unit> atksk = new List<bat_unit>();
                    List<bat_unit> defsk = new List<bat_unit>();
                    atksk = allbattle[i].attack;
                    defsk = allbattle[i].defence;
                    atksk= Matching.Randomize(atksk);
                    defsk = Matching.Randomize(defsk);
                    if (defsk.Count == atksk.Count)
                    {
                        for(int j = 0; j < defsk.Count; j++)
                        {
                            List<bat_unit> atk_xia = new List<bat_unit>();
                            atksk[j].change_atp_str(defsk[j]);
                            defsk[j].change_atp_str(atksk[j]);
                            atk_xia.Add(atksk[j]);
                            List<bat_unit> def_xia = new List<bat_unit>();
                            def_xia.Add(defsk[j]);


                            innerbat xiabat = new innerbat(atk_xia, def_xia);
                            allbattle.Add(xiabat);

                        }
                    }
                    else
                    {
                        List<innerbat> Logica = new List<innerbat>();
                        int smallcou = defsk.Count;
                        int bigcou = atksk.Count;
                        var smalllist = defsk;
                        var biglist = atksk;
                        if (smallcou > bigcou)
                        {
                            smallcou = atksk.Count;
                            bigcou = defsk.Count;
                            smalllist = atksk;
                            biglist = defsk;
                        }
                        for(int j = 0;j < smallcou; j++)
                        {
                            List<bat_unit> atk_xia = new List<bat_unit>();
                            atk_xia.Add(atksk[j]);
                            List<bat_unit> def_xia = new List<bat_unit>();
                            def_xia.Add(defsk[j]);
                            innerbat xia_Bat = new innerbat(atk_xia,def_xia);
                            Logica.Add(xia_Bat);
                        }
                        defsk.RemoveRange(0 , smallcou);
                        atksk.RemoveRange(0, smallcou);
                        bigcou = bigcou - smallcou;
                        for (int j = 0;j < bigcou; j++)
                        {
                            Random r = new Random();
                            int rdx = r.Next(Logica.Count);
                            if (defsk.Count > atksk.Count)
                            {
                                Logica[rdx].add_defence(defsk[j]);
                            }
                            else
                            {
                                Logica[rdx].add_attack(atksk[j]);
                            }
                        }
                        for (int j = 0; j < Logica.Count; j++)
                        {
                            allbattle.Add(Logica[j]);
                        }
                    }
                    }
                if (allbattle[i].attack.Count == 0 && allbattle[i].defence.Count == 0)
                {
                    allbattle.RemoveAt(i);
                    i--;
                }

                }

        }
        }
    }

