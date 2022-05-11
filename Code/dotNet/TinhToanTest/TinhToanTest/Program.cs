using System;
using System.Collections.Generic;

namespace TinhToanTest
{
    class Program
    {
        public static List<int> LaySo(List<string> lstStr)
        {
            List<int> lstInt = new List<int>();
            foreach (var val in lstStr)
            {
                if(!string.IsNullOrEmpty(val))
                {
                    lstInt.Add(int.Parse(val));
                }
            }
            return lstInt;
        }
        public static List<string> GhepSo(char[] arr)
        {
            List<string> lstString = new List<string>();
            string temp = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (char.IsDigit(arr[i]) && i == arr.Length - 1)
                {
                    temp += arr[i].ToString();
                    lstString.Add(temp);
                }
                else if (char.IsDigit(arr[i]))
                {
                    temp += arr[i].ToString();
                }
                else
                {
                    lstString.Add(temp);
                    temp = "";
                    continue;
                }
            }
            return lstString;
        }

        static void Main(string[] args)
        {
            char[] arr = { 'a', '1', '2', 'b', 'c', '1', '3', '4', 'd', '1' };
        }
    }
}
