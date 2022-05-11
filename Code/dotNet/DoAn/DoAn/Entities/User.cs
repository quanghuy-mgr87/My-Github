using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public DateTime? ngaySinh { get; set; }
        public string soDienThoai { get; set; }
        public int? roleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
