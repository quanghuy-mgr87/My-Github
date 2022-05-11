using HVIT_MVC_HocSinh.Helper;
using HVIT_MVC_HocSinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_MVC_HocSinh.Controller
{
    class DiemController
    {
        private static List<Diem> lstDiem = new List<Diem>();
        private static List<HocSinh> lstHocSinh = new List<HocSinh>();
        private static List<MonHoc> lstMonHoc = new List<MonHoc>();

        private static bool KiemTraTonTaiHS(List<HocSinh> lstHS, int hocSinhID)
        {
            foreach (HocSinh val in lstHS)
            {
                if (val.maHocSinh == hocSinhID)
                    return true;
            }
            return false;
        }

        private static bool KiemTraTonTaiMH(List<MonHoc> lstMH, int monHocID)
        {
            foreach (MonHoc val in lstMH)
            {
                if (val.maMH == monHocID)
                    return true;
            }
            return false;
        }

        private static bool KiemTraHocSinhTrongBangDiem(List<Diem> lstDiem, int hocSinhID)
        {
            foreach (Diem val in lstDiem)
            {
                if (val.maHS == hocSinhID)
                    return true;
            }
            return false;
        }

        private static bool KiemTraMonHocTrongBangDiem(List<Diem> lstDiem, int monHocID)
        {
            foreach (Diem val in lstDiem)
            {
                if (val.maMH == monHocID)
                    return true;
            }
            return false;
        }

        public static int DemHS(List<string> lstHocSinh, int hocSinhId)
        {
            HocSinh hocSinh = LayThongTinHSTheoMa(hocSinhId);
            int dem = 0;
            foreach (var val in lstHocSinh)
            {
                if (string.Compare(val, hocSinh.tenHocSinh, true) == 0)
                {
                    dem++;
                }
            }
            return dem;
        }

        public static void HienThiDSHocSinh()
        {
            int dem = 0;
            List<string> temp = new List<string>();
            for (int i = 0; i < lstHocSinh.Count(); i++)
            {
                dem = DemHS(temp, lstHocSinh[i].maHocSinh);
                temp.Add(lstHocSinh[i].tenHocSinh);
                if (dem != 0)
                {
                    lstHocSinh[i].tenHocSinh += dem.ToString();
                }
            }

            foreach (HocSinh hocSinh1 in lstHocSinh)
            {
                hocSinh1.InThongTin();
            }
        }

        private static HocSinh LayThongTinHSTheoMa(int hocSinhID)
        {
            HocSinh temp = null;
            foreach (HocSinh val in lstHocSinh)
            {
                if (val.maHocSinh == hocSinhID)
                    temp = val;
            }
            return temp;
        }

        private static MonHoc LayMonHocTheoMa(int monHocID)
        {
            MonHoc temp = null;
            foreach (MonHoc val in lstMonHoc)
            {
                if (val.maMH == monHocID)
                    temp = val;
            }
            return temp;
        }

        public static void InBangDiem(List<Diem> lstDiem, int maHS)
        {
            foreach (Diem val in lstDiem)
            {
                if (val.maHS == maHS)
                {
                    MonHoc monHoc = LayMonHocTheoMa(val.maMH);
                    Console.WriteLine($"{monHoc.tenMH}: {val.diem} diem");
                }
            }
        }
        public static void InBangTongKet(List<Diem> lstDiem, int maMH)
        {
            foreach (Diem val in lstDiem)
            {
                if (val.maMH == maMH)
                {
                    HocSinh hocSinh = LayThongTinHSTheoMa(val.maHS);
                    Console.WriteLine($"Hoc sinh: {hocSinh.tenHocSinh}: {val.diem} diem.");
                }
            }
        }

        public static errorType ThemHocSinh(HocSinh hocSinh)
        {
            if (KiemTraTonTaiHS(lstHocSinh, hocSinh.maHocSinh))
            {
                return errorType.HSDaTonTai;
            }
            else
            {
                lstHocSinh.Add(hocSinh);
                return errorType.ThanhCong;
            }
        }
        public static errorType ThemMonHoc(MonHoc monHoc)
        {
            if (KiemTraTonTaiMH(lstMonHoc, monHoc.maMH))
            {
                return errorType.MHDaTonTai;
            }
            else
            {
                lstMonHoc.Add(monHoc);
                return errorType.ThanhCong;
            }
        }
        public static errorType ChamDiem(int maHS, int maMH)
        {
            if (!KiemTraTonTaiHS(lstHocSinh, maHS))
            {
                return errorType.HSChuaTonTai;
            }
            if (!KiemTraTonTaiMH(lstMonHoc, maMH))
            {
                return errorType.MHChuaTonTai;
            }
            else
            {
                if (KiemTraHocSinhTrongBangDiem(lstDiem, maHS) && KiemTraMonHocTrongBangDiem(lstDiem, maMH))
                {
                    foreach (Diem val in lstDiem)
                    {
                        if (val.maMH == maMH && val.maHS == maHS)
                        {
                            val.diem = inputHelper.NhapDiem(res.inputDiem, res.errorDiem);
                        }
                    }
                }
                else
                {
                    double diem = inputHelper.NhapDiem(res.inputDiem, res.errorDiem);
                    Diem diem1 = new Diem(maHS, maMH, diem);
                    lstDiem.Add(diem1);
                }
                return errorType.ThanhCong;
            }
        }
        public static errorType BangDiem(int maHS)
        {
            if (KiemTraTonTaiHS(lstHocSinh, maHS))
            {
                if (KiemTraHocSinhTrongBangDiem(lstDiem, maHS))
                {
                    HocSinh hs = LayThongTinHSTheoMa(maHS);
                    hs.InThongTin();
                    InBangDiem(lstDiem, maHS);
                    return errorType.ThanhCong;
                }
                else
                {
                    return errorType.DanhSachTrong;
                }
            }
            else
            {
                return errorType.HSChuaTonTai;
            }
        }
        public static errorType TongKetMon(int maMH)
        {
            if (KiemTraTonTaiMH(lstMonHoc, maMH))
            {
                if (KiemTraMonHocTrongBangDiem(lstDiem, maMH))
                {
                    MonHoc monHoc = LayMonHocTheoMa(maMH);
                    monHoc.InThongTin();
                    InBangTongKet(lstDiem, maMH);
                    return errorType.ThanhCong;
                }
                else
                {
                    return errorType.DanhSachTrong;
                }
            }
            else
            {
                return errorType.MHChuaTonTai;
            }
        }
    }
}
