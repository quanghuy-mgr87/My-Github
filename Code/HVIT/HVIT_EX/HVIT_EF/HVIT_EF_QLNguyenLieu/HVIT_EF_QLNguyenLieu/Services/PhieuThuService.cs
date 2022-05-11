using HVIT_EF_QLNguyenLieu.Entities;
using HVIT_EF_QLNguyenLieu.Helper;
using HVIT_EF_QLNguyenLieu.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_EF_QLNguyenLieu.Services
{
    class PhieuThuService : IPhieuThuService
    {
        private QLNguyenLieuDbContext dbContext { get; }
        public PhieuThuService()
        {
            dbContext = new QLNguyenLieuDbContext();
        }
        public IEnumerable<PhieuThu> HienThiDSPhieuThu(string keyword = null)
        {
            var query = dbContext.PhieuThus.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.NhanVienLap.Contains(keyword));
            }
            return query;
        }

        public void HienThiDSSanPham(PhieuThu phieuThu)
        {
            List<ChiTietPhieuThu> lstSP = dbContext.ChiTietPhieuThus.Where(x => x.PhieuThuId == phieuThu.Id).ToList();
            foreach (var val in lstSP)
            {
                var nguyenLieu = dbContext.NguyenLieus.Find(val.NguyenLieuId);
                var loaiNguyenLieu = dbContext.LoaiNguyenLieus.Find(nguyenLieu.LoaiNguyenLieuId);
                Console.WriteLine($"Ma nguyen lieu: {nguyenLieu.TenNguyenLieu}\n" +
                    $"Loai: {loaiNguyenLieu.TenLoai}\n" +
                    $"Gia ban: {nguyenLieu.GiaBan}\n" +
                    $"Don vi tinh: {nguyenLieu.DonViTinh}\n" +
                    $"So luong kho: {nguyenLieu.SoLuongKho}\n" +
                    $"So luong ban: {val.SoLuongBan}\n");
            }
        }

        public errType LayRaThongTinPhieuTheoThoiGian(PhieuThu phieuThu)
        {
            if (dbContext.PhieuThus.Any(x => x.NgayLap == phieuThu.NgayLap))
            {
                List<PhieuThu> lstPhieuThu = dbContext.PhieuThus.Where(x => x.NgayLap == phieuThu.NgayLap).ToList();
                foreach (var val in lstPhieuThu)
                {
                    Console.WriteLine($"Phieu thu ID: {val.Id}, ngay lap: {val.NgayLap}, nhan vien lap: {val.NhanVienLap}, ghi chu: {val.GhiChu}, thanh tien: {val.ThanhTien}");
                    Console.WriteLine("---------------------------------------------------");
                    HienThiDSSanPham(val);
                    Console.WriteLine("---------------------------------------------------");
                }
                return errType.ThanhCong;
            }
            else
            {
                return errType.PhieuThuKhongTonTai;
            }
        }

        public errType ThemPhieuThu(PhieuThu phieuThu)
        {
            dbContext.PhieuThus.Add(phieuThu);
            dbContext.SaveChanges();
            ChiTietPhieuThuService chiTietPhieuThuService = new ChiTietPhieuThuService();
            ChiTietPhieuThu chiTietPhieuThu = new ChiTietPhieuThu();
            chiTietPhieuThu.PhieuThuId = phieuThu.Id;
            return chiTietPhieuThuService.ThemDSChiTietPhieu(chiTietPhieuThu);
        }

        public errType XoaPhieuThu(PhieuThu phieuThu)
        {
            if (dbContext.PhieuThus.Any(x => x.Id == phieuThu.Id))
            {
                List<ChiTietPhieuThu> lstChiTiet = dbContext.ChiTietPhieuThus.Where(x => x.PhieuThuId == phieuThu.Id).ToList();
                foreach (var val in lstChiTiet)
                {
                    var temp = new RecycleBin();
                    temp.Id = 0;
                    temp.NguyenLieuId = val.NguyenLieuId;
                    temp.PhieuThuId = val.PhieuThuId;
                    temp.SoLuongBan = val.SoLuongBan;
                    dbContext.RecycleBins.Add(temp);
                    dbContext.SaveChanges();
                    //update so luong kho
                    var nguyenLieu = dbContext.NguyenLieus.Find(val.NguyenLieuId);
                    nguyenLieu.SoLuongKho += val.SoLuongBan;
                    dbContext.NguyenLieus.Update(nguyenLieu);
                    dbContext.SaveChanges();

                    dbContext.ChiTietPhieuThus.Remove(val);
                    dbContext.SaveChanges();
                }
                dbContext.PhieuThus.Remove(phieuThu);
                dbContext.SaveChanges();
                return errType.ThanhCong;
            }
            else
            {
                return errType.PhieuThuKhongTonTai;
            }
        }
    }
}
