	using QLKhoaHocMVC.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QLKhoaHocMVC.Model
{
    [Table("KhoaHoc")]
    class KhoaHoc
    {
        [Key]
        public int KhoahocID { get; set; }
        [StringLength(10)]
        public string Tenkhoahoc { get; set; }
        public string Mota { get; set; }
        public int Hocphi { get; set; }
        public DateTime Ngaybatdau { get; set; }
        public DateTime Ngayketthuc { get; set; }
        [InverseProperty("KhoaHoc")]
        List<HocVien> hocViens { get; set; }
        List<NgayHoc> ngayHocs { get; set; }
        public KhoaHoc()
        {

        }
        public KhoaHoc(inputType inputType)
        {
            switch (inputType)
            {
                case inputType.XoaKhoaHoc:
                    {
                        KhoahocID = inputHelper.InputInt("Ma khoa hoc: ", "Loi!");
                    }
                    break;
                case inputType.TinhDoanhThu:
                    {

                    }
                    break;
                case inputType.ThemNgayHocVaoKhoaHoc:
                    {
                        KhoahocID = inputHelper.InputInt("Ma khoa hoc: ", "Loi!");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
