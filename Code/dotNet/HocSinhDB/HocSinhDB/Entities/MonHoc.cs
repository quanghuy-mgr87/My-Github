using System;
using System.Collections.Generic;
using System.Text;

namespace HocSinhDB.Entities
{
    public class MonHoc
    {
        public int Id { get; set; }
        public string TenMon { get; set; }
        public string GhiChu { get; set; }
        public virtual QuanLyHS QuanLyHS { get; set; }
    }
}
