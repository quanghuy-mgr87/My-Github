using System;
using System.Collections.Generic;
using System.Text;

namespace HVITQuanLyNhanVien.Entities
{
    public class PhanCong
    {
        public int Id { get; set; }
        public int? NhanVienId { get; set; }
        public int? DuAnId { get; set; }
        public int? SoGioLam { get; set; }
        public virtual IEnumerable<NhanVien> NhanViens { get; set; }
        public virtual IEnumerable<DuAn> DuAns { get; set; }
    }
}
