using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Model
{
    public class NguoiMuaHang
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string TenDonVi { get; set; }
        public string DiaChi { get; set; }
        public string SoTaiKhoan { get; set; }
        public string HinhThucThanhToan { get; set; }
        public string MaSoThue { get; set; }

        public NguoiMuaHang()
        {
        }

        public NguoiMuaHang(int id, string hoTen, string tenDonVi, string diaChi, string soTaiKhoan, string hinhThucThanhToan, string maSoThue)
        {
            Id = id;
            HoTen = hoTen;
            TenDonVi = tenDonVi;
            DiaChi = diaChi;
            SoTaiKhoan = soTaiKhoan;
            HinhThucThanhToan = hinhThucThanhToan;
            MaSoThue = maSoThue;
        }
    }
}
