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
    internal class MatHangServices : IMatHangServices
    {
        private bool KiemTraTonTai(int maMatHang)
        {
            return LayDSMatHang(maMatHang).Rows.Count > 0;
        }
        public DataTable LayDSMatHang(int maMatHang = 0, string tenMatHang = null, int maDonVi = 0)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
            {
                conn.Open();
                string sql = "select * from MatHang where 1 = 1 ";
                if (maMatHang > 0)
                {
                    sql += "and MaMatHang = @MaMatHang ";
                }
                if (!string.IsNullOrEmpty(tenMatHang))
                {
                    sql += "and TenMatHang like @TenMatHang";
                }
                if (maDonVi > 0)
                {
                    sql += "and DonViBanId = @DonViBanId";
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@MaMatHang", maMatHang);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@TenMatHang", $"%{tenMatHang}%");
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@DonViBanId", maDonVi);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                conn.Close();
                return dataTable;
            }
        }

        public bool SuaMatHang(MatHang matHang)
        {
            if (KiemTraTonTai(matHang.MaMatHang))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string sql = "update MatHang set TenMatHang = @TenMatHang, HangSanXuat = @HangSanXuat, DonViTinh = @DonViTinh, DonGiaNhap = @DonGiaNhap, DonGiaBan = @DonGiaBan, DonViBanId = @DonViBanId where MaMatHang = @MaMatHang";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TenMatHang", $"{matHang.TenMatHang}");
                    cmd.Parameters.AddWithValue("@HangSanXuat", $"{matHang.HangSanXuat}");
                    cmd.Parameters.AddWithValue("@DonViTinh", $"{matHang.DonViTinh}");
                    cmd.Parameters.AddWithValue("@DonGiaNhap", matHang.DonGiaNhap);
                    cmd.Parameters.AddWithValue("@DonGiaBan", matHang.DonGiaBan);
                    cmd.Parameters.AddWithValue("@DonViBanId", matHang.DonViBanId);
                    cmd.Parameters.AddWithValue("@MaMatHang", matHang.MaMatHang);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;
        }

        public bool ThemMatHang(MatHang matHang)
        {
            if (!KiemTraTonTai(matHang.MaMatHang) || matHang.MaMatHang == 0)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string sql = "insert into MatHang (TenMatHang, HangSanXuat, DonViTinh, DonGiaNhap, DonGiaBan, DonViBanId) values (@TenMatHang, @HangSanXuat, @DonViTinh, @DonGiaNhap, @DonGiaBan, @DonViBanId)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TenMatHang", $"{matHang.TenMatHang}");
                    cmd.Parameters.AddWithValue("@HangSanXuat", $"{matHang.HangSanXuat}");
                    cmd.Parameters.AddWithValue("@DonViTinh", $"{matHang.DonViTinh}");
                    cmd.Parameters.AddWithValue("@DonGiaNhap", matHang.DonGiaNhap);
                    cmd.Parameters.AddWithValue("@DonGiaBan", matHang.DonGiaBan);
                    cmd.Parameters.AddWithValue("@DonViBanId", matHang.DonViBanId);
                    cmd.Parameters.AddWithValue("@MaMatHang", matHang.MaMatHang);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;
        }

        public bool XoaMatHang(int matHangId)
        {
            if (KiemTraTonTai(matHangId))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string sql = "delete MatHang where MaMatHang = @MaMatHang";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaMatHang", matHangId);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;
        }

        public MatHang LayThongTinMatHangTheoMa(int maMatHang = 0)
        {
            if (KiemTraTonTai(maMatHang))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string sql = "select * from MatHang where 1 = 1 ";
                    if (maMatHang > 0)
                    {
                        sql += "and MaMatHang = @MaMatHang";
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@MaMatHang", maMatHang);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    conn.Close();
                    MatHang matHang = new MatHang();
                    matHang.MaMatHang = int.Parse(dataTable.Rows[0]["MaMatHang"].ToString());
                    matHang.TenMatHang = dataTable.Rows[0]["TenMatHang"].ToString();
                    matHang.HangSanXuat = dataTable.Rows[0]["HangSanXuat"].ToString();
                    matHang.DonViTinh = dataTable.Rows[0]["DonViTinh"].ToString();
                    matHang.DonGiaNhap = int.Parse(dataTable.Rows[0]["DonGiaNhap"].ToString());
                    matHang.DonGiaBan = int.Parse(dataTable.Rows[0]["DonGiaBan"].ToString());
                    matHang.DonViBanId = int.Parse(dataTable.Rows[0]["DonViBanId"].ToString());
                    return matHang;
                }
            }
            return null;
        }
    }
}
