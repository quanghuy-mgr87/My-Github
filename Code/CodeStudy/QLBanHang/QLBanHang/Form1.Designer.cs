namespace QLBanHang
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchNgườiMuaHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchĐơnVịBánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHàngHoáToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDanhSáchHàngHoáToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHoáĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpHoáĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDanhSáchHoáĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.quảnLýHàngHoáToolStripMenuItem,
            this.quảnLýHoáĐơnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchNgườiMuaHàngToolStripMenuItem,
            this.danhSáchĐơnVịBánToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // danhSáchNgườiMuaHàngToolStripMenuItem
            // 
            this.danhSáchNgườiMuaHàngToolStripMenuItem.Image = global::QLBanHang.Properties.Resources.man_icon;
            this.danhSáchNgườiMuaHàngToolStripMenuItem.Name = "danhSáchNgườiMuaHàngToolStripMenuItem";
            this.danhSáchNgườiMuaHàngToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.danhSáchNgườiMuaHàngToolStripMenuItem.Text = "QL người mua hàng";
            this.danhSáchNgườiMuaHàngToolStripMenuItem.Click += new System.EventHandler(this.danhSáchNgườiMuaHàngToolStripMenuItem_Click);
            // 
            // danhSáchĐơnVịBánToolStripMenuItem
            // 
            this.danhSáchĐơnVịBánToolStripMenuItem.Image = global::QLBanHang.Properties.Resources.shop_icon;
            this.danhSáchĐơnVịBánToolStripMenuItem.Name = "danhSáchĐơnVịBánToolStripMenuItem";
            this.danhSáchĐơnVịBánToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.danhSáchĐơnVịBánToolStripMenuItem.Text = "QL đơn vị bán";
            this.danhSáchĐơnVịBánToolStripMenuItem.Click += new System.EventHandler(this.danhSáchĐơnVịBánToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Image = global::QLBanHang.Properties.Resources.Sign_Shutdown_icon;
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // quảnLýHàngHoáToolStripMenuItem
            // 
            this.quảnLýHàngHoáToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpHàngToolStripMenuItem,
            this.xemDanhSáchHàngHoáToolStripMenuItem});
            this.quảnLýHàngHoáToolStripMenuItem.Name = "quảnLýHàngHoáToolStripMenuItem";
            this.quảnLýHàngHoáToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.quảnLýHàngHoáToolStripMenuItem.Text = "Quản lý hàng hoá";
            // 
            // nhậpHàngToolStripMenuItem
            // 
            this.nhậpHàngToolStripMenuItem.Image = global::QLBanHang.Properties.Resources.Add_Folder_icon;
            this.nhậpHàngToolStripMenuItem.Name = "nhậpHàngToolStripMenuItem";
            this.nhậpHàngToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.nhậpHàngToolStripMenuItem.Text = "Nhập hàng";
            this.nhậpHàngToolStripMenuItem.Click += new System.EventHandler(this.nhậpHàngToolStripMenuItem_Click);
            // 
            // xemDanhSáchHàngHoáToolStripMenuItem
            // 
            this.xemDanhSáchHàngHoáToolStripMenuItem.Image = global::QLBanHang.Properties.Resources.category_icon;
            this.xemDanhSáchHàngHoáToolStripMenuItem.Name = "xemDanhSáchHàngHoáToolStripMenuItem";
            this.xemDanhSáchHàngHoáToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.xemDanhSáchHàngHoáToolStripMenuItem.Text = "Xem danh sách hàng hoá";
            this.xemDanhSáchHàngHoáToolStripMenuItem.Click += new System.EventHandler(this.xemDanhSáchHàngHoáToolStripMenuItem_Click);
            // 
            // quảnLýHoáĐơnToolStripMenuItem
            // 
            this.quảnLýHoáĐơnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpHoáĐơnToolStripMenuItem,
            this.xemDanhSáchHoáĐơnToolStripMenuItem});
            this.quảnLýHoáĐơnToolStripMenuItem.Name = "quảnLýHoáĐơnToolStripMenuItem";
            this.quảnLýHoáĐơnToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.quảnLýHoáĐơnToolStripMenuItem.Text = "Quản lý hoá đơn";
            // 
            // nhậpHoáĐơnToolStripMenuItem
            // 
            this.nhậpHoáĐơnToolStripMenuItem.Image = global::QLBanHang.Properties.Resources.Add_Folder_icon;
            this.nhậpHoáĐơnToolStripMenuItem.Name = "nhậpHoáĐơnToolStripMenuItem";
            this.nhậpHoáĐơnToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.nhậpHoáĐơnToolStripMenuItem.Text = "Nhập hoá đơn";
            this.nhậpHoáĐơnToolStripMenuItem.Click += new System.EventHandler(this.nhậpHoáĐơnToolStripMenuItem_Click);
            // 
            // xemDanhSáchHoáĐơnToolStripMenuItem
            // 
            this.xemDanhSáchHoáĐơnToolStripMenuItem.Image = global::QLBanHang.Properties.Resources.category_icon;
            this.xemDanhSáchHoáĐơnToolStripMenuItem.Name = "xemDanhSáchHoáĐơnToolStripMenuItem";
            this.xemDanhSáchHoáĐơnToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.xemDanhSáchHoáĐơnToolStripMenuItem.Text = "Xem danh sách hoá đơn";
            this.xemDanhSáchHoáĐơnToolStripMenuItem.Click += new System.EventHandler(this.xemDanhSáchHoáĐơnToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLBanHang.Properties.Resources.marketing;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Quản lý bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHàngHoáToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHoáĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchNgườiMuaHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchĐơnVịBánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemDanhSáchHàngHoáToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpHoáĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemDanhSáchHoáĐơnToolStripMenuItem;
    }
}