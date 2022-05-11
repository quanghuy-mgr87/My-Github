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
    internal class HoaDonServices : IHoaDonServices
    {
        private readonly IChiTietHoaDonServices chiTietHoaDonServices = new ChiTietHoaDonServices();
        private bool KiemTraHoaDonTonTai(int maHoaDon)
        {
            return LayDSHoaDon(maHoaDon).Rows.Count > 0;
        }
        public DataTable LayDSHoaDon(int maHoaDon = 0, DateTime? ngayLapHoaDon = null, int nguoiMuaHangId = 0)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
            {
                conn.Open();
                string sql = "select * from HoaDon where 1 = 1 ";
                if (maHoaDon != 0)
                {
                    sql += "and MaHoaDon = @MaHoaDon ";
                }
                if (ngayLapHoaDon != null)
                {
                    sql += "and NgayLapHoaDon = @NgayLapHoaDon";
                }
                if (nguoiMuaHangId != 0)
                {
                    sql += "and NguoiMuaHangId = @NguoiMuaHangId";
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@NguoiMuaHangId", nguoiMuaHangId);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@NgayLapHoaDon", $"{ngayLapHoaDon}");
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public bool SuaHoaDon(HoaDon hoaDon)
        {
            if (KiemTraHoaDonTonTai(hoaDon.HoaDonId))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string sql = "update HoaDon set NgayLapHoaDon = @NgayLapHoaDon, ThueSuat = @ThueSuat, TongTienHang = @TongTienHang, ThueGTGT = @ThueGTGT, TongTienThanhToan = @TongTienThanhToan, NguoiMuaHangId = @NguoiMuaHangId where MaHoaDon = @MaHoaDon";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@NgayLapHoaDon", $"{hoaDon.NgayLapHoaDon}");
                    cmd.Parameters.AddWithValue("@ThueSuat", hoaDon.ThueSuat);
                    cmd.Parameters.AddWithValue("@TongTienHang", hoaDon.TongTienHang);
                    cmd.Parameters.AddWithValue("@ThueGTGT", hoaDon.ThueGTGT);
                    cmd.Parameters.AddWithValue("@TongTienThanhToan", hoaDon.TongTienThanhToan);
                    cmd.Parameters.AddWithValue("@NguoiMuaHangId", $"{hoaDon.NguoiMuaHangId}");
                    cmd.Parameters.AddWithValue("@MaHoaDon", $"{hoaDon.HoaDonId}");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;
        }

        public bool ThemHoaDon(HoaDon hoaDon)
        {
            if (!KiemTraHoaDonTonTai(hoaDon.HoaDonId))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string sql = "insert into HoaDon values (@MaHoaDon, @NgayLapHoaDon, @ThueSuat, @TongTienHang, @ThueGTGT, @TongTienThanhToan, @NguoiMuaHangId)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@NgayLapHoaDon", $"{hoaDon.NgayLapHoaDon}");
                    cmd.Parameters.AddWithValue("@ThueSuat", hoaDon.ThueSuat);
                    cmd.Parameters.AddWithValue("@MaHoaDon", hoaDon.HoaDonId);
                    cmd.Parameters.AddWithValue("@TongTienHang", hoaDon.TongTienHang);
                    cmd.Parameters.AddWithValue("@ThueGTGT", hoaDon.ThueGTGT);
                    cmd.Parameters.AddWithValue("@TongTienThanhToan", hoaDon.TongTienThanhToan);
                    cmd.Parameters.AddWithValue("@NguoiMuaHangId", $"{hoaDon.NguoiMuaHangId}");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;
        }

        public bool XoaHoaDon(int maHoaDon)
        {
            if (KiemTraHoaDonTonTai(maHoaDon))
            {
                DataTable dt = chiTietHoaDonServices.LayDSChiTietHoaDon(0, maHoaDon);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int maChiTiet = int.Parse(dt.Rows[i]["ChiTietHoaDonId"].ToString());
                        chiTietHoaDonServices.XoaChiTietHoaDon(maChiTiet);
                    }
                }
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string sql = "delete HoaDon where MaHoaDon = @MaHoaDon";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;
        }

        public HoaDon LayThongTinHoaDonTheoMa(int maHoaDon = 0)
        {
            if (KiemTraHoaDonTonTai(maHoaDon))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string sql = "select * from HoaDon where MaHoaDon = @MaHoaDon";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    HoaDon hoaDon = new HoaDon(int.Parse(dt.Rows[0]["MaHoaDon"].ToString()), DateTime.Parse(dt.Rows[0]["NgayLapHoaDon"].ToString()), int.Parse(dt.Rows[0]["TongTienHang"].ToString()), int.Parse(dt.Rows[0]["NguoiMuaHangId"].ToString()));
                    conn.Close();
                    return hoaDon;
                }
            }
            return null;
        }
    }
}
