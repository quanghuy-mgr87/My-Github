using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Model
{
    public class DonViBanHang
    {
        public int Id { get; set; }
        public string MaSoThue { get; set; }
        public string TenDonVi { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string SoTaiKhoan { get; set; }

        public DonViBanHang()
        {
        }

        public DonViBanHang(int id, string maSoThue, string tenDonVi, string diaChi, string soDienThoai, string soTaiKhoan)
        {
            Id = id;
            MaSoThue = maSoThue;
            TenDonVi = tenDonVi;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            SoTaiKhoan = soTaiKhoan;
        }
    }
}
