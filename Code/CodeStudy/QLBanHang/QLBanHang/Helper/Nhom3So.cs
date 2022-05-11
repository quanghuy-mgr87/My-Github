using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Helper
{
    internal class Nhom3So
    {
        //Các Property ứng với các chữ số hàng đơn vị, hàng chục và hàng trăm
        public int hd { get; set; }
        public int hc { get; set; }
        public int ht { get; set; }

        //Phương thức khởi tạo: Nhập nhóm 3 chữ số, đưa từng chữ số trong nhóm
        //vào các thuộc tính
        public Nhom3So() { }

        public Nhom3So(int nhom)
        {
            this.hd = nhom % 10;
            this.hc = nhom / 10 % 10;
            this.ht = nhom / 100;
        }

        public Nhom3So(string stringNhom)
        {
            int nhom = int.Parse(stringNhom);
            this.hd = nhom % 10;
            this.hc = nhom / 10 % 10;
            this.ht = nhom / 100;
        }
    }
}
