using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyPhongBan.Entities
{
    public class QuanLyDuAn
    {
        public int Id { get; set; }
        public int NhanVienId { get; set; }
        public int DuAnId { get; set; }
        public int SoGioLamViec { get; set; }
        public virtual IEnumerable<NhanVien> NhanViens { get; set; }
        public virtual IEnumerable<DuAn> DuAns { get; set; }
    }
}
