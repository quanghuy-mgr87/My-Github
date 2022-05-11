﻿using SalesManagement.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model.ContentsManagement.Common
{
    class MessageCommon
    {
        // ***** メッセージ関係

        // メッセージチェック
        // out      true  : メッセージ無
        //          false : メッセージ有
        public bool CheckMessage()
        {
            using (var db = new SalesDbContext())
            {
                if (db.Messagess.Count() == 0) return true;
                else return false;
            }
        }

        // メッセージ取得
        public string GetMessage(int no)
        {
            using (var db = new SalesDbContext())
            {
                return db.Messagess.Single(m => m.MessagesNo == no).Message;
            }
        }

        // メッセージ追加
        public void PostMessage(List<Messages> messagess)
        {
            using (var db = new SalesDbContext())
            {
                foreach (Messages message in messagess)
                {
                    db.Messagess.Add(message);
                }
                db.SaveChanges();
            }
        }
    }
}
