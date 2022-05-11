using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.Entity.Disp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model.ContentsManagement.Common
{
    class AggregationCommon
    {
        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** 集計関係

        // データ取得（EntityFramework）
        public IEnumerable<Aggregation> GetAggregations()
        {
            using (var db = new SalesDbContext()) return db.Aggregations.ToList();
        }

        // データ取得
        // in  : aggregationId
        // out : aggregationデータ
        public Aggregation GetAggregation(int aggregationId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Aggregations.Single(m => m.AggregationId == aggregationId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundAggregation);
            }
        }

        // 表示データ取得（EntityFramework）
        public IEnumerable<DispAggregation> GetDispAggregations()
        {
            using (var db = new SalesDbContext())
            {
                List<DispAggregation> dispAggregations = new List<DispAggregation>();
                foreach (Aggregation aggregation in db.Aggregations)
                {
                    dispAggregations.Add(new DispAggregation()
                    {
                        AggregationId = aggregation.AggregationId,
                        AggregationCode = aggregation.AggregationCode,
                        Year = aggregation.Year.ToString(),
                        Month = aggregation.Month.ToString(),
                        Day = aggregation.Day.ToString(),
                        TotalPrice = String.Format("{0:#,0}", aggregation.TotalPrice),
                        Comments = aggregation.Comments,
                        Status = StaticCommon.ConvertToString(1, aggregation.Status),
                        Timestamp = aggregation.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispAggregation> sortableDispAggregation = new SortableBindingList<DispAggregation>(dispAggregations);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Aggregation",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispAggregation;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<DispAggregation> GetDispAggregations(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<DispAggregation> dispAggregations = new List<DispAggregation>();
                int count = 0;
                foreach (Aggregation aggregation in db.Aggregations)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    dispAggregations.Add(new DispAggregation()
                    {
                        AggregationId = aggregation.AggregationId,
                        AggregationCode = aggregation.AggregationCode,
                        Year = aggregation.Year.ToString(),
                        Month = aggregation.Month.ToString(),
                        Day = aggregation.Day.ToString(),
                        TotalPrice = String.Format("{0:#,0}", aggregation.TotalPrice),
                        Comments = aggregation.Comments,
                        Status = StaticCommon.ConvertToString(1, aggregation.Status),
                        Timestamp = aggregation.Timestamp
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispAggregation> sortableDispAggregation = new SortableBindingList<DispAggregation>(dispAggregations);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Aggregation",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispAggregation;
            }
        }

        // in   ShopId : 店舗Id
        //      mode   : 0=Day, 1=Month, 2=3Month, 4=Year
        public IEnumerable<ChartAggregation> CalcShopAggregation(int ShopId, int mode)
        {
            List<SaleDetail> saleDetails = new List<SaleDetail>();

            using (var db = new SalesDbContext())
            {
                // 店舗（Shop） でデータ絞込

                foreach (SaleDetail saleDetail in db.SaleDetails)
                {
                    if (db.Sales.Single(n => n.SaleId == saleDetail.SaleNo).SaleShopsId == ShopId)
                    {
                        saleDetails.Add(saleDetail);
                    }
                }
            }

            // グループ化　&　集計処理
            return GroupingAggregation2(saleDetails, mode);
        }

        // in   StaffId : 従業員Id
        //      mode   : 0=Day, 1=Month, 2=3Month, 4=Year
        public IEnumerable<ChartAggregation> CalcStaffAggregation(int StaffId, int mode)
        {
            List<SaleDetail> saleDetails = new List<SaleDetail>();

            using (var db = new SalesDbContext())
            {
                // 従業員（Staff） でデータ絞込

                foreach (SaleDetail saleDetail in db.SaleDetails)
                {
                    if (db.Sales.Single(n => n.SaleId == saleDetail.SaleNo).PersonInChargesId == StaffId)
                    {
                        saleDetails.Add(saleDetail);
                    }
                }
            }

            // グループ化　&　集計処理
            return GroupingAggregation2(saleDetails, mode);
        }

        // in   CategoryId : カテゴリーId
        //      mode   : 0=Day, 1=Month, 2=3Month, 4=Year
        public IEnumerable<ChartAggregation> CalcCategoryAggregation(long CategoryCode, int mode)
        {
            List<SaleDetail> saleDetails = new List<SaleDetail>();

            using (var db = new SalesDbContext())
            {
                // 指定したカテゴリーに属する商品リストを取得
                // Itemに格納されているCategorysIdはCategoryCodeである事に注意
                List<Item> items = db.Items.Where(m => m.CategorysId == CategoryCode).ToList();

                foreach (SaleDetail saleDetail in db.SaleDetails)
                {
                    // 売り上げた商品が指定したカテゴリーに属するかチェック
                    foreach (Item item in items)
                    {
                        if (saleDetail.ItemsId == item.ItemId) saleDetails.Add(saleDetail);
                    }
                }
            }

            // グループ化　&　集計処理
            return GroupingAggregation2(saleDetails, mode);
        }

        // in   ItemId : 商品Id
        //      mode   : 0=Day, 1=Month, 2=3Month, 4=Year
        public IEnumerable<ChartAggregation> CalcItemAggregation(int ItemId, int mode)
        {
            List<SaleDetail> saleDetails;

            using (var db = new SalesDbContext())
            {
                // 商品（Item） でデータ絞込
                saleDetails = db.SaleDetails.Where(m => m.ItemsId == ItemId).ToList();
            }

            // グループ化　&　集計処理
            return GroupingAggregation2(saleDetails, mode);
        }

        // グループ化　&　集計処理
        // in       sales : 売上データ
        //          mode  : 0=日単位、1=月単位、2=３ヶ月単位、3=年単位
        private IEnumerable<Aggregation> GroupingAggregation(List<SaleDetail> saleDetails, int mode)
        {
            // 計算用リスト
            List<CalcAggregation> calcAggregations = new List<CalcAggregation>();

            DateTime? dateTime;
            using (var db = new SalesDbContext())
            {
                foreach (var daySaleDetail in saleDetails)
                {
                    CalcAggregation calcAggregation = new CalcAggregation();
                    switch (mode)
                    {
                        case 0:
                            // 販売日時を日単位に丸める
                            dateTime = db.Sales.Single(m => m.SaleId == daySaleDetail.SaleNo).SaleDateTime;
                            calcAggregation.SaleDateTime = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, 0, 0, 0);
                            break;
                        case 1:
                            // 販売日時を月単位に丸める
                            dateTime = db.Sales.Single(m => m.SaleId == daySaleDetail.SaleNo).SaleDateTime;
                            calcAggregation.SaleDateTime = new DateTime(dateTime.Value.Year, dateTime.Value.Month, 1, 0, 0, 0);
                            break;
                        case 2:
                            // 販売日時を３ヶ月単位に丸める
                            dateTime = db.Sales.Single(m => m.SaleId == daySaleDetail.SaleNo).SaleDateTime;

                            int month = dateTime.Value.Month;
                            if (1 <= month && month <= 3) calcAggregation.SaleDateTime = new DateTime(dateTime.Value.Year, 1, 1, 0, 0, 0);
                            if (4 <= month && month <= 6) calcAggregation.SaleDateTime = new DateTime(dateTime.Value.Year, 2, 1, 0, 0, 0);
                            if (7 <= month && month <= 9) calcAggregation.SaleDateTime = new DateTime(dateTime.Value.Year, 3, 1, 0, 0, 0);
                            if (10 <= month && month <= 12) calcAggregation.SaleDateTime = new DateTime(dateTime.Value.Year, 4, 1, 0, 0, 0);
                            break;
                        case 3:
                            // 販売日時を年単位に丸める
                            dateTime = db.Sales.Single(m => m.SaleId == daySaleDetail.SaleNo).SaleDateTime;
                            calcAggregation.SaleDateTime = new DateTime(dateTime.Value.Year, 1, 1, 0, 0, 0);
                            break;
                    }
                    calcAggregation.Price = daySaleDetail.Price;
                    calcAggregations.Add(calcAggregation);
                }

                //List<Aggregation> aggregations = new List<Aggregation>();
                db.Aggregations.RemoveRange(db.Aggregations);

                var salesGroup = calcAggregations.GroupBy(m => m.SaleDateTime).OrderBy(n => n.Key.Value);
                int counter = 0;
                foreach (var sale in salesGroup)
                {
                    Aggregation aggregation = new Aggregation();
                    foreach (var price in sale)
                    {
                        aggregation.TotalPrice += price.Price;
                    }
                    aggregation.AggregationCode = ++counter;
                    aggregation.Year = sale.Key.Value.Year;
                    aggregation.Month = sale.Key.Value.Month;
                    aggregation.Day = sale.Key.Value.Day;

                    // aggregations.Add(aggregation);
                    db.Aggregations.Add(aggregation);
                }
                db.SaveChanges();
                return db.Aggregations.ToList();
            }
        }

        // グループ化　&　集計処理
        // in       sales : 売上データ
        //          mode  : 0=日単位、1=月単位、2=３ヶ月単位、3=年単位
        private IEnumerable<ChartAggregation> GroupingAggregation2(List<SaleDetail> saleDetails, int mode)
        {
            List<ChartAggregation> chartAggregations = new List<ChartAggregation>();

            // 計算用リスト
            List<CalcAggregation> calcAggregations = new List<CalcAggregation>();

            DateTime? dateTime;
            using (var db = new SalesDbContext())
            {
                foreach (var daySaleDetail in saleDetails)
                {
                    CalcAggregation calcAggregation = new CalcAggregation();
                    switch (mode)
                    {
                        case 0:
                            // 販売日時を日単位に丸める
                            dateTime = db.Sales.Single(m => m.SaleId == daySaleDetail.SaleNo).SaleDateTime;
                            calcAggregation.SaleDateTime = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, 0, 0, 0);
                            break;
                        case 1:
                            // 販売日時を月単位に丸める
                            dateTime = db.Sales.Single(m => m.SaleId == daySaleDetail.SaleNo).SaleDateTime;
                            calcAggregation.SaleDateTime = new DateTime(dateTime.Value.Year, dateTime.Value.Month, 1, 0, 0, 0);
                            break;
                        case 2:
                            // 販売日時を３ヶ月単位に丸める
                            dateTime = db.Sales.Single(m => m.SaleId == daySaleDetail.SaleNo).SaleDateTime;

                            int month = dateTime.Value.Month;
                            if (1 <= month && month <= 3) calcAggregation.SaleDateTime = new DateTime(dateTime.Value.Year, 1, 1, 0, 0, 0);
                            if (4 <= month && month <= 6) calcAggregation.SaleDateTime = new DateTime(dateTime.Value.Year, 2, 1, 0, 0, 0);
                            if (7 <= month && month <= 9) calcAggregation.SaleDateTime = new DateTime(dateTime.Value.Year, 3, 1, 0, 0, 0);
                            if (10 <= month && month <= 12) calcAggregation.SaleDateTime = new DateTime(dateTime.Value.Year, 4, 1, 0, 0, 0);
                            break;
                        case 3:
                            // 販売日時を年単位に丸める
                            dateTime = db.Sales.Single(m => m.SaleId == daySaleDetail.SaleNo).SaleDateTime;
                            calcAggregation.SaleDateTime = new DateTime(dateTime.Value.Year, 1, 1, 0, 0, 0);
                            break;
                    }
                    calcAggregation.Price = daySaleDetail.Price;
                    calcAggregations.Add(calcAggregation);
                }

                db.Aggregations.RemoveRange(db.Aggregations);

                var salesGroup = calcAggregations.GroupBy(m => m.SaleDateTime).OrderBy(n => n.Key.Value);
                int counter = 0;
                foreach (var sale in salesGroup)
                {
                    Aggregation aggregation = new Aggregation();
                    ChartAggregation chartAggregation = new ChartAggregation();
                    foreach (var price in sale)
                    {
                        aggregation.TotalPrice += price.Price;
                        chartAggregation.TotalPrice += price.Price;
                    }
                    aggregation.AggregationCode = ++counter;
                    aggregation.Year = sale.Key.Value.Year;
                    aggregation.Month = sale.Key.Value.Month;
                    aggregation.Day = sale.Key.Value.Day;

                    chartAggregation.AggregationCode = aggregation.AggregationCode;
                    chartAggregation.YearMonthDay = sale.Key.Value.Year.ToString() + "." + sale.Key.Value.Month.ToString() + "." + sale.Key.Value.Day.ToString();
                    chartAggregation.YearMonth = sale.Key.Value.Year.ToString() + "." + sale.Key.Value.Month.ToString();
                    chartAggregation.Year = sale.Key.Value.Year.ToString();

                    // aggregations.Add(aggregation);
                    db.Aggregations.Add(aggregation);
                    chartAggregations.Add(chartAggregation);
                }
                db.SaveChanges();
                return chartAggregations;
            }
        }
    }
}
