using HVIT_MVC_SanPham.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_SanPham.Model
{
    class NhaCungCap
    {
        public int nhaCC { get; set; }
        public string tenNCC { get; set; }
        public int soDT { get; set; }
        public NhaCungCap()
        {
            nhaCC = inputHelper.InputInt(res.inputNhaCC, res.errorNhaCC);
            tenNCC = inputHelper.InputString(res.inputTenNCC, res.errorTenNCC);
            soDT = inputHelper.InputInt(res.inputSoDT, res.errorSoDT);
        }
        public void InThongTin()
        {
            Console.WriteLine($"Ma nha cung cap: {nhaCC}, ten nha cung cap: {tenNCC}, so dien thoai: {soDT}");
        }
    }
}
