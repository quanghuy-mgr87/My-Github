using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class BangLuong
    {
        public int id { get; set; }
        public int? thang { get; set; }
        public double? tongLuong { get; set; }
        public virtual IEnumerable<ChiTietBangLuong> ChiTietBangLuongs { get; set; }
    }
}
