namespace SalesManagement
{
    partial class FormDivision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDivision));
            this.buttonLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.buttonImport = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.buttonSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxLoginName = new System.Windows.Forms.TextBox();
            this.menuStrip4 = new System.Windows.Forms.MenuStrip();
            this.buttonRegist = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.labelDispName = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip6 = new System.Windows.Forms.MenuStrip();
            this.buttonPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonReset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip7 = new System.Windows.Forms.MenuStrip();
            this.buttonClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip5 = new System.Windows.Forms.MenuStrip();
            this.labelLogin = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.labelPageSize = new System.Windows.Forms.Label();
            this.buttonPageSizeChange = new System.Windows.Forms.Button();
            this.textBoxPageSize = new System.Windows.Forms.TextBox();
            this.labelPage = new System.Windows.Forms.Label();
            this.textBoxDisplayPageNo = new System.Windows.Forms.TextBox();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.textBoxComments = new System.Windows.Forms.TextBox();
            this.labelComments = new System.Windows.Forms.Label();
            this.textBoxDivisionName = new System.Windows.Forms.TextBox();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.labelDelFLG = new System.Windows.Forms.Label();
            this.labelDivisionID = new System.Windows.Forms.Label();
            this.textBoxDivisionID = new System.Windows.Forms.TextBox();
            this.labeDivisionName = new System.Windows.Forms.Label();
            this.checkBoxDelFLG = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip2.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip6.SuspendLayout();
            this.menuStrip7.SuspendLayout();
            this.menuStrip5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(80, 18);
            this.buttonLogout.Text = "ログアウト";
            this.buttonLogout.Click += new System.EventHandler(this.ButtonLogout_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonImport,
            this.buttonExport});
            this.menuStrip2.Location = new System.Drawing.Point(2, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(150, 22);
            this.menuStrip2.Stretch = false;
            this.menuStrip2.TabIndex = 1290;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // buttonImport
            // 
            this.buttonImport.Enabled = false;
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(80, 18);
            this.buttonImport.Text = "インポート";
            // 
            // buttonExport
            // 
            this.buttonExport.Enabled = false;
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(92, 18);
            this.buttonExport.Text = "エクスポート";
            // 
            // menuStrip3
            // 
            this.menuStrip3.AutoSize = false;
            this.menuStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip3.Enabled = false;
            this.menuStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSearch});
            this.menuStrip3.Location = new System.Drawing.Point(190, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip3.Size = new System.Drawing.Size(75, 22);
            this.menuStrip3.Stretch = false;
            this.menuStrip3.TabIndex = 1294;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // buttonSearch
            // 
            this.buttonSearch.AutoSize = false;
            this.buttonSearch.Enabled = false;
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(51, 24);
            this.buttonSearch.Text = "検索";
            // 
            // textBoxLoginName
            // 
            this.textBoxLoginName.CausesValidation = false;
            this.textBoxLoginName.Location = new System.Drawing.Point(502, 25);
            this.textBoxLoginName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxLoginName.Name = "textBoxLoginName";
            this.textBoxLoginName.ReadOnly = true;
            this.textBoxLoginName.Size = new System.Drawing.Size(124, 19);
            this.textBoxLoginName.TabIndex = 1292;
            this.textBoxLoginName.TabStop = false;
            // 
            // menuStrip4
            // 
            this.menuStrip4.AutoSize = false;
            this.menuStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRegist,
            this.buttonUpdate});
            this.menuStrip4.Location = new System.Drawing.Point(284, 0);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip4.Size = new System.Drawing.Size(112, 22);
            this.menuStrip4.Stretch = false;
            this.menuStrip4.TabIndex = 1296;
            this.menuStrip4.Text = "menuStrip4";
            // 
            // buttonRegist
            // 
            this.buttonRegist.Name = "buttonRegist";
            this.buttonRegist.Size = new System.Drawing.Size(44, 18);
            this.buttonRegist.Text = "登録";
            this.buttonRegist.Click += new System.EventHandler(this.ButtonRegist_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(44, 18);
            this.buttonUpdate.Text = "更新";
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // labelDispName
            // 
            this.labelDispName.AutoSize = true;
            this.labelDispName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.labelDispName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDispName.Location = new System.Drawing.Point(13, 28);
            this.labelDispName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDispName.Name = "labelDispName";
            this.labelDispName.Size = new System.Drawing.Size(71, 12);
            this.labelDispName.TabIndex = 1293;
            this.labelDispName.Text = "部署マスター";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(51, 186);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.Size = new System.Drawing.Size(622, 310);
            this.dataGridView.TabIndex = 1280;
            this.dataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_RowEnter);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(44, 18);
            this.buttonDelete.Text = "削除";
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // menuStrip6
            // 
            this.menuStrip6.AutoSize = false;
            this.menuStrip6.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip6.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip6.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonPrint,
            this.buttonReset});
            this.menuStrip6.Location = new System.Drawing.Point(514, 0);
            this.menuStrip6.Name = "menuStrip6";
            this.menuStrip6.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip6.Size = new System.Drawing.Size(132, 22);
            this.menuStrip6.Stretch = false;
            this.menuStrip6.TabIndex = 1298;
            this.menuStrip6.Text = "menuStrip6";
            // 
            // buttonPrint
            // 
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(44, 18);
            this.buttonPrint.Text = "印刷";
            this.buttonPrint.Click += new System.EventHandler(this.ButtonPrint_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(80, 18);
            this.buttonReset.Text = "入力クリア";
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // menuStrip7
            // 
            this.menuStrip7.AutoSize = false;
            this.menuStrip7.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip7.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip7.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonClose});
            this.menuStrip7.Location = new System.Drawing.Point(659, 0);
            this.menuStrip7.Name = "menuStrip7";
            this.menuStrip7.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip7.Size = new System.Drawing.Size(75, 22);
            this.menuStrip7.Stretch = false;
            this.menuStrip7.TabIndex = 1299;
            this.menuStrip7.Text = "menuStrip7";
            // 
            // buttonClose
            // 
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(56, 18);
            this.buttonClose.Text = "閉じる";
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // menuStrip5
            // 
            this.menuStrip5.AutoSize = false;
            this.menuStrip5.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip5.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonDelete});
            this.menuStrip5.Location = new System.Drawing.Point(423, 0);
            this.menuStrip5.Name = "menuStrip5";
            this.menuStrip5.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip5.Size = new System.Drawing.Size(75, 22);
            this.menuStrip5.Stretch = false;
            this.menuStrip5.TabIndex = 1297;
            this.menuStrip5.Text = "menuStrip5";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.labelLogin.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelLogin.Location = new System.Drawing.Point(422, 28);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(69, 12);
            this.labelLogin.TabIndex = 1295;
            this.labelLogin.Text = "ユーザー名：";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonLogout});
            this.menuStrip1.Location = new System.Drawing.Point(659, 23);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(75, 22);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 1291;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Click += new System.EventHandler(this.ButtonLogout_Click);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument_PrintPage);
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Location = new System.Drawing.Point(57, 503);
            this.labelPageSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(65, 12);
            this.labelPageSize.TabIndex = 1267;
            this.labelPageSize.Text = "1ページ行数";
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Location = new System.Drawing.Point(189, 498);
            this.buttonPageSizeChange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(75, 23);
            this.buttonPageSizeChange.TabIndex = 1282;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = true;
            this.buttonPageSizeChange.Click += new System.EventHandler(this.ButtonPageSizeChange_Click);
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Location = new System.Drawing.Point(126, 501);
            this.textBoxPageSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(46, 19);
            this.textBoxPageSize.TabIndex = 1279;
            this.textBoxPageSize.Leave += new System.EventHandler(this.TextBoxPageSize_Leave);
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(468, 504);
            this.labelPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(35, 12);
            this.labelPage.TabIndex = 1273;
            this.labelPage.Text = "ページ";
            // 
            // textBoxDisplayPageNo
            // 
            this.textBoxDisplayPageNo.Location = new System.Drawing.Point(411, 501);
            this.textBoxDisplayPageNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxDisplayPageNo.Name = "textBoxDisplayPageNo";
            this.textBoxDisplayPageNo.Size = new System.Drawing.Size(46, 19);
            this.textBoxDisplayPageNo.TabIndex = 1281;
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Location = new System.Drawing.Point(604, 498);
            this.buttonLastPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(22, 22);
            this.buttonLastPage.TabIndex = 1288;
            this.buttonLastPage.Text = "▶|";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            this.buttonLastPage.Click += new System.EventHandler(this.ButtonLastPage_Click);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Location = new System.Drawing.Point(578, 498);
            this.buttonNextPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(22, 22);
            this.buttonNextPage.TabIndex = 1287;
            this.buttonNextPage.Text = "▶";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.ButtonNextPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Location = new System.Drawing.Point(551, 498);
            this.buttonPreviousPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(22, 22);
            this.buttonPreviousPage.TabIndex = 1286;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            this.buttonPreviousPage.Click += new System.EventHandler(this.ButtonPreviousPage_Click);
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Location = new System.Drawing.Point(525, 498);
            this.buttonFirstPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(22, 22);
            this.buttonFirstPage.TabIndex = 1285;
            this.buttonFirstPage.Text = "|◀";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            this.buttonFirstPage.Click += new System.EventHandler(this.ButtonFirstPage_Click);
            // 
            // textBoxComments
            // 
            this.textBoxComments.Location = new System.Drawing.Point(173, 114);
            this.textBoxComments.Multiline = true;
            this.textBoxComments.Name = "textBoxComments";
            this.textBoxComments.Size = new System.Drawing.Size(335, 45);
            this.textBoxComments.TabIndex = 1277;
            this.textBoxComments.Leave += new System.EventHandler(this.TextBoxComments_Leave);
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Location = new System.Drawing.Point(60, 118);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(29, 12);
            this.labelComments.TabIndex = 1270;
            this.labelComments.Text = "備考";
            // 
            // textBoxDivisionName
            // 
            this.textBoxDivisionName.Location = new System.Drawing.Point(174, 73);
            this.textBoxDivisionName.Name = "textBoxDivisionName";
            this.textBoxDivisionName.Size = new System.Drawing.Size(335, 19);
            this.textBoxDivisionName.TabIndex = 1275;
            this.textBoxDivisionName.Leave += new System.EventHandler(this.TextBoxDivisionName_Leave);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // labelDelFLG
            // 
            this.labelDelFLG.AutoSize = true;
            this.labelDelFLG.Location = new System.Drawing.Point(60, 165);
            this.labelDelFLG.Name = "labelDelFLG";
            this.labelDelFLG.Size = new System.Drawing.Size(54, 12);
            this.labelDelFLG.TabIndex = 1272;
            this.labelDelFLG.Text = "削除フラグ";
            // 
            // labelDivisionID
            // 
            this.labelDivisionID.AutoSize = true;
            this.labelDivisionID.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDivisionID.ForeColor = System.Drawing.Color.Red;
            this.labelDivisionID.Location = new System.Drawing.Point(61, 56);
            this.labelDivisionID.Name = "labelDivisionID";
            this.labelDivisionID.Size = new System.Drawing.Size(44, 12);
            this.labelDivisionID.TabIndex = 1271;
            this.labelDivisionID.Text = "部署ID";
            // 
            // textBoxDivisionID
            // 
            this.textBoxDivisionID.Location = new System.Drawing.Point(174, 52);
            this.textBoxDivisionID.Name = "textBoxDivisionID";
            this.textBoxDivisionID.Size = new System.Drawing.Size(177, 19);
            this.textBoxDivisionID.TabIndex = 1274;
            this.textBoxDivisionID.Leave += new System.EventHandler(this.TextBoxDivisionID_Leave);
            // 
            // labeDivisionName
            // 
            this.labeDivisionName.AutoSize = true;
            this.labeDivisionName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labeDivisionName.ForeColor = System.Drawing.Color.Red;
            this.labeDivisionName.Location = new System.Drawing.Point(61, 77);
            this.labeDivisionName.Name = "labeDivisionName";
            this.labeDivisionName.Size = new System.Drawing.Size(44, 12);
            this.labeDivisionName.TabIndex = 1266;
            this.labeDivisionName.Text = "部署名";
            // 
            // checkBoxDelFLG
            // 
            this.checkBoxDelFLG.AutoSize = true;
            this.checkBoxDelFLG.Location = new System.Drawing.Point(174, 166);
            this.checkBoxDelFLG.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxDelFLG.Name = "checkBoxDelFLG";
            this.checkBoxDelFLG.Size = new System.Drawing.Size(15, 14);
            this.checkBoxDelFLG.TabIndex = 1301;
            this.checkBoxDelFLG.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pictureBox1.Location = new System.Drawing.Point(2, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(732, 22);
            this.pictureBox1.TabIndex = 1300;
            this.pictureBox1.TabStop = false;
            // 
            // FormDivision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 521);
            this.Controls.Add(this.checkBoxDelFLG);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.menuStrip3);
            this.Controls.Add(this.textBoxLoginName);
            this.Controls.Add(this.menuStrip4);
            this.Controls.Add(this.labelDispName);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip6);
            this.Controls.Add(this.menuStrip7);
            this.Controls.Add(this.menuStrip5);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelPageSize);
            this.Controls.Add(this.buttonPageSizeChange);
            this.Controls.Add(this.textBoxPageSize);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.textBoxDisplayPageNo);
            this.Controls.Add(this.buttonLastPage);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.buttonPreviousPage);
            this.Controls.Add(this.buttonFirstPage);
            this.Controls.Add(this.textBoxComments);
            this.Controls.Add(this.labelComments);
            this.Controls.Add(this.textBoxDivisionName);
            this.Controls.Add(this.labelDelFLG);
            this.Controls.Add(this.labelDivisionID);
            this.Controls.Add(this.textBoxDivisionID);
            this.Controls.Add(this.labeDivisionName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDivision";
            this.Text = "販売管理システムー従業員管理";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.menuStrip4.ResumeLayout(false);
            this.menuStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip6.ResumeLayout(false);
            this.menuStrip6.PerformLayout();
            this.menuStrip7.ResumeLayout(false);
            this.menuStrip7.PerformLayout();
            this.menuStrip5.ResumeLayout(false);
            this.menuStrip5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem buttonLogout;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem buttonImport;
        private System.Windows.Forms.ToolStripMenuItem buttonExport;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem buttonSearch;
        private System.Windows.Forms.TextBox textBoxLoginName;
        private System.Windows.Forms.MenuStrip menuStrip4;
        private System.Windows.Forms.ToolStripMenuItem buttonRegist;
        private System.Windows.Forms.ToolStripMenuItem buttonUpdate;
        private System.Windows.Forms.Label labelDispName;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem buttonDelete;
        private System.Windows.Forms.MenuStrip menuStrip6;
        private System.Windows.Forms.ToolStripMenuItem buttonPrint;
        private System.Windows.Forms.ToolStripMenuItem buttonReset;
        private System.Windows.Forms.MenuStrip menuStrip7;
        private System.Windows.Forms.ToolStripMenuItem buttonClose;
        private System.Windows.Forms.MenuStrip menuStrip5;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.Button buttonPageSizeChange;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.TextBox textBoxDisplayPageNo;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Label labelComments;
        private System.Windows.Forms.TextBox textBoxDivisionName;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.Label labelDelFLG;
        private System.Windows.Forms.Label labelDivisionID;
        private System.Windows.Forms.TextBox textBoxDivisionID;
        private System.Windows.Forms.Label labeDivisionName;
        private System.Windows.Forms.CheckBox checkBoxDelFLG;
    }
}