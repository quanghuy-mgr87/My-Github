using HVITQuanLyHS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVITQuanLyHS.Services
{
    class LopService : ILopService
    {
        private QLHSDbContext qLHSDbContext { get; }
        public LopService()
        {
            qLHSDbContext = new QLHSDbContext();
        }
        public IEnumerable<Lop> LayDanhSachLop(string keyword = null)
        {
            var query = qLHSDbContext.Lop.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(lop => lop.TenLop.ToLower().Contains(keyword));
            }
            return query;
        }

        public Lop LayLopTheoMa(int lopId)
        {
            var lop = qLHSDbContext.Lop.Find(lopId);
            return lop;
        }

        public Lop SuaThongTinLop(int lopId, Lop lop)
        {
            if (qLHSDbContext.Lop.Any(lop => lop.Id == lopId))
            {
                var updateLop = LayLopTheoMa(lopId);
                updateLop.TenLop = lop.TenLop;
                updateLop.SiSo = lop.SiSo;
                qLHSDbContext.Lop.Update(updateLop);
                qLHSDbContext.SaveChanges();
                return updateLop;
            }
            else
            {
                throw new Exception($"Lop {lopId} khong ton tai.");
            }
        }
    }
}
