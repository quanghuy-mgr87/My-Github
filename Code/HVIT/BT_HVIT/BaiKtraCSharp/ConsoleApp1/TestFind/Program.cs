using System;
using System.Collections.Generic;
using System.Linq;

namespace TestFind
{
    class test
    {
        public int id { get; set; }
        public string name { get; set; }
        public test(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<test> lstTest = new List<test>();
            lstTest.Add(new test(1, "Hui"));
            lstTest.Add(new test(2, "Jayf"));
            lstTest.Add(new test(3, "Huy"));
            Console.WriteLine(lstTest.Sum(x => x.id));
        }
    }
}
