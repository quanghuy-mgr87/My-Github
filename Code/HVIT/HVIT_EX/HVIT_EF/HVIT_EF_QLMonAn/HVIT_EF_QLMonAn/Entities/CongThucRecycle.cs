using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLMonAn.Entities
{
    class CongThucRecycle
    {
        public int Id { get; set; }
        public int? NguyenLieuId { get; set; }
        public int? MonAnId { get; set; }
        public int? SoLuong { get; set; }
        public string DonViTinh { get; set; }
    }
}
