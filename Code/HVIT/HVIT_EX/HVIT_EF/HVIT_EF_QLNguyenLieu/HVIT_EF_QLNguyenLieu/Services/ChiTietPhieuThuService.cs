using HVIT_EF_QLNguyenLieu.Entities;
using HVIT_EF_QLNguyenLieu.Helper;
using HVIT_EF_QLNguyenLieu.IServices;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_EF_QLNguyenLieu.Services
{
    class ChiTietPhieuThuService : IChiTietPhieuService
    {
        private QLNguyenLieuDbContext dbContext { get; }
        public ChiTietPhieuThuService()
        {
            dbContext = new QLNguyenLieuDbContext();
        }
        public IEnumerable<ChiTietPhieuThu> HienThiDSChiTietPhieu()
        {
            var query = dbContext.ChiTietPhieuThus.AsQueryable();
            return query;
        }
        public bool CapNhatSoLuongKho(int nguyenLieuId, int soLuongBan)
        {
            bool ok;
            NguyenLieu nguyenLieu = dbContext.NguyenLieus.Find(nguyenLieuId);
            int temp = (int)nguyenLieu.SoLuongKho - soLuongBan;
            ok = temp >= 0;
            if (ok)
            {
                nguyenLieu.SoLuongKho = temp;
                dbContext.NguyenLieus.Update(nguyenLieu);
                dbContext.SaveChanges();
            }
            return ok;
        }
        public ChiTietPhieuThu NhapChiTietPhieu(int phieuThuId)
        {
            // Kiem tra nguyen lieu co ton tai hay ko
            bool ok;
            ChiTietPhieuThu chiTietPhieuThu = new ChiTietPhieuThu();
            do
            {
                chiTietPhieuThu.NguyenLieuId = inputHelper.InputInt(res.inputMaNguyenLieu, res.errorMaNguyenLieu);
                ok = dbContext.NguyenLieus.Any(x => x.Id == chiTietPhieuThu.NguyenLieuId);
                if (!ok)
                {
                    Console.WriteLine("Nguyen lieu khong ton tai!");
                }
            } while (!ok);
            chiTietPhieuThu.PhieuThuId = phieuThuId;

            // Kiem tra so luong trong kho, neu con du moi dc add, con khong thi bo qua
            bool check;
            do
            {
                chiTietPhieuThu.SoLuongBan = inputHelper.InputInt(res.inputSoLuongBan, res.errorSoLuongBan);
                check = CapNhatSoLuongKho((int)chiTietPhieuThu.NguyenLieuId, (int)chiTietPhieuThu.SoLuongBan);
                if (!check)
                {
                    Console.WriteLine("So luong hang trong kho khong du, nhap 0 de bo qua!");
                }
            } while (!check);
            return chiTietPhieuThu;
        }

        public List<ChiTietPhieuThu> NhapDSChiTietPhieu(int phieuThuId, int soLuong)
        {
            List<ChiTietPhieuThu> lstChiTiet = new List<ChiTietPhieuThu>();
            int i = 0;
            while (i < soLuong)
            {
                Console.WriteLine($"Nhap chi tiet phieu thu {i}:");
                ChiTietPhieuThu chiTietPhieu = NhapChiTietPhieu(phieuThuId);
                lstChiTiet.Add(chiTietPhieu);
                i++;
            }
            return lstChiTiet;
        }

        public void CapNhatThanhTien(int phieuThuId, List<ChiTietPhieuThu> lstChiTiet)
        {
            var phieuThu = dbContext.PhieuThus.Find(phieuThuId);
            //var lstChiTiet = dbContext.ChiTietPhieuThus.Where(x => x.PhieuThuId == phieuThuId);
            ////?
            double thanhTien = 0;
            foreach (var val in lstChiTiet)
            {
                var nguyenLieu = dbContext.NguyenLieus.Find(val.NguyenLieuId);
                double giaBan = (double)nguyenLieu.GiaBan;
                thanhTien += giaBan * (int)val.SoLuongBan;
            }
            if (phieuThu.ThanhTien == null)
            {
                phieuThu.ThanhTien = thanhTien;
            }
            else
            {
                phieuThu.ThanhTien += thanhTien;
            }
            dbContext.PhieuThus.Update(phieuThu);
            dbContext.SaveChanges();
        }

        public errType ThemDSChiTietPhieu(ChiTietPhieuThu chiTietPhieuThu)
        {
            if (dbContext.PhieuThus.Any(x => x.Id == chiTietPhieuThu.PhieuThuId))
            {
                int soLuong = inputHelper.InputInt("Nhap so luong chi tiet phieu: ", "So nhap vao phai la so nguyen!");
                var lstChiTiet = NhapDSChiTietPhieu((int)chiTietPhieuThu.PhieuThuId, soLuong);
                foreach (var val in lstChiTiet)
                {
                    dbContext.ChiTietPhieuThus.Add(val);
                    dbContext.SaveChanges();
                    if (val.SoLuongBan == 0)
                    {
                        dbContext.ChiTietPhieuThus.Remove(val);
                        dbContext.SaveChanges();
                    }
                }
                CapNhatThanhTien((int)chiTietPhieuThu.PhieuThuId, lstChiTiet);
                return errType.ThanhCong;
            }
            else
            {
                return errType.PhieuThuKhongTonTai;
            }
        }
    }
}
