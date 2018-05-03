using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace VOC_LIST
{
    public partial class VOC_DeleteManage : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member
        string strUserID = string.Empty;
        string strDeptCode = string.Empty;
        string strInsertAuth = string.Empty;
        string strUpdateAuth = string.Empty;
        string strDeleteAuth = string.Empty;
        string strSearchAuth = string.Empty;
        string strPrintAuth = string.Empty;
        string strExcelAuth = string.Empty;
        string strDataAuth = string.Empty;
        string strAuth = string.Empty;

        Cesco.FW.Global.Util.Common.CesnetUserAuthInfo _cesnetUserInfo = new Cesco.FW.Global.Util.Common.CesnetUserAuthInfo();
        #endregion

        public VOC_DeleteManage()
        {
            InitializeComponent();
        }
        public VOC_DeleteManage(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
        {
            InitializeComponent();

            strUserID = pUserID;
            strDeptCode = pDeptCode;
            strInsertAuth = pInsertAuth;
            strUpdateAuth = pUpdateAuth;
            strDeleteAuth = pDeleteAuth;
            strSearchAuth = pSearchAuth;
            strPrintAuth = pPrintAuth;
            strExcelAuth = pExcelAuth;
            strDataAuth = pDataAuth;
        }

        private void VOC_State_Load(object sender, EventArgs e)
        {
            setDate();
        }

        private void setDate()
        {
            DateTime mToday = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-7).Day);
            deStart_Date.EditValue = mToday;
            deEnd_Date.EditValue = DateTime.Now;
        }
        
        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            db.Procedure.ProcedureName = "CESCOEIS.dbo.USP_VOC_DELETE_HIS";
            //db.Procedure.ProcedureName = "BACKUPDB.dbo.USP_VOC_DELETE_HIS";
            db.Procedure.ParamAdd("@DTSTART", deStart_Date.Text.Replace("-", "").Replace("-", ""));
            db.Procedure.ParamAdd("@DTEND", deEnd_Date.Text.Replace("-", "").Replace("-", ""));

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = db.ProcedureToDataSet();

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    XtraMessageBox.Show("조회할 항목이 없습니다.");
                    return;
                }
                gcStateList.DataSource = ds.Tables[0];
            }
            catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            {
                MessageBox.Show(ex.Message, "DB 에러");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void gvStateList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}
