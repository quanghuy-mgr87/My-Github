using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNguyenLieu.Entities
{
    class RecycleBin
    {
        public int Id { get; set; }
        public int? NguyenLieuId { get; set; }
        public int? PhieuThuId { get; set; }
        public int? SoLuongBan { get; set; }
    }
}
