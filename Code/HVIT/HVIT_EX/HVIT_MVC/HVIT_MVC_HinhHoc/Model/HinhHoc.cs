using HVIT_MVC_HinhHoc.Controller;
using HVIT_MVC_HinhHoc.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_MVC_HinhHoc.Model
{
    class HinhHoc
    {
        public List<Diem> lstDiem { get; set; }
        public HinhHoc(List<Diem> lstDiem)
        {
            this.lstDiem = lstDiem;
        }
        public void InThongTin()
        {
            Console.WriteLine($"Hinh duoc tao thanh tu {lstDiem.Count()} diem.");
            int i = 1;
            foreach (var val in lstDiem)
            {
                Console.WriteLine($"Hinh {i}:");
                val.InThongTin();
                i++;
            }
            errorHelper.log(HinhHocController.KiemTraHinh(lstDiem));
        }
    }
}
