using HVIT_EF_QLNgayHoc.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNgayHoc.Entities
{
    class HocVien
    {
        public int Id { get; set; }
        public int? khoaHocId { get; set; }
        public string hoTen { get; set; }
        public DateTime ngaySinh { get; set; }
        public string queQuan { get; set; }
        public string diaChi { get; set; }
        public string soDienThoai { get; set; }
        public virtual KhoaHoc KhoaHoc { get; set; }
        public HocVien() { }
        public HocVien(inputType inputType)
        {
            switch (inputType)
            {
                case inputType.SuaThongTinHocVien:
                    {
                        Id = inputHelper.InputInt(res.inputMaHocVien, res.errorMaHocVien);
                        khoaHocId = inputHelper.InputInt(res.inputMaKhoaHoc, res.errorMaKhoaHoc);
                        hoTen = inputHelper.NhapTen(res.inputHoTen, res.errorHoTen);
                        ngaySinh = inputHelper.NhapNgay(res.inputNgaySinh, res.errorNgaySinh);
                        Console.Write("Que quan: ");
                        queQuan = Console.ReadLine();
                        Console.Write("Dia chi: ");
                        diaChi = Console.ReadLine();
                        soDienThoai = inputHelper.NhapSoDT(res.inputSDT, res.errorSDT);
                    }
                    break;
                case inputType.TimHocVienTheoHoTenVaKhoaHoc:
                    {
                        hoTen = inputHelper.NhapTen(res.inputHoTen, res.errorHoTen);
                        khoaHocId = inputHelper.InputInt(res.inputMaKhoaHoc, res.errorMaKhoaHoc);
                    }
                    break;
                case inputType.ThemHocVien:
                    {
                        khoaHocId = inputHelper.InputInt(res.inputMaKhoaHoc, res.errorMaKhoaHoc);
                        hoTen = inputHelper.NhapTen(res.inputHoTen, res.errorHoTen);
                        ngaySinh = inputHelper.NhapNgay(res.inputNgaySinh, res.errorNgaySinh);
                        Console.Write("Que quan: ");
                        queQuan = Console.ReadLine();
                        Console.Write("Dia chi: ");
                        diaChi = Console.ReadLine();
                        soDienThoai = inputHelper.NhapSoDT(res.inputSDT, res.errorSDT);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
