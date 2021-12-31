
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System;
using System.Reflection;
using ConsoleApp1;

//using 
// See https://aka.ms/new-console-template for more information
// 테스트용 코드

Console.WriteLine("Hello, World!");
int[] stkp = { 2, 99, 4 };
int[] stkp2 = { 5, 6, 7 };
 bat_unit first_unit = new bat_unit(1, stkp, 5, 0, "신병", 8, 9, "무기이름");
 bat_unit second_unit = new bat_unit(2, stkp2, 5, 0, "신병", 8, 9, "무기이름");
 void battlep(bat_unit atk, bat_unit def, int kind)
 {

  //여기서 무기별 특수능력 반영
  def.got_atk(atk.atp[kind]);
  }
  Console.WriteLine(second_unit.hp);
  battlep(first_unit, second_unit, 1);
  Console.WriteLine(second_unit.hp);
  Console.WriteLine(first_unit.hp);
  Console.WriteLine(first_unit.atp[1]);































//유닛 class


