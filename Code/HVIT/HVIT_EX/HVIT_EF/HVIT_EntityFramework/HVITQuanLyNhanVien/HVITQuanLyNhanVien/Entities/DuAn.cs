using System;
using System.Collections.Generic;
using System.Text;

namespace HVITQuanLyNhanVien.Entities
{
    public class DuAn
    {
        public int Id { get; set; }
        public string TenDuAn { get; set; }
        public string MoTa { get; set; }
        public string GhiChu { get; set; }
        public int? PhanCongId { get; set; }
        public virtual PhanCong PhanCong { get; set; }
    }
}
