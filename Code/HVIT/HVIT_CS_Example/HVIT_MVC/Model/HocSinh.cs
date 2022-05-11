using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HVIT_MVC.Helper;

namespace HVIT_MVC.Model
{
    class HocSinh
    {
        public int HocSinhID { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public HocSinh()
        {
            HocSinhID = InputHelper.InputINT(res.InputMaHS, res.ErrMaHS);
            Ten = InputHelper.InputSTR(res.InputTen, res.ErrTen, 6, 20);
            NgaySinh = InputHelper.InputDT(res.InputNgaySinh, res.ErrNgaySinh, new DateTime(2002, 1, 1), new DateTime(2013, 12, 31));

        }
        public void HienThi()
        {
            Console.WriteLine($"{HocSinhID} co ten la {Ten} sinh ngay {NgaySinh.ToShortDateString()}");
        }
    }
}
