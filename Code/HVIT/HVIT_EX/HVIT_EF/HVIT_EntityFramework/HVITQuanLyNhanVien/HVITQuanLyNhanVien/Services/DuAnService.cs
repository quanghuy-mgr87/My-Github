using HVITQuanLyNhanVien.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVITQuanLyNhanVien.Services
{
    class DuAnService : IDuAnService
    {
        private QuanLyNhanVienDbContext qLNVDbContext { get; }
        public DuAnService()
        {
            qLNVDbContext = new QuanLyNhanVienDbContext();
        }
        public DuAn SuaDuAn(int duAnId, DuAn duAn)
        {
            if (qLNVDbContext.DuAn.Any(val => val.Id == duAnId))
            {
                var currentDuAn = TimDuAnTheoId(duAnId);
                currentDuAn.TenDuAn = duAn.TenDuAn;
                currentDuAn.MoTa = duAn.MoTa;
                currentDuAn.GhiChu = duAn.GhiChu;
                qLNVDbContext.SaveChanges();
                return currentDuAn;
            }
            else
            {
                throw new Exception($"Du an {duAnId} khong ton tai!");
            }
        }

        public DuAn TimDuAnTheoId(int duAnId)
        {
            var duAn = qLNVDbContext.DuAn.Find(duAnId);
            return duAn;
        }

        public IEnumerable<DuAn> HienThiDSDuAn(string keyword = null)
        {
            var query = qLNVDbContext.DuAn.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(duAn => duAn.TenDuAn.ToLower().Contains(keyword));
            }
            return query;
        }

        public DuAn ThemDuAn(DuAn duAn)
        {
            qLNVDbContext.DuAn.Add(duAn);
            qLNVDbContext.SaveChanges();
            return duAn;
        }

        public void XoaDuAn(int duAnId)
        {
            if (qLNVDbContext.DuAn.Any(duAn => duAn.Id == duAnId))
            {
                var currentDuAn = TimDuAnTheoId(duAnId);
                qLNVDbContext.DuAn.Remove(currentDuAn);
                qLNVDbContext.SaveChanges();
            }
        }
    }
}
