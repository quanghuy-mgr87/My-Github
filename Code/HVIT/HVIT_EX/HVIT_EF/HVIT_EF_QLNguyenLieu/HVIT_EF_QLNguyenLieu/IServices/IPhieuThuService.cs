using HVIT_EF_QLNguyenLieu.Entities;
using HVIT_EF_QLNguyenLieu.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNguyenLieu.IServices
{
    interface IPhieuThuService
    {
        public IEnumerable<PhieuThu> HienThiDSPhieuThu(string keyword = null);
        public errType ThemPhieuThu(PhieuThu phieuThu);
        public errType XoaPhieuThu(PhieuThu phieuThu);
        public errType LayRaThongTinPhieuTheoThoiGian(PhieuThu phieuThu);
    }
}
