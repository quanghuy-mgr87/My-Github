namespace QLBanHang.View.HoaDonBusiness
{
    partial class FrmNhapHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnKiemTraHoaDon = new System.Windows.Forms.Button();
            this.btnNhapHang = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLamLai = new System.Windows.Forms.Button();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grHoaDon = new System.Windows.Forms.GroupBox();
            this.btnCapNhatHoaDon = new System.Windows.Forms.Button();
            this.txtSTK = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTongTienBangChu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridChiTiet = new System.Windows.Forms.DataGridView();
            this.grMatHang = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.gridMatHang = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDonGiaBan = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.txtTenMatHang = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.grHoaDon.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridChiTiet)).BeginInit();
            this.grMatHang.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMatHang)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKiemTraHoaDon
            // 
            this.btnKiemTraHoaDon.Location = new System.Drawing.Point(409, 203);
            this.btnKiemTraHoaDon.Name = "btnKiemTraHoaDon";
            this.btnKiemTraHoaDon.Size = new System.Drawing.Size(103, 23);
            this.btnKiemTraHoaDon.TabIndex = 1;
            this.btnKiemTraHoaDon.Text = "Kiểm tra hoá đơn";
            this.btnKiemTraHoaDon.UseVisualStyleBackColor = true;
            this.btnKiemTraHoaDon.Click += new System.EventHandler(this.btnKiemTraHoaDon_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.Location = new System.Drawing.Point(422, 12);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(90, 23);
            this.btnNhapHang.TabIndex = 0;
            this.btnNhapHang.Text = "Nhập hàng";
            this.btnNhapHang.UseVisualStyleBackColor = true;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.btnLamLai);
            this.groupBox3.Controls.Add(this.btnNhapHang);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 567);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(524, 41);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // btnLamLai
            // 
            this.btnLamLai.Location = new System.Drawing.Point(326, 12);
            this.btnLamLai.Name = "btnLamLai";
            this.btnLamLai.Size = new System.Drawing.Size(90, 23);
            this.btnLamLai.TabIndex = 1;
            this.btnLamLai.Text = "Làm lại";
            this.btnLamLai.UseVisualStyleBackColor = true;
            this.btnLamLai.Click += new System.EventHandler(this.btnLamLai_Click);
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Location = new System.Drawing.Point(109, 21);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(130, 20);
            this.txtMaHoaDon.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Mã hoá đơn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Ngày lập:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, -36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mã KH:";
            // 
            // grHoaDon
            // 
            this.grHoaDon.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grHoaDon.Controls.Add(this.btnCapNhatHoaDon);
            this.grHoaDon.Controls.Add(this.btnSearch);
            this.grHoaDon.Controls.Add(this.txtSTK);
            this.grHoaDon.Controls.Add(this.txtHoTen);
            this.grHoaDon.Controls.Add(this.label7);
            this.grHoaDon.Controls.Add(this.label10);
            this.grHoaDon.Controls.Add(this.txtMaKhachHang);
            this.grHoaDon.Controls.Add(this.label2);
            this.grHoaDon.Controls.Add(this.lblTongTienBangChu);
            this.grHoaDon.Controls.Add(this.label6);
            this.grHoaDon.Controls.Add(this.btnKiemTraHoaDon);
            this.grHoaDon.Controls.Add(this.lblTongTien);
            this.grHoaDon.Controls.Add(this.label4);
            this.grHoaDon.Controls.Add(this.dtpNgayLap);
            this.grHoaDon.Controls.Add(this.txtMaHoaDon);
            this.grHoaDon.Controls.Add(this.label8);
            this.grHoaDon.Controls.Add(this.label3);
            this.grHoaDon.Controls.Add(this.label1);
            this.grHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.grHoaDon.Location = new System.Drawing.Point(0, 0);
            this.grHoaDon.Name = "grHoaDon";
            this.grHoaDon.Size = new System.Drawing.Size(524, 232);
            this.grHoaDon.TabIndex = 4;
            this.grHoaDon.TabStop = false;
            this.grHoaDon.Text = "Thông tin hoá đơn";
            // 
            // btnCapNhatHoaDon
            // 
            this.btnCapNhatHoaDon.Location = new System.Drawing.Point(409, 203);
            this.btnCapNhatHoaDon.Name = "btnCapNhatHoaDon";
            this.btnCapNhatHoaDon.Size = new System.Drawing.Size(103, 23);
            this.btnCapNhatHoaDon.TabIndex = 46;
            this.btnCapNhatHoaDon.Text = "Cập nhật hoá đơn";
            this.btnCapNhatHoaDon.UseVisualStyleBackColor = true;
            this.btnCapNhatHoaDon.Click += new System.EventHandler(this.btnCapNhatHoaDon_Click);
            // 
            // txtSTK
            // 
            this.txtSTK.Location = new System.Drawing.Point(364, 125);
            this.txtSTK.Name = "txtSTK";
            this.txtSTK.Size = new System.Drawing.Size(100, 20);
            this.txtSTK.TabIndex = 44;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(109, 163);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(385, 20);
            this.txtHoTen.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(284, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Số tài khoản:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Họ tên:";
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Location = new System.Drawing.Point(109, 125);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(130, 20);
            this.txtMaKhachHang.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Mã khách hàng:";
            // 
            // lblTongTienBangChu
            // 
            this.lblTongTienBangChu.AutoSize = true;
            this.lblTongTienBangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienBangChu.Location = new System.Drawing.Point(130, 91);
            this.lblTongTienBangChu.Name = "lblTongTienBangChu";
            this.lblTongTienBangChu.Size = new System.Drawing.Size(39, 13);
            this.lblTongTienBangChu.TabIndex = 38;
            this.lblTongTienBangChu.Text = "NULL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Tổng tiền bằng chữ:";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(106, 59);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(39, 13);
            this.lblTongTien.TabIndex = 36;
            this.lblTongTien.Text = "NULL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Tổng tiền:";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.CustomFormat = " dd / MM / yyyy";
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLap.Location = new System.Drawing.Point(364, 21);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(130, 20);
            this.dtpNgayLap.TabIndex = 34;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.gridChiTiet);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 608);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 222);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết hoá đơn";
            // 
            // gridChiTiet
            // 
            this.gridChiTiet.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridChiTiet.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.gridChiTiet.Location = new System.Drawing.Point(3, 16);
            this.gridChiTiet.Name = "gridChiTiet";
            this.gridChiTiet.Size = new System.Drawing.Size(518, 203);
            this.gridChiTiet.TabIndex = 0;
            // 
            // grMatHang
            // 
            this.grMatHang.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grMatHang.Controls.Add(this.groupBox5);
            this.grMatHang.Controls.Add(this.groupBox4);
            this.grMatHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.grMatHang.Location = new System.Drawing.Point(0, 232);
            this.grMatHang.Name = "grMatHang";
            this.grMatHang.Size = new System.Drawing.Size(524, 335);
            this.grMatHang.TabIndex = 5;
            this.grMatHang.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox5.Controls.Add(this.gridMatHang);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 122);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(518, 210);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Danh sách mặt hàng";
            // 
            // gridMatHang
            // 
            this.gridMatHang.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMatHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMatHang.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.gridMatHang.Location = new System.Drawing.Point(3, 16);
            this.gridMatHang.Name = "gridMatHang";
            this.gridMatHang.Size = new System.Drawing.Size(512, 191);
            this.gridMatHang.TabIndex = 0;
            this.gridMatHang.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMatHang_CellEnter);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox4.Controls.Add(this.txtSoLuong);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtDonGiaBan);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtDonViTinh);
            this.groupBox4.Controls.Add(this.txtTenMatHang);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(518, 106);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin mặt hàng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(106, 70);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(130, 20);
            this.txtSoLuong.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Số lượng:";
            // 
            // txtDonGiaBan
            // 
            this.txtDonGiaBan.Location = new System.Drawing.Point(361, 43);
            this.txtDonGiaBan.Name = "txtDonGiaBan";
            this.txtDonGiaBan.Size = new System.Drawing.Size(130, 20);
            this.txtDonGiaBan.TabIndex = 51;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(281, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = "Đơn giá bán:";
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(106, 43);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(130, 20);
            this.txtDonViTinh.TabIndex = 48;
            // 
            // txtTenMatHang
            // 
            this.txtTenMatHang.Location = new System.Drawing.Point(106, 17);
            this.txtTenMatHang.Name = "txtTenMatHang";
            this.txtTenMatHang.Size = new System.Drawing.Size(385, 20);
            this.txtTenMatHang.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Đơn vị tính:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "Tên mặt hàng:";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::QLBanHang.Properties.Resources.Search_icon1;
            this.btnSearch.Location = new System.Drawing.Point(471, 124);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 23);
            this.btnSearch.TabIndex = 45;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmNhapHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 830);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grMatHang);
            this.Controls.Add(this.grHoaDon);
            this.MaximizeBox = false;
            this.Name = "FrmNhapHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập hoá đơn";
            this.Load += new System.EventHandler(this.FrmNhapHoaDon_Load);
            this.groupBox3.ResumeLayout(false);
            this.grHoaDon.ResumeLayout(false);
            this.grHoaDon.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridChiTiet)).EndInit();
            this.grMatHang.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMatHang)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnKiemTraHoaDon;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grHoaDon;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridChiTiet;
        private System.Windows.Forms.GroupBox grMatHang;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDonGiaBan;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.TextBox txtTenMatHang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown txtSoLuong;
        private System.Windows.Forms.DataGridView gridMatHang;
        private System.Windows.Forms.Label lblTongTienBangChu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLamLai;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSTK;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCapNhatHoaDon;
    }
}