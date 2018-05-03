namespace VOC
{
    partial class VOC_TemplateManage
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
            this.gc_Large = new DevExpress.XtraGrid.GridControl();
            this.gv_Large = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col대분류 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col대분류VOCID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.cm_Category_Refresh = new Cesco.FW.Global.UCControls.Construct.CESMenu();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.cm_S_New = new Cesco.FW.Global.UCControls.Construct.CESMenu();
            this.cm_S_Save = new Cesco.FW.Global.UCControls.Construct.CESMenu();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.btnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl7 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.text_L_Name = new DevExpress.XtraEditors.TextEdit();
            this.text_L_vocid = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.templateText = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Large)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Large)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).BeginInit();
            this.panelControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.text_L_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.text_L_vocid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.templateText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gc_Large
            // 
            this.gc_Large.Dock = System.Windows.Forms.DockStyle.Left;
            this.gc_Large.EmbeddedNavigator.TextStringFormat = "Record {0} of {1}";
            this.gc_Large.Location = new System.Drawing.Point(0, 31);
            this.gc_Large.LookAndFeel.SkinName = "Office 2010 Black";
            this.gc_Large.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gc_Large.MainView = this.gv_Large;
            this.gc_Large.Name = "gc_Large";
            this.gc_Large.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gc_Large.Size = new System.Drawing.Size(408, 752);
            this.gc_Large.TabIndex = 0;
            this.gc_Large.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Large});
            // 
            // gv_Large
            // 
            this.gv_Large.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.gv_Large.Appearance.EvenRow.Options.UseBackColor = true;
            this.gv_Large.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gv_Large.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gv_Large.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gv_Large.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gv_Large.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gv_Large.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gv_Large.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gv_Large.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gv_Large.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gv_Large.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gv_Large.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gv_Large.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gv_Large.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gv_Large.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gv_Large.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col대분류,
            this.col대분류VOCID});
            this.gv_Large.GridControl = this.gc_Large;
            this.gv_Large.IndicatorWidth = 40;
            this.gv_Large.Name = "gv_Large";
            this.gv_Large.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_Large.OptionsView.ColumnAutoWidth = false;
            this.gv_Large.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_Large.OptionsView.ShowGroupPanel = false;
            this.gv_Large.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gv_Large_CustomDrawRowIndicator);
            this.gv_Large.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv_Large_FocusedRowChanged);
            // 
            // col대분류
            // 
            this.col대분류.AppearanceHeader.Options.UseTextOptions = true;
            this.col대분류.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col대분류.Caption = "대분류";
            this.col대분류.FieldName = "대분류명";
            this.col대분류.Name = "col대분류";
            this.col대분류.OptionsColumn.AllowEdit = false;
            this.col대분류.Visible = true;
            this.col대분류.VisibleIndex = 0;
            this.col대분류.Width = 296;
            // 
            // col대분류VOCID
            // 
            this.col대분류VOCID.Caption = "대분류VOCID";
            this.col대분류VOCID.FieldName = "대분류VOCID";
            this.col대분류VOCID.Name = "col대분류VOCID";
            this.col대분류VOCID.OptionsColumn.AllowEdit = false;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repositoryItemCheckEdit1.ValueChecked = "Y";
            this.repositoryItemCheckEdit1.ValueUnchecked = "N";
            // 
            // cm_Category_Refresh
            // 
            this.cm_Category_Refresh.LinkName = "Refresh";
            this.cm_Category_Refresh.MatchBarItem = null;
            this.cm_Category_Refresh.MenuCaption = "새로고침";
            this.cm_Category_Refresh.MenuImageClass = Cesco.FW.Global.UCControls.Construct.CESMenu.MenuImageType.Search;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Location = new System.Drawing.Point(408, 31);
            this.splitterControl2.LookAndFeel.SkinName = "Office 2013";
            this.splitterControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(12, 752);
            this.splitterControl2.TabIndex = 8;
            this.splitterControl2.TabStop = false;
            // 
            // cm_S_New
            // 
            this.cm_S_New.LinkName = "New";
            this.cm_S_New.MatchBarItem = null;
            this.cm_S_New.MenuCaption = "신규";
            this.cm_S_New.MenuImageClass = Cesco.FW.Global.UCControls.Construct.CESMenu.MenuImageType.New;
            // 
            // cm_S_Save
            // 
            this.cm_S_Save.LinkName = "Save";
            this.cm_S_Save.MatchBarItem = null;
            this.cm_S_Save.MenuCaption = "저장";
            this.cm_S_Save.MenuImageClass = Cesco.FW.Global.UCControls.Construct.CESMenu.MenuImageType.Save;
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
            // bar2
            // 
            this.bar2.BarName = "Tools";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Tools";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSearch,
            this.barButtonItem1});
            this.barManager1.MaxItemId = 2;
            // 
            // bar3
            // 
            this.bar3.BarName = "Tools";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSearch),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Tools";
            // 
            // btnSearch
            // 
            this.btnSearch.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnSearch.Caption = "새로고침";
            this.btnSearch.Glyph = global::VOC_LIST.Properties.Resources.refresh4;
            this.btnSearch.Id = 0;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSearch_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "저장";
            this.barButtonItem1.Glyph = global::VOC_LIST.Properties.Resources.save2;
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1244, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 783);
            this.barDockControlBottom.Size = new System.Drawing.Size(1244, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 752);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1244, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 752);
            // 
            // panelControl7
            // 
            this.panelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl7.Controls.Add(this.labelControl3);
            this.panelControl7.Controls.Add(this.text_L_Name);
            this.panelControl7.Controls.Add(this.text_L_vocid);
            this.panelControl7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl7.Location = new System.Drawing.Point(0, 0);
            this.panelControl7.LookAndFeel.SkinName = "Office 2013";
            this.panelControl7.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl7.Name = "panelControl7";
            this.panelControl7.Size = new System.Drawing.Size(824, 33);
            this.panelControl7.TabIndex = 3;
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
            this.labelControl3.Location = new System.Drawing.Point(12, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(96, 27);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "대분류";
            // 
            // text_L_Name
            // 
            this.text_L_Name.Location = new System.Drawing.Point(220, 6);
            this.text_L_Name.Name = "text_L_Name";
            this.text_L_Name.Properties.ReadOnly = true;
            this.text_L_Name.Size = new System.Drawing.Size(248, 20);
            this.text_L_Name.TabIndex = 2;
            // 
            // text_L_vocid
            // 
            this.text_L_vocid.Location = new System.Drawing.Point(114, 6);
            this.text_L_vocid.Name = "text_L_vocid";
            this.text_L_vocid.Properties.ReadOnly = true;
            this.text_L_vocid.Size = new System.Drawing.Size(100, 20);
            this.text_L_vocid.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.templateText);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.panelControl7);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(420, 31);
            this.panelControl2.LookAndFeel.SkinName = "Office 2013";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(824, 752);
            this.panelControl2.TabIndex = 1;
            // 
            // templateText
            // 
            this.templateText.Location = new System.Drawing.Point(114, 39);
            this.templateText.MenuManager = this.barManager1;
            this.templateText.Name = "templateText";
            this.templateText.Size = new System.Drawing.Size(354, 444);
            this.templateText.TabIndex = 10;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Image = global::VOC_LIST.Properties.Resources._1416917852_resultset_next;
            this.labelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.LineColor = System.Drawing.Color.Silver;
            this.labelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 27);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "템플릿";
            // 
            // VOC_TemplateManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.gc_Large);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "Office 2013";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "VOC_TemplateManage";
            this.Size = new System.Drawing.Size(1244, 783);
            this.Load += new System.EventHandler(this.CategoryManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gc_Large)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Large)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).EndInit();
            this.panelControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.text_L_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.text_L_vocid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.templateText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gc_Large;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Large;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private Cesco.FW.Global.UCControls.Construct.CESMenu cm_Category_Refresh;
        private Cesco.FW.Global.UCControls.Construct.CESMenu cm_S_New;
        private Cesco.FW.Global.UCControls.Construct.CESMenu cm_S_Save;
        private DevExpress.XtraGrid.Columns.GridColumn col대분류;
        private DevExpress.XtraGrid.Columns.GridColumn col대분류VOCID;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem btnSearch;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl7;
        private DevExpress.XtraEditors.TextEdit text_L_Name;
        private DevExpress.XtraEditors.TextEdit text_L_vocid;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit templateText;


    }
}
