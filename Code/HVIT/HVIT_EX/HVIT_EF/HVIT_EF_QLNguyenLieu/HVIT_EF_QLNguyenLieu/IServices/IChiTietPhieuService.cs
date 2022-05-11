using HVIT_EF_QLNguyenLieu.Entities;
using HVIT_EF_QLNguyenLieu.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNguyenLieu.IServices
{
    interface IChiTietPhieuService
    {
        public IEnumerable<ChiTietPhieuThu> HienThiDSChiTietPhieu();
        public errType ThemDSChiTietPhieu(ChiTietPhieuThu chiTietPhieuThu);
    }
}
