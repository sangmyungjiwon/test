namespace DocManagement
{
    partial class VOC_UserCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VOC_UserCheck));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.gcEmpList = new DevExpress.XtraGrid.GridControl();
            this.gvEmpList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmpList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmpList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(345, 30);
            this.panelControl1.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(270, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 85;
            this.btnSave.Text = "등록";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gcEmpList
            // 
            this.gcEmpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEmpList.Location = new System.Drawing.Point(0, 30);
            this.gcEmpList.LookAndFeel.SkinName = "Office 2010 Black";
            this.gcEmpList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcEmpList.MainView = this.gvEmpList;
            this.gcEmpList.Name = "gcEmpList";
            this.gcEmpList.Size = new System.Drawing.Size(345, 352);
            this.gcEmpList.TabIndex = 3;
            this.gcEmpList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEmpList});
            // 
            // gvEmpList
            // 
            this.gvEmpList.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.gvEmpList.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvEmpList.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvEmpList.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvEmpList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvEmpList.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvEmpList.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvEmpList.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gvEmpList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvEmpList.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvEmpList.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvEmpList.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gvEmpList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvEmpList.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvEmpList.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvEmpList.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvEmpList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gvEmpList.GridControl = this.gcEmpList;
            this.gvEmpList.Name = "gvEmpList";
            this.gvEmpList.OptionsBehavior.Editable = false;
            this.gvEmpList.OptionsView.ColumnAutoWidth = false;
            this.gvEmpList.OptionsView.EnableAppearanceEvenRow = true;
            this.gvEmpList.OptionsView.ShowGroupPanel = false;
            this.gvEmpList.DoubleClick += new System.EventHandler(this.gvEmpList_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "사번";
            this.gridColumn1.FieldName = "사번";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "직원명";
            this.gridColumn2.FieldName = "한글성명";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "부서코드";
            this.gridColumn3.FieldName = "부서코드";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "부서명";
            this.gridColumn4.FieldName = "부서명";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 132;
            // 
            // VOC_UserCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 382);
            this.Controls.Add(this.gcEmpList);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "VOC_UserCheck";
            this.Text = "사원 확인";
            this.Load += new System.EventHandler(this.Doc_UserCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcEmpList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmpList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.GridControl gcEmpList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEmpList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}