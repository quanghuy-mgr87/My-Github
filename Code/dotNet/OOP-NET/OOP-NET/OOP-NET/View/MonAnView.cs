using OOP_NET.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_NET.View
{
    class MonAnView
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("" +
                "1. Them mon an\n" +
                "2. Xoa mon an\n" +
                "3. Sua thong tin mon an\n" +
                "4. Tim mon an theo ten\n" +
                "5. Hien thi danh sach mon an\n" +
                "6. Thoat");
            Console.Write("Chon: ");
            char c = Console.ReadKey().KeyChar;
            ThucHien(c);
        }
        private static void ThucHien(char c)
        {
            switch (c)
            {
                case '1':
                    {

                    }
                    break;
                case '2':
                    break;
                case '3':
                    break;
                case '4':
                    break;
                case '5':
                    break;
                case '6':
                    break;

                default:
                    break;
            }
        }
    }
}
