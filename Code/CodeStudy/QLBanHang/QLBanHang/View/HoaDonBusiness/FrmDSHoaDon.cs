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

namespace QLBanHang.View.HoaDonBusiness
{
    public partial class FrmDSHoaDon : Form
    {
        private readonly IHoaDonServices hoaDonServices = new HoaDonServices();
        private readonly IChiTietHoaDonServices chiTietHoaDonServices = new ChiTietHoaDonServices();
        public FrmDSHoaDon()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HienThiDS()
        {
            gridHoaDon.DataSource = hoaDonServices.LayDSHoaDon();
        }

        private void TaoBang()
        {
            gridHoaDon.Columns.Add("MaHoaDon", "Mã hoá đơn");
            gridHoaDon.Columns["MaHoaDon"].DataPropertyName = "MaHoaDon";
            gridHoaDon.Columns.Add("NgayLapHoaDon", "Ngày lập hoá đơn");
            gridHoaDon.Columns["NgayLapHoaDon"].DataPropertyName = "NgayLapHoaDon";
            gridHoaDon.Columns.Add("ThueSuat", "Thuế suất");
            gridHoaDon.Columns["ThueSuat"].DataPropertyName = "ThueSuat";
            gridHoaDon.Columns.Add("TongTienHang", "Tổng tiền hàng");
            gridHoaDon.Columns["TongTienHang"].DataPropertyName = "TongTienHang";
            gridHoaDon.Columns.Add("ThueGTGT", "Thuế giá trị gia tăng");
            gridHoaDon.Columns["ThueGTGT"].DataPropertyName = "ThueGTGT";
            gridHoaDon.Columns.Add("TongTienThanhToan", "Tổng tiền thanh toán");
            gridHoaDon.Columns["TongTienThanhToan"].DataPropertyName = "TongTienThanhToan";
            gridHoaDon.Columns.Add("TongTienBangChu", "Tổng tiền bằng chữ");
            gridHoaDon.Columns["TongTienBangChu"].DataPropertyName = "TongTienBangChu";
            gridHoaDon.Columns.Add("NguoiMuaHangId", "Mã người mua");
            gridHoaDon.Columns["NguoiMuaHangId"].DataPropertyName = "NguoiMuaHangId";
            gridHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void FrmDSHoaDon_Load(object sender, EventArgs e)
        {
            TaoBang();
            HienThiDS();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maHoaDon = int.Parse(gridHoaDon.CurrentRow.Cells["MaHoaDon"].Value.ToString());

            DialogResult ret = MessageBox.Show($"Bạn có chắc chắn muốn xoá hoá đơn {maHoaDon} không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                bool ok = hoaDonServices.XoaHoaDon(maHoaDon);
                if (ok)
                {
                    MessageBox.Show($"Đã xoá hoá đơn {maHoaDon}", "Thông báo!");
                    HienThiDS();
                }
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            int maHoaDon = int.Parse(gridHoaDon.CurrentRow.Cells["MaHoaDon"].Value.ToString());
            HoaDon hoaDon = hoaDonServices.LayThongTinHoaDonTheoMa(maHoaDon);
            FrmNhapHoaDon frmNhapHoaDon = new FrmNhapHoaDon(hoaDon);
            frmNhapHoaDon.ShowDialog();
            HienThiDS();
        }
    }
}
