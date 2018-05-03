namespace VOC_LIST
{
    partial class VOC_FrmCategoryChg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VOC_FrmCategoryChg));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnOpenYN = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.teSearchNm = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnOpenYN = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.trCategoryList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gv_2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col선택2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col부서명2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col부서코드 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col한글성명 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col사번 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teSearchNm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trCategoryList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnOpenYN);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.teSearchNm);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(525, 33);
            this.panelControl1.TabIndex = 0;
            // 
            // btnOpenYN
            // 
            this.btnOpenYN.Image = global::VOC_LIST.Properties.Resources._1433243993_pin;
            this.btnOpenYN.Location = new System.Drawing.Point(447, 4);
            this.btnOpenYN.Name = "btnOpenYN";
            this.btnOpenYN.Size = new System.Drawing.Size(75, 23);
            this.btnOpenYN.TabIndex = 9;
            this.btnOpenYN.Text = "접기";
            this.btnOpenYN.Click += new System.EventHandler(this.btnOpenYN_Click);
            this.btnOpenYN.DoubleClick += new System.EventHandler(this.btnOpenYN_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Appearance.Image = global::VOC_LIST.Properties.Resources._1416917852_resultset_next;
            this.labelControl3.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.LineColor = System.Drawing.Color.Silver;
            this.labelControl3.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(96, 27);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "검색어";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::VOC_LIST.Properties.Resources.search2;
            this.btnSearch.Location = new System.Drawing.Point(358, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "검색";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // teSearchNm
            // 
            this.teSearchNm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teSearchNm.Location = new System.Drawing.Point(105, 6);
            this.teSearchNm.MenuManager = this.barManager1;
            this.teSearchNm.Name = "teSearchNm";
            this.teSearchNm.Size = new System.Drawing.Size(247, 20);
            this.teSearchNm.TabIndex = 1;
            this.teSearchNm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teSearchNm_KeyDown);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSave,
            this.barBtnSearch,
            this.barBtnOpenYN});
            this.barManager1.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSearch),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnOpenYN),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barBtnSearch
            // 
            this.barBtnSearch.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barBtnSearch.Caption = "검색";
            this.barBtnSearch.Glyph = global::VOC_LIST.Properties.Resources.search2;
            this.barBtnSearch.Id = 1;
            this.barBtnSearch.Name = "barBtnSearch";
            this.barBtnSearch.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnSearch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnOpenYN
            // 
            this.barBtnOpenYN.Caption = "펼치기";
            this.barBtnOpenYN.Glyph = global::VOC_LIST.Properties.Resources._1433243993_pin1;
            this.barBtnOpenYN.Id = 2;
            this.barBtnOpenYN.Name = "barBtnOpenYN";
            this.barBtnOpenYN.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnOpenYN.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barBtnOpenYN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnOpenYN_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnSave.Caption = "저장";
            this.btnSave.Glyph = global::VOC_LIST.Properties.Resources.save2;
            this.btnSave.Id = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(525, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 583);
            this.barDockControlBottom.Size = new System.Drawing.Size(525, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 552);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(525, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 552);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.trCategoryList);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 64);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(525, 519);
            this.panelControl2.TabIndex = 1;
            // 
            // trCategoryList
            // 
            this.trCategoryList.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.trCategoryList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.trCategoryList.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.trCategoryList.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.trCategoryList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.trCategoryList.Appearance.FocusedRow.Options.UseForeColor = true;
            this.trCategoryList.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.trCategoryList.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.trCategoryList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.trCategoryList.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.trCategoryList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn7,
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6});
            this.trCategoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trCategoryList.Location = new System.Drawing.Point(0, 0);
            this.trCategoryList.LookAndFeel.SkinName = "Office 2010 Black";
            this.trCategoryList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.trCategoryList.Name = "trCategoryList";
            this.trCategoryList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.trCategoryList.SelectImageList = this.imageList1;
            this.trCategoryList.Size = new System.Drawing.Size(525, 519);
            this.trCategoryList.TabIndex = 0;
            this.trCategoryList.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.trCategoryList_CellValueChanged);
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn7.Caption = "선택";
            this.treeListColumn7.ColumnEdit = this.repositoryItemCheckEdit1;
            this.treeListColumn7.FieldName = "선택";
            this.treeListColumn7.MinWidth = 33;
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.OptionsColumn.AllowSort = false;
            this.treeListColumn7.Visible = true;
            this.treeListColumn7.VisibleIndex = 0;
            this.treeListColumn7.Width = 33;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repositoryItemCheckEdit1.ValueChecked = "Y";
            this.repositoryItemCheckEdit1.ValueUnchecked = "N";
            this.repositoryItemCheckEdit1.EditValueChanged += new System.EventHandler(this.repositoryItemCheckEdit1_EditValueChanged);
            this.repositoryItemCheckEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repositoryItemCheckEdit1_EditValueChanging);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "카테고리명";
            this.treeListColumn1.FieldName = "카테고리명";
            this.treeListColumn1.MinWidth = 33;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 1;
            this.treeListColumn1.Width = 370;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn2.Caption = "카테고리코드";
            this.treeListColumn2.FieldName = "카테고리코드";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.Width = 95;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "부모카테고리코드";
            this.treeListColumn3.FieldName = "부모카테고리코드";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowEdit = false;
            this.treeListColumn3.Width = 130;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn4.Caption = "멀티여부";
            this.treeListColumn4.FieldName = "멀티여부";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowEdit = false;
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 2;
            this.treeListColumn4.Width = 93;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "사용여부";
            this.treeListColumn5.FieldName = "사용여부";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.OptionsColumn.AllowEdit = false;
            this.treeListColumn5.Width = 77;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "IMAGEINDEX";
            this.treeListColumn6.FieldName = "IMAGEINDEX";
            this.treeListColumn6.Name = "treeListColumn6";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1432186247_folder.png");
            this.imageList1.Images.SetKeyName(1, "1433140554_book.png");
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            this.repositoryItemCheckEdit3.ValueChecked = "Y";
            this.repositoryItemCheckEdit3.ValueUnchecked = "N";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("한글성명", "이름"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("사번", "사번", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "선택";
            // 
            // gv_2
            // 
            this.gv_2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col선택2,
            this.col부서명2,
            this.col부서코드,
            this.col한글성명,
            this.col사번});
            this.gv_2.Name = "gv_2";
            this.gv_2.OptionsView.AllowCellMerge = true;
            this.gv_2.OptionsView.ColumnAutoWidth = false;
            this.gv_2.OptionsView.ShowGroupPanel = false;
            // 
            // col선택2
            // 
            this.col선택2.AppearanceHeader.Options.UseTextOptions = true;
            this.col선택2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col선택2.Caption = "선택";
            this.col선택2.ColumnEdit = this.repositoryItemCheckEdit3;
            this.col선택2.FieldName = "선택";
            this.col선택2.Name = "col선택2";
            this.col선택2.Visible = true;
            this.col선택2.VisibleIndex = 0;
            this.col선택2.Width = 50;
            // 
            // col부서명2
            // 
            this.col부서명2.Caption = "부서명";
            this.col부서명2.FieldName = "부서명";
            this.col부서명2.Name = "col부서명2";
            this.col부서명2.OptionsColumn.AllowEdit = false;
            this.col부서명2.Visible = true;
            this.col부서명2.VisibleIndex = 1;
            this.col부서명2.Width = 120;
            // 
            // col부서코드
            // 
            this.col부서코드.Caption = "부서코드";
            this.col부서코드.FieldName = "부서코드";
            this.col부서코드.Name = "col부서코드";
            // 
            // col한글성명
            // 
            this.col한글성명.Caption = "사원명";
            this.col한글성명.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.col한글성명.FieldName = "한글성명";
            this.col한글성명.Name = "col한글성명";
            this.col한글성명.Visible = true;
            this.col한글성명.VisibleIndex = 2;
            // 
            // col사번
            // 
            this.col사번.Caption = "사번";
            this.col사번.FieldName = "사번";
            this.col사번.Name = "col사번";
            // 
            // VOC_FrmCategoryChg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 583);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "VOC_FrmCategoryChg";
            this.Text = "카테고리 변경";
            this.Load += new System.EventHandler(this.VOC_FrmCategoryChg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teSearchNm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trCategoryList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraTreeList.TreeList trCategoryList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit teSearchNm;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_2;
        private DevExpress.XtraGrid.Columns.GridColumn col선택2;
        private DevExpress.XtraGrid.Columns.GridColumn col부서명2;
        private DevExpress.XtraGrid.Columns.GridColumn col부서코드;
        private DevExpress.XtraGrid.Columns.GridColumn col한글성명;
        private DevExpress.XtraGrid.Columns.GridColumn col사번;
        private DevExpress.XtraEditors.SimpleButton btnOpenYN;
        private DevExpress.XtraBars.BarButtonItem barBtnSearch;
        private DevExpress.XtraBars.BarButtonItem barBtnOpenYN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}