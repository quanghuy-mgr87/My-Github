using System;
using System.Collections.Generic;

#nullable disable

namespace DemoApiDBFirst.Model
{
    public partial class HocSinh
    {
        public int HocSinhId { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public int? LopId { get; set; }

        public virtual Lop Lop { get; set; }
    }
}
