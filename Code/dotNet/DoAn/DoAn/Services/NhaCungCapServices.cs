using DoAn.Entities;
using DoAn.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Services
{
    class NhaCungCapServices : INhaCungCapServices
    {
        private AppDbContext dbContext { get; }
        public NhaCungCapServices()
        {
            dbContext = new AppDbContext();
        }
        public NhaCungCap GetNhaCungCapById(int nccId)
        {
            return dbContext.nhaCungCaps.Find(nccId);
        }

        public List<NhaCungCap> GetNhaCungCapList(string keyword = "")
        {
            List<NhaCungCap> lstNCC = dbContext.nhaCungCaps.AsQueryable().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                lstNCC = lstNCC.Where(x => x.tenNhaCungCap == keyword).ToList();
            }
            lstNCC = lstNCC.Select(x => new NhaCungCap()
            {
                id = x.id,
                tenNhaCungCap = x.tenNhaCungCap,
                soDienThoai = x.soDienThoai,
                diaChi = x.diaChi
            }).ToList();
            return lstNCC;
        }

        public bool SuaNhaCungCap(NhaCungCap nhaCungCap)
        {
            var currentNCC = dbContext.nhaCungCaps.SingleOrDefault(x => x.id == nhaCungCap.id);
            if (currentNCC != null)
            {
                currentNCC.tenNhaCungCap = nhaCungCap.tenNhaCungCap;
                currentNCC.diaChi = nhaCungCap.diaChi;
                currentNCC.soDienThoai = nhaCungCap.soDienThoai;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ThemNhaCungCap(NhaCungCap nhaCungCap)
        {
            if (!dbContext.nhaCungCaps.Any(x => x.tenNhaCungCap == nhaCungCap.tenNhaCungCap))
            {
                nhaCungCap.id = 0;
                dbContext.nhaCungCaps.Add(nhaCungCap);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool XoaNhaCungCap(int nccId)
        {
            var currentNCC = dbContext.nhaCungCaps.SingleOrDefault(x => x.id == nccId);
            if (currentNCC != null)
            {
                dbContext.nhaCungCaps.Remove(currentNCC);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
