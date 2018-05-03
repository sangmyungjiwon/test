namespace VOC_LIST
{
    partial class VOC_TotalStateMng_Category_Detail
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
            this.gcSmList = new DevExpress.XtraGrid.GridControl();
            this.gvSmList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMidList = new DevExpress.XtraGrid.GridControl();
            this.gvMidList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcbigList = new DevExpress.XtraGrid.GridControl();
            this.gvbigList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.rgVOC_P = new System.Windows.Forms.RadioButton();
            this.lue_ProblemLv = new DevExpress.XtraEditors.LookUpEdit();
            this.rgVOC_A = new System.Windows.Forms.RadioButton();
            this.lueDeptDetail = new DevExpress.XtraEditors.LookUpEdit();
            this.lueDept = new DevExpress.XtraEditors.LookUpEdit();
            this.lueGubun_Detail = new DevExpress.XtraEditors.LookUpEdit();
            this.rgVOC1 = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.deDate_To = new DevExpress.XtraEditors.DateEdit();
            this.deDate_From = new DevExpress.XtraEditors.DateEdit();
            this.lueDate_Gubun = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcSmList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSmList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMidList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMidList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcbigList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvbigList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lue_ProblemLv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDeptDetail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGubun_Detail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgVOC1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate_To.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate_To.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate_From.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate_From.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDate_Gubun.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcSmList
            // 
            this.gcSmList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSmList.EmbeddedNavigator.TextStringFormat = "Record {0} of {1}";
            this.gcSmList.Location = new System.Drawing.Point(0, 533);
            this.gcSmList.LookAndFeel.SkinName = "Office 2010 Black";
            this.gcSmList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcSmList.MainView = this.gvSmList;
            this.gcSmList.Name = "gcSmList";
            this.gcSmList.Size = new System.Drawing.Size(1024, 235);
            this.gcSmList.TabIndex = 10;
            this.gcSmList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSmList});
            // 
            // gvSmList
            // 
            this.gvSmList.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvSmList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvSmList.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvSmList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvSmList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvSmList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvSmList.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvSmList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvSmList.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvSmList.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvSmList.GridControl = this.gcSmList;
            this.gvSmList.IndicatorWidth = 50;
            this.gvSmList.Name = "gvSmList";
            this.gvSmList.OptionsBehavior.Editable = false;
            this.gvSmList.OptionsBehavior.ReadOnly = true;
            this.gvSmList.OptionsView.ShowGroupPanel = false;
            this.gvSmList.OptionsView.ShowViewCaption = true;
            this.gvSmList.ViewCaption = "소분류";
            this.gvSmList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvSmList_CustomDrawRowIndicator);
            // 
            // gcMidList
            // 
            this.gcMidList.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcMidList.EmbeddedNavigator.TextStringFormat = "Record {0} of {1}";
            this.gcMidList.Location = new System.Drawing.Point(0, 308);
            this.gcMidList.LookAndFeel.SkinName = "Office 2010 Black";
            this.gcMidList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcMidList.MainView = this.gvMidList;
            this.gcMidList.Name = "gcMidList";
            this.gcMidList.Size = new System.Drawing.Size(1024, 213);
            this.gcMidList.TabIndex = 8;
            this.gcMidList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMidList});
            // 
            // gvMidList
            // 
            this.gvMidList.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvMidList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvMidList.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvMidList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvMidList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvMidList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvMidList.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvMidList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvMidList.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvMidList.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvMidList.GridControl = this.gcMidList;
            this.gvMidList.IndicatorWidth = 50;
            this.gvMidList.Name = "gvMidList";
            this.gvMidList.OptionsBehavior.Editable = false;
            this.gvMidList.OptionsBehavior.ReadOnly = true;
            this.gvMidList.OptionsView.ShowGroupPanel = false;
            this.gvMidList.OptionsView.ShowViewCaption = true;
            this.gvMidList.ViewCaption = "중분류";
            this.gvMidList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvMidList_CustomDrawRowIndicator);
            this.gvMidList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvMidList_FocusedRowChanged);
            this.gvMidList.Click += new System.EventHandler(this.gvMidList_Click);
            // 
            // gcbigList
            // 
            this.gcbigList.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcbigList.EmbeddedNavigator.TextStringFormat = "Record {0} of {1}";
            this.gcbigList.Location = new System.Drawing.Point(0, 94);
            this.gcbigList.LookAndFeel.SkinName = "Office 2010 Black";
            this.gcbigList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcbigList.MainView = this.gvbigList;
            this.gcbigList.Name = "gcbigList";
            this.gcbigList.Size = new System.Drawing.Size(1024, 202);
            this.gcbigList.TabIndex = 6;
            this.gcbigList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvbigList});
            // 
            // gvbigList
            // 
            this.gvbigList.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvbigList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvbigList.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvbigList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvbigList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvbigList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvbigList.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvbigList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvbigList.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvbigList.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvbigList.GridControl = this.gcbigList;
            this.gvbigList.IndicatorWidth = 50;
            this.gvbigList.Name = "gvbigList";
            this.gvbigList.OptionsBehavior.Editable = false;
            this.gvbigList.OptionsBehavior.ReadOnly = true;
            this.gvbigList.OptionsView.ShowGroupPanel = false;
            this.gvbigList.OptionsView.ShowViewCaption = true;
            this.gvbigList.ViewCaption = "대분류";
            this.gvbigList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvbigList_CustomDrawRowIndicator);
            this.gvbigList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvbigList_FocusedRowChanged);
            this.gvbigList.Click += new System.EventHandler(this.gvbigList_Click);
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl2.Location = new System.Drawing.Point(0, 296);
            this.splitterControl2.LookAndFeel.SkinName = "Office 2013";
            this.splitterControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(1024, 12);
            this.splitterControl2.TabIndex = 11;
            this.splitterControl2.TabStop = false;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 521);
            this.splitterControl1.LookAndFeel.SkinName = "Office 2013";
            this.splitterControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(1024, 12);
            this.splitterControl1.TabIndex = 12;
            this.splitterControl1.TabStop = false;
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
            this.barButtonItem1});
            this.barManager1.MaxItemId = 1;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.Caption = "조회";
            this.barButtonItem1.Glyph = global::VOC_LIST.Properties.Resources.search2;
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1024, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 768);
            this.barDockControlBottom.Size = new System.Drawing.Size(1024, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(1024, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 737);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.panelControl1);
            this.panelControl2.Controls.Add(this.lueDeptDetail);
            this.panelControl2.Controls.Add(this.lueDept);
            this.panelControl2.Controls.Add(this.lueGubun_Detail);
            this.panelControl2.Controls.Add(this.rgVOC1);
            this.panelControl2.Controls.Add(this.labelControl7);
            this.panelControl2.Controls.Add(this.deDate_To);
            this.panelControl2.Controls.Add(this.deDate_From);
            this.panelControl2.Controls.Add(this.lueDate_Gubun);
            this.panelControl2.Controls.Add(this.labelControl8);
            this.panelControl2.Controls.Add(this.labelControl9);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 31);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1024, 63);
            this.panelControl2.TabIndex = 8;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.rgVOC_P);
            this.panelControl1.Controls.Add(this.lue_ProblemLv);
            this.panelControl1.Controls.Add(this.rgVOC_A);
            this.panelControl1.Location = new System.Drawing.Point(700, 31);
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.LookAndFeel.UseWindowsXPTheme = true;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(312, 26);
            this.panelControl1.TabIndex = 30;
            // 
            // rgVOC_P
            // 
            this.rgVOC_P.AutoSize = true;
            this.rgVOC_P.BackColor = System.Drawing.Color.Transparent;
            this.rgVOC_P.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.rgVOC_P.Location = new System.Drawing.Point(96, 4);
            this.rgVOC_P.Name = "rgVOC_P";
            this.rgVOC_P.Size = new System.Drawing.Size(76, 18);
            this.rgVOC_P.TabIndex = 22;
            this.rgVOC_P.TabStop = true;
            this.rgVOC_P.Text = "문제VOC";
            this.rgVOC_P.UseVisualStyleBackColor = false;
            this.rgVOC_P.CheckedChanged += new System.EventHandler(this.rgVOC_P_CheckedChanged);
            // 
            // lue_ProblemLv
            // 
            this.lue_ProblemLv.Location = new System.Drawing.Point(176, 3);
            this.lue_ProblemLv.MenuManager = this.barManager1;
            this.lue_ProblemLv.Name = "lue_ProblemLv";
            this.lue_ProblemLv.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_ProblemLv.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("선택", "문제VOC")});
            this.lue_ProblemLv.Properties.NullText = "선택";
            this.lue_ProblemLv.Size = new System.Drawing.Size(117, 20);
            this.lue_ProblemLv.TabIndex = 20;
            // 
            // rgVOC_A
            // 
            this.rgVOC_A.AutoSize = true;
            this.rgVOC_A.BackColor = System.Drawing.Color.Transparent;
            this.rgVOC_A.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.rgVOC_A.Location = new System.Drawing.Point(17, 4);
            this.rgVOC_A.Name = "rgVOC_A";
            this.rgVOC_A.Size = new System.Drawing.Size(76, 18);
            this.rgVOC_A.TabIndex = 21;
            this.rgVOC_A.TabStop = true;
            this.rgVOC_A.Text = "전체VOC";
            this.rgVOC_A.UseVisualStyleBackColor = false;
            this.rgVOC_A.CheckedChanged += new System.EventHandler(this.rgVOC_A_CheckedChanged);
            // 
            // lueDeptDetail
            // 
            this.lueDeptDetail.Location = new System.Drawing.Point(285, 34);
            this.lueDeptDetail.MenuManager = this.barManager1;
            this.lueDeptDetail.Name = "lueDeptDetail";
            this.lueDeptDetail.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDeptDetail.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("부서명", "부서")});
            this.lueDeptDetail.Properties.NullText = "선택";
            this.lueDeptDetail.Size = new System.Drawing.Size(162, 20);
            this.lueDeptDetail.TabIndex = 29;
            // 
            // lueDept
            // 
            this.lueDept.Location = new System.Drawing.Point(117, 34);
            this.lueDept.MenuManager = this.barManager1;
            this.lueDept.Name = "lueDept";
            this.lueDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDept.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("부서명", "부서")});
            this.lueDept.Properties.NullText = "선택";
            this.lueDept.Size = new System.Drawing.Size(162, 20);
            this.lueDept.TabIndex = 28;
            this.lueDept.EditValueChanged += new System.EventHandler(this.lueDept_EditValueChanged);
            // 
            // lueGubun_Detail
            // 
            this.lueGubun_Detail.Location = new System.Drawing.Point(223, 7);
            this.lueGubun_Detail.MenuManager = this.barManager1;
            this.lueGubun_Detail.Name = "lueGubun_Detail";
            this.lueGubun_Detail.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGubun_Detail.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "상세구분")});
            this.lueGubun_Detail.Properties.NullText = "선택";
            this.lueGubun_Detail.Size = new System.Drawing.Size(100, 20);
            this.lueGubun_Detail.TabIndex = 27;
            this.lueGubun_Detail.EditValueChanged += new System.EventHandler(this.lueGubun_Detail_EditValueChanged);
            // 
            // rgVOC1
            // 
            this.rgVOC1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rgVOC1.EditValue = "A";
            this.rgVOC1.Location = new System.Drawing.Point(785, 5);
            this.rgVOC1.MenuManager = this.barManager1;
            this.rgVOC1.Name = "rgVOC1";
            this.rgVOC1.Properties.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.rgVOC1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.rgVOC1.Properties.Appearance.Options.UseBackColor = true;
            this.rgVOC1.Properties.Appearance.Options.UseFont = true;
            this.rgVOC1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.rgVOC1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("A", "전체 VOC"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("P", "문제 VOC")});
            this.rgVOC1.Size = new System.Drawing.Size(227, 22);
            this.rgVOC1.TabIndex = 26;
            this.rgVOC1.Visible = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(430, 9);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(17, 14);
            this.labelControl7.TabIndex = 25;
            this.labelControl7.Text = " ~ ";
            // 
            // deDate_To
            // 
            this.deDate_To.EditValue = null;
            this.deDate_To.Location = new System.Drawing.Point(449, 7);
            this.deDate_To.MenuManager = this.barManager1;
            this.deDate_To.Name = "deDate_To";
            this.deDate_To.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDate_To.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDate_To.Size = new System.Drawing.Size(100, 20);
            this.deDate_To.TabIndex = 24;
            // 
            // deDate_From
            // 
            this.deDate_From.EditValue = null;
            this.deDate_From.Location = new System.Drawing.Point(329, 7);
            this.deDate_From.MenuManager = this.barManager1;
            this.deDate_From.Name = "deDate_From";
            this.deDate_From.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDate_From.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDate_From.Size = new System.Drawing.Size(100, 20);
            this.deDate_From.TabIndex = 23;
            this.deDate_From.EditValueChanged += new System.EventHandler(this.deDate_From_EditValueChanged);
            // 
            // lueDate_Gubun
            // 
            this.lueDate_Gubun.Location = new System.Drawing.Point(117, 7);
            this.lueDate_Gubun.MenuManager = this.barManager1;
            this.lueDate_Gubun.Name = "lueDate_Gubun";
            this.lueDate_Gubun.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDate_Gubun.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "구분")});
            this.lueDate_Gubun.Properties.NullText = "선택";
            this.lueDate_Gubun.Size = new System.Drawing.Size(100, 20);
            this.lueDate_Gubun.TabIndex = 21;
            this.lueDate_Gubun.EditValueChanged += new System.EventHandler(this.lueDate_Gubun_EditValueChanged);
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl8.Appearance.Image = global::VOC_LIST.Properties.Resources._1416917852_resultset_next;
            this.labelControl8.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl8.LineColor = System.Drawing.Color.Silver;
            this.labelControl8.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.labelControl8.LineVisible = true;
            this.labelControl8.Location = new System.Drawing.Point(15, 31);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(96, 27);
            this.labelControl8.TabIndex = 20;
            this.labelControl8.Text = "소속";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl9.Appearance.Image = global::VOC_LIST.Properties.Resources._1416917852_resultset_next;
            this.labelControl9.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl9.LineColor = System.Drawing.Color.Silver;
            this.labelControl9.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.labelControl9.LineVisible = true;
            this.labelControl9.Location = new System.Drawing.Point(15, 4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(96, 27);
            this.labelControl9.TabIndex = 19;
            this.labelControl9.Text = "기간";
            // 
            // VOC_TotalStateMng_Category_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcSmList);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.gcMidList);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.gcbigList);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "Office 2013";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "VOC_TotalStateMng_Category_Detail";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.VOC_TotalStateMng_Category_Load);
            this.SizeChanged += new System.EventHandler(this.VOC_TotalStateMng_Category_Detail_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VOC_TotalStateMng_Category_Detail_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gcSmList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSmList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMidList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMidList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcbigList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvbigList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lue_ProblemLv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDeptDetail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGubun_Detail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgVOC1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate_To.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate_To.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate_From.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate_From.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDate_Gubun.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcSmList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSmList;
        private DevExpress.XtraGrid.GridControl gcMidList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMidList;
        private DevExpress.XtraGrid.GridControl gcbigList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvbigList;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueGubun_Detail;
        private DevExpress.XtraEditors.RadioGroup rgVOC1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.DateEdit deDate_To;
        private DevExpress.XtraEditors.DateEdit deDate_From;
        private DevExpress.XtraEditors.LookUpEdit lueDate_Gubun;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LookUpEdit lueDeptDetail;
        private DevExpress.XtraEditors.LookUpEdit lueDept;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.RadioButton rgVOC_P;
        private DevExpress.XtraEditors.LookUpEdit lue_ProblemLv;
        private System.Windows.Forms.RadioButton rgVOC_A;
    }
}
