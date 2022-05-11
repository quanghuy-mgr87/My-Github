using System;
using HVIT_MVCTest.View;

namespace HVIT_MVCTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ok = false;
            do
            {
                DuAnView duAnView = new DuAnView();
                duAnView.Menu();
                Console.ReadKey();
            } while (!ok);
        }
    }
}
