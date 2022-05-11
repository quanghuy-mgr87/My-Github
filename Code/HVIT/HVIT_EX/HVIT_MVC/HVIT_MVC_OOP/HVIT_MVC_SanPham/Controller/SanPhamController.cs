using HVIT_MVC_SanPham.Helper;
using HVIT_MVC_SanPham.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_MVC_SanPham.Controller
{
    enum errorType
    {
        DaTonTai,
        ChuaTonTai,
        DanhSachTrong,
        ThanhCong
    }
    class SanPhamController
    {
        private static List<SanPham> lstSanPham = new List<SanPham>();

        public static errorType ThemNCC(NhaCungCap nhaCungCap)
        {
            if (lstSanPham.Any(x => x.nhaCC.nhaCC == nhaCungCap.nhaCC))
            {
                return errorType.DaTonTai;
            }
            else
            {
                lstSanPham.Add(new SanPham(nhaCungCap));
                return errorType.ThanhCong;
            }
        }
        public static errorType ThemLoaiSP(LoaiSanPham loaiSanPham)
        {
            if (lstSanPham.Any(x => x.loaiSP.loaiSP == loaiSanPham.loaiSP))
            {
                return errorType.DaTonTai;
            }
            else
            {
                lstSanPham.Add(new SanPham(loaiSanPham));
                return errorType.ThanhCong;
            }
        }

        public static void CapNhatNCCRong(SanPham sanPham)
        {
            Console.WriteLine("Nha cung cap chua ton tai, ban co muon them nha cung cap moi khong?\n" +
                            "1. Co\n" +
                            "2. Khong");
            Console.Write("Chon: ");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (c == '1')
            {
                foreach (var val in lstSanPham)
                {
                    if (val.loaiSP.loaiSP == sanPham.loaiSP.loaiSP)
                    {
                        val.nhaCC = sanPham.nhaCC;
                        val.maSP = sanPham.maSP;
                        val.tenSP = sanPham.tenSP;
                    }
                }
            }
        }
        public static void ThucHienThemNCC(SanPham sanPham)
        {
            Console.WriteLine("Nha cung cap chua ton tai, ban co muon them nha cung cap moi khong?\n" +
                            "1. Co\n" +
                            "2. Khong");
            Console.Write("Chon: ");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (c == '1')
            {
                lstSanPham.Add(sanPham);
            }
        }
        public static errorType ThemSanPham(SanPham sanPham)
        {
            if (lstSanPham.Any(x => x.maSP == sanPham.maSP))
            {
                return errorType.DaTonTai;
            }
            else
            {
                if (lstSanPham.Any(x => x.loaiSP.loaiSP == sanPham.loaiSP.loaiSP))
                {
                    if (lstSanPham.Any(x => x.nhaCC != null && x.loaiSP.loaiSP == sanPham.loaiSP.loaiSP))
                    {
                        if (lstSanPham.Any(x => x.nhaCC.nhaCC == sanPham.nhaCC.nhaCC))
                        {
                            lstSanPham.Add(sanPham);
                        }
                        else
                        {
                            ThucHienThemNCC(sanPham);
                        }
                    }
                    else
                    {
                        CapNhatNCCRong(sanPham);
                    }
                }
                else
                {
                    if (lstSanPham.Any(x => x.nhaCC != null && x.nhaCC.nhaCC == sanPham.nhaCC.nhaCC))
                    {
                        Console.WriteLine("Loai san pham chua ton tai, ban co muon them loai san pham moi khong?\n" +
                        "1. Co\n" +
                        "2. Khong");
                        Console.Write("Chon: ");
                        char c = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        if (c == '1')
                        {
                            lstSanPham.Add(new SanPham(sanPham));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Loai san pham chua ton tai, ban co muon them loai san pham moi khong?\n" +
                        "1. Co\n" +
                        "2. Khong");
                        Console.Write("Chon: ");
                        char c = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        if (c == '1')
                        {
                            lstSanPham.Add(new SanPham(sanPham.loaiSP));
                        }
                    }
                }
                return errorType.ThanhCong;
            }
        }
        public static List<SanPham> SapXepTangTheoNCC(List<SanPham> lst)
        {
            List<SanPham> lstSP = new List<SanPham>();
            foreach (var val in lst)
            {
                lstSP.Add(val);
            }
            for (int i = 0; i < lstSP.Count(); i++)
            {
                for (int j = i; j < lstSP.Count(); j++)
                {
                    if (lstSP[i].nhaCC.nhaCC > lstSP[j].nhaCC.nhaCC)
                    {
                        SanPham temp = lstSP[i];
                        lstSP[i] = lstSP[j];
                        lstSP[j] = temp;
                    }
                }
            }
            return lstSP;
        }
        public static List<SanPham> SapXepTangTheoLoai(List<SanPham> lst)
        {
            List<SanPham> lstSP = new List<SanPham>();
            foreach (var val in lst)
            {
                lstSP.Add(val);
            }
            for (int i = 0; i < lstSP.Count(); i++)
            {
                for (int j = i; j < lstSP.Count(); j++)
                {
                    if (lstSP[i].loaiSP.loaiSP > lstSP[j].loaiSP.loaiSP)
                    {
                        SanPham temp = lstSP[i];
                        lstSP[i] = lstSP[j];
                        lstSP[j] = temp;
                    }
                }
            }
            return lstSP;
        }
        public static errorType HienLoai(int loaiSP)
        {
            if (lstSanPham.Any(x => x.loaiSP.loaiSP == loaiSP))
            {
                List<SanPham> temp = new List<SanPham>();
                foreach (var val in lstSanPham)
                {
                    if (val.loaiSP.loaiSP == loaiSP)
                        temp.Add(val);
                }
                temp = SapXepTangTheoNCC(temp);
                temp.ForEach(x => x.InThongTin());
                return errorType.ThanhCong;
            }
            else
            {
                return errorType.ChuaTonTai;
            }
        }
        public static errorType HienNCC(int nhaCC)
        {
            if (lstSanPham.Any(x => x.nhaCC.nhaCC == nhaCC))
            {
                List<SanPham> temp = new List<SanPham>();
                foreach (var val in lstSanPham)
                {
                    if (val.nhaCC.nhaCC == nhaCC)
                        temp.Add(val);
                }
                temp = SapXepTangTheoLoai(temp);
                temp.ForEach(x => x.InThongTin());
                return errorType.ThanhCong;
            }
            else
            {
                return errorType.ChuaTonTai;
            }
        }
    }
}

