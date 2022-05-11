using DoAn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.IServices
{
    interface INhaCungCapServices
    {
        public List<NhaCungCap> GetNhaCungCapList(string keyword = "");
        public NhaCungCap GetNhaCungCapById(int nccId);
        public bool ThemNhaCungCap(NhaCungCap nhaCungCap);
        public bool XoaNhaCungCap(int nccId);
        public bool SuaNhaCungCap(NhaCungCap nhaCungCap);
    }
}
