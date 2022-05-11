using SalesManagement.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model.ContentsManagement.Common
{
    class ControlPanelCommon
    {
        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        public IEnumerable<ControlPanel> GetControlPanels()
        {
            using (var db = new SalesDbContext()) return db.ControlPanels.ToList();
        }

        // データ取得（ログ無し）
        public ControlPanel GetInitialControlPanel()
        {
            try
            {
                using (var db = new SalesDbContext())
                {
                    return db.ControlPanels.First();
                }
            }
            catch
            {
                // throw new Exception(Messages.errorNotFoundControlPanel, ex);
                // throw new Exception(_cm.GetMessage(103), ex);
                return null;
            }
        }

        // データ取得（トップデータ）
        public ControlPanel GetControlPanel()
        {
            try
            {
                using (var db = new SalesDbContext())
                {
                    // ログ出力
                    var operationLog = new OperationLog()
                    {
                        EventRaisingTime = DateTime.Now,
                        Operator = _logonUser,
                        Table = "ControlPanel",
                        Command = "Get",
                        Data = string.Empty,
                        Comments = string.Empty
                    };
                    StaticCommon.PostOperationLog(operationLog);

                    return db.ControlPanels.First();
                }
            }
            catch
            {
                // throw new Exception(Messages.errorNotFoundControlPanel, ex);
                // throw new Exception(_cm.GetMessage(103), ex);
                return null;
            }
        }

        // データ追加
        public void PostControlPanel(ControlPanel regControlPanel)
        {
            using (var db = new SalesDbContext())
            {
                regControlPanel.Status = 1;
                db.ControlPanels.Add(regControlPanel);
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "ControlPanel",
                Command = "Post",
                Data = StaticCommon.ControlPanelLogData(regControlPanel),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        public void PutControlPanel(ControlPanel regControlPanel)
        {
            using (var db = new SalesDbContext())
            {
                ControlPanel controlPanel;
                try
                {
                    controlPanel = db.ControlPanels.First();
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundControlPanel, ex);
                    // throw new Exception(_cm.GetMessage(103), ex);
                }
                controlPanel.ControlPanelId = regControlPanel.ControlPanelId;
                controlPanel.FileName = regControlPanel.FileName;
                controlPanel.PageSize = regControlPanel.PageSize;
                controlPanel.LockSttRecord = regControlPanel.LockSttRecord;
                controlPanel.LockEndRecord = regControlPanel.LockEndRecord;
                controlPanel.Status = regControlPanel.Status;
                controlPanel.Timestamp = regControlPanel.Timestamp;
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
                Table = "ControlPanel",
                Command = "Put",
                Data = StaticCommon.ControlPanelLogData(regControlPanel),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ削除
        public void DeleteControlPanel()
        {
            using (var db = new SalesDbContext())
            {
                ControlPanel controlPanel;
                try
                {
                    controlPanel = db.ControlPanels.First();
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundControlPanel, ex);
                    // throw new Exception(_cm.GetMessage(103), ex);
                }
                db.ControlPanels.Remove(controlPanel);
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
                Table = "ControlPanel",
                Command = "Delete",
                Data = string.Empty,
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }


    }
}
