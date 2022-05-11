using HVIT_EF_QLMonAn.View;
using System;

namespace HVIT_EF_QLMonAn
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            do
            {
                QLMonAnView qLMonAnView = new QLMonAnView();
                qLMonAnView.Menu();
                Console.ReadKey();
            } while (!exit);
        }
    }
}
