using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            DonDatHang d1 = new DonDatHang();
            d1.HienThi();
            DonDatHang d2 = new DonDatHang(1, new DateTime(2020, 01, 20), "san pham 2", 30000, 5);
            d2.HienThi();
            Console.ReadKey();
        }
    }
}
