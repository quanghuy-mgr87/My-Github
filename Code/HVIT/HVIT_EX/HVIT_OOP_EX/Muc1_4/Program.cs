using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<HocVien> lstHV = new List<HocVien>();
            lstHV.Add(new HocVien(1, "Nguyen Quang Dung", new DateTime(2000, 1, 1), 2, 1000000));
            lstHV.Add(new HocVien(2, "Nguyen Quang Duy", new DateTime(2000, 12, 11), 2.5, 2000000));
            lstHV.Add(new HocVien(3, "Nguyen Huy Hung", new DateTime(2000, 11, 12), 2.7, 5000000));
            lstHV.Add(new HocVien(4, "Nguyen Huy Hung", new DateTime(2000, 12, 12), 2.7, 5000000));

            Console.WriteLine("Danh sach hoc vien: ");
            lstHV.ForEach(x => x.HienThi());
            string str;
            Console.Write("\nNhap ten hoc vien can tim: ");
            str = Console.ReadLine();
            List<HocVien> lst = Helper.TimKiemHocVien(lstHV, str);
            Console.WriteLine($"Danh sach cac hoc vien co ten \"{str}\":");
            lst.ForEach(x => x.HienThi());
            Console.ReadKey();
        }
    }
}
