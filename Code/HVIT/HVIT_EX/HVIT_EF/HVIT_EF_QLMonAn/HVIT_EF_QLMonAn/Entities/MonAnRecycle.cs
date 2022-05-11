using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLMonAn.Entities
{
    class MonAnRecycle
    {
        public int Id { get; set; }
        public int? LoaiMonAnId { get; set; }
        public string TenMon { get; set; }
        public double? GiaBan { get; set; }
        public string GioiThieu { get; set; }
        public string CachLam { get; set; }
    }
}
