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
    class CategoryContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // メッセージ
        private readonly Messages _ms = new Messages();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得（for ComboBox）
        // out コンボボックス用データ（配列）
        public IEnumerable<Category> GetCategorys()
        {
            using (var db = new SalesDbContext())
            {
                List<Category> category = db.Categorys.ToList();

                // 無効のものはリストから削除
                category.RemoveAll(m => m.DelFLG != 0);
                return category;
            }
        }

        // データ取得
        // in  : CategoryId
        // out : Categoryデータ
        public Category GetCategory(int CategoryId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Categorys.Single(m => m.CategoryId == CategoryId);
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
        public string GetCategoryByCode(long CategoryCode)
        {
            if (CategoryCode == 0) return Constants.topPath;
            try
            {
                using (var db = new SalesDbContext()) return db.Categorys.Single(m => m.CategoryCode == CategoryCode).CategoryName;
            }
            catch
            {

                return null;
                // throw new Exception("カテゴリーコードが見つかりませんでした。");
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<DispCategory> GetDispCategorys()
        {
            using (var db = new SalesDbContext())
            {
                List<DispCategory> dispCategorys = new List<DispCategory>();
                foreach (Category Category in db.Categorys)
                {
                    dispCategorys.Add(new DispCategory()
                    {
                        CategoryId = Category.CategoryId,
                        CategoryCode = Category.CategoryCode,
                        ParentCategory = GetCategoryByCode(Category.ParentCategory),
                        CategoryName = Category.CategoryName,
                        CategoryKana = Category.CategoryKana,
                        Comments = Category.Comments,
                        Status = StaticCommon.ConvertToString(1, Category.DelFLG),
                        Timestamp = Category.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispCategory> sortableDispCategory = new SortableBindingList<DispCategory>(dispCategorys);

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
        public IEnumerable<DispCategory> GetDispCategorys(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<DispCategory> dispCategorys = new List<DispCategory>();
                int count = 0;
                foreach (Category Category in db.Categorys)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    dispCategorys.Add(new DispCategory()
                    {
                        CategoryId = Category.CategoryId,
                        CategoryCode = Category.CategoryCode,
                        ParentCategory = GetCategoryByCode(Category.ParentCategory),
                        CategoryName = Category.CategoryName,
                        CategoryKana = Category.CategoryKana,
                        Comments = Category.Comments,
                        Status = StaticCommon.ConvertToString(1, Category.DelFLG),
                        Timestamp = Category.Timestamp
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispCategory> sortableDispCategory = new SortableBindingList<DispCategory>(dispCategorys);

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
        public void PostCategory(Category regCategory)
        {
            using (var db = new SalesDbContext())
            {
                db.Categorys.Add(regCategory);
                db.Entry(regCategory).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Category",
                Command = "Post",
                Data = CategoryLogData(regCategory),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Categoryデータ
        public void PutCategory(Category regCategory)
        {
            using (var db = new SalesDbContext())
            {
                Category Category;
                try
                {
                    Category = db.Categorys.Single(x => x.CategoryId == regCategory.CategoryId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundCategory, ex);
                    // throw new Exception(_cm.GetMessage(101), ex);
                }
                Category.CategoryCode = regCategory.CategoryCode;
                Category.ParentCategory = regCategory.ParentCategory;
                Category.CategoryName = regCategory.CategoryName;
                Category.CategoryKana = regCategory.CategoryKana;
                Category.Comments = regCategory.Comments;
                Category.DelFLG = regCategory.DelFLG;
                Category.Timestamp = regCategory.Timestamp;

                db.Entry(Category).State = EntityState.Modified;
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
                    Table = "Category",
                    Command = "Put",
                    Data = CategoryLogData(regCategory),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // データ削除
        // in       CategoryId : 削除するカテゴリーId
        public void DeleteCategory(int CategoryId)
        {
            Category Category;
            using (var db = new SalesDbContext())
            {
                try
                {
                    Category = db.Categorys.Single(x => x.CategoryId == CategoryId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundCategory, ex);
                    // throw new Exception(_cm.GetMessage(101), ex);
                }
                db.Categorys.Remove(Category);
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
                    Table = "Category",
                    Command = "Delete",
                    Data = CategoryId.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
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
                    Category ct = db.Categorys.Single(m => m.CategoryName == categoryName);
                    status = false;
                }
            }
            catch {}

            return status;
        }

        // ログデータ作成
        // in       regCategory : ログ対象データ
        // out      string      : ログ文字列
        private string CategoryLogData(Category regCategory)
        {
            return regCategory.CategoryId.ToString() + ", " +
            regCategory.CategoryCode.ToString() + ", " +
            GetCategoryByCode(regCategory.ParentCategory) + ", " +
            regCategory.CategoryName + ", " +
            regCategory.CategoryKana + ", " +
            regCategory.Comments + ", " +
            StaticCommon.ConvertToString(1, regCategory.DelFLG);
        }
    }
}
