using DoAn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.IServices
{
    interface IPhongBanServices
    {
        public List<PhongBan> GetPhongBanList(string keyword = "");
        public PhongBan GetPhongBanById(int phongBanId);
        public bool ThemPhongBan(PhongBan phongBan);
        public bool XoaPhongBan(int phongBanId);
        public bool SuaPhongBan(PhongBan phongBan);
    }
}
