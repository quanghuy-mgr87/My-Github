using HVIT_MVC_HocSinh.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_HocSinh.Model
{
    class MonHoc
    {
        public int maMH { get; set; }
        public string tenMH { get; set; }
        public int soTiet { get; set; }
        public MonHoc()
        {
            maMH = inputHelper.InputInt(res.inputMaMH, res.errorMaMH);
            tenMH = inputHelper.InputString(res.inputTenMH, res.errorTenMH);
            soTiet = inputHelper.InputInt(res.inputSoTiet, res.errorSoTiet);
        }
        public void InThongTin()
        {
            Console.WriteLine($"Ma mon hoc: {maMH}, ten mon: {tenMH}, so tiet: {soTiet}");
        }
    }
}
