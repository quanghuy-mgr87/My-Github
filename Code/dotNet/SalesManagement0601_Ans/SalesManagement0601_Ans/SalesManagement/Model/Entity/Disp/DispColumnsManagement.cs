using System;
using System.ComponentModel;

namespace SalesManagement.Model.Entity.Disp
{
    // 項目管理表示用　エンティティ
    class DispColumnsManagement
    {
        public int ColumnsManagementId { get; set; }

        [DisplayName("項目管理コード")]
        public int ColumnsManagementCode { get; set; }

        [DisplayName("表示/印刷")]
        public string DisplayOrPrint { get; set; }

        [DisplayName("データベース名")]
        public string ClassNumber { get; set; }

        [DisplayName("項目名")]
        public string ColumnNumber { get; set; }

        [DisplayName("項目表示名")]
        public string HeaderName { get; set; }

        [DisplayName("非表示")]
        public bool Visible { get; set; }

        [DisplayName("項目長")]
        public int ColumnWidth { get; set; }

        [DisplayName("背景色")]
        public string BackColor { get; set; }

        [DisplayName("最大文字長")]
        public int CharMaxLength { get; set; }

        [DisplayName("文字レイアウト")]
        public string CharLayout { get; set; }

        [DisplayName("ラップモード")]
        public bool WrapMode { get; set; }

        [DisplayName("フォントファミリー")]
        public string FontFamily { get; set; }

        [DisplayName("フォントサイズ")]
        public string FontSize { get; set; }

        [DisplayName("太字/標準")]
        public bool Bold { get; set; }

        [DisplayName("文字色")]
        public string ForeColor { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        public Byte[] Timestamp { get; set; }
    }
}
