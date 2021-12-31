
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System;
using System.Reflection;
using ConsoleApp1;

//using 
// See https://aka.ms/new-console-template for more information
// 테스트용 코드

Console.WriteLine("Hello, World!");
bat_unit[] attacker = { };
bat_unit[] defender = { };
farthing.readingdata(farthing.get_xl(false),attacker,1);
farthing.readingdata(farthing.get_xl(false),defender,2);
for (int i = 0; i < defender.Length; i++)
{
    var p = defender[i];
    Console.WriteLine(i+": id:"+p.ID+"/hp :"+p.hp);
}
Console.WriteLine(attacker);
Console.WriteLine(defender);