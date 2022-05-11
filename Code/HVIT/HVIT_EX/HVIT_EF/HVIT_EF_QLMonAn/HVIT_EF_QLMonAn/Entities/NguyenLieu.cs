using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLMonAn.Entities
{
    class NguyenLieu
    {
        public int Id { get; set; }
        public string TenNguyenLieu { get; set; }
        public string GhiChu { get; set; }
        public virtual IEnumerable<CongThuc> CongThucs { get; set; }
    }
}
