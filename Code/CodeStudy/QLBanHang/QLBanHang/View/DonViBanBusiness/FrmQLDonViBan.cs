using QLBanHang.Interface;
using QLBanHang.Model;
using QLBanHang.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang.View.DonViBanBusiness
{
    public partial class FrmQLDonViBan : Form
    {
        private readonly IDonViBanHangServices donViBanHangServices = new DonViBanHangServices();
        public FrmQLDonViBan()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HienThiDS()
        {
            gridDonViBan.DataSource = donViBanHangServices.LayDSDonViBanHang();
        }

        private void TaoBang()
        {
            DataGridViewColumn column = new DataGridViewColumn();
            gridDonViBan.Columns.Add("Id", "Mã đơn vị");
            gridDonViBan.Columns["ID"].DataPropertyName = "Id";
            gridDonViBan.Columns.Add("TenDonVi", "Tên đơn vị");
            gridDonViBan.Columns["TenDonVi"].DataPropertyName = "TenDonVi";
            gridDonViBan.Columns.Add("DiaChi", "Địa chỉ");
            gridDonViBan.Columns["DiaChi"].DataPropertyName = "DiaChi";
            gridDonViBan.Columns.Add("SoTaiKhoan", "Số tài khoản");
            gridDonViBan.Columns["SoTaiKhoan"].DataPropertyName = "SoTaiKhoan";
            gridDonViBan.Columns.Add("SoDienThoai", "Số điện thoại");
            gridDonViBan.Columns["SoDienThoai"].DataPropertyName = "SoDienThoai";
            gridDonViBan.Columns.Add("MaSoThue", "Mã số thuế");
            gridDonViBan.Columns["MaSoThue"].DataPropertyName = "MaSoThue";
            gridDonViBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FrmQLDonViBan_Load(object sender, EventArgs e)
        {
            TaoBang();
            HienThiDS();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int donViBanId = int.Parse(gridDonViBan.CurrentRow.Cells["Id"].Value.ToString());
            DialogResult ret = MessageBox.Show($"Bạn có muốn xoá đơn vị bán {donViBanId} không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                bool isDelete = donViBanHangServices.XoaDonViBanHang(donViBanId);
                if (!isDelete)
                {
                    MessageBox.Show("Xảy ra lỗi khi xoá, xin mời thử lại!", "Thông báo!");
                }
                HienThiDS();
            }
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            DonViBanHang donViBanHang = new DonViBanHang();
            donViBanHang.Id = int.Parse(gridDonViBan.CurrentRow.Cells["Id"].Value.ToString());
            donViBanHang.MaSoThue = gridDonViBan.CurrentRow.Cells["MaSoThue"].Value.ToString();
            donViBanHang.TenDonVi = gridDonViBan.CurrentRow.Cells["TenDonVi"].Value.ToString();
            donViBanHang.DiaChi = gridDonViBan.CurrentRow.Cells["DiaChi"].Value.ToString();
            donViBanHang.SoDienThoai = gridDonViBan.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            donViBanHang.SoTaiKhoan = gridDonViBan.CurrentRow.Cells["SoTaiKhoan"].Value.ToString();
            FrmCapNhatDonViBan frmCapNhatDonViBan = new FrmCapNhatDonViBan(donViBanHang);
            frmCapNhatDonViBan.ShowDialog();
            HienThiDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmCapNhatDonViBan frmCapNhatDonViBan = new FrmCapNhatDonViBan();
            frmCapNhatDonViBan.ShowDialog();
            HienThiDS();
        }
    }
}
