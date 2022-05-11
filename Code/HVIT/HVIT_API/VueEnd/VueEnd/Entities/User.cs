using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueEnd.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public int? QuyenAdmin { get; set; }
        public string SoDienThoai { get; set; }
    }
}
