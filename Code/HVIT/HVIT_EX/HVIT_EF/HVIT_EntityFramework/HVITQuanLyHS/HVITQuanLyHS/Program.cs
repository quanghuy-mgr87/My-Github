using HVITQuanLyHS.Entities;
using HVITQuanLyHS.Services;
using System;
using System.Collections;
using System.Linq;

namespace HVITQuanLyHS
{

    class Program
    {
        static void Menu()
        {
            Console.WriteLine("============ Menu ============");
            Console.WriteLine("1. Hien thi danh sach hoc sinh.");
            Console.WriteLine("2. Hien thi hoc sinh theo ma.");
            Console.WriteLine("3. Them hoc sinh vao lop.");
            Console.WriteLine("4. Sua thong tin hoc sinh.");
            Console.WriteLine("5. Xoa hoc sinh.");
            Console.WriteLine("6. Chuyen lop.");
        }

        static void Main(string[] args)
        {
            IHocSinhService hocSinhService = new HocSinhService();
            ILopService lopService = new LopService();
            bool exit = false;
            do
            {
                Menu();
                Console.Write("Chon chuc nang: ");
                var chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":
                        {
                            Console.Write("Nhap tu khoa: ");
                            var keyword = Console.ReadLine();
                            var lstHS = hocSinhService.LayDanhSachHS(keyword);
                            if (lstHS.Count() == 0)
                            {
                                Console.WriteLine("Danh sach rong!");
                            }
                            foreach (var val in lstHS)
                            {
                                var lop = lopService.LayLopTheoMa(val.LopId);
                                Console.WriteLine($"Id: {val.Id}, ho ten: {val.HoTen}, ngay sinh: {val.NgaySinh.ToShortDateString()}, que quan: {val.QueQuan}, ma lop: {val.LopId}, tenlop: {lop.TenLop}");
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Nhap ma hoc sinh: ");
                            var hocSinhId = int.Parse(Console.ReadLine());
                            var hocSinh = hocSinhService.LayHocSinhTheoMa(hocSinhId);
                            var lop = lopService.LayLopTheoMa(hocSinh.LopId);
                            Console.WriteLine($"Id: {hocSinh.Id}, ho ten: {hocSinh.HoTen}, ngay sinh: {hocSinh.NgaySinh.ToShortDateString()}, que quan: {hocSinh.QueQuan}, ma lop: {hocSinh.LopId}, ten lop: {lop.TenLop}");
                            break;
                        }
                    case "3":
                        {
                            string keyword = null;
                            Console.Write("Nhap lop muon them hoc sinh: ");
                            var maLop = int.Parse(Console.ReadLine());
                            var dsLop = hocSinhService.LayDanhSachHS(keyword, maLop);
                            if (dsLop.Count() >= 20)
                            {
                                Console.WriteLine("Lop da du hoc sinh!");
                            }
                            else
                            {
                                var newHS = new HocSinh();
                                var updateLop = lopService.LayLopTheoMa(maLop);
                                newHS.HoTen = Helper.NhapHoTen("Nhap ho ten: ", "Ho ten vua nhap khong hop le!", 20);
                                newHS.NgaySinh = Helper.NhapNgaySinh("Nhap ngay sinh: ", "Nam sinh phai nhap trong khoang tu 2001 den 2013!", 2001, 2013);
                                Console.Write("Que quan: ");
                                newHS.QueQuan = Console.ReadLine();
                                newHS.LopId = maLop;
                                newHS = hocSinhService.ThemHocSinh(newHS);
                                //cập nhật sĩ số lớp
                                dsLop = hocSinhService.LayDanhSachHS(keyword, maLop);
                                updateLop.SiSo = dsLop.Count();
                                updateLop = lopService.SuaThongTinLop(maLop, updateLop);
                                Console.WriteLine("Them thanh cong!");
                            }
                            if (dsLop.Count() == 0)
                            {
                                Console.WriteLine("Khong co thong tin hoc sinh");
                            }
                            break;
                        }
                    case "4":
                        {
                            Console.Write("Nhap ma hoc sinh: ");
                            var hocSinhId = int.Parse(Console.ReadLine());
                            var updateHS = new HocSinh();
                            updateHS.HoTen = Helper.NhapHoTen("Nhap ho ten: ", "Ho ten vua nhap khong hop le!", 20);
                            updateHS.NgaySinh = Helper.NhapNgaySinh("Nhap ngay sinh: ", "Nam sinh phai nhap trong khoang tu 2001 den 2013!", 2001, 2013);
                            Console.Write("Que quan: ");
                            updateHS.QueQuan = Console.ReadLine();
                            Console.Write("Ma lop: ");
                            updateHS.LopId = int.Parse(Console.ReadLine());
                            updateHS = hocSinhService.SuaThongTinHS(hocSinhId, updateHS);
                            Console.WriteLine("Cap nhat thanh cong!");
                            break;
                        }
                    case "5":
                        {
                            Console.Write("Nhap ma hoc sinh: ");
                            var hocSinhId = int.Parse(Console.ReadLine());
                            hocSinhService.XoaHocSinh(hocSinhId);
                            Console.WriteLine("Xoa hoc sinh thanh cong!");
                            break;
                        }
                    case "6":
                        {
                            Console.Write("Nhap ma hoc sinh: ");
                            var hocSinhId = int.Parse(Console.ReadLine());
                            Console.Write("Nhap ma lop can chuyen den: ");
                            var lopId = int.Parse(Console.ReadLine());
                            hocSinhService.ChuyenLopHocSinh(hocSinhId, lopId);
                            Console.WriteLine("Chuyen lop thanh cong!");
                            break;
                        }
                    default:
                        break;
                }
            } while (!exit);
            Console.ReadKey();
        }
    }
}
