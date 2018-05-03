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
    public partial class VOC_DivideMng : DevExpress.XtraEditors.XtraForm
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
        string strRegUser = string.Empty;
        string strRegDate = string.Empty;
        string strAuth = string.Empty;
        string strCraimCode = string.Empty;
        string strGubun = string.Empty;
        DataTable dtCustWork = new DataTable();
        DataTable dtCustWork_set = new DataTable();
        #endregion

        public VOC_DivideMng()
        {
            InitializeComponent();
        }

        public VOC_DivideMng(string pUserID, string pDeptCode, string pRegDate, string pRegNum, string pRegUser)
        {
            InitializeComponent();
            strUserID = pUserID;
            strDeptCode = pDeptCode;
            strRegDate = pRegDate;
            strRegUser = pRegUser;
            strRegNum = pRegNum;
            strGubun = "A";
        }

        public VOC_DivideMng(string pUserID, string pDeptCode, string pCraimCode)
        {
            InitializeComponent();
            strUserID = pUserID;
            strDeptCode = pDeptCode;
            strCraimCode = pCraimCode;
            strGubun = "B";
        }

        public VOC_DivideMng(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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
            setlueDept();
            setlueWork_Gubun();
            setDeDate();
            getDTCustWork();
            setgcCategory();
            setUserGubun();
            setMonitoringList();
            GetHistroy();
            //setBigCate();

            if (luePro_State.EditValue.ToString() == "Y")
            {
                lueDistr_Work_Dept.Properties.ReadOnly = true;
                lueDistr_Part_Dept.Properties.ReadOnly = true;
                lueDistr_Team_Dept.Properties.ReadOnly = true;
                lueDistr_Recei_Dept.Properties.ReadOnly = true;

                lueDistr_Work_User.Properties.ReadOnly = true;
                lueDistr_Part_User.Properties.ReadOnly = true;
                lueDistr_Team_User.Properties.ReadOnly = true;
                lueDistr_Recei_User.Properties.ReadOnly = true;
                btnSMS1.Enabled = false;
                btnSMS2.Enabled = false;
                btnSMS3.Enabled = false;
                btnSave_Dist.Enabled = false;

            }
            if (strAuth == "D")
            {
                lueRecei_Dept.Visible = false;
                lueRecei_User.Visible = false;
            }
            else
            {
                lueRecei_Dept.Visible = true;
                lueRecei_User.Visible = true;
            }
        }

        private void GetHistroy()
        {
            try
            {
                Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_Get고객요청HIS";
                dbA.Procedure.ParamAdd("@클레임번호", teCate_ClaimNum.Text);

                Cesco.FW.Global.DBAdapter.Utils.DebugingTools debug = new Cesco.FW.Global.DBAdapter.Utils.DebugingTools();
                string sqlQuery = debug.GetExcuteSqlString(dbA.Procedure);

                DataSet ds = dbA.ProcedureToDataSetCompress();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grd이력.DataSource = ds.Tables[0];
                }
                else
                {
                    grd이력.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void setDeDate()
        {
            deRecei_Date.Text = DateTime.Now.ToString().Substring(0, 10);
        }


        private void setUserGubun()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_USERGUBUN";
            db.Procedure.ParamAdd("@USERID", strUserID);

            try
            {
                DataSet ds = db.ProcedureToDataSet();

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    return;
                }
                else
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "Y")
                    {
                        lueDistr_Work_Dept.Properties.ReadOnly = false;
                        lueDistr_Work_User.Properties.ReadOnly = false;
                        btnSave_Dist.Enabled = true;
                    }
                    else
                    {
                        lueDistr_Work_Dept.Properties.ReadOnly = true;
                        lueDistr_Work_User.Properties.ReadOnly = true;
                        btnSave_Dist.Enabled = false;
                    }
                }
 
            }
            catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            {
                MessageBox.Show(ex.Message, "DB 에러");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "처리되지 않은 에러");
            }
        }


        #region 기존 데이터 불러오기 ★★★★★★★★★★★★

        private void getDTCustWork()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            if (strGubun == "A")
            {
                db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_PROCESS_SELECT";
                db.Procedure.ParamAdd("@RegDate", strRegDate.Replace("-", "").Replace("-", "").Substring(0, 8));
                db.Procedure.ParamAdd("@RegUser", strRegUser);
                db.Procedure.ParamAdd("@RegNum", strRegNum);
             
            }
            else
            {
                db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_POP_SELECT";
                db.Procedure.ParamAdd("@CRAIMCODE", strCraimCode);
               
            }
            try
            {
                DataSet ds = db.ProcedureToDataSet();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    teCustCode.Text = ds.Tables[0].Rows[0]["고객코드"].ToString();
                    teCustNm.Text = ds.Tables[0].Rows[0]["고객명"].ToString();
                    teCustAddr1.Text = ds.Tables[0].Rows[0]["주소1"].ToString();
                    teCustAddr2.Text = ds.Tables[0].Rows[0]["주소2"].ToString();
                    lueCustMng_Dept.EditValue = ds.Tables[0].Rows[0]["담당부서"].ToString();
                    teCustMng.Text = ds.Tables[0].Rows[0]["고객담당사원"].ToString();
                    meReceiMemo.Text = ds.Tables[0].Rows[0]["접수내용"].ToString();
                    teCate_Receive.Text = ds.Tables[0].Rows[0]["접수차수"].ToString();
                    //  dePro_Date.Text = DateTime.Now.ToString();
                    deRecei_Date.Text = ds.Tables[0].Rows[0]["접수일자"].ToString();
                    lueRecei_Dept.EditValue = ds.Tables[0].Rows[0]["접수부서"].ToString();
                    lueRecei_User.EditValue = ds.Tables[0].Rows[0]["접수사원"].ToString();
                    teCate_ClaimNum.Text = ds.Tables[0].Rows[0]["크레임번호"].ToString();
                    lueDistr_Work_Dept.EditValue = ds.Tables[0].Rows[0]["처리부서"].ToString();
                    lueDistr_Work_User.EditValue = ds.Tables[0].Rows[0]["처리사원"].ToString();
                    lueDistr_Recei_Dept.EditValue = ds.Tables[0].Rows[0]["접수부서"].ToString();
                    lueDistr_Recei_User.EditValue = ds.Tables[0].Rows[0]["접수사원"].ToString();
                    teCall_TellNum.Text = ds.Tables[0].Rows[0]["고객전화번호"].ToString();
                    teCall_CellNum.Text = ds.Tables[0].Rows[0]["고객휴대전화"].ToString();
                    lueDistr_Recei_Dept.EditValue = ds.Tables[0].Rows[0]["사업소접수부서"].ToString();
                    lueDistr_Recei_User.EditValue = ds.Tables[0].Rows[0]["사업소접수자"].ToString();
                    rgCallYN.EditValue = ds.Tables[0].Rows[0]["통화여부"].ToString();
                    rgRegYN.EditValue = ds.Tables[0].Rows[0]["사업소접수여부"].ToString();
                    teCallTime.Text = ds.Tables[0].Rows[0]["통화시간"].ToString();
                    teCustMngDept.Text = ds.Tables[0].Rows[0]["통화시간"].ToString();
                    teCustMngUser.Text = ds.Tables[0].Rows[0]["고객담당자"].ToString();
                    lueCall_BigCate.EditValue = ds.Tables[0].Rows[0]["TM접수구분"].ToString();
                    lueDistr_Part_Dept.EditValue = ds.Tables[0].Rows[0]["처리부서"].ToString();
                    lueDistr_Team_Dept.EditValue = ds.Tables[0].Rows[0]["처리부서"].ToString();
                    lueDistr_Part_User.EditValue = ds.Tables[0].Rows[0]["배분파트장"].ToString();
                    lueDistr_Team_User.EditValue = ds.Tables[0].Rows[0]["배분팀장"].ToString();
                    tePro_OverTime.Text = ds.Tables[0].Rows[0]["대기시간"].ToString();
                    if (ds.Tables[0].Rows[0]["전화요청"].ToString() == "Y")
                        chkCall.Checked = true;
                    else
                        chkCall.Checked = false;
                    if (ds.Tables[0].Rows[0]["방문요청"].ToString() == "Y")
                        chkVisit.Checked = true;
                    else
                        chkVisit.Checked = false;

                    // 처리내용 탭
                    luePro_State.EditValue = ds.Tables[0].Rows[0]["처리여부코드"].ToString();
                    mePro_Memo1.Text = ds.Tables[0].Rows[0]["처리내용"].ToString();
                    mePro_Memo2.Text = ds.Tables[0].Rows[0]["처리내용2"].ToString();
                    dePro_Date.EditValue = ds.Tables[0].Rows[0]["처리일자2"].ToString();
                }
            }
            catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            {
                MessageBox.Show(ex.Message, "DB 에러");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "처리되지 않은 에러");
            }


          //  DataRow[] dRow_CustWork = dtCustWork.Select("고객코드 = '" + strCustCode + "' AND 접수순번 = '"+ strRegNum +"'");

          //  teCustCode.Text = dRow_CustWork[0]["고객코드"].ToString();
          //  teCustNm.Text = dRow_CustWork[0]["고객명"].ToString();
          //  teCustAddr1.Text = dRow_CustWork[0]["주소1"].ToString();
          //  teCustAddr2.Text = dRow_CustWork[0]["주소2"].ToString();
          //  lueCustMng_Dept.EditValue = dRow_CustWork[0]["담당부서"].ToString();
          //  teCustMng.Text = dRow_CustWork[0]["고객담당자"].ToString();
          //  meReceiMemo.Text = dRow_CustWork[0]["접수내용"].ToString();
          //  teCate_Receive.Text = dRow_CustWork[0]["접수차수"].ToString();
          ////  dePro_Date.Text = DateTime.Now.ToString();
          //  deRecei_Date.Text = dRow_CustWork[0]["접수일자"].ToString();
          //  lueRecei_Dept.EditValue = dRow_CustWork[0]["접수부서"].ToString();
          //  lueRecei_User.EditValue = dRow_CustWork[0]["접수사원"].ToString();
          //  teCate_ClaimNum.Text = dRow_CustWork[0]["크레임번호"].ToString();
          //  lueDistr_Work_Dept.EditValue = dRow_CustWork[0]["처리부서"].ToString();
          //  lueDistr_Work_User.EditValue = dRow_CustWork[0]["처리사원"].ToString();
          //  lueDistr_Recei_Dept.EditValue = dRow_CustWork[0]["접수부서"].ToString();
          //  lueDistr_Recei_User.EditValue = dRow_CustWork[0]["접수사원"].ToString();
          //  teCall_TellNum.Text = dRow_CustWork[0]["고객전화번호"].ToString();
          //  teCall_CellNum.Text = dRow_CustWork[0]["고객휴대전화"].ToString();
          //  lueDistr_Recei_Dept.EditValue = dRow_CustWork[0]["사업소접수부서"].ToString();
          //  lueDistr_Recei_User.EditValue = dRow_CustWork[0]["사업소접수자"].ToString();
          //  rgCallYN.EditValue = dRow_CustWork[0]["통화여부"].ToString();
          //  rgRegYN.EditValue = dRow_CustWork[0]["사업소접수여부"].ToString();
          //  teCallTime.Text = dRow_CustWork[0]["통화시간"].ToString();
          //  teCustMngDept.Text = dRow_CustWork[0]["통화시간"].ToString();
          //  teCustMngUser.Text = dRow_CustWork[0]["고객담당자"].ToString();
          //  lueCall_BigCate.EditValue = dRow_CustWork[0]["TM접수구분"].ToString();
          //  lueDistr_Part_Dept.EditValue = dRow_CustWork[0]["처리부서"].ToString();
          //  lueDistr_Team_Dept.EditValue = dRow_CustWork[0]["처리부서"].ToString();
          //  lueDistr_Part_User.EditValue = dRow_CustWork[0]["배분파트장"].ToString();
          //  lueDistr_Team_User.EditValue = dRow_CustWork[0]["배분팀장"].ToString();
          //  tePro_OverTime.Text = dRow_CustWork[0]["대기시간"].ToString();
          //  if (dRow_CustWork[0]["전화요청"].ToString() == "Y")
          //      chkCall.Checked = true;
          //  else
          //      chkCall.Checked = false;
          //  if (dRow_CustWork[0]["방문요청"].ToString() == "Y")
          //      chkVisit.Checked = true;
          //  else
          //      chkVisit.Checked = false;
        }
        #endregion

        #region 부서/사원 세팅 ★★★★★★★★★★★★
        /// <summary>
        /// 부서 세팅
        /// </summary>
        /// <param name="lueNm"></param>
        /// <param name="i"></param>
        /// <param name="paramValue"></param>
        /// <param name="valMem"></param>
        /// <param name="disMem"></param>
        private void setLue(LookUpEdit lueNm, int i, string paramValue, string valMem, string disMem)
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESNET2.dbo.SP_DEPT_SEARCH_ALL";
            db.Procedure.ParamAdd("@부서코드", paramValue);

            try
            {
                DataSet ds = db.ProcedureToDataSet();

                lueNm.Properties.ValueMember = valMem;
                lueNm.Properties.DisplayMember = disMem;
                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    XtraMessageBox.Show("조회된 데이터가 없습니다.");
                    return;
                }
                lueNm.Properties.DataSource = ds.Tables[i];
            }
            catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            {
                MessageBox.Show(ex.Message, "DB 에러");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "처리되지 않은 에러");
            }
        }

        private void setlueDept()
        {
            setLue(lueCustMng_Dept, 0, "", "부서코드", "부서명");
            setLue(lueDistr_Work_Dept, 0, "", "부서코드", "부서명");
            setLue(lueDistr_Part_Dept, 0, "", "부서코드", "부서명");
            setLue(lueDistr_Team_Dept, 0, "", "부서코드", "부서명");
            setLue(lueDistr_Recei_Dept, 0, "", "부서코드", "부서명");
            setLue(lueRecei_Dept, 0, "", "부서코드", "부서명");
        }

        private void lueDistr_Work_Dept_EditValueChanged(object sender, EventArgs e)
        {
            setLue(lueDistr_Work_User, 1, lueDistr_Work_Dept.EditValue.ToString(), "사번", "한글성명");
        }

        private void lueDistr_Part_Dept_EditValueChanged(object sender, EventArgs e)
        {
            setLue(lueDistr_Part_User, 1, lueDistr_Part_Dept.EditValue.ToString(), "사번", "한글성명");
        }

        private void lueDistr_Team_Dept_EditValueChanged(object sender, EventArgs e)
        {
            setLue(lueDistr_Team_User, 1, lueDistr_Team_Dept.EditValue.ToString(), "사번", "한글성명");
        }

        private void lueDistr_Recei_Dept_EditValueChanged(object sender, EventArgs e)
        {
            setLue(lueDistr_Recei_User, 1, lueDistr_Recei_Dept.EditValue.ToString(), "사번", "한글성명");
        }

        private void lueRecei_Dept_EditValueChanged(object sender, EventArgs e)
        {
            setLue(lueRecei_User, 1, lueRecei_Dept.EditValue.ToString(), "사번", "한글성명");
        }
        #endregion

        #region 대분류 세팅 ★★★★★★★★★★★★
        /// <summary>
        /// 업종구분 LUE 세팅
        /// </summary>
        private void setlueWork_Gubun()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_GUBUN_SELECT";
            try
            {
                DataSet ds = db.ProcedureToDataSet();

                lueCall_BigCate.Properties.ValueMember = "대분류코드";
                lueCall_BigCate.Properties.DisplayMember = "대분류명";

                luePro_State.Properties.ValueMember = "코드구분";
                luePro_State.Properties.DisplayMember = "코드명";

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[1].Rows.Count == 0)
                {
                    return;
                }

                lueCall_BigCate.Properties.DataSource = ds.Tables[4];
                luePro_State.Properties.DataSource = ds.Tables[3];
            }

            catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            {
                MessageBox.Show(ex.Message, "DB 에러");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "처리되지 않은 에러");
            }
        }
        #endregion

        #region 처리내용 등록 ★★★★★★★★★★★★
        private void btnProcMemo1_Save_Click(object sender, EventArgs e)
        {
            strPROMEMOGubun = "1";
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_PROCESS_SAVE";
            db.Procedure.ParamAdd("@PROMEMOGUBUN", strPROMEMOGubun);
            db.Procedure.ParamAdd("@PROTIME", tePro_OverTime.Text);
            db.Procedure.ParamAdd("@REGDATE", deRecei_Date.Text.Replace("-", "").Replace("-", ""));
            db.Procedure.ParamAdd("@REGUSER", lueRecei_User.EditValue);
            db.Procedure.ParamAdd("@REGNUM", strRegNum);
        }

        private void btnProcMemo2_Save_Click(object sender, EventArgs e)
        {
            strPROMEMOGubun = "2";
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_PROCESS_SAVE";
            db.Procedure.ParamAdd("@PROMEMOGUBUN", strPROMEMOGubun);
            db.Procedure.ParamAdd("@PROTIME", tePro_OverTime.Text);
            db.Procedure.ParamAdd("@REGDATE", deRecei_Date.Text.Replace("-", "").Replace("-", ""));
            db.Procedure.ParamAdd("@REGUSER", lueRecei_User.EditValue);
            db.Procedure.ParamAdd("@REGNUM", strRegNum);
        }

        #endregion

        #region 카테고리 변경 버튼 클릭 ★★★★★★★★★★★★
        private void btnCate_Change_Click(object sender, EventArgs e)
        {
            if (lueCall_BigCate.EditValue == "" || lueCall_BigCate.EditValue == null)
            {
                MessageBox.Show("대분류를 먼저 선택해주세요.", "대분류 미선택", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lueCall_BigCate.Focus();
                return;
            }

            string strRegDate = deRecei_Date.Text.Replace("-", "").Replace("-", "");
            string strRegUserID = lueRecei_User.EditValue.ToString();
            string strBigCate = lueCall_BigCate.EditValue.ToString();
            string strClaimNum = teCate_ClaimNum.Text;
            VOC_FrmCategoryChg FC = new VOC_FrmCategoryChg(strUserID, strBigCate, strClaimNum, strRegDate, strRegUserID, strRegNum);
            FC.StartPosition = FormStartPosition.CenterParent;
            FC.ShowDialog();

            setgcCategory();
        }
        #endregion

        #region 카테고리 테이블 불러오기 ★★★★★★★★★★★★
        private void setgcCategory()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_CATEGORY_SELECT";
            db.Procedure.ParamAdd("@CLAIMCODE", teCate_ClaimNum.Text);
            try
            {
                DataSet ds = db.ProcedureToDataSet();

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    return;
                }
                gcCategory.DataSource = ds.Tables[0];
            }

            catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            {
                MessageBox.Show(ex.Message, "DB 에러");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "처리되지 않은 에러");
            }
        }
        #endregion

        #region 고객정보열람 ★★★★★★★★★★★★★★
        private void btnContactHis_Click(object sender, EventArgs e)
        {
            if (teCustCode.Text != "")
            {
                string[] args = new string[9];

                args[0] = strUserID;
                args[1] = strDeptCode;
                args[2] = ""; // ibs 고객정보열람에서 매출/수금탭 고정 
                args[3] = strUpdateAuth;
                args[4] = strDeleteAuth;
                args[5] = strSearchAuth;
                args[6] = strPrintAuth;
                args[7] = strExcelAuth;
                args[8] = strDataAuth;

                bool bModal = true;
                int iFormWidth = 1010;
                int iFormHeight = 670;
                string MenuName = "고객상세정보";
                //string sFilePath = "NSIM.MasterMgmt.dll";
                //string sNameSpace = "NSIM.MasterMgmt.ClientInfo";
                //string sClass = "ClientInfoView";
                string sParam = teCustCode.Text;
                string sPath = "C:/Program Files/CESNET2.0/NSIMNew/NSIM.MasterMgmt.dll";

                CES.FUNCTION.CESAssembly cesAssem = new CES.FUNCTION.CESAssembly();
                object control = cesAssem.LoadAssembly(sPath, "NSIM.MasterMgmt.ClientInfo.ClientInfoView", args);

                System.Reflection.Assembly assem = System.Reflection.Assembly.LoadFrom("C:/Program Files/CESNET2.0/NSIMNew/NSIM.MasterMgmt.dll");
                //assem.CreateInstance("NSIM.MasterMgmt.ClientInfo.ClientInfoView", false, System.Reflection.BindingFlags.CreateInstance, null, args, null, null);
                System.Windows.Forms.UserControl ctrl = (System.Windows.Forms.UserControl)assem.CreateInstance("NSIM.MasterMgmt.ClientInfo.ClientInfoView", false, System.Reflection.BindingFlags.CreateInstance, null, args, null, null);
                ctrl.Dock = System.Windows.Forms.DockStyle.Fill;
                ctrl.Tag = sParam;

                Form frm = new Form();
                frm.Controls.Add(ctrl);
                frm.Size = new System.Drawing.Size(iFormWidth, iFormHeight);
                frm.Text = MenuName;
                frm.StartPosition = FormStartPosition.CenterParent;

                if (bModal)
                    frm.ShowDialog();
                else
                    frm.ShowDialog();
            }
        }
        #endregion

        #region SMS 보내기 ★★★★★★★★★★★★★★
        private void sendSMS(string strSendUserID, string strSendDeptCode, string strSendCustCode)
        {
            CCM_SMS.CCM_SMS_MAIN cs = new CCM_SMS.CCM_SMS_MAIN(strUserID, strDeptCode, "", strSendCustCode, strSendUserID, strSendDeptCode, "2", strInsertAuth, strUpdateAuth, strDeleteAuth, strSearchAuth, strPrintAuth, strExcelAuth, strDataAuth, meReceiMemo.Text);
            cs.Show();
        }

        private void btnSMS1_Click(object sender, EventArgs e)
        {
            sendSMS(lueDistr_Work_User.EditValue.ToString(), lueDistr_Work_Dept.EditValue.ToString(), teCustCode.Text);
        }

        private void btnSMS2_Click(object sender, EventArgs e)
        {
            sendSMS(lueDistr_Part_User.EditValue.ToString(), lueDistr_Part_Dept.EditValue.ToString(), teCustCode.Text);
        }

        private void btnSMS3_Click(object sender, EventArgs e)
        {
            sendSMS(lueDistr_Team_User.EditValue.ToString(), lueDistr_Team_Dept.EditValue.ToString(), teCustCode.Text);
        }
        #endregion


        #region 처리담당자 변경 ★★★★★★★★★★★★★
        private void btnSave_Dist_Click(object sender, EventArgs e)
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_WORK_DISTR";
            db.Procedure.ParamAdd("@WORK_USERID", lueDistr_Work_User.EditValue);
            db.Procedure.ParamAdd("@WORK_DEPTCODE", lueDistr_Work_Dept.EditValue); 	
            db.Procedure.ParamAdd("@REGDATE", deRecei_Date.Text.Replace("-", "").Replace("-", ""));
            db.Procedure.ParamAdd("@REGUSERID", lueRecei_User.EditValue);
            db.Procedure.ParamAdd("@REGNUM", strRegNum);		
            try
            {
                DataSet ds = db.ProcedureToDataSet();
            }
            catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            {
                MessageBox.Show(ex.Message, "DB 에러");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "처리되지 않은 에러");
            }

            MessageBox.Show("처리담당자가 변경되었습니다.", "처리담당자 저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        #endregion

        #region 모니터링 기준정보 리스트 조회 ★★★★★★★★★★★★★
        private void setMonitoringList() //string strCategoryNo
        {
            //Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            //db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_DIVIDE_MONITORING_SENDHIS"; //SP_VOC_DIVIDE_MONITORING_SELECT
            //db.Procedure.ParamAdd("@REGDATE", deRecei_Date.Text.Replace("-", "").Replace("-", ""));
            //db.Procedure.ParamAdd("@REGUSER", lueRecei_User.EditValue);
            //db.Procedure.ParamAdd("@REGNUM", strRegNum);
            //db.Procedure.ParamAdd("@CLAIMCODE", teCate_ClaimNum.Text);	

            //try
            //{
            //    DataSet ds = db.ProcedureToDataSet();

            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        gcMonitoringList.DataSource = ds.Tables[0];
            //    }
            //    if (ds.Tables[1].Rows.Count > 0)
            //    {
            //        gcChgHis.DataSource = ds.Tables[1];
            //    }

                
            //    ////tePro_OverTime.Text = ds.Tables[0].Rows[0][""].ToString();
            //    //teFitProTime.Text = ds.Tables[0].Rows[0]["권장처리시간"].ToString();
            //    //teMaxProTime.Text = ds.Tables[0].Rows[0]["MAX처리시간"].ToString();
            //}

            //catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            //{
            //    MessageBox.Show(ex.Message, "DB 에러");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "처리되지 않은 에러");
            //}

            Cesco.FW.Global.DBAdapter.DBAdapters db2 = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            db2.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_DIVIDE_MONITORING_SELECT"; //SP_VOC_DIVIDE_MONITORING_SELECT
            db2.Procedure.ParamAdd("@BIGCATEGORY", lueCall_BigCate.EditValue);	

            try
            {
                DataSet ds = db2.ProcedureToDataSet();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    teFitProTime.Text = ds.Tables[0].Rows[0]["권장처리시간"].ToString();
                    teMaxProTime.Text = ds.Tables[0].Rows[0]["MAX처리시간"].ToString();
                }
            }
            catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            {
                MessageBox.Show(ex.Message, "DB 에러");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "처리되지 않은 에러");
            }
        }

        #endregion



        #region 이미지 보기 버튼 클릭 ★★★★★★★★★★★★★
        private void btnImageView_Click(object sender, EventArgs e)
        {
            VOC_FrmImageView FI = new VOC_FrmImageView();
            FI.ShowDialog();
        }
        #endregion

        #region 메모 보기 버튼 클릭 ★★★★★★★★★★★★★
        private void btnMemoView_Click(object sender, EventArgs e)
        {
            VOC_FrmMemoView FM = new VOC_FrmMemoView();
            FM.ShowDialog();
        }
        #endregion

        private void gvCategory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string str_CategoryNo = string.Empty;
            string str_SmallCateNo = gvCategory.GetFocusedRowCellValue("소분류코드").ToString();

            if (str_SmallCateNo == "")
            {
                str_CategoryNo = gvCategory.GetFocusedRowCellValue("중분류코드").ToString();
            }
            else
            {
                str_CategoryNo = str_SmallCateNo;
            }

            //setMonitoringList(str_CategoryNo);
        }

        private void btnBigcate_Click(object sender, EventArgs e)
        {
            //setMonitoringList(lueCall_BigCate.EditValue.ToString());
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            VOC_VoluntaryReport VR = new VOC_VoluntaryReport(strUserID, teCustCode.Text, teCate_ClaimNum.Text);
            VR.StartPosition = FormStartPosition.CenterParent;
            if (VR.strYN != "N")
                VR.ShowDialog();
        }
    }
}
