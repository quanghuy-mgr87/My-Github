using HVIT_MVCTest.Helper;
using HVIT_MVCTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_MVCTest.Controller
{
    class PhanCongController
    {
        public static errType ThemNhanVienVaoDuAn(PhanCong phanCong)
        {
            using (var db = new BusinessContext())
            {
                PhanCong phanCong1 = db.phanCongs.SingleOrDefault(x => x.PhancongId == phanCong.PhancongId);
                NhanVien nhanVien = db.nhanViens.SingleOrDefault(x => x.NhanvienId == phanCong.NhanvienId);
                DuAn duAn = db.duAns.SingleOrDefault(x => x.DuanId == phanCong.DuanId);
                if (nhanVien == null)
                {
                    return errType.KhongTonTaiNhanVien;
                }
                if (duAn == null)
                {
                    return errType.KhongTonTaiDuAn;
                }
                if (phanCong1 != null)
                {
                    return errType.DaTonTai;
                }
                else
                {
                    phanCong.PhancongId = 0;
                    db.phanCongs.Add(phanCong);
                    db.SaveChanges();
                    return errType.ThanhCong;
                }
            }
        }
    }
}
