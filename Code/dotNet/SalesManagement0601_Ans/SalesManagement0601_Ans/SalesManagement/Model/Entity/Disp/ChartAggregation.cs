namespace SalesManagement.Model.Entity.Disp
{
    // 集計-チャート表示用　エンティティ
    public class ChartAggregation
    {
        public int AggregationId { get; set; }
        public int AggregationCode { get; set; }
        public string Year { get; set; }
        public string YearMonth { get; set; }
        public string YearMonthDay { get; set; }
        public int TotalPrice { get; set; }
    }
}
