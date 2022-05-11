using System;
using System.Collections.Generic;

#nullable disable

namespace DemoApiDBFirst.Model
{
    public partial class Lop
    {
        public Lop()
        {
            HocSinhs = new HashSet<HocSinh>();
        }

        public int LopId { get; set; }
        public string TenLop { get; set; }
        public int? SiSo { get; set; }

        public virtual ICollection<HocSinh> HocSinhs { get; set; }
    }
}
