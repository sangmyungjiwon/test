﻿namespace VOC_LIST
{
    partial class VOC_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VOC_Form));
            this.panelControl = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.LookAndFeel.SkinName = "Office 2013";
            this.panelControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1014, 659);
            this.panelControl.TabIndex = 0;
            // 
            // VOC_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1014, 659);
            this.Controls.Add(this.panelControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "VOC_Form";
            this.Text = "VOC_검색리스트";
            this.Load += new System.EventHandler(this.VOC_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl;
    }
}