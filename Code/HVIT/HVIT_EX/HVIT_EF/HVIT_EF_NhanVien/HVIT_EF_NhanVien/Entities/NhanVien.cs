using HVIT_EF_NhanVien.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_NhanVien.Entities
{
    class NhanVien
    {
        public int Id { get; set; }
        public string hoTen { get; set; }
        public string soDienThoai { get; set; }
        public string diaChi { get; set; }
        public string email { get; set; }
        public double? heSoLuong { get; set; }
        public virtual IEnumerable<PhanCong> phanCongs { get; set; }
        public NhanVien() { }
        public NhanVien(inputType inputType)
        {
            switch (inputType)
            {
                case inputType.ThemNhanVien:
                    {
                        hoTen = inputHelper.NhapTen(res.inputHoTen, res.errorHoTen);
                        soDienThoai = inputHelper.NhapSoDT(res.inputSDT, res.errorSDT, 0, 10);
                        diaChi = inputHelper.InputString(res.inputDiaChi, res.errorDiaChi, 0);
                        email = inputHelper.NhapEmail(res.inputEmail, res.errorEmail);
                        heSoLuong = inputHelper.InputDouble(res.inputHeSoLuong, res.errorHeSoLuong);
                    }
                    break;
                case inputType.XoaNhanVien:
                    {
                        Id = inputHelper.InputInt(res.inputNhanVienId, res.errorNhanVienId);
                    }
                    break;
                case inputType.TinhLuong:
                    {
                        Id = inputHelper.InputInt(res.inputNhanVienId, res.errorNhanVienId);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
