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

namespace QLBanHang.View.HoaDonBusiness
{
    public partial class FrmNhapHoaDon : Form
    {
        private readonly IChiTietHoaDonServices chiTietHoaDonServices = new ChiTietHoaDonServices();
        private readonly IMatHangServices matHangServices = new MatHangServices();
        private readonly INguoiMuaHangServices nguoiMuaHangServices = new NguoiMuaHangServices();
        private readonly IHoaDonServices hoaDonServices = new HoaDonServices();
        private HoaDon hoaDon = null;
        private NguoiMuaHang nguoiMuaHang = null;
        public FrmNhapHoaDon()
        {
            InitializeComponent();
            btnKiemTraHoaDon.Show();
            btnCapNhatHoaDon.Hide();
        }

        public FrmNhapHoaDon(HoaDon hoaDon)
        {
            InitializeComponent();
            this.hoaDon = hoaDon;
            btnKiemTraHoaDon.Hide();
            btnCapNhatHoaDon.Show();
            btnLamLai.Hide();
            txtMaHoaDon.ReadOnly = true;
            nguoiMuaHang = nguoiMuaHangServices.TimThongTinNguoiMuaTheoMa(hoaDon.NguoiMuaHangId);

        }

        private void EnableItem(bool isEnable = false)
        {
            grMatHang.Enabled = isEnable;
            gridMatHang.Enabled = isEnable;
            btnNhapHang.Enabled = isEnable;
            grHoaDon.Enabled = !isEnable;
            btnLamLai.Enabled = isEnable;
        }

        private void ClearData()
        {
            txtMaHoaDon.Clear();
            dtpNgayLap.Value = DateTime.Now;
            lblTongTien.Text = "NULL";
            lblTongTienBangChu.Text = "NULL";
            txtMaKhachHang.Clear();
            txtHoTen.Clear();
            txtSTK.Clear();
        }

        private void HienThiDS()
        {
            if (hoaDon != null)
            {
                txtMaHoaDon.Text = hoaDon.HoaDonId.ToString();
                dtpNgayLap.Value = hoaDon.NgayLapHoaDon;
                lblTongTien.Text = ((int)hoaDon.TongTienThanhToan).ToString();
                lblTongTienBangChu.Text = hoaDon.TongTienBangChu.ToString();
                gridChiTiet.DataSource = chiTietHoaDonServices.LayDSChiTietHoaDon(0, int.Parse(txtMaHoaDon.Text));
                if (nguoiMuaHang != null)
                {
                    txtMaKhachHang.Text = nguoiMuaHang.Id.ToString();
                    txtHoTen.Text = nguoiMuaHang.HoTen;
                    txtSTK.Text = nguoiMuaHang.SoTaiKhoan;
                }
            }
            else
            {
                hoaDon = new HoaDon();
            }
            gridMatHang.DataSource = matHangServices.LayDSMatHang();
        }

        private void TaoBang()
        {
            gridChiTiet.Columns.Add("ChiTietHoaDonId", "ID");
            gridChiTiet.Columns["ChiTietHoaDonId"].DataPropertyName = "ChiTietHoaDonId";
            gridChiTiet.Columns.Add("TenMatHang", "Tên mặt hàng");
            gridChiTiet.Columns["TenMatHang"].DataPropertyName = "TenMatHang";
            gridChiTiet.Columns.Add("SoLuong", "Số lượng");
            gridChiTiet.Columns["SoLuong"].DataPropertyName = "SoLuong";
            gridChiTiet.Columns.Add("ThanhTien", "Thành tiền");
            gridChiTiet.Columns["ThanhTien"].DataPropertyName = "ThanhTien";
            gridChiTiet.Columns.Add("MaHoaDon", "Mã hoá đơn");
            gridChiTiet.Columns["MaHoaDon"].DataPropertyName = "MaHoaDon";
            gridChiTiet.Columns.Add("MaHang", "Mã hàng");
            gridChiTiet.Columns["MaHang"].DataPropertyName = "MaHang";
            gridChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
        private void FrmNhapHoaDon_Load(object sender, EventArgs e)
        {
            if (hoaDon == null)
            {
                EnableItem(false);
            }

            TaoBang();
            HienThiDS();
        }

        private void gridMatHang_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtTenMatHang.Text = gridMatHang.CurrentRow.Cells["TenMatHang"].Value.ToString(); ;
            txtDonViTinh.Text = gridMatHang.CurrentRow.Cells["DonViTinh"].Value.ToString();
            txtDonGiaBan.Text = gridMatHang.CurrentRow.Cells["DonGiaBan"].Value.ToString();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
            chiTietHoaDon.HoaDonId = int.Parse(txtMaHoaDon.Text);
            chiTietHoaDon.MaHang = int.Parse(gridMatHang.CurrentRow.Cells["MaMatHang"].Value.ToString());
            chiTietHoaDon.SoLuong = (int)txtSoLuong.Value;
            chiTietHoaDon.ThanhTien = chiTietHoaDon.SoLuong * int.Parse(txtDonGiaBan.Text);
            bool ok = chiTietHoaDonServices.ThemChiTietHoaDon(chiTietHoaDon);
            if (ok)
            {
                MessageBox.Show("Thêm thành công!", "Thông báo!");
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo!");
                return;
            }
            DataTable dt = chiTietHoaDonServices.LayDSChiTietHoaDon(0, hoaDon.HoaDonId);
            int tong = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tong += int.Parse(dt.Rows[i]["ThanhTien"].ToString());
                }
            }
            hoaDon.TongTienHang = tong;
            hoaDonServices.SuaHoaDon(hoaDon);
            HienThiDS();
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            EnableItem(false);
            hoaDon = null;
            nguoiMuaHang = null;
            ClearData();
        }

        private void btnKiemTraHoaDon_Click(object sender, EventArgs e)
        {
            hoaDon = hoaDonServices.LayThongTinHoaDonTheoMa(int.Parse(txtMaHoaDon.Text));

            if (hoaDon == null)
            {
                hoaDon = new HoaDon();
                hoaDon.HoaDonId = int.Parse(txtMaHoaDon.Text);
                hoaDon.NgayLapHoaDon = dtpNgayLap.Value;
                hoaDon.TongTienHang = 0;
                hoaDon.NguoiMuaHangId = int.Parse(txtMaKhachHang.Text);
                bool ok = hoaDonServices.ThemHoaDon(hoaDon);
                if (ok)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo!");
                    HienThiDS();
                    EnableItem(true);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo!");
                }
            }
            else
            {
                MessageBox.Show("Hoá đơn đã tồn tại!", "Thông báo!");
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaKhachHang.Text) || !string.IsNullOrEmpty(txtSTK.Text))
            {
                nguoiMuaHang = !string.IsNullOrEmpty(txtMaKhachHang.Text) ? nguoiMuaHangServices.TimThongTinNguoiMuaTheoMa(int.Parse(txtMaKhachHang.Text)) : nguoiMuaHangServices.TimThongTinNguoiMuaTheoMa(0, txtSTK.Text);
                if (nguoiMuaHang == null)
                {
                    DialogResult ret = MessageBox.Show("Khách hàng không tồn tại! Bạn có muốn thêm khách hàng không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ret == DialogResult.Yes)
                    {
                        FrmCapNhatThongTin frmCapNhatThongTin = new FrmCapNhatThongTin();
                        frmCapNhatThongTin.ShowDialog();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                txtMaKhachHang.Text = nguoiMuaHang.Id.ToString();
                txtSTK.Text = nguoiMuaHang.SoTaiKhoan.ToString();
                txtHoTen.Text = nguoiMuaHang.HoTen.ToString();
            }
        }

        private void btnCapNhatHoaDon_Click(object sender, EventArgs e)
        {
            if (hoaDon != null)
            {
                hoaDon.NgayLapHoaDon = dtpNgayLap.Value;
                hoaDon.TongTienHang = 0;
                hoaDon.NguoiMuaHangId = int.Parse(txtMaKhachHang.Text);
                bool ok = hoaDonServices.SuaHoaDon(hoaDon);
                if (ok)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo!");
                    HienThiDS();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo!");
                }
            }
        }
    }
}
