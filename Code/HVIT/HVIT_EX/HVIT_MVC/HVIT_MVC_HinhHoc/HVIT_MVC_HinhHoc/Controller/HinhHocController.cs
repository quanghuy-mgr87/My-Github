using HVIT_MVC_HinhHoc.Helper;
using HVIT_MVC_HinhHoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_MVC_HinhHoc.Controller
{
    class HinhHocController
    {
        private static List<HinhHoc> lstHinhHoc = new List<HinhHoc> { new HinhHoc(new Diem(0, 0), new Diem(1, 1), new Diem(2, 1), new Diem(3, 0)) };
        private static Random random = new Random();
        public static void TaoNgauNhien()
        {
            int soLuongHinh = inputHelper.InputInt("So luong hinh: ", "Loi!");
            List<Diem> lstDiem = new List<Diem>();
            for (int i = 0; i < soLuongHinh; i++)
            {
                int soLuongDiem = random.Next(3, 5);
                for (int j = 0; j < soLuongDiem; j++)
                {
                    bool ok;
                    do
                    {
                        int toaDoX = random.Next(0, 4);
                        int toaDoY = random.Next(0, 4);
                        Diem diem = lstDiem.SingleOrDefault(x => x.x == toaDoX && x.y == toaDoY);
                        if (diem == null)
                        {
                            lstDiem.Add(new Diem(toaDoX, toaDoY));
                            ok = true;
                        }
                        else
                        {
                            ok = false;
                        }
                    } while (!ok);
                }
                HinhHoc hinhHoc = new HinhHoc(lstDiem.ToArray());
                hinhHoc.XacDinhHinh();
                lstHinhHoc.Add(hinhHoc);
            }
        }

        public static void HienThi(LoaiHinh loaiHinh)
        {
            foreach (var val in lstHinhHoc)
            {
                val.XacDinhHinh();
            }
            switch (loaiHinh)
            {
                case LoaiHinh.Vuong:
                    {
                        lstHinhHoc.Where(x => x.laHinhVuong).ToList().ForEach(x => x.InThongTin());
                    }
                    break;
                case LoaiHinh.TamGiac:
                    {
                        lstHinhHoc.Where(x => x.laTamGiac).ToList().ForEach(x => x.InThongTin());
                    }
                    break;
                case LoaiHinh.ChuNhat:
                    {
                        lstHinhHoc.Where(x => x.laChuNhat).ToList().ForEach(x => x.InThongTin());
                    }
                    break;
                case LoaiHinh.Thang:
                    {
                        lstHinhHoc.Where(x => x.laHinhThang).ToList().ForEach(x => x.InThongTin());
                    }
                    break;
                case LoaiHinh.TatCa:
                    {
                        lstHinhHoc.ForEach(x => x.InThongTin());
                    }
                    break;
                case LoaiHinh.BinhHanh:
                    {
                        lstHinhHoc.Where(x => x.laBinhHanh).ToList().ForEach(x => x.InThongTin());
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
