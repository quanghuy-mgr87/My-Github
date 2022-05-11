namespace DoAn
{
    partial class frmUser
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDatQTV = new System.Windows.Forms.Button();
            this.btnXoaQTV = new System.Windows.Forms.Button();
            this.btnResetPass = new System.Windows.Forms.Button();
            this.btnXoaTK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridUserList = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản trị người dùng";
            // 
            // btnDatQTV
            // 
            this.btnDatQTV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDatQTV.Location = new System.Drawing.Point(170, 12);
            this.btnDatQTV.Name = "btnDatQTV";
            this.btnDatQTV.Size = new System.Drawing.Size(177, 34);
            this.btnDatQTV.TabIndex = 1;
            this.btnDatQTV.Text = "Đặt làm quản trị viên";
            this.btnDatQTV.UseVisualStyleBackColor = true;
            this.btnDatQTV.Click += new System.EventHandler(this.btnDatQTV_Click);
            // 
            // btnXoaQTV
            // 
            this.btnXoaQTV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaQTV.Location = new System.Drawing.Point(353, 12);
            this.btnXoaQTV.Name = "btnXoaQTV";
            this.btnXoaQTV.Size = new System.Drawing.Size(140, 34);
            this.btnXoaQTV.TabIndex = 2;
            this.btnXoaQTV.Text = "Xoá quản trị viên";
            this.btnXoaQTV.UseVisualStyleBackColor = true;
            this.btnXoaQTV.Click += new System.EventHandler(this.btnXoaQTV_Click);
            // 
            // btnResetPass
            // 
            this.btnResetPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetPass.Location = new System.Drawing.Point(499, 12);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(140, 34);
            this.btnResetPass.TabIndex = 3;
            this.btnResetPass.Text = "Đặt lại mật khẩu";
            this.btnResetPass.UseVisualStyleBackColor = true;
            this.btnResetPass.Click += new System.EventHandler(this.btnResetPass_Click);
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaTK.Location = new System.Drawing.Point(645, 12);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(140, 34);
            this.btnXoaTK.TabIndex = 4;
            this.btnXoaTK.Text = "Xoá tài khoản";
            this.btnXoaTK.UseVisualStyleBackColor = true;
            this.btnXoaTK.Click += new System.EventHandler(this.btnXoaTK_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridUserList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 428);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXoaTK);
            this.panel2.Controls.Add(this.btnDatQTV);
            this.panel2.Controls.Add(this.btnXoaQTV);
            this.panel2.Controls.Add(this.btnResetPass);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 392);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 55);
            this.panel2.TabIndex = 6;
            // 
            // gridUserList
            // 
            this.gridUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUserList.Location = new System.Drawing.Point(0, 0);
            this.gridUserList.Name = "gridUserList";
            this.gridUserList.Size = new System.Drawing.Size(794, 428);
            this.gridUserList.TabIndex = 0;
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmUser";
            this.Text = "DANH SÁCH NGƯỜI DÙNG";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUserList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXoaQTV;
        private System.Windows.Forms.Button btnDatQTV;
        private System.Windows.Forms.Button btnResetPass;
        private System.Windows.Forms.Button btnXoaTK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridUserList;
    }
}