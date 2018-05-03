namespace VOC_LIST
{
    partial class VOC_CategoryMngerSet
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VOC_CategoryMngerSet));
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barBtnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.tr_stdMng = new DevExpress.XtraTreeList.TreeList();
            this.col대분류VOCID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.meProDelay = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.meApplyDelay = new DevExpress.XtraEditors.MemoEdit();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.gcUserList = new DevExpress.XtraGrid.GridControl();
            this.gvUserList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.teEmp = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.btnAuth_Del = new DevExpress.XtraEditors.SimpleButton();
            this.btnAuth_Add = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tr_stdMng)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meProDelay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meApplyDelay.Properties)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teEmp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnSearch,
            this.barBtnSave});
            this.barManager1.MaxItemId = 2;
            // 
            // bar2
            // 
            this.bar2.BarName = "Tools";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSearch),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSave)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Tools";
            // 
            // barBtnSearch
            // 
            this.barBtnSearch.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barBtnSearch.Caption = "조회";
            this.barBtnSearch.Glyph = global::VOC_LIST.Properties.Resources.search2;
            this.barBtnSearch.Id = 0;
            this.barBtnSearch.Name = "barBtnSearch";
            this.barBtnSearch.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSearch_ItemClick);
            // 
            // barBtnSave
            // 
            this.barBtnSave.Caption = "저장";
            this.barBtnSave.Glyph = global::VOC_LIST.Properties.Resources.save21;
            this.barBtnSave.Id = 1;
            this.barBtnSave.Name = "barBtnSave";
            this.barBtnSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSave_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1319, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 768);
            this.barDockControlBottom.Size = new System.Drawing.Size(1319, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 737);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1319, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 737);
            // 
            // bar3
            // 
            this.bar3.BarName = "Tools";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Tools";
            // 
            // tr_stdMng
            // 
            this.tr_stdMng.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tr_stdMng.Appearance.EvenRow.Options.UseBackColor = true;
            this.tr_stdMng.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tr_stdMng.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.tr_stdMng.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tr_stdMng.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tr_stdMng.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tr_stdMng.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.tr_stdMng.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tr_stdMng.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tr_stdMng.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tr_stdMng.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.tr_stdMng.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tr_stdMng.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tr_stdMng.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tr_stdMng.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.tr_stdMng.Appearance.SelectedRow.Options.UseBackColor = true;
            this.tr_stdMng.Appearance.SelectedRow.Options.UseForeColor = true;
            this.tr_stdMng.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.col대분류VOCID,
            this.treeListColumn2,
            this.treeListColumn3});
            this.tr_stdMng.Dock = System.Windows.Forms.DockStyle.Left;
            this.tr_stdMng.Location = new System.Drawing.Point(0, 31);
            this.tr_stdMng.LookAndFeel.SkinName = "Office 2010 Black";
            this.tr_stdMng.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tr_stdMng.Name = "tr_stdMng";
            this.tr_stdMng.OptionsBehavior.PopulateServiceColumns = true;
            this.tr_stdMng.Size = new System.Drawing.Size(539, 737);
            this.tr_stdMng.TabIndex = 4;
            this.tr_stdMng.NodeChanged += new DevExpress.XtraTreeList.NodeChangedEventHandler(this.tr_stdMng_NodeChanged);
            this.tr_stdMng.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tr_stdMng_FocusedNodeChanged);
            this.tr_stdMng.CustomDrawNodeIndicator += new DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventHandler(this.tr_stdMng_CustomDrawNodeIndicator);
            // 
            // col대분류VOCID
            // 
            this.col대분류VOCID.Caption = "대분류VOCID";
            this.col대분류VOCID.FieldName = "대분류VOCID";
            this.col대분류VOCID.Name = "col대분류VOCID";
            this.col대분류VOCID.OptionsColumn.AllowEdit = false;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "대분류PARENTID";
            this.treeListColumn2.FieldName = "대분류PARENTID";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn3.Caption = "카테고리명";
            this.treeListColumn3.FieldName = "대분류명";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowEdit = false;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 0;
            this.treeListColumn3.Width = 232;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(539, 31);
            this.splitterControl1.LookAndFeel.SkinName = "Metropolis";
            this.splitterControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(12, 737);
            this.splitterControl1.TabIndex = 5;
            this.splitterControl1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupControl2);
            this.groupBox1.Controls.Add(this.groupControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(551, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 737);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "지연 안내 문구 관리";
            this.groupBox1.Visible = false;
            // 
            // groupControl2
            // 
            this.groupControl2.CaptionImage = global::VOC_LIST.Properties.Resources._1416917852_resultset_next;
            this.groupControl2.Controls.Add(this.meProDelay);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(311, 18);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(0, 716);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "처리 지연 안내 문구";
            this.groupControl2.Visible = false;
            // 
            // meProDelay
            // 
            this.meProDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meProDelay.Location = new System.Drawing.Point(1, 24);
            this.meProDelay.MenuManager = this.barManager1;
            this.meProDelay.Name = "meProDelay";
            this.meProDelay.Size = new System.Drawing.Size(0, 690);
            this.meProDelay.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = global::VOC_LIST.Properties.Resources._1416917852_resultset_next;
            this.groupControl1.Controls.Add(this.meApplyDelay);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(3, 18);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(308, 716);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "접수 지연 안내 문구";
            // 
            // meApplyDelay
            // 
            this.meApplyDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meApplyDelay.Location = new System.Drawing.Point(2, 24);
            this.meApplyDelay.MenuManager = this.barManager1;
            this.meApplyDelay.Name = "meApplyDelay";
            this.meApplyDelay.Size = new System.Drawing.Size(304, 690);
            this.meApplyDelay.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.gcUserList);
            this.groupBox5.Controls.Add(this.panelControl4);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox5.Location = new System.Drawing.Point(864, 31);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(455, 737);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "본사 담당자 등록";
            // 
            // gcUserList
            // 
            this.gcUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUserList.Location = new System.Drawing.Point(3, 47);
            this.gcUserList.LookAndFeel.SkinName = "Office 2010 Black";
            this.gcUserList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcUserList.MainView = this.gvUserList;
            this.gcUserList.MenuManager = this.barManager1;
            this.gcUserList.Name = "gcUserList";
            this.gcUserList.Size = new System.Drawing.Size(449, 687);
            this.gcUserList.TabIndex = 2;
            this.gcUserList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUserList});
            // 
            // gvUserList
            // 
            this.gvUserList.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.gvUserList.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvUserList.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvUserList.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvUserList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvUserList.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvUserList.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvUserList.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gvUserList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvUserList.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvUserList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvUserList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvUserList.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvUserList.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gvUserList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvUserList.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvUserList.Appearance.Row.Options.UseTextOptions = true;
            this.gvUserList.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvUserList.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvUserList.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvUserList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn3});
            this.gvUserList.GridControl = this.gcUserList;
            this.gvUserList.IndicatorWidth = 50;
            this.gvUserList.Name = "gvUserList";
            this.gvUserList.OptionsBehavior.Editable = false;
            this.gvUserList.OptionsView.ColumnAutoWidth = false;
            this.gvUserList.OptionsView.EnableAppearanceEvenRow = true;
            this.gvUserList.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "사원명";
            this.gridColumn4.FieldName = "한글성명";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 70;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "사번";
            this.gridColumn9.FieldName = "사번";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "부서코드";
            this.gridColumn10.FieldName = "부서코드";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "부서명";
            this.gridColumn3.FieldName = "부서명";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 125;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.teEmp);
            this.panelControl4.Controls.Add(this.labelControl11);
            this.panelControl4.Controls.Add(this.btnAuth_Del);
            this.panelControl4.Controls.Add(this.btnAuth_Add);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(3, 18);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(449, 29);
            this.panelControl4.TabIndex = 1;
            // 
            // teEmp
            // 
            this.teEmp.Location = new System.Drawing.Point(118, 4);
            this.teEmp.MenuManager = this.barManager1;
            this.teEmp.Name = "teEmp";
            this.teEmp.Size = new System.Drawing.Size(134, 20);
            this.teEmp.TabIndex = 9;
            this.teEmp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teEmp_KeyDown);
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl11.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl11.Appearance.Image")));
            this.labelControl11.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl11.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl11.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl11.LineColor = System.Drawing.Color.Silver;
            this.labelControl11.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.labelControl11.LineVisible = true;
            this.labelControl11.Location = new System.Drawing.Point(5, 4);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(107, 20);
            this.labelControl11.TabIndex = 8;
            this.labelControl11.Text = "사번 / 사원명 :";
            // 
            // btnAuth_Del
            // 
            this.btnAuth_Del.Image = ((System.Drawing.Image)(resources.GetObject("btnAuth_Del.Image")));
            this.btnAuth_Del.Location = new System.Drawing.Point(339, 3);
            this.btnAuth_Del.LookAndFeel.SkinName = "Office 2013";
            this.btnAuth_Del.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAuth_Del.Name = "btnAuth_Del";
            this.btnAuth_Del.Size = new System.Drawing.Size(75, 23);
            this.btnAuth_Del.TabIndex = 1;
            this.btnAuth_Del.Text = "삭제";
            this.btnAuth_Del.Click += new System.EventHandler(this.btnAuth_Del_Click);
            // 
            // btnAuth_Add
            // 
            this.btnAuth_Add.Image = ((System.Drawing.Image)(resources.GetObject("btnAuth_Add.Image")));
            this.btnAuth_Add.Location = new System.Drawing.Point(258, 3);
            this.btnAuth_Add.LookAndFeel.SkinName = "Office 2013";
            this.btnAuth_Add.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAuth_Add.Name = "btnAuth_Add";
            this.btnAuth_Add.Size = new System.Drawing.Size(75, 23);
            this.btnAuth_Add.TabIndex = 0;
            this.btnAuth_Add.Text = "추가";
            this.btnAuth_Add.Click += new System.EventHandler(this.btnAuth_Add_Click);
            // 
            // VOC_CategoryMngerSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.tr_stdMng);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "Office 2013";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "VOC_CategoryMngerSet";
            this.Size = new System.Drawing.Size(1319, 768);
            this.Load += new System.EventHandler(this.VOC_CategoryMngerSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tr_stdMng)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meProDelay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meApplyDelay.Properties)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teEmp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem barBtnSearch;
        private DevExpress.XtraBars.BarButtonItem barBtnSave;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraTreeList.TreeList tr_stdMng;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col대분류VOCID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.MemoEdit meProDelay;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MemoEdit meApplyDelay;
        private System.Windows.Forms.GroupBox groupBox5;
        private DevExpress.XtraGrid.GridControl gcUserList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUserList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.TextEdit teEmp;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.SimpleButton btnAuth_Del;
        private DevExpress.XtraEditors.SimpleButton btnAuth_Add;
    }
}
