using System;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 項目管理　エンティティ
    public class ColumnsManagement
    {
        public int ColumnsManagementId { get; set; }
        public int ColumnsManagementCode { get; set; }
        public int DisplayOrPrint { get; set; }
        public int ClassNumber { get; set; }
        public int ColumnNumber { get; set; }
        public string HeaderName { get; set; }
        public bool Visible { get; set; }
        public int ColumnWidth { get; set; }
        public int BackColor { get; set; }
        public int CharMaxLength { get; set; }
        public int CharLayout { get; set; }
        public bool WrapMode { get; set; }
        public int FontFamily { get; set; }
        public int FontSize { get; set; }
        public bool Bold { get; set; }
        public int ForeColor { get; set; }
        public int Status { get; set; }
        public string Comments { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
