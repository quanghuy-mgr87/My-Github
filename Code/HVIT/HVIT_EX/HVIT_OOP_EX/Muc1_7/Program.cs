using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_7
{
    class Program
    {
        static void Main(string[] args)
        {
            DongHo d1 = new DongHo();
            d1.HienThi(0);
            DongHo d2 = new DongHo(12, 15, 15);
            d2.HienThi(0);

            DongHo d3 = d1.LayKhoangThoiGian(d2);
            Console.WriteLine("\nKhoang thoi gian giua d1 va d2:");
            d3.HienThi(1);

            Console.ReadKey();
        }
    }
}
