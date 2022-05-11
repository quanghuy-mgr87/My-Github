using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            SoNguyen s1 = new SoNguyen();
            s1.HienThi();
            Console.WriteLine();
            SoNguyen s2 = new SoNguyen(12321);
            s2.HienThi();
            int result = s1.Cong(s2.GiaTri);
            Console.WriteLine($"{s1.GiaTri} + {s2.GiaTri} = {result}.");
            Console.ReadKey();
        }
    }
}
