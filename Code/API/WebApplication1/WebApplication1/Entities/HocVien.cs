using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class HocVien
    {
        public Guid HocVienId { get; set; }
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Ho ten phai tu 6 den 50 ki tu")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Ngay sinh la bat buoc")]
        public DateTime NgaySinh { get; set; }
        [Required(ErrorMessage = "Gioi tinh la bat buoc")]
        public byte GioiTinh { get; set; }
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Email phai tu 10 den 100 ki tu")]
        public string Email { get; set; }
        [StringLength(15, MinimumLength = 10, ErrorMessage = "SDT phai tu 10 den 15 ki tu")]
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string TrinhDo { get; set; }
        public string Lop { get; set; }
        public DateTime NgayDangKy { get; set; }

        public HocVien()
        {
        }

        public HocVien(Guid hocVienId, string hoTen, DateTime ngaySinh, byte gioiTinh, string email, string soDienThoai, string diaChi, string trinhDo, string lop, DateTime ngayDangKy)
        {
            HocVienId = hocVienId;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            Email = email;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
            TrinhDo = trinhDo;
            Lop = lop;
            NgayDangKy = ngayDangKy;
        }
    }
}
