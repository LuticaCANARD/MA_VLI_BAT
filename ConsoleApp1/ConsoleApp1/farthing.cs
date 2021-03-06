using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System;
using System.Reflection;

namespace ConsoleApp1
{
    internal partial class farthing
    {
        public static void readingdata(string path, List<bat_unit> readinglist, int mode)
        {//파싱
         // 번호1	  이름2	무기종류3	무장수준4	인원숫자5	방탄복6	숙련도7	조직수준8	분대지원장비(전투)9
            Excel.Application excelApp = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;
            try
            {
                excelApp = new Excel.Application();
                wb = excelApp.Workbooks.Open(path);
                ws = wb.Worksheets.get_Item(mode);
                int readingpoint = 1;
                while (ws.Cells[readingpoint, 1].Value != null)
                {
                    if (readingpoint == 1)
                    {
                        readingpoint++;
                        continue;
                    }
                    else
                    {
                        //번호 이름 무장수준 인원숫자    방탄복 숙련도 조직수준
                        int ID = (int)ws.Cells[readingpoint, 1].value();
                        string name = ws.Cells[readingpoint, 2].value();
                        string weapon_name = ws.Cells[readingpoint, 3].value();
                        int hp = (int)ws.Cells[readingpoint, 5].value();
                        string barrier_p = ws.Cells[readingpoint, 6].value();
                        string xp = ws.Cells[readingpoint, 7].value();
                        int cro_point = (int)ws.Cells[readingpoint, 8].value();
                        string scope_name = ws.Cells[readingpoint, 4].value();
                        int[] ksp = { 0, 0, 0 };
                        bat_unit appending = new bat_unit(ID, ksp, hp, barrier_p, xp, cro_point, scope_name, weapon_name, name);
                        readinglist.Add(appending);
                        readingpoint++;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "errr");
            }
            finally
            {
                if (wb != null)
                {
                    wb.Close();
                }
            }

        }
        public static string get_xl(bool output)
        {
            // mode == 0 > input 불러오기 , ==1 > output불러오기
            var url = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var urlx = "";
            if (output == true)
            {
                urlx = Path.Combine(url, "outputo.xlsx");

            }
            else
            {
                urlx = Path.Combine(url, "inputn.xlsx");

            };
            string path_file = new Uri(urlx).LocalPath;
            Console.WriteLine(path_file);
            return path_file.ToString();

        }

        public static void outbounddata(List<innerbat> allbat, string path)
        {
            {//파싱
             // 번호1	  이름2	무기종류3	무장수준4	인원숫자5	방탄복6	숙련도7	조직수준8	분대지원장비(전투)9
                Excel.Application excelApp = null;
                Excel.Workbook wb = null;
                Excel.Worksheet ws = null;
                try
                {
                    excelApp = new Excel.Application();
                    wb = excelApp.Workbooks.Open(path);
                    ws = wb.Worksheets.get_Item(1);
                    int writp = 2;
                    while (!(Convert.ToString(ws.Cells[writp, 1].Value()) =="")&& writp <= 200)
                    {
                        ws.Cells[writp, 1] = "";
                        ws.Cells[writp, 2] = "";
                        ws.Cells[writp, 3] = "";
                        ws.Cells[writp, 4] = "";
                        ws.Cells[writp, 5] = "";
                        ws.Cells[writp, 6] = "";
                        ws.Cells[writp, 7] = "";
                        ws.Cells[writp, 8] = "";
                        writp++;
                    }
                    writp = 2;
                    for (int i = 0; i < allbat.Count; i++)
                    {
                        for(int j = 0; j < allbat[i].attack.Count; j++)
                        {
                            ws.Cells[writp,1] = allbat[i].attack[j].ID;
                            ws.Cells[writp, 2] = allbat[i].attack[j].name;
                            ws.Cells[writp, 3] = allbat[i].attack[j].weap;
                            ws.Cells[writp, 4] = allbat[i].attack[j].sp;
                            ws.Cells[writp, 5] = allbat[i].attack[j].hp;
                            ws.Cells[writp, 6] = allbat[i].attack[j].bp;
                            ws.Cells[writp, 7] = allbat[i].attack[j].xp;
                            ws.Cells[writp, 8] = allbat[i].attack[j].cp;
                            writp++;
                        }
                        
                    }

                    writp = 2;
                    ws = wb.Worksheets.get_Item(2);
                    while (!(Convert.ToString(ws.Cells[writp, 1].Value()) == "")&&writp<=200)
                    {
                        ws.Cells[writp, 1] = "";
                        ws.Cells[writp, 2] = "";
                        ws.Cells[writp, 3] = "";
                        ws.Cells[writp, 4] = "";
                        ws.Cells[writp, 5] = "";
                        ws.Cells[writp, 6] = "";
                        ws.Cells[writp, 7] = "";
                        ws.Cells[writp, 8] = "";
                        writp++;
                    }
                    writp = 2;
                    for (int i = 0; i < allbat.Count; i++)
                    {
                        for (int j = 0; j < allbat[i].defence.Count; j++)
                        {
                            ws.Cells[writp, 1] = allbat[i].defence[j].ID;
                            ws.Cells[writp, 2] = allbat[i].defence[j].name;
                            ws.Cells[writp, 3] = allbat[i].defence[j].weap;
                            ws.Cells[writp, 4] = allbat[i].defence[j].sp;
                            ws.Cells[writp, 5] = allbat[i].defence[j].hp;
                            ws.Cells[writp, 6] = allbat[i].defence[j].bp;
                            ws.Cells[writp, 7] = allbat[i].defence[j].xp;
                            ws.Cells[writp, 8] = allbat[i].defence[j].cp;
                            writp++;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "errr");
                }
                finally
                {
                    if (wb != null)
                    {
                        wb.Close();
                    }
                }
            }


        }
    } }
