
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
// See https://aka.ms/new-console-template for more information
// 테스트용 코드
Console.WriteLine("Hello, World!");
int[] stkp = { 2, 99, 4 };
int[] stkp2 = { 5, 6, 7 };
bat_unit first_unit = new bat_unit(1, stkp , 5,0, "신병", 8, 9,"무기이름");
bat_unit second_unit = new bat_unit(2, stkp2, 5, 0, "신병", 8, 9, "무기이름");
void battlep(bat_unit atk, bat_unit def, int kind)
{

    //여기서 무기별 특수능력 반영
    def.got_atk(atk.atp[kind]);
}

void readingdata(string path)
{//파싱
    // id , 이름 , 
    Excel.Application excelApp = null;
    Excel.Workbook wb = null;
    Excel.Worksheet ws = null;
    try
    {
        excelApp=new Excel.Application();
        wb = excelApp.Workbooks.Open(path);
        ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;
        
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    };

}
Console.WriteLine(second_unit.hp);
battlep(first_unit, second_unit, 1);
Console.WriteLine(second_unit.hp);
Console.WriteLine(first_unit.hp);
Console.WriteLine(first_unit.atp[1]);

































//유닛 class
class bat_unit
{
    public int ID; public int[] atp ; public int hp; public int bp; public string xp; public int cp; public int sp; public string weap;

    public bat_unit(int _ID, int[] _atp, int _hp,int _bp, string _xp, int _cp ,int _sp, string _weap)
    {
        ID = _ID; atp = _atp; hp = _hp; bp = _bp; xp = _xp; cp = _cp; sp = _sp; weap = _weap;
    }
    public void got_atk(int damage)
    {
        int sdamage;
        if (damage - bp <= 0)
            sdamage = 0;
        else
            sdamage = damage - bp;

        if (this.hp - sdamage <= 0)
        {
            this.hp = 0;
        }

    }
    public void sync_xp() {
        double sigma;
        if (xp == "신병")
        { sigma = 0.85; }
        else if (xp == "기간병")
        { sigma = 1; }
        else if (xp == "전문가")
        { sigma = 1.10; }
        else if (xp == "정예병")
        { sigma = 1.05; }
        else { sigma = 1; }
        atp[0] = Convert.ToInt32(atp[0] * sigma);
        atp[1] = Convert.ToInt32(atp[1] * sigma);
        atp[2] = Convert.ToInt32(atp[2] * sigma);
    }

};

