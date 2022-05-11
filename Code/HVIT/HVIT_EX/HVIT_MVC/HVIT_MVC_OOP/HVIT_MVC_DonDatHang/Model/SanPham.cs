using HVIT_MVC_DonDatHang.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_DonDatHang.Model
{
    class SanPham
    {
        public int maSP { get; set; }
        public string tenSP { get; set; }
        public float giaBan { get; set; }
        public string ghiChu { get; set; }
        public SanPham()
        {
            maSP = inputHelper.InputInt(res.inputMaSP, res.errorMaSP);
            tenSP = inputHelper.InputString(res.inputTenSP, res.errorTenSP);
            giaBan = inputHelper.InputFloat(res.inputGiaBan, res.errorGiaBan);
            Console.Write("Ghi chu: ");
            ghiChu = Console.ReadLine();
        }
        public void InThongTin()
        {
            Console.WriteLine($"Ma san pham: {maSP}, ten san pham: {tenSP}, gia ban: {giaBan}, ghi chu: {ghiChu}");
        }
    }
}
