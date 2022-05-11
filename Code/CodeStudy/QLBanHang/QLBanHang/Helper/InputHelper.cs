using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Helper
{
    internal class InputHelper
    {
        public static bool KiemTraSo(string str)
        {
            return int.TryParse(str, out int i);
        }

        public static string ChuanHoaHoTen(string str)
        {
            IEnumerable<string> lst = str.Split(' ')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.First().ToString().ToUpper() + x.Substring(1).ToLower());
            return string.Join(" ", lst);
        }
    }
}
