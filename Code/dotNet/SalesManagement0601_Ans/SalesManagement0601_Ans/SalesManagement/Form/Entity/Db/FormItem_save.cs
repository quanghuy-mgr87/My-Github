using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SalesManagement.Model;
using SalesManagement.Model.ContentsManagement;
using SalesManagement.Model.ContentsManagement.Common;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.Entity.Disp;

namespace SalesManagement
{
    // 商品マスター　フォームクラス
    public partial class FormItem : Form
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private CommonFunction _cm = new CommonFunction();

        // データベース処理モジュール（項目処理）
        private ColumnsManagementCommon _cmc = new ColumnsManagementCommon();

        // データベース処理モジュール（コードカウンター）
        private CodeCounterCommon _cc = new CodeCounterCommon();

        // 入力チェックモジュール
        private InputCheck _ic = new InputCheck();

        // メッセージ
        private Messages _ms = new Messages();

        // データベース処理モジュール（Item）
        // private ItemContents _it = new ItemContents();
        private M_ItemContents _it = new M_ItemContents();

        // データベース処理モジュール（Maker）
        private M_MakerContents _mk = new M_MakerContents();

        // データベース処理モジュール（Category）
        private M_CategoryContents _ct = new M_CategoryContents();

        // データベース処理モジュール（Unit）
        private UnitContents _ut = new UnitContents();

        // ***** プロパティ定義

        // トップフォーム
        public TopForm _topForm;

        // 売上フォーム
        public SalesForm _salesForm;

        // 在庫フォーム
        public StockForm _stockForm;

        // 発注フォーム
        public OrderForm _orderForm;
        public FormPlaceOrder _formPlaceOrder;
        public FormPurchase _formPurchase;

        // 集計フォーム
        public AggregationCategoryFormItem _aggregationCategoryFormItem;

        // 起動モード
        private int _mode;                              // 0:通常モード、1:選択モード

        // 選択行番号
        private int _lineNo;

        // バージョン管理
        private byte[] _timeStamp;

        // ページング
        private int _pageCountPaging;                   // 全表示ページ数
        private int _recordCount;                       // 全表示データ数
        private int _pageSizePaging;                    // １ページ表示データ行数
        private int _currentPage;                       // 現在のページ
        private int _recordNo;                          // ページ先頭位置のデータ（スタートデータ）
        private IEnumerable<M_DispItem> _dispItemPaging;         // 表示用データ

        // 印刷
        private int _pageCountPrinting;                 // 全印刷ページ数
        private int _pageNumber = 0;                    // 印刷ページ番号
        private int _pageSizePrinting;                  // １ページ印刷データ行数
        private List<M_DispItem> _dispItemPrinting;       // 印刷用データ

        // コンストラクタ
        public FormItem()
        {
            InitializeComponent();
        }

        // TopForm呼出用コンストラクタ
        public FormItem(TopForm topForm)
        {
            _topForm = topForm;
            InitializeComponent();
        }

        // SalesForm呼出用コンストラクタ
        public FormItem(SalesForm salesForm, int mode)
        {
            _salesForm = salesForm;
            _mode = mode;
            InitializeComponent();

            // 選択ボタンに変更
            if (mode == 1) buttonClose.Text = Constants.lblSelectReturn;
        }

        // StockForm呼出用コンストラクタ
        public FormItem(StockForm stockForm, int mode)
        {
            _stockForm = stockForm;
            _mode = mode;
            InitializeComponent();

            // 選択ボタンに変更
            if (mode == 1) buttonClose.Text = Constants.lblSelectReturn;
        }

        // OrderForm呼出用コンストラクタ
        public FormItem(OrderForm orderForm, int mode)
        {
            _orderForm = orderForm;
            _mode = mode;
            InitializeComponent();

            // 選択ボタンに変更
            if (mode == 1) buttonClose.Text = Constants.lblSelectReturn;
        }

        public FormItem(FormPlaceOrder formPlaceOrder, int mode)
        {
            _formPlaceOrder = formPlaceOrder;
            _mode = mode;
            InitializeComponent();

            // 選択ボタンに変更
            if (mode == 1) buttonClose.Text = Constants.lblSelectReturn;
        }

        // FormPurchase呼出用コンストラクタ
        public FormItem(FormPurchase formPurchase, int mode)
        {
            _formPurchase = formPurchase;
            _mode = mode;
            InitializeComponent();

            // 選択ボタンに変更
            if (mode == 1) buttonClose.Text = Constants.lblSelectReturn;
        }

        // AggregationCategoryFormItem呼出用
        public FormItem(AggregationCategoryFormItem aggregationCategoryFormItem, SalesForm salesForm)
        {
            _salesForm = salesForm;
            _aggregationCategoryFormItem = aggregationCategoryFormItem;

            InitializeComponent();

            // 選択ボタンに変更
            buttonClose.Text = Constants.lblSelectReturn;
        }

        // *** イベント処理 *****

        // ロード処理
        // 8.1.0.1 初期化
        private void Form_Load(object sender, EventArgs e)
        {
            // フォーム初期設定
            FormInitialSetting();

            // データグリッドビュー初期設定
            DataGridViewInitialSetting();

            // 入力コントロール初期設定
            InputInitialSetting();

            // コンボボックス初期設定
            ComboBoxSetting();

            // ログオンユーザー情報 ContentsManageモジュールへセット
            String name = string.Empty;
            if (_topForm != null) name = _topForm._staff.M_Staff[0].StaffName;
            else if (_salesForm != null) name = _salesForm._staff.M_Staff[0].StaffName;
            else if (_stockForm != null) name = _stockForm._staff.M_Staff[0].StaffName;
            else if (_orderForm != null) name = _orderForm._staff.M_Staff[0].StaffName;
            else if (_formPlaceOrder != null) name = _formPlaceOrder._staff.M_Staff[0].StaffName;
            else if (_formPurchase != null) name = _formPurchase._staff.M_Staff[0].StaffName;
            _cmc._logonUser = name;
            _it._logonUser = name;
            _mk._logonUser = name;
            _ct._logonUser = name;
            _ut._logonUser = name;

            // ユーザー名画面表示
            textBoxLoginName.Text = name;

            // データ取得&表示（データバインド）
            _dispItemPaging = _it.GetDispItems();
            dataGridView.DataSource = _dispItemPaging;

            // 全データ数取得
            _recordCount = _dispItemPaging.Count();
        }

        // ロード最終処理（データバインド後に実行）
        // 8.1.0.2 初期化（最終処理）
        private void Form_Shown(object sender, EventArgs e)
        {
            // ヘッダー設定
            DataGridViewHeaderSetting();

            // 初期表示サイズ設定
            this.Width = Constants.itemFormWidth;
            this.Height = Constants.itemFormHeight;

            // 入力クリア
            ClearInput();

            // ページング初期化
            ClearPaging();
        }

        // 登録ボタン
        // 8.1.1 商品情報登録
        private void ButtonRegist_Click(object sender, EventArgs e)
        {
            // 8.1.1.1 妥当な商品データ取得
            if (!GetValidDataAtRegistration()) return;

            // 8.1.1.2 商品情報作成
            var regItem = GenerateDataAtRegistration();

            // 8.1.1.3 商品情報登録
            RegisterItemInformation(regItem);

        }

        //
        //
        // 8.1.1.1 妥当な商品データ取得（新規登録）
        //
        //
        private bool GetValidDataAtRegistration()
        {
            labelMessage.Text = null;

            // 商品データの形式チェック
            // 商品IDの適否

            // コードカウンターセット（空白の場合カウンターをセット）
            if (textBoxItemCD.Text.Trim() == string.Empty) textBoxItemCD.Text = _cc.GetCodeIncrement(Constants.divisionCode, out _timeStamp).ToString();

            if (!_ic.NumericRangeCheck(textBoxItemCD.Text, 0, Constants.codeMax, out string errorMessage))
            {
                textBoxItemCD.Focus();
                // labelMessage.Text = errorMessage;
                MessageBox.Show(errorMessage);
                return false;
            };

            // 商品名の適否
            if (string.IsNullOrEmpty(textBoxItemName.Text.Trim()))
            {
                textBoxItemName.Focus();
                // labelMessage.Text = Messages.nullNotAllowed;
                MessageBox.Show(Messages.nullNotAllowed);
                return false;
            }
            if (!_ic.FullWidthCharCheck(textBoxItemName.Text, out errorMessage))
            {
                textBoxItemName.Focus();
                // labelMessage.Text = errorMessage;
                MessageBox.Show(errorMessage);
                return false;
            }

            // 商品読み仮名の適否
            // if (!_ic.HalfAlphabetCheck(textBoxItemKana.Text, out errorMessage))
            // {
            //     textBoxItemName.Focus();
            //     labelMessage.Text = errorMessage;
            //     MessageBox.Show(errorMessage);
            //     return false;
            // }

            // 商品データの重複チェック
            if (!_cc.CheckCodeDuplication(Constants.numItem, int.Parse(textBoxItemCD.Text), out errorMessage))
            {
                textBoxItemCD.Focus();
                // labelMessage.Text = errorMessage;
                MessageBox.Show(errorMessage);
                return false;
            }

            return true;
        }

        //
        //
        // 8.1.1.2 商品情報作成
        //
        //
        // out      Item : Itemデータ
        private M_Item GenerateDataAtRegistration()
        {
            return new M_Item
            {
                ItemCD = textBoxItemCD.Text,
                ItemName = textBoxItemName.Text,
                ItemKana = textBoxItemKana.Text,
                ModelNo = textBoxModelNo.Text,
                JanCD = textBoxJanCD.Text,
                ListPrice = int.Parse((textBoxListPrice.Text != string.Empty) ? textBoxListPrice.Text : "0"),
                SellingPrice = int.Parse((textBoxSellingPrice.Text != string.Empty) ? textBoxSellingPrice.Text : "0"),
                MakerID = int.Parse(comboBoxMakers.SelectedValue.ToString()),
                CategoryID = long.Parse(comboBoxCategorys.SelectedValue.ToString()),
                DelFLG = checkBoxDelFLG.Checked,
                Comments = textBoxComments.Text,
            };
        }

        //
        //
        // 8.1.1.3 商品情報登録
        //
        //
        private void RegisterItemInformation(M_Item regItem)
        {
            // 商品情報登録
            var errorMessage = _it.PostItem(regItem);
            if (errorMessage != string.Empty) MessageBox.Show(errorMessage);
            else
            {
                // コードカウンターインクリメント
                _cc.PutCodeById(Constants.divisionCode, _cc.GetCodeIncrement(Constants.divisionCode, out _timeStamp), _timeStamp);
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();

        }

        // 更新ボタン
        // 8.1.2 商品情報更新
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            // 8.1.2.1 妥当な商品データ取得
            if (!GetValidDataAtUpdate()) return;

            // 8.1.2.2（8.1.1.2）商品情報作成
            var regItem = GenerateDataAtRegistration();

            // 8.1.2.3 商品情報更新
            UpdateItemInformation(regItem);

        }

        //
        //
        // 8.1.2.1 妥当な商品データ取得（更新）
        //
        //
        private bool GetValidDataAtUpdate()
        {
            labelMessage.Text = null;

            // 商品データの形式チェック
            // 商品IDの適否
            if (!_ic.NumericRangeCheck(textBoxItemCD.Text, 0, Constants.codeMax, out string errorMessage))
            {
                textBoxItemCD.Focus();
                // labelMessage.Text = errorMessage;
                MessageBox.Show(errorMessage);
                return false;
            };

            // 商品名の適否
            if (string.IsNullOrEmpty(textBoxItemName.Text.Trim()))
            {
                textBoxItemName.Focus();
                // labelMessage.Text = Messages.nullNotAllowed;
                MessageBox.Show(Messages.nullNotAllowed);
                return false;
            }
            if (!_ic.FullWidthCharCheck(textBoxItemName.Text, out errorMessage))
            {
                textBoxItemName.Focus();
                // labelMessage.Text = errorMessage;
                MessageBox.Show(errorMessage);
                return false;
            }

            // 商品読み仮名の適否
            // if (!_ic.HalfAlphabetCheck(textBoxItemKana.Text, out errorMessage))
            // {
            //     textBoxItemName.Focus();
            //     labelMessage.Text = errorMessage;
            //     MessageBox.Show(errorMessage);
            //     return false;
            // }

            return true;
        }

        //
        //
        // 8.1.2.3 商品情報更新
        //
        //
        private void UpdateItemInformation(M_Item regItem)
        {
            // バージョン情報取得
            regItem.Timestamp = _timeStamp;

            // データ行番号をセットし、商品情報更新
            regItem.ItemCD = textBoxItemCD.Text;
            var errorMessage = _it.PutItem(regItem);
            if (errorMessage != string.Empty) MessageBox.Show(errorMessage);

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();

        }

        // 削除ボタン
        // 8.1.5 商品情報削除
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            // データ行番号を取得
            string ItemCD = textBoxItemCD.Text;
            using (var dcm = new DeleteConfirmForm())
            {
                // 確認後、削除実行
                if (dcm.ShowDialog(this) == DialogResult.OK) Delete(ItemCD);
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
        }

        // リセットボタン
        // 8.1.6 商品情報入力リセット
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            // フォームの入力データをクリアする
            ClearInput();
        }

        // 閉じるボタン
        // 8.1.7 画面クローズ
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            // 画面を閉じ、メモリを解放する
            Dispose();
        }

        // データグリッドビュークリック処理（行選択）
        // e.RowIndex : 選択行
        private void DataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // ラインNo取得
            _lineNo = e.RowIndex;

            // 行セレクトを解除
            if (dataGridView.SelectionMode == DataGridViewSelectionMode.CellSelect) return;

            // データグリッドビュー　→　フォームデータ読込
            DataCopy();

            // ボタン表示切替
            buttonRegist.Enabled = false;
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;
        }

        // ***** 入力チェック（各入力項目から入力フォーカスが離れる時にチェック）
        // 商品コード
        private void TextBoxItemCD_Leave(object sender, EventArgs e)
        {
            // 空白の時はチェックしない
            if (textBoxItemCD.Text == string.Empty) return;

            // 半角英数字チェック
            if (!_ic.HalfAlphabetNumericCheck(textBoxItemCD.Text, out string errorMessage))
            {
                textBoxItemCD.Focus();
                // labelMessage.Text = errorMessage;
                MessageBox.Show(errorMessage);
                return;
            };
        }

        // 商品名
        private void TextBoxItemName_Leave(object sender, EventArgs e)
        {
            if (textBoxItemName.Text == string.Empty) return;

            // 全角チェック
            if (!_ic.FullWidthCharCheck(textBoxItemName.Text, out string errorMessage)) textBoxItemName.Focus();
            // labelMessage.Text = errorMessage;
            if (errorMessage != string.Empty) MessageBox.Show(errorMessage);
        }

        // 商品名カナ
        private void TextBoxItemKana_Leave(object sender, EventArgs e)
        {
            if (textBoxItemKana.Text == string.Empty) return;

            // 半角英字チェック
            if (!_ic.HalfAlphabetCheck(textBoxItemKana.Text, out string errorMessage)) textBoxItemKana.Focus();
            // labelMessage.Text = errorMessage;
            if (errorMessage != string.Empty) MessageBox.Show(errorMessage);
        }

        // モデルNo.
        private void TextBoxModelNo_Leave(object sender, EventArgs e)
        {
            if (textBoxModelNo.Text == string.Empty) return;

            // 半角英数記号チェック
            if (!_ic.HalfCharCheck(textBoxModelNo.Text, out string errorMessage)) textBoxModelNo.Focus();
            // labelMessage.Text = errorMessage;
            if (errorMessage != string.Empty) MessageBox.Show(errorMessage);
        }

        // 定価
        private void TextBoxListPrice_Leave(object sender, EventArgs e)
        {
            if (textBoxListPrice.Text == string.Empty) return;

            // 値段チェック
            if (!_ic.PriceCheck(textBoxListPrice.Text, out string errorMessage)) textBoxListPrice.Focus();
            // labelMessage.Text = errorMessage;
            if (errorMessage != string.Empty) MessageBox.Show(errorMessage);
        }

        // 販売価格
        private void TextBoxSellingPrice_Leave(object sender, EventArgs e)
        {
            if (textBoxSellingPrice.Text == string.Empty) return;

            // 値段チェック
            if (!_ic.PriceCheck(textBoxSellingPrice.Text, out string errorMessage)) textBoxSellingPrice.Focus();
            // labelMessage.Text = errorMessage;
            if (errorMessage != string.Empty) MessageBox.Show(errorMessage);
        }

        // 備考
        private void TextBoxComments_Leave(object sender, EventArgs e)
        {

        }

        // ページサイズ
        private void TextBoxPageSize_Leave(object sender, EventArgs e)
        {
            // 数値チェック
            if (!_ic.NumericCheck(textBoxPageSize.Text, out string errorMessage)) textBoxPageSize.Focus();
            // labelMessage.Text = errorMessage;
            MessageBox.Show(errorMessage);
        }

        // ***** ページング処理
        // 以下参照
        // https://support.microsoft.com/ja-jp/help/307710/how-to-perform-paging-with-the-datagrid-windows-control-by-using-visua
        // １ページ行数変更
        private void ButtonPageSizeChange_Click(object sender, EventArgs e)
        {
            // ページサイズ
            if (!_ic.NumericCheck(textBoxPageSize.Text, out string errorMessage))
            {
                textBoxPageSize.Focus();
                // labelMessage.Text = errorMessage;
                MessageBox.Show(errorMessage);
                return;
            }

            // １ページ行数取得
            _pageSizePaging = Convert.ToInt32(textBoxPageSize.Text);

            // 全データ数取得
            _recordCount = _dispItemPaging.Count();

            // 全ページ数取得
            if (_pageSizePaging != 0)
            {
                _pageCountPaging = _recordCount / _pageSizePaging;

                // 全ページ数調整
                if ((_recordCount % _pageSizePaging) > 0) _pageCountPaging += 1;
            }
            else
                _pageCountPaging = 1;


            // 表示ページ＆ページトップデータ初期化
            _currentPage = 1;
            _recordNo = 0;

            // データ表示
            LoadPage();

            // データグリッド選択解除
            dataGridView.ClearSelection();
        }

        // ファーストページ表示
        private void ButtonFirstPage_Click(object sender, EventArgs e)
        {
            if (_pageSizePaging == 0)
            {
                return;
            }
            // ファーストページチェック
            if (_currentPage == 1)
            {
                MessageBox.Show(Messages.pagingFirstPage);
                // MessageBox.Show(_cm.GetMessage(1));
                return;
            }
            _currentPage = 1;
            _recordNo = 0;
            LoadPage();
        }

        // 前ページ表示
        private void ButtonPreviousPage_Click(object sender, EventArgs e)
        {
            if (_pageSizePaging == 0) return;

            if (_currentPage == _pageCountPaging)
            {
                _recordNo = _pageSizePaging * (_currentPage - 2);
            }
            _currentPage -= 1;

            // ファーストページチェック
            if (_currentPage < 1)
            {
                MessageBox.Show(Messages.pagingFirstPage);
                // MessageBox.Show(_cm.GetMessage(1));
                _currentPage = 1;
                return;
            }
            else
            {
                _recordNo = _pageSizePaging * (_currentPage - 1);
            }
            LoadPage();
        }

        // 次ページ表示
        private void ButtonNextPage_Click(object sender, EventArgs e)
        {
            //If the user did not click the "Fill Grid" button, then return.
            //Check if the user clicks the "Fill Grid" button.
            if (_pageSizePaging == 0) return;

            _currentPage += 1;
            if (_currentPage > _pageCountPaging)
            {
                _currentPage = _pageCountPaging;

                // ラストページチェック
                if (_recordNo == _recordCount)
                {
                    MessageBox.Show(Messages.pagingLastPage);
                    // MessageBox.Show(_cm.GetMessage(2));
                    return;
                }
            }
            LoadPage();
        }

        // ラストページ表示
        private void ButtonLastPage_Click(object sender, EventArgs e)
        {
            if (_pageSizePaging == 0) return;

            // ラストページチェック
            if (_recordNo == _recordCount)
            {
                MessageBox.Show(Messages.pagingLastPage);
                // MessageBox.Show(_cm.GetMessage(1));
                return;
            }
            _currentPage = _pageCountPaging;
            _recordNo = _pageSizePaging * (_currentPage - 1);
            LoadPage();
        }


        // 印刷
        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            // 用紙設定
            foreach (PaperSize ps in printDocument.PrinterSettings.PaperSizes)
            {
                // A4
                if (ps.Kind == PaperKind.A4)
                {
                    printDocument.DefaultPageSettings.PaperSize = ps;
                    break;
                }
            }

            // 用紙の向き(横：true、縦：false)
            printDocument.DefaultPageSettings.Landscape = true;

            // ページ番号初期化
            _pageNumber = 1;

            // 印刷ドキュメント指定
            printPreviewDialog.Document = printDocument;

            // 表示位置とサイズ設定
            printPreviewDialog.StartPosition = FormStartPosition.CenterScreen;
            printPreviewDialog.Size = new Size(640, 400);

            // １ページ行数設定
            _pageSizePrinting = Constants.pageSizePrinting;

            // 印刷ページ数取得
            GetPrintPage();

            // プレビュー画面表示
            printPreviewDialog.ShowDialog(this);
        }

        // 印刷イベント
        // textBoxPageSize == 0 : _pageSizePrinting（１ページ印刷行数）で全行印刷
        // textBoxPageSize != 0 : 表示されているページのみ印刷
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // ページ印刷データ取得

            // 全行印刷
            if (Convert.ToInt32(textBoxPageSize.Text) == 0)
            {
                int st = _pageSizePrinting * (_pageNumber - 1);
                if (_pageNumber == _pageCountPrinting) _dispItemPrinting = _it.GetDispItems(st, _recordCount).ToList();
                else _dispItemPrinting = _it.GetDispItems(st, st + _pageSizePrinting).ToList();
            }

            // 表示ページのみ印刷
            else
            {
                int startRec;
                int endRec;
                if (_currentPage == _pageCountPaging) endRec = _recordCount;
                else endRec = _pageSizePaging * _currentPage;
                startRec = _recordNo - _pageSizePaging;

                if (_pageCountPrinting == 1)
                {
                    _dispItemPrinting = _it.GetDispItems(startRec, endRec).ToList();
                }
                else
                {
                    int st = startRec + (_pageSizePrinting * (_pageNumber - 1));
                    if (endRec <= st + _pageSizePrinting) _dispItemPrinting = _it.GetDispItems(st, endRec).ToList();
                    else _dispItemPrinting = _it.GetDispItems(st, st + _pageSizePrinting).ToList();
                }
            }

            // データ構造取得
            M_DispItem dispItem = new M_DispItem();

            // 項目数取得（xxxId, TimeStamp を項目に含めない）
            int columnsCount = dispItem.GetType().GetProperties().Count() - 2;

            // dataGridView 描画

            // カスタムデータ取得
            List<ColumnsManagement> columnsManagements = _cmc.GetColumnsManagements().Where(m => (m.ClassNumber == Constants.numItem) & (m.DisplayOrPrint == Constants.numPrint)).ToList();

            // ライン長計算
            var lineWidth = 0;
            int count = 0;
            foreach (ColumnsManagement cm in columnsManagements)
            {
                if (cm.Visible == true) { count++; }
                else if (cm.ColumnWidth != 0) { lineWidth += cm.ColumnWidth; count++; }
            }
            lineWidth += Constants.defaultColumnLength * (columnsCount - count);

            // ヘッダー 描画

            // ヘッダートップライン
            e.Graphics.DrawLine(Pens.Black, Constants.leftTopX, Constants.leftTopY, Constants.leftTopX + lineWidth, Constants.leftTopY);
            var columnCount = 0;

            var lineW = 0;          // ライン長ワーク
            var columnH = 0;        // カラム高ワーク
            foreach (PropertyInfo prop in dispItem.GetType().GetProperties())
            {
                // DisplayName属性取得
                if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr)
                {
                    columnCount++;

                    // カスタム情報取得
                    List<ColumnsManagement> cms = columnsManagements.Where(m => (m.ColumnNumber + 1) == columnCount).ToList();

                    // 項目区切りライン
                    if (cms.Count() == 0 || (cms.Count() != 0 && cms.First().Visible == false)) e.Graphics.DrawLine(Pens.Black, Constants.leftTopX + lineW, Constants.leftTopY + columnH, Constants.leftTopX + lineW, Constants.leftTopY + columnH + Constants.defaultColumnHeight);

                    // ヘッダー文字
                    string headerName;
                    if (cms.Count() != 0 && cms.First().HeaderName != string.Empty) headerName = cms.First().HeaderName;
                    else headerName = dispNameAttr.DisplayName;
                    if (cms.Count() == 0 || (cms.Count() != 0 && cms.First().Visible == false)) e.Graphics.DrawString(headerName, this.Font, Brushes.Black, Constants.leftTopX + Constants.strMarginX + lineW, Constants.leftTopY + columnH + Constants.strMarginY);

                    // ライン長計算
                    if (cms.Count() != 0 && cms.First().Visible == false && cms.First().ColumnWidth != 0) lineW += cms.First().ColumnWidth;
                    else if (cms.Count() == 0) lineW += Constants.defaultColumnLength;
                }
            }

            // 項目区切りライン（終）
            e.Graphics.DrawLine(Pens.Black, Constants.leftTopX + lineW, Constants.leftTopY + columnH, Constants.leftTopX + lineW, Constants.leftTopY + columnH + Constants.defaultColumnHeight);

            // ヘッダーボトムライン
            columnH += Constants.defaultColumnHeight;
            e.Graphics.DrawLine(Pens.Black, Constants.leftTopX, Constants.leftTopY + columnH, Constants.leftTopX + lineWidth, Constants.leftTopY + columnH);

            // データ描画
            foreach (M_DispItem ds in _dispItemPrinting)
                {
                    columnCount = 0;
                lineW = 0;

                // 項目区切りライントップY座標保存
                int columnTop = columnH;

                columnH += Constants.defaultColumnHeight;

                // １カラム最大文字行数取得
                int subRowCount = 1;

                foreach (PropertyInfo prop in dispItem.GetType().GetProperties())
                {
                    // DisplayName属性取得
                    if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr)
                    {
                        columnCount++;

                        // カスタム情報取得
                        List<ColumnsManagement> cms = columnsManagements.Where(m => (m.ColumnNumber + 1) == columnCount).ToList();

                        // データ文字
                        Font font;
                        string fontFamily = this.Font.FontFamily.Name;
                        float fontSize = this.Font.Size;
                        font = new Font(fontFamily, fontSize);

                        string data = prop.GetValue(ds)?.ToString();

                        // columnH は、カラムアンダーラインのY座標なので、strH は、文字のY座標を表す。
                        int strH = columnH - Constants.defaultColumnHeight;

                        if (cms.Count() != 0)
                        {
                            // フォントファミリー適用
                            if (0 < cms.First().FontFamily) fontFamily = StaticCommon.ConvertToString(6, cms.First().FontFamily);

                            // フォントサイズ適用
                            if (0 < cms.First().FontSize) fontSize = cms.First().FontSize;

                            // フォント太字適用
                            if (cms.First().Bold == true) font = new Font(fontFamily, fontSize, FontStyle.Bold);
                            else font = new Font(fontFamily, fontSize);

                            // 非表示適用
                            if (cms.First().Visible == false)
                            {
                                // 最大文字長チェック
                                if (cms.First().CharMaxLength != 0 && cms.First().CharMaxLength < data.Length)
                                {
                                    List<string> strdata = _cm.SplitString(data, cms.First().CharMaxLength);
                                    int refRowCount = 0;
                                    foreach (string dt in strdata)
                                    {
                                        e.Graphics.DrawString(dt, font, Brushes.Black, Constants.leftTopX + Constants.strMarginX + lineW, Constants.leftTopY + Constants.strMarginY + strH + (int)(Constants.defaultColumnHeight * refRowCount * 0.8));
                                        refRowCount++;

                                        // ラップモードチェック
                                        if (cms.First().WrapMode == false) break;
                                    }
                                    if (subRowCount < refRowCount) subRowCount = refRowCount;
                                }
                                else
                                {
                                    // 全角・半角チェック
                                    char ch;
                                    if (_ic.FullWidthCharCheck(data, out string errorMessage)) ch = '　';
                                    else ch = ' ';

                                    // 文字レイアウト適用
                                    if (cms.First().CharMaxLength != 0 && cms.First().CharLayout == 1)                // 右寄せ
                                    {
                                        data = data.ToString().PadLeft(cms.First().CharMaxLength, ch);
                                    }
                                    else if (cms.First().CharMaxLength != 0 && cms.First().CharLayout == 2)           // センター
                                    {
                                        int calcLength = (((cms.First().CharMaxLength - data.Length) / 2) + data.Length);
                                        data = data.ToString().PadLeft(calcLength, ch);
                                    }
                                    e.Graphics.DrawString(data, font, Brushes.Black, Constants.leftTopX + Constants.strMarginX + lineW, Constants.leftTopY + Constants.strMarginY + strH);
                                }
                            }
                        }
                        else
                            e.Graphics.DrawString(data, font, Brushes.Black, Constants.leftTopX + Constants.strMarginX + lineW, Constants.leftTopY + Constants.strMarginY + strH);

                        // 項目区切りライン
                        // e.Graphics.DrawLine(Pens.Black, Constants.leftTopX + lineW, Constants.leftTopY + columnH - Constants.defaultColumnHeight, Constants.leftTopX + lineW, Constants.leftTopY + columnH);

                        // ライン長計算
                        if (cms.Count() != 0 && cms.First().Visible == false && cms.First().ColumnWidth != 0) lineW += cms.First().ColumnWidth;
                        else if (cms.Count() == 0) lineW += Constants.defaultColumnLength;
                    }
                }

                // １カラム複数行文字表示の場合の修正
                columnH = columnH + (int)(Constants.defaultLineHeight * (subRowCount - 1) * 0.8);

                // 項目区切りライン
                columnCount = 0;
                lineW = 0;
                foreach (PropertyInfo prop in dispItem.GetType().GetProperties())
                {
                    // DisplayName属性取得
                    if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr)
                    {
                        columnCount++;

                        // カスタム情報取得
                        List<ColumnsManagement> cms = columnsManagements.Where(m => (m.ColumnNumber + 1) == columnCount).ToList();

                        // 項目区切りライン
                        e.Graphics.DrawLine(Pens.Black, Constants.leftTopX + lineW, Constants.leftTopY + columnTop, Constants.leftTopX + lineW, Constants.leftTopY + columnH);

                        // ライン長計算
                        if (cms.Count() != 0 && cms.First().Visible == false && cms.First().ColumnWidth != 0) lineW += cms.First().ColumnWidth;
                        else if (cms.Count() == 0) lineW += Constants.defaultColumnLength;
                    }
                }

                // 項目区切りライン（終）
                e.Graphics.DrawLine(Pens.Black, Constants.leftTopX + lineWidth, Constants.leftTopY + columnTop, Constants.leftTopX + lineWidth, Constants.leftTopY + columnH);

                // データボトムライン
                e.Graphics.DrawLine(Pens.Black, Constants.leftTopX, Constants.leftTopY + columnH, Constants.leftTopX + lineWidth, Constants.leftTopY + columnH);
            }

            // タイトル印刷
            e.Graphics.DrawString(this.Text, this.Font, Brushes.Black, Constants.titleX, Constants.titleY);

            // ページ数印刷
            e.Graphics.DrawString(String.Format("{0}/{1}ページ", _pageNumber, _pageCountPrinting), this.Font, Brushes.Black, Constants.pageX, Constants.pageY);

            // 複数ページ印刷コントロール
            if (_pageNumber < _pageCountPrinting)
            {
                // 印刷継続
                e.HasMorePages = true;

                // ページ番号加算
                _pageNumber++;
            }
            else
            {
                // 印刷終了
                e.HasMorePages = false;

                // ページ番号初期化
                _pageNumber = 1;
            }
        }

        // メーカー選択
        private void ButtonSelectMaker_Click(object sender, EventArgs e)
        {
                MakerForm _mkf = new MakerForm(this, _salesForm);
                _mkf.ShowDialog();
        }

        // カテゴリー選択
        private void ButtonSelectCategory_Click(object sender, EventArgs e)
        {
            CategoryForm _ctf = new CategoryForm(this, _salesForm);
            _ctf.ShowDialog();
        }

        // ログアウト
        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            _topForm.Logon();
            Dispose();
        }

        // *** 内部処理 *****

        // 登録・更新入力チェック
        // in       sw : 0 = チェック無し、1 = 新規登録、2 = 更新
        // out      bool : true = チェックOK
        private bool InputCheck(int sw)
        {
            labelMessage.Text = string.Empty;
            if (sw == 0) return true;

            // 半角英数字チェック
            if (!_ic.HalfAlphabetNumericCheck(textBoxItemCD.Text, out string errorMessage))
            {
                textBoxItemCD.Focus();
                // labelMessage.Text = errorMessage;
                MessageBox.Show(errorMessage);
                return false;
            };

            // コード重複チェック
            if (sw == 1)
            {
                if (!_cc.CheckCodeDuplication(Constants.numItem, int.Parse(textBoxItemCD.Text), out errorMessage))
                {
                    textBoxItemCD.Focus();
                    // labelMessage.Text = errorMessage;
                    MessageBox.Show(errorMessage);
                    return false;
                }
            }

            // 商品名
            if (textBoxItemName.Text == string.Empty || !_ic.FullWidthCharCheck(textBoxItemName.Text, out errorMessage))
            {
                textBoxItemName.Focus();
                // if (textBoxItemName.Text == string.Empty) labelMessage.Text = _cm.GetMessage(10);
                if (textBoxItemName.Text == string.Empty)
                {
                    // labelMessage.Text = Messages.necessaryInput;
                    MessageBox.Show(Messages.necessaryInput);
                }
                else
                    // labelMessage.Text = errorMessage;
                    MessageBox.Show(errorMessage);
                return false;
            }

            // 商品名カナ
            if (textBoxItemName.Text == string.Empty || !_ic.HalfAlphabetCheck(textBoxItemKana.Text, out errorMessage))
            {
                textBoxItemKana.Focus();
                // if (textBoxItemKana.Text == string.Empty) labelMessage.Text = _cm.GetMessage(10);
                if (textBoxItemKana.Text == string.Empty)
                {
                    // labelMessage.Text = Messages.necessaryInput;
                    MessageBox.Show(Messages.necessaryInput);
                }
                else
                    // labelMessage.Text = errorMessage;
                    MessageBox.Show(errorMessage);
                return false;
            }

            // モデルNo.
            if (textBoxModelNo.Text == string.Empty || !_ic.HalfCharCheck(textBoxModelNo.Text, out errorMessage))
            {
                textBoxModelNo.Focus();
                // if (textBoxModelNo.Text == string.Empty) labelMessage.Text = _cm.GetMessage(10);
                if (textBoxModelNo.Text == string.Empty)
                {
                    // labelMessage.Text = Messages.necessaryInput;
                    MessageBox.Show(Messages.necessaryInput);
                }
                else
                    // labelMessage.Text = errorMessage;
                    MessageBox.Show(errorMessage);
                return false;
            }

            // 定価
            if (!_ic.PriceCheck(textBoxListPrice.Text, out errorMessage))
            {
                textBoxListPrice.Focus();
                // labelMessage.Text = errorMessage;
                MessageBox.Show(errorMessage);
                return false;
            }

            // 販売価格
            if (!_ic.PriceCheck(textBoxSellingPrice.Text, out errorMessage))
            {
                textBoxSellingPrice.Focus();
                // labelMessage.Text = errorMessage;
                MessageBox.Show(errorMessage);
                return false;
            }

            // メーカー
            if (comboBoxMakers.Items.Count == 0)
            {
                // labelMessage.Text = Messages.registMaker;
                // labelMessage.Text = _cm.GetMessage(30);
                MessageBox.Show(Messages.registMaker);
                return false;
            }
            if (comboBoxMakers.SelectedIndex == -1)
            {
                // labelMessage.Text = Messages.selectMaker;
                // labelMessage.Text = _cm.GetMessage(31);
                MessageBox.Show(Messages.selectMaker);
                return false;
            }

            // カテゴリー
            if (comboBoxCategorys.Items.Count == 0)
            {
                // labelMessage.Text = Messages.registCategory;
                // labelMessage.Text = _cm.GetMessage(32);
                MessageBox.Show(Messages.registCategory);
                return false;
            }
            if (comboBoxCategorys.SelectedIndex == -1)
            {
                // labelMessage.Text = Messages.selectCategory;
                // labelMessage.Text = _cm.GetMessage(33);
                MessageBox.Show(Messages.selectCategory);
                return false;
            }

            return true;
        }

        // データ作成（登録・更新用）
        // out      Item : Itemデータ
        private M_Item GenerateData()
        {
            return new M_Item
            {
                ItemCD = (textBoxItemCD.Text != string.Empty) ? textBoxItemCD.Text : "0",
                ItemName = textBoxItemName.Text,
                ItemKana = textBoxItemKana.Text,
                ModelNo = textBoxModelNo.Text,
                JanCD = textBoxJanCD.Text,
                ListPrice = int.Parse((textBoxListPrice.Text != string.Empty) ? textBoxListPrice.Text.Replace(",", "") : "0"),
                SellingPrice = int.Parse((textBoxSellingPrice.Text != string.Empty) ? textBoxSellingPrice.Text.Replace(",", "") : "0"),
                MakerID = int.Parse(comboBoxMakers.SelectedValue?.ToString() ?? "-1"),
                CategoryID = long.Parse(comboBoxCategorys.SelectedValue?.ToString() ?? "0"),
                DelFLG = checkBoxDelFLG.Checked,
                Comments = textBoxComments.Text,
                // LogData = "",
            };
        }

        // 重複チェック（コード）
        // out      bool : true = チェックOK
        private bool DuplicationCheck()
        {
            // コード重複チェック
            if (!_cc.CheckCodeDuplication(Constants.numItem, int.Parse(textBoxItemCD.Text), out string errorMessage))
            {
                textBoxItemCD.Focus();
                // labelMessage.Text = errorMessage;
                MessageBox.Show(errorMessage);
                return false;
            }

            return true;
        }

        // 親フォームコンボボックスを更新
        // in       form : 親フォーム
        private void RenewParent(Form form)
        {
            ComboBox comboBoxItems = (ComboBox)form.Controls["comboBoxItems"];
            comboBoxItems.DataSource = _it.GetItems();
            comboBoxItems.DisplayMember = "ItemName";
            comboBoxItems.ValueMember = "ItemCode";

            // 商品名選択
            comboBoxItems.SelectedValue = long.Parse(textBoxItemCD.Text);
        }

        // データグリッドビュー　→　フォームデータ読込
        private void DataCopy()
        {
            M_Item item = _it.GetItem((dataGridView.Rows[_lineNo].Cells["ItemCD"].Value ?? 0).ToString());

            // textBoxItemCode.Text = item.ItemCode.ToString();
            textBoxItemCD.Text = item.ItemCD.ToString();
            textBoxItemName.Text = item.ItemName;
            textBoxItemKana.Text = item.ItemKana;
            textBoxModelNo.Text = item.ModelNo;
            textBoxListPrice.Text = String.Format("{0:#,0}", item.ListPrice);
            textBoxSellingPrice.Text = String.Format("{0:#,0}", item.SellingPrice);
            // comboBoxMakers.SelectedValue = item.MakersId;
            comboBoxMakers.SelectedValue = item.MakerID;
            // comboBoxCategorys.SelectedValue = long.Parse(item.CategoryID);
            textBoxComments.Text =item.Comments;
            checkBoxDelFLG.Checked = item.DelFLG;

            // バージョン情報保管
            _timeStamp = item.Timestamp;
        }

        // フォーム初期設定
        private void FormInitialSetting()
        {
            // コントロールボックス & サイズグリップ無効
            ControlBox = false;
            SizeGripStyle = SizeGripStyle.Hide;
        }

        // データグリッドビュー初期設定
        private void DataGridViewInitialSetting()
        {
            // データグリッドビューセレクトモード設定
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 行追加無効設定
            dataGridView.AllowUserToAddRows = false;
        }

        // データグリッドビューヘッダー初期設定
        private void DataGridViewHeaderSetting()
        {
            // カスタムデータ取得
            List<ColumnsManagement> columnsManagements = _cmc.GetColumnsManagements().Where(m => (m.ClassNumber == Constants.numItem) & (m.DisplayOrPrint == Constants.numDisplay)).ToList();

            // DispItem dispItem = new DispItem();
            M_DispItem dispItem = new M_DispItem();
            var count = 0;
            var columnCount = 0;
            foreach (PropertyInfo prop in dispItem.GetType().GetProperties())
            {
                // DisplayName属性取得
                if (Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) is DisplayNameAttribute dispNameAttr)
                {
                    dataGridView.Columns[count].HeaderText = dispNameAttr.DisplayName;
                    columnCount++;

                    // カスタム情報取得
                    List<ColumnsManagement> cms = columnsManagements.Where(m => (m.ColumnNumber + 1) == columnCount).ToList();
                    if (cms.Count() != 0)
                    {
                        // 非表示適用
                        if (cms.First().Visible == true) dataGridView.Columns[count].Visible = false;

                        // ヘッダー表示
                        if (cms.First().HeaderName != string.Empty) dataGridView.Columns[count].HeaderText = cms.First().HeaderName;
                        else dataGridView.Columns[count].HeaderText = dispNameAttr.DisplayName;

                        // 項目長適用
                        if (cms.First().ColumnWidth != 0) dataGridView.Columns[count].Width = cms.First().ColumnWidth;

                        // 背景色適用
                        if (cms.First().BackColor != -1) dataGridView.Columns[count].DefaultCellStyle.BackColor = _cm.GetColor(StaticCommon.ConvertToString(4, cms.First().BackColor));

                        // 文字色適用
                        if (cms.First().ForeColor != -1) dataGridView.Columns[count].DefaultCellStyle.ForeColor = _cm.GetColor(StaticCommon.ConvertToString(5, cms.First().ForeColor));

                        // 文字レイアウト適用
                        if (cms.First().CharLayout == 0) dataGridView.Columns[count].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        else if (cms.First().CharLayout == 1) dataGridView.Columns[count].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        else if (cms.First().CharLayout == 2) dataGridView.Columns[count].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        Font font;
                        string fontFamily = this.Font.FontFamily.Name;
                        float fontSize = this.Font.Size;

                        // フォントファミリー適用
                        if (cms.First().FontFamily != 0) fontFamily = StaticCommon.ConvertToString(6, cms.First().FontFamily);

                        // フォントサイズ適用
                        if (cms.First().FontSize != 0) fontSize = cms.First().FontSize;

                        // フォント太字適用
                        if (cms.First().Bold == true) font = new Font(fontFamily, fontSize, FontStyle.Bold);
                        else font = new Font(fontFamily, fontSize);

                        // フォント設定
                        dataGridView.Columns[count].DefaultCellStyle.Font = font;
                    }
                }
                count++;
            }
            dataGridView.Columns["ItemCD"].Visible = false;
            dataGridView.Columns["TimeStamp"].Visible = false;
        }

        // 入力コントロール初期設定
        private void InputInitialSetting()
        {
            // IMEセット
            textBoxItemCD.ImeMode = ImeMode.Off;
            textBoxItemName.ImeMode = ImeMode.On;
            textBoxItemKana.ImeMode = ImeMode.Off;
            textBoxModelNo.ImeMode = ImeMode.Off;
            textBoxListPrice.ImeMode = ImeMode.Off;
            textBoxSellingPrice.ImeMode = ImeMode.Off;
            textBoxComments.ImeMode = ImeMode.On;

            // 最大文字長セット
            textBoxItemCD.MaxLength = 20;
            textBoxItemName.MaxLength = 50;
            textBoxItemKana.MaxLength = 50;
            textBoxModelNo.MaxLength = 20;
            textBoxListPrice.MaxLength = 20;
            textBoxSellingPrice.MaxLength = 20;
            textBoxComments.MaxLength = 300;

            // テキスト配置
            textBoxItemCD.TextAlign = HorizontalAlignment.Right;
            textBoxListPrice.TextAlign = HorizontalAlignment.Right;
            textBoxSellingPrice.TextAlign = HorizontalAlignment.Right;

        }

        // コンボボックス初期設定
        private void ComboBoxSetting()
        {
            // メーカー
            comboBoxMakers.DataSource = _mk.GetMakers();
            comboBoxMakers.DisplayMember = "MakerName";
            comboBoxMakers.ValueMember = "MakerID";

            // カテゴリー
            comboBoxCategorys.DataSource = _ct.GetCategorys();
            comboBoxCategorys.DisplayMember = "CategoryName";
            comboBoxCategorys.ValueMember = "CategoryID";
        }

        // 入力クリア
        internal void ClearInput()
        {
            // 表示モード設定
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // データグリッド選択解除
            dataGridView.ClearSelection();

            // テキストボックス＆コンボボックスクリア
            textBoxItemCD.Clear();
            textBoxItemName.Clear();
            textBoxItemKana.Clear();
            textBoxModelNo.Clear();
            comboBoxMakers.SelectedIndex = -1;
            textBoxListPrice.Clear();
            textBoxSellingPrice.Clear();
            comboBoxCategorys.SelectedIndex = -1;
            textBoxComments.Clear();
            checkBoxDelFLG.Checked = false;

            // ボタンリセット
            buttonRegist.Enabled = true;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;

            // 入力フォーカスリセット
            textBoxItemCD.Focus();

            // コードカウンターセット
            // textBoxItemCD.Text = _cc.GetCodeIncrement(Constants.itemCode, out _timeStamp).ToString();
        }

        // 表示データ更新
        private void RefreshDataGridView()
        {
            // スクロール位置取得
            int ScrollPosition = dataGridView.FirstDisplayedScrollingRowIndex;

            // データ取得&表示（データバインド）
            _dispItemPaging = _it.GetDispItems();
            dataGridView.DataSource = _dispItemPaging;

            // 全データ数取得
            _recordCount = _dispItemPaging.Count();

            // スクロール位置セット
            if (0 < ScrollPosition) dataGridView.FirstDisplayedScrollingRowIndex = ScrollPosition;

            // 入力クリア
            ClearInput();

            // ページング初期化
            ClearPaging();
        }

        // 削除処理
        // in       ItemCD : 削除するメーカーCD
        private void Delete(string ItemCD)
        {
            // _it.DeleteItem(int.Parse(ItemCD));
            _it.DeleteItem(ItemCD);

            // データ取得&表示
            dataGridView.DataSource = _it.GetDispItems();
        }

        // ページング処理

        // ページング初期化
        private void ClearPaging()
        {
            // ページサイズ初期化（全行表示）
            textBoxPageSize.Text = "0";
            _pageSizePaging = Convert.ToInt32(textBoxPageSize.Text);
            _recordCount = _dispItemPaging.Count();
            _pageCountPaging = 1;

            // 表示ページ＆ページトップデータ初期化
            _currentPage = 1;
            _recordNo = 0;
        }

        // ページデータ表示処理
        private void LoadPage()
        {
            int startRec;
            int endRec;

            // 表示データ位置（スタートデータ＆エンドデータ）取得
            if (_currentPage == _pageCountPaging) endRec = _recordCount;
            else endRec = _pageSizePaging * _currentPage;
            startRec = _recordNo;

            // データ取得＆表示
            dataGridView.DataSource = _it.GetDispItems(startRec, endRec);

            // 次ページスタートデータ保持
            _recordNo += _it.GetDispItems(startRec, endRec).Count();

            // ページ情報表示
            DisplayPageInfo();
        }

        // ページ情報表示
        private void DisplayPageInfo()
        {
            textBoxDisplayPageNo.Text = _currentPage.ToString() + "/ " + _pageCountPaging.ToString();
        }

        // 印刷ページ数取得
        private void GetPrintPage()
        {
            // 全行印刷
            if (Convert.ToInt32(textBoxPageSize.Text) == 0)
            {
                int count = _it.GetDispItems().Count();
                _pageCountPrinting = count / _pageSizePrinting;
                if (count % _pageSizePrinting > 0) _pageCountPrinting++;
            }

            // 表示ページのみ印刷
            else
            {
                int startRec;
                int endRec;
                if (_currentPage == _pageCountPaging) endRec = _recordCount;
                else endRec = _pageSizePaging * _currentPage;
                startRec = _recordNo - _pageSizePaging;

                int count = _it.GetDispItems(startRec, endRec).Count();
                _pageCountPrinting = count / _pageSizePrinting;
                if (count % _pageSizePrinting > 0) _pageCountPrinting++;
            }

            if (_pageCountPrinting == 0) _pageCountPrinting = 1;
        }
    }
}
