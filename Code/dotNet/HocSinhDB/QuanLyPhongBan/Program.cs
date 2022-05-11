using QuanLyPhongBan.Entities;
using QuanLyPhongBan.Service;
using System;

namespace QuanLyPhongBan
{
    class Program
    {
        static void Menu()
        {
            Console.WriteLine("Chon chuc nang:");
            Console.WriteLine("1. Lay danh sach nhan vien.");
            Console.WriteLine("2. Lay nhan vien theo Id.");
            Console.WriteLine("3. Tao nhan vien.");
            Console.WriteLine("4. Cap nhat nhan vien.");
            Console.WriteLine("5. Xoa nhan vien.");
            Console.WriteLine("6. Thoat.");
        }
        static void Main(string[] args)
        {
            Menu();
            Console.Write("Chon chuc nang: ");
            var chon = Console.ReadLine();
            INhanVienService nhanVienService = new NhanVienService();
            switch (chon)
            {
                case "1":
                    {
                        Console.Write("Nhap tu khoa tim kiem: ");
                        var keyword = Console.ReadLine();
                        var nhanVien = nhanVienService.LayDanhSachNhanVien(keyword);
                        int i = 1;
                        foreach (var val in nhanVien)
                        {
                            Console.WriteLine($"{i}. Ma nhan vien: {val.Id}, Ho ten: {val.HoTen}, Dia chi: {val.DiaChi}, SDT: {val.SoDienThoai}, Email: {val.Email}");
                            i++;
                        }
                        break;
                    }
                case "2":
                    {
                        Console.Write("Nhap ma nhan vien: ");
                        var maNhanVien = int.Parse(Console.ReadLine());
                        NhanVien nhanVien = nhanVienService.LayNhanVienTheoMa(maNhanVien);
                        Console.WriteLine($"Ma nhan vien: {nhanVien.Id}, Ho ten: {nhanVien.HoTen}, Dia chi: {nhanVien.DiaChi}, SDT: {nhanVien.SoDienThoai}, Email: {nhanVien.Email}");
                        break;
                    }
                case "3":
                    {
                        var nhanVienNew = new NhanVien();
                        Console.Write("- Ho ten: ");
                        nhanVienNew.HoTen = Console.ReadLine();
                        Console.Write("- Dia chi: ");
                        nhanVienNew.DiaChi = Console.ReadLine();
                        Console.Write("- So dien thoai: ");
                        nhanVienNew.SoDienThoai = Console.ReadLine();
                        Console.Write("- Email: ");
                        nhanVienNew.Email = Console.ReadLine();
                        Console.Write("- Ma phong ban: ");
                        nhanVienNew.PhongBanId = int.Parse(Console.ReadLine());
                        nhanVienNew = nhanVienService.TaoNhanVien(nhanVienNew);
                        Console.Write($"Ma nhan vien: {nhanVienNew.Id}, Ho ten: {nhanVienNew.HoTen}, Dia chi: {nhanVienNew.DiaChi}, SDT: {nhanVienNew.SoDienThoai}, Email: {nhanVienNew.Email}");
                        break;
                    }
                case "4":
                    {
                        var nhanVienUpdate = new NhanVien();
                        Console.Write("Nhap ma nhan vien: ");
                        nhanVienUpdate.Id = int.Parse(Console.ReadLine());
                        Console.Write("- Ho ten: ");
                        nhanVienUpdate.HoTen = Console.ReadLine();
                        Console.Write("- Dia chi: ");
                        nhanVienUpdate.DiaChi = Console.ReadLine();
                        Console.Write("- So dien thoai: ");
                        nhanVienUpdate.SoDienThoai = Console.ReadLine();
                        Console.Write("- Email: ");
                        nhanVienUpdate.Email = Console.ReadLine();
                        Console.Write("- Ma phong ban: ");
                        nhanVienUpdate.PhongBanId = int.Parse(Console.ReadLine());
                        nhanVienUpdate = nhanVienService.CapNhatNhanVien(nhanVienUpdate.Id, nhanVienUpdate);
                        Console.Write($"Ma nhan vien: {nhanVienUpdate.Id}, Ho ten: {nhanVienUpdate.HoTen}, Dia chi: {nhanVienUpdate.DiaChi}, SDT: {nhanVienUpdate.SoDienThoai}, Email: {nhanVienUpdate.Email}");
                        break;
                    }
                case "5":
                    {
                        Console.Write("Nhap ma nhan vien: ");
                        var nhanVienId = int.Parse(Console.ReadLine());
                        nhanVienService.XoaNhanVien(nhanVienId);
                        Console.WriteLine($"Da xoa nhan vien {nhanVienId}");
                        break;
                    }
            }
            Console.ReadKey();
        }
    }
}
