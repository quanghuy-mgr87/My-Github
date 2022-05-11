using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SalesManagement.Model.ContentsManagement.Common;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;

namespace SalesManagement.Model.ContentsManagement
{
    // 発注管理　データ処理クラス
    public class OrderContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private CommonFunction _cm = new CommonFunction();

        // データベース処理（OrderDetail）
        private readonly OrderDetailContents _od = new OrderDetailContents();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得（配列）
        public IEnumerable<Order> GetOrders()
        {
            using (var db = new SalesDbContext()) return db.Orders.ToList();
        }

        // データ取得（orderId）
        // in  : orderId
        // out : orderデータ
        public Order GetOrderById(int orderId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Orders.Single(m => m.OrderId == orderId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundOrder);
            }
        }

        // データ取得（orderNo）
        // in  : orderNo
        // out : orderデータ
        public Order GetOrderByNo(int orderNo)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Orders.Single(m => m.OrderNo == orderNo);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundOrder);
            }
        }

        // データ取得（最新）
        // out : orderデータ
        public Order GetLastOrder()
        {
            try
            {
                using (var db = new SalesDbContext())
                {
                    long count = db.CodeCounters.Single(m => m.CodeId == Constants.orderNo).Counter;
                    return db.Orders.Single(m => m.OrderNo == count);
                }

            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundOrder);
            }
        }

        // データ追加
        // in   : Orderデータ
        public void PostOrder(Order regOrder)
        {
            using (var db = new SalesDbContext())
            {
                db.Orders.Add(regOrder);
                db.Entry(regOrder).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Order",
                Command = "Post",
                Data = OrderLogData(regOrder),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Orderデータ
        public void PutOrder(Order regOrder)
        {
            using (var db = new SalesDbContext())
            {
                Order order;
                try
                {
                    order = db.Orders.Single(x => x.OrderId == regOrder.OrderId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundOrder, ex);
                    // throw new Exception(_cm.GetMessage(121), ex);
                }
                order.OrderNo = regOrder.OrderNo;
                order.OrderName = regOrder.OrderName;
                order.DeliveryDateTime = regOrder.DeliveryDateTime;
                order.OrderDateTime = regOrder.OrderDateTime;
                order.PersonInChargesId = regOrder.PersonInChargesId;
                order.SuppliersId = regOrder.SuppliersId;
                order.DeliveredShopsId = regOrder.DeliveredShopsId;
                order.PrintStatus = regOrder.PrintStatus;
                order.Comments = regOrder.Comments;
                order.Status = regOrder.Status;
                order.Timestamp = regOrder.Timestamp;

                db.Entry(order).State = EntityState.Modified;
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
                Table = "Order",
                Command = "Put",
                Data = OrderLogData(regOrder),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ削除
        // in       OrderId : 削除する売上Id
        public void DeleteOrderById(int orderId)
        {
            Order order;
            using (var db = new SalesDbContext())
            {
                try
                {
                    order = db.Orders.Single(m => m.OrderId == orderId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundOrder, ex);
                    // throw new Exception(_cm.GetMessage(121), ex);
                }
                db.Orders.Remove(order);
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
                Table = "Order",
                Command = "Delete",
                Data = orderId.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ削除
        // in       OrderNo : 削除する売上No
        public void DeleteOrderByNo(int orderNo)
        {
            Order order;
            using (var db = new SalesDbContext())
            {
                try
                {
                    order = db.Orders.Single(x => x.OrderNo == orderNo);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundOrder, ex);
                    // throw new Exception(_cm.GetMessage(121), ex);
                }
                db.Orders.Remove(order);
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
                Table = "Order",
                Command = "Delete",
                Data = orderNo.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // ログデータ作成
        // in       regOrder : ログ対象データ
        // out      string  : ログ文字列
        private string OrderLogData(Order regOrder)
        {
            string orderDateTime = string.Empty;
            if (regOrder.OrderDateTime != null) orderDateTime = regOrder.OrderDateTime.Value.ToShortDateString();

            string deliveryDateTime = string.Empty;
            if (regOrder.DeliveryDateTime != null) deliveryDateTime = regOrder.DeliveryDateTime.Value.ToShortDateString();

            string staff;
            string deliveredShop;
            string supplier;
            using (var db = new SalesDbContext())
            {
                try
                {
                    staff = (regOrder.PersonInChargesId != -1) ? db.Staffs.Single(m => m.StaffCode == regOrder.PersonInChargesId).StaffName : string.Empty;

                    // 無効表示
                    if (db.Staffs.Single(m => m.StaffCode == regOrder.PersonInChargesId).Status != 0) staff = "[" + staff + "]";
                }
                catch
                {
                    staff = string.Empty;
                }

                try
                {
                    supplier = (regOrder.SuppliersId != -1) ? db.Suppliers.Single(m => m.SupplierCode == regOrder.SuppliersId).SupplierName : string.Empty;

                    // 無効表示
                    if (db.Staffs.Single(m => m.StaffCode == regOrder.SuppliersId).Status != 0) supplier = "[" + supplier + "]";
                }
                catch
                {
                    supplier = string.Empty;
                }

                try
                {
                    deliveredShop = (regOrder.DeliveredShopsId != -1) ? db.Shops.Single(m => m.ShopCode == regOrder.DeliveredShopsId).ShopName : string.Empty;

                    // 無効表示
                    if (db.Shops.Single(m => m.ShopCode == regOrder.DeliveredShopsId).Status != 0) deliveredShop = "[" + deliveredShop + "]";
                }
                catch
                {
                    deliveredShop = string.Empty;
                }
            }

            return regOrder.OrderId.ToString() + ", " +
            regOrder.OrderNo.ToString() + ", " +
            regOrder.OrderName.ToString() + ", " +
            staff + ", " +
            deliveryDateTime + ", " +
            orderDateTime + ", " +
            supplier + ", " +
            deliveredShop + ", " +
            regOrder.PrintStatus + ", " +
            regOrder.Comments + ", " +
            StaticCommon.ConvertToString(1, regOrder.Status);
        }
    }
}
