using HVIT_MVCTest.Helper;
using HVIT_MVCTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_MVCTest.Controller
{
    class NhanVienController
    {
        public static errType ThemMoiNhanVien(NhanVien nhanVien)
        {
            using (var db = new BusinessContext())
            {
                NhanVien nhanVien1 = db.nhanViens.SingleOrDefault(x => x.NhanvienId == nhanVien.NhanvienId);
                if (nhanVien1 == null)
                {
                    nhanVien.NhanvienId = 0;
                    db.nhanViens.Add(nhanVien);
                    db.SaveChanges();
                    return errType.ThanhCong;
                }
                else
                {
                    return errType.DaTonTai;
                }
            }
        }
        public static errType XoaNhanVien(NhanVien nhanVien)
        {
            using (var db = new BusinessContext())
            {
                NhanVien nhanVien1 = db.nhanViens.SingleOrDefault(x => x.NhanvienId == nhanVien.NhanvienId);
                if (nhanVien1 == null)
                {
                    return errType.KhongTonTaiNhanVien;
                }
                else
                {
                    List<PhanCong> lstPhanCong = db.phanCongs.Where(x => x.NhanvienId == nhanVien.NhanvienId).ToList();
                    lstPhanCong.ForEach(x => db.phanCongs.Remove(x));
                    db.SaveChanges();   //xoá xong trong bảng phân công xong phải update thì mới xoá đc ở bảng nhân viên

                    db.nhanViens.Remove(nhanVien1);
                    db.SaveChanges();
                    return errType.ThanhCong;
                }
            }
        }
        public static void TinhLuong(NhanVien nhanVien)
        {
            using (var db = new BusinessContext())
            {
                NhanVien nhanVien1 = db.nhanViens.SingleOrDefault(x => x.NhanvienId == nhanVien.NhanvienId);
                if (nhanVien1 == null)
                {
                    errHelper.log(errType.KhongTonTaiNhanVien);
                }
                else
                {
                    double luong = nhanVien1.Hesoluong * 15 * db.phanCongs.Where(x => x.NhanvienId == nhanVien.NhanvienId).Sum(x => x.Sogiolam);
                    Console.WriteLine($"Luong cua nhan vien {nhanVien1.Hoten} la: {luong}");
                }
            }
        }
    }
}
