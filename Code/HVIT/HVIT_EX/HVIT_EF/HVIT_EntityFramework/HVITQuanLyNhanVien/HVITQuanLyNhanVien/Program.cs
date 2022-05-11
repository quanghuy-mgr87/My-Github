using HVITQuanLyNhanVien.Entities;
using HVITQuanLyNhanVien.Services;
using System;
using System.Collections;

namespace HVITQuanLyNhanVien
{
    class Program
    {
        static void MainMenu()
        {
            Console.WriteLine("1. Nhan vien.");
            Console.WriteLine("2. Du an.");
            Console.WriteLine("3. Phan cong.");
        }
        static void SubMenu()
        {
            Console.WriteLine("- a. Xem.");
            Console.WriteLine("- b. Tim.");
            Console.WriteLine("- c. Them.");
            Console.WriteLine("- d. Sua.");
            Console.WriteLine("- e. Xoa.");
        }
        static void Main(string[] args)
        {
            IDuAnService duAnService = new DuAnService();
            INhanVienService nhanVienService = new NhanVienService();
            IPhanCongService phanCongService = new PhanCongService();
            bool exit = false;
            do
            {
                MainMenu();
                Console.Write("Chon: ");
                var chonMain = Console.ReadLine();
                switch (chonMain)
                {
                    case "1":
                        {
                            SubMenu();
                            Console.Write("Chon: ");
                            var chonSub = Console.ReadLine();
                            switch (chonSub)
                            {
                                case "a":
                                    {
                                        var DSNhanVien = nhanVienService.HienThiDSNhanVien();
                                        foreach (var val in DSNhanVien)
                                        {
                                            Console.WriteLine($"Id: {val.Id}, ho ten: {val.HoTen}, sdt: {val.SDT}, dia chi: {val.DiaChi}, email: {val.Email}, he so luong: {val.HeSoLuong}");
                                        }
                                        break;
                                    }
                                case "b":
                                    {
                                        break;
                                    }
                                case "c":
                                    {
                                        var nhanVienNew = new NhanVien();
                                        nhanVienNew.HoTen = Helper.NhapHoTen("Nhap ho ten nhan vien: ", "Ho ten nhap khong hop le!", 20);
                                        Console.Write("So dien thoai: ");
                                        nhanVienNew.SDT = Console.ReadLine();
                                        Console.Write("Dia chi: ");
                                        nhanVienNew.DiaChi = Console.ReadLine();
                                        nhanVienNew.Email = Helper.NhapEmail("Nhap email: ", "Email nhap khong hop le!");
                                        Console.Write("He so luong: ");
                                        nhanVienNew.HeSoLuong = double.Parse(Console.ReadLine());
                                        nhanVienNew = nhanVienService.ThemNhanVien(nhanVienNew);
                                        Console.WriteLine($"Them thanh cong nhan vien id: {nhanVienNew.Id}, ho ten: {nhanVienNew.HoTen}, sdt: {nhanVienNew.SDT}, dia chi: {nhanVienNew.DiaChi}, email: {nhanVienNew.Email}, he so luong: {nhanVienNew.HeSoLuong}");
                                        break;
                                    }
                                case "d":
                                    {
                                        break;
                                    }
                                case "e":
                                    {
                                        break;
                                    }

                                default:
                                    break;
                            }
                            break;
                        }
                    case "2":
                        {
                            SubMenu();
                            Console.Write("Chon: ");
                            var chonSub = Console.ReadLine();
                            switch (chonSub)
                            {
                                case "a":
                                    {
                                        Console.Write("Nhap ten du an can tim: ");
                                        string keyword = Console.ReadLine();
                                        var DSDuAn = duAnService.HienThiDSDuAn(keyword);
                                        foreach (var val in DSDuAn)
                                        {
                                            Console.WriteLine($"Ma du an: {val.Id}, ten du an: {val.TenDuAn}, mo ta: {val.MoTa}, ghi chu: {val.GhiChu}");
                                        }
                                        break;
                                    }
                                case "b":
                                    {
                                        break;
                                    }
                                case "c":
                                    {
                                        break;
                                    }
                                case "d":
                                    {
                                        Console.WriteLine("Sua thong tin du an:");
                                        Console.Write("Nhap ma du an: ");
                                        var duAnId = int.Parse(Console.ReadLine());
                                        var updateDuAn = new DuAn();
                                        updateDuAn.TenDuAn = Helper.NhapTenDuAn("Nhap ten du an: ", "Ten du an qua dai!", 10);
                                        Console.Write("Mo ta: ");
                                        updateDuAn.MoTa = Console.ReadLine();
                                        Console.Write("Ghi chu: ");
                                        updateDuAn.GhiChu = Console.ReadLine();
                                        updateDuAn = duAnService.SuaDuAn(duAnId, updateDuAn);
                                        Console.WriteLine("Sua du an thanh cong!");
                                        Console.WriteLine($"Ma du an: {updateDuAn.Id}, ten du an: {updateDuAn.TenDuAn}, mo ta: {updateDuAn.MoTa}, ghi chu: {updateDuAn.GhiChu}");
                                        break;
                                    }
                                case "e":
                                    {
                                        break;
                                    }

                                default:
                                    break;
                            }
                            break;
                        }
                    case "3":
                        {
                            SubMenu();
                            Console.Write("Chon: ");
                            var chonSub = Console.ReadLine();
                            switch (chonSub)
                            {
                                case "a":
                                    {
                                        var DSPhanCong = phanCongService.DanhSachPhanCong();
                                        foreach (var val in DSPhanCong)
                                        {
                                            //double luong = phanCongService.TinhLuong();
                                            Console.WriteLine($"ID: {val.Id}, ma du an: {val.DuAnId}, ma nhan vien: {val.NhanVienId}, so gio lam: {val.SoGioLam}");
                                        }
                                        break;
                                    }
                                case "b":
                                    {
                                        Console.WriteLine($"Luong: {phanCongService.TinhLuong(1)}");
                                        break;
                                    }
                                case "c":
                                    {
                                        var newPhanCong = new PhanCong();
                                        Console.Write("Ma nhan vien: ");
                                        newPhanCong.NhanVienId = int.Parse(Console.ReadLine());
                                        Console.Write("Ma du an: ");
                                        newPhanCong.DuAnId = int.Parse(Console.ReadLine());
                                        newPhanCong.SoGioLam = Helper.NhapSoGioLam("Nhap so gio lam: ", "So gio lam phai la so nguyen duong!");
                                        newPhanCong = phanCongService.ThemMoiPhanCong(newPhanCong);
                                        break;
                                    }
                                case "d":
                                    {
                                        break;
                                    }
                                case "e":
                                    {
                                        break;
                                    }

                                default:
                                    break;
                            }
                            break;
                        }

                }
            } while (!exit);
            Console.ReadKey();
        }
    }
}
