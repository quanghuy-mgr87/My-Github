using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using HVIT_MVCTest.Helper;

namespace HVIT_MVCTest.Model
{
    [Table("NhanVien")]
    class NhanVien
    {
        [Key]
        public int NhanvienId { get; set; }
        [StringLength(20)]
        public string Hoten { get; set; }
        [StringLength(10)]
        public string Sodienthoai { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public double Hesoluong { get; set; }
        [InverseProperty("NhanVien")]
        List<PhanCong> phanCongs { get; set; }
        public NhanVien()
        {

        }
        public NhanVien(inputType inputType)
        {
            if (inputType == inputType.ThemNhanVien)
            {
                Hoten = inputHelper.NhapTen("Ho ten: ", "Loi!");
                Sodienthoai = inputHelper.InputString("So dien thoai: ", "Loi!", 0, 10);
                Diachi = inputHelper.InputString("Dia chi: ", "Loi!", 0, int.MaxValue);
                Email = inputHelper.InputString("Email: ", "Loi!", 0, int.MaxValue);
                Console.Write("He so luong: ");
                Hesoluong = double.Parse(Console.ReadLine());
            }
            else if (inputType == inputType.XoaNhanVien)
            {
                NhanvienId = inputHelper.InputInt("Id nhan vien: ", "Loi!");
            }
            else if (inputType == inputType.TinhLuong)
            {
                NhanvienId = inputHelper.InputInt("Id nhan vien: ", "Loi!");
            }
        }
    }
}
