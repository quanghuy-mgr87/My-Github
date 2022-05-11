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
    // 発注明細管理　データ処理クラス
    public class T_PlaceOrderListContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // データベース処理（Unit）
        private UnitContents _ut = new UnitContents();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得（配列）
        public IEnumerable<T_PlaceOrderList> GetOrderLists()
        {
            using (var db = new SalesDbContext()) return db.T_PlaceOrderLists.ToList();
        }

        // 発注番号指定　発注明細データ数取得
        // in  : orderNo　　　　：発注番号
        // out : orderDetailデータ数
        public int GetOrderDetailCountsByNo(int orderNo)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.OrderDetails.Where(m => m.OrderNo == orderNo).Count();
            }
            catch
            {
                return 0;
                // throw new Exception(Messages.errorNotFoundOrderDetail);
            }
        }

        // データ取得
        // in  : orderDetailId
        // out : orderDetailデータ
        public OrderDetail GetOrderDetail(int orderNo, int orderDetailNo)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.OrderDetails.Single(m => m.OrderNo == orderNo && m.OrderDetailNo == orderDetailNo);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundOrderDetail);
            }
        }

        // データ取得（shopId & itemId）
        // in  : shopId, itemId
        // out : 発注掛数
        public int GetOrderDetailByShopItem(int deliverdShopId, long itemId)
        {
            int totalMsPcs = 0;
            try
            {
                using (var db = new SalesDbContext())
                {
                    // 商品が一致
                    List<OrderDetail> orderDetails = db.OrderDetails.Where(m => m.ItemsId == itemId).ToList();
                    foreach(OrderDetail orderDetail in orderDetails)
                    {
                        // 店舗が一致
                        if (db.Orders.Single(m => m.OrderNo == orderDetail.OrderNo).DeliveredShopsId == deliverdShopId)
                        {
                            // 発注掛フラグをチェックし、発注掛数をカウント
                            if (orderDetail.Stored == false)
                            {
                                // 個数取得
                                int quantity = orderDetail.Quantity;

                                // 単位個数取得
                                int pcs = _ut.GetUnit(orderDetail.UnitsId).NumberOfComponent;

                                // 合計最低個数計算
                                totalMsPcs += (quantity * pcs);
                            }
                        }
                    }
                }
            }
            catch
            {
                return 0;
                // throw new Exception(Messages.errorNotFoundOrder);
            }

            return totalMsPcs;
        }

        // データ取得（shopId & itemId & voucharNo）
        // in  : shopId, itemId, voucharNo
        // out : 発注掛リスト
        public IEnumerable<OrderDetail> GetOrderDetailByShopItemVoucharNo(int deliverdShopId, long itemId, string voucherNo)
        {
            // リターン用データ
            List<OrderDetail> retOrderDetails = new List<OrderDetail>();

            try
            {
                using (var db = new SalesDbContext())
                {
                    // 商品が一致
                    List<OrderDetail> orderDetails = db.OrderDetails.Where(m => m.ItemsId == itemId).ToList();
                    foreach (OrderDetail orderDetail in orderDetails)
                    {
                        // 店舗が一致
                        if (db.Orders.Single(m => m.OrderNo == orderDetail.OrderNo).DeliveredShopsId == deliverdShopId)
                        {
                            // 発注掛で、伝票番号が一致
                            if (orderDetail.Stored == false & orderDetail.VoucherNo == voucherNo)
                            {
                                retOrderDetails.Add(orderDetail);
                            }
                        }
                    }
                }
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundOrder);
            }

            return retOrderDetails;
        }

        // 印刷データ数取得（始点指定）
        // in  supplierId : -1 = サプライヤー未指定
        //     printStatus : 0 = 印刷（リストアップ）
        // in   startRec : 配列抜出の始点
        // out  int : dataCount = スタート位置の発注番号が同じデータの数
        public int GetDispOrderCount(int supplierId, int startRec)
        {
            using (var db = new SalesDbContext())
            {
                int orderNo = 0;
                int count = 0;
                int dataCount = 0;
                foreach (OrderDetail orderDetail in db.OrderDetails)
                {
                    // Order 情報取得
                    Order order = db.Orders.Single(m => m.OrderNo == orderDetail.OrderNo);

                    // サプライヤーチェック
                    if (supplierId != -1 && order.SuppliersId != supplierId) continue;

                    // 印刷ステータスチェック
                    // if (order.PrintStatus != 0) continue;

                    // スタート位置までパス
                    if (count < startRec) { count++; continue; }

                    // 注文番号チェック
                    if (orderNo == 0) orderNo = order.OrderNo;
                    else if (orderNo != order.OrderNo) break;

                    dataCount++;
                }
                return dataCount;
            }
        }

        // 発注印刷ページ数取得（始点指定）
        // in  supplierId : -1 = サプライヤー未指定
        //     printStatus : 0 = 印刷（リストアップ）
        // out  int : count = 印刷ページ数
        public int GetPrintPageCount(int supplierId)
        {
            using (var db = new SalesDbContext())
            {
                int orderNo = 0;
                int count = 0;
                foreach (OrderDetail orderDetail in db.OrderDetails)
                {
                    // Order 情報取得
                    Order order = db.Orders.Single(m => m.OrderNo == orderDetail.OrderNo);

                    // サプライヤーチェック
                    if (supplierId != -1 & order.SuppliersId != supplierId) continue;

                    // 印刷ステータスチェック
                    if (order.PrintStatus != 0) continue;

                    // 注文番号チェック
                    if (orderNo != order.OrderNo)
                    {
                        orderNo = order.OrderNo;
                        count++;
                    }
                }
                return count;
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<DispOrder> GetDispOrderDetails()
        {
            // リターン用リスト
            List<DispOrder> dispOrders = new List<DispOrder>();

            using (var db = new SalesDbContext())
            {
                foreach (OrderDetail orderDetail in db.OrderDetails)
                {
                    Order order = db.Orders.Single(m => m.OrderNo == orderDetail.OrderNo);

                    string staff;
                    try
                    {
                        staff = (order.PersonInChargesId != -1) ? db.Staffs.Single(m => m.StaffCode == order.PersonInChargesId).StaffName : string.Empty;

                        // 無効表示
                        if (db.Staffs.Single(m => m.StaffCode == order.PersonInChargesId).Status != 0) staff = "[" + staff + "]";
                    }
                    catch
                    {
                        staff = string.Empty;
                    }

                    string supplier;
                    try
                    {
                        supplier = (order.SuppliersId != -1) ? db.Suppliers.Single(m => m.SupplierCode == order.SuppliersId).SupplierName : string.Empty;

                        // 無効表示
                        if (db.Suppliers.Single(m => m.SupplierCode == order.SuppliersId).Status != 0) supplier = "[" + supplier + "]";
                    }
                    catch
                    {
                        supplier = string.Empty;
                    }

                    string deliveredShop;
                    try
                    {
                        deliveredShop = (order.DeliveredShopsId != -1) ? db.Shops.Single(m => m.ShopCode == order.DeliveredShopsId).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == order.DeliveredShopsId).Status != 0) deliveredShop = "[" + deliveredShop + "]";
                    }
                    catch
                    {
                        deliveredShop = string.Empty;
                    }

                    string tax;
                    try
                    {
                        tax = (order.TaxsId != -1) ? db.Taxs.Single(m => m.TaxCode == order.TaxsId).TaxValue.ToString() : string.Empty;

                        // 無効表示
                        if (db.Taxs.Single(m => m.TaxCode == order.TaxsId).Status != 0) tax = "[" + tax + "]";
                    }
                    catch
                    {
                        tax = string.Empty;
                    }

                    string item;
                    try
                    {
                        item = (orderDetail.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == orderDetail.ItemsId).ItemName : string.Empty;

                        // 無効表示
                        if (db.Items.Single(m => m.ItemCode == orderDetail.ItemsId).Status != 0) item = "[" + item + "]";
                    }
                    catch
                    {
                        item = string.Empty;
                    }

                    string unit;
                    try
                    {
                        unit = (orderDetail.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == orderDetail.UnitsId).UnitName : string.Empty;

                        // 無効表示
                        if (db.Units.Single(m => m.UnitCode == orderDetail.UnitsId).Status != 0) unit = "[" + unit + "]";
                    }
                    catch
                    {
                        unit = string.Empty;
                    }

                    dispOrders.Add(new DispOrder()
                    {
                        OrderId = order.OrderId,
                        OrderNo = order.OrderNo,
                        OrderName = order.OrderName,
                        PersonInCharge = staff,
                        DeliveryDateTime = order.DeliveryDateTime,
                        OrderDateTime = order.OrderDateTime,
                        PrintStatus = order.PrintStatus,
                        Supplier = supplier,
                        DeliveredShop = deliveredShop,
                        OrderDetailNo = orderDetail.OrderDetailNo,
                        Item = item,
                        Quantity = orderDetail.Quantity.ToString(),
                        Unit = unit,
                        Price = String.Format("{0:#,0}", orderDetail.Price),
                        TotalPrice = String.Format("{0:#,0}", orderDetail.TotalPrice),
                        Tax = tax,
                        VoucherNo = orderDetail.VoucherNo,
                        Stored = orderDetail.Stored,
                        Comments = order.Comments,
                        Status = StaticCommon.ConvertToString(1, order.Status),
                        Timestamp = order.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispOrder> sortableDispOrder = new SortableBindingList<DispOrder>(dispOrders);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "OrderDetail",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispOrder;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        //      dispSale : 表示用データリスト
        public IEnumerable<DispOrder> GetDispOrderDetails(int startRec, int endRec)
        {
            // リターン用リスト
            List<DispOrder> dispOrders = new List<DispOrder>();

            using (var db = new SalesDbContext())
            {
                int count = 0;
                foreach (OrderDetail orderDetail in db.OrderDetails)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    Order order = db.Orders.Single(m => m.OrderNo == orderDetail.OrderNo);

                    string staff;
                    try
                    {
                        staff = (order.PersonInChargesId != -1) ? db.Staffs.Single(m => m.StaffCode == order.PersonInChargesId).StaffName : string.Empty;

                        // 無効表示
                        if (db.Staffs.Single(m => m.StaffCode == order.PersonInChargesId).Status != 0) staff = "[" + staff + "]";
                    }
                    catch
                    {
                        staff = string.Empty;
                    }

                    string supplier;
                    try
                    {
                        supplier = (order.SuppliersId != -1) ? db.Suppliers.Single(m => m.SupplierCode == order.SuppliersId).SupplierName : string.Empty;

                        // 無効表示
                        if (db.Suppliers.Single(m => m.SupplierCode == order.SuppliersId).Status != 0) supplier = "[" + supplier + "]";
                    }
                    catch
                    {
                        supplier = string.Empty;
                    }

                    string deliveredShop;
                    try
                    {
                        deliveredShop = (order.DeliveredShopsId != -1) ? db.Shops.Single(m => m.ShopCode == order.DeliveredShopsId).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == order.DeliveredShopsId).Status != 0) deliveredShop = "[" + deliveredShop + "]";
                    }
                    catch
                    {
                        deliveredShop = string.Empty;
                    }

                    string tax;
                    try
                    {
                        tax = (order.TaxsId != -1) ? db.Taxs.Single(m => m.TaxCode == order.TaxsId).TaxValue.ToString() : string.Empty;

                        // 無効表示
                        if (db.Taxs.Single(m => m.TaxCode == order.TaxsId).Status != 0) tax = "[" + tax + "]";
                    }
                    catch
                    {
                        tax = string.Empty;
                    }

                    string item;
                    try
                    {
                        item = (orderDetail.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == orderDetail.ItemsId).ItemName : string.Empty;

                        // 無効表示
                        if (db.Items.Single(m => m.ItemCode == orderDetail.ItemsId).Status != 0) item = "[" + item + "]";
                    }
                    catch
                    {
                        item = string.Empty;
                    }

                    string unit;
                    try
                    {
                        unit = (orderDetail.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == orderDetail.UnitsId).UnitName : string.Empty;

                        // 無効表示
                        if (db.Units.Single(m => m.UnitCode == orderDetail.UnitsId).Status != 0) unit = "[" + unit + "]";
                    }
                    catch
                    {
                        unit = string.Empty;
                    }

                    dispOrders.Add(new DispOrder()
                    {
                        OrderId = order.OrderId,
                        OrderNo = order.OrderNo,
                        OrderName = order.OrderName,
                        PersonInCharge = staff,
                        DeliveryDateTime = order.DeliveryDateTime,
                        OrderDateTime = order.OrderDateTime,
                        PrintStatus = order.PrintStatus,
                        Supplier = supplier,
                        DeliveredShop = deliveredShop,
                        OrderDetailNo = orderDetail.OrderDetailNo,
                        Item = item,
                        Quantity = orderDetail.Quantity.ToString(),
                        Unit = unit,
                        Price = String.Format("{0:#,0}", orderDetail.Price),
                        TotalPrice = String.Format("{0:#,0}", orderDetail.TotalPrice),
                        Tax = tax,
                        VoucherNo = orderDetail.VoucherNo,
                        Stored = orderDetail.Stored,
                        Comments = order.Comments,
                        Status = StaticCommon.ConvertToString(1, order.Status),
                        Timestamp = order.Timestamp
                    });

                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispOrder> sortableDispOrder = new SortableBindingList<DispOrder>(dispOrders);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "OrderDetail",
                    Command = "GetPartial",
                    Data = "StartRec=" + startRec.ToString() + ":EndRec=" + endRec.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispOrder;
            }
        }

        // 印刷データ取得
        // in  supplierId : -1 = サプライヤー未指定
        //     printStatus : 0 = 印刷（リストアップ）
        // out 表示データ（配列）
        public IEnumerable<DispOrder> GetDispOrderDetails(int supplierId)
        {
            // リターン用リスト
            List<DispOrder> dispOrders = new List<DispOrder>();

            using (var db = new SalesDbContext())
            {
                foreach (OrderDetail orderDetail in db.OrderDetails)
                {
                    // Order 情報取得
                    Order order = db.Orders.Single(m => m.OrderNo == orderDetail.OrderNo);

                    // サプライヤーチェック
                    if (supplierId != -1 & order.SuppliersId != supplierId) continue;

                    // 印刷ステータスチェック
                    if (order.PrintStatus != 0) continue;

                    string staff;
                    try
                    {
                        staff = (order.PersonInChargesId != -1) ? db.Staffs.Single(m => m.StaffCode == order.PersonInChargesId).StaffName : string.Empty;

                        // 無効表示
                        if (db.Staffs.Single(m => m.StaffCode == order.PersonInChargesId).Status != 0) staff = "[" + staff + "]";
                    }
                    catch
                    {
                        staff = string.Empty;
                    }

                    string supplier;
                    try
                    {
                        supplier = (order.SuppliersId != -1) ? db.Suppliers.Single(m => m.SupplierCode == order.SuppliersId).SupplierName : string.Empty;

                        // 無効表示
                        if (db.Suppliers.Single(m => m.SupplierCode == order.SuppliersId).Status != 0) supplier = "[" + supplier + "]";
                    }
                    catch
                    {
                        supplier = string.Empty;
                    }

                    string deliveredShop;
                    try
                    {
                        deliveredShop = (order.DeliveredShopsId != -1) ? db.Shops.Single(m => m.ShopCode == order.DeliveredShopsId).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == order.DeliveredShopsId).Status != 0) deliveredShop = "[" + deliveredShop + "]";
                    }
                    catch
                    {
                        deliveredShop = string.Empty;
                    }

                    string tax;
                    try
                    {
                        tax = (order.TaxsId != -1) ? db.Taxs.Single(m => m.TaxCode == order.TaxsId).TaxValue.ToString() : string.Empty;

                        // 無効表示
                        if (db.Taxs.Single(m => m.TaxCode == order.TaxsId).Status != 0) tax = "[" + tax + "]";
                    }
                    catch
                    {
                        tax = string.Empty;
                    }

                    string item;
                    try
                    {
                        item = (orderDetail.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == orderDetail.ItemsId).ItemName : string.Empty;

                        // 無効表示
                        if (db.Items.Single(m => m.ItemCode == orderDetail.ItemsId).Status != 0) item = "[" + item + "]";
                    }
                    catch
                    {
                        item = string.Empty;
                    }

                    string unit;
                    try
                    {
                        unit = (orderDetail.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == orderDetail.UnitsId).UnitName : string.Empty;

                        // 無効表示
                        if (db.Units.Single(m => m.UnitCode == orderDetail.UnitsId).Status != 0) unit = "[" + unit + "]";
                    }
                    catch
                    {
                        unit = string.Empty;
                    }

                    dispOrders.Add(new DispOrder()
                    {
                        OrderId = order.OrderId,
                        OrderNo = order.OrderNo,
                        OrderName = order.OrderName,
                        PersonInCharge = staff,
                        DeliveryDateTime = order.DeliveryDateTime,
                        OrderDateTime = order.OrderDateTime,
                        PrintStatus = order.PrintStatus,
                        Supplier = supplier,
                        DeliveredShop = deliveredShop,
                        OrderDetailNo = orderDetail.OrderDetailNo,
                        Item = item,
                        Quantity = orderDetail.Quantity.ToString(),
                        Unit = unit,
                        Price = String.Format("{0:#,0}", orderDetail.Price),
                        TotalPrice = String.Format("{0:#,0}", orderDetail.TotalPrice),
                        Tax = tax,
                        VoucherNo = orderDetail.VoucherNo,
                        Stored = orderDetail.Stored,
                        Comments = order.Comments,
                        Status = StaticCommon.ConvertToString(1, order.Status),
                        Timestamp = order.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispOrder> sortableDispOrder = new SortableBindingList<DispOrder>(dispOrders);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "OrderDetail",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispOrder;
            }
        }

        // 印刷データ取得（始点・終点指定）
        // in  supplierId : -1 = サプライヤー未指定
        //     printStatus : 0 = 印刷（リストアップ）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        //      dispSale : 印刷用データリスト
        public IEnumerable<DispOrder> GetDispOrderDetails(int supplierId, int startRec, int endRec)
        {
            // リターン用リスト
            List<DispOrder> dispOrders = new List<DispOrder>();

            using (var db = new SalesDbContext())
            {
                int count = 0;
                foreach (OrderDetail orderDetail in db.OrderDetails)
                {
                    // Order 情報取得
                    Order order = db.Orders.Single(m => m.OrderNo == orderDetail.OrderNo);

                    // サプライヤーチェック
                    if (supplierId != -1 && order.SuppliersId != supplierId) continue;

                    // 印刷ステータスチェック
                    //if (order.PrintStatus != 0) continue;

                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    string staff;
                    try
                    {
                        staff = (order.PersonInChargesId != -1) ? db.Staffs.Single(m => m.StaffCode == order.PersonInChargesId).StaffName : string.Empty;

                        // 無効表示
                        if (db.Staffs.Single(m => m.StaffCode == order.PersonInChargesId).Status != 0) staff = "[" + staff + "]";
                    }
                    catch
                    {
                        staff = string.Empty;
                    }

                    string supplier;
                    try
                    {
                        supplier = (order.SuppliersId != -1) ? db.Suppliers.Single(m => m.SupplierCode == order.SuppliersId).SupplierName : string.Empty;

                        // 無効表示
                        if (db.Suppliers.Single(m => m.SupplierCode == order.SuppliersId).Status != 0) supplier = "[" + supplier + "]";
                    }
                    catch
                    {
                        supplier = string.Empty;
                    }

                    string deliveredShop;
                    try
                    {
                        deliveredShop = (order.DeliveredShopsId != -1) ? db.Shops.Single(m => m.ShopCode == order.DeliveredShopsId).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == order.DeliveredShopsId).Status != 0) deliveredShop = "[" + deliveredShop + "]";
                    }
                    catch
                    {
                        deliveredShop = string.Empty;
                    }

                    string tax;
                    try
                    {
                        tax = (order.TaxsId != -1) ? db.Taxs.Single(m => m.TaxCode == order.TaxsId).TaxValue.ToString() : string.Empty;

                        // 無効表示
                        if (db.Taxs.Single(m => m.TaxCode == order.TaxsId).Status != 0) tax = "[" + tax + "]";
                    }
                    catch
                    {
                        tax = string.Empty;
                    }

                    string item;
                    try
                    {
                        item = (orderDetail.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == orderDetail.ItemsId).ItemName : string.Empty;

                        // 無効表示
                        if (db.Items.Single(m => m.ItemCode == orderDetail.ItemsId).Status != 0) item = "[" + item + "]";
                    }
                    catch
                    {
                        item = string.Empty;
                    }

                    string unit;
                    try
                    {
                        unit = (orderDetail.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == orderDetail.UnitsId).UnitName : string.Empty;

                        // 無効表示
                        if (db.Units.Single(m => m.UnitCode == orderDetail.UnitsId).Status != 0) unit = "[" + unit + "]";
                    }
                    catch
                    {
                        unit = string.Empty;
                    }

                    dispOrders.Add(new DispOrder()
                    {
                        OrderId = order.OrderId,
                        OrderNo = order.OrderNo,
                        OrderName = order.OrderName,
                        PersonInCharge = staff,
                        DeliveryDateTime = order.DeliveryDateTime,
                        OrderDateTime = order.OrderDateTime,
                        PrintStatus = order.PrintStatus,
                        Supplier = supplier,
                        DeliveredShop = deliveredShop,
                        OrderDetailNo = orderDetail.OrderDetailNo,
                        Item = item,
                        Quantity = orderDetail.Quantity.ToString(),
                        Unit = unit,
                        Price = String.Format("{0:#,0}", orderDetail.Price),
                        TotalPrice = String.Format("{0:#,0}", orderDetail.TotalPrice),
                        Tax = tax,
                        VoucherNo = orderDetail.VoucherNo,
                        Stored = orderDetail.Stored,
                        Comments = order.Comments,
                        Status = StaticCommon.ConvertToString(1, order.Status),
                        Timestamp = order.Timestamp
                    });

                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispOrder> sortableDispOrder = new SortableBindingList<DispOrder>(dispOrders);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "OrderDetail",
                    Command = "GetPartial",
                    Data = "StartRec=" + startRec.ToString() + ":EndRec=" + endRec.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispOrder;
            }
        }


        // 発注明細印刷データ取得（始点・終点指定）
        // in  supplierId : -1 = サプライヤー未指定
        //     printStatus : 0 = 印刷（リストアップ）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        //      dispSale : 印刷用データリスト
        public IEnumerable<DispOrdering> GetDispOrderDetailsCustom(int supplierId, int startRec, int endRec)
        {
            // リターン用リスト
            List<DispOrdering> dispOrderings = new List<DispOrdering>();

            using (var db = new SalesDbContext())
            {
                int count = 0;
                foreach (OrderDetail orderDetail in db.OrderDetails)
                {
                    // Order 情報取得
                    Order order = db.Orders.Single(m => m.OrderNo == orderDetail.OrderNo);

                    // サプライヤーチェック
                    if (supplierId != -1 & order.SuppliersId != supplierId) continue;

                    // 印刷ステータスチェック
                    // if (order.PrintStatus != 0) continue;

                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    string staff;
                    try
                    {
                        staff = (order.PersonInChargesId != -1) ? db.Staffs.Single(m => m.StaffCode == order.PersonInChargesId).StaffName : string.Empty;

                        // 無効表示
                        if (db.Staffs.Single(m => m.StaffCode == order.PersonInChargesId).Status != 0) staff = "[" + staff + "]";
                    }
                    catch
                    {
                        staff = string.Empty;
                    }

                    string supplier;
                    try
                    {
                        supplier = (order.SuppliersId != -1) ? db.Suppliers.Single(m => m.SupplierCode == order.SuppliersId).SupplierName : string.Empty;

                        // 無効表示
                        if (db.Suppliers.Single(m => m.SupplierCode == order.SuppliersId).Status != 0) supplier = "[" + supplier + "]";
                    }
                    catch
                    {
                        supplier = string.Empty;
                    }

                    string deliveredShop;
                    try
                    {
                        deliveredShop = (order.DeliveredShopsId != -1) ? db.Shops.Single(m => m.ShopCode == order.DeliveredShopsId).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == order.DeliveredShopsId).Status != 0) deliveredShop = "[" + deliveredShop + "]";
                    }
                    catch
                    {
                        deliveredShop = string.Empty;
                    }

                    string tax;
                    try
                    {
                        tax = (order.TaxsId != -1) ? db.Taxs.Single(m => m.TaxCode == order.TaxsId).TaxValue.ToString() : string.Empty;

                        // 無効表示
                        if (db.Taxs.Single(m => m.TaxCode == order.TaxsId).Status != 0) tax = "[" + tax + "]";
                    }
                    catch
                    {
                        tax = string.Empty;
                    }

                    string item;
                    try
                    {
                        item = (orderDetail.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == orderDetail.ItemsId).ItemName : string.Empty;

                        // 無効表示
                        if (db.Items.Single(m => m.ItemCode == orderDetail.ItemsId).Status != 0) item = "[" + item + "]";
                    }
                    catch
                    {
                        item = string.Empty;
                    }

                    string modelNo;
                    try
                    {
                        modelNo = (orderDetail.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == orderDetail.ItemsId).ModelNo : string.Empty;

                        // 無効表示
                        if (db.Items.Single(m => m.ItemCode == orderDetail.ItemsId).Status != 0) modelNo = "[" + modelNo + "]";
                    }
                    catch
                    {
                        modelNo = string.Empty;
                    }

                    string maker;
                    try
                    {
                        int makerId = (orderDetail.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == orderDetail.ItemsId).MakersId : -1;
                        maker = (makerId != -1) ? db.Makers.Single(m => m.MakerCode == makerId).MakerName : string.Empty;

                        // 無効表示
                        if (db.Makers.Single(m => m.MakerCode == makerId).Status != 0) maker = "[" + maker + "]";
                    }
                    catch
                    {
                        maker = string.Empty;
                    }

                    string unit;
                    try
                    {
                        unit = (orderDetail.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == orderDetail.UnitsId).UnitName : string.Empty;

                        // 無効表示
                        if (db.Units.Single(m => m.UnitCode == orderDetail.UnitsId).Status != 0) unit = "[" + unit + "]";
                    }
                    catch
                    {
                        unit = string.Empty;
                    }

                    dispOrderings.Add(new DispOrdering()
                    {
                        OrderId = order.OrderId,
                        OrderDetailNo = orderDetail.OrderDetailNo,
                        Item = item,
                        ModelNo = modelNo,
                        Maker = maker,
                        Quantity = orderDetail.Quantity.ToString(),
                        Unit = unit,
                        Price = String.Format("{0:#,0}", orderDetail.Price),
                        TotalPrice = String.Format("{0:#,0}", orderDetail.TotalPrice),
                    });

                    count++;
                }

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "OrderDetail",
                    Command = "GetPartial",
                    Data = "StartRec=" + startRec.ToString() + ":EndRec=" + endRec.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return dispOrderings;
            }
        }

        // データ追加
        // in   : OrderDetailデータ
        public void PostOrderDetail(OrderDetail regOrderDetail)
        {
            using (var db = new SalesDbContext())
            {
                db.OrderDetails.Add(regOrderDetail);
                db.Entry(regOrderDetail).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "OrderDetail",
                Command = "Post",
                Data = OrderDetailLogData(regOrderDetail),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : OrderDetailデータ
        public void PutOrderDetail(OrderDetail regOrderDetail)
        {
            using (var db = new SalesDbContext())
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
                Table = "OrderDetail",
                Command = "Put",
                Data = OrderDetailLogData(regOrderDetail),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ削除
        // in       orderNo　　   : 削除する発注No
        //          orderDetailNo : 削除する発注明細No
        public void DeleteOrderDetail(int orderNo, int orderDetailNo)
        {
            OrderDetail orderDetail;
            using (var db = new SalesDbContext())
            {
                try
                {
                    orderDetail = db.OrderDetails.Single(m => m.OrderNo == orderNo && m.OrderDetailNo == orderDetailNo);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundSale, ex);
                    // throw new Exception(_cm.GetMessage(112), ex);
                }
                db.OrderDetails.Remove(orderDetail);
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
                Table = "OrderDetail",
                Command = "Delete",
                Data = orderDetailNo.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // ログデータ作成
        // in       regOrderDetail : ログ対象データ
        // out      string        : ログ文字列
        private string OrderDetailLogData(OrderDetail regOrderDetail)
        {
            string item;
            string unit;
            using (var db = new SalesDbContext())
            {
                try
                {
                    item = (regOrderDetail.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == regOrderDetail.ItemsId).ItemName : string.Empty;

                    // 無効表示
                    if (db.Items.Single(m => m.ItemCode == regOrderDetail.ItemsId).Status != 0) item = "[" + item + "]";
                }
                catch
                {
                    item = string.Empty;
                }

                try
                {
                    unit = (regOrderDetail.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == regOrderDetail.UnitsId).UnitName : string.Empty;

                    // 無効表示
                    if (db.Units.Single(m => m.UnitCode == regOrderDetail.UnitsId).Status != 0) unit = "[" + unit + "]";
                }
                catch
                {
                    unit = string.Empty;
                }
            }

            return regOrderDetail.OrderDetailId.ToString() + ", " +
            regOrderDetail.OrderDetailNo.ToString() + ", " +
            item + ", " +
            regOrderDetail.Quantity + ", " +
            unit + ", " +
            regOrderDetail.Price + ", " +
            regOrderDetail.TotalPrice + ", " +
            regOrderDetail.VoucherNo + ", " +
            regOrderDetail.Stored + ", " +
            regOrderDetail.Comments + ", " +
            StaticCommon.ConvertToString(1, regOrderDetail.Status);
        }
    }
}
