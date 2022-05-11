using HVIT_MVC_DonDatHang.Helper;
using HVIT_MVC_DonDatHang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_MVC_DonDatHang.Controller
{
    class DonDatHangController
    {
        private static List<DonDatHang> lstDonDatHang = new List<DonDatHang>();
        private static List<ChiTietDonDatHang> lstChiTiet = new List<ChiTietDonDatHang>();
        private static List<SanPham> lstSanPham = new List<SanPham>();
        public static errorType ThemSanPham(SanPham sanPham)
        {
            if (lstSanPham.Any(x => x.maSP == sanPham.maSP))
            {
                return errorType.DaTonTai;
            }
            else
            {
                lstSanPham.Add(sanPham);
                return errorType.ThanhCong;
            }
        }
        public static errorType ThemDonDatHang(DonDatHang donDatHang)
        {
            if (lstDonDatHang.Any(x => x.maDDH == donDatHang.maDDH))
            {
                return errorType.DaTonTai;
            }
            else
            {
                lstDonDatHang.Add(donDatHang);
                return errorType.ThanhCong;
            }
        }
        public static errorType ThemChiTietDonDatHang(ChiTietDonDatHang chiTietDonDatHang)
        {
            if (lstChiTiet.Any(x => x.id == chiTietDonDatHang.id))
            {
                return errorType.DaTonTai;
            }
            else
            {
                SanPham sanPham1 = lstSanPham.SingleOrDefault(x => x.maSP == chiTietDonDatHang.maSP);
                DonDatHang donDatHang = lstDonDatHang.SingleOrDefault(x => x.maDDH == chiTietDonDatHang.maDDH);
                if (sanPham1 == null)
                {
                    Console.WriteLine("San pham chua ton tai, ban co muon them san pham moi khong?\n" +
                        "1. Co\n" +
                        "2. Khong");
                    Console.Write("Chon chuc nang: ");
                    char c = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    if (c == '1')
                    {
                        SanPham sanPham = new SanPham();
                        return ThemSanPham(sanPham);
                    }
                    else
                    {
                        return errorType.DanhSachTrong;
                    }
                }

                if (donDatHang == null)
                {
                    Console.WriteLine("Don dat hang chua ton tai, ban co muon them khong?\n" +
                        "1. Co\n" +
                        "2. Khong");
                    Console.Write("Chon chuc nang: ");
                    char c = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    if (c == '1')
                    {
                        DonDatHang donDatHang1 = new DonDatHang();
                        return ThemDonDatHang(donDatHang1);
                    }
                    else
                    {
                        return errorType.DanhSachTrong;
                    }
                }
                else
                {
                    lstChiTiet.Add(chiTietDonDatHang);
                    return errorType.ThanhCong;
                }
            }
        }
        public static SanPham LaySanPhamTheoMa(int maSP)
        {
            SanPham sanPham = lstSanPham.SingleOrDefault(x => x.maSP == maSP);
            return sanPham;
        }
        public static errorType HienThiDon(int maDDH)
        {
            DonDatHang donDatHang = lstDonDatHang.SingleOrDefault(x => x.maDDH == maDDH);
            donDatHang.InThongTin();
            if (lstChiTiet.Any(x => x.maDDH == maDDH))
            {
                foreach (var val in lstChiTiet)
                {
                    int i = 1;
                    if (val.maDDH == maDDH)
                    {
                        Console.WriteLine($"-- {i} --");
                        SanPham sanPham = LaySanPhamTheoMa(val.maSP);
                        sanPham.InThongTin();
                        val.InThongTin();
                        i++;
                    }
                }
                return errorType.ThanhCong;
            }
            else
            {
                return errorType.ChuaTonTai;
            }
        }
    }
}
