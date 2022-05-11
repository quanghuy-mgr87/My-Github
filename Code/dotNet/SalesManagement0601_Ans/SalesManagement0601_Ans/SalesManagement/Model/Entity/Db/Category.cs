using System;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // カテゴリーマスター　エンティティ
    public class Category
    {
        public int CategoryId { get; set; }
        public long CategoryCode { get; set; }
        public long ParentCategory { get; set; }
        public string CategoryName { get; set; }
        public string CategoryKana { get; set; }
        public string Comments { get; set; }
        public int DelFLG { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
