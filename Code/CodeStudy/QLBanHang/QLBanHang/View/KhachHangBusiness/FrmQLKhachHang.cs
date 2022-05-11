using QLBanHang.Interface;
using QLBanHang.Model;
using QLBanHang.Services;
using QLBanHang.View.KhachHangBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang.View
{
    public partial class FrmQLKhachHang : Form
    {
        private readonly INguoiMuaHangServices nguoiMuaHangServices = new NguoiMuaHangServices();
        private readonly IHoaDonServices hoaDonServices = new HoaDonServices();
        public FrmQLKhachHang()
        {
            InitializeComponent();
        }

        private void HienThiDS()
        {
            gridKH.DataSource = nguoiMuaHangServices.LayDSNguoiMuaHang();
        }

        private void TaoBang()
        {
            DataGridViewColumn column = new DataGridViewColumn();
            gridKH.Columns.Add("Id", "Mã KH");
            gridKH.Columns["ID"].DataPropertyName = "Id";
            gridKH.Columns.Add("HoTen", "Họ tên");
            gridKH.Columns["HoTen"].DataPropertyName = "HoTen";
            gridKH.Columns.Add("TenDonVi", "Tên đơn vị");
            gridKH.Columns["TenDonVi"].DataPropertyName = "TenDonVi";
            gridKH.Columns.Add("DiaChi", "Địa chỉ");
            gridKH.Columns["DiaChi"].DataPropertyName = "DiaChi";
            gridKH.Columns.Add("SoTaiKhoan", "Số tài khoản");
            gridKH.Columns["SoTaiKhoan"].DataPropertyName = "SoTaiKhoan";
            gridKH.Columns.Add("HinhThucThanhToan", "Hình thức thanh toán");
            gridKH.Columns["HinhThucThanhToan"].DataPropertyName = "HinhThucThanhToan";
            gridKH.Columns.Add("MaSoThue", "Mã số thuế");
            gridKH.Columns["MaSoThue"].DataPropertyName = "MaSoThue";
            gridKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FrmQLKhachHang_Load(object sender, EventArgs e)
        {
            TaoBang();
            HienThiDS();
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            NguoiMuaHang nguoiMuaHang = new NguoiMuaHang();
            nguoiMuaHang.Id = int.Parse(gridKH.CurrentRow.Cells["Id"].Value.ToString());
            nguoiMuaHang.HoTen = gridKH.CurrentRow.Cells["HoTen"].Value.ToString();
            nguoiMuaHang.TenDonVi = gridKH.CurrentRow.Cells["TenDonVi"].Value.ToString();
            nguoiMuaHang.DiaChi = gridKH.CurrentRow.Cells["DiaChi"].Value.ToString();
            nguoiMuaHang.SoTaiKhoan = gridKH.CurrentRow.Cells["SoTaiKhoan"].Value.ToString();
            nguoiMuaHang.HinhThucThanhToan = gridKH.CurrentRow.Cells["HinhThucThanhToan"].Value.ToString();
            nguoiMuaHang.MaSoThue = gridKH.CurrentRow.Cells["MaSoThue"].Value.ToString();
            FrmCapNhatThongTin frmCapNhatThongTin = new FrmCapNhatThongTin(nguoiMuaHang);
            frmCapNhatThongTin.ShowDialog();
            HienThiDS();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int nguoiMuaHangId = int.Parse(gridKH.CurrentRow.Cells["Id"].Value.ToString());
            DialogResult ret = MessageBox.Show($"Bạn có muốn xoá khách hàng {nguoiMuaHangId} không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                bool isDelete = nguoiMuaHangServices.XoaNguoiMuaHang(nguoiMuaHangId);
                if (!isDelete)
                {
                    MessageBox.Show("Xảy ra lỗi khi xoá, xin mời thử lại!", "Thông báo!");
                }
                HienThiDS();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmCapNhatThongTin frmCapNhatThongTin = new FrmCapNhatThongTin();
            frmCapNhatThongTin.ShowDialog();
            HienThiDS();
        }
    }
}
