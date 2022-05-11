using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_10
{
    class Program
    {
        static void Main(string[] args)
        {
            MaTran m1 = new MaTran();
            Console.WriteLine("Ma tran vua nhap:");
            m1.InMaTran();
            Console.WriteLine();
            int[,] a = { { 1, 2, 3 }, { 1, 2, 3 } };
            MaTran m2 = new MaTran(a, 2, 3);
            Console.WriteLine("Ma tran vua nhap:");
            m2.InMaTran();
            Console.WriteLine();
            Console.WriteLine("Tong 2 ma tran:");
            MaTran m = m1.CongMaTran(m2);
            if (m != null)
            {
                m.InMaTran();
            }
            else
            {
                Console.WriteLine("Loi khong cong duoc ma tran!");
            }
            Console.ReadKey();
        }
    }
}
