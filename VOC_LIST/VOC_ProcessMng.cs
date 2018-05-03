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
    public partial class VOC_ProcessMng : DevExpress.XtraEditors.XtraForm
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
        string strVCNO = string.Empty;
        string strVCTP = string.Empty;
        string strPartCode = string.Empty;
        string strOriPartCode = string.Empty;

        DataTable dtCustWork = new DataTable();
        DataTable dtCustWork_set = new DataTable(); 
     
        #endregion

        public VOC_ProcessMng()
        {
            InitializeComponent();
        }

        public VOC_ProcessMng(string pUserID, string pDeptCode, string pCustCode, DataTable pCustWork, string pRegNum, DataRow dRow, string pAuth)
        {
            InitializeComponent();
            strUserID = pUserID;
            strDeptCode = pDeptCode;
            strCustCode = pCustCode;
            dtCustWork = pCustWork;
            strRegNum = pRegNum;
            strAuth = pAuth;
        }

        public VOC_ProcessMng(string pUserID, string pDeptCode, string pRegDate, string pRegNum, string pRegUser, string pCustcode, string pAuth)
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


        public VOC_ProcessMng(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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
        public VOC_ProcessMng(string pUserID, string pDeptCode, string pRegDate, string pRegNum, string pRegUser, string pCustcode, string pAuth, string pstrVCNO, string pstrVCTP, string pmsg)
        {                      
            
            InitializeComponent();

            strUserID = pUserID;
            strDeptCode = pDeptCode;
            strRegDate = pRegDate;
            strRegUser = pRegUser;
            strRegNum = pRegNum;
            strCustCode = pCustcode;
            strAuth = pAuth;
            strVCNO = pstrVCNO;
            strVCTP = pstrVCTP;
        }
        public VOC_ProcessMng(string pUserID, string pDeptCode, string pRegDate, string pRegNum, string pRegUser, string pCustcode, string pAuth, string pstrVCNO, string pstrVCTP, string pmsg, string pPartCode)
        {

            InitializeComponent();

            strUserID = pUserID;
            strDeptCode = pDeptCode;
            strRegDate = pRegDate;
            strRegUser = pRegUser;
            strRegNum = pRegNum;
            strCustCode = pCustcode;
            strAuth = pAuth;
            strVCNO = pstrVCNO;
            strVCTP = pstrVCTP;
            strPartCode = pPartCode;
        }
        private void VOC_WORK_Load(object sender, EventArgs e)
        {
            luePro_State.EditValueChanged -= luePro_State_EditValueChanged;

            //접수일자 처리일자 세팅
            setDeDate();
            //대분류 세팅
            setlueWork_Gubun();
            //상세리스트세팅
            getDTCustWork();
            //처리담당자부서세팅
            setlueDept();
            //중분류,세분류 세팅
            setgcCategory();
            //처리담당자 세팅
            setUserGubun();
            //대분류 조건
            if (lueCall_BigCate.Text == "")
            {
                btnCate_Change.Enabled = false;
            }
            else
            {
                btnCate_Change.Enabled = true;
            }
            //처리담당자와 로그인사원이 같을 시 읽음으로 변경로직
            if (lueDistr_Work_User.EditValue.ToString() == strUserID)
            {
                //if (luePro_State.EditValue.ToString() == "I") // I == 입력완료 RY08 , N == 미처리 RY04
                if (luePro_State.EditValue.ToString() == "RY04") //미처링일때 읽음으로 표시
                {
                    Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

                    strPROMEMOGubun = "2";
                    db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_READ_SAVE_SDH";

                    //db.Procedure.ParamAdd("@PROSTATE", "R"); //읽음 RY07
                    db.Procedure.ParamAdd("@PROSTATE", "RY07"); //읽음 RY07
                    db.Procedure.ParamAdd("@REGDATE", deRecei_Date.Text.Replace("-", "").Replace("-", ""));
                    db.Procedure.ParamAdd("@REGUSER", strUserID);
                    db.Procedure.ParamAdd("@REGDEPT", strDeptCode);
                    db.Procedure.ParamAdd("@REGNUM", strRegNum);
                    db.Procedure.ParamAdd("@VCNO", strVCNO);
                    db.Procedure.ParamAdd("@VCTP", strVCTP.Trim());

                    try
                    {
                        DataSet ds = db.ProcedureToDataSet();
                        // luePro_State.EditValue = "R";//읽음 RY07
                        luePro_State.EditValue = "RY07";//읽음 RY07
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
            }

            if (strAuth == "D")
            {
                
                teRecei_Dept.Visible = false;
                teRecei_User.Visible = false;
            }
            else
            {
               
                teRecei_Dept.Visible = true;
                teRecei_User.Visible = true;
            }
    
            if (luePro_State.EditValue.ToString() == "RY01") //RY01 처리완료
            {
                mePro_Memo1.Properties.ReadOnly = true;
                btnProcMemo1_Save.Enabled = false;
                btnSave_Dist.Enabled = false;

                dePro_Date.Enabled = false;
                luePro_State.Enabled = false;
                btnCate_Change.Enabled = false;
                btnSMS1.Enabled = false; // 20170706 이보현 추가 요청서 상신

                // 20171211 이보현 추가내용 요청서 상신
                mePro_Memo2.Properties.ReadOnly = false;
                btnProcMemo2_Save.Enabled = true;
            }

            luePro_State.EditValueChanged += luePro_State_EditValueChanged;
           
        }

        private void setDeDate()
        {
            //deRecei_Date.Text = DateTime.Now.ToString().Substring(0, 10);
            //dePro_Date.Text = DateTime.Now.ToString().Substring(0, 10);
            deRecei_Date.EditValue = DateTime.Now;
            dePro_Date.EditValue = DateTime.Now;

        }



        /// <summary>
        /// 카테고리 변경 버튼 enabled 여부
        /// </summary>
        private void setBigCate()
        {
            if (lueCall_BigCate.EditValue.ToString() == "")
            {
                btnCate_Change.Enabled = false;
            }
            else
            {
                btnCate_Change.Enabled = true;
            }
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
                        lueDistr_Work_Dept.Properties.ReadOnly = true;
                        lueDistr_Work_User.Properties.ReadOnly = true;
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

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_PROCESS_SELECT_SDH_VER2";
            db.Procedure.ParamAdd("@RegDate", strRegDate.Replace("-", "").Replace("-", "").Substring(0, 8));
            db.Procedure.ParamAdd("@RegUser", strRegUser);
            db.Procedure.ParamAdd("@RegNum", strRegNum);
            db.Procedure.ParamAdd("@VCNO", strVCNO);
            db.Procedure.ParamAdd("@VCTP", strVCTP.Trim());
            db.Procedure.ParamAdd("@USERID", strUserID);

            try
            {
                DataSet ds = db.ProcedureToDataSet();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    teCustCode.Text = ds.Tables[0].Rows[0]["고객코드"].ToString();
                    teCustNm.Text = ds.Tables[0].Rows[0]["고객명"].ToString();
                    teCustAddr1.Text = ds.Tables[0].Rows[0]["주소1"].ToString();
                    teCustAddr2.Text = ds.Tables[0].Rows[0]["주소2"].ToString();
                    teCustMng_Dept.Text = ds.Tables[0].Rows[0]["고객담당부서명"].ToString();
                    teCustMng.Text = ds.Tables[0].Rows[0]["고객담당사원"].ToString();


                    teCustMngDept.Text = ds.Tables[0].Rows[0]["고객담당부서코드"].ToString();
                    teCustMngUser.Text = ds.Tables[0].Rows[0]["고객담당자"].ToString();
                    teCall_TellNum.Text = ds.Tables[0].Rows[0]["고객전화번호"].ToString();
                    teCall_CellNum.Text = ds.Tables[0].Rows[0]["고객휴대전화"].ToString();

                    teCate_ClaimNum.Text = ds.Tables[0].Rows[0]["클레임번호"].ToString();
                    lueCall_BigCate.EditValue = ds.Tables[0].Rows[0]["대분류"].ToString().Trim();

                    strOriPartCode = ds.Tables[0].Rows[0]["PartCode"].ToString();

                    lueDistr_Work_Dept.EditValue = ds.Tables[0].Rows[0]["처리부서"].ToString();
                    lueDistr_Work_User.EditValue = ds.Tables[0].Rows[0]["처리사원"].ToString();
                    
                    
                    teRecei_Dept.Text = ds.Tables[0].Rows[0]["접수사원부서명"].ToString();
                    teRecei_User.Text = ds.Tables[0].Rows[0]["접수사원명"].ToString();
                    teRecei_UserID.Text = ds.Tables[0].Rows[0]["접수사원"].ToString();
                    meReceiMemo.Text = ds.Tables[0].Rows[0]["접수내용"].ToString();
                    deRecei_Date.Text = ds.Tables[0].Rows[0]["접수일자"].ToString();

                    luePro_State.EditValue = ds.Tables[0].Rows[0]["처리여부코드"].ToString();
                    dePro_Date.Text = ds.Tables[0].Rows[0]["처리일자"].ToString();
                    tePro_OverTime.Text = ds.Tables[0].Rows[0]["대기시간"].ToString();
                    mePro_Memo1.Text = ds.Tables[0].Rows[0]["처리내용"].ToString();


                    lueDistr_Work_Dept2.EditValue = strDeptCode;
                    lueDistr_Work_User2.EditValue = strUserID;

                    if (strDeptCode == "10259" || strDeptCode == "10225" || strDeptCode == "10226" || strDeptCode == "10227" || strDeptCode == "10228")
                        lueDistr_Work_Dept2.Properties.ReadOnly = false;
                    else
                        lueDistr_Work_Dept2.Properties.ReadOnly = true;

                    //if (teCustCode.Text == "EO0521")
                    //{
                    //    btnDept.Visible = true;
                    //    btnStaff.Visible = true;
                    //}
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    gc1.DataSource = ds.Tables[1];
                
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
            if (strUserID == "15897" || strUserID == "18251" || strUserID == "18146")
                db.Procedure.ParamAdd("@파트코드", "");
            else
                db.Procedure.ParamAdd("@파트코드", i == 4 ? strOriPartCode.Replace(" ", "") : "");

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
            setLue(lueDistr_Work_Dept, 0, teCustMngDept.Text.Replace(" ", ""), "부서코드", "부서명");
            setLue(lueDistr_Work_Dept2, 0, strDeptCode, "부서코드", "부서명");
        }

        private void lueDistr_Work_Dept_EditValueChanged(object sender, EventArgs e)
        {
            setLue(lueDistr_Work_User, 1, lueDistr_Work_Dept.EditValue.ToString(), "사번", "한글성명");

            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_PROMNG_SELECT";
            db.Procedure.ParamAdd("@DEPTCODE", lueDistr_Work_Dept.EditValue);
            db.Procedure.ParamAdd("@VOCID", lueCall_BigCate.EditValue);/////////////////////////////////////

            try
            {
                DataSet ds = db.ProcedureToDataSet();
                
                if (ds.Tables[0].Rows.Count > 0 )
                  lueDistr_Work_User.EditValue = ds.Tables[0].Rows[0]["처리담당자사원"];
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

        private void lueDistr_Work_Dept2_EditValueChanged(object sender, EventArgs e)
        {
            setLue(lueDistr_Work_User2, 4, lueDistr_Work_Dept2.EditValue.ToString(), "사번", "한글성명");
        }

        //private void lueDistr_Part_Dept_EditValueChanged(object sender, EventArgs e)
        //{
        //    setLue(lueDistr_Part_User, 1, lueDistr_Part_Dept.EditValue.ToString(), "사번", "한글성명");
        //}

        //private void lueDistr_Team_Dept_EditValueChanged(object sender, EventArgs e)
        //{
        //    setLue(lueDistr_Team_User, 1, lueDistr_Team_Dept.EditValue.ToString(), "사번", "한글성명");
        //}

        #endregion

        #region 대분류 세팅 ★★★★★★★★★★★★
        /// <summary>
        /// 업종구분 LUE 세팅
        /// </summary>
        private void setlueWork_Gubun()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            //db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_GUBUN_SELECT";
            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_GUBUN_SELECT_SDH";
            
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
            string strProUser = string.Empty;
            string str직책코드 = string.Empty;
            string str직책코드_Log = string.Empty;
            
            Cesco.FW.Global.DBAdapter.DBAdapters db_Pro = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            db_Pro.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_SMALLESSEN_PRO_CHECK_SDH";
            db_Pro.Procedure.ParamAdd("@RegNum", strRegNum);
            db_Pro.Procedure.ParamAdd("@VCNO", strVCNO);
            db_Pro.Procedure.ParamAdd("@VCTP", strVCTP.Trim());
            db_Pro.Procedure.ParamAdd("@STAFFID", strUserID);

            try
            {
                DataSet ds = db_Pro.ProcedureToDataSet();
                strProUser = ds.Tables[0].Rows[0]["처리사원"].ToString();
                str직책코드 = ds.Tables[0].Rows[0]["직책코드"].ToString();
                str직책코드_Log = ds.Tables[1].Rows[0]["직책코드"].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (strUserID != strProUser)
            {
                if (str직책코드 != "B39" && str직책코드 != "B41" && str직책코드 != "B42" && str직책코드 != "B43" && str직책코드 != "B45")
                {
                    MessageBox.Show("처리 담당자만 저장할 수 있습니다.", "저장 불가", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (str직책코드_Log != "B39" && str직책코드_Log != "B41" && str직책코드_Log != "B42" && str직책코드_Log != "B43" && str직책코드_Log != "B45")
                {
                    MessageBox.Show("처리 담당자만 저장할 수 있습니다.", "저장 불가", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (mePro_Memo1.Text == "")
            {
                 MessageBox.Show("처리내용은 필수 항목입니다.", "처리내용 미입력", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 mePro_Memo1.Focus();
                 return;
            }
      
            Cesco.FW.Global.DBAdapter.DBAdapters db2 = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            db2.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_SMALLESSEN_CHECK_SDH";
            db2.Procedure.ParamAdd("@RegNum", strRegNum);
            db2.Procedure.ParamAdd("@VCNO", strVCNO);
            db2.Procedure.ParamAdd("@VCTP", strVCTP.Trim());
       
            try
            {
                DataSet ds = db2.ProcedureToDataSet();

                DataRow[] dRow_A = ds.Tables[0].Select("SUBCLASSESSEN = 'A'");
                if (dRow_A.Length > 0)
                {
                    string strMid = string.Empty;
                    for (int i = 0; i < dRow_A.Length; i++)
                    {
                        strMid += dRow_A[i]["VOCNAME"].ToString();
                        if (i < dRow_A.Length - 1)
                        {
                            strMid += strMid + ", ";
                        }
                    }

                    if (strDeptCode == "10220")
                    {
                        if (ds.Tables[1].Rows.Count < 1)
                        {
                            MessageBox.Show("중분류 [ " + strMid + " ] 는 소분류 선택이 필수인 항목입니다.", "소분류 선택", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }


                DataRow[] dRow_B = ds.Tables[0].Select("SUBCLASSESSEN = 'B'");
                if (dRow_B.Length > 0)
                {
                    string strMid = string.Empty;
                    for (int i = 0; i < dRow_B.Length; i++)
                    {
                        strMid += dRow_B[i]["VOCNAME"].ToString();
                        if (i < dRow_B.Length - 1)
                        {
                            strMid += strMid + ", ";
                        }
                    }

                    if (strUserID == strProUser)
                    {
                        if (ds.Tables[2].Rows.Count < 1)
                        {
                            MessageBox.Show("중분류 [ " + strMid + " ] 는 소분류 선택이 필수인 항목입니다.\n소분류를 선택해주세요.", "소분류 선택", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_PROCESS_SAVE_SDH";
            
            db.Procedure.ParamAdd("@PROMEMO1", mePro_Memo1.Text);
            db.Procedure.ParamAdd("@PROUSER", strUserID);
            db.Procedure.ParamAdd("@PRODEPT", strDeptCode);
            db.Procedure.ParamAdd("@PROSTATE", luePro_State.EditValue.ToString());
            db.Procedure.ParamAdd("@RegNum", strRegNum);
            db.Procedure.ParamAdd("@VCNO", strVCNO);
            db.Procedure.ParamAdd("@VCTP", strVCTP.Trim());
           
            
            try
            {
                DataSet ds = db.ProcedureToDataSet();
                MessageBox.Show("저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region 카테고리 변경 버튼 클릭 ★★★★★★★★★★★★
        private void btnCate_Change_Click(object sender, EventArgs e)
        {
            Object ob_Roll;
            Cesco.FW.Global.DBAdapter.DBAdapters db_Roll = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db_Roll.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_USERGUBUN";
            db_Roll.Procedure.ParamAdd("@USERID", strUserID);

            try
            {
                ob_Roll = db_Roll.ProcedureToScalar();
                if (Convert.ToString(ob_Roll) == "N")
                {
                    MessageBox.Show("팀장만 변경할 수 있습니다.", "변경 불가", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
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

            if (lueCall_BigCate.EditValue == "" || lueCall_BigCate.EditValue == null)
            {
                MessageBox.Show("대분류를 먼저 선택해주세요.", "대분류 미선택", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lueCall_BigCate.Focus();
                return;
            }

            string strRegDate = deRecei_Date.Text.Replace("-", "").Replace("-", "");
            string strRegUserID = teRecei_UserID.Text;
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
            //db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_CATEGORY_SELECT";
            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_CATEGORY_SELECT_SDH";
            db.Procedure.ParamAdd("@RegNum", strRegNum);
            db.Procedure.ParamAdd("@VCNO", strVCNO);
      
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
                /*세스넷 2.0 탭 호출*/

                try
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
                    int iFormWidth = 1150;
                    int iFormHeight = 750;
                    string MenuName = "고객정보열람";
                    //string sFilePath = "NSIM.MasterMgmt.dll";
                    //string sNameSpace = "NSIM.MasterMgmt.ClientInfo";
                    //string sClass = "ClientInfoView";
                    string sParam = teCustCode.Text;
                    string startPath = Application.StartupPath;
                    string sPath = startPath + @"\NSIMNew\NSIM.MasterMgmt.dll";
                    //string sPath = "C:/Program Files/CESNET2.0/NSIMNew/NSIM.MasterMgmt.dll";

                    CES.FUNCTION.CESAssembly cesAssem = new CES.FUNCTION.CESAssembly();
                    object control = cesAssem.LoadAssembly(sPath, "NSIM.MasterMgmt.ClientInfo.ClientInfoView", args);

                    System.Reflection.Assembly assem = System.Reflection.Assembly.LoadFrom(startPath + @"\NSIMNew\NSIM.MasterMgmt.dll");

                    //System.Reflection.Assembly assem = System.Reflection.Assembly.LoadFrom("C:/Program Files/CESNET2.0/NSIMNew/NSIM.MasterMgmt.dll");
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
                catch (Exception ex)
                {
                    MessageBox.Show("오류 : " + ex.Message.ToString(), "오류!");
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
 


            }
        }
        #endregion

        #region SMS 보내기 ★★★★★★★★★★★★★★
        private void sendSMS(string strSendUserID, string strSendDeptCode, string strSendCustCode)
        {
            CCM_SMS.CCM_SMS_MAIN cs = new CCM_SMS.CCM_SMS_MAIN(strUserID, strDeptCode, "", strSendCustCode, strSendUserID, strSendDeptCode, "2", strInsertAuth, strUpdateAuth, strDeleteAuth, strSearchAuth, strPrintAuth, strExcelAuth, strDataAuth, meReceiMemo.Text);
            //cs.Contents = meReceiMemo.Text;
            cs.Show();
        }

        private void btnSMS1_Click(object sender, EventArgs e)
        {
            sendSMS(lueDistr_Work_User.EditValue.ToString(), lueDistr_Work_Dept.EditValue.ToString(), teCustCode.Text);
        }

        //private void btnSMS2_Click(object sender, EventArgs e)
        //{
        //    sendSMS(lueDistr_Part_User.EditValue.ToString(), lueDistr_Part_Dept.EditValue.ToString(), teCustCode.Text);
        //}

        //private void btnSMS3_Click(object sender, EventArgs e)
        //{
        //    sendSMS(lueDistr_Team_User.EditValue.ToString(), lueDistr_Team_Dept.EditValue.ToString(), teCustCode.Text);
        //}
        #endregion

        private void btnSave_Dist_Click(object sender, EventArgs e)
        {

            if (luePro_State.EditValue.ToString() == "RY01")
            {
                MessageBox.Show("이미 처리완료된 접수입니다.", "변경 불가", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            Object ob_Roll;
            Cesco.FW.Global.DBAdapter.DBAdapters db_Roll = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db_Roll.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_USERGUBUN";
            db_Roll.Procedure.ParamAdd("@USERID", strUserID);
       
            try
            {
                ob_Roll = db_Roll.ProcedureToScalar();
                if (Convert.ToString(ob_Roll) == "N")
                {
                    MessageBox.Show("팀장만 변경할 수 있습니다.", "변경 불가", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
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

            save1();

            MessageBox.Show("처리담당자가 변경되었습니다.", "처리담당자 저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void save1()
        {
          
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_WORK_DISTR_SDH";
            db.Procedure.ParamAdd("@WORK_USERID", lueDistr_Work_User2.EditValue);
            db.Procedure.ParamAdd("@WORK_DEPTCODE", lueDistr_Work_Dept2.EditValue);
            db.Procedure.ParamAdd("@RegNum", strRegNum);
            db.Procedure.ParamAdd("@VCNO", strVCNO);
            db.Procedure.ParamAdd("@VCTP", strVCTP.Trim());
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
        }


        //private void btnImageView_Click(object sender, EventArgs e)
        //{
        //    VOC_FrmImageView FI = new VOC_FrmImageView();
        //    FI.StartPosition = FormStartPosition.CenterParent;
        //    FI.ShowDialog();
        //}

        //private void btnMemoView_Click(object sender, EventArgs e)
        //{
        //    VOC_FrmMemoView FM = new VOC_FrmMemoView();
        //    FM.StartPosition = FormStartPosition.CenterParent;
        //    FM.ShowDialog();
        //}

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string strClaimNum = string.Empty;
            strClaimNum = teCate_ClaimNum.Text;
            VOC_VoluntaryReport VR = new VOC_VoluntaryReport(strUserID, strCustCode, strClaimNum);
            VR.StartPosition = FormStartPosition.CenterParent;
            if(VR.strYN != "N")
                VR.ShowDialog();

        }

        private void luePro_State_EditValueChanged(object sender, EventArgs e)
        {
         
            //if (luePro_State.EditValue.ToString() == "RY01")
            //{
            //    dePro_Date.Enabled = true;
             
            //}
            //else
            //{
            //    dePro_Date.Enabled = false;
               
            //}
        }

        private void gv1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            me_List.Text = gv1.GetFocusedRowCellValue("처리내용").ToString();
        }

        private void btnProcMemo2_Save_Click(object sender, EventArgs e)
        {

            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_PROCESS_SAVE_SDH";

            db.Procedure.ParamAdd("@PROMEMO1", mePro_Memo2.Text);
            db.Procedure.ParamAdd("@PROUSER", strUserID);
            db.Procedure.ParamAdd("@PRODEPT", strDeptCode);
            db.Procedure.ParamAdd("@PROSTATE", "RY09");
            db.Procedure.ParamAdd("@RegNum", strRegNum);
            db.Procedure.ParamAdd("@VCNO", strVCNO);
            db.Procedure.ParamAdd("@VCTP", strVCTP.Trim());


            try
            {
                DataSet ds = db.ProcedureToDataSet();
                MessageBox.Show("저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getDTCustWork();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void btnDept_Click(object sender, EventArgs e)
        //{
        //    MakeCall(teCall_TellNum.Text); 
        //}

        //private void btnStaff_Click(object sender, EventArgs e)
        //{
        //    MakeCall(teCall_CellNum.Text); 
        //}

        //#region MakeCall  - 전화걸기
        ////-----------------------------------------------------------------------------------------------------------------------
        //// MakeCall  - 전화걸기
        //// Description : 상담 APP에서 전화걸기를 시도하는 요청전문
        //public void MakeCall(string strTransTelNum)
        //{
        //    try
        //    {
        //        string strTelNumber;         //전화번호
        //        long longResult;
        //        string strCTIMsg;

        //        //전화번호 정의
        //        strTelNumber = strTransTelNum.Replace("-", "").Trim();


        //        //---------------------------------------------------------------------------------------------------------------------
        //        // 전화걸기 전문 작성
        //        strCTIMsg = "";
        //        strCTIMsg = strCTIMsg + "00029";                                                    //전문길이         (5)
        //        strCTIMsg = strCTIMsg + "0117";                                                     //전문번호:0117   (4)
        //        strCTIMsg = strCTIMsg + strTelNumber + " ".PadRight(20 - strTelNumber.Length);      //내선번호         (20)


        //        //---------------------------------------------------------------------------------------------------------------------
        //        // 전화걸기 요청
        //        // FrmCCMMain.OcxCTISoftPhone.SockSendMsg(strCTIMsg)
        //        // FrmCCMMain.CTI_Sock.SendData (strCTIMsg)
        //        _SocketEvent(strCTIMsg);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}
        //#endregion


        //#region CTI Class 에서 Socket 관련 수신데이타를 CTI 로 전송하기 위한 처리
        //public void _SocketEvent(string strCTIMsg)
        //{
        //    CTI_OCXAppClient.SockSendMsg(strCTIMsg);

        //}
        //#endregion



    }
}
