using SalesManagement.DataSet;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.Entity.Disp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static SalesManagement.DataSet.DsColumnsManagement;

namespace SalesManagement.Model.ContentsManagement.Common
{
    class ColumnsManagementCommon
    {
        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // データベース接続文字列
        private readonly string connDBString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagementADO;Integrated Security=True";

        // ***** 項目処理関係
        // データ取得（EntityFramework）
        public IEnumerable<ColumnsManagement> GetColumnsManagements()
        {
            using (var db = new SalesDbContext()) return db.ColumnsManagements.ToList();
        }

        // データ取得（データセット）
        public DsColumnsManagement GetDsColumnsManagements()
        {
            // データ格納データセット
            DsColumnsManagement cm = new DsColumnsManagement();
            ColumnsManagementsDataTable table = cm.ColumnsManagements;

            string SelectcommandText = "SELECT * FROM M_Staff WHERE(DelFLG = 0)";

            // ***** クエリで実行

            // データベースコネクション
            SqlConnection SQLC = new SqlConnection(connDBString);

            // 選択コマンド
            SqlCommand cmd = new SqlCommand(SelectcommandText, SQLC);

            try
            {
                // 接続
                SQLC.Open();

                // 実行（１レコードずつ読み込んでデータセットにデータをセット）
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ColumnsManagementsRow datarow = (ColumnsManagementsRow)table.NewRow();
                    datarow["ColumnsManagementId"] = dr.GetString(0);
                    datarow["ColumnsManagementCode"] = dr.GetString(1);
                    datarow["DisplayOrPrint"] = dr.GetString(2);
                    datarow["ClassNumber"] = dr.GetString(3);
                    datarow["ColumnNumber"] = dr.GetString(4);
                    datarow["HeaderName"] = dr.GetString(5);
                    datarow["Visible"] = dr.GetString(6);
                    datarow["ColumnWidth"] = dr.GetString(7);
                    datarow["BackColor"] = dr.GetString(8);
                    datarow["CharMaxLength"] = dr.GetDateTime(9);
                    datarow["CharLayout"] = dr.GetDateTime(10);
                    datarow["WrapMode"] = dr.GetInt32(11);
                    table.AddColumnsManagementsRow(datarow);
                }
            }
            catch (Exception e)
            {
                string err = e.ToString();
            }
            finally
            {
                // 切断
                SQLC.Close();
            }
            return cm;
        }

        // データ取得
        // in  : ColumnsManagementId
        // out : ColumnsManagementデータ
        public ColumnsManagement GetColumnsManagement(int columnsManagementId)
        {
            try
            {
                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "ColumnsManagement",
                    Command = "Get",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                using (var db = new SalesDbContext()) return db.ColumnsManagements.Single(m => m.ColumnsManagementId == columnsManagementId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundColumn);
            }
        }

        // 表示データ取得（EntityFramework）
        public IEnumerable<DispColumnsManagement> GetDispColumnsManagements()
        {
            using (var db = new SalesDbContext())
            {
                List<DispColumnsManagement> dispColumnsManagements = new List<DispColumnsManagement>();
                foreach (ColumnsManagement columnsManagement in db.ColumnsManagements)
                {
                    dispColumnsManagements.Add(new DispColumnsManagement()
                    {
                        ColumnsManagementId = columnsManagement.ColumnsManagementId,
                        ColumnsManagementCode = columnsManagement.ColumnsManagementCode,
                        DisplayOrPrint = StaticCommon.ConvertToString(2, columnsManagement.DisplayOrPrint),
                        ClassNumber = StaticCommon.ConvertToString(7, columnsManagement.ClassNumber),
                        ColumnNumber = GetColumnName(columnsManagement.ClassNumber, columnsManagement.ColumnNumber),
                        HeaderName = columnsManagement.HeaderName,
                        Visible = columnsManagement.Visible,
                        ColumnWidth = columnsManagement.ColumnWidth,
                        BackColor = StaticCommon.ConvertToString(4, columnsManagement.BackColor),
                        CharMaxLength = columnsManagement.CharMaxLength,
                        CharLayout = StaticCommon.ConvertToString(8, columnsManagement.CharLayout),
                        WrapMode = columnsManagement.WrapMode,
                        FontFamily = StaticCommon.ConvertToString(6, columnsManagement.FontFamily),
                        FontSize = columnsManagement.FontSize.ToString(),
                        Bold = columnsManagement.Bold,
                        ForeColor = StaticCommon.ConvertToString(5, columnsManagement.ForeColor),
                        Comments = columnsManagement.Comments,
                        Status = StaticCommon.ConvertToString(1, columnsManagement.Status),
                        Timestamp = columnsManagement.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispColumnsManagement> sortableColumnsManagement = new SortableBindingList<DispColumnsManagement>(dispColumnsManagements);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "ColumnsManagement",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableColumnsManagement;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<DispColumnsManagement> GetDispColumnsManagements(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<DispColumnsManagement> dispColumnsManagements = new List<DispColumnsManagement>();
                int count = 0;
                foreach (ColumnsManagement columnsManagement in db.ColumnsManagements)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    dispColumnsManagements.Add(new DispColumnsManagement()
                    {
                        ColumnsManagementId = columnsManagement.ColumnsManagementId,
                        ColumnsManagementCode = columnsManagement.ColumnsManagementCode,
                        DisplayOrPrint = StaticCommon.ConvertToString(2, columnsManagement.DisplayOrPrint),
                        ClassNumber = StaticCommon.ConvertToString(7, columnsManagement.ClassNumber),
                        ColumnNumber = GetColumnName(columnsManagement.ClassNumber, columnsManagement.ColumnNumber),
                        HeaderName = columnsManagement.HeaderName,
                        Visible = columnsManagement.Visible,
                        ColumnWidth = columnsManagement.ColumnWidth,
                        BackColor = StaticCommon.ConvertToString(4, columnsManagement.BackColor),
                        CharMaxLength = columnsManagement.CharMaxLength,
                        CharLayout = StaticCommon.ConvertToString(8, columnsManagement.CharLayout),
                        WrapMode = columnsManagement.WrapMode,
                        FontFamily = StaticCommon.ConvertToString(6, columnsManagement.FontFamily),
                        FontSize = columnsManagement.FontSize.ToString(),
                        Bold = columnsManagement.Bold,
                        ForeColor = StaticCommon.ConvertToString(5, columnsManagement.ForeColor),
                        Comments = columnsManagement.Comments,
                        Status = StaticCommon.ConvertToString(1, columnsManagement.Status),
                        Timestamp = columnsManagement.Timestamp
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispColumnsManagement> sortableColumnsManagement = new SortableBindingList<DispColumnsManagement>(dispColumnsManagements);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "ColumnsManagement",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableColumnsManagement;
            }
        }
        // データ追加
        public void PostColumnsManagement(ColumnsManagement regColumnsManagement)
        {
            using (var db = new SalesDbContext())
            {
                db.ColumnsManagements.Add(regColumnsManagement);
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "ColumnsManagement",
                Command = "Post",
                Data = StaticCommon.ColumnsManagementLogData(regColumnsManagement),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        public void PutColumnsManagement(ColumnsManagement regColumnsManagement)
        {
            using (var db = new SalesDbContext())
            {
                ColumnsManagement columnsManagement;
                try
                {
                    columnsManagement = db.ColumnsManagements.Single(m => m.ColumnsManagementId == regColumnsManagement.ColumnsManagementId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundColumn, ex);
                    // throw new Exception(_cm.GetMessage(107), ex);
                }
                columnsManagement.ColumnsManagementCode = regColumnsManagement.ColumnsManagementCode;
                columnsManagement.DisplayOrPrint = regColumnsManagement.DisplayOrPrint;
                columnsManagement.ClassNumber = regColumnsManagement.ClassNumber;
                columnsManagement.ColumnNumber = regColumnsManagement.ColumnNumber;
                columnsManagement.HeaderName = regColumnsManagement.HeaderName;
                columnsManagement.Visible = regColumnsManagement.Visible;
                columnsManagement.ColumnWidth = regColumnsManagement.ColumnWidth;
                columnsManagement.BackColor = regColumnsManagement.BackColor;
                columnsManagement.CharMaxLength = regColumnsManagement.CharMaxLength;
                columnsManagement.CharLayout = regColumnsManagement.CharLayout;
                columnsManagement.WrapMode = regColumnsManagement.WrapMode;
                columnsManagement.FontFamily = regColumnsManagement.FontFamily;
                columnsManagement.FontSize = regColumnsManagement.FontSize;
                columnsManagement.Bold = regColumnsManagement.Bold;
                columnsManagement.ForeColor = regColumnsManagement.ForeColor;
                columnsManagement.Status = regColumnsManagement.Status;
                columnsManagement.Comments = regColumnsManagement.Comments;
                columnsManagement.Timestamp = regColumnsManagement.Timestamp;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "ColumnsManagement",
                Command = "Put",
                Data = StaticCommon.ColumnsManagementLogData(regColumnsManagement),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ削除
        public void DeleteColumnsManagement(int columnsManagementId)
        {
            using (var db = new SalesDbContext())
            {
                ColumnsManagement columnsManagement;
                try
                {
                    columnsManagement = db.ColumnsManagements.Single(x => x.ColumnsManagementId == columnsManagementId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundColumn, ex);
                    // throw new Exception(_cm.GetMessage(107), ex);
                }
                db.ColumnsManagements.Remove(columnsManagement);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                }
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "ColumnsManagement",
                Command = "Delete",
                Data = columnsManagementId.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // 各データベース（Entity）の項目一覧を返す
        // in   Entity番号 : entityNo（Constantsに定義）
        // out 項目リスト
        public List<string> GetColumnNames(int entityNo)
        {
            List<string> columnName = new List<string>();
            switch (entityNo)
            {
                case 0:                                 // Shop
                    var dispShop = new DispShop();
                    foreach (PropertyInfo prop in dispShop.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 1:                                 // Division
                    var dispDivision = new DispDivision();
                    foreach (PropertyInfo prop in dispDivision.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 2:                                 // Staff
                    var dispStaff = new DispStaff();
                    foreach (PropertyInfo prop in dispStaff.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 3:                                 // Category
                    var dispCategory = new DispCategory();
                    foreach (PropertyInfo prop in dispCategory.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 4:                                 // Maker
                    var dispMaker = new DispMaker();
                    foreach (PropertyInfo prop in dispMaker.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 5:                                 // Tax
                    var dispTax = new DispTax();
                    foreach (PropertyInfo prop in dispTax.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 6:                                 // Unit
                    var dispUnit = new DispUnit();
                    foreach (PropertyInfo prop in dispUnit.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 7:                                 // Item
                    var dispItem = new DispItem();
                    foreach (PropertyInfo prop in dispItem.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 8:                                 // Supplier
                    var dispSupplier = new DispSupplier();
                    foreach (PropertyInfo prop in dispSupplier.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 9:                                 // ColumnsManagement
                    var dispColumnsManagement = new DispColumnsManagement();
                    foreach (PropertyInfo prop in dispColumnsManagement.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 10:                                // Sale
                    var dispSale = new DispSale();
                    foreach (PropertyInfo prop in dispSale.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 11:                                // Stock
                    var dispStock = new DispStock();
                    foreach (PropertyInfo prop in dispStock.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 12:                                // Order
                    var dispOrder = new DispOrder();
                    foreach (PropertyInfo prop in dispOrder.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 13:                                // Aggregation
                    var dispAggregation = new DispAggregation();
                    foreach (PropertyInfo prop in dispAggregation.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 14:                                // Ordering
                    var dispOrdering = new DispOrdering();
                    foreach (PropertyInfo prop in dispOrdering.GetType().GetProperties())
                    {
                        // DisplayName属性取得
                        if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr) columnName.Add(dispNameAttr.DisplayName);
                    }
                    break;
                case 15:                                // Log 
                    break;
                default:
                    break;
            }
            return columnName;
        }

        // データベース（Entity）指定、項目番号指定で項目名を返す
        // in   Entity番号  : entityNo（Constantsに定義）
        //      項目番号    : columnNo
        // out 項目名
        public string GetColumnName(int entityNo, int columnNo)
        {
            string columnName = string.Empty;
            PropertyInfo info;

            switch (entityNo)
            {
                case 0:                                 // Shop
                    var dispShop = new DispShop();
                    info = dispShop.GetType().GetProperties().ElementAt(columnNo + 1);          // 項目：xxxIdを飛ばしてカウント
                    if (Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttributeShop) columnName = dispNameAttributeShop.DisplayName;
                    break;
                case 1:                                 // Division
                    var dispDivision = new DispDivision();
                    info = dispDivision.GetType().GetProperties().ElementAt(columnNo + 1);
                    if (Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttributeDivision) columnName = dispNameAttributeDivision.DisplayName;
                    break;
                case 2:                                 // Staff
                    var dispStaff = new DispStaff();
                    info = dispStaff.GetType().GetProperties().ElementAt(columnNo + 1);
                    if (Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttributeStaff) columnName = dispNameAttributeStaff.DisplayName;
                    break;
                case 3:                                 // Category
                    var dispCategory = new DispCategory();
                    info = dispCategory.GetType().GetProperties().ElementAt(columnNo + 1);
                    if (Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttributeCategory) columnName = dispNameAttributeCategory.DisplayName;
                    break;
                case 4:                                 // Maker
                    var dispMaker = new DispMaker();
                    info = dispMaker.GetType().GetProperties().ElementAt(columnNo + 1);
                    if (Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttributeMaker) columnName = dispNameAttributeMaker.DisplayName;
                    break;
                case 5:                                 // Tax
                    var dispTax = new DispTax();
                    info = dispTax.GetType().GetProperties().ElementAt(columnNo + 1);
                    if (Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttributeTax) columnName = dispNameAttributeTax.DisplayName;
                    break;
                case 6:                                 // Unit
                    var dispUnit = new DispUnit();
                    info = dispUnit.GetType().GetProperties().ElementAt(columnNo + 1);
                    if (Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttributeUnit) columnName = dispNameAttributeUnit.DisplayName;
                    break;
                case 7:                                 // Item
                    var dispItem = new DispItem();
                    info = dispItem.GetType().GetProperties().ElementAt(columnNo + 1);
                    if (Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttributeItem) columnName = dispNameAttributeItem.DisplayName;
                    break;
                case 8:                                 // Supplier
                    var dispSupplier = new DispSupplier();
                    info = dispSupplier.GetType().GetProperties().ElementAt(columnNo + 1);
                    if (Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttributeSupplier) columnName = dispNameAttributeSupplier.DisplayName;
                    break;
                case 9:                                 // ColumnsManagement
                    var dispColumnsManagement = new DispColumnsManagement();
                    info = dispColumnsManagement.GetType().GetProperties().ElementAt(columnNo + 1);
                    if (Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttributeColumnsManagement) columnName = dispNameAttributeColumnsManagement.DisplayName;
                    break;
                case 10:                                // Sales
                    var dispSale = new DispSale();
                    info = dispSale.GetType().GetProperties().ElementAt(columnNo + 1);
                    if (Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttributeSale) columnName = dispNameAttributeSale.DisplayName;
                    break;
                case 11:                                // Stock
                    var dispStock = new DispStock();
                    info = dispStock.GetType().GetProperties().ElementAt(columnNo + 1);
                    if (Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttributeStock) columnName = dispNameAttributeStock.DisplayName;
                    break;
                case 12:                                // Order
                    var dispOrder = new DispOrder();
                    info = dispOrder.GetType().GetProperties().ElementAt(columnNo + 1);
                    if (Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttributeOrder) columnName = dispNameAttributeOrder.DisplayName;
                    break;
                case 13:                                // Aggregation
                    var dispAggregation = new DispAggregation();
                    info = dispAggregation.GetType().GetProperties().ElementAt(columnNo + 1);
                    if (Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttributeAggregation) columnName = dispNameAttributeAggregation.DisplayName;
                    break;
                case 14:                                // Log
                    break;
                default:
                    break;
            }
            return columnName;
        }
    }
}
