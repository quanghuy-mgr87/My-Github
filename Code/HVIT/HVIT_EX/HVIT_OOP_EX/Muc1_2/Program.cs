using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Nguoi nguoi = new Nguoi(1, "Truong    Tien Hoang Duong", new DateTime(1997, 1, 1));
            nguoi.HienThi();
            Console.WriteLine();
            Nguoi nguoi2 = new Nguoi();
            nguoi2.HienThi();
            Console.ReadKey();
        }
    }
}
