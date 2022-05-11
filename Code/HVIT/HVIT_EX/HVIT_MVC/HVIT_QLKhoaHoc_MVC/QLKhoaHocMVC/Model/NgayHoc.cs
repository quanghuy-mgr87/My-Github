using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QLKhoaHocMVC.Model
{
    [Table("NgayHoc")]
    class NgayHoc
    {
        [Key]
        public int NgayhocID { get; set; }
        public int KhoahocID { get; set; }
        public string Noidung { get; set; }
        public string Ghichu { get; set; }
        [ForeignKey("KhoahocID")]
        KhoaHoc khoaHoc { get; set; }
        public NgayHoc()
        {

        }
    }
}
