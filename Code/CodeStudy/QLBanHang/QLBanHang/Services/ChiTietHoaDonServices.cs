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
    internal class ChiTietHoaDonServices : IChiTietHoaDonServices
    {
        public bool KiemTraChiTietTonTai(int maChiTiet = 0)
        {
            return LayDSChiTietHoaDon(0, 0, maChiTiet).Rows.Count > 0;
        }
        public DataTable LayDSChiTietHoaDon(int maHang = 0, int maHoaDon = 0, int maChiTiet = 0)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
            {
                conn.Open();
                string query = "select ChiTietHoaDon.ChiTietHoaDonId, ChiTietHoaDon.SoLuong, ChiTietHoaDon.ThanhTien, HoaDon.MaHoaDon, ChiTietHoaDon.MaHang, MatHang.TenMatHang from ChiTietHoaDon, HoaDon, MatHang where ChiTietHoaDon.HoaDonId = HoaDon.MaHoaDon and ChiTietHoaDon.MaHang = MatHang.MaMatHang ";
                if (maHang != 0)
                {
                    query += "and ChiTietHoaDon.MaHang = @MaHang ";
                }
                if (maHoaDon != 0)
                {
                    query += "and ChiTietHoaDon.HoaDonId = @HoaDonId ";
                }
                if (maChiTiet != 0)
                {
                    query += "and ChiTietHoaDon.ChiTietHoaDonId = @ChiTietHoaDonId ";
                }
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@MaHang", maHang);
                adapter.SelectCommand.Parameters.AddWithValue("@HoaDonId", maHoaDon);
                adapter.SelectCommand.Parameters.AddWithValue("@ChiTietHoaDonId", maChiTiet);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                conn.Close();
                return dataTable;
            }
        }

        public bool SuaChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            if (KiemTraChiTietTonTai(chiTietHoaDon.ChiTietHoaDonId))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string query = "update ChiTietHoaDon set SoLuong = @SoLuong, ThanhTien = @ThanhTien, HoaDonId = @HoaDonId, MaHang = @MaHang where ChiTietHoaDonId = @ChiTietHoaDonId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SoLuong", chiTietHoaDon.SoLuong);
                    cmd.Parameters.AddWithValue("@ThanhTien", chiTietHoaDon.ThanhTien);
                    cmd.Parameters.AddWithValue("@HoaDonId", chiTietHoaDon.HoaDonId);
                    cmd.Parameters.AddWithValue("@MaHang", chiTietHoaDon.MaHang);
                    cmd.Parameters.AddWithValue("@ChiTietHoaDonId", chiTietHoaDon.ChiTietHoaDonId);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;
        }

        public bool ThemChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            if (KiemTraChiTietTonTai(chiTietHoaDon.ChiTietHoaDonId) || chiTietHoaDon.ChiTietHoaDonId == 0)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string query = "insert into ChiTietHoaDon (SoLuong, ThanhTien, HoaDonId, MaHang) values (@SoLuong, @ThanhTien, @HoaDonId, @MaHang)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SoLuong", chiTietHoaDon.SoLuong);
                    cmd.Parameters.AddWithValue("@ThanhTien", chiTietHoaDon.ThanhTien);
                    cmd.Parameters.AddWithValue("@HoaDonId", chiTietHoaDon.HoaDonId);
                    cmd.Parameters.AddWithValue("@MaHang", chiTietHoaDon.MaHang);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;
        }

        public bool XoaChiTietHoaDon(int chiTietHoaDonId)
        {
            if (KiemTraChiTietTonTai(chiTietHoaDonId))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string query = "delete from ChiTietHoaDon where ChiTietHoaDonId = @chiTietHoaDonId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@chiTietHoaDonId", chiTietHoaDonId);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;
        }
    }
}
