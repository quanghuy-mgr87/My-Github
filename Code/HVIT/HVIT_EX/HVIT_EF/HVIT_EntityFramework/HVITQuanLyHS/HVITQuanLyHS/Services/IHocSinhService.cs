using HVITQuanLyHS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVITQuanLyHS.Services
{
    interface IHocSinhService
    {
        /// <summary>
        /// Lấy danh sách học sinh
        /// </summary>
        /// <param name="keyword">Từ khoá</param>
        /// <returns>Danh sách học sinh</returns>
        IEnumerable<HocSinh> LayDanhSachHS(string keyword = null, int maLop = int.MinValue);
        /// <summary>
        /// Lấy học sinh theo mã
        /// </summary>
        /// <param name="hocSinhId">Mã học sinh cần tìm</param>
        /// <returns>Học sinh tìm được</returns>
        HocSinh LayHocSinhTheoMa(int hocSinhId);
        HocSinh ThemHocSinh(HocSinh hocSinh);
        /// <summary>
        /// Hàm sửa thông tin học sinh
        /// </summary>
        /// <param name="hocSinhId">Mã học sinh cần sửa</param>
        /// <param name="hocSinh">Đối tượng học sinh chứa thông tin chỉnh sửa</param>
        /// <returns>Học sinh sau khi sửa</returns>
        HocSinh SuaThongTinHS(int hocSinhId, HocSinh hocSinh);
        /// <summary>
        /// Xoá học sinh
        /// </summary>
        /// <param name="hocSinhId">Mã học sinh cần xoá</param>
        void XoaHocSinh(int hocSinhId);
        /// <summary>
        /// Chuyển lớp cho học sinh sang lớp mới đã tồn tại
        /// </summary>
        /// <param name="hocSinhId">Mã học sinh</param>
        /// <param name="idLop">Mã lớp chuyển đến</param>
        /// <returns>Kết quả chuyển</returns>
        void ChuyenLopHocSinh(int hocSinhId, int idLop);
    }
}
