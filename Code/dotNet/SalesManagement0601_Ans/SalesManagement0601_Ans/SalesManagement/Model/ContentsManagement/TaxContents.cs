using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.Entity.Disp;
using SalesManagement.Model.ContentsManagement.Common;


namespace SalesManagement.Model.ContentsManagement
{
    // 消費税マスター　データ処理クラス
    class TaxContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得（for ComboBox）
        // out コンボボックス用データ（配列）
        public IEnumerable<Tax> GetTaxs()
        {
            using (var db = new SalesDbContext())
            {
                List<Tax> tax = db.Taxs.ToList();

                // 無効のものはリストから削除
                tax.RemoveAll(m => m.Status != 0);
                return tax;
            }
        }

        // データ取得
        // in  : TaxId
        // out : Taxデータ
        public Tax GetTax(int TaxId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Taxs.Single(m => m.TaxId == TaxId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundTax);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<DispTax> GetDispTaxs()
        {
            using (var db = new SalesDbContext())
            {
                List<DispTax> dispTaxs = new List<DispTax>();
                foreach (Tax Tax in db.Taxs)
                {
                    dispTaxs.Add(new DispTax()
                    {
                        TaxId = Tax.TaxId,
                        TaxCode = Tax.TaxCode,
                        TaxValue = Tax.TaxValue,
                        Comments = Tax.Comments,
                        Status = StaticCommon.ConvertToString(1, Tax.Status),
                        Timestamp = Tax.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispTax> sortableDispTax = new SortableBindingList<DispTax>(dispTaxs);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Tax",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispTax;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<DispTax> GetDispTaxs(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<DispTax> dispTaxs = new List<DispTax>();
                int count = 0;
                foreach (Tax Tax in db.Taxs)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    dispTaxs.Add(new DispTax()
                    {
                        TaxId = Tax.TaxId,
                        TaxCode = Tax.TaxCode,
                        TaxValue = Tax.TaxValue,
                        Comments = Tax.Comments,
                        Status = Common.StaticCommon.ConvertToString(1, Tax.Status),
                        Timestamp = Tax.Timestamp
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispTax> sortableDispTax = new SortableBindingList<DispTax>(dispTaxs);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Tax",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispTax;
            }
        }

        // データ取得
        // out : TaxIndex（有効の設定がない場合は-1を返す）
        public int GetDefaultTaxCode()
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Taxs.First(m => m.Status == 0).TaxCode;
            }
            catch
            {
                return -1;
                // throw new Exception(Messages.errorNotFoundTax);
            }
        }

        // データ追加
        // in   : Taxデータ
        public void PostTax(Tax regTax)
        {
            using (var db = new SalesDbContext())
            {
                db.Taxs.Add(regTax);
                db.Entry(regTax).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Tax",
                Command = "Post",
                Data = TaxLogData(regTax),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Taxデータ
        public void PutTax(Tax regTax)
        {
            using (var db = new SalesDbContext())
            {
                Tax Tax;
                try
                {
                    Tax = db.Taxs.Single(x => x.TaxId == regTax.TaxId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundTax, ex);
                    // throw new Exception(_cm.GetMessage(115), ex);
                }
                Tax.TaxCode = regTax.TaxCode;
                Tax.TaxValue = regTax.TaxValue;
                Tax.Comments = regTax.Comments;
                Tax.Status = regTax.Status;
                Tax.Timestamp = regTax.Timestamp;

                db.Entry(Tax).State = EntityState.Modified;
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
                Table = "Tax",
                Command = "Put",
                Data = TaxLogData(regTax),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ削除
        // in       TaxId : 削除する消費税Id
        public void DeleteTax(int TaxId)
        {
            Tax Tax;
            using (var db = new SalesDbContext())
            {
                try
                {
                    Tax = db.Taxs.Single(x => x.TaxId == TaxId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundTax, ex);
                    // throw new Exception(_cm.GetMessage(115), ex);
                }
                db.Taxs.Remove(Tax);
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
                Table = "Tax",
                Command = "Delete",
                Data = TaxId.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // ログデータ作成
        // in       regTax : ログ対象データ
        // out      string : ログ文字列
        private string TaxLogData(Tax regTax)
        {
            return regTax.TaxId.ToString() + ", " +
            regTax.TaxCode.ToString() + ", " +
            regTax.TaxValue + ", " +
            regTax.Comments + ", " +
            StaticCommon.ConvertToString(1, regTax.Status);
        }
    }
}
