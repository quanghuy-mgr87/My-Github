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
    internal class DonViBanHangServices : IDonViBanHangServices
    {
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataTable dataTable;

        public bool KiemTraTonTai(int id = 0, string tenDonVi = null, string sdt = null)
        {
            dataTable = LayDSDonViBanHang(id, tenDonVi, sdt);
            return dataTable.Rows.Count > 0;
        }

        public DataTable LayDSDonViBanHang(int maDonVi = 0, string tenDonVi = null, string sdt = null)
        {
            using (conn = new SqlConnection(ConnectionString.connectionString))
            {
                conn.Open();
                String sql = "select * from DonViBanHang where 1 = 1 ";
                if (maDonVi != 0)
                {
                    sql += "and Id = @MaDonVi ";
                }
                if (!String.IsNullOrEmpty(tenDonVi))
                {
                    sql += "and TenDonVi like @tenDonVi ";
                }
                if (!String.IsNullOrEmpty(sdt))
                {
                    sql += "and SoDienThoai = @sdt";
                }
                adapter = new SqlDataAdapter(sql, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@tenDonVi", $"%{tenDonVi}%");
                adapter.SelectCommand.Parameters.AddWithValue("@sdt", $"{sdt}");
                adapter.SelectCommand.Parameters.AddWithValue("@MaDonVi", maDonVi);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                conn.Close();
                return dataTable;
            }
        }

        public bool SuaDonViBanHang(DonViBanHang donViBanHang)
        {
            if (KiemTraTonTai(donViBanHang.Id, null, null))
            {
                using (conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string sql = "update DonViBanHang set MaSoThue = @MaSoThue, TenDonVi = @TenDonVi, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, SoTaiKhoan = @SoTaiKhoan where Id = @Id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaSoThue", $"{donViBanHang.MaSoThue}");
                    cmd.Parameters.AddWithValue("@TenDonVi", $"{donViBanHang.TenDonVi}");
                    cmd.Parameters.AddWithValue("@DiaChi", $"{donViBanHang.DiaChi}");
                    cmd.Parameters.AddWithValue("@Id", donViBanHang.Id);
                    cmd.Parameters.AddWithValue("@SoDienThoai", $"{donViBanHang.SoDienThoai}");
                    cmd.Parameters.AddWithValue("@SoTaiKhoan", $"{donViBanHang.SoTaiKhoan}");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;
        }

        public bool ThemDonViBanHang(DonViBanHang donViBanHang)
        {
            if (!KiemTraTonTai(0, donViBanHang.SoDienThoai, null))
            {
                using (conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    String sql = "insert into DonViBanHang values (@Id, @MaSoThue,@TenDonVi, @DiaChi, @SoDienThoai,@SoTaiKhoan)";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaSoThue", $"{donViBanHang.MaSoThue}");
                    cmd.Parameters.AddWithValue("@TenDonVi", $"{donViBanHang.TenDonVi}");
                    cmd.Parameters.AddWithValue("@DiaChi", $"{donViBanHang.DiaChi}");
                    cmd.Parameters.AddWithValue("@Id", donViBanHang.Id);
                    cmd.Parameters.AddWithValue("@SoDienThoai", $"{donViBanHang.SoDienThoai}");
                    cmd.Parameters.AddWithValue("@SoTaiKhoan", $"{donViBanHang.SoTaiKhoan}");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;
        }

        public DonViBanHang TimDonViTheoMa(int maDonVi = 0, string sdt = null)
        {
            if (KiemTraTonTai(maDonVi))
            {
                using (conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string sql = "select * from DonViBanHang where 1 = 1 ";
                    if (maDonVi > 0)
                    {
                        sql += "and Id = @Id ";
                    }
                    if (!string.IsNullOrEmpty(sdt))
                    {
                        sql += "and SoDienThoai like @SoDienThoai ";
                    }
                    adapter = new SqlDataAdapter(sql, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@Id", maDonVi);
                    adapter.SelectCommand.Parameters.AddWithValue("@SoDienThoai", $"{sdt}");
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    conn.Close();
                    DonViBanHang donViBanHang = new DonViBanHang();
                    donViBanHang.Id = int.Parse(dataTable.Rows[0]["ID"].ToString());
                    donViBanHang.TenDonVi = dataTable.Rows[0]["TenDonVi"].ToString();
                    donViBanHang.MaSoThue = dataTable.Rows[0]["MaSoThue"].ToString();
                    donViBanHang.DiaChi = dataTable.Rows[0]["DiaChi"].ToString();
                    donViBanHang.SoDienThoai = dataTable.Rows[0]["SoDienThoai"].ToString();
                    donViBanHang.SoTaiKhoan = dataTable.Rows[0]["SoTaiKhoan"].ToString();
                    return donViBanHang;
                }
            }
            return null;
        }

        public bool XoaDonViBanHang(int donViBangHangId)
        {
            if (KiemTraTonTai(donViBangHangId, null, null))
            {
                using (conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string sql = "delete DonViBanHang where Id = @Id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", donViBangHangId);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            return false;
        }
    }
}
