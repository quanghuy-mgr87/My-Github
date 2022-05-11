using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            PhanSo p1 = new PhanSo();
            p1.HienThi();
            PhanSo p2 = new PhanSo(3, 9);
            p2.HienThi();
            Console.WriteLine();
            Console.WriteLine("- Tong 2 phan so:");
            PhanSo p = p1.Cong(p2);
            p.HienThi();
            Console.WriteLine("- Hieu 2 phan so:");
            p = p1.Tru(p2);
            p.HienThi();
            Console.ReadKey();
        }
    }
}
