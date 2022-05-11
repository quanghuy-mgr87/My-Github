﻿using SalesManagement.DataSet;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.Entity.Disp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static SalesManagement.DataSet.DsColumnsManagement;
using SalesManagement.Model.ContentsManagement.Common;


namespace SalesManagement.Model
{
    // マスター及び売上・在庫・発注関係以外　データ処理クラス
    class CommonFunction
    {

        // ***** メソッド定義

        // 色取得
        // in       sw : 色名
        // out      Colorオブジェクト
        public Color GetColor(string sw)
        {
            switch(sw)
            {
                case Constants.clrWhite:
                    return Color.White;
                case Constants.clrIvory:
                    return Color.Ivory;
                case Constants.clrLightYellow:
                    return Color.LightYellow;
                case Constants.clrLightGray:
                    return Color.LightGray;
                case Constants.clrLightPink:
                    return Color.LightPink;
                case Constants.clrLightBlue:
                    return Color.LightBlue;
                case Constants.clrAquamarine:
                    return Color.Aquamarine;
                case Constants.clrLightSkyBlue:
                    return Color.LightSkyBlue;
                case Constants.clrSkyBlue:
                    return Color.SkyBlue;
                case Constants.clrPaleGreen:
                    return Color.PaleGreen;
                case Constants.clrLightSalmon:
                    return Color.LightSalmon;
                case Constants.clrLightGreen:
                    return Color.LightGreen;
                case Constants.clrBlack:
                    return Color.Black;
                case Constants.clrPink:
                    return Color.Pink;
                case Constants.clrViolet:
                    return Color.Violet;
                case Constants.clrSilver:
                    return Color.Silver;
                case Constants.clrYellow:
                    return Color.Yellow;
                case Constants.clrGold:
                    return Color.Gold;
                case Constants.clrOrange:
                    return Color.Orange;
                case Constants.clrGray:
                    return Color.Gray;
                case Constants.clrOlive:
                    return Color.Olive;
                case Constants.clrPurple:
                    return Color.Purple;
                case Constants.clrBlue:
                    return Color.Blue;
                case Constants.clrLime:
                    return Color.Lime;
                case Constants.clrRed:
                    return Color.Red;
                case Constants.clrBrown:
                    return Color.Brown;
                case Constants.clrMaroon:
                    return Color.Maroon;
                case Constants.clrNavy:
                    return Color.Navy;
                case Constants.clrGreen:
                    return Color.Green;
                case Constants.clrDarkGreen:
                    return Color.DarkGreen;
                default:
                    return Color.Black;
            }
        }

        // 文字数で文字列を分割
        // in       strsrc : 入力文字列
        //          count  : 分割文字数
        public List<string> SplitString(string strsrc, int count)
        {
            // 結果格納リスト
            var strList = new List<string>();

            // 分割数計算
            int length = strsrc.Length / count;
            if (strsrc.Length % count > 0) length++;

            for (int i = 0; i < length; i++)
            {
                // 分割終了
                if (strsrc.Length <= count * i) break;

                // 残りの格納
                if (strsrc.Length < count * (i + 1)) strList.Add(strsrc.Substring(count * i));

                // 分割
                else strList.Add(strsrc.Substring(count * i, count));
            }
            return strList;
        }

        // アクセス権ラベル取得
        // in       accessAuth : アクセス権レベル
        // out      string
        // 0 = 一般、1 = 管理者、2 = 特権管理者
        public string GetAccessAuth(int accessAuth)
        {
            switch (accessAuth)
            {
                case Constants.numGeneral:
                    return Constants.strGeneral;
                case Constants.numManager:
                    return Constants.strManager;
                case Constants.numMaster:
                    return Constants.strMaster;
                default:
                    return null;
            }
        }

    }
}
