using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace InToHopSo
{
    class Program
    {
        static void InList(List<int> lst)
        {
            lst.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            #region cach1
            //int n;
            //List<int> lstInt = new List<int>();
            //Console.WriteLine("Nhap n: ");
            //n = int.Parse(Console.ReadLine());
            //for (int i = 0; i < n; i++)
            //{
            //    lstInt.Add(0);
            //}
            //InList(lstInt);

            //for (int i = n - 1; i >= 0; i--)
            //{
            //    if (lstInt[i] == 0)
            //    {
            //        lstInt[i] = 1;
            //        for (int j = i + 1; j < n; j++)
            //        {
            //            lstInt[j] = 0;
            //        }
            //        i = n;
            //        InList(lstInt);

            //    }
            //}
            //Console.ReadKey();
            #endregion

            int[] arr = new int[5];
            double n = Math.Pow(2, arr.Length) - 1;
            for (int i = 0; i < n; i++)
            {
                int pos = arr.ToList().FindLastIndex(x => x == 0);
                arr[pos] = 1;
                int len = arr.Length - pos - 1;
                Array.Copy(Enumerable.Range(0, len).Select(x => 0).ToArray(), 0, arr, pos + 1, len);
                arr.ToList().ForEach(x => Write(x + " "));
                WriteLine();
            }
            ReadKey();
        }
    }
}
