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
    class CongThucService : ICongThucService
    {
        private AppDbContext dbContext { get; }
        public CongThucService()
        {
            dbContext = new AppDbContext();
        }
        public void ThemMotCongThuc(MonAn monAn)
        {
            string cachLam = "";
            bool ok;
            int nguyenLieuId;
            do
            {
                nguyenLieuId = inputHelper.InputInt(res.inputNguyenLieuId, res.errorNguyenLieuId);
                ok = dbContext.nguyenLieus.Any(x => x.Id == nguyenLieuId);
                if (!ok)
                {
                    Console.WriteLine("Nguyen lieu khong ton tai!");
                }
            } while (!ok);

            //them chi tiet cong thuc
            var congThuc = new CongThuc();
            congThuc.MonAnId = monAn.Id;
            congThuc.NguyenLieuId = nguyenLieuId;
            congThuc.SoLuong = inputHelper.InputInt(res.inputSoLuongNL, res.errorSoLuongNL);
            congThuc.DonViTinh = inputHelper.NhapDonVi(res.inputDonVi, res.errorDonVi);
            dbContext.congThucs.Add(congThuc);
            dbContext.SaveChanges();

            var nguyenLieu = dbContext.nguyenLieus.Find(nguyenLieuId);
            cachLam += $"{nguyenLieu.TenNguyenLieu}: {congThuc.SoLuong} {congThuc.DonViTinh}\n";

            if (string.IsNullOrEmpty(monAn.CachLam))
            {
                monAn.CachLam = cachLam;
            }
            else
            {
                monAn.CachLam += cachLam;
            }
            Console.WriteLine(monAn.CachLam);
            dbContext.monAns.Update(monAn);
            dbContext.SaveChanges();
        }
        public errType ThemCacCongThucChoMonAn(CongThuc congThuc)
        {
            if (dbContext.monAns.Any(x => x.Id == congThuc.MonAnId))
            {
                MonAn monAn = dbContext.monAns.Find(congThuc.MonAnId);
                int soLuong = inputHelper.InputInt(res.inputSoLuongNL, res.errorSoLuongNL);
                for (int i = 0; i < soLuong; i++)
                {
                    ThemMotCongThuc(monAn);
                    Console.WriteLine();
                }
                return errType.ThanhCong;
            }
            else
            {
                return errType.MonAnKhongTonTai;
            }
        }
    }
}
