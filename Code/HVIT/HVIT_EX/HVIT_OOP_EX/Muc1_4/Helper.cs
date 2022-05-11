using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_4
{
    class Helper
    {
        public static List<HocVien> TimKiemHocVien(List<HocVien> lst, string name)
        {
            List<HocVien> newLst = new List<HocVien>();
            foreach (HocVien val in lst)
            {
                if (val.KiemTraTen(name))
                    newLst.Add(val);
            }
            return newLst;
        }
    }
}
