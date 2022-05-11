using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SalesManagement.Model;
using SalesManagement.Model.ContentsManagement;
using SalesManagement.Model.ContentsManagement.Common;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.Entity.Disp;

namespace SalesManagement
{
    // 部署マスター　フォームクラス
    public partial class FormDivision : Form
    {
        // ***** モジュール実装（よく使う他クラスで定義したメソッドが利用できるようあらかじめ実装します。）

        // 共通データベース処理モジュール
        private CommonFunction _cm = new CommonFunction();

        // データベース処理モジュール（項目処理）
        private ColumnsManagementCommon _cmc = new ColumnsManagementCommon();

        // データベース処理モジュール（コードカウンター）
        private CodeCounterCommon _cc = new CodeCounterCommon();

        // 入力チェックモジュール
        private InputCheck _ic = new InputCheck();

        // メッセージ処理モジュール
        private Messages _ms = new Messages();

        // データベース処理モジュール（M_Division）
        private M_DivisionContents _dv = new M_DivisionContents();

        // ***** プロパティ定義

        // トップフォーム
        public TopForm _topForm;

        // 選択行番号
        private int _lineNo;

        // バージョン管理
        // データベースからデータを読み込んだ時の時間を管理します。
        // 後にデータベースに書き込む時、異なるバージョンのデータ（読み込んだデータが既に他者によって書き換えられている）
        // だった場合、書き込みは失敗します。（楽観的同時実行制御）
        private byte[] _timeStamp;

        // ページング関係プロパティ
        private int _pageCountPaging;                                       // 全表示ページ数
        private int _recordCount;                                           // 全表示データ数
        private int _pageSizePaging;                                        // １ページ表示データ行数
        private int _currentPage;                                           // 現在のページ
        private int _recordNo;                                              // ページ先頭位置のデータ（スタートデータ）
        private IEnumerable<M_DispDivision> _dispDivisionPaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<M_DispDivision> _dispDivisionPrinting;                 // 印刷用データ

        // コンストラクタ
        public FormDivision()
        {
            InitializeComponent();
        }

        // TopForm呼出用コンストラクタ
        public FormDivision(TopForm topForm)
        {
            _topForm = topForm;
            InitializeComponent();
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

            // ログオンユーザー情報 セット
            String name = string.Empty;
            if (_topForm != null) name = _topForm._staff.M_Staff[0].StaffName;
            _cmc._logonUser = name;                                                 // 項目処理モジュールに受け渡し
            _dv._logonUser = name;                                                  // データベース処理モジュールに受け渡し

            // ユーザー名画面表示
            textBoxLoginName.Text = name;

            // データ取得 & 表示（データバインド）
            _dispDivisionPaging = _dv.GetM_DispDivisions();
            dataGridView.DataSource = _dispDivisionPaging;

            // 全データ数取得
            _recordCount = _dispDivisionPaging.Count();
        }

        // ロード最終処理（データグリッドビューにデータバインド後に実行）
        // 8.1.0.2 初期化（最終処理）
        private void Form_Shown(object sender, EventArgs e)
        {
            // ヘッダー設定
            DataGridViewHeaderSetting();

            // 入力クリア
            ClearInput();

            // ページング初期化
            ClearPaging();
        }

        // 登録ボタン
        // 8.1.1 部署情報登録
        private void ButtonRegist_Click(object sender, EventArgs e)
        {
            // 8.1.1.1 妥当な部署データ取得
            if (!GetValidDataAtRegistration())
                return;

            // 8.1.1.2 部署情報作成
            var regDivision = GenerateDataAtRegistration();

            // 8.1.1.3 部署情報登録
            if (!DivisionRegistration(regDivision))
                return;

        }

        //
        //
        // 8.1.1.1 妥当な部署データ取得（新規登録）
        //
        //
        private bool GetValidDataAtRegistration()
        {
            // 部署データの形式チェック
            string errorMessage = string.Empty;

            // 部署IDの適否
            if (!String.IsNullOrEmpty(textBoxDivisionID.Text))
            {
                MessageBox.Show("部署IDは入力できません");
                textBoxDivisionID.Focus();
                return false;
            }

            // 部署名の適否
            if (String.IsNullOrEmpty(textBoxDivisionName.Text))
            {
                MessageBox.Show(Messages.necessaryInput);
                textBoxDivisionName.Focus();
                return false;
            }

            if (!_ic.FullWidthCharCheck(textBoxDivisionName.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                textBoxDivisionName.Focus();
                return false;
            }

            if (textBoxDivisionName.TextLength > 50)
            {
                MessageBox.Show("部署名は50文字以下です");
                textBoxDivisionName.Focus();
                return false;
            }

            // 削除フラグの適否
            if (checkBoxDelFLG.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show(Messages.necessaryInput);
                checkBoxDelFLG.Focus();
                return false;
            }

            // 備考の適否
            if (textBoxComments.TextLength > 80)
            {
                MessageBox.Show("備考は80文字以下です");
                textBoxComments.Focus();
                return false;
            }

            return true;
        }

        //
        //
        // 8.1.1.2 部署情報作成
        //
        //
        // out      Division : Divisionデータ
        private M_Division GenerateDataAtRegistration()
        {
            return new M_Division
            {
                DivisionName = textBoxDivisionName.Text,
                DelFLG = checkBoxDelFLG.Checked,
                Comments = textBoxComments.Text,
            };
        }

        //
        //
        // 8.1.1.3 部署情報登録
        //
        //
        private bool DivisionRegistration(M_Division regDivision)
        {
            // 登録可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }

            // 商品メーカ情報の登録
            var errorMessage = _dv.PostM_Division(regDivision);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            // 画面更新
            RefreshDataGridView();
            textBoxDivisionName.Focus();

            return true;

        }

        // 更新ボタン
        // 8.1.2 部署情報更新
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            // 8.1.2.1 妥当な部署データ取得
            if (!GetValidDataAtUpdate())
                return;

            // 8.1.2.2 部署情報作成
            var regDivision = GenerateDataAtUpdate();

            // 8.1.2.3 部署情報更新
            if (!DivisionUpdate(regDivision))
                return;

        }

        //
        //
        // 8.1.2.1 妥当な部署データ取得（更新）
        //
        //
        private bool GetValidDataAtUpdate()
        {
            // 部署データの形式チェック
            string errorMessage = string.Empty;

            // 部署IDの適否
            if (String.IsNullOrEmpty(textBoxDivisionID.Text))
            {
                MessageBox.Show(Messages.necessaryInput);
                textBoxDivisionID.Focus();
                return false;
            }

            if (!_ic.NumericCheck(textBoxDivisionID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                textBoxDivisionID.Focus();
                return false;
            };

            if (!_ic.NumericRangeCheck(textBoxDivisionID.Text, 0, Constants.codeMax, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                textBoxDivisionID.Focus();
                return false;
            };

            // 部署名の適否
            if (String.IsNullOrEmpty(textBoxDivisionName.Text))
            {
                MessageBox.Show(Messages.necessaryInput);
                textBoxDivisionName.Focus();
                return false;
            }

            if (!_ic.FullWidthCharCheck(textBoxDivisionName.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                textBoxDivisionName.Focus();
                return false;
            }

            if (textBoxDivisionName.TextLength > 50)
            {
                MessageBox.Show("部署名は50文字以下です");
                textBoxDivisionName.Focus();
                return false;
            }

            // 削除フラグの適否
            if (checkBoxDelFLG.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show(Messages.necessaryInput);
                checkBoxDelFLG.Focus();
                return false;
            }

            // 備考の適否
            if (textBoxComments.TextLength > 80)
            {
                MessageBox.Show("備考は80文字以下です");
                textBoxComments.Focus();
                return false;
            }

            //  部署データの存在チェック
            if (_cc.CheckCodeDuplication(Constants.numDivision, int.Parse(textBoxDivisionID.Text), out errorMessage))
            {
                MessageBox.Show("部署IDが存在しません");
                textBoxDivisionID.Focus();
                return false;
            }

            return true;
        }

        //
        //
        // 8.1.2.2 部署情報作成
        //
        //
        // out      Division : Divisionデータ
        private M_Division GenerateDataAtUpdate()
        {
            return new M_Division
            {
                DivisionID = int.Parse(textBoxDivisionID.Text.Trim()),
                DivisionName = textBoxDivisionName.Text,
                DelFLG = checkBoxDelFLG.Checked,
                Comments = textBoxComments.Text,
                Timestamp = _timeStamp,
            };
        }


        //
        //
        // 8.1.2.3 部署情報更新
        //
        //
        private bool DivisionUpdate(M_Division regDivision)
        {
            // 更新可否
            if (DialogResult.OK != MessageBox.Show(this, "更新してよろしいですか", "更新可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }

            var errorMessage = _dv.PutM_Division(regDivision);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            // 画面更新
            RefreshDataGridView();
            textBoxDivisionName.Focus();

            return true;

        }

        // 削除ボタン
        // 8.1.5 部署情報削除
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            // データ行番号を取得
            int DivisionID = int.Parse(textBoxDivisionID.Text);
            using (var dcm = new DeleteConfirmForm())
            {
                // 確認後、削除実行
                if (dcm.ShowDialog(this) == DialogResult.OK) Delete(DivisionID);
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
        }

        // リセットボタン
        // 8.1.6 部署情報入力リセット
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

            // ID改変無効処置
            textBoxDivisionID.Enabled = false;
        }

        // ***** 入力チェック（各入力項目から入力フォーカスが離れる時にチェック）
        // 部署ID
        private void TextBoxDivisionID_Leave(object sender, EventArgs e)
        {
            // 空白の時はチェックしない
            if (textBoxDivisionID.Text == string.Empty) return;

            // 数値チェック
            if (!_ic.NumericRangeCheck(textBoxDivisionID.Text, 0, Constants.codeMax, out string errorMessage))
            {
                textBoxDivisionID.Focus();
                // labelMessage.Text = errorMessage;
                MessageBox.Show(errorMessage);
                return;
            };
        }

        // 部署名
        private void TextBoxDivisionName_Leave(object sender, EventArgs e)
        {
            // 空白の時はチェックしない
            if (textBoxDivisionName.Text == string.Empty) return;

            // 全角チェック
            if (!_ic.FullWidthCharCheck(textBoxDivisionName.Text, out string errorMessage)) textBoxDivisionName.Focus();

            // エラーメッセージセット
            // labelMessage.Text = errorMessage;
            if (errorMessage != string.Empty) MessageBox.Show(errorMessage);
        }

        // 備考
        private void TextBoxComments_Leave(object sender, EventArgs e)
        {

        }

        // ページサイズ変更処理
        private void TextBoxPageSize_Leave(object sender, EventArgs e)
        {

            // 数値チェック
            if (!_ic.NumericCheck(textBoxPageSize.Text, out string errorMessage))
            {
                textBoxPageSize.Focus();
                // labelMessage.Text = errorMessage;
                MessageBox.Show(errorMessage);
            }
        }

        // ***** ページング処理
        // 以下参照
        // https://support.microsoft.com/ja-jp/help/307710/how-to-perform-paging-with-the-datagrid-windows-control-by-using-visua
        // １ページ行数変更
        private void ButtonPageSizeChange_Click(object sender, EventArgs e)
        {
            
            // ページサイズ入力チェック
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
            _recordCount = _dispDivisionPaging.Count();

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
                // MessageBox.Show(_cm.GetMessage(2));
                return;
            }
            _currentPage = _pageCountPaging;
            _recordNo = _pageSizePaging * (_currentPage - 1);
            LoadPage();
        }

        // 印刷
        // 8.1.4.1 部署情報印刷設定
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
        // 8.1.4.2 部署情報印刷
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // ページ印刷データ取得

            // 全行印刷
            if (Convert.ToInt32(textBoxPageSize.Text) == 0)
            {
                int st = _pageSizePrinting * (_pageNumber - 1);
                if (_pageNumber == _pageCountPrinting) _dispDivisionPrinting = _dv.GetDispDivisions(st, _recordCount).ToList();
                else _dispDivisionPrinting = _dv.GetDispDivisions(st, st + _pageSizePrinting).ToList();
            }

            // 表示ページのみ印刷
            else
            {
                int startRec;
                int endRec;
                if (_currentPage == _pageCountPaging) endRec = _recordCount;
                else endRec = _pageSizePaging * _currentPage;
                startRec = _pageSizePaging * (_currentPage - 1);

                if (_pageCountPrinting == 1)
                {
                    _dispDivisionPrinting = _dv.GetDispDivisions(startRec, endRec).ToList();
                }
                else
                {
                    int st = startRec + (_pageSizePrinting * (_pageNumber - 1));
                    if (endRec <= st + _pageSizePrinting) _dispDivisionPrinting = _dv.GetDispDivisions(st, endRec).ToList();
                    else _dispDivisionPrinting = _dv.GetDispDivisions(st, st + _pageSizePrinting).ToList();
                }
            }

            // データ構造取得
            M_DispDivision dispDivision = new M_DispDivision();

            // 項目数取得（xxxId, TimeStamp を項目に含めない）
            int columnsCount = dispDivision.GetType().GetProperties().Count() - 2;

            // dataGridView 描画

            // カスタムデータ取得
            List<ColumnsManagement> columnsManagements = _cmc.GetColumnsManagements().Where(m => (m.ClassNumber == Constants.numDivision) & (m.DisplayOrPrint == Constants.numPrint)).ToList();

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
            foreach (PropertyInfo prop in dispDivision.GetType().GetProperties())
            {
                if (columnCount >= columnsCount) break;

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
            foreach (M_DispDivision ds in _dispDivisionPrinting)
            {
                columnCount = 0;
                lineW = 0;

                // 項目区切りライントップY座標保存
                int columnTop = columnH;

                columnH += Constants.defaultColumnHeight;

                // １カラム最大文字行数取得
                int subRowCount = 1;

                foreach (PropertyInfo prop in dispDivision.GetType().GetProperties())
                {
                    if (columnCount >= columnsCount) break;

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
                foreach (PropertyInfo prop in dispDivision.GetType().GetProperties())
                {
                    if (columnCount >= columnsCount) break;

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

        // ログアウト
        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            _topForm.Logon();
            Dispose();
        }

        // *** 内部処理 *****

       // データグリッドビュー　→　フォームデータ読込
        private void DataCopy()
        {
            textBoxDivisionID.Text = (dataGridView.Rows[_lineNo].Cells["DivisionId"].Value ?? 0).ToString();
            M_Division Division = _dv.GetM_Division(int.Parse(textBoxDivisionID.Text));

            textBoxDivisionID.Text = Division.DivisionID.ToString();
            textBoxDivisionName.Text = Division.DivisionName;
            checkBoxDelFLG.Checked = Division.DelFLG;
            textBoxComments.Text = Division.Comments;

            // バージョン情報保管
            _timeStamp = Division.Timestamp;
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
            List<ColumnsManagement> columnsManagements = _cmc.GetColumnsManagements().Where(m => (m.ClassNumber == Constants.numDivision) & (m.DisplayOrPrint == Constants.numDisplay)).ToList();

            M_DispDivision dispDivision = new M_DispDivision();
            var count = 0;
            var columnCount = 0;
            foreach (PropertyInfo prop in dispDivision.GetType().GetProperties())
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
            // dataGridView.Columns["DivisionID"].Visible = false;
            dataGridView.Columns["TimeStamp"].Visible = false;
        }

        // 入力コントロール初期設定
        private void InputInitialSetting()
        {
            // IMEセット
            textBoxDivisionID.ImeMode = ImeMode.Off;
            textBoxDivisionName.ImeMode = ImeMode.On;
            textBoxComments.ImeMode = ImeMode.On;

            // 最大文字長セット
            textBoxDivisionID.MaxLength = 20;
            textBoxDivisionName.MaxLength = 50;
            textBoxComments.MaxLength = 300;

            // ページコントロール
            textBoxPageSize.TextAlign = HorizontalAlignment.Right;
            textBoxDisplayPageNo.TextAlign = HorizontalAlignment.Right;
            textBoxDisplayPageNo.Enabled = false;
        }

        // 入力クリア
        internal void ClearInput()
        {
            // 表示モード設定
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // データグリッド選択解除
            dataGridView.ClearSelection();

            // テキストボックス＆コンボボックスクリア
            textBoxDivisionID.Text = null;
            textBoxDivisionID.Clear();
            textBoxDivisionName.Clear();
            textBoxComments.Clear();
            checkBoxDelFLG.Checked = false;

            // ボタンリセット
            buttonRegist.Enabled = true;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;

            // ID改変無効処置リセット
            textBoxDivisionID.Enabled = true;

            // 入力フォーカスリセット
            textBoxDivisionID.Focus();

            // コードカウンターセット
            // textBoxDivisionID.Text = _cc.GetCodeIncrement(Constants.divisionCode, out _timeStamp).ToString();
        }

        // 表示データ更新
        private void RefreshDataGridView()
        {
            // スクロール位置取得
            int ScrollPosition = dataGridView.FirstDisplayedScrollingRowIndex;

            // データ取得&表示（データバインド）
            _dispDivisionPaging = _dv.GetM_DispDivisions();
            dataGridView.DataSource = _dispDivisionPaging;

            // 全データ数取得
            _recordCount = _dispDivisionPaging.Count();

            // スクロール位置セット
            if (0 < ScrollPosition) dataGridView.FirstDisplayedScrollingRowIndex = ScrollPosition;

            // 入力クリア
            ClearInput();

            // ページング初期化
            ClearPaging();
        }

        // 削除処理
        // in       DivisionID : 削除する部署ID
        private void Delete(int DivisionID)
        {
            var errorMessage = _dv.DeleteM_Division(DivisionID);
            if (errorMessage != string.Empty) MessageBox.Show(errorMessage);

            // データ取得&表示
            dataGridView.DataSource = _dv.GetM_DispDivisions();
        }

        // ページング処理

        // ページング初期化
        private void ClearPaging()
        {
            // ページサイズ初期化（全行表示）
            textBoxPageSize.Text = "0";
            _pageSizePaging = Convert.ToInt32(textBoxPageSize.Text);
            _recordCount = _dispDivisionPaging.Count();
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
            dataGridView.DataSource = _dv.GetDispDivisions(startRec, endRec);

            // 次ページスタートデータ保持
            _recordNo += _dv.GetDispDivisions(startRec, endRec).Count();

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
                int count = _dv.GetM_DispDivisions().Count();
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

                int count = _dv.GetDispDivisions(startRec, endRec).Count();
                _pageCountPrinting = count / _pageSizePrinting;
                if (count % _pageSizePrinting > 0) _pageCountPrinting++;
            }

            if (_pageCountPrinting == 0) _pageCountPrinting = 1;
        }
    }
}
