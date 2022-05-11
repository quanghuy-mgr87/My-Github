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
    class M_TaxContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // データベース処理モジュール（メッセージ）
        private MessageCommon _msc = new MessageCommon();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得（for ComboBox）
        // out コンボボックス用データ（配列）
        public IEnumerable<M_Tax> GetTaxs()
        {
            using (var db = new SalesDbContext())
            {
                List<M_Tax> tax = db.M_Taxs.ToList();
                return tax;
            }
        }

        // データ取得
        // in  : TaxID
        // out : Taxデータ
        public M_Tax GetTax(int TaxID)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.M_Taxs.Single(m => m.TaxID == TaxID);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundTax);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<M_DispTax> GetDispTaxs()
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispTax> m_DispTaxs = new List<M_DispTax>();
                foreach (M_Tax m_Tax in db.M_Taxs)
                {
                    m_DispTaxs.Add(new M_DispTax()
                    {
                        TaxID = m_Tax.TaxID,
                        Tax = m_Tax.Tax,
                        ModifyDate = m_Tax.ModifyDate,
                        Comments = m_Tax.Comments,
                        Timestamp = m_Tax.Timestamp,
                        LogData = m_Tax.LogData
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispTax> sortableDispTax = new SortableBindingList<M_DispTax>(m_DispTaxs);

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
        public IEnumerable<M_DispTax> GetDispTaxs(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispTax> m_DispTaxs = new List<M_DispTax>();
                int count = 0;
                foreach (M_Tax m_Tax in db.M_Taxs)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    m_DispTaxs.Add(new M_DispTax()
                    {
                        TaxID = m_Tax.TaxID,
                        Tax = m_Tax.Tax,
                        ModifyDate = m_Tax.ModifyDate,
                        Comments = m_Tax.Comments,
                        Timestamp = m_Tax.Timestamp,
                        LogData = m_Tax.LogData
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispTax> sortableDispTax = new SortableBindingList<M_DispTax>(m_DispTaxs);

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
        // out : Tax（有効の設定がない場合は-1を返す）
        public int GetDefaultTaxCode()
        {
            try
            {
                using (var db = new SalesDbContext()) return db.M_Taxs.First().Tax;
            }
            catch
            {
                return -1;
                // throw new Exception(Messages.errorNotFoundTax);
            }
        }

        // データ追加
        // in   : M_Taxデータ
        public string PostTax(M_Tax regM_Tax)
        {
            using (var db = new SalesDbContext())
            {
                db.M_Taxs.Add(regM_Tax);
                db.Entry(regM_Tax).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Tax",
                Command = "Post",
                Data = TaxLogData(regM_Tax),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

            return string.Empty;
        }

        // データ更新
        // in   : M_Taxデータ
        // out  : エラーメッセージ 
        public string PutTax(M_Tax regM_Tax)
        {
            using (var db = new SalesDbContext())
            {
                M_Tax m_Tax;
                try
                {
                    m_Tax = db.M_Taxs.Single(x => x.TaxID == regM_Tax.TaxID);
                    m_Tax.Tax = regM_Tax.Tax;
                    m_Tax.ModifyDate = regM_Tax.ModifyDate;
                    m_Tax.Comments = regM_Tax.Comments;
                    m_Tax.Timestamp = regM_Tax.Timestamp;

                    db.Entry(m_Tax).State = EntityState.Modified;
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundTax, ex);
                    // throw new Exception(_cm.GetMessage(115), ex);
                    return _msc.GetMessage(115);
                }

                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    // throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                    return _msc.GetMessage(100);
                }
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Tax",
                Command = "Put",
                Data = TaxLogData(regM_Tax),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

            return string.Empty;
        }

        // データ削除
        // in       TaxID : 削除する消費税ID
        public string DeleteTax(int TaxID)
        {
            M_Tax m_Tax;
            using (var db = new SalesDbContext())
            {
                try
                {
                    m_Tax = db.M_Taxs.Single(x => x.TaxID == TaxID);
                    db.M_Taxs.Remove(m_Tax);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundTax, ex);
                    // throw new Exception(_cm.GetMessage(115), ex);
                    return _msc.GetMessage(115);
                }
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    // throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                    return _msc.GetMessage(100);
                }
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Tax",
                Command = "Delete",
                Data = TaxID.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

            return string.Empty;
        }

        // ログデータ作成
        // in       regM_Tax : ログ対象データ
        // out      string   : ログ文字列
        private string TaxLogData(M_Tax regM_Tax)
        {
            return regM_Tax.TaxID.ToString() + ", " +
            regM_Tax.Tax.ToString() + ", " +
            regM_Tax.Comments;
        }
    }
}
