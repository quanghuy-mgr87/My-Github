namespace SalesManagement
{
    partial class FormItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormItem));
            this.labelPage = new System.Windows.Forms.Label();
            this.textBoxDisplayPageNo = new System.Windows.Forms.TextBox();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.labelPageSize = new System.Windows.Forms.Label();
            this.buttonPageSizeChange = new System.Windows.Forms.Button();
            this.textBoxPageSize = new System.Windows.Forms.TextBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.labelDelFLG = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelItemCD = new System.Windows.Forms.Label();
            this.textBoxItemCD = new System.Windows.Forms.TextBox();
            this.textBoxComments = new System.Windows.Forms.TextBox();
            this.labelComments = new System.Windows.Forms.Label();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.textBoxListPrice = new System.Windows.Forms.TextBox();
            this.labelListPrice = new System.Windows.Forms.Label();
            this.labelMaker = new System.Windows.Forms.Label();
            this.textBoxModelNo = new System.Windows.Forms.TextBox();
            this.labelModelNo = new System.Windows.Forms.Label();
            this.labelItemKana = new System.Windows.Forms.Label();
            this.textBoxItemKana = new System.Windows.Forms.TextBox();
            this.textBoxSellingPrice = new System.Windows.Forms.TextBox();
            this.labelSellingPrice = new System.Windows.Forms.Label();
            this.labelItemName = new System.Windows.Forms.Label();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.comboBoxMakers = new System.Windows.Forms.ComboBox();
            this.comboBoxCategorys = new System.Windows.Forms.ComboBox();
            this.buttonSelectMaker = new System.Windows.Forms.Button();
            this.buttonSelectCategory = new System.Windows.Forms.Button();
            this.textBoxJanCD = new System.Windows.Forms.TextBox();
            this.labelJanCD = new System.Windows.Forms.Label();
            this.checkBoxDelFLG = new System.Windows.Forms.CheckBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.buttonImport = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buttonLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.buttonSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxLoginName = new System.Windows.Forms.TextBox();
            this.menuStrip4 = new System.Windows.Forms.MenuStrip();
            this.buttonRegist = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.labelDispName = new System.Windows.Forms.Label();
            this.menuStrip5 = new System.Windows.Forms.MenuStrip();
            this.buttonDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip6 = new System.Windows.Forms.MenuStrip();
            this.buttonPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonReset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip7 = new System.Windows.Forms.MenuStrip();
            this.buttonClose = new System.Windows.Forms.ToolStripMenuItem();
            this.labelLogin = new System.Windows.Forms.Label();
            this.dataStaffId = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            this.menuStrip5.SuspendLayout();
            this.menuStrip6.SuspendLayout();
            this.menuStrip7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(1356, 579);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(43, 15);
            this.labelPage.TabIndex = 1117;
            this.labelPage.Text = "ページ";
            this.labelPage.UseWaitCursor = true;
            // 
            // textBoxDisplayPageNo
            // 
            this.textBoxDisplayPageNo.Location = new System.Drawing.Point(1280, 575);
            this.textBoxDisplayPageNo.Name = "textBoxDisplayPageNo";
            this.textBoxDisplayPageNo.Size = new System.Drawing.Size(60, 22);
            this.textBoxDisplayPageNo.TabIndex = 230;
            this.textBoxDisplayPageNo.UseWaitCursor = true;
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Location = new System.Drawing.Point(1537, 572);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(30, 27);
            this.buttonLastPage.TabIndex = 1240;
            this.buttonLastPage.Text = "▶|";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            this.buttonLastPage.UseWaitCursor = true;
            this.buttonLastPage.Click += new System.EventHandler(this.ButtonLastPage_Click);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Location = new System.Drawing.Point(1502, 572);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(30, 27);
            this.buttonNextPage.TabIndex = 1230;
            this.buttonNextPage.Text = "▶";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.UseWaitCursor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.ButtonNextPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Location = new System.Drawing.Point(1467, 572);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(30, 27);
            this.buttonPreviousPage.TabIndex = 1220;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            this.buttonPreviousPage.UseWaitCursor = true;
            this.buttonPreviousPage.Click += new System.EventHandler(this.ButtonPreviousPage_Click);
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Location = new System.Drawing.Point(1432, 572);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(30, 27);
            this.buttonFirstPage.TabIndex = 1210;
            this.buttonFirstPage.Text = "|◀";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            this.buttonFirstPage.UseWaitCursor = true;
            this.buttonFirstPage.Click += new System.EventHandler(this.ButtonFirstPage_Click);
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Location = new System.Drawing.Point(11, 578);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(81, 15);
            this.labelPageSize.TabIndex = 0;
            this.labelPageSize.Text = "1ページ行数";
            this.labelPageSize.UseWaitCursor = true;
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Location = new System.Drawing.Point(187, 571);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(100, 29);
            this.buttonPageSizeChange.TabIndex = 1060;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = true;
            this.buttonPageSizeChange.UseWaitCursor = true;
            this.buttonPageSizeChange.Click += new System.EventHandler(this.ButtonPageSizeChange_Click);
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Location = new System.Drawing.Point(104, 575);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(60, 22);
            this.textBoxPageSize.TabIndex = 210;
            this.textBoxPageSize.UseWaitCursor = true;
            this.textBoxPageSize.Leave += new System.EventHandler(this.TextBoxPageSize_Leave);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(4, 575);
            this.labelMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 15);
            this.labelMessage.TabIndex = 1082;
            this.labelMessage.UseWaitCursor = true;
            // 
            // labelDelFLG
            // 
            this.labelDelFLG.AutoSize = true;
            this.labelDelFLG.Location = new System.Drawing.Point(720, 257);
            this.labelDelFLG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDelFLG.Name = "labelDelFLG";
            this.labelDelFLG.Size = new System.Drawing.Size(69, 15);
            this.labelDelFLG.TabIndex = 0;
            this.labelDelFLG.Text = "削除フラグ";
            this.labelDelFLG.UseWaitCursor = true;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelCategory.ForeColor = System.Drawing.Color.Red;
            this.labelCategory.Location = new System.Drawing.Point(13, 72);
            this.labelCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(67, 15);
            this.labelCategory.TabIndex = 0;
            this.labelCategory.Text = "カテゴリー";
            this.labelCategory.UseWaitCursor = true;
            // 
            // labelItemCD
            // 
            this.labelItemCD.AutoSize = true;
            this.labelItemCD.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelItemCD.ForeColor = System.Drawing.Color.Red;
            this.labelItemCD.Location = new System.Drawing.Point(13, 130);
            this.labelItemCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelItemCD.Name = "labelItemCD";
            this.labelItemCD.Size = new System.Drawing.Size(75, 15);
            this.labelItemCD.TabIndex = 0;
            this.labelItemCD.Text = "商品コード";
            this.labelItemCD.UseWaitCursor = true;
            // 
            // textBoxItemCD
            // 
            this.textBoxItemCD.Location = new System.Drawing.Point(164, 126);
            this.textBoxItemCD.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxItemCD.Name = "textBoxItemCD";
            this.textBoxItemCD.Size = new System.Drawing.Size(235, 22);
            this.textBoxItemCD.TabIndex = 10;
            this.textBoxItemCD.UseWaitCursor = true;
            this.textBoxItemCD.Leave += new System.EventHandler(this.TextBoxItemCD_Leave);
            // 
            // textBoxComments
            // 
            this.textBoxComments.Location = new System.Drawing.Point(871, 193);
            this.textBoxComments.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxComments.Multiline = true;
            this.textBoxComments.Name = "textBoxComments";
            this.textBoxComments.Size = new System.Drawing.Size(445, 55);
            this.textBoxComments.TabIndex = 130;
            this.textBoxComments.UseWaitCursor = true;
            this.textBoxComments.Leave += new System.EventHandler(this.TextBoxComments_Leave);
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Location = new System.Drawing.Point(720, 197);
            this.labelComments.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(37, 15);
            this.labelComments.TabIndex = 0;
            this.labelComments.Text = "備考";
            this.labelComments.UseWaitCursor = true;
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
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument_PrintPage);
            // 
            // textBoxListPrice
            // 
            this.textBoxListPrice.Location = new System.Drawing.Point(871, 139);
            this.textBoxListPrice.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxListPrice.Name = "textBoxListPrice";
            this.textBoxListPrice.Size = new System.Drawing.Size(235, 22);
            this.textBoxListPrice.TabIndex = 60;
            this.textBoxListPrice.UseWaitCursor = true;
            this.textBoxListPrice.Leave += new System.EventHandler(this.TextBoxListPrice_Leave);
            // 
            // labelListPrice
            // 
            this.labelListPrice.AutoSize = true;
            this.labelListPrice.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelListPrice.ForeColor = System.Drawing.Color.Red;
            this.labelListPrice.Location = new System.Drawing.Point(720, 144);
            this.labelListPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelListPrice.Name = "labelListPrice";
            this.labelListPrice.Size = new System.Drawing.Size(39, 15);
            this.labelListPrice.TabIndex = 0;
            this.labelListPrice.Text = "定価";
            this.labelListPrice.UseWaitCursor = true;
            // 
            // labelMaker
            // 
            this.labelMaker.AutoSize = true;
            this.labelMaker.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMaker.ForeColor = System.Drawing.Color.Red;
            this.labelMaker.Location = new System.Drawing.Point(13, 224);
            this.labelMaker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaker.Name = "labelMaker";
            this.labelMaker.Size = new System.Drawing.Size(56, 15);
            this.labelMaker.TabIndex = 0;
            this.labelMaker.Text = "メーカー";
            this.labelMaker.UseWaitCursor = true;
            // 
            // textBoxModelNo
            // 
            this.textBoxModelNo.Location = new System.Drawing.Point(164, 242);
            this.textBoxModelNo.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxModelNo.Name = "textBoxModelNo";
            this.textBoxModelNo.Size = new System.Drawing.Size(339, 22);
            this.textBoxModelNo.TabIndex = 40;
            this.textBoxModelNo.UseWaitCursor = true;
            this.textBoxModelNo.Leave += new System.EventHandler(this.TextBoxModelNo_Leave);
            // 
            // labelModelNo
            // 
            this.labelModelNo.AutoSize = true;
            this.labelModelNo.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelModelNo.ForeColor = System.Drawing.Color.Red;
            this.labelModelNo.Location = new System.Drawing.Point(13, 247);
            this.labelModelNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelModelNo.Name = "labelModelNo";
            this.labelModelNo.Size = new System.Drawing.Size(39, 15);
            this.labelModelNo.TabIndex = 0;
            this.labelModelNo.Text = "型番";
            this.labelModelNo.UseWaitCursor = true;
            // 
            // labelItemKana
            // 
            this.labelItemKana.AutoSize = true;
            this.labelItemKana.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelItemKana.ForeColor = System.Drawing.Color.Red;
            this.labelItemKana.Location = new System.Drawing.Point(13, 182);
            this.labelItemKana.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelItemKana.Name = "labelItemKana";
            this.labelItemKana.Size = new System.Drawing.Size(80, 15);
            this.labelItemKana.TabIndex = 0;
            this.labelItemKana.Text = "商品カナ名";
            this.labelItemKana.UseWaitCursor = true;
            // 
            // textBoxItemKana
            // 
            this.textBoxItemKana.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxItemKana.Location = new System.Drawing.Point(164, 177);
            this.textBoxItemKana.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxItemKana.Name = "textBoxItemKana";
            this.textBoxItemKana.Size = new System.Drawing.Size(445, 22);
            this.textBoxItemKana.TabIndex = 30;
            this.textBoxItemKana.UseWaitCursor = true;
            this.textBoxItemKana.Leave += new System.EventHandler(this.TextBoxItemKana_Leave);
            // 
            // textBoxSellingPrice
            // 
            this.textBoxSellingPrice.Location = new System.Drawing.Point(871, 164);
            this.textBoxSellingPrice.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSellingPrice.Name = "textBoxSellingPrice";
            this.textBoxSellingPrice.Size = new System.Drawing.Size(235, 22);
            this.textBoxSellingPrice.TabIndex = 70;
            this.textBoxSellingPrice.UseWaitCursor = true;
            this.textBoxSellingPrice.Leave += new System.EventHandler(this.TextBoxSellingPrice_Leave);
            // 
            // labelSellingPrice
            // 
            this.labelSellingPrice.AutoSize = true;
            this.labelSellingPrice.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSellingPrice.ForeColor = System.Drawing.Color.Red;
            this.labelSellingPrice.Location = new System.Drawing.Point(720, 170);
            this.labelSellingPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSellingPrice.Name = "labelSellingPrice";
            this.labelSellingPrice.Size = new System.Drawing.Size(103, 15);
            this.labelSellingPrice.TabIndex = 0;
            this.labelSellingPrice.Text = "店頭販売価格";
            this.labelSellingPrice.UseWaitCursor = true;
            // 
            // labelItemName
            // 
            this.labelItemName.AutoSize = true;
            this.labelItemName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelItemName.ForeColor = System.Drawing.Color.Red;
            this.labelItemName.Location = new System.Drawing.Point(13, 157);
            this.labelItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelItemName.Name = "labelItemName";
            this.labelItemName.Size = new System.Drawing.Size(55, 15);
            this.labelItemName.TabIndex = 0;
            this.labelItemName.Text = "商品名";
            this.labelItemName.UseWaitCursor = true;
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.Location = new System.Drawing.Point(164, 152);
            this.textBoxItemName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(445, 22);
            this.textBoxItemName.TabIndex = 20;
            this.textBoxItemName.UseWaitCursor = true;
            this.textBoxItemName.Leave += new System.EventHandler(this.TextBoxItemName_Leave);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 287);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.Size = new System.Drawing.Size(1683, 283);
            this.dataGridView.TabIndex = 220;
            this.dataGridView.UseWaitCursor = true;
            this.dataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_RowEnter);
            // 
            // comboBoxMakers
            // 
            this.comboBoxMakers.FormattingEnabled = true;
            this.comboBoxMakers.Location = new System.Drawing.Point(164, 215);
            this.comboBoxMakers.Name = "comboBoxMakers";
            this.comboBoxMakers.Size = new System.Drawing.Size(339, 23);
            this.comboBoxMakers.TabIndex = 50;
            this.comboBoxMakers.UseWaitCursor = true;
            // 
            // comboBoxCategorys
            // 
            this.comboBoxCategorys.FormattingEnabled = true;
            this.comboBoxCategorys.Location = new System.Drawing.Point(164, 63);
            this.comboBoxCategorys.Name = "comboBoxCategorys";
            this.comboBoxCategorys.Size = new System.Drawing.Size(339, 23);
            this.comboBoxCategorys.TabIndex = 90;
            this.comboBoxCategorys.UseWaitCursor = true;
            // 
            // buttonSelectMaker
            // 
            this.buttonSelectMaker.Location = new System.Drawing.Point(548, 214);
            this.buttonSelectMaker.Name = "buttonSelectMaker";
            this.buttonSelectMaker.Size = new System.Drawing.Size(60, 29);
            this.buttonSelectMaker.TabIndex = 1070;
            this.buttonSelectMaker.Text = "選択";
            this.buttonSelectMaker.UseVisualStyleBackColor = true;
            this.buttonSelectMaker.UseWaitCursor = true;
            this.buttonSelectMaker.Click += new System.EventHandler(this.ButtonSelectMaker_Click);
            // 
            // buttonSelectCategory
            // 
            this.buttonSelectCategory.Location = new System.Drawing.Point(548, 59);
            this.buttonSelectCategory.Name = "buttonSelectCategory";
            this.buttonSelectCategory.Size = new System.Drawing.Size(60, 29);
            this.buttonSelectCategory.TabIndex = 1080;
            this.buttonSelectCategory.Text = "選択";
            this.buttonSelectCategory.UseVisualStyleBackColor = true;
            this.buttonSelectCategory.UseWaitCursor = true;
            this.buttonSelectCategory.Click += new System.EventHandler(this.ButtonSelectCategory_Click);
            // 
            // textBoxJanCD
            // 
            this.textBoxJanCD.Location = new System.Drawing.Point(164, 90);
            this.textBoxJanCD.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxJanCD.Name = "textBoxJanCD";
            this.textBoxJanCD.Size = new System.Drawing.Size(235, 22);
            this.textBoxJanCD.TabIndex = 1242;
            this.textBoxJanCD.UseWaitCursor = true;
            // 
            // labelJanCD
            // 
            this.labelJanCD.AutoSize = true;
            this.labelJanCD.Location = new System.Drawing.Point(13, 93);
            this.labelJanCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelJanCD.Name = "labelJanCD";
            this.labelJanCD.Size = new System.Drawing.Size(50, 15);
            this.labelJanCD.TabIndex = 1241;
            this.labelJanCD.Text = "JanCD";
            this.labelJanCD.UseWaitCursor = true;
            // 
            // checkBoxDelFLG
            // 
            this.checkBoxDelFLG.AutoSize = true;
            this.checkBoxDelFLG.Location = new System.Drawing.Point(871, 256);
            this.checkBoxDelFLG.Name = "checkBoxDelFLG";
            this.checkBoxDelFLG.Size = new System.Drawing.Size(18, 17);
            this.checkBoxDelFLG.TabIndex = 1243;
            this.checkBoxDelFLG.UseVisualStyleBackColor = true;
            this.checkBoxDelFLG.UseWaitCursor = true;
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
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(200, 28);
            this.menuStrip2.Stretch = false;
            this.menuStrip2.TabIndex = 1317;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.UseWaitCursor = true;
            // 
            // buttonImport
            // 
            this.buttonImport.Enabled = false;
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(76, 24);
            this.buttonImport.Text = "インポート";
            // 
            // buttonExport
            // 
            this.buttonExport.Enabled = false;
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(87, 24);
            this.buttonExport.Text = "エクスポート";
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
            this.menuStrip1.Location = new System.Drawing.Point(1100, 29);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(100, 28);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 1318;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.UseWaitCursor = true;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(77, 24);
            this.buttonLogout.Text = "ログアウト";
            this.buttonLogout.Click += new System.EventHandler(this.ButtonLogout_Click);
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
            this.menuStrip3.Location = new System.Drawing.Point(300, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(100, 28);
            this.menuStrip3.Stretch = false;
            this.menuStrip3.TabIndex = 1323;
            this.menuStrip3.Text = "menuStrip3";
            this.menuStrip3.UseWaitCursor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.AutoSize = false;
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(51, 24);
            this.buttonSearch.Text = "検索";
            // 
            // textBoxLoginName
            // 
            this.textBoxLoginName.CausesValidation = false;
            this.textBoxLoginName.Location = new System.Drawing.Point(836, 31);
            this.textBoxLoginName.Name = "textBoxLoginName";
            this.textBoxLoginName.ReadOnly = true;
            this.textBoxLoginName.Size = new System.Drawing.Size(164, 22);
            this.textBoxLoginName.TabIndex = 1319;
            this.textBoxLoginName.TabStop = false;
            this.textBoxLoginName.UseWaitCursor = true;
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
            this.menuStrip4.Location = new System.Drawing.Point(500, 0);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.Size = new System.Drawing.Size(150, 28);
            this.menuStrip4.Stretch = false;
            this.menuStrip4.TabIndex = 1324;
            this.menuStrip4.Text = "menuStrip4";
            this.menuStrip4.UseWaitCursor = true;
            // 
            // buttonRegist
            // 
            this.buttonRegist.Name = "buttonRegist";
            this.buttonRegist.Size = new System.Drawing.Size(51, 24);
            this.buttonRegist.Text = "登録";
            this.buttonRegist.Click += new System.EventHandler(this.ButtonRegist_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(51, 24);
            this.buttonUpdate.Text = "更新";
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // labelDispName
            // 
            this.labelDispName.AutoSize = true;
            this.labelDispName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.labelDispName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDispName.Location = new System.Drawing.Point(14, 35);
            this.labelDispName.Name = "labelDispName";
            this.labelDispName.Size = new System.Drawing.Size(87, 15);
            this.labelDispName.TabIndex = 1320;
            this.labelDispName.Text = "商品マスター";
            this.labelDispName.UseWaitCursor = true;
            // 
            // menuStrip5
            // 
            this.menuStrip5.AutoSize = false;
            this.menuStrip5.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip5.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonDelete});
            this.menuStrip5.Location = new System.Drawing.Point(706, 0);
            this.menuStrip5.Name = "menuStrip5";
            this.menuStrip5.Size = new System.Drawing.Size(100, 28);
            this.menuStrip5.Stretch = false;
            this.menuStrip5.TabIndex = 1325;
            this.menuStrip5.Text = "menuStrip5";
            this.menuStrip5.UseWaitCursor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(51, 24);
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
            this.menuStrip6.Location = new System.Drawing.Point(850, 0);
            this.menuStrip6.Name = "menuStrip6";
            this.menuStrip6.Size = new System.Drawing.Size(200, 28);
            this.menuStrip6.Stretch = false;
            this.menuStrip6.TabIndex = 1326;
            this.menuStrip6.Text = "menuStrip6";
            this.menuStrip6.UseWaitCursor = true;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(51, 24);
            this.buttonPrint.Text = "印刷";
            this.buttonPrint.Click += new System.EventHandler(this.ButtonPrint_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(85, 24);
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
            this.menuStrip7.Location = new System.Drawing.Point(1100, 0);
            this.menuStrip7.Name = "menuStrip7";
            this.menuStrip7.Size = new System.Drawing.Size(100, 28);
            this.menuStrip7.Stretch = false;
            this.menuStrip7.TabIndex = 1327;
            this.menuStrip7.Text = "menuStrip7";
            this.menuStrip7.UseWaitCursor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(58, 24);
            this.buttonClose.Text = "閉じる";
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.labelLogin.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelLogin.Location = new System.Drawing.Point(729, 35);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(84, 15);
            this.labelLogin.TabIndex = 1322;
            this.labelLogin.Text = "ユーザー名：";
            this.labelLogin.UseWaitCursor = true;
            // 
            // dataStaffId
            // 
            this.dataStaffId.AutoSize = true;
            this.dataStaffId.Location = new System.Drawing.Point(1215, 10);
            this.dataStaffId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataStaffId.Name = "dataStaffId";
            this.dataStaffId.Size = new System.Drawing.Size(0, 15);
            this.dataStaffId.TabIndex = 1321;
            this.dataStaffId.UseWaitCursor = true;
            this.dataStaffId.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1600, 28);
            this.pictureBox1.TabIndex = 1328;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // FormItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 599);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip3);
            this.Controls.Add(this.textBoxLoginName);
            this.Controls.Add(this.menuStrip4);
            this.Controls.Add(this.labelDispName);
            this.Controls.Add(this.menuStrip5);
            this.Controls.Add(this.menuStrip6);
            this.Controls.Add(this.menuStrip7);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.dataStaffId);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBoxDelFLG);
            this.Controls.Add(this.textBoxJanCD);
            this.Controls.Add(this.labelJanCD);
            this.Controls.Add(this.buttonSelectCategory);
            this.Controls.Add(this.buttonSelectMaker);
            this.Controls.Add(this.comboBoxCategorys);
            this.Controls.Add(this.comboBoxMakers);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.textBoxDisplayPageNo);
            this.Controls.Add(this.buttonLastPage);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.buttonPreviousPage);
            this.Controls.Add(this.buttonFirstPage);
            this.Controls.Add(this.labelPageSize);
            this.Controls.Add(this.buttonPageSizeChange);
            this.Controls.Add(this.textBoxPageSize);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.labelDelFLG);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelItemCD);
            this.Controls.Add(this.textBoxItemCD);
            this.Controls.Add(this.textBoxComments);
            this.Controls.Add(this.labelComments);
            this.Controls.Add(this.textBoxListPrice);
            this.Controls.Add(this.labelListPrice);
            this.Controls.Add(this.labelMaker);
            this.Controls.Add(this.textBoxModelNo);
            this.Controls.Add(this.labelModelNo);
            this.Controls.Add(this.labelItemKana);
            this.Controls.Add(this.textBoxItemKana);
            this.Controls.Add(this.textBoxSellingPrice);
            this.Controls.Add(this.labelSellingPrice);
            this.Controls.Add(this.labelItemName);
            this.Controls.Add(this.textBoxItemName);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormItem";
            this.Text = "販売管理システムー商品管理";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.menuStrip4.ResumeLayout(false);
            this.menuStrip4.PerformLayout();
            this.menuStrip5.ResumeLayout(false);
            this.menuStrip5.PerformLayout();
            this.menuStrip6.ResumeLayout(false);
            this.menuStrip6.PerformLayout();
            this.menuStrip7.ResumeLayout(false);
            this.menuStrip7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.TextBox textBoxDisplayPageNo;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.Button buttonPageSizeChange;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelDelFLG;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelItemCD;
        private System.Windows.Forms.TextBox textBoxItemCD;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Label labelComments;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.TextBox textBoxListPrice;
        private System.Windows.Forms.Label labelListPrice;
        private System.Windows.Forms.Label labelMaker;
        private System.Windows.Forms.TextBox textBoxModelNo;
        private System.Windows.Forms.Label labelModelNo;
        private System.Windows.Forms.Label labelItemKana;
        private System.Windows.Forms.TextBox textBoxItemKana;
        private System.Windows.Forms.TextBox textBoxSellingPrice;
        private System.Windows.Forms.Label labelSellingPrice;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.TextBox textBoxItemName;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox comboBoxMakers;
        private System.Windows.Forms.ComboBox comboBoxCategorys;
        private System.Windows.Forms.Button buttonSelectMaker;
        private System.Windows.Forms.Button buttonSelectCategory;
        private System.Windows.Forms.TextBox textBoxJanCD;
        private System.Windows.Forms.Label labelJanCD;
        private System.Windows.Forms.CheckBox checkBoxDelFLG;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem buttonImport;
        private System.Windows.Forms.ToolStripMenuItem buttonExport;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem buttonLogout;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem buttonSearch;
        private System.Windows.Forms.TextBox textBoxLoginName;
        private System.Windows.Forms.MenuStrip menuStrip4;
        private System.Windows.Forms.ToolStripMenuItem buttonRegist;
        private System.Windows.Forms.ToolStripMenuItem buttonUpdate;
        private System.Windows.Forms.Label labelDispName;
        private System.Windows.Forms.MenuStrip menuStrip5;
        private System.Windows.Forms.ToolStripMenuItem buttonDelete;
        private System.Windows.Forms.MenuStrip menuStrip6;
        private System.Windows.Forms.ToolStripMenuItem buttonPrint;
        private System.Windows.Forms.ToolStripMenuItem buttonReset;
        private System.Windows.Forms.MenuStrip menuStrip7;
        private System.Windows.Forms.ToolStripMenuItem buttonClose;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label dataStaffId;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}