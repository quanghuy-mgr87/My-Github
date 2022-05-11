using HVIT_EF_QLNguyenLieu.Entities;
using HVIT_EF_QLNguyenLieu.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNguyenLieu.IServices
{
    interface INguyenLieuService
    {
        public IEnumerable<NguyenLieu> HienThiDanhSachNguyenLieu(string keyword = null);
        public errType ThemNguyenLieu(NguyenLieu nguyenLieu);
    }
}
