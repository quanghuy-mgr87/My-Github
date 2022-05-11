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

namespace QLBanHang.View.HangHoaBusiness
{
    public partial class FrmNhapHang : Form
    {
        private DonViBanHang donViBanHang = null;
        private MatHang matHangUpdate = null;
        private readonly IMatHangServices matHangServices = new MatHangServices();
        private readonly IDonViBanHangServices donViBanHangServices = new DonViBanHangServices();
        public FrmNhapHang()
        {
            InitializeComponent();
        }

        public FrmNhapHang(DonViBanHang donViBanHang)
        {
            InitializeComponent();
            this.donViBanHang = donViBanHang;
        }

        public FrmNhapHang(DonViBanHang donViBanHang, MatHang matHangUpdate)
        {
            InitializeComponent();
            this.donViBanHang = donViBanHang;
            this.matHangUpdate = matHangUpdate;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HienThiDS()
        {
            if (donViBanHang != null)
            {
                gridMatHang.DataSource = matHangServices.LayDSMatHang(0, null, donViBanHang.Id);
            }
        }

        private void TaoBang()
        {
            DataGridViewColumn column = new DataGridViewColumn();
            gridMatHang.Columns.Add("MaMatHang", "Mã mặt hàng");
            gridMatHang.Columns["MaMatHang"].DataPropertyName = "MaMatHang";
            gridMatHang.Columns.Add("TenMatHang", "Tên mặt hàng");
            gridMatHang.Columns["TenMatHang"].DataPropertyName = "TenMatHang";
            gridMatHang.Columns.Add("HangSanXuat", "Hãng sản xuất");
            gridMatHang.Columns["HangSanXuat"].DataPropertyName = "HangSanXuat";
            gridMatHang.Columns.Add("DonViTinh", "Đơn vị tính");
            gridMatHang.Columns["DonViTinh"].DataPropertyName = "DonViTinh";
            gridMatHang.Columns.Add("DonGiaNhap", "Đơn giá nhập");
            gridMatHang.Columns["DonGiaNhap"].DataPropertyName = "DonGiaNhap";
            gridMatHang.Columns.Add("DonGiaBan", "Đơn giá bán");
            gridMatHang.Columns["DonGiaBan"].DataPropertyName = "DonGiaBan";
            gridMatHang.Columns.Add("DonViBanId", "Mã đơn vị bán");
            gridMatHang.Columns["DonViBanId"].DataPropertyName = "DonViBanId";
            gridMatHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void UpData()
        {
            if (matHangUpdate != null)
            {
                txtTenMatHang.Text = matHangUpdate.TenMatHang;
                txtHangSX.Text = matHangUpdate.HangSanXuat;
                txtDonViTinh.Text = matHangUpdate.DonViTinh;
                txtDonGiaNhap.Text = matHangUpdate.DonGiaNhap.ToString();
                txtDonGiaBan.Text = matHangUpdate.DonGiaBan.ToString();

            }
            if (donViBanHang != null)
            {
                txtMaDonVi.Text = donViBanHang.Id.ToString();
                txtTenDonVi.Text = donViBanHang.TenDonVi;
                txtDiaChi.Text = donViBanHang.DiaChi;
                txtSTK.Text = donViBanHang.SoTaiKhoan;
                txtSDT.Text = donViBanHang.SoDienThoai;
                txtMaSoThue.Text = donViBanHang.MaSoThue;
            }
        }

        private void ClearData()
        {
            txtTenMatHang.Clear();
            txtHangSX.Clear();
            txtDonGiaBan.Clear();
            txtDonGiaNhap.Clear();
            txtDonViTinh.Clear();
        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            if (matHangUpdate != null)
            {
                grDonViBan.Enabled = false;
                this.Text = "Cập nhật thông tin mặt hàng";
                btnNhapHang.Text = "Cập nhật";
            }
            UpData();
            TaoBang();
            HienThiDS();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if (donViBanHang == null)
            {
                donViBanHang = new DonViBanHang();
                donViBanHang.Id = int.Parse(txtMaDonVi.Text);
                donViBanHang.TenDonVi = txtTenDonVi.Text;
                donViBanHang.MaSoThue = txtMaSoThue.Text;
                donViBanHang.SoDienThoai = txtSDT.Text;
                donViBanHang.DiaChi = txtDiaChi.Text;
                donViBanHang.SoTaiKhoan = txtSTK.Text;
                ok = donViBanHangServices.ThemDonViBanHang(donViBanHang);
            }
            MatHang matHang = new MatHang();
            matHang.TenMatHang = txtTenMatHang.Text;
            matHang.HangSanXuat = txtHangSX.Text;
            matHang.DonViTinh = txtDonViTinh.Text;
            matHang.DonGiaNhap = int.Parse(txtDonGiaNhap.Text);
            matHang.DonGiaBan = int.Parse(txtDonGiaBan.Text);
            matHang.DonViBanId = donViBanHang.Id;
            if (matHangUpdate == null)
            {
                ok = ok && matHangServices.ThemMatHang(matHang);
            }
            else
            {
                matHang.MaMatHang = int.Parse(gridMatHang.CurrentRow.Cells["MaMatHang"].Value.ToString());
                ok = ok && matHangServices.SuaMatHang(matHang);
            }
            if (ok)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo!");
                ClearData();
                HienThiDS();
            }
            else
            {
                MessageBox.Show("Thao tác thất bại!", "Thông báo!");
            }
        }

        private void txtMaDonVi_Leave(object sender, EventArgs e)
        {
            donViBanHang = donViBanHangServices.TimDonViTheoMa(int.Parse(txtMaDonVi.Text));
            UpData();
            HienThiDS();
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            donViBanHang = donViBanHangServices.TimDonViTheoMa(0, txtSDT.Text);
            UpData();
            HienThiDS();
        }

        private void gridMatHang_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (matHangUpdate == null)
                return;
            txtTenMatHang.Text = gridMatHang.CurrentRow.Cells["TenMatHang"].Value.ToString();
            txtHangSX.Text = gridMatHang.CurrentRow.Cells["HangSanXuat"].Value.ToString();
            txtDonViTinh.Text = gridMatHang.CurrentRow.Cells["DonViTinh"].Value.ToString();
            txtDonGiaNhap.Text = gridMatHang.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtDonGiaBan.Text = gridMatHang.CurrentRow.Cells["DonGiaBan"].Value.ToString();
        }
    }
}
