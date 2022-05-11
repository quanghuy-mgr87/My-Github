using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;

namespace DoAn.Entities
{
    class AppDbContext : DbContext
    {
        public AppDbContext() : base("name = DbContext")
        {
            
        }
        public DbSet<BangLuong> bangLuongs { get; set; }
        public DbSet<ChiTietBangLuong> chiTietBangLuongs { get; set; }
        public DbSet<ChiTietHoaDonBan> chiTietHoaDonBans { get; set; }
        public DbSet<ChiTietHoaDonMua> chiTietHoaDonMuas { get; set; }
        public DbSet<ChiTietKho> chiTietKhos { get; set; }
        public DbSet<ChucVu> chucVus { get; set; }
        public DbSet<DonViTinh> donViTinhs { get; set; }
        public DbSet<HangHoa> hangHoas { get; set; }
        public DbSet<HoaDonBan> hoaDonBans { get; set; }
        public DbSet<HoaDonMua> hoaDonMuas { get; set; }
        public DbSet<KhachHang> khachHangs { get; set; }
        public DbSet<Kho> khos { get; set; }
        public DbSet<LoaiHang> loaiHangs { get; set; }
        public DbSet<NhaCungCap> nhaCungCaps { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }
        public DbSet<PhongBan> phongBans { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<ThongTinDiemDanh> thongTinDiemDanhs { get; set; }
        public DbSet<TinhTrangHang> tinhTrangHangs { get; set; }
        public DbSet<User> users { get; set; }
    }
}
