using QLKhoaHocMVC.View;
using System;

namespace QLKhoaHocMVC
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            do
            {
                KhoaHocView khoaHocView = new KhoaHocView();
                khoaHocView.Menu();
                Console.ReadKey();
            } while (!exit);
        }
    }
}
