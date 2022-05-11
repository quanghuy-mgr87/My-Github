using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_2
{
    class Helper
    {
        public static string[] CatChuoi(string str)
        {
            str = str.Trim();
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            string[] arr = str.Split(' ');
            return arr;
        }
    }
}
