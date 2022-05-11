using System;
using System.Collections.Generic;
using System.Linq;

namespace TieuTien
{
    class Program
    {
        static List<string> lstCode = new List<string>();
        static int CountNumber(int num)
        {
            int count = 0;
            while (num != 0)
            {
                count++;
                num /= 10;
            }
            return count;
        }
        static int CountTradingCode(List<string> lstBill, string strDate)
            => lstBill.Where(x => x.Contains(strDate)).ToList().Count();
        static string CreateTradingCode()
        {
            string code = "";
            DateTime currentDay = DateTime.Now;
            string strDate = currentDay.Year.ToString();
            strDate += CountNumber(currentDay.Month) >= 2 ? currentDay.Month.ToString() : "0" + currentDay.Month.ToString();
            strDate += CountNumber(currentDay.Day) >= 2 ? currentDay.Day.ToString() : "0" + currentDay.Day.ToString();
            int count = CountTradingCode(lstCode, strDate);
            if (count == 0)
            {
                code += strDate + "_001";
            }
            else
            {
                int num = CountNumber(++count);
                code += strDate + "_";
                code += (num >= 3) ? count.ToString() : num >= 2 ? "0" + count.ToString() : "00" + count.ToString();
            }
            return code;
        }
        static void ViewList(List<string> lstStr)
            => lstStr.ForEach(x => Console.WriteLine(x));
        static void Main(string[] args)
        {
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            lstCode.Add(CreateTradingCode());
            ViewList(lstCode);
            Console.ReadKey();
        }
    }
}
