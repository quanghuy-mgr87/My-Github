using API_ThucHanh.Entities;
using API_ThucHanh.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ThucHanh.Helper
{
    public class InputHelper
    {
        public static int CountNumber(int num)
        {
            int count = 0;
            while (num != 0)
            {
                count++;
                num /= 10;
            }
            return count;
        }

        /// <summary>
        /// get number of trading code like param strDate
        /// </summary>
        /// <param name="lstBill">list of bill</param>
        /// <param name="strDate">date was converted to string</param>
        /// <returns>the number of trading code</returns>
        public static int CountTradingCode(List<Bill> lstBill, string strDate)
            => lstBill.Where(x => x.tradingCode.Contains(strDate)).ToList().Count();

        /// <summary>
        /// Create trading code
        /// This function will check all bills in your list bill, get the number of the trading code on current day and generate corresponding codes 
        /// </summary>
        /// <returns>code</returns>
        public static string CreateTradingCode()
        {
            BillServices billServices = new BillServices();
            var lstBill = billServices.GetBillList("").ToList();
            string code = "";
            DateTime currentDay = DateTime.Now;
            string strDate = currentDay.Year.ToString();
            strDate += CountNumber(currentDay.Month) >= 2 ? currentDay.Month.ToString() : "0" + currentDay.Month.ToString();
            strDate += CountNumber(currentDay.Day) >= 2 ? currentDay.Day.ToString() : "0" + currentDay.Day.ToString();
            int count = CountTradingCode(lstBill, strDate);
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
    }
}
