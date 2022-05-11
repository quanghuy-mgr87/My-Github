using HVIT_EF_QLNguyenLieu.Entities;
using HVIT_EF_QLNguyenLieu.Helper;
using HVIT_EF_QLNguyenLieu.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_EF_QLNguyenLieu.Services
{
    class NguyenLieuService : INguyenLieuService
    {
        private QLNguyenLieuDbContext dbContext { get; }
        public NguyenLieuService()
        {
            dbContext = new QLNguyenLieuDbContext();
        }
        public IEnumerable<NguyenLieu> HienThiDanhSachNguyenLieu(string keyword = null)
        {
            var query = dbContext.NguyenLieus.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.TenNguyenLieu.Contains(keyword));
            }
            return query;
        }

        public errType ThemNguyenLieu(NguyenLieu nguyenLieu)
        {
            if (dbContext.LoaiNguyenLieus.Any(x => x.Id == nguyenLieu.LoaiNguyenLieuId))
            {
                dbContext.NguyenLieus.Add(nguyenLieu);
                dbContext.SaveChanges();
                return errType.ThanhCong;
            }
            else
            {
                return errType.LoaiNguyenLieuKhongTonTai;
            }
        }
    }
}
