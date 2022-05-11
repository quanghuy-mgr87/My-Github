using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model.ContentsManagement.Common
{
    class CodeCounterCommon
    {
        // ***** コードカウンター関係
        // データ取得（EntityFramework）
        public IEnumerable<CodeCounter> GetCodeCounters()
        {
            using (var db = new SalesDbContext()) return db.CodeCounters.ToList();
        }

        // データ取得
        // in  : codeCounterId
        // out : CodeCounterデータ
        public CodeCounter GetCodeCounter(int codeId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.CodeCounters.Single(m => m.CodeId == codeId);
            }
            catch (Exception ex)
            {
                throw new Exception(Messages.errorNotFoundCounter, ex);
                // throw new Exception(_cm.GetMessage(102), ex);
            }
        }

        // データ取得
        // in  : codeCounterId
        // out : counterデータ
        public long GetCounter(int codeId, out byte[] timeStamp)
        {
            try
            {
                using (var db = new SalesDbContext())
                {

                    CodeCounter codeCounter = db.CodeCounters.Single(m => m.CodeId == codeId);
                    timeStamp = codeCounter.Timestamp;
                    return codeCounter.Counter;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(Messages.errorNotFoundCounter, ex);
                // throw new Exception(_cm.GetMessage(102), ex);
            }
        }

        // データ取得
        // in  : codeId
        // out : CodeCounterデータ（増加）
        public long GetCodeIncrement(int codeId, out byte[] timeStamp)
        {
            try
            {
                using (var db = new SalesDbContext())
                {
                    CodeCounter codeCounter = db.CodeCounters.Single(m => m.CodeId == codeId);
                    timeStamp = codeCounter.Timestamp;
                    return codeCounter.Counter + 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(Messages.errorNotFoundCounter, ex);
                // throw new Exception(_cm.GetMessage(102), ex);
            }
        }

        // データ追加
        public void PostCodeCounter(CodeCounter regCodeCounter)
        {
            using (var db = new SalesDbContext())
            {
                db.CodeCounters.Add(regCodeCounter);
                db.SaveChanges();
            }
        }

        // データ更新
        public void PutCodeCounter(CodeCounter regCodeCounter)
        {
            using (var db = new SalesDbContext())
            {
                CodeCounter codeCounter;
                try
                {
                    codeCounter = db.CodeCounters.Single(m => m.CodeCounterId == regCodeCounter.CodeCounterId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundCounter, ex);
                    // throw new Exception(_cm.GetMessage(102), ex);
                }
                codeCounter.CodeId = regCodeCounter.CodeId;
                codeCounter.Counter = regCodeCounter.Counter;
                // codeCounter.Timestamp = regCodeCounter.Timestamp;
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
        }

        // データ更新
        // in codeId : カウンターID、counter : カウンター値
        public void PutCodeById(int codeId, long counter, byte[] timeStamp)
        {
            using (var db = new SalesDbContext())
            {
                CodeCounter codeCounter;
                try
                {
                    codeCounter = db.CodeCounters.Single(m => m.CodeId == codeId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundCounter, ex);
                    // throw new Exception(_cm.GetMessage(102), ex);
                }
                codeCounter.Counter = counter;
                codeCounter.Timestamp = timeStamp;
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
        }

        // データ削除
        public void DeleteCodeCounter(int codeCounterId)
        {
            using (var db = new SalesDbContext())
            {
                CodeCounter codeCounter;
                try
                {
                    codeCounter = db.CodeCounters.Single(x => x.CodeCounterId == codeCounterId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundCounter, ex);
                    // throw new Exception(_cm.GetMessage(102), ex);
                }
                db.CodeCounters.Remove(codeCounter);
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
        }

        // コードカウンター重複チェック（Longタイプ）
        // in   NUMDB : データベース指定
        //      counter: チェックコード
        // out  bool   : false = 重複あり
        public bool CheckCodeDuplication(int numDb, long counter, out string errorMessage)
        {
            bool status = true;
            errorMessage = string.Empty;
            using (var db = new SalesDbContext())
            {
                try
                {
                    switch (numDb)
                    {
                        case Constants.numMaker:
                            M_Maker maker = db.M_Makers.Single(m => m.MakerID == counter);
                            status = false;
                            break;
                        case Constants.numCategory:
                            M_Category category = db.M_Categorys.Single(m => m.CategoryCD == counter.ToString());
                            status = false;
                            break;
                        case Constants.numUnit:
                            Unit unit = db.Units.Single(m => m.UnitCode == counter);
                            status = false;
                            break;
                        case Constants.numSupplier:
                            Supplier supplier = db.Suppliers.Single(m => m.SupplierCode == counter);
                            status = false;
                            break;
                        case Constants.numStaff:
                            Staff staff = db.Staffs.Single(m => m.StaffCode == counter);
                            status = false;
                            break;
                        case Constants.numDivision:
                            M_Division division = db.M_Divisions.Single(m => m.DivisionID == counter);
                            status = false;
                            break;
                        case Constants.numPosition:
                            Position position = db.Positions.Single(m => m.PositionCode == counter);
                            status = false;
                            break;
                        case Constants.numShop:
                            Shop shop = db.Shops.Single(m => m.ShopCode == counter);
                            status = false;
                            break;
                        case Constants.numColumnsManagement:
                            ColumnsManagement columnsManagement = db.ColumnsManagements.Single(m => m.ColumnsManagementCode == counter);
                            status = false;
                            break;
                        case Constants.numTax:
                            M_Tax tax = db.M_Taxs.Single(m => m.TaxID == counter);
                            status = false;
                            break;
                        case Constants.numStock:
                            Stock stock = db.Stocks.Single(m => m.StorageNo == counter);
                            status = false;
                            break;
                        case Constants.numSale:
                            Sale sale = db.Sales.Single(m => m.SaleNo == counter);
                            status = false;
                            break;
                        case Constants.numOrder:
                            Order order = db.Orders.Single(m => m.OrderNo == counter);
                            status = false;
                            break;
                        case Constants.numLog:
                            OperationLog operationLog = db.OperationLogs.Single(m => m.OperationLogId == counter);
                            status = false;
                            break;
                        case Constants.numAggregation:
                            Aggregation aggregation = db.Aggregations.Single(m => m.AggregationCode == counter);
                            status = false;
                            break;
                        default:
                            status = false;
                            break;
                    }
                    errorMessage = "コードが重複しています。";
                }
                catch
                {
                    return status;
                }
            }
            return status;
        }

        // コードカウンター重複チェック（Stringタイプ）
        // in   NUMDB : データベース指定
        //      counter: チェックコード
        // out  bool   : false = 重複あり
        public bool CheckCodeDuplication(int numDb, string code, out string errorMessage)
        {
            bool status = true;
            errorMessage = string.Empty;
            using (var db = new SalesDbContext())
            {
                try
                {
                    switch (numDb)
                    {
                        case Constants.numCategory:
                            M_Category category = db.M_Categorys.Single(m => m.CategoryCD == code);
                            status = false;
                            break;
                        case Constants.numItem:
                            M_Item item = db.M_Items.Single(m => m.ItemCD == code);
                            status = false;
                            break;
                        default:
                            status = false;
                            break;
                    }
                    errorMessage = "コードが重複しています。";
                }
                catch
                {
                    return status;
                }
            }
            return status;
        }
    }
}
