using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class ChiTietKho
    {
        public int id { get; set; }
        public int? hangHoaId { get; set; }
        public int? khoId { get; set; }
        public int? soLuong { get; set; }
        public int? tinhTrangHangId { get; set; }
        public virtual Kho Kho { get; set; }
        public virtual HangHoa HangHoa { get; set; }
        public virtual TinhTrangHang TinhTrangHang { get; set; }
    }
}
