using HVIT_MVC_HocSinh.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_HocSinh.Model
{
    class HocSinh
    {
        public int maHocSinh { get; set; }
        public string tenHocSinh { get; set; }
        public DateTime ngaySinh { get; set; }
        public HocSinh()
        {
            maHocSinh = inputHelper.InputInt(res.inputMaHS, res.errorMaHS);
            tenHocSinh = inputHelper.NhapTen(res.inputTenHS, res.errorTenHS);
            ngaySinh = inputHelper.InputDateTime(res.inputNgaySinh, res.errorNgaySinh);
        }
        public void InThongTin()
        {
            Console.WriteLine($"Hoc sinh ID: {maHocSinh}, ho ten: {tenHocSinh}, ngay sinh: {ngaySinh.ToShortDateString()}");
        }
    }
}
