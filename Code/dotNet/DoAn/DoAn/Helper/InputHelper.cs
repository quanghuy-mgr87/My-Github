using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Helper
{
    class InputHelper
    {
        public static string InputName(string str)
        {
            string name = "";
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            List<string> lstStr = str.ToLower().Split(' ').ToList();
            lstStr.ForEach(x => name += x.First().ToString().ToUpper() + x.Substring(1).ToString() + " ");
            return name;
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public static bool ValidateEmail(string email)
        {
            try
            {
                new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
