﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNguyenLieu.Entities
{
    class LoaiNguyenLieu
    {
        public int Id { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public virtual IEnumerable<NguyenLieu> NguyenLieus { get; set; }
    }
}
