using HVIT_EF_QLNguyenLieu.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNguyenLieu.Entities
{
    class PhieuThu
    {
        public int Id { get; set; }
        public DateTime NgayLap { get; set; }
        public string NhanVienLap { get; set; }
        public string GhiChu { get; set; }
        public double? ThanhTien { get; set; }
        public virtual IEnumerable<ChiTietPhieuThu> ChiTietPhieuThus { get; set; }
        public PhieuThu() { }
        public PhieuThu(inputType inputType)
        {
            switch (inputType)
            {
                case inputType.ThemPhieuThu:
                    {
                        NgayLap = inputHelper.NhapNgay(res.inputNgayLap, res.errorNgayLap);
                        NhanVienLap = inputHelper.NhapTen(res.inputTen, res.errorTen);
                        Console.Write(res.inputGhiChu);
                        GhiChu = Console.ReadLine();
                    }
                    break;
                case inputType.XoaPhieuThu:
                    {
                        Id = inputHelper.InputInt(res.inputMaPhieuThu, res.errorMaPhieuThu);
                    }
                    break;
                case inputType.LayThongTinPhieuThuTheoThoiGian:
                    {
                        NgayLap = inputHelper.NhapNgay(res.inputNgayLap, res.errorNgayLap);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
