using System;
using System.Collections.Generic;
using System.Linq;

namespace GhepSo
{
    class Program
    {
        static int GhepSo(char x, int num)
        {
            return num * 10 + int.Parse(x.ToString());
        }
        static void Main(string[] args)
        {
            int num = 0, sum = 0;
            string str = "a12sdfg3okj345x";
            List<char> lstCh = str.ToCharArray().ToList();
            lstCh.ForEach(x =>
            {
                if (Char.IsDigit(x))
                {
                    num = GhepSo(x, num);
                }
                else
                {
                    sum += num;
                    num = 0;
                }
            });

            Console.WriteLine(sum);
        }
    }
}
