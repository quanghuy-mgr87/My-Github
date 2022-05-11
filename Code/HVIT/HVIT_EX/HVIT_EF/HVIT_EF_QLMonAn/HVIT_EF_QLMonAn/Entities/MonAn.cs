using HVIT_EF_QLMonAn.Helper;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_EF_QLMonAn.Entities
{
    class MonAn
    {
        public int Id { get; set; }
        public int? LoaiMonAnId { get; set; }
        public string TenMon { get; set; }
        public double? GiaBan { get; set; }
        public string GioiThieu { get; set; }
        public string CachLam { get; set; }
        public virtual IEnumerable<CongThuc> CongThucs { get; set; }
        public virtual LoaiMonAn LoaiMonAn { get; set; }
        public MonAn() { }
        public MonAn(inputType inputType)
        {
            switch (inputType)
            {
                case inputType.ThemMonAn:
                    {
                        AppDbContext dbContext = new AppDbContext();
                        bool ok;
                        do
                        {
                            LoaiMonAnId = inputHelper.InputInt(res.inputLoaiMonAnId, res.errorLoaiMonAnId);
                            ok = dbContext.loaiMonAns.Any(x => x.Id == LoaiMonAnId);
                            if (!ok)
                            {
                                Console.WriteLine("Loai mon an khong ton tai!");
                            }
                        } while (!ok);
                        TenMon = inputHelper.NhapTenMon(res.inputTenMon, res.errorTenMon);
                        GiaBan = inputHelper.InputDouble(res.inputGiaBan, res.errorGiaBan);
                        GioiThieu = inputHelper.InputString(res.inputGioiThieu, res.errorGioiThieu);
                        CachLam = inputHelper.InputString(res.inputCachLam, res.errorCachLam);
                    }
                    break;
                case inputType.TimMonAnTheoTenVaNguyenLieu:
                    {
                        TenMon = inputHelper.NhapTenMon(res.inputTenMon, res.errorTenMon);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
