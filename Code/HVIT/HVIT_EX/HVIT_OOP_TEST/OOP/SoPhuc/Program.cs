using System;

namespace SoPhuc
{
    class Program
    {
        static void Main(string[] args)
        {
            SoPhuc soPhuc = new SoPhuc(1, 2);
            soPhuc.HienThi();
            SoPhuc soPhuc1 = new SoPhuc();
            soPhuc1.HienThi();
            Console.ReadKey();
        }
    }
}
