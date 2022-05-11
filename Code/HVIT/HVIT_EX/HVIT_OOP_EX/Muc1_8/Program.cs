using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_8
{
    class Program
    {
        static void Main(string[] args)
        {
            ThoiGian t = new ThoiGian();
            t.HienThi();
            ThoiGian t2 = new ThoiGian(2020, 2, 1);
            t2.HienThi();
            Console.WriteLine();
            Console.WriteLine("Khoang thoi gian giua ngay t va t2");
            int n = t.LayKhoangThoiGian(t,t2);
            Console.WriteLine($"Khoang thoi gian giua 2 ngay la: {n} gio");
            Console.ReadKey();
        }
    }
}
