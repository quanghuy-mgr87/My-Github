using QLKhoaHocMVC.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QLKhoaHocMVC.Model
{
    [Table("HocVien")]
    class HocVien
    {
        [Key]
        public int HocvienID { get; set; }
        public int KhoahocID { get; set; }
        [StringLength(20)]
        public string Hoten { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string Quequan { get; set; }
        public string Diachi { get; set; }
        [StringLength(10)]
        public string Sodienthoai { get; set; }
        [ForeignKey("KhoahocID")]
        KhoaHoc khoaHoc { get; set; }
        public HocVien()
        {

        }
        public HocVien(inputType inputType)
        {
            switch (inputType)
            {
                case inputType.SuaThongTinHocVien:
                    {
                        HocvienID = inputHelper.InputInt("Ma hoc vien: ", "Loi!");
                        KhoahocID = inputHelper.InputInt("Ma khoa hoc: ", "Loi!");
                        Hoten = inputHelper.NhapTen("Ho ten: ", "Loi!");
                        Ngaysinh = inputHelper.NhapNgay("Ngay sinh: ", "Loi!");
                        Console.Write("Que quan: ");
                        Quequan = Console.ReadLine();
                        Console.Write("Dia chi: ");
                        Diachi = Console.ReadLine();
                        Console.Write("So dien thoai: ");
                        Sodienthoai = Console.ReadLine();
                    }
                    break;
                case inputType.TimHocVienTheoHoTenVaKhoaHoc:
                    {
                        Hoten = inputHelper.NhapTen("Ho ten: ", "Loi!");
                        KhoahocID = inputHelper.InputInt("Ma khoa hoc: ", "Loi!");
                    }
                    break;
                case inputType.ThemHocVien:
                    {
                        KhoahocID = inputHelper.InputInt("Ma khoa hoc: ", "Loi!");
                        Hoten = inputHelper.NhapTen("Ho ten: ", "Loi!");
                        Ngaysinh = inputHelper.NhapNgay("Ngay sinh: ", "Loi!");
                        Console.Write("Que quan: ");
                        Quequan = Console.ReadLine();
                        Console.Write("Dia chi: ");
                        Diachi = Console.ReadLine();
                        Console.Write("So dien thoai: ");
                        Sodienthoai = Console.ReadLine();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
