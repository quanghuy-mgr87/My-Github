using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNgayHoc.Entities
{
    class NgayHoc
    {
        public int Id { get; set; }
        public int? khoaHocId { get; set; }
        public string noiDung { get; set; }
        public string ghiChu { get; set; }
        public virtual KhoaHoc KhoaHoc { get; set; }
        public NgayHoc() { }
    }
}
