
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System;
using System.Reflection;
using ConsoleApp1;

//using 
// See https://aka.ms/new-console-template for more information
// 테스트용 코드
//파싱
Console.WriteLine("Hello, World!");
//번호	이름	무기종류	무장수준	인원숫자	방탄복	숙련도	조직수준	분대지원장비(전투)
List<bat_unit> attacker = new List<bat_unit> { };
List<bat_unit> defender = new List<bat_unit> { };
farthing.readingdata(farthing.get_xl(false),attacker,1);
farthing.readingdata(farthing.get_xl(false),defender,2);
Console.WriteLine("----------------------------------");
Console.WriteLine("--------------수비측-------------");
Console.WriteLine("----------------------------------");
for (int i = 0; i < defender.Count; i++)
{
    var p = defender[i];
    Console.WriteLine(i + ": id:" + p.ID + "/hp :" + p.hp + "/무기이름 :" + "|");
}
Console.WriteLine("----------------------------------");
Console.WriteLine("---------------공격측---------------");
Console.WriteLine("----------------------------------");
for (int i = 0; i < attacker.Count; i++)
{
    var p = attacker[i];
    Console.WriteLine(i + ": id:" + p.ID + "/hp :" + p.hp + "/무기이름 :" + "|");
}

//파싱 체크
//매칭
List<innerbat> allbattle = new List<innerbat>();
allbattle = Matching.matching(attacker, defender);
Console.WriteLine("일어난 전투 수 /" + allbattle.Count);
for(int i = 0;i < allbattle.Count;i++)
{
    Console.WriteLine("전투" + i + "번의 공격 ID:","=","-");
    for (int j = 0;j < allbattle[i].visuallize(false).Count; j++)
    {
        Console.WriteLine(Convert.ToString(allbattle[i].visuallize(false)[j]),",");
    }
    Console.WriteLine("전투" + i + "번의 수비 ID:", "=");
    for (int j = 0; j < allbattle[i].visuallize(true).Count; j++)
    {
        Console.WriteLine(Convert.ToString(allbattle[i].visuallize(true)[j]), ",");
    }
    Console.WriteLine(" ");
}

//매칭 체크
//스텟 확정
for (int i = 0; i < allbattle.Count; i++)
{
    if (allbattle[i].attack.Count==1& allbattle[i].defence.Count == 1)
    {
        string atkweapname = allbattle[i].attack[0].weap;
        string defweapname = allbattle[i].defence[0].weap;
        string scope = allbattle[i].attack[0].sp;
        allbattle[i].attack[0].change_atp(weapon_to_atp.String_to_ATP(atkweapname, defweapname, scope));
        allbattle[i].attack[0].sync_xp();
    }
    else if(allbattle[i].attack.Count != 1& allbattle[i].defence.Count == 1)
    {
        for (int j = 0;j < allbattle[i].attack.Count; j++)
        {
            string atkweapname = allbattle[i].attack[j].weap;
            string defweapname = allbattle[i].defence[0].weap;
            string scope = allbattle[i].attack[j].sp;
            allbattle[i].attack[j].change_atp(weapon_to_atp.String_to_ATP(atkweapname, defweapname, scope));
            allbattle[i].attack[j].sync_xp();
        }

    }else
    {
        int checkwep =0;
        for (int j = 0;j < allbattle[i].defence.Count; j++)
        {
            int vik = weapon_to_atp.ranking_wep(allbattle[i].defence[j].weap);
            if (vik > checkwep)
            {
                checkwep = vik;
            }
        }
        string weapclass = weapon_to_atp.inverse_rank(checkwep);
        string atkweapname = allbattle[i].attack[0].weap;
        string scope = allbattle[i].attack[0].sp;
        allbattle[i].attack[0].change_atp(weapon_to_atp.String_to_ATP(atkweapname, weapclass, scope));
        allbattle[i].attack[0].sync_xp();


    }
}

for (int i = 0; i < allbattle.Count; i++)
{
    if (allbattle[i].defence.Count == 1 & allbattle[i].attack.Count == 1)
    {
        string atkweapname = allbattle[i].defence[0].weap;
        string defweapname = allbattle[i].attack[0].weap;
        string scope = allbattle[i].defence[0].sp;
        allbattle[i].defence[0].change_atp(weapon_to_atp.String_to_ATP(atkweapname, defweapname, scope));
        allbattle[i].defence[0].sync_xp();
    }
    else if (allbattle[i].defence.Count != 1 & allbattle[i].attack.Count == 1)
    {
        for (int j = 0; j < allbattle[i].defence.Count; j++)
        {
            string atkweapname = allbattle[i].defence[j].weap;
            string defweapname = allbattle[i].attack[0].weap;
            string scope = allbattle[i].defence[j].sp;
            allbattle[i].defence[j].change_atp(weapon_to_atp.String_to_ATP(atkweapname, defweapname, scope));
            allbattle[i].defence[j].sync_xp();
        }

    }
    else
    {
        int checkwep = 0;
        for (int j = 0; j < allbattle[i].attack.Count; j++)
        {
            int vik = weapon_to_atp.ranking_wep(allbattle[i].attack[j].weap);
            if (vik > checkwep)
            {
                checkwep = vik;
            }
        }
        string weapclass = weapon_to_atp.inverse_rank(checkwep);
        string atkweapname = allbattle[i].defence[0].weap;
        string scope = allbattle[i].defence[0].sp;
        allbattle[i].defence[0].change_atp(weapon_to_atp.String_to_ATP(atkweapname, weapclass, scope));
        allbattle[i].defence[0].sync_xp();


    }
}
for (int i = 0; i < allbattle[0].attack.Count; i++)
{
    Console.WriteLine("테스트 전투 선공 ID : " + allbattle[0].attack[i].ID + "/무기종류 :" + allbattle[0].attack[i].weap + 
        "/전투력(장) :" + allbattle[0].attack[i].atp[0]+ "/전투력(중) :" + allbattle[0].attack[i].atp[1]+ "/전투력(단) :" + allbattle[0].attack[i].atp[2]);
}
for (int i = 0; i< allbattle[0].defence.Count; i++)
{
    Console.WriteLine("테스트 전투(피해전) 후공 ID : " + allbattle[0].defence[i].ID + "/무기종류 :" + allbattle[0].defence[i].weap + "/hp :" + allbattle[0].defence[i].hp +
    "/전투력(장) :" + allbattle[0].defence[i].atp[0] + "/전투력(중) :" + allbattle[0].defence[i].atp[1] + "/전투력(단) :" + allbattle[0].defence[i].atp[2]);
}

//스텟 확정 체크

//장거리 전투
for (int i = 0; i < allbattle.Count; i++)
{
    allbattle[i].fighti(false, 0);
}
for (int i = 0;i < allbattle[0].defence.Count; i++)
{
    Console.WriteLine("테스트 전투(피해후) 후공 ID : " + allbattle[0].defence[i].ID + "/무기종류 :" + allbattle[0].defence[i].weap +"/hp :"+ allbattle[0].defence[i].hp+
    "/전투력(장) :" + allbattle[0].defence[i].atp[0] + "/전투력(중) :" + allbattle[0].defence[i].atp[1] + "/전투력(단) :" + allbattle[0].defence[i].atp[2]);
}

//장거리 전투 체크
//중거리 전투

//중거리 전투 체크
//단거리 전투

//단거리 전투 체크
//결과 파싱

//결과 파싱 체크
Console.WriteLine(" test end ");
