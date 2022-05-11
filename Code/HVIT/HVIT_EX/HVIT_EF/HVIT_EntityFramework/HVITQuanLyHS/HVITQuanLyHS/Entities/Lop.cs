using System;
using System.Collections.Generic;
using System.Text;

namespace HVITQuanLyHS.Entities
{
    public class Lop
    {
        public int Id { get; set; }
        public string TenLop { get; set; }
        public int? SiSo { get; set; }
        public virtual IEnumerable<HocSinh> hocSinhs { get; set; }
    }
}
