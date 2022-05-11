using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Weekday w = new Weekday();
            w.HienThi();
            Weekday w2 = new Weekday(2020, 12, 13);
            w2.HienThi();
            int SoNgay = w.LayKhoangThoiGian(w2);
            Console.WriteLine($"So ngay chenh lech giua 2 ngay la: {SoNgay} ngay.");
            Console.ReadKey();
        }
    }
}
