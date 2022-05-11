using HVIT_EF_QLNguyenLieu.Helper;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_EF_QLNguyenLieu.Entities
{
    class NguyenLieu
    {
        public int Id { get; set; }
        public int? LoaiNguyenLieuId { get; set; }
        public string TenNguyenLieu { get; set; }
        public double? GiaBan { get; set; }
        public string DonViTinh { get; set; }
        public int? SoLuongKho { get; set; }
        public virtual LoaiNguyenLieu LoaiNguyenLieu { get; set; }
        public virtual IEnumerable<ChiTietPhieuThu> ChiTietPhieuThus { get; set; }
        public NguyenLieu() { }
        public NguyenLieu(inputType inputType)
        {
            QLNguyenLieuDbContext dbContext = new QLNguyenLieuDbContext();
            switch (inputType)
            {
                case inputType.ThemNguyenLieu:
                    {
                        LoaiNguyenLieuId = inputHelper.InputInt(res.inputMaLoaiNL, res.errorMaLoaiNL);
                        if (dbContext.LoaiNguyenLieus.Any(x => x.Id == LoaiNguyenLieuId))
                        {
                            TenNguyenLieu = inputHelper.InputString(res.inputTenNL, res.errorTenNL, 0, 20);
                            GiaBan = inputHelper.InputDouble(res.inputGiaBan, res.errorGiaBan);
                            DonViTinh = inputHelper.InputString(res.inputDonVi, res.errorDonVi, 0, 10);
                            SoLuongKho = inputHelper.InputInt(res.inputSoLuongKho, res.errorSoLuongKho);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
