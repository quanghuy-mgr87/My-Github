using DoAn.Entities;
using DoAn.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Services
{
    class PhongBanServices : IPhongBanServices
    {
        private AppDbContext dbContext { get; }
        public PhongBanServices()
        {
            dbContext = new AppDbContext();
        }
        public PhongBan GetPhongBanById(int phongBanId)
        {
            return dbContext.phongBans.Find(phongBanId);
        }

        public List<PhongBan> GetPhongBanList(string keyword = "")
        {
            var lstPB = dbContext.phongBans.AsQueryable().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                lstPB = lstPB.Where(x => x.tenPhongBan == keyword).ToList();
            }
            lstPB = lstPB.Select(x => new PhongBan()
            {
                id = x.id,
                tenPhongBan = x.tenPhongBan,
                soNhanVien = x.soNhanVien
            }).ToList();
            return lstPB;
        }

        public bool SuaPhongBan(PhongBan phongBan)
        {
            var currentPB = dbContext.phongBans.SingleOrDefault(x => x.id == phongBan.id);
            if (currentPB != null)
            {
                currentPB.tenPhongBan = phongBan.tenPhongBan;
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ThemPhongBan(PhongBan phongBan)
        {
            if (!dbContext.phongBans.Any(x => x.id == phongBan.id))
            {
                int soLuongNV = dbContext.nhanViens.Where(x => x.phongBanId == phongBan.id).Count();
                phongBan.id = 0;
                phongBan.soNhanVien = soLuongNV;
                dbContext.phongBans.Add(phongBan);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool XoaPhongBan(int phongBanId)
        {
            var currentPB = dbContext.phongBans.SingleOrDefault(x => x.id == phongBanId);
            if (currentPB != null)
            {
                dbContext.phongBans.Remove(currentPB);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
