using HVIT_EF_QLMonAn.Entities;
using HVIT_EF_QLMonAn.Helper;
using HVIT_EF_QLMonAn.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLMonAn.View
{
    class QLMonAnView
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("" +
                "--------- Menu ---------\n" +
                "1. Them mot mon an thuoc loai mon an da ton tai\n" +
                "2. Them cac cong thuc cho mon an\n" +
                "3. Xoa mot loai mon\n" +
                "4. Tim kiem mon an theo ten va nguyen lieu che bien mon\n" +
                "5. Thoat.");
            Console.Write("Chon: ");
            char chon = Console.ReadKey().KeyChar;
            Console.WriteLine();
            DoAction(chon);
        }
        private void DoAction(char c)
        {
            MonAnService monAnService = new MonAnService();
            LoaiMonService loaiMonService = new LoaiMonService();
            CongThucService congThucService = new CongThucService();
            switch (c)
            {
                case '1':
                    {
                        errHelper.log(monAnService.ThemMonAn(new MonAn(inputType.ThemMonAn)));
                    }
                    break;
                case '2':
                    {
                        errHelper.log(congThucService.ThemCacCongThucChoMonAn(new CongThuc(inputType.ThemCongThucMonAn)));
                    }
                    break;
                case '3':
                    {
                        errHelper.log(loaiMonService.XoaLoaiMon(new LoaiMonAn(inputType.XoaLoaiMon)));
                    }
                    break;
                case '4':
                    {
                        errHelper.log(monAnService.TimMonAnTheoTenVaNguyenLieu(new MonAn(inputType.TimMonAnTheoTenVaNguyenLieu)));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
