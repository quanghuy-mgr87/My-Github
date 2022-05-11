using HVIT_EF_QLMonAn.Entities;
using HVIT_EF_QLMonAn.Helper;
using HVIT_EF_QLMonAn.IServices;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HVIT_EF_QLMonAn.Services
{
    class MonAnService : IMonAnService
    {
        private AppDbContext dbContext { get; }
        public MonAnService()
        {
            dbContext = new AppDbContext();
        }
        public errType ThemMonAn(MonAn monAn)
        {
            dbContext.monAns.Add(monAn);
            dbContext.SaveChanges();
            return errType.ThanhCong;
        }

        public errType TimMonAnTheoTenVaNguyenLieu(MonAn monAn)
        {
            var monAn1 = dbContext.monAns.SingleOrDefault(x => x.TenMon.Contains(monAn.TenMon));
            string tenNguyenLieu = inputHelper.NhapTenNguyenLieu(res.inputTenNguyenLieu, res.errorTenNguyenLieu);
            var nguyenLieu = dbContext.nguyenLieus.SingleOrDefault(x => x.TenNguyenLieu.Contains(tenNguyenLieu));
            if (monAn1 == null)
            {
                return errType.MonAnKhongTonTai;
            }
            if (nguyenLieu == null)
            {
                return errType.NguyenLieuKhongTonTai;
            }
            else
            {
                if (dbContext.congThucs.Any(x => x.MonAnId == monAn1.Id && x.NguyenLieuId == nguyenLieu.Id))
                {
                    Console.WriteLine($"Mon an can tim: {monAn1.TenMon} co ma mon an la {monAn1.Id}\n" +
                       $"Cac nguyen lieu:\n" +
                       $"{monAn1.CachLam}");
                    return errType.ThanhCong;
                }
                else
                {
                    return errType.MonAnKhongTonTai;
                }
            }
        }
    }
}
