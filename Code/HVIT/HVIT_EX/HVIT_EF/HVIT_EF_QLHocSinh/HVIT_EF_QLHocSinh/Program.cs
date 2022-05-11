using HVIT_EF_QLHocSinh.View;
using System;

namespace HVIT_EF_QLHocSinh
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            do
            {
                QLHocSinhView qLHocSinhView = new QLHocSinhView();
                qLHocSinhView.Menu();
                Console.ReadKey();
            } while (!exit);
        }
    }
}
