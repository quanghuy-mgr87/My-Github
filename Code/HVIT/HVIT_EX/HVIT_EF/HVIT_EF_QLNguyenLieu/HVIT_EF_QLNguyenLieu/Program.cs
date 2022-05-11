using HVIT_EF_QLNguyenLieu.View;
using System;

namespace HVIT_EF_QLNguyenLieu
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            do
            {
                QLNguyenLieuView qLNguyenLieuView = new QLNguyenLieuView();
                qLNguyenLieuView.Menu();
                Console.ReadKey();
            } while (!exit);
        }
    }
}
