using System;
using System.Collections.Generic;
using System.Linq;

namespace testString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "nguyen ba quang Huy";
            string name = "";
            string[] arrStr = str.Split(" ");
            List<string> lstStr = str.ToLower().Split(" ").ToList();
            lstStr.ForEach(x => name += x.First().ToString().ToUpper() + x.Substring(1).ToString() + " ");
            Console.WriteLine(name);
        }
    }
}
