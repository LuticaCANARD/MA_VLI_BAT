
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System;
using System.Reflection;
using ConsoleApp1;

//using 
// See https://aka.ms/new-console-template for more information
// 테스트용 코드

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
    Console.WriteLine(i + ": id:" + p.ID + "/hp :" + p.hp + "/무기이름 :" + p.weap + "/공격력(장거리)" + p.atp[0] + "/공격력(중거리)" + p.atp[1] + "/공격력(단거리)" + p.atp[2] + "|");
}
Console.WriteLine("----------------------------------");
Console.WriteLine("---------------공격측---------------");
Console.WriteLine("----------------------------------");
for (int i = 0; i < attacker.Count; i++)
{
    var p = attacker[i];
    Console.WriteLine(i + ": id:" + p.ID + "/hp :" + p.hp + "/무기이름 :" + p.weap + "/공격력(장거리)" + p.atp[0] + "/공격력(중거리)" + p.atp[1] + "/공격력(단거리)" + p.atp[2] + "|");
}
