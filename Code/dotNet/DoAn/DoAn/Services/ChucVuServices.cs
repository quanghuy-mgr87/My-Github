using DoAn.Entities;
using DoAn.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Services
{
    class ChucVuServices : IChucVuServices
    {
        private AppDbContext dbContext { get; }
        public ChucVuServices()
        {
            dbContext = new AppDbContext();
        }
        public ChucVu GetChucVuById(int chucVuId)
        {
            return dbContext.chucVus.Find(chucVuId);
        }

        public List<ChucVu> GetChucVuList(string keyword = "")
        {
            var lstChucVu = dbContext.chucVus.AsQueryable().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                lstChucVu = lstChucVu.Where(x => x.tenChucVu == keyword).ToList();
            }
            lstChucVu = lstChucVu.Select(x => new ChucVu()
            {
                id = x.id,
                tenChucVu = x.tenChucVu
            }).ToList();
            return lstChucVu;
        }

        public bool SuaChucVu(ChucVu chucVu)
        {
            var currentChucVu = dbContext.chucVus.SingleOrDefault(x => x.id == chucVu.id);
            if (chucVu != null)
            {
                currentChucVu.tenChucVu = chucVu.tenChucVu;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ThemChucVu(ChucVu chucVu)
        {
            if (!dbContext.chucVus.Any(x => x.id == chucVu.id))
            {
                chucVu.id = 0;
                dbContext.chucVus.Add(chucVu);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool XoaChucVu(int chucVuId)
        {
            var chucVu = dbContext.chucVus.SingleOrDefault(x => x.id == chucVuId);
            if (chucVu != null)
            {
                dbContext.chucVus.Remove(chucVu);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
