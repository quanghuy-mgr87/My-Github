using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SalesManagement.Model.ContentsManagement.Common;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.Entity.Disp;

namespace SalesManagement.Model.ContentsManagement
{
    // 売上管理　データ処理クラス
    public class SaleContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private CommonFunction _cm = new CommonFunction();

        // データベース処理（SaleDetail）
        private SaleDetailContents _sd = new SaleDetailContents();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得（配列）
        public IEnumerable<Sale> GetSales()
        {
            using (var db = new SalesDbContext()) return db.Sales.ToList();
        }

        // データ取得（saleId）
        // in  : saleId
        // out : saleデータ
        public Sale GetSaleById(int saleId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Sales.Single(m => m.SaleId == saleId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundSale);
            }
        }

        // データ取得（saleNo）
        // in  : saleNo
        // out : saleデータ
        public Sale GetSaleByNo(int saleNo)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Sales.Single(m => m.SaleNo == saleNo);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundSale);
            }
        }

        // 在庫未処理判定
        // in  : saleNo
        // out : 在庫処理情報
        public int? IssuedJudge(int saleNo)
        {
            try
            {
                using (var db = new SalesDbContext())
                {
                    return db.Sales.Single(m => m.SaleNo == saleNo).StockManagementInfo;
                }
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundSale);
            }
        }

        // データ取得（最新）
        // out : saleデータ
        public Sale GetLastSale()
        {
            try
            {
                using (var db = new SalesDbContext())
                {
                    long count = db.CodeCounters.Single(m => m.CodeId == Constants.numSale).Counter;
                    return db.Sales.Single(m => m.SaleNo == count);
                }

            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundSale);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<DispSale> GetDispSales()
        {
            List<DispSale> dispSales = _sd.GetDispSaleDetails().ToList();
            Sale sale;

            using (var db = new SalesDbContext())
            {
                foreach (DispSale dispSale in dispSales)
                {
                    // 売上情報取得
                    sale = db.Sales.Single(m => m.SaleNo == dispSale.SaleNo);

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

                    dispSale.SaleId = sale.SaleId;
                    dispSale.SaleNo = sale.SaleNo;
                    dispSale.SaleShop = shop;
                    dispSale.PersonInCharge = staff;
                    dispSale.ReceiptNo1 = sale.ReceiptNo1;
                    dispSale.Tax = tax;
                    dispSale.SaleDateTime = sale.SaleDateTime;
                    dispSale.StockManagementInfo = StaticCommon.ConvertToString(10, sale.StockManagementInfo);
                    dispSale.LockInfo = StaticCommon.ConvertToString(9, sale.LockInfo);
                    dispSale.Comments = sale.Comments;
                    dispSale.Status = StaticCommon.ConvertToString(1, sale.Status);
                    dispSale.Timestamp = sale.Timestamp;
                }

                // ソータブルリスト作成
                SortableBindingList<DispSale> sortableDispSale = new SortableBindingList<DispSale>(dispSales);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Sale",
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
        public IEnumerable<DispSale> GetDispSales(int startRec, int endRec)
        {
            List<DispSale> dispSales = _sd.GetDispSaleDetails().ToList();
            List<DispSale> retDispSales = new List<DispSale>();
            Sale sale;

            using (var db = new SalesDbContext())
            {
                int count = 0;
                foreach (DispSale dispSale in dispSales)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    // 売上情報取得
                    sale = db.Sales.Single(m => m.SaleNo == dispSale.SaleNo);

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

                    retDispSales.Add(new DispSale()
                    {
                        SaleId = sale.SaleId,
                        SaleNo = sale.SaleNo,
                        SaleShop = shop,
                        PersonInCharge = staff,
                        ReceiptNo1 = sale.ReceiptNo1,
                        SaleDetailNo = dispSale.SaleDetailNo,
                        Item = dispSale.Item,
                        Quantity = dispSale.Quantity.ToString(),
                        Unit = dispSale.Unit,
                        Price = String.Format("{0:#,0}", dispSale.Price),
                        TotalPrice = String.Format("{0:#,0}", dispSale.TotalPrice),
                        Tax = tax,
                        SaleDateTime = sale.SaleDateTime,
                        ReceiptNo2 = dispSale.ReceiptNo2,
                        StockManagementInfo = StaticCommon.ConvertToString(10, sale.StockManagementInfo),
                        LockInfo = StaticCommon.ConvertToString(9, sale.LockInfo),
                        Comments = sale.Comments,
                        Status = StaticCommon.ConvertToString(1, sale.Status),
                        Timestamp = sale.Timestamp
                    });

                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispSale> sortableDispSale = new SortableBindingList<DispSale>(retDispSales);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Sale",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispSale;
            }
        }

        // データロック（始点・終点指定）
        //      lockMode : 1 = Lock, 2 = UnLock
        // in   startRec : ロックデータの始点
        //      endRec   : ロックデータの終点
        public void SetLockSales(int lockMode, long startRec, long endRec)
        {
            using (var db = new SalesDbContext())
            {
                foreach (Sale sale in db.Sales)
                {
                    if (sale.SaleNo < startRec) continue;
                    if (endRec < sale.SaleNo) break;

                    if (lockMode == 1) sale.LockInfo = Constants.numLock;
                    else sale.LockInfo = Constants.numUnlock;

                    db.Entry(sale).State = EntityState.Modified;
                }
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
                Table = "Sale",
                Command = "Lock",
                Data = lockMode.ToString() + "," + startRec.ToString() + "," + endRec.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ追加
        // in   : Saleデータ
        public void PostSale(Sale regSale)
        {
            using (var db = new SalesDbContext())
            {
                db.Sales.Add(regSale);
                db.Entry(regSale).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Sale",
                Command = "Post",
                Data = SaleLogData(regSale),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Saleデータ
        public void PutSale(Sale regSale)
        {
            using (var db = new SalesDbContext())
            {
                Sale sale;
                try
                {
                    sale = db.Sales.Single(m => m.SaleId == regSale.SaleId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundSale, ex);
                    // throw new Exception(_cm.GetMessage(112), ex);
                }
                sale.SaleNo = regSale.SaleNo;
                sale.SaleShopsId = regSale.SaleShopsId;
                sale.PersonInChargesId = regSale.PersonInChargesId;
                sale.ReceiptNo1 = regSale.ReceiptNo1;
                sale.TaxsId = regSale.TaxsId;
                sale.SaleDateTime = regSale.SaleDateTime;
                sale.StockManagementInfo = regSale.StockManagementInfo;
                sale.LockInfo = regSale.LockInfo;
                sale.Comments = regSale.Comments;
                sale.Status = regSale.Status;
                sale.Timestamp = regSale.Timestamp;

                db.Entry(sale).State = EntityState.Modified;
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
                Table = "Sale",
                Command = "Put",
                Data = SaleLogData(regSale),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // 在庫処理済設定
        // in  : saleNo
        public void Issued(int saleNo)
        {
            using (var db = new SalesDbContext())
            {
                Sale sale;
                try
                {
                    sale = db.Sales.Single(m => m.SaleNo == saleNo);
                    sale.StockManagementInfo = 1;
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundSale, ex);
                    // throw new Exception(_cm.GetMessage(112), ex);
                }

                db.Entry(sale).State = EntityState.Modified;
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
                Table = "Sale",
                Command = "Put",
                Data = saleNo.ToString() + ":Issued",
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

        }


        // データ削除
        // in       SaleId : 削除する売上Id
        public void DeleteSaleById(int SaleId)
        {
            Sale sale;
            using (var db = new SalesDbContext())
            {
                try
                {
                    sale = db.Sales.Single(m => m.SaleId == SaleId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundSale, ex);
                    // throw new Exception(_cm.GetMessage(112), ex);
                }
                db.Sales.Remove(sale);
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
                Table = "Sale",
                Command = "Delete",
                Data = SaleId.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ削除
        // in       SaleNo : 削除する売上No
        public void DeleteSaleByNo(int saleNo)
        {
            Sale sale;
            using (var db = new SalesDbContext())
            {
                try
                {
                    sale = db.Sales.Single(m => m.SaleNo == saleNo);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundSale, ex);
                    // throw new Exception(_cm.GetMessage(112), ex);
                }
                db.Sales.Remove(sale);
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
                Table = "Sale",
                Command = "Delete",
                Data = saleNo.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // ログデータ作成
        // in       regSale : ログ対象データ
        // out      string  : ログ文字列
        private string SaleLogData(Sale regSale)
        {
            string saleDateTime = string.Empty;
            if (regSale.SaleDateTime != null) saleDateTime = regSale.SaleDateTime.Value.ToShortDateString();

            string shop;
            string staff;
            string tax;
            using (var db = new SalesDbContext())
            {
                try
                {
                    shop = (regSale.SaleShopsId != -1) ? db.Shops.Single(m => m.ShopCode == regSale.SaleShopsId).ShopName : string.Empty;

                    // 無効表示
                    if (db.Shops.Single(m => m.ShopCode == regSale.SaleShopsId).Status != 0) shop = "[" + shop + "]";
                }
                catch
                {
                    shop = string.Empty;
                }

                try
                {
                    staff = (regSale.PersonInChargesId != -1) ? db.Staffs.Single(m => m.StaffCode == regSale.PersonInChargesId).StaffName : string.Empty;

                    // 無効表示
                    if (db.Staffs.Single(m => m.StaffCode == regSale.PersonInChargesId).Status != 0) staff = "[" + staff + "]";
                }
                catch
                {
                    staff = string.Empty;
                }

                try
                {
                    tax = (regSale.TaxsId != -1) ? db.Taxs.Single(m => m.TaxCode == regSale.TaxsId).TaxValue.ToString() : string.Empty;

                    // 無効表示
                    if (db.Taxs.Single(m => m.TaxCode == regSale.TaxsId).Status != 0) tax = "[" + tax + "]";
                }
                catch
                {
                    tax = string.Empty;
                }
            }

            return regSale.SaleId.ToString() + ", " +
            regSale.SaleNo.ToString() + ", " +
            shop + ", " +
            staff + ", " +
            regSale.ReceiptNo1 + ", " +
            tax + ", " +
            saleDateTime + ", " +
            StaticCommon.ConvertToString(10, regSale.StockManagementInfo) + ", " +
            StaticCommon.ConvertToString(9, regSale.LockInfo) + ", " +
            regSale.Comments + ", " +
            StaticCommon.ConvertToString(1, regSale.Status);
        }
    }
}
