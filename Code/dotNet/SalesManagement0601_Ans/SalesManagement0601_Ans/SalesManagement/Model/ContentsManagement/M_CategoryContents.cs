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
    // カテゴリーマスター　データ処理クラス
    class M_CategoryContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // メッセージ
        private readonly Messages _ms = new Messages();

        // データベース処理モジュール（メッセージ）
        private MessageCommon _msc = new MessageCommon();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得（for ComboBox）
        // out コンボボックス用データ（配列）
        public IEnumerable<M_Category> GetCategorys()
        {
            using (var db = new SalesDbContext())
            {
                List<M_Category> category = db.M_Categorys.ToList();

                // 無効のものはリストから削除
                category.RemoveAll(m => m.DelFLG == true);
                return category;
            }
        }

        // データ取得
        // in  : CategoryCD
        // out : Categoryデータ
        public M_Category GetCategory(string CategoryCD)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.M_Categorys.Single(m => m.CategoryCD == CategoryCD);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundCategory);
            }
        }

        // データ取得
        // in  : CategoryCode
        // out : Category名
        public string GetCategoryByCode(string CategoryCD)
        {
            if (CategoryCD == string.Empty) return Constants.topPath;
            try
            {
                using (var db = new SalesDbContext()) return db.M_Categorys.Single(m => m.CategoryCD == CategoryCD).CategoryName;
            }
            catch
            {

                return null;
                // throw new Exception("カテゴリーコードが見つかりませんでした。");
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<M_DispCategory> GetDispCategorys()
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispCategory> m_DispCategorys = new List<M_DispCategory>();
                foreach (M_Category m_Category in db.M_Categorys)
                {
                    m_DispCategorys.Add(new M_DispCategory()
                    {
                        CategoryCD = m_Category.CategoryCD,
                        ParentCategory = GetCategoryByCode(m_Category.ParentCategory),
                        CategoryName = m_Category.CategoryName,
                        CategoryKana = m_Category.CategoryKana,
                        DelFLG = m_Category.DelFLG.ToString(),
                        Comments = m_Category.Comments,
                        Timestamp = m_Category.Timestamp,
                        LogData = m_Category.LogData
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispCategory> sortableDispCategory = new SortableBindingList<M_DispCategory>(m_DispCategorys);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Category",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispCategory;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<M_DispCategory> GetDispCategorys(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispCategory> m_DispCategorys = new List<M_DispCategory>();
                int count = 0;
                foreach (M_Category m_Category in db.M_Categorys)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    m_DispCategorys.Add(new M_DispCategory()
                    {
                        CategoryCD = m_Category.CategoryCD,
                        ParentCategory = GetCategoryByCode(m_Category.ParentCategory),
                        CategoryName = m_Category.CategoryName,
                        CategoryKana = m_Category.CategoryKana,
                        DelFLG = m_Category.DelFLG.ToString(),
                        Comments = m_Category.Comments,
                        Timestamp = m_Category.Timestamp,
                        LogData = m_Category.LogData
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispCategory> sortableDispCategory = new SortableBindingList<M_DispCategory>(m_DispCategorys);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Category",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispCategory;
            }
        }

        // データ追加
        // in   : Categoryデータ
        public string PostCategory(M_Category regM_Category)
        {
            using (var db = new SalesDbContext())
            {
                db.M_Categorys.Add(regM_Category);
                db.Entry(regM_Category).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Category",
                Command = "Post",
                Data = CategoryLogData(regM_Category),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

            return string.Empty;
        }

        // データ更新
        // in   : M_Categoryデータ
        // out  : エラーメッセージ 
        public string PutCategory(M_Category regM_Category)
        {
            using (var db = new SalesDbContext())
            {
                M_Category m_Category;
                try
                {
                    m_Category = db.M_Categorys.Single(x => x.CategoryCD == regM_Category.CategoryCD);
                    m_Category.ParentCategory = regM_Category.ParentCategory;
                    m_Category.CategoryName = regM_Category.CategoryName;
                    m_Category.CategoryKana = regM_Category.CategoryKana;
                    m_Category.DelFLG = regM_Category.DelFLG;
                    m_Category.Comments = regM_Category.Comments;
                    m_Category.Timestamp = regM_Category.Timestamp;

                    db.Entry(m_Category).State = EntityState.Modified;
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundCategory, ex);
                    // throw new Exception(_cm.GetMessage(101), ex);
                    return _msc.GetMessage(101);
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

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Category",
                    Command = "Put",
                    Data = CategoryLogData(regM_Category),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }

        // データ削除
        // in       CategoryCD : 削除するカテゴリーCD
        public string DeleteCategory(string CategoryCD)
        {
            M_Category m_Category;
            using (var db = new SalesDbContext())
            {
                try
                {
                    m_Category = db.M_Categorys.Single(x => x.CategoryCD == CategoryCD);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundCategory, ex);
                    // throw new Exception(_cm.GetMessage(101), ex);
                    return _msc.GetMessage(101);
                }
                db.M_Categorys.Remove(m_Category);
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
                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Category",
                    Command = "Delete",
                    Data = CategoryCD,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }

        // カテゴリー名重複チェック
        // in   categoryName : 登録予定カテゴリー名
        // out  true         : 重複無し
        public bool CheckCategoryNameDuplication(String categoryName)
        {
            bool status = true;
            try
            {
                using (var db = new SalesDbContext())
                {
                    M_Category ct = db.M_Categorys.Single(m => m.CategoryName == categoryName);
                    status = false;
                }
            }
            catch { }

            return status;
        }

        // ログデータ作成
        // in       regM_Category : ログ対象データ
        // out      string        : ログ文字列
        private string CategoryLogData(M_Category regM_Category)
        {
            return regM_Category.CategoryCD + ", " +
            GetCategoryByCode(regM_Category.ParentCategory) + ", " +
            regM_Category.CategoryName + ", " +
            regM_Category.CategoryKana + ", " +
            regM_Category.DelFLG.ToString() + ", " +
            regM_Category.Comments;
        }
    }
}
