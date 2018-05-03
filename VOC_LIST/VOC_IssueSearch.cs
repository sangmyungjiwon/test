using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using EApprovalForms;

namespace VOC_LIST
{
    public partial class VOC_IssueSearch : DevExpress.XtraEditors.XtraUserControl
    {
        #region 생성자
        string _strUserID
                , _strDeptCode
                , _strInsertAuth
                , _strUpdateAuth
                , _strDeleteAuth
                , _strSearchAuth
                , _strPrintAuth
                , _strExcelAuth
                , _strDataAuth;
        #endregion

        string _custCode = string.Empty;

        public VOC_IssueSearch()
        {
            InitializeComponent();
        }

        public VOC_IssueSearch(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
        {
            InitializeComponent();

            _strDeptCode = pDeptCode;
            _strUserID = pUserID;
            _strInsertAuth = pInsertAuth;
            _strUpdateAuth = pUpdateAuth;
            _strDeleteAuth = pDeleteAuth;
            _strSearchAuth = pSearchAuth;
            _strPrintAuth = pPrintAuth;
            _strExcelAuth = pExcelAuth;
            _strDataAuth = pDataAuth;
        }

        private void VOC_IssueSearch_Load(object sender, EventArgs e)
        {
            ctiCustInfo.SetControl(_strUserID);
            ctiCustInfo.ResetControl();
            if (_custCode.Length != 0)
            {
                ctiCustInfo.CustCode = _custCode;
            }

            dtFrom.DateTime = DateTime.Now.AddDays(-15);
            dtTo.DateTime = DateTime.Now;            
        }

        private void grd이슈_DoubleClick(object sender, EventArgs e)
        {            
            if(gv이슈.RowCount == 0)
            {
                return;
            }            

            if (gv이슈.FocusedColumn.FieldName == "크레임번호")
            {
                if (gv이슈.GetFocusedRowCellValue("크레임번호").ToString() == "")
                    return;
                this.Cursor = Cursors.WaitCursor;
                VOC_DivideMng VW = new VOC_DivideMng(_strUserID, "", gv이슈.GetFocusedRowCellValue("접수일자").ToString().Replace("-", ""), gv이슈.GetFocusedRowCellValue("접수순번").ToString().Replace("-", ""), gv이슈.GetFocusedRowCellValue("접수사원").ToString().Replace("-", ""));
                VW.StartPosition = FormStartPosition.CenterParent;
                VW.ShowDialog();
                this.Cursor = Cursors.Default;
            }
            else
            {

                string path = "C:\\Program Files\\CESNET2.0\\CommonCtrl.dll";
                System.Reflection.Assembly assem = System.Reflection.Assembly.LoadFrom(path);
                Type[] t = assem.GetTypes();
                object result;
                string text = gv이슈.GetFocusedRowCellValue("ApprovalID").ToString();
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    result = assem.CreateInstance(
                    "CommonCtrl.UC_EApprovalReferencesViewer",
                    true,
                    BindingFlags.CreateInstance,
                    null,
                    new object[] { _strUserID, text },
                    null,
                    null);
                    Form uc = result as Form;
                    uc.Show();
                    this.Cursor = Cursors.Default;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_IssueSearch_SELECT";
                dbA.Procedure.ParamAdd("@From", dtFrom.DateTime.ToString("yyyyMMdd"));
                dbA.Procedure.ParamAdd("@To", dtTo.DateTime.ToString("yyyyMMdd"));
                dbA.Procedure.ParamAdd("@CustCode", ctiCustInfo.CustCode);
                dbA.Procedure.ParamAdd("@DeptCode", _strDeptCode);
                dbA.Procedure.ParamAdd("@UserId", _strUserID);


                Cesco.FW.Global.DBAdapter.Utils.DebugingTools debug = new Cesco.FW.Global.DBAdapter.Utils.DebugingTools();
                string sqlQuery = debug.GetExcuteSqlString(dbA.Procedure);

                DataSet ds = dbA.ProcedureToDataSetCompress();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grd이슈.DataSource = ds.Tables[0];
                }
                else
                {
                    grd이슈.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gv이슈_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnWrite_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //IssueRegistration IR = new IssueRegistration(_strUserID, _strDeptCode, "", gv이슈.GetFocusedRowCellValue("크레임번호").ToString());
            //IR.Show();
              // 결재 문서 작성 폼 객체 생성
            //CESMM.Connection.Common oCommon = new CESMM.Connection.Common();
            try
            {
                //if (oCommon.GetUSP_AP_ApprovalMasterStatus(gvPIList.GetFocusedRowCellValue("결재문서번호").ToString(), strUserID) == false)
                //{
                //    MessageBox.Show("이미 결재 진행중인 건이므로 진행할 수 없습니다.", "전자결재 진행중", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}
                string[] args = new string[4];
                args[0] = _strUserID;
                args[1] = _strDeptCode;
                args[2] = "F713";
               
                CommonFunc.CallAssembly oCallAssembly = new CommonFunc.CallAssembly();
                oCallAssembly.CallAssemblyBy4(true, 1000, 700, "전자결재작성", "592", args, ".\\GroupWare\\EApprovalWrite.dll", "EApprovalWrite", "EApprovalFormWrite");
                //oCallAssembly.CallAssemblyBy4(false, 1000, 700, "전자결재작성", "592", args, "GroupWare\\EApprovalWrite.dll", "EApprovalWrite", "EApprovalFormWrite");
                //oCallAssembly.CallAssemblyBy4(false, 1000, 700, "전자결재작성", "592", args, "C:\\Program Files\\CESNET2.0\\GroupWare\\EApprovalWrite.dll", "EApprovalWrite", "EApprovalFormWrite");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }
    }
}
