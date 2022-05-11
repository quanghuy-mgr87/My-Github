using SalesManagement.Model.ContentsManagement.Common;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.Entity.Disp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace SalesManagement.Model.ContentsManagement
{
    // 在庫マスター　データ処理クラス
    class StockContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private CommonFunction _cm = new CommonFunction();

        // データベース処理（Unit）
        private UnitContents _ut = new UnitContents();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得（for ComboBox）
        // out コンボボックス用データ（配列）
        public IEnumerable<Stock> GetStocks()
        {
            using (var db = new SalesDbContext())
            {
                List<Stock> stock = db.Stocks.ToList();

                // 無効のものはリストから削除
                stock.RemoveAll(m => m.Status != 0);
                return stock;
            }
        }

        // データ取得
        // in  : StockId
        // out : Stockデータ
        public Stock GetStock(int StockId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Stocks.Single(m => m.StockId == StockId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundStock);
                // throw new Exception(_cm.GetMessage(117), ex);
            }
        }

        // 表示データ取得
        // out 表示データ
        public DispStock GetDispStock(int stockId)
        {
            using (var db = new SalesDbContext())
            {
                Stock stock = db.Stocks.Single(m => m.StockId == stockId);
                string shop;
                try
                {
                    shop = (stock.ShopsId != -1) ? db.Shops.Single(m => m.ShopCode == stock.ShopsId).ShopName : string.Empty;

                    // 無効表示
                    if (db.Shops.Single(m => m.ShopCode == stock.ShopsId).Status != 0) shop = "[" + shop + "]";
                }
                catch
                {
                    shop = string.Empty;
                }

                string destinationShop;
                try
                {
                    destinationShop = (stock.DestinationShopsId != -1) ? db.Shops.Single(m => m.ShopCode == stock.DestinationShopsId).ShopName : string.Empty;

                    // 無効表示
                    if (db.Shops.Single(m => m.ShopCode == stock.DestinationShopsId).Status != 0) destinationShop = "[" + destinationShop + "]";
                }
                catch
                {
                    destinationShop = string.Empty;
                }

                string item;
                try
                {
                    item = (stock.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == stock.ItemsId).ItemName : string.Empty;

                    // 無効表示
                    if (db.Items.Single(m => m.ItemCode == stock.ItemsId).Status != 0) item = "[" + item + "]";
                }
                catch
                {
                    item = string.Empty;
                }

                string unit;
                try
                {
                    unit = (stock.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == stock.UnitsId).UnitName : string.Empty;

                    // 無効表示
                    if (db.Units.Single(m => m.UnitCode == stock.UnitsId).Status != 0) unit = "[" + unit + "]";
                }
                catch
                {
                    unit = string.Empty;
                }

                string tax;
                try
                {
                    tax = (stock.TaxsId != -1) ? db.Taxs.Single(m => m.TaxCode == stock.TaxsId).TaxValue.ToString() : string.Empty;

                    // 無効表示
                    if (db.Taxs.Single(m => m.TaxCode == stock.TaxsId).Status != 0) tax = "[" + tax + "]";
                }
                catch
                {
                    tax = string.Empty;
                }

                DispStock dispStock = new DispStock()
                {
                    StockId = stock.StockId,
                    TransactionNo = stock.TransactionNo,
                    Operation = StaticCommon.ConvertToString(11, stock.Operation),
                    StorageNo = stock.StorageNo,
                    OperationDateTime = stock.OperationDateTime,
                    Shop = shop,
                    DestinationShop = destinationShop,
                    Item = item,
                    Quantity = stock.Quantity.ToString(),
                    Unit = unit,
                    Price = String.Format("{0:#,0}", stock.Price),
                    TotalPrice = String.Format("{0:#,0}", stock.TotalPrice),
                    Tax = tax,
                    VoucherNo = stock.VoucherNo,
                    Comments = stock.Comments,
                    Status = StaticCommon.ConvertToString(1, stock.Status),
                    Timestamp = stock.Timestamp
                };

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Stock",
                    Command = "Get",
                    Data = stockId.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return dispStock;
            }
        }

        // 表示データ取得
        // out 表示データ
        public DispStock GetDispStockByTransNo(long transactionNo)
        {
            using (var db = new SalesDbContext())
            {
                Stock stock = db.Stocks.Single(m => m.TransactionNo == transactionNo);
                string shop;
                try
                {
                    shop = (stock.ShopsId != -1) ? db.Shops.Single(m => m.ShopCode == stock.ShopsId).ShopName : string.Empty;

                    // 無効表示
                    if (db.Shops.Single(m => m.ShopCode == stock.ShopsId).Status != 0) shop = "[" + shop + "]";
                }
                catch
                {
                    shop = string.Empty;
                }

                string destinationShop;
                try
                {
                    destinationShop = (stock.DestinationShopsId != -1) ? db.Shops.Single(m => m.ShopCode == stock.DestinationShopsId).ShopName : string.Empty;

                    // 無効表示
                    if (db.Shops.Single(m => m.ShopCode == stock.DestinationShopsId).Status != 0) destinationShop = "[" + destinationShop + "]";
                }
                catch
                {
                    destinationShop = string.Empty;
                }

                string item;
                try
                {
                    item = (stock.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == stock.ItemsId).ItemName : string.Empty;

                    // 無効表示
                    if (db.Items.Single(m => m.ItemCode == stock.ItemsId).Status != 0) item = "[" + item + "]";
                }
                catch
                {
                    item = string.Empty;
                }

                string unit;
                try
                {
                    unit = (stock.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == stock.UnitsId).UnitName : string.Empty;

                    // 無効表示
                    if (db.Units.Single(m => m.UnitCode == stock.UnitsId).Status != 0) unit = "[" + unit + "]";
                }
                catch
                {
                    unit = string.Empty;
                }

                string tax;
                try
                {
                    tax = (stock.TaxsId != -1) ? db.Taxs.Single(m => m.TaxCode == stock.TaxsId).TaxValue.ToString() : string.Empty;

                    // 無効表示
                    if (db.Taxs.Single(m => m.TaxCode == stock.TaxsId).Status != 0) tax = "[" + tax + "]";
                }
                catch
                {
                    tax = string.Empty;
                }

                DispStock dispStock = new DispStock()
                {
                    StockId = stock.StockId,
                    TransactionNo = stock.TransactionNo,
                    Operation = StaticCommon.ConvertToString(11, stock.Operation),
                    StorageNo = stock.StorageNo,
                    OperationDateTime = stock.OperationDateTime,
                    Shop = shop,
                    DestinationShop = destinationShop,
                    Item = item,
                    Quantity = stock.Quantity.ToString(),
                    Unit = unit,
                    Price = String.Format("{0:#,0}", stock.Price),
                    TotalPrice = String.Format("{0:#,0}", stock.TotalPrice),
                    Tax = tax,
                    VoucherNo = stock.VoucherNo,
                    Comments = stock.Comments,
                    Status = StaticCommon.ConvertToString(1, stock.Status),
                    Timestamp = stock.Timestamp
                };

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Stock",
                    Command = "Get",
                    Data = transactionNo.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return dispStock;
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<DispStock> GetDispStocks()
        {
            using (var db = new SalesDbContext())
            {
                List<DispStock> dispStocks = new List<DispStock>();
                foreach (Stock stock in db.Stocks)
                {
                    string shop;
                    try
                    {
                        shop = (stock.ShopsId != -1) ? db.Shops.Single(m => m.ShopCode == stock.ShopsId).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == stock.ShopsId).Status != 0) shop = "[" + shop + "]";
                    }
                    catch
                    {
                        shop = string.Empty;
                    }

                    string destinationShop;
                    try
                    {
                        destinationShop = (stock.DestinationShopsId != -1) ? db.Shops.Single(m => m.ShopCode == stock.DestinationShopsId).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == stock.DestinationShopsId).Status != 0) destinationShop = "[" + destinationShop + "]";
                    }
                    catch
                    {
                        destinationShop = string.Empty;
                    }

                    string item;
                    try
                    {
                        item = (stock.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == stock.ItemsId).ItemName : string.Empty;

                        // 無効表示
                        if (db.Items.Single(m => m.ItemCode == stock.ItemsId).Status != 0) item = "[" + item + "]";
                    }
                    catch
                    {
                        item = string.Empty;
                    }

                    string unit;
                    try
                    {
                        unit = (stock.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == stock.UnitsId).UnitName : string.Empty;

                        // 無効表示
                        if (db.Units.Single(m => m.UnitCode == stock.UnitsId).Status != 0) unit = "[" + unit + "]";
                    }
                    catch
                    {
                        unit = string.Empty;
                    }

                    string tax;
                    try
                    {
                        tax = (stock.TaxsId != -1) ? db.Taxs.Single(m => m.TaxCode == stock.TaxsId).TaxValue.ToString() : string.Empty;

                        // 無効表示
                        if (db.Taxs.Single(m => m.TaxCode == stock.TaxsId).Status != 0) tax = "[" + tax + "]";
                    }
                    catch
                    {
                        tax = string.Empty;
                    }

                    dispStocks.Add(new DispStock()
                    {
                        StockId = stock.StockId,
                        TransactionNo = stock.TransactionNo,
                        Operation = StaticCommon.ConvertToString(11, stock.Operation),
                        StorageNo = stock.StorageNo,
                        OperationDateTime = stock.OperationDateTime,
                        Shop = shop,
                        DestinationShop = destinationShop,
                        Item = item,
                        Quantity = stock.Quantity.ToString(),
                        Unit = unit,
                        Price = String.Format("{0:#,0}", stock.Price),
                        TotalPrice = String.Format("{0:#,0}", stock.TotalPrice),
                        Tax = tax,
                        VoucherNo = stock.VoucherNo,
                        Comments = stock.Comments,
                        Status = StaticCommon.ConvertToString(1, stock.Status),
                        Timestamp = stock.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispStock> sortableDispStock = new SortableBindingList<DispStock>(dispStocks);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Stock",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispStock;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<DispStock> GetDispStocks(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<DispStock> dispStocks = new List<DispStock>();
                int count = 0;
                foreach (Stock stock in db.Stocks)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    string shop;
                    try
                    {
                        shop = (stock.ShopsId != -1) ? db.Shops.Single(m => m.ShopCode == stock.ShopsId).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == stock.ShopsId).Status != 0) shop = "[" + shop + "]";
                    }
                    catch
                    {
                        shop = string.Empty;
                    }

                    string destinationShop;
                    try
                    {
                        destinationShop = (stock.DestinationShopsId != -1) ? db.Shops.Single(m => m.ShopCode == stock.DestinationShopsId).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == stock.DestinationShopsId).Status != 0) destinationShop = "[" + destinationShop + "]";
                    }
                    catch
                    {
                        destinationShop = string.Empty;
                    }

                    string item;
                    try
                    {
                        item = (stock.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == stock.ItemsId).ItemName : string.Empty;

                        // 無効表示
                        if (db.Items.Single(m => m.ItemCode == stock.ItemsId).Status != 0) item = "[" + item + "]";
                    }
                    catch
                    {
                        item = string.Empty;
                    }

                    string unit;
                    try
                    {
                        unit = (stock.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == stock.UnitsId).UnitName : string.Empty;

                        // 無効表示
                        if (db.Units.Single(m => m.UnitCode == stock.UnitsId).Status != 0) unit = "[" + unit + "]";
                    }
                    catch
                    {
                        unit = string.Empty;
                    }

                    string tax;
                    try
                    {
                        tax = (stock.TaxsId != -1) ? db.Taxs.Single(m => m.TaxCode == stock.TaxsId).TaxValue.ToString() : string.Empty;

                        // 無効表示
                        if (db.Taxs.Single(m => m.TaxCode == stock.TaxsId).Status != 0) tax = "[" + tax + "]";
                    }
                    catch
                    {
                        tax = string.Empty;
                    }

                    dispStocks.Add(new DispStock()
                    {
                        StockId = stock.StockId,
                        TransactionNo = stock.TransactionNo,
                        Operation = StaticCommon.ConvertToString(11, stock.Operation),
                        StorageNo = stock.StorageNo,
                        OperationDateTime = stock.OperationDateTime,
                        Shop = shop,
                        DestinationShop = destinationShop,
                        Item = item,
                        Quantity = stock.Quantity.ToString(),
                        Unit = unit,
                        Price = String.Format("{0:#,0}", stock.Price),
                        TotalPrice = String.Format("{0:#,0}", stock.TotalPrice),
                        Tax = tax,
                        VoucherNo = stock.VoucherNo,
                        Comments = stock.Comments,
                        Status = StaticCommon.ConvertToString(1, stock.Status),
                        Timestamp = stock.Timestamp
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispStock> sortableDispStock = new SortableBindingList<DispStock>(dispStocks);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Stock",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispStock;
            }
        }


        // データ取得（同じ商品・発注伝票の入庫数チェック）
        // in  : itemId（long）   ：商品コード
        //       voucherNo（int） ：伝票番号
        // out : 合計既入庫数（int）：
        public int GetStoredTotal(long itemId, string voucherNo)
        {
            int totalPcs = 0;

            try
            {
                using (var db = new SalesDbContext())
                {
                    List<Stock> stocks = db.Stocks.Where(m => m.ItemsId == itemId && m.VoucherNo == voucherNo).ToList();

                    // 既入庫数計算
                    foreach (Stock stock in stocks)
                    {
                        // 数量取得
                        int quantity = stock.Quantity;

                        // 単位個数取得
                        int pcs = _ut.GetUnit(stock.UnitsId).NumberOfComponent;

                        // 合計個数計算
                        totalPcs += quantity * pcs;
                    }
                }
            }
            catch
            {
                return 0;
                // throw new Exception(Messages.errorNotFoundStockDetail);
                // throw new Exception(_cm.GetMessage(120), ex);
            }
            return totalPcs;
        }

        // データ追加
        // in   : Stockデータ
        public void PostStock(Stock regStock)
        {
            using (var db = new SalesDbContext())
            {
                db.Stocks.Add(regStock);
                db.Entry(regStock).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Stock",
                Command = "Post",
                Data = StockLogData(regStock),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Stockデータ
        public void PutStock(Stock regStock)
        {
            using (var db = new SalesDbContext())
            {
                Stock stock;
                try
                {
                    stock = db.Stocks.Single(x => x.StockId == regStock.StockId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundStock, ex);
                    // throw new Exception(_cm.GetMessage(118), ex);
                }
                stock.TransactionNo = regStock.TransactionNo;
                stock.Operation = regStock.Operation;
                stock.StorageNo = regStock.StorageNo;
                stock.OperationDateTime = regStock.OperationDateTime;
                stock.ShopsId = regStock.ShopsId;
                stock.DestinationShopsId = regStock.DestinationShopsId;
                stock.ItemsId = regStock.ItemsId;
                stock.Quantity = regStock.Quantity;
                stock.UnitsId = regStock.UnitsId;
                stock.Price = regStock.Price;
                stock.TotalPrice = regStock.TotalPrice;
                stock.TaxsId = regStock.TaxsId;
                stock.VoucherNo = regStock.VoucherNo;
                stock.Comments = regStock.Comments;
                stock.Status = regStock.Status;
                stock.Timestamp = regStock.Timestamp;

                db.Entry(stock).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                }

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Stock",
                    Command = "Put",
                    Data = StockLogData(regStock),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // データ削除
        // in       StockId : 削除するメーカーId
        public void DeleteStock(int StockId)
        {
            Stock stock;
            using (var db = new SalesDbContext())
            {
                try
                {
                    stock = db.Stocks.Single(x => x.StockId == StockId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundStock, ex);
                    // throw new Exception(_cm.GetMessage(118), ex);
                }
                db.Stocks.Remove(stock);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                }

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Stock",
                    Command = "Delete",
                    Data = StockId.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // ***** 在庫処理　トランザクション処理モジュール

        // 登録（入庫）
        public void RegistReceiveProcess(List<OrderDetail> orderDetails, Stock regStock, int regStockListId, List<StockDetail> addStockDetails)
        {
            using (var db = new SalesDbContext())
            {
                // トランザクション処理
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // ①発注完了時完了フラグセット
                        foreach (OrderDetail regOrderDetail in orderDetails)
                        {
                            OrderDetail orderDetail;
                            try
                            {
                                orderDetail = db.OrderDetails.Single(x => x.OrderDetailId == regOrderDetail.OrderDetailId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundOrder, ex);
                                // throw new Exception(_cm.GetMessage(120), ex);
                            }

                            orderDetail.Stored = regOrderDetail.Stored;

                            db.Entry(orderDetail).State = EntityState.Modified;
                        }

                        // ②商品管理（登録）
                        int totalAddPrice = 0;
                        foreach (StockDetail stockDetail in addStockDetails)
                        {
                            // 追加合計金額計算
                            totalAddPrice += stockDetail.Price;

                            db.StockDetails.Add(stockDetail);
                            db.Entry(stockDetail).State = EntityState.Added;
                        }

                        // ③リスト管理（個数増加）
                        // 商品登録が有れば個数増加
                        StockList stockList = null;
                        try
                        {
                            stockList = db.StockLists.Single(m => m.StockListId == regStockListId);
                        }
                        catch
                        {
                            // throw new Exception(Messages.errorNotFoundStockList, ex);
                            // throw new Exception(_cm.GetMessage(119), ex);
                        }

                        if (stockList != null)
                        {
                            // 在庫数増加
                            stockList.Pcs += addStockDetails.Count();

                            // 合計値段増加
                            stockList.TotalPrice += totalAddPrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければ新規登録
                        else
                        {
                            // 商品在庫検索
                            db.StockLists.Add(stockList);
                            db.Entry(stockList).State = EntityState.Added;

                            // コードカウンターインクリメント（在庫リスト番号）
                            CodeCounter codeCounterList = db.CodeCounters.Single(m => m.CodeId == Constants.stockListNo);
                            codeCounterList.Counter += 1;
                        }

                        // ④コードカウンターインクリメント（入庫番号）
                        CodeCounter codeCounterStock = db.CodeCounters.Single(m => m.CodeId == Constants.stockNo);
                        codeCounterStock.Counter += 1;
                        db.Entry(codeCounterStock).State = EntityState.Modified;

                        // ⑤トランザクション登録
                        db.Stocks.Add(regStock);
                        db.Entry(regStock).State = EntityState.Added;

                        // ⑥コードカウンターインクリメント（トランザクション番号）
                        CodeCounter codeCounterTranz = db.CodeCounters.Single(m => m.CodeId == Constants.transactionNo);
                        codeCounterTranz.Counter += 1;
                        db.Entry(codeCounterTranz).State = EntityState.Modified;

                        // db更新
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            throw new Exception(Messages.errorConflict, ex);
                            // throw new Exception(_cm.GetMessage(100), ex);
                        }

                        // トランザクション正常終了
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new Exception("トランザクション処理に失敗しました。");
                    }
                }
            }
        }

        // 登録（出庫）
        public void RegistIssueProcess(Stock regStock, int regStockListId, int totalPcs, int totalPrice, List<StockDetail> stockDetails)
        {
            using (var db = new SalesDbContext())
            {
                // トランザクション処理
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // ①商品管理（削除）
                        int totalRemovePrice = 0;
                        try
                        {
                            foreach (StockDetail stockDetail in stockDetails)
                            {
                                StockDetail sd = db.StockDetails.Single(m => m.StockDetailId == stockDetail.StockDetailId);

                                // 削除合計金額計算
                                totalRemovePrice += sd.Price;

                                // 削除
                                db.StockDetails.Remove(sd);
                                db.Entry(sd).State = EntityState.Deleted;
                            }
                        }
                        catch
                        {
                            throw new Exception(Messages.errorNotFoundStockDetail);
                            // throw new Exception(_cm.GetMessage(120), ex);
                        }

                        // ②リスト管理（個数減少）
                        // 商品登録が有れば個数減少
                        if (regStockListId != -1)
                        {
                            StockList stockList;
                            try
                            {
                                stockList = db.StockLists.Single(m => m.StockListId == regStockListId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundStockList, ex);
                                // throw new Exception(_cm.GetMessage(119), ex);
                            }
                            // 在庫数減少
                            stockList.Pcs -= stockDetails.Count();

                            // 合計値段減少
                            stockList.TotalPrice -= totalRemovePrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければエラーメッセージ
                        else
                        {
                            throw new Exception(Messages.notFoundItem);
                            // throw new Exception(_cm.GetMessage(201));
                        }

                        // ③トランザクション登録
                        db.Stocks.Add(regStock);
                        db.Entry(regStock).State = EntityState.Added;

                        // ④コードカウンターインクリメント（トランザクション番号）
                        CodeCounter codeCounterTranz = db.CodeCounters.Single(m => m.CodeId == Constants.transactionNo);
                        codeCounterTranz.Counter += 1;
                        db.Entry(codeCounterTranz).State = EntityState.Modified;

                        // db更新
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            throw new Exception(Messages.errorConflict, ex);
                            // throw new Exception(_cm.GetMessage(100), ex);
                        }
                        // トランザクション正常終了
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new Exception("トランザクション処理に失敗しました。");
                    }
                }
            }
        }

        // 登録（出庫：インポート）
        public void ImportIssueProcess(Stock regStock, StockList regStockList, int tempSaleNo, List<StockDetail> removeStockDetails)
        {
            using (var db = new SalesDbContext())
            {
                // トランザクション処理
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // ①商品管理（削除）
                        int totalRemovePrice = 0;
                        foreach (StockDetail stockDetail in removeStockDetails)
                        {
                            StockDetail sd = db.StockDetails.Single(m => m.StockDetailId == stockDetail.StockDetailId);

                            // 削除合計金額計算
                            totalRemovePrice += sd.Price;

                            // 削除
                            db.StockDetails.Remove(sd);
                            db.Entry(sd).State = EntityState.Deleted;
                        }

                        // ②リスト管理（個数減少）
                        // 商品登録が有れば個数減少
                        if (regStockList != null)
                        {
                            StockList stockList;
                            try
                            {
                                stockList = db.StockLists.Single(x => x.StockListId == regStockList.StockListId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundStockList, ex);
                                // throw new Exception(_cm.GetMessage(119), ex);
                            }
                            // 在庫数減少
                            stockList.Pcs -= removeStockDetails.Count();

                            // 合計値段減少
                            stockList.TotalPrice -= totalRemovePrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければエラーメッセージ
                        else
                        {
                            throw new Exception(Messages.notFoundItem);
                            // throw new Exception(_cm.GetMessage(201));
                        }

                        // ③トランザクション登録
                        db.Stocks.Add(regStock);
                        db.Entry(regStock).State = EntityState.Added;

                        // ④コードカウンターインクリメント（トランザクション番号）
                        CodeCounter codeCounterTranz = db.CodeCounters.Single(m => m.CodeId == Constants.transactionNo);
                        codeCounterTranz.Counter += 1;
                        db.Entry(codeCounterTranz).State = EntityState.Modified;

                        // ⑤インポート処理フラグ
                        Sale sale = db.Sales.Single(m => m.SaleNo == tempSaleNo);
                        sale.StockManagementInfo = 1;

                        db.Entry(sale).State = EntityState.Modified;

                        // db更新
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            throw new Exception(Messages.errorConflict, ex);
                            // throw new Exception(_cm.GetMessage(100), ex);
                        }
                        // トランザクション正常終了
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new Exception("トランザクション処理に失敗しました。");
                    }
                }
            }
        }

        // 登録（移動）
        public void RegistMoveProcess(Stock regStock, int issuingStockListId, int receivingStockListId, int destinationShopId, List<StockDetail> removeStockDetails, List<StockDetail> addStockDetails)
        {
            using (var db = new SalesDbContext())
            {
                // トランザクション処理
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        StockList stockList;

                        // ①商品管理（削除）
                        int totalRemovePrice = 0;
                        foreach (StockDetail stockDetail in removeStockDetails)
                        {
                            StockDetail sd = db.StockDetails.Single(m => m.StockDetailId == stockDetail.StockDetailId);

                            // 削除合計金額計算
                            totalRemovePrice += sd.Price;

                            // 削除
                            db.StockDetails.Remove(sd);
                            db.Entry(sd).State = EntityState.Deleted;
                        }

                        // ②リスト管理（個数減少）
                        // 商品登録が有れば個数減少
                        if (issuingStockListId != -1)
                        {
                            try
                            {
                                stockList = db.StockLists.Single(m => m.StockListId == issuingStockListId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundStockList, ex);
                                // throw new Exception(_cm.GetMessage(119), ex);
                            }

                            // 在庫数減少
                            stockList.Pcs -= removeStockDetails.Count();

                            // 合計値段減少
                            stockList.TotalPrice -= totalRemovePrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければエラーメッセージ
                        else
                        {
                            throw new Exception(Messages.notFoundItem);
                            // throw new Exception(_cm.GetMessage(201));
                        }

                        // ③商品管理（登録）
                        int totalAddPrice = 0;
                        foreach (StockDetail stockDetail in addStockDetails)
                        {
                            // 追加合計金額計算
                            totalAddPrice += stockDetail.Price;

                            // 追加
                            db.StockDetails.Add(stockDetail);
                            db.Entry(stockDetail).State = EntityState.Added;
                        }

                        // ④リスト管理（個数増加）
                        if (receivingStockListId != -1)
                        {
                            try
                            {
                                stockList = db.StockLists.Single(m => m.StockListId == receivingStockListId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundStockList, ex);
                                // throw new Exception(_cm.GetMessage(119), ex);
                            }

                            // 在庫数増加
                            stockList.Pcs += addStockDetails.Count();

                            // 合計値段増加
                            stockList.TotalPrice += totalAddPrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければエラーメッセージ
                        else
                        {
                            throw new Exception(Messages.notFoundItem);
                            // throw new Exception(_cm.GetMessage(201));
                        }

                        // ⑤コードカウンターインクリメント（入庫番号）
                        CodeCounter codeCounterStock = db.CodeCounters.Single(m => m.CodeId == Constants.stockNo);
                        codeCounterStock.Counter += 1;
                        db.Entry(codeCounterStock).State = EntityState.Modified;

                        // ⑥トランザクション登録
                        db.Stocks.Add(regStock);
                        db.Entry(regStock).State = EntityState.Added;

                        // ⑦コードカウンターインクリメント（トランザクション番号）
                        CodeCounter codeCounterTranz = db.CodeCounters.Single(m => m.CodeId == Constants.transactionNo);
                        codeCounterTranz.Counter += 1;
                        db.Entry(codeCounterTranz).State = EntityState.Modified;

                        // db更新
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            throw new Exception(Messages.errorConflict, ex);
                            // throw new Exception(_cm.GetMessage(100), ex);
                        }
                        // トランザクション正常終了
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new Exception("トランザクション処理に失敗しました。");
                    }
                }
            }
        }

        // 更新（入庫）
        public void UpdateReceiveProcess(List<OrderDetail> orderDetails, Stock regStock, int issuingStockListId, int receivingStockListId, List<StockDetail> removeStockDetails, List<StockDetail> addStockDetails)
        {
            StockList stockList;
            using (var db = new SalesDbContext())
            {
                // トランザクション処理
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // ①商品管理（削除）
                        int totalRemovePrice = 0;
                        try
                        {
                            foreach (StockDetail stockDetail in removeStockDetails)
                            {
                                StockDetail sd = db.StockDetails.Single(m => m.StockDetailId == stockDetail.StockDetailId);

                                // 削除合計金額計算
                                totalRemovePrice += sd.Price;

                                // 削除
                                db.StockDetails.Remove(sd);
                                db.Entry(sd).State = EntityState.Deleted;
                            }
                        }
                        catch
                        {
                            throw new Exception(Messages.errorNotFoundStockDetail);
                            // throw new Exception(_cm.GetMessage(120), ex);
                        }

                        // ②リスト管理（個数減少）
                        // 商品登録が有れば個数減少
                        if (issuingStockListId != -1)
                        {
                            try
                            {
                                stockList = db.StockLists.Single(x => x.StockListId == issuingStockListId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundStockList, ex);
                                // throw new Exception(_cm.GetMessage(119), ex);
                            }

                            // 在庫数減少
                            stockList.Pcs -= removeStockDetails.Count();

                            // 合計値段減少
                            stockList.TotalPrice -= totalRemovePrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければエラーメッセージ
                        else
                        {
                            throw new Exception(Messages.notFoundItem);
                            // throw new Exception(_cm.GetMessage(201));
                        }

                        // ③発注完了時完了フラグセット
                        foreach (OrderDetail regOrderDetail in orderDetails)
                        {
                            OrderDetail orderDetail;
                            try
                            {
                                orderDetail = db.OrderDetails.Single(x => x.OrderDetailId == regOrderDetail.OrderDetailId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundOrder, ex);
                                // throw new Exception(_cm.GetMessage(120), ex);
                            }
                            orderDetail.Stored = regOrderDetail.Stored;

                            db.Entry(orderDetail).State = EntityState.Modified;
                        }

                        // ④商品管理（登録）
                        int totalAddPrice = 0;
                        foreach (StockDetail stockDetail in addStockDetails)
                        {
                            // 追加合計金額計算
                            totalAddPrice += stockDetail.Price;

                            // 追加
                            db.StockDetails.Add(stockDetail);
                            db.Entry(stockDetail).State = EntityState.Added;
                        }

                        // ⑤リスト管理（個数増加）
                        // 商品登録が有れば個数増加
                        if (receivingStockListId != -1)
                        {
                            try
                            {
                                stockList = db.StockLists.Single(m => m.StockListId == receivingStockListId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundStockList, ex);
                                // throw new Exception(_cm.GetMessage(119), ex);
                            }

                            // 在庫数増加
                            stockList.Pcs += addStockDetails.Count();

                            // 合計値段増加
                            stockList.TotalPrice += totalAddPrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければエラーメッセージ
                        else
                        {
                            throw new Exception(Messages.notFoundItem);
                            // throw new Exception(_cm.GetMessage(201));
                        }

                        // ⑥トランザクション更新
                        Stock stock = db.Stocks.Single(x => x.StockId == regStock.StockId);
                        stock.TransactionNo = regStock.TransactionNo;
                        stock.Operation = regStock.Operation;
                        stock.StorageNo = regStock.StorageNo;
                        stock.OperationDateTime = regStock.OperationDateTime;
                        stock.ShopsId = regStock.ShopsId;
                        stock.DestinationShopsId = regStock.DestinationShopsId;
                        stock.ItemsId = regStock.ItemsId;
                        stock.Quantity = regStock.Quantity;
                        stock.UnitsId = regStock.UnitsId;
                        stock.Price = regStock.Price;
                        stock.TotalPrice = regStock.TotalPrice;
                        stock.TaxsId = regStock.TaxsId;
                        stock.VoucherNo = regStock.VoucherNo;
                        stock.Comments = regStock.Comments;
                        stock.Status = regStock.Status;
                        stock.Timestamp = regStock.Timestamp;

                        db.Entry(stock).State = EntityState.Modified;

                        // db更新
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            throw new Exception(Messages.errorConflict, ex);
                            // throw new Exception(_cm.GetMessage(100), ex);
                        }
                        // トランザクション正常終了
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new Exception("トランザクション処理に失敗しました。");
                    }
                }
            }
        }

        // 更新（出庫）
        public void UpdateIssueProcess(Stock regStock, int receivingStockListId, int issuingStockListId, List<StockDetail> addStockDetails, List<StockDetail> removeStockDetails)
        {
            using (var db = new SalesDbContext())
            {
                // トランザクション処理
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // ①商品管理（登録）
                        int totalAddPrice = 0;
                        foreach (StockDetail stockDetail in addStockDetails)
                        {
                            // 追加合計金額計算
                            totalAddPrice += stockDetail.Price;

                            // 追加
                            db.StockDetails.Add(stockDetail);
                            db.Entry(stockDetail).State = EntityState.Added;
                        }

                        // ②リスト管理（個数増加）
                        StockList stockList;
                        try
                        {
                            stockList = db.StockLists.Single(m => m.StockListId == receivingStockListId);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(Messages.errorNotFoundStockList, ex);
                            // throw new Exception(_cm.GetMessage(119), ex);
                        }

                        // 在庫数増加
                        stockList.Pcs += addStockDetails.Count();

                        // 合計値段増加
                        stockList.TotalPrice += totalAddPrice;

                        db.Entry(stockList).State = EntityState.Modified;

                        // ③商品管理（削除）
                        int totalRemovePrice = 0;
                        foreach (StockDetail stockDetail in removeStockDetails)
                        {
                            StockDetail sd = db.StockDetails.Single(m => m.StockDetailId == stockDetail.StockDetailId);

                            // 削除合計金額計算
                            totalRemovePrice += sd.Price;

                            // 削除
                            db.StockDetails.Remove(sd);
                            db.Entry(sd).State = EntityState.Deleted;
                        }

                        // ④リスト管理（個数減少）
                        // 商品登録が有れば個数減少
                        if (issuingStockListId != -1)
                        {
                            try
                            {
                                stockList = db.StockLists.Single(x => x.StockListId == issuingStockListId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundStockList, ex);
                                // throw new Exception(_cm.GetMessage(119), ex);
                            }

                            // 在庫数減少
                            stockList.Pcs -= removeStockDetails.Count();

                            // 合計値段減少
                            stockList.TotalPrice -= totalRemovePrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければエラーメッセージ
                        else
                        {
                            throw new Exception(Messages.notFoundItem);
                            // throw new Exception(_cm.GetMessage(201));
                        }

                        // ⑤トランザクション更新
                        Stock stock = db.Stocks.Single(x => x.StockId == regStock.StockId);
                        stock.TransactionNo = regStock.TransactionNo;
                        stock.Operation = regStock.Operation;
                        stock.StorageNo = regStock.StorageNo;
                        stock.OperationDateTime = regStock.OperationDateTime;
                        stock.ShopsId = regStock.ShopsId;
                        stock.DestinationShopsId = regStock.DestinationShopsId;
                        stock.ItemsId = regStock.ItemsId;
                        stock.Quantity = regStock.Quantity;
                        stock.UnitsId = regStock.UnitsId;
                        stock.Price = regStock.Price;
                        stock.TotalPrice = regStock.TotalPrice;
                        stock.TaxsId = regStock.TaxsId;
                        stock.VoucherNo = regStock.VoucherNo;
                        stock.Comments = regStock.Comments;
                        stock.Status = regStock.Status;
                        stock.Timestamp = regStock.Timestamp;

                        db.Entry(stock).State = EntityState.Modified;


                        // db更新
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            throw new Exception(Messages.errorConflict, ex);
                            // throw new Exception(_cm.GetMessage(100), ex);
                        }
                        // トランザクション正常終了
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new Exception("トランザクション処理に失敗しました。");
                    }
                }
            }
        }

        // 更新（移動）
        public void UpdateMoveProcess(Stock regStock, int issuingStockListId, int receivingStockListId, int destinationShopId, List<StockDetail> removeStockDetails, List<StockDetail> addStockDetails, int nIssuingStockListId, int nReceivingStockListId, int nDestinationShopId, List<StockDetail> nRemoveStockDetails, List<StockDetail> nAddStockDetails)
        {
            StockList stockList;
            using (var db = new SalesDbContext())
            {
                // トランザクション処理
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // ①商品管理（削除）
                        int totalRemovePrice = 0;
                        try
                        {
                            foreach (StockDetail stockDetail in removeStockDetails)
                            {
                                StockDetail sd = db.StockDetails.Single(m => m.StockDetailId == stockDetail.StockDetailId);

                                // 削除合計金額計算
                                totalRemovePrice += sd.Price;

                                // 削除
                                db.StockDetails.Remove(sd);
                                db.Entry(sd).State = EntityState.Deleted;
                            }
                        }
                        catch
                        {
                            throw new Exception(Messages.errorNotFoundStockDetail);
                            // throw new Exception(_cm.GetMessage(120), ex);
                        }

                        // ②リスト管理（個数減少）
                        // 商品登録が有れば個数減少
                        if (issuingStockListId != -1)
                        {
                            try
                            {
                                stockList = db.StockLists.Single(x => x.StockListId == issuingStockListId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundStockList, ex);
                                // throw new Exception(_cm.GetMessage(119), ex);
                            }

                            // 在庫数減少
                            stockList.Pcs -= removeStockDetails.Count();

                            // 合計値段減少
                            stockList.TotalPrice -= totalRemovePrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければエラーメッセージ
                        else
                        {
                            throw new Exception(Messages.notFoundItem);
                            // throw new Exception(_cm.GetMessage(201));
                        }

                        // ③商品管理（登録）
                        int totalAddPrice = 0;
                        foreach (StockDetail stockDetail in addStockDetails)
                        {
                            // 追加合計金額計算
                            totalAddPrice += stockDetail.Price;

                            // 追加（削除したものを復旧するため在庫番号を負に反転：新たに追加したものだけに在庫番号を振る）
                            stockDetail.StorageNo = -stockDetail.StorageNo;
                            db.StockDetails.Add(stockDetail);
                            db.Entry(stockDetail).State = EntityState.Added;
                        }

                        // ④リスト管理（個数増加）
                        // 商品登録が有れば個数減少
                        if (issuingStockListId != -1)
                        {
                            try
                            {
                                stockList = db.StockLists.Single(m => m.StockListId == receivingStockListId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundStockList, ex);
                                // throw new Exception(_cm.GetMessage(119), ex);
                            }

                            // 在庫数増加
                            stockList.Pcs += addStockDetails.Count();

                            // 合計値段増加
                            stockList.TotalPrice += totalAddPrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければエラーメッセージ
                        else
                        {
                            throw new Exception(Messages.notFoundItem);
                            // throw new Exception(_cm.GetMessage(201));
                        }

                        // 新たに登録
                        // ①商品管理（削除）
                        int nTotalRemovePrice = 0;
                        foreach (StockDetail stockDetail in nRemoveStockDetails)
                        {
                            StockDetail sd = db.StockDetails.Single(m => m.StockDetailId == stockDetail.StockDetailId);

                            // 削除合計金額計算
                            nTotalRemovePrice += sd.Price;

                            // 削除
                            db.StockDetails.Remove(sd);
                            db.Entry(sd).State = EntityState.Deleted;
                        }

                        // ②リスト管理（個数減少）
                        // 商品登録が有れば個数減少
                        if (nIssuingStockListId != -1)
                        {
                            try
                            {
                                stockList = db.StockLists.Single(m => m.StockListId == nIssuingStockListId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundStockList, ex);
                                // throw new Exception(_cm.GetMessage(119), ex);
                            }

                            // 在庫数減少
                            stockList.Pcs -= nRemoveStockDetails.Count();

                            // 合計値段減少
                            stockList.TotalPrice -= nTotalRemovePrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければエラーメッセージ
                        else
                        {
                            throw new Exception(Messages.notFoundItem);
                            // throw new Exception(_cm.GetMessage(201));
                        }

                        // ③商品管理（登録）
                        int nTotalAddPrice = 0;
                        foreach (StockDetail stockDetail in nAddStockDetails)
                        {
                            // 追加合計金額計算
                            nTotalAddPrice += stockDetail.Price;

                            // 追加
                            db.StockDetails.Add(stockDetail);
                            db.Entry(stockDetail).State = EntityState.Added;
                        }

                        // ④リスト管理（個数増加）
                        if (nReceivingStockListId != -1)
                        {
                            try
                            {
                                stockList = db.StockLists.Single(m => m.StockListId == nReceivingStockListId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundStockList, ex);
                                // throw new Exception(_cm.GetMessage(119), ex);
                            }

                            // 在庫数増加
                            stockList.Pcs += nAddStockDetails.Count();

                            // 合計値段増加
                            stockList.TotalPrice += nTotalAddPrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければエラーメッセージ
                        else
                        {
                            throw new Exception(Messages.notFoundItem);
                            // throw new Exception(_cm.GetMessage(201));
                        }

                        // ⑤トランザクション更新
                        Stock stock = db.Stocks.Single(x => x.StockId == regStock.StockId);
                        stock.TransactionNo = regStock.TransactionNo;
                        stock.Operation = regStock.Operation;
                        stock.StorageNo = regStock.StorageNo;
                        stock.OperationDateTime = regStock.OperationDateTime;
                        stock.ShopsId = regStock.ShopsId;
                        stock.DestinationShopsId = regStock.DestinationShopsId;
                        stock.ItemsId = regStock.ItemsId;
                        stock.Quantity = regStock.Quantity;
                        stock.UnitsId = regStock.UnitsId;
                        stock.Price = regStock.Price;
                        stock.TotalPrice = regStock.TotalPrice;
                        stock.TaxsId = regStock.TaxsId;
                        stock.VoucherNo = regStock.VoucherNo;
                        stock.Comments = regStock.Comments;
                        stock.Status = regStock.Status;
                        stock.Timestamp = regStock.Timestamp;

                        db.Entry(stock).State = EntityState.Modified;

                        // db更新
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            throw new Exception(Messages.errorConflict, ex);
                            // throw new Exception(_cm.GetMessage(100), ex);
                        }
                        // トランザクション正常終了
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new Exception("トランザクション処理に失敗しました。");
                    }
                }
            }
        }

        // 削除（入庫）
        public void DeleteReceiveProcess(List<OrderDetail> orderDetails, Stock regStock, int regStockListId, List<StockDetail> removeStockDetails)
        {
            using (var db = new SalesDbContext())
            {
                // トランザクション処理
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // ①商品管理（削除）
                        int totalRemovePrice = 0;
                        foreach (StockDetail stockDetail in removeStockDetails)
                        {
                            StockDetail sd = db.StockDetails.Single(m => m.StockDetailId == stockDetail.StockDetailId);

                            // 削除合計金額計算
                            totalRemovePrice += sd.Price;

                            // 削除
                            db.StockDetails.Remove(sd);
                            db.Entry(sd).State = EntityState.Deleted;
                        }

                        // ②リスト管理（個数減少）
                        // 商品登録が有れば個数減少
                        if (regStockListId != -1)
                        {
                            StockList stockList;
                            try
                            {
                                stockList = db.StockLists.Single(x => x.StockListId == regStockListId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundStockList, ex);
                                // throw new Exception(_cm.GetMessage(119), ex);
                            }

                            // 在庫数減少
                            stockList.Pcs -= removeStockDetails.Count();

                            // 合計値段減少
                            stockList.TotalPrice -= totalRemovePrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければエラーメッセージ
                        else
                        {
                            throw new Exception(Messages.notFoundItem);
                            // throw new Exception(_cm.GetMessage(201));
                        }

                        // ③発注完了時完了フラグセット
                        foreach (OrderDetail regOrderDetail in orderDetails)
                        {
                            OrderDetail orderDetail;
                            try
                            {
                                orderDetail = db.OrderDetails.Single(x => x.OrderDetailId == regOrderDetail.OrderDetailId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundOrder, ex);
                                // throw new Exception(_cm.GetMessage(120), ex);
                            }
                            orderDetail.OrderDetailNo = regOrderDetail.OrderDetailNo;
                            orderDetail.ItemsId = regOrderDetail.ItemsId;
                            orderDetail.Quantity = regOrderDetail.Quantity;
                            orderDetail.UnitsId = regOrderDetail.UnitsId;
                            orderDetail.Price = regOrderDetail.Price;
                            orderDetail.TotalPrice = regOrderDetail.TotalPrice;
                            orderDetail.VoucherNo = regOrderDetail.VoucherNo;
                            orderDetail.Stored = regOrderDetail.Stored;
                            orderDetail.Comments = regOrderDetail.Comments;
                            orderDetail.Status = regOrderDetail.Status;
                            orderDetail.Timestamp = regOrderDetail.Timestamp;

                            db.Entry(orderDetail).State = EntityState.Modified;
                        }

                        // ④トランザクション削除
                        // 削除
                        Stock stock;
                        try
                        {
                            stock = db.Stocks.Single(m => m.StockId == regStock.StockId);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(Messages.errorNotFoundStock, ex);
                            // throw new Exception(_cm.GetMessage(118), ex);
                        }
                        db.Stocks.Remove(stock);
                        db.Entry(stock).State = EntityState.Deleted;

                        // db更新
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            throw new Exception(Messages.errorConflict, ex);
                            // throw new Exception(_cm.GetMessage(100), ex);
                        }
                        // トランザクション正常終了
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new Exception("トランザクション処理に失敗しました。");
                    }
                }
            }
        }

        // 削除（出庫）
        public void DeleteIssueProcess(List<OrderDetail> orderDetails, Stock regStock, int receivingStockListId, List<StockDetail> addStockDetails)
        {
            using (var db = new SalesDbContext())
            {
                // トランザクション処理
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // ①商品管理（登録）
                        int totalAddPrice = 0;
                        foreach (StockDetail stockDetail in addStockDetails)
                        {
                            // 追加合計金額計算
                            totalAddPrice += stockDetail.Price;

                            // 追加
                            db.StockDetails.Add(stockDetail);
                            db.Entry(stockDetail).State = EntityState.Added;
                        }

                        // ②リスト管理（個数増加）
                        StockList stockList;
                        try
                        {
                            stockList = db.StockLists.Single(m => m.StockListId == receivingStockListId);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(Messages.errorNotFoundStockList, ex);
                            // throw new Exception(_cm.GetMessage(119), ex);
                        }
                        stockList.Pcs += addStockDetails.Count();
                        stockList.TotalPrice += totalAddPrice;

                        db.Entry(stockList).State = EntityState.Modified;


                        // ③発注完了時完了フラグセット
                        foreach (OrderDetail regOrderDetail in orderDetails)
                        {
                            OrderDetail orderDetail;
                            try
                            {
                                orderDetail = db.OrderDetails.Single(x => x.OrderDetailId == regOrderDetail.OrderDetailId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundOrder, ex);
                                // throw new Exception(_cm.GetMessage(120), ex);
                            }
                            orderDetail.OrderDetailNo = regOrderDetail.OrderDetailNo;
                            orderDetail.ItemsId = regOrderDetail.ItemsId;
                            orderDetail.Quantity = regOrderDetail.Quantity;
                            orderDetail.UnitsId = regOrderDetail.UnitsId;
                            orderDetail.Price = regOrderDetail.Price;
                            orderDetail.TotalPrice = regOrderDetail.TotalPrice;
                            orderDetail.VoucherNo = regOrderDetail.VoucherNo;
                            orderDetail.Stored = regOrderDetail.Stored;
                            orderDetail.Comments = regOrderDetail.Comments;
                            orderDetail.Status = regOrderDetail.Status;
                            orderDetail.Timestamp = regOrderDetail.Timestamp;

                            db.Entry(orderDetail).State = EntityState.Modified;
                        }

                        // ④トランザクション削除
                        // 削除
                        Stock stock;
                        try
                        {
                            stock = db.Stocks.Single(m => m.StockId == regStock.StockId);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(Messages.errorNotFoundStock, ex);
                            // throw new Exception(_cm.GetMessage(118), ex);
                        }
                        db.Stocks.Remove(stock);
                        db.Entry(stock).State = EntityState.Deleted;

                        // db更新
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            throw new Exception(Messages.errorConflict, ex);
                            // throw new Exception(_cm.GetMessage(100), ex);
                        }
                        // トランザクション正常終了
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new Exception("トランザクション処理に失敗しました。");
                    }
                }
            }
        }

        // 削除（移動）
        public void DeleteMoveProcess(Stock regStock, int issuingStockListId, int receivingStockListId, int destinationShopId, List<StockDetail> removeStockDetails, List<StockDetail> addStockDetails)
        {
            StockList stockList;
            using (var db = new SalesDbContext())
            {
                // トランザクション処理
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // ①商品管理（削除）
                        int totalRemovePrice = 0;
                        try
                        {
                            foreach (StockDetail stockDetail in removeStockDetails)
                            {
                                StockDetail sd = db.StockDetails.Single(m => m.StockDetailId == stockDetail.StockDetailId);

                                // 削除合計金額計算
                                totalRemovePrice += sd.Price;

                                // 削除
                                db.StockDetails.Remove(sd);
                                db.Entry(sd).State = EntityState.Deleted;
                            }
                        }
                        catch
                        {
                            throw new Exception(Messages.errorNotFoundStockDetail);
                            // throw new Exception(_cm.GetMessage(120), ex);
                        }

                        // ②リスト管理（個数減少）
                        // 商品登録が有れば個数減少
                        if (issuingStockListId != -1)
                        {
                            try
                            {
                                stockList = db.StockLists.Single(x => x.StockListId == issuingStockListId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundStockList, ex);
                                // throw new Exception(_cm.GetMessage(119), ex);
                            }

                            // 在庫数減少
                            stockList.Pcs -= removeStockDetails.Count();

                            // 合計値段減少
                            stockList.TotalPrice -= totalRemovePrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければエラーメッセージ
                        else
                        {
                            throw new Exception(Messages.notFoundItem);
                            // throw new Exception(_cm.GetMessage(201));
                        }

                        // ③商品管理（登録）
                        int totalAddPrice = 0;
                        foreach (StockDetail stockDetail in addStockDetails)
                        {
                            // 追加合計金額計算
                            totalAddPrice += stockDetail.Price;

                            // 追加（削除したものを復旧するため在庫番号を負に反転：新たに追加したものだけに在庫番号を振る）
                            stockDetail.StorageNo = -stockDetail.StorageNo;
                            db.StockDetails.Add(stockDetail);
                            db.Entry(stockDetail).State = EntityState.Added;
                        }

                        // ④リスト管理（個数増加）
                        // 商品登録が有れば個数減少
                        if (issuingStockListId != -1)
                        {
                            try
                            {
                                stockList = db.StockLists.Single(m => m.StockListId == receivingStockListId);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(Messages.errorNotFoundStockList, ex);
                                // throw new Exception(_cm.GetMessage(119), ex);
                            }

                            // 在庫数増加
                            stockList.Pcs += addStockDetails.Count();

                            // 合計値段増加
                            stockList.TotalPrice += totalAddPrice;

                            db.Entry(stockList).State = EntityState.Modified;
                        }

                        // 商品登録が無ければエラーメッセージ
                        else
                        {
                            throw new Exception(Messages.notFoundItem);
                            // throw new Exception(_cm.GetMessage(201));
                        }

                        // ⑤トランザクション削除
                        // 削除
                        Stock stock;
                        try
                        {
                            stock = db.Stocks.Single(m => m.StockId == regStock.StockId);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(Messages.errorNotFoundStock, ex);
                            // throw new Exception(_cm.GetMessage(118), ex);
                        }
                        db.Stocks.Remove(stock);
                        db.Entry(stock).State = EntityState.Deleted;

                        // db更新
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            throw new Exception(Messages.errorConflict, ex);
                            // throw new Exception(_cm.GetMessage(100), ex);
                        }
                        // トランザクション正常終了
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new Exception("トランザクション処理に失敗しました。");
                    }
                }
            }
        }

        // ログデータ作成
        // in       regStock : ログ対象データ
        // out      string   : ログ文字列
        private string StockLogData(Stock regStock)
        {
            string operationDateTime = string.Empty;
            if (regStock.OperationDateTime != null) operationDateTime = regStock.OperationDateTime.Value.ToShortDateString();

            string shop;
            string destinationShop;
            string item;
            string unit;
            string tax;
            using (var db = new SalesDbContext())
            {
                try
                {
                    shop = (regStock.ShopsId != -1) ? db.Shops.Single(m => m.ShopCode == regStock.ShopsId).ShopName : string.Empty;

                    // 無効表示
                    if (db.Shops.Single(m => m.ShopCode == regStock.ShopsId).Status != 0) shop = "[" + shop + "]";
                }
                catch
                {
                    shop = string.Empty;
                }

                try
                {
                    destinationShop = (regStock.DestinationShopsId != -1) ? db.Shops.Single(m => m.ShopCode == regStock.DestinationShopsId).ShopName : string.Empty;

                    // 無効表示
                    if (db.Shops.Single(m => m.ShopCode == regStock.DestinationShopsId).Status != 0) destinationShop = "[" + destinationShop + "]";
                }
                catch
                {
                    destinationShop = string.Empty;
                }

                try
                {
                    item = (regStock.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == regStock.ItemsId).ItemName : string.Empty;

                    // 無効表示
                    if (db.Items.Single(m => m.ItemCode == regStock.ItemsId).Status != 0) item = "[" + item + "]";
                }
                catch
                {
                    item = string.Empty;
                }

                try
                {
                    unit = (regStock.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == regStock.UnitsId).UnitName : string.Empty;

                    // 無効表示
                    if (db.Units.Single(m => m.UnitCode == regStock.UnitsId).Status != 0) unit = "[" + unit + "]";
                }
                catch
                {
                    unit = string.Empty;
                }

                try
                {
                    tax = (regStock.TaxsId != -1) ? db.Taxs.Single(m => m.TaxCode == regStock.TaxsId).TaxValue.ToString() : string.Empty;

                    // 無効表示
                    if (db.Taxs.Single(m => m.TaxCode == regStock.TaxsId).Status != 0) tax = "[" + tax + "]";
                }
                catch
                {
                    tax = string.Empty;
                }
            }

            return regStock.StockId.ToString() + ", " +
            regStock.TransactionNo.ToString() + ", " +
            StaticCommon.ConvertToString(11, regStock.Operation) + ", " +
            regStock.StorageNo.ToString() + ", " +
            operationDateTime + ", " +
            shop + ", " +
            destinationShop + ", " +
            item + ", " +
            regStock.Quantity.ToString() + ", " +
            unit + ", " +
            regStock.Price + ", " +
            regStock.TotalPrice + ", " +
            tax + ", " +
            regStock.VoucherNo + ", " +
            regStock.Comments + ", " +
            StaticCommon.ConvertToString(1, regStock.Status);
        }
    }
}
