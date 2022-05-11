using DoAn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.IServices
{
    interface IChucVuServices
    {
        public List<ChucVu> GetChucVuList(string keyword = "");
        public ChucVu GetChucVuById(int chucVuId);
        public bool ThemChucVu(ChucVu chucVu);
        public bool XoaChucVu(int chucVuId);
        public bool SuaChucVu(ChucVu chucVu);
    }
}
