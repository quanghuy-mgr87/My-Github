using QLBanHang.Helper;
using QLBanHang.Interface;
using QLBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Services
{
    internal class NguoiMuaHangServices : INguoiMuaHangServices
    {
        private readonly IHoaDonServices hoaDonServices = new HoaDonServices();
        public bool KiemTraTonTaiNguoiMuaHang(int nguoiMuaHangId = 0, string maSoThue = null, string stk = null)
        {
            return LayDSNguoiMuaHang(nguoiMuaHangId, null, maSoThue, stk).Rows.Count > 0;
        }
        public DataTable LayDSNguoiMuaHang(int nguoiMuaHangId = 0, string hoTen = null, string maSoThue = null, string stk = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
            {
                conn.Open();
                String sql = "Select * from NguoiMuaHang where 1 = 1 ";
                if (nguoiMuaHangId != 0)
                {
                    sql += "and Id = @Id ";
                }
                if (!string.IsNullOrEmpty(hoTen))
                {
                    sql += "and HoTen like @HoTen ";
                }
                if (!string.IsNullOrEmpty(maSoThue))
                {
                    sql += "and MaSoThue like @MaSoThue ";
                }
                if (!string.IsNullOrEmpty(stk))
                {
                    sql += "and SoTaiKhoan like @SoTaiKhoan ";
                }
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@Id", nguoiMuaHangId);
                adapter.SelectCommand.Parameters.AddWithValue("@HoTen", $"%{hoTen}%");
                adapter.SelectCommand.Parameters.AddWithValue("@MaSoThue", $"{maSoThue}");
                adapter.SelectCommand.Parameters.AddWithValue("@SoTaiKhoan", $"{stk}");
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public bool SuaThongTinNguoiMuaHang(NguoiMuaHang nguoiMuaHang)
        {
            if (KiemTraTonTaiNguoiMuaHang(nguoiMuaHang.Id))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string sql = "update NguoiMuaHang set HoTen = @HoTen, TenDonVi = @TenDonVi, DiaChi = @DiaChi, SoTaiKhoan = @SoTaiKhoan, HinhThucThanhToan = @HinhThucThanhToan, MaSoThue = @MaSoThue where Id = @Id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", $"{nguoiMuaHang.Id}");
                    cmd.Parameters.AddWithValue("@HoTen", $"{InputHelper.ChuanHoaHoTen(nguoiMuaHang.HoTen)}");
                    cmd.Parameters.AddWithValue("@TenDonVi", $"{nguoiMuaHang.TenDonVi}");
                    cmd.Parameters.AddWithValue("@DiaChi", $"{nguoiMuaHang.DiaChi}");
                    cmd.Parameters.AddWithValue("@SoTaiKhoan", $"{nguoiMuaHang.SoTaiKhoan}");
                    cmd.Parameters.AddWithValue("@HinhThucThanhToan", $"{nguoiMuaHang.HinhThucThanhToan}");
                    cmd.Parameters.AddWithValue("@MaSoThue", $"{nguoiMuaHang.MaSoThue}");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;
        }

        public bool ThemNguoiMuaHang(NguoiMuaHang nguoiMuaHang)
        {
            if (!KiemTraTonTaiNguoiMuaHang(0, nguoiMuaHang.MaSoThue))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string sql = "insert into NguoiMuaHang values (@Id, @HoTen, @TenDonVi, @DiaChi, @SoTaiKhoan, @HinhThucThanhToan, @MaSoThue)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@HoTen", $"{InputHelper.ChuanHoaHoTen(nguoiMuaHang.HoTen)}");
                    cmd.Parameters.AddWithValue("@Id", nguoiMuaHang.Id);
                    cmd.Parameters.AddWithValue("@TenDonVi", $"{nguoiMuaHang.TenDonVi}");
                    cmd.Parameters.AddWithValue("@DiaChi", $"{nguoiMuaHang.DiaChi}");
                    cmd.Parameters.AddWithValue("@SoTaiKhoan", $"{nguoiMuaHang.SoTaiKhoan}");
                    cmd.Parameters.AddWithValue("@HinhThucThanhToan", $"{nguoiMuaHang.HinhThucThanhToan}");
                    cmd.Parameters.AddWithValue("@MaSoThue", $"{nguoiMuaHang.MaSoThue}");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;

        }

        public NguoiMuaHang TimThongTinNguoiMuaTheoMa(int nguoiMuaHangId = 0, string stk = null)
        {
            if (KiemTraTonTaiNguoiMuaHang(nguoiMuaHangId, null, stk))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    DataTable dt = LayDSNguoiMuaHang(nguoiMuaHangId, null, null, stk);
                    NguoiMuaHang nguoiMuaHang = new NguoiMuaHang();
                    nguoiMuaHang.Id = int.Parse(dt.Rows[0]["Id"].ToString());
                    nguoiMuaHang.HoTen = dt.Rows[0]["HoTen"].ToString();
                    nguoiMuaHang.TenDonVi = dt.Rows[0]["TenDonVi"].ToString();
                    nguoiMuaHang.SoTaiKhoan = dt.Rows[0]["SoTaiKhoan"].ToString();
                    nguoiMuaHang.HinhThucThanhToan = dt.Rows[0]["HinhThucThanhToan"].ToString();
                    nguoiMuaHang.MaSoThue = dt.Rows[0]["MaSoThue"].ToString();
                    conn.Close();
                    return nguoiMuaHang;
                }
            }
            return null;
        }

        public bool XoaNguoiMuaHang(int nguoiMuaHangId)
        {
            if (KiemTraTonTaiNguoiMuaHang(nguoiMuaHangId))
            {
                DataTable dt = hoaDonServices.LayDSHoaDon(0, null, nguoiMuaHangId);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int maHoaDon = int.Parse(dt.Rows[i]["MaHoaDon"].ToString());
                        hoaDonServices.XoaHoaDon(maHoaDon);
                    }
                }
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string sql = "delete NguoiMuaHang where Id = @Id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", nguoiMuaHangId);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;
        }
    }
}
