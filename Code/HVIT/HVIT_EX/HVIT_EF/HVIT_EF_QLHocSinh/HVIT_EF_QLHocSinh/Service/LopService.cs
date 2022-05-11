using HVIT_EF_QLHocSinh.Entities;
using HVIT_EF_QLHocSinh.Helper;
using HVIT_EF_QLHocSinh.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_EF_QLHocSinh.Service
{
    class LopService : ILopService
    {
        private QLHocSinhDbContext dbContext { get; }
        public LopService()
        {
            dbContext = new QLHocSinhDbContext();
        }
        public IEnumerable<Lop> HienThiDSLop(string keyword = null)
        {
            var query = dbContext.lops.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.TenLop.Contains(keyword));
            }
            return query;
        }
    }
}
