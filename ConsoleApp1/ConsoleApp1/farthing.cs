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
        public static void readingdata(string path, bat_unit[] readinglist, int mode)
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
                        double[] aktp = new double[3] { ws.Cells[readingpoint, 4].Value, ws.Cells[readingpoint, 4].Value, ws.Cells[readingpoint, 4].Value };
                        readinglist.Append(new bat_unit(
                            // ID, 공격력[3], 체력, 방어력(방탄복), 숙련도,조직수준, 지원장비(전투),무기이름
                            ws.Cells[readingpoint, 1].Value, aktp, ws.Cells[readingpoint, 5], ws.Cells[readingpoint, 6], ws.Cells[readingpoint, 7], ws.Cells[readingpoint, 8], ws.Cells[readingpoint, 9], ws.Cells[readingpoint, 3]
                            ));
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
