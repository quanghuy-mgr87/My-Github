using System;
using System.Collections.Generic;

namespace Caesar
{
    class Program
    {
        static List<char> TaoListKiTuThuong()
        {
            List<char> lstCh = new List<char>();
            char beginCh = 'a', endCh = 'z';
            while (beginCh != endCh)
            {
                lstCh.Add(beginCh);
                beginCh++;
            }
            lstCh.Add(endCh);
            return lstCh;
        }

        static char TimKiTu(char x, List<char> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i] == x)
                {
                    if (lst[i] == 'a')
                        return lst[lst.Count - i - 3];
                    else if (lst[i] == 'b')
                        return lst[lst.Count - i - 1];
                    else if (lst[i] == 'c')
                        return lst[lst.Count - i + 1];
                    else
                        return lst[i - 3];
                }
            }
            return '\0';
        }
        static string GiaiMa(string str, List<char> lst)
        {
            string result = "";
            str = str.ToLower();
            for (int i = 0; i < str.Length; i++)
            {
                result += TimKiTu(Char.Parse(str[i].ToString()), lst);
            }
            return result;
        }
        static void Main(string[] args)
        {
            List<char> lst = TaoListKiTuThuong();
            string code = "Eloo lv zdwfklqj";
            string result = GiaiMa(code, lst);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
