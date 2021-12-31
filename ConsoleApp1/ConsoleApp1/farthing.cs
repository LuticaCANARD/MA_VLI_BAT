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
                        //번호	이름	무기종류	무장수준	인원숫자	방탄복	숙련도	조직수준	분대지원장비(전투)
                        int ks1 = (int) ws.Cells[readingpoint, 1].value();
                        string ks2 = ws.Cells[readingpoint, 2].value();
                        string ks3 = ws.Cells[readingpoint, 3].value();
                        int ks4 = (int)ws.Cells[readingpoint, 4].value();
                        int ks5 = (int)ws.Cells[readingpoint, 5].value();
                        int ks6 = (int)ws.Cells[readingpoint, 6].value();
                        string ks7 = ws.Cells[readingpoint, 7].value();
                        int ks8 = (int)ws.Cells[readingpoint, 8].value();
                        string ks9 = ws.Cells[readingpoint, 9].value();
                        int[] ksp = { ks4, ks4, ks4 };
                        bat_unit appending = new bat_unit(ks1, ksp, ks5, ks6, ks7, ks8, ks9, ks3);
                        readinglist.Add(appending);
                        readingpoint++;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message+"errr");
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
            var urlx="";
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
    }
}
