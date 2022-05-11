using SalesManagement.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model.ContentsManagement.Common
{
    class SaltCommon
    {
        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** Salt関係
        // データ取得（EntityFramework）
        public IEnumerable<Salt> GetSalts()
        {
            using (var db = new SalesDbContext()) return db.Salts.ToList();
        }

        // データ取得（トップデータ）
        public Salt GetSalt()
        {
            try
            {
                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Salt",
                    Command = "Get",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                using (var db = new SalesDbContext())
                {
                    return db.Salts.First();
                }
            }
            catch
            {
                // throw new Exception(Messages.errorNotFoundSalt, ex);
                return null;
            }
        }

        // データ追加
        public void PostSalt(Salt regSalt)
        {
            using (var db = new SalesDbContext())
            {
                regSalt.Status = 1;
                db.Salts.Add(regSalt);
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Salt",
                Command = "Post",
                Data = StaticCommon.SaltLogData(regSalt),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        public void PutSalt(Salt regSalt)
        {
            using (var db = new SalesDbContext())
            {
                Salt salt;
                try
                {
                    salt = db.Salts.First();
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundSalt, ex);
                    // throw new Exception(_cm.GetMessage(105), ex);
                }
                salt.SaltId = regSalt.SaltId;
                salt.SaltCode = regSalt.SaltCode;
                salt.SaltData = regSalt.SaltData;
                salt.Status = regSalt.Status;
                salt.Timestamp = regSalt.Timestamp;
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
                Table = "Salt",
                Command = "Put",
                Data = StaticCommon.SaltLogData(regSalt),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ削除
        public void DeleteSalt()
        {
            using (var db = new SalesDbContext())
            {
                Salt salt;
                try
                {
                    salt = db.Salts.First();
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundSalt, ex);
                    // throw new Exception(_cm.GetMessage(105), ex);
                }
                db.Salts.Remove(salt);
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
                Table = "Salt",
                Command = "Delete",
                Data = string.Empty,
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }
    }
}
