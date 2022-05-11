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
    // 売上明細管理　データ処理クラス
    class SaleDetailContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private CommonFunction _cm = new CommonFunction();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得（配列）
        public IEnumerable<SaleDetail> GetSaleDetails()
        {
            using (var db = new SalesDbContext()) return db.SaleDetails.ToList();
        }

        // 売上番号指定　売上明細データ数取得
        // in  : saleNo　　　　：売上番号
        // out : saleDetailデータ数
        public int GetSaleDetailCountsByNo(int saleNo)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.SaleDetails.Where(m => m.SaleNo == saleNo).Count();
            }
            catch
            {
                return 0;
                // throw new Exception(Messages.errorNotFoundSaleDetail);
            }
        }

        // データ取得
        // in  : saleNo　　　　：売上番号
        //       saleDetailNo　：売上明細番号
        // out : saleDetailデータ
        public SaleDetail GetSaleDetail(int saleNo, int saleDetailNo)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.SaleDetails.Single(m => m.SaleNo == saleNo && m.SaleDetailNo == saleDetailNo);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundSaleDetail);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<DispSale> GetDispSaleDetails()
        {
            // リターン用リスト
            List<DispSale> dispSales = new List<DispSale>();

            using (var db = new SalesDbContext())
            {
                foreach (SaleDetail saleDetail in db.SaleDetails)
                {
                    Sale sale = db.Sales.Single(m => m.SaleNo == saleDetail.SaleNo);

                    string shop;
                    try
                    {
                        shop = (sale.SaleShopsId != -1) ? db.Shops.Single(m => m.ShopCode == sale.SaleShopsId).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == sale.SaleShopsId).Status != 0) shop = "[" + shop + "]";
                    }
                    catch
                    {
                        shop = string.Empty;
                    }

                    string staff;
                    try
                    {
                        staff = (sale.PersonInChargesId != -1) ? db.Staffs.Single(m => m.StaffCode == sale.PersonInChargesId).StaffName : string.Empty;

                        // 無効表示
                        if (db.Staffs.Single(m => m.StaffCode == sale.PersonInChargesId).Status != 0) staff = "[" + staff + "]";
                    }
                    catch
                    {
                        staff = string.Empty;
                    }

                    string item;
                    try
                    {
                        item = (saleDetail.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == saleDetail.ItemsId).ItemName : string.Empty;

                        // 無効表示
                        if (db.Items.Single(m => m.ItemCode == saleDetail.ItemsId).Status != 0) item = "[" + item + "]";
                    }
                    catch
                    {
                        item = string.Empty;
                    }

                    string unit;
                    try
                    {
                        unit = (saleDetail.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == saleDetail.UnitsId).UnitName : string.Empty;

                        // 無効表示
                        if (db.Units.Single(m => m.UnitCode == saleDetail.UnitsId).Status != 0) unit = "[" + unit + "]";
                    }
                    catch
                    {
                        unit = string.Empty;
                    }

                    string tax;
                    try
                    {
                        tax = (sale.TaxsId != -1) ? db.Taxs.Single(m => m.TaxCode == sale.TaxsId).TaxValue.ToString() : string.Empty;

                        // 無効表示
                        if (db.Taxs.Single(m => m.TaxCode == sale.TaxsId).Status != 0) tax = "[" + tax + "]";
                    }
                    catch
                    {
                        tax = string.Empty;
                    }

                    dispSales.Add(new DispSale()
                    {
                        SaleId = sale.SaleId,
                        SaleNo = sale.SaleNo,
                        SaleShop = shop,
                        PersonInCharge = staff,
                        ReceiptNo1 = sale.ReceiptNo1,
                        SaleDetailNo = saleDetail.SaleDetailNo,
                        Item = item,
                        Quantity = saleDetail.Quantity.ToString(),
                        Unit = unit,
                        Price = String.Format("{0:#,0}", saleDetail.Price),
                        TotalPrice = String.Format("{0:#,0}", saleDetail.TotalPrice),
                        Tax = tax,
                        SaleDateTime = sale.SaleDateTime,
                        ReceiptNo2 = saleDetail.ReceiptNo2,
                        StockManagementInfo = StaticCommon.ConvertToString(10, sale.StockManagementInfo),
                        LockInfo = StaticCommon.ConvertToString(9, sale.LockInfo),
                        Comments = sale.Comments,
                        Status = StaticCommon.ConvertToString(1, sale.Status),
                        Timestamp = sale.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispSale> sortableDispSale = new SortableBindingList<DispSale>(dispSales);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "SaleDetail",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispSale;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        //      dispSale : 表示用データリスト
        public IEnumerable<DispSale> GetDispSales(int startRec, int endRec)
        {
            // リターン用リスト
            List<DispSale> dispSales = new List<DispSale>();

            using (var db = new SalesDbContext())
            {
                int count = 0;
                foreach (SaleDetail saleDetail in db.SaleDetails)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    Sale sale = db.Sales.Single(m => m.SaleNo == saleDetail.SaleNo);

                    string shop;
                    try
                    {
                        shop = (sale.SaleShopsId != -1) ? db.Shops.Single(m => m.ShopCode == sale.SaleShopsId).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == sale.SaleShopsId).Status != 0) shop = "[" + shop + "]";
                    }
                    catch
                    {
                        shop = string.Empty;
                    }

                    string staff;
                    try
                    {
                        staff = (sale.PersonInChargesId != -1) ? db.Staffs.Single(m => m.StaffCode == sale.PersonInChargesId).StaffName : string.Empty;

                        // 無効表示
                        if (db.Staffs.Single(m => m.StaffCode == sale.PersonInChargesId).Status != 0) staff = "[" + staff + "]";
                    }
                    catch
                    {
                        staff = string.Empty;
                    }

                    string item;
                    try
                    {
                        item = (saleDetail.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == saleDetail.ItemsId).ItemName : string.Empty;

                        // 無効表示
                        if (db.Items.Single(m => m.ItemCode == saleDetail.ItemsId).Status != 0) item = "[" + item + "]";
                    }
                    catch
                    {
                        item = string.Empty;
                    }

                    string unit;
                    try
                    {
                        unit = (saleDetail.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == saleDetail.UnitsId).UnitName : string.Empty;

                        // 無効表示
                        if (db.Units.Single(m => m.UnitCode == saleDetail.UnitsId).Status != 0) unit = "[" + unit + "]";
                    }
                    catch
                    {
                        unit = string.Empty;
                    }

                    string tax;
                    try
                    {
                        tax = (sale.TaxsId != -1) ? db.Taxs.Single(m => m.TaxCode == sale.TaxsId).TaxValue.ToString() : string.Empty;

                        // 無効表示
                        if (db.Taxs.Single(m => m.TaxCode == sale.TaxsId).Status != 0) tax = "[" + tax + "]";
                    }
                    catch
                    {
                        tax = string.Empty;
                    }

                    dispSales.Add(new DispSale()
                    {
                        SaleId = sale.SaleId,
                        SaleNo = sale.SaleNo,
                        SaleShop = shop,
                        PersonInCharge = staff,
                        ReceiptNo1 = sale.ReceiptNo1,
                        SaleDetailNo = saleDetail.SaleDetailNo,
                        Item = item,
                        Quantity = saleDetail.Quantity.ToString(),
                        Unit = unit,
                        Price = String.Format("{0:#,0}", saleDetail.Price),
                        TotalPrice = String.Format("{0:#,0}", saleDetail.TotalPrice),
                        Tax = tax,
                        SaleDateTime = sale.SaleDateTime,
                        ReceiptNo2 = saleDetail.ReceiptNo2,
                        StockManagementInfo = StaticCommon.ConvertToString(10, sale.StockManagementInfo),
                        LockInfo = StaticCommon.ConvertToString(9, sale.LockInfo),
                        Comments = sale.Comments,
                        Status = StaticCommon.ConvertToString(1, sale.Status),
                        Timestamp = sale.Timestamp
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispSale> sortableDispSale = new SortableBindingList<DispSale>(dispSales);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "SaleDetail",
                    Command = "GetPartial",
                    Data = "StartRec=" + startRec.ToString() + ":EndRec=" + endRec.ToString() ,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispSale;
            }
        }

        // データ追加
        // in   : SaleDetailデータ
        public void PostSaleDetail(SaleDetail regSaleDetail)
        {
            using (var db = new SalesDbContext())
            {
                db.SaleDetails.Add(regSaleDetail);
                db.Entry(regSaleDetail).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "SaleDetail",
                Command = "Post",
                Data = SaleDetailLogData(regSaleDetail),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : SaleDetailデータ
        public void PutSaleDetail(SaleDetail regSaleDetail)
        {
            using (var db = new SalesDbContext())
            {
                SaleDetail saleDetail;
                try
                {
                    saleDetail = db.SaleDetails.Single(x => x.SaleDetailId == regSaleDetail.SaleDetailId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundSale, ex);
                    // throw new Exception(_cm.GetMessage(112), ex);
                }
                saleDetail.SaleDetailNo = regSaleDetail.SaleDetailNo;
                saleDetail.ItemsId = regSaleDetail.ItemsId;
                saleDetail.Quantity = regSaleDetail.Quantity;
                saleDetail.UnitsId = regSaleDetail.UnitsId;
                saleDetail.Price = regSaleDetail.Price;
                saleDetail.TotalPrice = regSaleDetail.TotalPrice;
                saleDetail.ReceiptNo2 = regSaleDetail.ReceiptNo2;
                saleDetail.Comments = regSaleDetail.Comments;
                saleDetail.Status = regSaleDetail.Status;
                saleDetail.Timestamp = regSaleDetail.Timestamp;

                db.Entry(saleDetail).State = EntityState.Modified;
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
                Table = "SaleDetail",
                Command = "Put",
                Data = SaleDetailLogData(regSaleDetail),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ削除
        // in       saleNo       : 削除する売上No
        //          saleDetailNo : 削除する売上明細No
        public void DeleteSaleDetail(int saleNo, int saleDetailNo)
        {
            SaleDetail saleDetail;
            using (var db = new SalesDbContext())
            {
                try
                {
                    saleDetail = db.SaleDetails.Single(m => m.SaleNo == saleNo && m.SaleDetailNo == saleDetailNo);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundSale, ex);
                    // throw new Exception(_cm.GetMessage(112), ex);
                }
                db.SaleDetails.Remove(saleDetail);
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
                Table = "SaleDetail",
                Command = "Delete",
                Data = saleDetailNo.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // ログデータ作成
        // in       regSaleDetail : ログ対象データ
        // out      string        : ログ文字列
        private string SaleDetailLogData(SaleDetail regSaleDetail)
        {
            string item;
            string unit;
            using (var db = new SalesDbContext())
            {
                try
                {
                    item = (regSaleDetail.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == regSaleDetail.ItemsId).ItemName : string.Empty;

                    // 無効表示
                    if (db.Items.Single(m => m.ItemCode == regSaleDetail.ItemsId).Status != 0) item = "[" + item + "]";
                }
                catch
                {
                    item = string.Empty;
                }

                try
                {
                    unit = (regSaleDetail.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == regSaleDetail.UnitsId).UnitName : string.Empty;

                    // 無効表示
                    if (db.Units.Single(m => m.UnitCode == regSaleDetail.UnitsId).Status != 0) unit = "[" + unit + "]";
                }
                catch
                {
                    unit = string.Empty;
                }
            }

            return regSaleDetail.SaleDetailId.ToString() + ", " +
            regSaleDetail.SaleDetailNo.ToString() + ", " +
            item + ", " +
            regSaleDetail.Quantity + ", " +
            unit + ", " +
            regSaleDetail.Price + ", " +
            regSaleDetail.TotalPrice + ", " +
            regSaleDetail.ReceiptNo2 + ", " +
            regSaleDetail.Comments + ", " +
            StaticCommon.ConvertToString(1, regSaleDetail.Status);
        }
    }
}
