namespace SalesManagement
{
    partial class FormCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCategory));
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
            this.menuStrip6 = new System.Windows.Forms.MenuStrip();
            this.buttonPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonReset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip7 = new System.Windows.Forms.MenuStrip();
            this.buttonClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip5 = new System.Windows.Forms.MenuStrip();
            this.buttonDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.labelLogin = new System.Windows.Forms.Label();
            this.dataPositionId = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buttonLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.dataDivisionId = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelParentCategory = new System.Windows.Forms.Label();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.comboBoxParentCategorys = new System.Windows.Forms.ComboBox();
            this.labelPageSize = new System.Windows.Forms.Label();
            this.textBoxPageSize = new System.Windows.Forms.TextBox();
            this.labelPage = new System.Windows.Forms.Label();
            this.textBoxDisplayPageNo = new System.Windows.Forms.TextBox();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.labelDelFLG = new System.Windows.Forms.Label();
            this.textBoxComments = new System.Windows.Forms.TextBox();
            this.labelComments = new System.Windows.Forms.Label();
            this.labelCategoryCD = new System.Windows.Forms.Label();
            this.textBoxCategoryCD = new System.Windows.Forms.TextBox();
            this.labelCategoryKana = new System.Windows.Forms.Label();
            this.textBoxCategoryKana = new System.Windows.Forms.TextBox();
            this.dataCategoryId = new System.Windows.Forms.Label();
            this.labeCategoryName = new System.Windows.Forms.Label();
            this.textBoxCategoryName = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonPageSizeChange = new System.Windows.Forms.Button();
            this.checkBoxDelFLG = new System.Windows.Forms.CheckBox();
            this.textBoxParentCategory = new System.Windows.Forms.TextBox();
            this.menuStrip2.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            this.menuStrip6.SuspendLayout();
            this.menuStrip7.SuspendLayout();
            this.menuStrip5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
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
            this.menuStrip2.TabIndex = 1303;
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
            this.menuStrip3.TabIndex = 1307;
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
            this.textBoxLoginName.TabIndex = 1305;
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
            this.menuStrip4.TabIndex = 1309;
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
            this.labelDispName.Size = new System.Drawing.Size(120, 12);
            this.labelDispName.TabIndex = 1306;
            this.labelDispName.Text = "商品カテゴリーマスター";
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
            this.menuStrip6.TabIndex = 1311;
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
            this.menuStrip7.TabIndex = 1312;
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
            this.menuStrip5.TabIndex = 1310;
            this.menuStrip5.Text = "menuStrip5";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(44, 18);
            this.buttonDelete.Text = "削除";
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
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
            this.labelLogin.TabIndex = 1308;
            this.labelLogin.Text = "ユーザー名：";
            // 
            // dataPositionId
            // 
            this.dataPositionId.AutoSize = true;
            this.dataPositionId.Location = new System.Drawing.Point(122, 29);
            this.dataPositionId.Name = "dataPositionId";
            this.dataPositionId.Size = new System.Drawing.Size(0, 12);
            this.dataPositionId.TabIndex = 1302;
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
            this.menuStrip1.TabIndex = 1304;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(80, 18);
            this.buttonLogout.Text = "ログアウト";
            this.buttonLogout.Click += new System.EventHandler(this.ButtonLogout_Click);
            // 
            // dataDivisionId
            // 
            this.dataDivisionId.AutoSize = true;
            this.dataDivisionId.Location = new System.Drawing.Point(122, 34);
            this.dataDivisionId.Name = "dataDivisionId";
            this.dataDivisionId.Size = new System.Drawing.Size(0, 12);
            this.dataDivisionId.TabIndex = 1301;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pictureBox1.Location = new System.Drawing.Point(2, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(732, 22);
            this.pictureBox1.TabIndex = 1313;
            this.pictureBox1.TabStop = false;
            // 
            // labelParentCategory
            // 
            this.labelParentCategory.AutoSize = true;
            this.labelParentCategory.Location = new System.Drawing.Point(62, 53);
            this.labelParentCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelParentCategory.Name = "labelParentCategory";
            this.labelParentCategory.Size = new System.Drawing.Size(61, 12);
            this.labelParentCategory.TabIndex = 1323;
            this.labelParentCategory.Text = "親カテゴリー";
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument_PrintPage);
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
            // comboBoxParentCategorys
            // 
            this.comboBoxParentCategorys.FormattingEnabled = true;
            this.comboBoxParentCategorys.Location = new System.Drawing.Point(176, 50);
            this.comboBoxParentCategorys.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxParentCategorys.Name = "comboBoxParentCategorys";
            this.comboBoxParentCategorys.Size = new System.Drawing.Size(115, 20);
            this.comboBoxParentCategorys.TabIndex = 1325;
            this.comboBoxParentCategorys.SelectedIndexChanged += new System.EventHandler(this.ComboBoxParentCategorys_SelectedIndexChanged);
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Location = new System.Drawing.Point(57, 522);
            this.labelPageSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(65, 12);
            this.labelPageSize.TabIndex = 1322;
            this.labelPageSize.Text = "1ページ行数";
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Location = new System.Drawing.Point(126, 520);
            this.textBoxPageSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(46, 19);
            this.textBoxPageSize.TabIndex = 1330;
            this.textBoxPageSize.Leave += new System.EventHandler(this.TextBoxPageSize_Leave);
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(503, 524);
            this.labelPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(35, 12);
            this.labelPage.TabIndex = 1320;
            this.labelPage.Text = "ページ";
            // 
            // textBoxDisplayPageNo
            // 
            this.textBoxDisplayPageNo.Location = new System.Drawing.Point(447, 521);
            this.textBoxDisplayPageNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxDisplayPageNo.Name = "textBoxDisplayPageNo";
            this.textBoxDisplayPageNo.Size = new System.Drawing.Size(46, 19);
            this.textBoxDisplayPageNo.TabIndex = 1332;
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Location = new System.Drawing.Point(639, 518);
            this.buttonLastPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(22, 22);
            this.buttonLastPage.TabIndex = 1339;
            this.buttonLastPage.Text = "▶|";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            this.buttonLastPage.Click += new System.EventHandler(this.ButtonLastPage_Click);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Location = new System.Drawing.Point(613, 518);
            this.buttonNextPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(22, 22);
            this.buttonNextPage.TabIndex = 1338;
            this.buttonNextPage.Text = "▶";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.ButtonNextPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Location = new System.Drawing.Point(587, 518);
            this.buttonPreviousPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(22, 22);
            this.buttonPreviousPage.TabIndex = 1337;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            this.buttonPreviousPage.Click += new System.EventHandler(this.ButtonPreviousPage_Click);
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Location = new System.Drawing.Point(561, 518);
            this.buttonFirstPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(22, 22);
            this.buttonFirstPage.TabIndex = 1336;
            this.buttonFirstPage.Text = "|◀";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            this.buttonFirstPage.Click += new System.EventHandler(this.ButtonFirstPage_Click);
            // 
            // labelDelFLG
            // 
            this.labelDelFLG.AutoSize = true;
            this.labelDelFLG.Location = new System.Drawing.Point(61, 182);
            this.labelDelFLG.Name = "labelDelFLG";
            this.labelDelFLG.Size = new System.Drawing.Size(54, 12);
            this.labelDelFLG.TabIndex = 1315;
            this.labelDelFLG.Text = "削除フラグ";
            // 
            // textBoxComments
            // 
            this.textBoxComments.Location = new System.Drawing.Point(174, 133);
            this.textBoxComments.Multiline = true;
            this.textBoxComments.Name = "textBoxComments";
            this.textBoxComments.Size = new System.Drawing.Size(335, 45);
            this.textBoxComments.TabIndex = 1328;
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Location = new System.Drawing.Point(61, 136);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(29, 12);
            this.labelComments.TabIndex = 1318;
            this.labelComments.Text = "備考";
            // 
            // labelCategoryCD
            // 
            this.labelCategoryCD.AutoSize = true;
            this.labelCategoryCD.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelCategoryCD.ForeColor = System.Drawing.Color.Red;
            this.labelCategoryCD.Location = new System.Drawing.Point(62, 75);
            this.labelCategoryCD.Name = "labelCategoryCD";
            this.labelCategoryCD.Size = new System.Drawing.Size(72, 12);
            this.labelCategoryCD.TabIndex = 1321;
            this.labelCategoryCD.Text = "カテゴリーCD";
            // 
            // textBoxCategoryCD
            // 
            this.textBoxCategoryCD.Location = new System.Drawing.Point(175, 70);
            this.textBoxCategoryCD.Name = "textBoxCategoryCD";
            this.textBoxCategoryCD.Size = new System.Drawing.Size(116, 19);
            this.textBoxCategoryCD.TabIndex = 1324;
            this.textBoxCategoryCD.Leave += new System.EventHandler(this.TextBoxCategoryCD_Leave);
            // 
            // labelCategoryKana
            // 
            this.labelCategoryKana.AutoSize = true;
            this.labelCategoryKana.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelCategoryKana.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelCategoryKana.Location = new System.Drawing.Point(62, 117);
            this.labelCategoryKana.Name = "labelCategoryKana";
            this.labelCategoryKana.Size = new System.Drawing.Size(80, 12);
            this.labelCategoryKana.TabIndex = 1317;
            this.labelCategoryKana.Text = "カテゴリーカナ名";
            // 
            // textBoxCategoryKana
            // 
            this.textBoxCategoryKana.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxCategoryKana.Location = new System.Drawing.Point(175, 112);
            this.textBoxCategoryKana.Name = "textBoxCategoryKana";
            this.textBoxCategoryKana.Size = new System.Drawing.Size(335, 19);
            this.textBoxCategoryKana.TabIndex = 1327;
            this.textBoxCategoryKana.Leave += new System.EventHandler(this.TextBoxCategoryKana_Leave);
            // 
            // dataCategoryId
            // 
            this.dataCategoryId.AutoSize = true;
            this.dataCategoryId.Location = new System.Drawing.Point(123, 33);
            this.dataCategoryId.Name = "dataCategoryId";
            this.dataCategoryId.Size = new System.Drawing.Size(0, 12);
            this.dataCategoryId.TabIndex = 1334;
            // 
            // labeCategoryName
            // 
            this.labeCategoryName.AutoSize = true;
            this.labeCategoryName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labeCategoryName.ForeColor = System.Drawing.Color.Red;
            this.labeCategoryName.Location = new System.Drawing.Point(62, 95);
            this.labeCategoryName.Name = "labeCategoryName";
            this.labeCategoryName.Size = new System.Drawing.Size(67, 12);
            this.labeCategoryName.TabIndex = 1314;
            this.labeCategoryName.Text = "カテゴリー名";
            // 
            // textBoxCategoryName
            // 
            this.textBoxCategoryName.Location = new System.Drawing.Point(175, 91);
            this.textBoxCategoryName.Name = "textBoxCategoryName";
            this.textBoxCategoryName.Size = new System.Drawing.Size(335, 19);
            this.textBoxCategoryName.TabIndex = 1326;
            this.textBoxCategoryName.Leave += new System.EventHandler(this.TextBoxCategoryName_Leave);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(52, 206);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.Size = new System.Drawing.Size(622, 310);
            this.dataGridView.TabIndex = 1331;
            this.dataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_RowEnter);
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Location = new System.Drawing.Point(187, 517);
            this.buttonPageSizeChange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(75, 23);
            this.buttonPageSizeChange.TabIndex = 1340;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = true;
            this.buttonPageSizeChange.Click += new System.EventHandler(this.ButtonPageSizeChange_Click);
            // 
            // checkBoxDelFLG
            // 
            this.checkBoxDelFLG.AutoSize = true;
            this.checkBoxDelFLG.Location = new System.Drawing.Point(174, 180);
            this.checkBoxDelFLG.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxDelFLG.Name = "checkBoxDelFLG";
            this.checkBoxDelFLG.Size = new System.Drawing.Size(15, 14);
            this.checkBoxDelFLG.TabIndex = 1341;
            this.checkBoxDelFLG.UseVisualStyleBackColor = true;
            // 
            // textBoxParentCategory
            // 
            this.textBoxParentCategory.Location = new System.Drawing.Point(308, 50);
            this.textBoxParentCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxParentCategory.Name = "textBoxParentCategory";
            this.textBoxParentCategory.Size = new System.Drawing.Size(203, 19);
            this.textBoxParentCategory.TabIndex = 1342;
            // 
            // FormCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 542);
            this.Controls.Add(this.textBoxParentCategory);
            this.Controls.Add(this.checkBoxDelFLG);
            this.Controls.Add(this.buttonPageSizeChange);
            this.Controls.Add(this.labelParentCategory);
            this.Controls.Add(this.comboBoxParentCategorys);
            this.Controls.Add(this.labelPageSize);
            this.Controls.Add(this.textBoxPageSize);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.textBoxDisplayPageNo);
            this.Controls.Add(this.buttonLastPage);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.buttonPreviousPage);
            this.Controls.Add(this.buttonFirstPage);
            this.Controls.Add(this.labelDelFLG);
            this.Controls.Add(this.textBoxComments);
            this.Controls.Add(this.labelComments);
            this.Controls.Add(this.labelCategoryCD);
            this.Controls.Add(this.textBoxCategoryCD);
            this.Controls.Add(this.labelCategoryKana);
            this.Controls.Add(this.textBoxCategoryKana);
            this.Controls.Add(this.dataCategoryId);
            this.Controls.Add(this.labeCategoryName);
            this.Controls.Add(this.textBoxCategoryName);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.menuStrip3);
            this.Controls.Add(this.textBoxLoginName);
            this.Controls.Add(this.menuStrip4);
            this.Controls.Add(this.labelDispName);
            this.Controls.Add(this.menuStrip6);
            this.Controls.Add(this.menuStrip7);
            this.Controls.Add(this.menuStrip5);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.dataPositionId);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataDivisionId);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormCategory";
            this.Text = "販売管理システムー商品管理";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.menuStrip4.ResumeLayout(false);
            this.menuStrip4.PerformLayout();
            this.menuStrip6.ResumeLayout(false);
            this.menuStrip6.PerformLayout();
            this.menuStrip7.ResumeLayout(false);
            this.menuStrip7.PerformLayout();
            this.menuStrip5.ResumeLayout(false);
            this.menuStrip5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.MenuStrip menuStrip6;
        private System.Windows.Forms.ToolStripMenuItem buttonPrint;
        private System.Windows.Forms.ToolStripMenuItem buttonReset;
        private System.Windows.Forms.MenuStrip menuStrip7;
        private System.Windows.Forms.ToolStripMenuItem buttonClose;
        private System.Windows.Forms.MenuStrip menuStrip5;
        private System.Windows.Forms.ToolStripMenuItem buttonDelete;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label dataPositionId;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem buttonLogout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label dataDivisionId;
        private System.Windows.Forms.Label labelParentCategory;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.ComboBox comboBoxParentCategorys;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.TextBox textBoxDisplayPageNo;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.Label labelDelFLG;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Label labelComments;
        private System.Windows.Forms.Label labelCategoryCD;
        private System.Windows.Forms.TextBox textBoxCategoryCD;
        private System.Windows.Forms.Label labelCategoryKana;
        private System.Windows.Forms.TextBox textBoxCategoryKana;
        private System.Windows.Forms.Label dataCategoryId;
        private System.Windows.Forms.Label labeCategoryName;
        private System.Windows.Forms.TextBox textBoxCategoryName;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonPageSizeChange;
        private System.Windows.Forms.CheckBox checkBoxDelFLG;
        private System.Windows.Forms.TextBox textBoxParentCategory;
    }
}