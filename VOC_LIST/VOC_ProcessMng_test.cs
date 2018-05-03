using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace VOC_LIST
{
    public partial class VOC_ProcessMng_test : DevExpress.XtraEditors.XtraForm
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
        string strCustCode = string.Empty;
        string strPROMEMOGubun = string.Empty;
        string strRegNum = string.Empty;
        string strAuth = string.Empty;
        string strRegUser = string.Empty;
        string strRegDate = string.Empty;

        DataTable dtCustWork = new DataTable();
        DataTable dtCustWork_set = new DataTable();

        #endregion

        public VOC_ProcessMng_test()
        {
            InitializeComponent();
        }

        public VOC_ProcessMng_test(string pUserID, string pDeptCode, string pCustCode, DataTable pCustWork, string pRegNum, DataRow dRow, string pAuth)
        {
            InitializeComponent();
            strUserID = pUserID;
            strDeptCode = pDeptCode;
            strCustCode = pCustCode;
            dtCustWork = pCustWork;
            strRegNum = pRegNum;
            strAuth = pAuth;
        }

        public VOC_ProcessMng_test(string pUserID, string pDeptCode, string pRegDate, string pRegNum, string pRegUser, string pCustcode, string pAuth)
        {
            InitializeComponent();
            strUserID = pUserID;
            strDeptCode = pDeptCode;
            strRegDate = pRegDate;
            strRegUser = pRegUser;
            strRegNum = pRegNum;
            strCustCode = pCustcode;
            strAuth = pAuth;
        }


        public VOC_ProcessMng_test(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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

        private void VOC_WORK_Load(object sender, EventArgs e)
        {
            //luePro_State.EditValueChanged -= luePro_State_EditValueChanged;


            //setlueDept();

            //setlueWork_Gubun();
            //setgcCategory();
            //setUserGubun();
            //if (lueCall_BigCate.Text == "")
            //{
            //    btnCate_Change.Enabled = false;
            //}
            //else
            //{
            //    btnCate_Change.Enabled = true;
            //}

            //if (lueDistr_Work_User.EditValue.ToString() == strUserID)
            //{
            //    if (luePro_State.EditValue.ToString() == "I") // I == 입력완료, N == 미처리
            //    {
            //        Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            //        strPROMEMOGubun = "2";
            //        db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_READ_SAVE";

            //        db.Procedure.ParamAdd("@PROSTATE", "R");
            //        db.Procedure.ParamAdd("@REGDATE", deRecei_Date.Text.Replace("-", "").Replace("-", ""));
            //        db.Procedure.ParamAdd("@REGUSER", lueRecei_User.EditValue);
            //        db.Procedure.ParamAdd("@REGNUM", strRegNum);
            //        try
            //        {
            //            DataSet ds = db.ProcedureToDataSet();
            //            luePro_State.EditValue = "R";
            //        }
            //        catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            //        {
            //            MessageBox.Show(ex.Message, "DB 에러");
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, "처리되지 않은 에러");
            //        }
            //    }
            //}

            //if (strAuth == "D")
            //{
            //    lueRecei_Dept.Visible = false;
            //    lueRecei_User.Visible = false;
            //}
            //else
            //{
            //    lueRecei_Dept.Visible = true;
            //    lueRecei_User.Visible = true;
            //}
            ////setBigCate();
            //btnProcMemo2_Save.Enabled = false;
            //mePro_Memo2.Properties.ReadOnly = true;
            ////처리완료 상태이면 저장 버튼 비활성화

            //if (luePro_State.EditValue.ToString() == "Y")
            //{
            //    mePro_Memo1.Properties.ReadOnly = true;
            //    btnProcMemo1_Save.Enabled = false;
            //    btnSave_Dist.Enabled = false;

            //    dePro_Date.Enabled = false;
            //    luePro_State.Enabled = false;

            //    btnAllSave.Enabled = false;
            //}

            //luePro_State.EditValueChanged += luePro_State_EditValueChanged;

        }

   


    }
}