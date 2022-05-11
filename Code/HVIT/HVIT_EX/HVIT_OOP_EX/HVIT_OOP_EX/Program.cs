using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVIT_OOP_EX
{
    class Program
    {
        static void Main(string[] args)
        {
            //nhap lieu:
            LopHoc lop1 = new LopHoc();
            lop1.HienThi();

            //Truyen vao:
            Console.WriteLine();
            LopHoc lop2 = new LopHoc(2, "Lop 2", 30, "Ha Noi", "Thu Ha");
            lop2.HienThi();

            Console.ReadKey();
        }
    }
}
