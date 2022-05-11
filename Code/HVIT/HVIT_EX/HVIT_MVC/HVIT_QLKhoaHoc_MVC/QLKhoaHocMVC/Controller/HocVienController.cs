using QLKhoaHocMVC.Helper;
using QLKhoaHocMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKhoaHocMVC.Controller
{
    class HocVienController
    {
        public static errType ThemHocVien(HocVien hocVien)
        {
            using (var db = new BusinessContext())
            {
                HocVien hocVien1 = db.hocViens.SingleOrDefault(x => x.HocvienID == hocVien.HocvienID);
                if (hocVien1 == null)
                {
                    hocVien.HocvienID = 0;
                    db.hocViens.Add(hocVien);
                    db.SaveChanges();
                    return errType.ThanhCong;
                }
                else
                {
                    return errType.HocVienDaTonTai;
                }
            }
        }
        public static errType SuaThongTinHocVien(HocVien hocVien)
        {
            using (var db = new BusinessContext())
            {
                HocVien hocVien1 = db.hocViens.SingleOrDefault(x => x.HocvienID == hocVien.HocvienID);
                KhoaHoc khoaHoc = db.khoaHocs.SingleOrDefault(x => x.KhoahocID == hocVien.KhoahocID);
                if (khoaHoc == null)
                {
                    return errType.KhoaHocKhongTonTai;
                }
                if (hocVien1 == null)
                {
                    return errType.HocVienKhongTonTai;
                }
                else
                {
                    hocVien1.KhoahocID = hocVien.KhoahocID;
                    hocVien1.Hoten = hocVien.Hoten;
                    hocVien1.Ngaysinh = hocVien.Ngaysinh;
                    hocVien1.Quequan = hocVien.Quequan;
                    hocVien1.Diachi = hocVien.Diachi;
                    hocVien1.Sodienthoai = hocVien.Sodienthoai;
                    db.hocViens.Update(hocVien1);
                    db.SaveChanges();
                    return errType.ThanhCong;
                }
            }
        }
        public static errType TimHocVien(HocVien hocVien)
        {
            using (var db = new BusinessContext())
            {
                HocVien hocVien1 = db.hocViens.SingleOrDefault(x => x.Hoten.Contains(hocVien.Hoten) && x.KhoahocID == hocVien.KhoahocID);
                if (hocVien1 == null)
                {
                    return errType.HocVienKhongTonTai;
                }
                //KhoahocID ko thuoc ve thang hoc vien nen minh phai goi thong qua doi tuong truyen vao la hocVien
                Console.WriteLine($"Hoc vien can tim: Id: {hocVien1.HocvienID}, ho ten: {hocVien1.Hoten}, khoa hoc id: {hocVien.KhoahocID}");
                return errType.ThanhCong;

            }
        }
    }
}
