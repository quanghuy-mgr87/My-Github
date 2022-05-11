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
    // サプライヤーマスター　データ処理クラス
    class SupplierContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private CommonFunction _cm = new CommonFunction();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得（for ComboBox）
        // out コンボボックス用データ（配列）
        public IEnumerable<Supplier> GetSuppliers()
        {
            using (var db = new SalesDbContext())
            {
                List<Supplier> supplier = db.Suppliers.ToList();

                // 無効のものはリストから削除
                supplier.RemoveAll(m => m.Status != 0);
                return supplier;
            }
        }

        // データ取得
        // in  : SupplierId
        // out : Supplierデータ
        public Supplier GetSupplier(long SupplierId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Suppliers.Single(m => m.SupplierId == SupplierId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundSupplier);
                // throw new Exception(_cm.GetMessage(117), ex);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<DispSupplier> GetDispSuppliers()
        {
            using (var db = new SalesDbContext())
            {
                List<DispSupplier> dispSuppliers = new List<DispSupplier>();
                foreach (Supplier supplier in db.Suppliers)
                {
                    dispSuppliers.Add(new DispSupplier()
                    {
                        SupplierId = supplier.SupplierId,
                        SupplierCode = supplier.SupplierCode,
                        SupplierName = supplier.SupplierName,
                        SupplierKana = supplier.SupplierKana,
                        OfficeName = supplier.OfficeName,
                        OfficeKana = supplier.OfficeKana,
                        PostCode = supplier.PostCode,
                        Address = supplier.Address,
                        AddressKana = supplier.AddressKana,
                        ContactNo = supplier.ContactNo,
                        Mail = supplier.Mail,
                        Division = supplier.Division,
                        PersonInCharge = supplier.PersonInCharge,
                        Phone = supplier.Phone,
                        SmartPhone = supplier.SmartPhone,
                        PersonalMail = supplier.PersonalMail,
                        PaymentTerms = supplier.PaymentTerms,
                        Comments = supplier.Comments,
                        Status = StaticCommon.ConvertToString(1, supplier.Status),
                        Timestamp = supplier.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispSupplier> sortableDispSupplier = new SortableBindingList<DispSupplier>(dispSuppliers);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Supplier",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispSupplier;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<DispSupplier> GetDispSuppliers(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<DispSupplier> dispSuppliers = new List<DispSupplier>();
                int count = 0;
                foreach (Supplier supplier in db.Suppliers)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    dispSuppliers.Add(new DispSupplier()
                    {
                        SupplierId = supplier.SupplierId,
                        SupplierCode = supplier.SupplierCode,
                        SupplierName = supplier.SupplierName,
                        SupplierKana = supplier.SupplierKana,
                        OfficeName = supplier.OfficeName,
                        OfficeKana = supplier.OfficeKana,
                        PostCode = supplier.PostCode,
                        Address = supplier.Address,
                        AddressKana = supplier.AddressKana,
                        ContactNo = supplier.ContactNo,
                        Mail = supplier.Mail,
                        Division = supplier.Division,
                        PersonInCharge = supplier.PersonInCharge,
                        Phone = supplier.Phone,
                        SmartPhone = supplier.SmartPhone,
                        PersonalMail = supplier.PersonalMail,
                        PaymentTerms = supplier.PaymentTerms,
                        Comments = supplier.Comments,
                        Status = StaticCommon.ConvertToString(1, supplier.Status),
                        Timestamp = supplier.Timestamp
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispSupplier> sortableDispSupplier = new SortableBindingList<DispSupplier>(dispSuppliers);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Supplier",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispSupplier;
            }
        }

        // データ追加
        // in   : Supplierデータ
        public void PostSupplier(Supplier regSupplier)
        {
            using (var db = new SalesDbContext())
            {
                db.Suppliers.Add(regSupplier);
                db.Entry(regSupplier).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Supplier",
                Command = "Post",
                Data = SupplierLogData(regSupplier),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Supplierデータ
        public void PutSupplier(Supplier regSupplier)
        {
            using (var db = new SalesDbContext())
            {
                Supplier supplier;
                try
                {
                    supplier = db.Suppliers.Single(x => x.SupplierId == regSupplier.SupplierId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundSupplier, ex);
                    // throw new Exception(_cm.GetMessage(117), ex);
                }
                supplier.SupplierCode = regSupplier.SupplierCode;
                supplier.SupplierName = regSupplier.SupplierName;
                supplier.SupplierKana = regSupplier.SupplierKana;
                supplier.OfficeName = regSupplier.OfficeName;
                supplier.OfficeKana = regSupplier.OfficeKana;
                supplier.PostCode = regSupplier.PostCode;
                supplier.Address = regSupplier.Address;
                supplier.AddressKana = regSupplier.AddressKana;
                supplier.ContactNo = regSupplier.ContactNo;
                supplier.Mail = regSupplier.Mail;
                supplier.Division = regSupplier.Division;
                supplier.PersonInCharge = regSupplier.PersonInCharge;
                supplier.Phone = regSupplier.Phone;
                supplier.SmartPhone = regSupplier.SmartPhone;
                supplier.PersonalMail = regSupplier.PersonalMail;
                supplier.PaymentTerms = regSupplier.PaymentTerms;
                supplier.Comments = regSupplier.Comments;
                supplier.Status = regSupplier.Status;
                supplier.Timestamp = regSupplier.Timestamp;

                db.Entry(supplier).State = EntityState.Modified;
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
                    Table = "Supplier",
                    Command = "Put",
                    Data = SupplierLogData(regSupplier),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // データ削除
        // in       SupplierId : 削除するメーカーId
        public void DeleteSupplier(int SupplierId)
        {
            Supplier supplier;
            using (var db = new SalesDbContext())
            {
                try
                {
                    supplier = db.Suppliers.Single(x => x.SupplierId == SupplierId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundSupplier, ex);
                    // throw new Exception(_cm.GetMessage(117), ex);
                }
                db.Suppliers.Remove(supplier);
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
                    Table = "Supplier",
                    Command = "Delete",
                    Data = SupplierId.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // ログデータ作成
        // in       regSupplier : ログ対象データ
        // out      string   : ログ文字列
        private string SupplierLogData(Supplier regSupplier)
        {
            return regSupplier.SupplierId.ToString() + ", " +
            regSupplier.SupplierCode.ToString() + ", " +
            regSupplier.SupplierName + ", " +
            regSupplier.SupplierKana + ", " +
            regSupplier.OfficeName + ", " +
            regSupplier.OfficeKana + ", " +
            regSupplier.PostCode + ", " +
            regSupplier.Address + ", " +
            regSupplier.AddressKana + ", " +
            regSupplier.ContactNo + ", " +
            regSupplier.Mail + ", " +
            regSupplier.Division + ", " +
            regSupplier.PersonInCharge + ", " +
            regSupplier.Phone + ", " +
            regSupplier.SmartPhone + ", " +
            regSupplier.PersonalMail + ", " +
            regSupplier.PaymentTerms + ", " +
            regSupplier.Comments + ", " +
            StaticCommon.ConvertToString(1, regSupplier.Status);
        }
    }
}
