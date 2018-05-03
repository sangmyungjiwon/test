using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing.Drawing2D;


namespace VOC_LIST
{
    public partial class VOC_TotalStateMng : DevExpress.XtraEditors.XtraUserControl
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
        string strGubun = string.Empty;
        string str본부 = string.Empty;
        string str지사 = string.Empty;
        string str파트 = string.Empty;


        Cesco.FW.Global.Util.Common.CesnetUserAuthInfo _cesnetUserInfo = new Cesco.FW.Global.Util.Common.CesnetUserAuthInfo();
        #endregion

        public VOC_TotalStateMng()
        {
            InitializeComponent();
        }
        public VOC_TotalStateMng(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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

        private void VOC_TotalStateMng_Load(object sender, EventArgs e)
        {
            setDateGubun();
            setDate();
            setLue(lueDept, 0, "", "부서코드", "부서명");
            lueDeptDetail.Visible = false;
            lueGubun_Detail.Enabled = false;
            lueDeptDetail.EditValue = "";
            lueDept.EditValue = "";
            setDept();

            setLueProb();
            rgVOC_A.Checked = true;
            lue_ProblemLv.EditValue = "1";
            lue_ProblemLv.Enabled = false;
        }
        /// <summary>
        /// 본부, 지사, 본사 셋팅
        /// </summary>
        private void setDept()
        {
            //본부이면 본부탭 & 해당 본부 셋팅
            if (strDeptCode.StartsWith("5"))
            {
                TabControl.SelectedTabPageIndex = 0;
                lueDept.EditValue = strDeptCode;
                lueDept.Enabled = false;
            }
            //지사이면 지사탭 & 해당 지사 셋팅
            else if (Convert.ToInt32(strDeptCode) >= 10280 && Convert.ToInt32(strDeptCode) < 19000)
            {
                xtraTabPage1.PageVisible = false;
                TabControl.SelectedTabPageIndex = 1;
                
                Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                db.Procedure.ProcedureName = "CESCOEIS.DBO.SP_VOC_DEPTSET_SELECT";
                db.Procedure.ParamAdd("@DeptCode", strDeptCode);
                try
                {
                    object obDeptCode = db.ProcedureToScalar();
                    lueDept.EditValue = obDeptCode;
                    lueDeptDetail.EditValue = strDeptCode;
                    lueDept.Enabled = false;
                    lueDeptDetail.Enabled = false;
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
            //본사이면 지사탭 & 해당 본사부서 셋팅
            else
            {
                xtraTabPage1.PageVisible = true;
                TabControl.SelectedTabPageIndex = 0;

                Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                db.Procedure.ProcedureName = "CESCOEIS.DBO.SP_VOC_DEPTSET_SELECT";
                db.Procedure.ParamAdd("@DeptCode", strDeptCode);

                try
                {
                    object obDeptCode = db.ProcedureToScalar();
                    lueDept.EditValue = obDeptCode;
                    lueDeptDetail.EditValue = strDeptCode;
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
        private void setDate()
        {
            DateTime mToday = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 01);

            string mToday_To = mToday.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"); 

            deDate_From.EditValue = mToday;
            deDate_To.EditValue = mToday_To;
        }

        private void setDateGubun()
        {
            DataTable dt_DateGubun = new DataTable();
            dt_DateGubun.Columns.Add("CODE");
            dt_DateGubun.Columns.Add("NAME");
            dt_DateGubun.Rows.Add("D", "일");
            dt_DateGubun.Rows.Add("W", "주");
            dt_DateGubun.Rows.Add("M", "월");
            dt_DateGubun.Rows.Add("P", "분기");
            dt_DateGubun.Rows.Add("B", "반기");

            lueDate_Gubun.Properties.ValueMember = "CODE";
            lueDate_Gubun.Properties.DisplayMember = "NAME";
            lueDate_Gubun.Properties.DataSource = dt_DateGubun;
        }

        private void lueDate_Gubun_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDate_Gubun.EditValue.ToString() == "D")
            {
                lueGubun_Detail.Enabled = false;
                deDate_To.EditValue = deDate_From.EditValue;
                
            }
            else if (lueDate_Gubun.EditValue.ToString() == "W")
            {
                lueGubun_Detail.Enabled = false;
                DateTime dt_To = deDate_From.DateTime.AddDays(+7);
                deDate_To.EditValue = dt_To;
            }
            else if (lueDate_Gubun.EditValue.ToString() == "M")
            {
                lueGubun_Detail.Enabled = false;
                DateTime dt_To = deDate_From.DateTime.AddMonths(1).AddDays(-1); 
                deDate_To.EditValue = dt_To;
            }
            else if (lueDate_Gubun.EditValue.ToString() == "P")
            {
                DataTable dt_DateGubun_Detail = new DataTable();
                dt_DateGubun_Detail.Columns.Add("CODE");
                dt_DateGubun_Detail.Columns.Add("NAME");
                dt_DateGubun_Detail.Rows.Add("Q1", "1분기");
                dt_DateGubun_Detail.Rows.Add("Q2", "2분기");
                dt_DateGubun_Detail.Rows.Add("Q3", "3분기");
                dt_DateGubun_Detail.Rows.Add("Q4", "4분기");

                lueGubun_Detail.Properties.ValueMember = "CODE";
                lueGubun_Detail.Properties.DisplayMember = "NAME";
                lueGubun_Detail.Properties.DataSource = dt_DateGubun_Detail;
                lueGubun_Detail.Enabled = true;
                lueGubun_Detail.EditValue = "Q1";

            }
            else
            {
                DataTable dt_DateGubun_Detail = new DataTable();
                dt_DateGubun_Detail.Columns.Add("CODE");
                dt_DateGubun_Detail.Columns.Add("NAME");
                dt_DateGubun_Detail.Rows.Add("SB", "상반기");
                dt_DateGubun_Detail.Rows.Add("HB", "하반기");

                lueGubun_Detail.Properties.ValueMember = "CODE";
                lueGubun_Detail.Properties.DisplayMember = "NAME";
                lueGubun_Detail.Properties.DataSource = dt_DateGubun_Detail;
                lueGubun_Detail.Enabled = true;
                lueGubun_Detail.EditValue = "SB";
            }
        }

        private void setLueProb()
        {
            DataTable dtCb = new DataTable();
            dtCb.Columns.Add("코드", typeof(string));
            dtCb.Columns.Add("선택");

            //DataRow dRowCust_0 = dtCb.NewRow();
            DataRow dRowCust_1 = dtCb.NewRow();
            DataRow dRowCust_2 = dtCb.NewRow();
            DataRow dRowCust_3 = dtCb.NewRow();

            //dRowCust_0["코드"] = "";
            //dRowCust_0["선택"] = "해당없음";
            dRowCust_1["코드"] = "1";
            dRowCust_1["선택"] = "레벨1";
            dRowCust_2["코드"] = "2";
            dRowCust_2["선택"] = "레벨2";
            dRowCust_3["코드"] = "3";
            dRowCust_3["선택"] = "레벨3";

            //dtCb.Rows.Add(dRowCust_0);
            dtCb.Rows.Add(dRowCust_1);
            dtCb.Rows.Add(dRowCust_2);
            dtCb.Rows.Add(dRowCust_3);

            lue_ProblemLv.Properties.DisplayMember = "선택";
            lue_ProblemLv.Properties.ValueMember = "코드";
            lue_ProblemLv.Properties.DataSource = dtCb;
        }


        private void setLue(LookUpEdit lueNm, int i, string paramValue, string valMem, string disMem)
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESNET2.dbo.SP_DEPT_ALL";
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

        private void setStateList()
        {
            if (TabControl.SelectedTabPageIndex == 0)
            {
                Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                db.BindingConfig.CloseTimeout = new TimeSpan(0, 30, 0);
                db.BindingConfig.SendTimeout = new TimeSpan(0, 30, 0);
                db.BindingConfig.TimeOut = Cesco.FW.Global.DBAdapter.ConfigurationDetail.TimeOuts.MINUTE10;
                db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_TotalStateMng_SELECT_MULTI"; //SP_VOC_TotalStateMng_SELECT_MULTI
                db.Procedure.ParamAdd("@DATE_FROM", deDate_From.Text.Replace("-", ""));
                db.Procedure.ParamAdd("@DATE_TO", deDate_To.Text.Replace("-", ""));
                db.Procedure.ParamAdd("@DEPTCODE", lueDept.EditValue == null ? "" : lueDept.EditValue);
                //db.Procedure.ParamAdd("@VOC", rgVOC1.EditValue);
                db.Procedure.ParamAdd("@VOC", rgVOC_A.Checked == true ? "A" : "P");
                db.Procedure.ParamAdd("@PROBLEMLV",  rgVOC_A.Checked == true ? "" : lue_ProblemLv.EditValue.ToString());

                try
                {
                    DataSet ds = db.ProcedureToDataSet();

                    if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                    {
                        XtraMessageBox.Show("조회된 데이터가 없습니다.");
                        return;
                    }
                    gc_ProcState_All.DataSource = ds.Tables[0];
                    gc_ProcState_Dist.DataSource = ds.Tables[1];
                    gc_DelayState_All.DataSource = ds.Tables[2];
                    gc_DelayState_Dist.DataSource = ds.Tables[3];

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
            else if (TabControl.SelectedTabPageIndex == 1)
            {
                setPage1();
            }
            else if (TabControl.SelectedTabPageIndex == 2)
            {
                setPage2();
            }
            else 
            {
                setPage3();
            }
        }


        private void deDate_From_EditValueChanged(object sender, EventArgs e)
        {
            if(lueDate_Gubun.EditValue != null)
            {
                if (lueDate_Gubun.EditValue.ToString() == "D")
                {
                    deDate_To.EditValue = deDate_From.EditValue;
                }
                else if (lueDate_Gubun.EditValue.ToString() == "W")
                {
                    DateTime dt_To = deDate_From.DateTime.AddDays(+7);
                    deDate_To.EditValue = dt_To;
                }
                else if (lueDate_Gubun.EditValue.ToString() == "M")
                {
                    DateTime dt_To = deDate_From.DateTime.AddMonths(1).AddDays(-1); 
                    deDate_To.EditValue = dt_To;
                }
            }
        }

        #region 본부클릭


        private void gv_ProcState_Dist_DoubleClick(object sender, EventArgs e)
        {
            if (gv_ProcState_Dist.FocusedColumn == bandedGridColumn8)
            {
                str본부 = gv_ProcState_Dist.GetFocusedRowCellValue("부서코드").ToString();
                TabControl.SelectedTabPageIndex = 1;
                lueDept.EditValue = str본부;
                setPage1();
            }
            else if (gv_ProcState_Dist.FocusedColumn == bandedGridColumn10 || gv_ProcState_Dist.FocusedColumn == bandedGridColumn11
                  || gv_ProcState_Dist.FocusedColumn == bandedGridColumn12 || gv_ProcState_Dist.FocusedColumn == bandedGridColumn13 || gv_ProcState_Dist.FocusedColumn == bandedGridColumn164)
            {
                string strDist = gv_ProcState_Dist.GetFocusedRowCellValue("부서코드").ToString();
                string strState = gv_ProcState_Dist.FocusedColumn.Caption;
                string strVOC_Prob = lue_ProblemLv.EditValue.ToString();
                string strStateCode = string.Empty;
                
                if (strState == "미확인")
                {
                    strStateCode = "미확인";
                }
                else if (strState == "확인")
                {
                    strStateCode = "확인";
                }
                else if (strState == "고객접촉완료")
                {
                    strStateCode = "고객접촉완료";
                }
                else if (strState == "미처리전체")
                {
                    strStateCode = "미처리전체";
                }
                else
                {
                    strStateCode = "처리완료";
                }
                VOC_Form VF = new VOC_Form(strUserID, strDeptCode, strDist, strStateCode, deDate_From.Text, deDate_To.Text, rgVOC_A.Checked == true ? "A" : "P", "", "", "", "", strVOC_Prob);
                VF.StartPosition = FormStartPosition.CenterParent;
                VF.Show();
            }
        }

        private void gv_DelayState_Dist_DoubleClick(object sender, EventArgs e)
        {
            if (gv_DelayState_Dist.FocusedColumn == bandedGridColumn90)
            {
                str본부 = gv_DelayState_Dist.GetFocusedRowCellValue("부서코드").ToString();
                TabControl.SelectedTabPageIndex = 1;
                setPage1();
            }
            else if (gv_DelayState_Dist.FocusedColumn == bandedGridColumn92 || gv_DelayState_Dist.FocusedColumn == bandedGridColumn93 ||
                gv_DelayState_Dist.FocusedColumn == bandedGridColumn94 || gv_DelayState_Dist.FocusedColumn == bandedGridColumn95 ||
                gv_DelayState_Dist.FocusedColumn == bandedGridColumn96 || gv_DelayState_Dist.FocusedColumn == bandedGridColumn97 || 
                gv_DelayState_Dist.FocusedColumn == bandedGridColumn98)
            {
                string strMonitoring = string.Empty;
                if (gv_DelayState_Dist.FocusedColumn == bandedGridColumn92) //20분 지연
                    strMonitoring = "0";
                else if (gv_DelayState_Dist.FocusedColumn == bandedGridColumn93) //1시간 지연
                    strMonitoring = "6";
                else if (gv_DelayState_Dist.FocusedColumn == bandedGridColumn95) //1차
                    strMonitoring = "7";
                else if (gv_DelayState_Dist.FocusedColumn == bandedGridColumn96) //2차
                    strMonitoring = "5";
                else if (gv_DelayState_Dist.FocusedColumn == bandedGridColumn97) //3차
                    strMonitoring = "3";
                else if (gv_DelayState_Dist.FocusedColumn == bandedGridColumn98) //4차
                    strMonitoring = "4";


                string strDist = gv_DelayState_Dist.GetFocusedRowCellValue("부서코드").ToString();
                string strState = gv_DelayState_Dist.FocusedColumn.Caption;
                string strStateCode = string.Empty;
                string strVOC_Prob = lue_ProblemLv.EditValue.ToString();

                if (strState == "미처리전체")
                {
                    strStateCode = "고객접촉지연";
                }
                else
                {
                    strStateCode = "";
                }

                VOC_Form VF = new VOC_Form(strUserID, strDeptCode, strDist, strStateCode, deDate_From.Text, deDate_To.Text, rgVOC_A.Checked == true ? "A" : "P", "", "", "", strMonitoring, strVOC_Prob);
                VF.StartPosition = FormStartPosition.CenterParent;
                VF.Show();
            }
        }
        #endregion

        #region 부서클릭

        private void gv_ProcState_Dist_Detail_DoubleClick(object sender, EventArgs e)
        {
            if (gv_ProcState_Dist_Detail.FocusedColumn == bandedGridColumn43)
            {
                strGubun = "A5";
                if (gv_ProcState_Dist_Detail.GetFocusedRowCellValue("지사구분").ToString() == "A1")
                {
                    str파트 = gv_ProcState_Dist_Detail.GetFocusedRowCellValue("부서코드").ToString();
                    lueDeptDetail.EditValue = str파트;
                    strGubun = "A1";
                    TabControl.SelectedTabPageIndex = 3;
                    setPage3();
                }
                else
                {
                    str지사 = gv_ProcState_Dist_Detail.GetFocusedRowCellValue("부서코드").ToString();
                    lueDeptDetail.EditValue = str지사;
                    TabControl.SelectedTabPageIndex = 2;
                    setPage2();
                }
            }
            else if (gv_ProcState_Dist_Detail.FocusedColumn == bandedGridColumn31 || gv_ProcState_Dist_Detail.FocusedColumn == bandedGridColumn32
                 || gv_ProcState_Dist_Detail.FocusedColumn == bandedGridColumn33 || gv_ProcState_Dist_Detail.FocusedColumn == bandedGridColumn34 || gv_ProcState_Dist_Detail.FocusedColumn == bandedGridColumn167)
            {
                string strDist = gv_ProcState_Dist_Detail.GetFocusedRowCellValue("부서코드").ToString();
                string strState = gv_ProcState_Dist_Detail.FocusedColumn.Caption;
                string strStateCode = string.Empty;
                string strVOC_Prob = lue_ProblemLv.EditValue.ToString();

                if (strState == "미확인")
                {
                    strStateCode = "미확인";
                }
                else if (strState == "확인")
                {
                    strStateCode = "확인";
                }
                else if (strState == "고객접촉완료")
                {
                    strStateCode = "고객접촉완료";
                }
                else if (strState == "미처리전체")
                {
                    strStateCode = "미처리전체";
                }
                else
                {
                    strStateCode = "처리완료";
                }
                VOC_Form VF = new VOC_Form(strUserID, strDeptCode, strDist, strStateCode, deDate_From.Text, deDate_To.Text, rgVOC_A.Checked == true ? "A" : "P", "", "", "", "", strVOC_Prob);
                VF.StartPosition = FormStartPosition.CenterParent;
                VF.Show();
            }
        }

        private void gv_DelayState_Dist_Detail_DoubleClick(object sender, EventArgs e)
        {
            if (gv_DelayState_Dist_Detail.FocusedColumn == bandedGridColumn108)
            {
                strGubun = "A5";
                if (gv_DelayState_Dist_Detail.GetFocusedRowCellValue("지사구분").ToString() == "A1")
                {
                    str파트 = gv_DelayState_Dist_Detail.GetFocusedRowCellValue("부서코드").ToString();
                    lueDeptDetail.EditValue = str파트;
                    strGubun = "A1";
                    TabControl.SelectedTabPageIndex = 3;
                    setPage3();
                }
                else
                {
                    str지사 = gv_DelayState_Dist_Detail.GetFocusedRowCellValue("부서코드").ToString();
                    lueDeptDetail.EditValue = str지사;
                    TabControl.SelectedTabPageIndex = 2;
                    setPage2();
                }
            }
            else if (gv_DelayState_Dist_Detail.FocusedColumn == bandedGridColumn109 || gv_DelayState_Dist_Detail.FocusedColumn == bandedGridColumn110 ||
               gv_DelayState_Dist_Detail.FocusedColumn == bandedGridColumn111 || gv_DelayState_Dist_Detail.FocusedColumn == bandedGridColumn112 ||
               gv_DelayState_Dist_Detail.FocusedColumn == bandedGridColumn113 || gv_DelayState_Dist_Detail.FocusedColumn == bandedGridColumn114 ||
               gv_DelayState_Dist_Detail.FocusedColumn == bandedGridColumn115)
            {
                string strMonitoring = string.Empty;
                if (gv_DelayState_Dist_Detail.FocusedColumn == bandedGridColumn109) //20분 지연
                    strMonitoring = "0";
                else if (gv_DelayState_Dist_Detail.FocusedColumn == bandedGridColumn110) //1시간 지연
                    strMonitoring = "6";
                else if (gv_DelayState_Dist_Detail.FocusedColumn == bandedGridColumn112) //1차
                    strMonitoring = "7";
                else if (gv_DelayState_Dist_Detail.FocusedColumn == bandedGridColumn113) //2차
                    strMonitoring = "5";
                else if (gv_DelayState_Dist_Detail.FocusedColumn == bandedGridColumn114) //3차
                    strMonitoring = "3";
                else if (gv_DelayState_Dist_Detail.FocusedColumn == bandedGridColumn115) //4차
                    strMonitoring = "4";


                string strDist = gv_DelayState_Dist_Detail.GetFocusedRowCellValue("부서코드").ToString();
                string strState = gv_DelayState_Dist_Detail.FocusedColumn.Caption;
                string strVOC_Prob = lue_ProblemLv.EditValue.ToString();
                string strStateCode = string.Empty;
                if (strState == "미처리전체")
                {
                    strStateCode = "고객접촉지연";
                }
                else
                {
                    strStateCode = "";
                }

                VOC_Form VF = new VOC_Form(strUserID, strDeptCode, strDist, strStateCode, deDate_From.Text, deDate_To.Text, rgVOC_A.Checked == true ? "A" : "P", "", "", "", strMonitoring, strVOC_Prob);
                VF.StartPosition = FormStartPosition.CenterParent;
                VF.Show();
            }
        }
        #endregion

        #region 파트클릭
      
        private void gv_ProcState_Part_Detail_DoubleClick(object sender, EventArgs e)
        {
            if (gv_ProcState_Part_Detail.FocusedColumn == bandedGridColumn52)
            {
                str파트 = gv_ProcState_Part_Detail.GetFocusedRowCellValue("파트코드").ToString();
                TabControl.SelectedTabPageIndex = 3;
                setPage3();
            }
            if (gv_ProcState_Part_Detail.FocusedColumn == bandedGridColumn54 || gv_ProcState_Part_Detail.FocusedColumn == bandedGridColumn55
                 || gv_ProcState_Part_Detail.FocusedColumn == bandedGridColumn56 || gv_ProcState_Part_Detail.FocusedColumn == bandedGridColumn57 || gv_ProcState_Part_Detail.FocusedColumn == bandedGridColumn169)
            {
                string strDist = gv_ProcState_Part_Detail.GetFocusedRowCellValue("파트명").ToString();
                string strUser_Part = gv_ProcState_Part_Detail.GetFocusedRowCellValue("파트코드").ToString(); //사번
                string strDist_Proc = gv_ProcState_Part_Detail.GetFocusedRowCellValue("부서코드").ToString(); //부서코드
                string strState = gv_ProcState_Part_Detail.FocusedColumn.Caption;
                string strStateCode = string.Empty;
                string strVOC_Prob = lue_ProblemLv.EditValue.ToString();

                if (strState == "미확인")
                {
                    strStateCode = "미확인";
                }
                else if (strState == "확인")
                {
                    strStateCode = "확인";
                }
                else if (strState == "고객접촉완료")
                {
                    strStateCode = "고객접촉완료";
                }
                else if (strState == "미처리전체")
                {
                    strStateCode = "미처리전체";
                }
                else
                {
                    strStateCode = "처리완료";
                }
                VOC_Form VF = new VOC_Form(strUserID, strDeptCode, strDist, strStateCode, deDate_From.Text, deDate_To.Text, rgVOC_A.Checked == true ? "A" : "P", "", strDist_Proc, strUser_Part, "", strVOC_Prob);
                VF.StartPosition = FormStartPosition.CenterParent;
                VF.Show();
            }
        }

        private void gv_DelayState_Part_Detail_DoubleClick(object sender, EventArgs e)
        {
            if (gv_DelayState_Part_Detail.FocusedColumn == bandedGridColumn126)
            {
                str파트 = gv_DelayState_Part_Detail.GetFocusedRowCellValue("파트코드").ToString();
                TabControl.SelectedTabPageIndex = 3;
                setPage3();
            }
            else if (gv_DelayState_Part_Detail.FocusedColumn == bandedGridColumn127 || gv_DelayState_Part_Detail.FocusedColumn == bandedGridColumn128 ||
              gv_DelayState_Part_Detail.FocusedColumn == bandedGridColumn129 || gv_DelayState_Part_Detail.FocusedColumn == bandedGridColumn130 ||
              gv_DelayState_Part_Detail.FocusedColumn == bandedGridColumn131 || gv_DelayState_Part_Detail.FocusedColumn == bandedGridColumn132 ||
              gv_DelayState_Part_Detail.FocusedColumn == bandedGridColumn133)
            {
                string strMonitoring = string.Empty;
                if (gv_DelayState_Part_Detail.FocusedColumn == bandedGridColumn127) //20분 지연
                    strMonitoring = "0";
                else if (gv_DelayState_Part_Detail.FocusedColumn == bandedGridColumn128) //1시간 지연
                    strMonitoring = "6";
                else if (gv_DelayState_Part_Detail.FocusedColumn == bandedGridColumn130) //1차
                    strMonitoring = "7";
                else if (gv_DelayState_Part_Detail.FocusedColumn == bandedGridColumn131) //2차
                    strMonitoring = "5";
                else if (gv_DelayState_Part_Detail.FocusedColumn == bandedGridColumn132) //3차
                    strMonitoring = "3";
                else if (gv_DelayState_Part_Detail.FocusedColumn == bandedGridColumn133) //4차
                    strMonitoring = "4";


                string strDist = gv_DelayState_Part_Detail.GetFocusedRowCellValue("파트명").ToString();
                string strUser_Part = gv_DelayState_Part_Detail.GetFocusedRowCellValue("파트코드").ToString(); //사번
                string strDist_Proc = gv_DelayState_Part_Detail.GetFocusedRowCellValue("부서코드").ToString(); //부서코드
                string strState = gv_DelayState_Part_Detail.FocusedColumn.Caption;
                string strStateCode = string.Empty;
                string strVOC_Prob = lue_ProblemLv.EditValue.ToString();

                if (strState == "미처리전체")
                {
                    strStateCode = "고객접촉지연";
                }
                else
                {
                    strStateCode = "";
                }
                VOC_Form VF = new VOC_Form(strUserID, strDeptCode, strDist, strStateCode, deDate_From.Text, deDate_To.Text, rgVOC_A.Checked == true ? "A" : "P", "", strDist_Proc, strUser_Part, strMonitoring, strVOC_Prob);
                VF.StartPosition = FormStartPosition.CenterParent;
                VF.Show();
            }
        }

        #endregion


        private void setPage1() //지사별
        {
            gc_ProcState_Dist_All.DataSource = null;
            gc_ProcState_Dist_Detail.DataSource = null;
            gc_DelayState_Dist_All.DataSource = null;
            gc_DelayState_Dist_Detail.DataSource = null;

            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_TotalStateMng_Dist_SELECT_MULTI"; //SP_VOC_TotalStateMng_Dist_SELECT_MULTI
            db.Procedure.ParamAdd("@DATE_FROM", deDate_From.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@DATE_TO", deDate_To.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@DEPTCODE", lueDept.EditValue);
            db.Procedure.ParamAdd("@DEPT_DETAILCODE", lueDeptDetail.EditValue);
            db.Procedure.ParamAdd("@VOC", rgVOC_A.Checked == true ? "A" : "P");
            db.Procedure.ParamAdd("@PROBLEMLV", rgVOC_A.Checked == true ? "" : lue_ProblemLv.EditValue.ToString());

            try
            {
                DataSet ds = db.ProcedureToDataSet();

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    return;
                }
                gc_ProcState_Dist_All.DataSource = ds.Tables[0];
                gc_ProcState_Dist_Detail.DataSource = ds.Tables[1];
                gc_DelayState_Dist_All.DataSource = ds.Tables[2];
                gc_DelayState_Dist_Detail.DataSource = ds.Tables[3];

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

        private void setPage2() //파트별
        {
            gc_ProcState_DistDetail_All.DataSource = null;
            gc_ProcState_Part_Detail.DataSource = null;
            gc_DelayState_DistDetail_All.DataSource = null;
            gc_DelayState_Part_Detail.DataSource = null;

            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_TotalStateMng_Part_SELECT_MULTI"; //★★★ N 분의 1 추가 SP_VOC_TotalStateMng_Part_SELECT_MULTI
            db.Procedure.ParamAdd("@DATE_FROM", deDate_From.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@DATE_TO", deDate_To.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@DEPTCODE", lueDeptDetail.EditValue);
            db.Procedure.ParamAdd("@VOC", rgVOC_A.Checked == true ? "A" : "P");
            db.Procedure.ParamAdd("@PROBLEMLV", rgVOC_A.Checked == true ? "" : lue_ProblemLv.EditValue.ToString());

            try
            {
                DataSet ds = db.ProcedureToDataSet();

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    return;
                }
                gc_ProcState_DistDetail_All.DataSource = ds.Tables[0];
                gc_ProcState_Part_Detail.DataSource = ds.Tables[1];
                gc_DelayState_DistDetail_All.DataSource = ds.Tables[2];
                gc_DelayState_Part_Detail.DataSource = ds.Tables[3];

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

        private void setPage3() //개인별
        {
            gc_ProcState_Part_All.DataSource = null;
            gc_ProcState_User_Detail.DataSource = null;
            gc_DelayState_Part_All.DataSource = null;
            gc_DelayState_User_Detail.DataSource = null;
            if (strGubun == "A1")
            {
                bandedGridColumn74.Caption = "부서";
                bandedGridColumn136.Caption = "부서";
                bandedGridColumn66.Caption = "부서";
                bandedGridColumn146.Caption = "부서";
                Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

                db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_TotalStateMng_A1User_SELECT_MULTI";  //★★★ N 분의 1 추가 SP_VOC_TotalStateMng_A1User_SELECT_MULTI
                db.Procedure.ParamAdd("@DATE_FROM", deDate_From.Text.Replace("-", ""));
                db.Procedure.ParamAdd("@DATE_TO", deDate_To.Text.Replace("-", ""));
                db.Procedure.ParamAdd("@DEPTCODE", str파트);
                db.Procedure.ParamAdd("@VOC", rgVOC_A.Checked == true ? "A" : "P");
                db.Procedure.ParamAdd("@PROBLEMLV", rgVOC_A.Checked == true ? "" : lue_ProblemLv.EditValue.ToString());
                db.Procedure.ParamAdd("@HEADCODE", lueDept.EditValue.ToString());

                try
                {
                    gc_ProcState_Part_All.DataSource = null;
                    gc_ProcState_User_Detail.DataSource = null;
                    gc_DelayState_Part_All.DataSource = null;
                    gc_DelayState_User_Detail.DataSource = null;

                    DataSet ds = db.ProcedureToDataSet();

                    if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                    {
                        return;
                    }
                    gc_ProcState_Part_All.DataSource = ds.Tables[0];
                    gc_ProcState_User_Detail.DataSource = ds.Tables[1];
                    gc_DelayState_Part_All.DataSource = ds.Tables[2];
                    gc_DelayState_User_Detail.DataSource = ds.Tables[3];
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
            else
            {
                bandedGridColumn74.Caption = "파트";
                bandedGridColumn136.Caption = "파트";
                bandedGridColumn66.Caption = "파트";
                bandedGridColumn146.Caption = "파트";
                Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

                db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_TotalStateMng_User_SELECT_MULTI";  //★★★ N 분의 1 추가 SP_VOC_TotalStateMng_User_SELECT_MULTI
                db.Procedure.ParamAdd("@DATE_FROM", deDate_From.Text.Replace("-", ""));
                db.Procedure.ParamAdd("@DATE_TO", deDate_To.Text.Replace("-", ""));
                db.Procedure.ParamAdd("@DEPTCODE", lueDeptDetail.EditValue.ToString());
                db.Procedure.ParamAdd("@PARTCODE", str파트);
                db.Procedure.ParamAdd("@VOC", rgVOC_A.Checked == true ? "A" : "P");
                db.Procedure.ParamAdd("@PROBLEMLV", rgVOC_A.Checked == true ? "" : lue_ProblemLv.EditValue.ToString());
                db.Procedure.ParamAdd("@HEADCODE", lueDept.EditValue.ToString());

                try
                {
                    gc_ProcState_Part_All.DataSource = null;
                    gc_ProcState_User_Detail.DataSource = null;
                    gc_DelayState_Part_All.DataSource = null;
                    gc_DelayState_User_Detail.DataSource = null;

                    DataSet ds = db.ProcedureToDataSet();

                    if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                    {
                        return;
                    }
                    gc_ProcState_Part_All.DataSource = ds.Tables[0];
                    gc_ProcState_User_Detail.DataSource = ds.Tables[1];
                    gc_DelayState_Part_All.DataSource = ds.Tables[2];
                    gc_DelayState_User_Detail.DataSource = ds.Tables[3];
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

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            setStateList();
            this.Cursor = Cursors.Default;
        }

        

        private void btn_C_Click(object sender, EventArgs e)
        {
            if (gc_ProcState_Dist.DataSource == null)
            {
                return;
            }
            string strDateFrom = deDate_From.Text;
            string strDateTo = deDate_To.Text;
            string strDept = lueDept.EditValue == null ? "" : lueDept.EditValue.ToString();
            string strGubun = lueDate_Gubun.EditValue == null ? "" : lueDate_Gubun.EditValue.ToString();
            string strGubun_Detail = lueGubun_Detail.EditValue == null ? "" : lueGubun_Detail.EditValue.ToString();
            string strVOC_Prob = lue_ProblemLv.EditValue.ToString();

            VOC_Form_Cate VF = new VOC_Form_Cate(strUserID, strDeptCode, strDateFrom, strDateTo, strDept, rgVOC_A.Checked == true ? "A" : "P", strGubun, strGubun_Detail, strVOC_Prob, "");
            VF.StartPosition = FormStartPosition.CenterParent;
            VF.Show();
        }

        private void lueGubun_Detail_EditValueChanged(object sender, EventArgs e)
        {
            string str_FromMonth = string.Empty;
            string str_ToDay = string.Empty;
            if (lueGubun_Detail.EditValue.ToString() == "Q1")
            {
                str_FromMonth = "01";
                str_ToDay = "03-31";
            }
            else if (lueGubun_Detail.EditValue.ToString() == "Q2")
            {
                str_FromMonth = "04";
                str_ToDay = "06-31";
            }
            else if (lueGubun_Detail.EditValue.ToString() == "Q3")
            {
                str_FromMonth = "07";
                str_ToDay = "09-30";
            }
            else if (lueGubun_Detail.EditValue.ToString() == "Q4")
            {
                str_FromMonth = "10";
                str_ToDay = "12-31";
            }
            else if (lueGubun_Detail.EditValue.ToString() == "SB")
            {
                str_FromMonth = "01";
                str_ToDay = "06-31";
            }
            else if (lueGubun_Detail.EditValue.ToString() == "HB")
            {
                str_FromMonth = "07";
                str_ToDay = "12-31";
            }

            deDate_From.Text = string.Format("{0}-{1}-01", DateTime.Today.Year, str_FromMonth);
            deDate_To.Text = string.Format("{0}-{1}", DateTime.Today.Year, str_ToDay);

        }

        private void TabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (TabControl.SelectedTabPageIndex == 0)
            {
                setLue(lueDept, 0, "", "부서코드", "부서명");
                //lueDept.EditValue = "";
                lueDeptDetail.Visible = false;

                if (strDeptCode.StartsWith("5"))
                {
                    lueDept.Enabled = false;
                    lueDeptDetail.Enabled = true;
                }
                else if(Convert.ToInt32(strDeptCode) >= 10280 && Convert.ToInt32(strDeptCode) < 19000)
                {
                    lueDept.Enabled = false;
                    lueDeptDetail.Enabled = false;
                }
                else
                {
                    lueDept.Enabled = true;
                    lueDeptDetail.Enabled = true;
                }
            }
            else if (TabControl.SelectedTabPageIndex == 1)
            {
                //lueDeptDetail.EditValue = "";
                lueDeptDetail.Visible = true;

                if (strDeptCode.StartsWith("5"))
                {
                    lueDept.Enabled = false;
                    lueDeptDetail.Enabled = true;
                }
                else if (Convert.ToInt32(strDeptCode) >= 10280 && Convert.ToInt32(strDeptCode) < 19000)
                {
                    lueDept.Enabled = false;
                    lueDeptDetail.Enabled = false;
                }
                else
                {
                    lueDept.Enabled = true;
                    lueDeptDetail.Enabled = true;
                }
            }
            else if (TabControl.SelectedTabPageIndex == 2)
            {

                lueDeptDetail.Visible = true;
                lueDept.Enabled = false;
                lueDeptDetail.Enabled = false;
            }
            else
            {
                lueDeptDetail.Visible = true;
                lueDept.Enabled = false;
                lueDeptDetail.Enabled = false;
            }
    
        }

        private void lueDept_EditValueChanged(object sender, EventArgs e)
        {
            setLue(lueDeptDetail, 1, lueDept.EditValue.ToString(), "부서코드", "부서명");
            lueDeptDetail.EditValue = "";
        }

        #region 비율 - footer 추가
        private void gv_ProcState_Dist_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            //var item = e.Item as Grid
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                e.TotalValue = gv_ProcState_All.GetFocusedRowCellDisplayText("비율");
            }
        }

        private void gv_ProcState_Dist_Detail_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                e.TotalValue = gv_ProcState_Dist_All.GetFocusedRowCellDisplayText("비율");
            }
        }

        private void gv_ProcState_Part_Detail_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                e.TotalValue = gv_ProcState_DistDetail_All.GetFocusedRowCellDisplayText("비율");
            }
        }

        private void gv_ProcState_User_Detail_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                e.TotalValue = gv_ProcState_Part_All.GetFocusedRowCellDisplayText("비율");
            }
        }

        #endregion


        #region 카테고리 버튼 클릭
        private void btn_C_Detail_Click(object sender, EventArgs e)
        {
            if (gc_ProcState_Dist_Detail.DataSource == null)
            {
                return;
            }
            string strDateFrom = deDate_From.Text;
            string strDateTo = deDate_To.Text;
            string strDept = lueDept.EditValue == null ? "" : lueDept.EditValue.ToString();
            string strDeptDetail = lueDeptDetail.EditValue == null ? "" : lueDeptDetail.EditValue.ToString();

            string strGubun = lueDate_Gubun.EditValue == null ? "" : lueDate_Gubun.EditValue.ToString();
            string strGubun_Detail = lueGubun_Detail.EditValue == null ? "" : lueGubun_Detail.EditValue.ToString();
            string strVOC_Prob = lue_ProblemLv.EditValue.ToString();

            VOC_Form_Cate_Detail VF = new VOC_Form_Cate_Detail(strUserID, strDeptCode, strDateFrom, strDateTo, strDept, rgVOC_A.Checked == true ? "A" : "P", strDeptDetail, "", "", "", strGubun, strGubun_Detail, strVOC_Prob);
            VF.StartPosition = FormStartPosition.CenterParent;
            VF.Show();
        }

        private void btn_C_Part_Click(object sender, EventArgs e)
        {
            if (gc_ProcState_Part_Detail.DataSource == null)
            {
                return;
            }
            string strDateFrom = deDate_From.Text.Replace("-", "");
            string strDateTo = deDate_To.Text.Replace("-", "");
            string strDept = lueDept.EditValue == null ? "" : lueDept.EditValue.ToString();
            string strDeptDetail = lueDeptDetail.EditValue == null ? "" : lueDeptDetail.EditValue.ToString();

            string strGubun = lueDate_Gubun.EditValue == null ? "" : lueDate_Gubun.EditValue.ToString();
            string strGubun_Detail = lueGubun_Detail.EditValue == null ? "" : lueGubun_Detail.EditValue.ToString();
            string strVOC_Prob = lue_ProblemLv.EditValue.ToString();

            VOC_Form_Cate_Detail VF = new VOC_Form_Cate_Detail(strUserID, strDeptCode, strDateFrom, strDateTo, strDept, rgVOC_A.Checked == true ? "A" : "P", strDeptDetail, "", "", "", strGubun, strGubun_Detail, strVOC_Prob);
            VF.StartPosition = FormStartPosition.CenterParent;
            VF.Show();
        }

        private void btn_C_User_Click(object sender, EventArgs e)
        {
            if (gc_ProcState_User_Detail.DataSource == null)
            {
                return;
            }
            string strDateFrom = deDate_From.Text.Replace("-", "");
            string strDateTo = deDate_To.Text.Replace("-", "");
            string strDept = lueDept.EditValue == null ? "" : lueDept.EditValue.ToString();
            string strDeptDetail = lueDeptDetail.EditValue == null ? "" : lueDeptDetail.EditValue.ToString();

            string strGubun = lueDate_Gubun.EditValue == null ? "" : lueDate_Gubun.EditValue.ToString();
            string strGubun_Detail = lueGubun_Detail.EditValue == null ? "" : lueGubun_Detail.EditValue.ToString();
            string strVOC_Prob = lue_ProblemLv.EditValue.ToString();

            VOC_Form_Cate_Detail VF = new VOC_Form_Cate_Detail(strUserID, strDeptCode, strDateFrom, strDateTo, strDept, rgVOC_A.Checked == true ? "A" : "P", strDeptDetail, "", "", "", strGubun, strGubun_Detail, strVOC_Prob);
            VF.StartPosition = FormStartPosition.CenterParent;
            VF.Show();
        }

        #endregion

      

        #region cell 색깔 넣기

        private void setColor(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            Color oColor = Color.FromArgb(235, 240, 255);
            Brush backBrush;
            backBrush = new LinearGradientBrush(e.Bounds, oColor, oColor,
                  LinearGradientMode.Vertical);
            // filling the background
            e.Graphics.FillRectangle(backBrush, e.Bounds);
        }


        private void gv_ProcState_Dist_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == bandedGridColumn10 || e.Column == bandedGridColumn11 || e.Column == bandedGridColumn12 || e.Column == bandedGridColumn13 || e.Column == bandedGridColumn164)
            {
                if (e.CellValue.ToString() != "0 (0%)")
                {
                    setColor(sender, e);
                }
            }
        }

        private void gv_DelayState_Dist_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == bandedGridColumn92 || e.Column == bandedGridColumn93 || e.Column == bandedGridColumn94 || e.Column == bandedGridColumn95
                || e.Column == bandedGridColumn96 || e.Column == bandedGridColumn97 || e.Column == bandedGridColumn98)
            {
                if (e.CellValue.ToString() != "0")
                {
                    setColor(sender, e);
                }
            }
        }
        private void gv_ProcState_Dist_Detail_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == bandedGridColumn31 || e.Column == bandedGridColumn32 || e.Column == bandedGridColumn33 || e.Column == bandedGridColumn34 || e.Column == bandedGridColumn167)
            {
                if (e.CellValue.ToString() != "0 (0%)")
                {
                    setColor(sender, e);
                }
            }
        }

        private void gv_DelayState_Dist_Detail_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == bandedGridColumn109 || e.Column == bandedGridColumn110 || e.Column == bandedGridColumn111 || e.Column == bandedGridColumn112
                 || e.Column == bandedGridColumn113 || e.Column == bandedGridColumn114 || e.Column == bandedGridColumn115)
            {
                if (e.CellValue.ToString() != "0")
                {
                    setColor(sender, e);
                }
            }
        }

        private void gv_ProcState_Part_Detail_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == bandedGridColumn54 || e.Column == bandedGridColumn55 || e.Column == bandedGridColumn56 || e.Column == bandedGridColumn57 || e.Column == bandedGridColumn169)
            {
                if (e.CellValue.ToString() != "0 (0%)")
                {
                    setColor(sender, e);
                }
            }
        }

        private void gv_DelayState_Part_Detail_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == bandedGridColumn127 || e.Column == bandedGridColumn128 || e.Column == bandedGridColumn129 || e.Column == bandedGridColumn130
                 || e.Column == bandedGridColumn131 || e.Column == bandedGridColumn132 || e.Column == bandedGridColumn133)
            {
                if (e.CellValue.ToString() != "0")
                {
                    setColor(sender, e);
                }
            }
        }

        private void gv_ProcState_User_Detail_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == bandedGridColumn75 || e.Column == bandedGridColumn76 || e.Column == bandedGridColumn77 || e.Column == bandedGridColumn78 || e.Column == bandedGridColumn171)
            {
                if (e.CellValue.ToString() != "0 (0%)")
                {
                    setColor(sender, e);
                }
            }
        }

        private void gv_DelayState_User_Detail_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == bandedGridColumn137 || e.Column == bandedGridColumn138 || e.Column == bandedGridColumn139 || e.Column == bandedGridColumn140
                || e.Column == bandedGridColumn141 || e.Column == bandedGridColumn142 || e.Column == bandedGridColumn143)
            {
                if (e.CellValue.ToString() != "0")
                {
                    setColor(sender, e);
                }
            }
        }
        #endregion

        #region 커서 변경

        private void gv_ProcState_Dist_MouseMove(object sender, MouseEventArgs e)
        {
            GridHitInfo hi = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));
            if (hi.Column == null)
            {
                return;
            }
            if (hi.Column == bandedGridColumn8 || hi.Column == bandedGridColumn10 || hi.Column == bandedGridColumn11
                || hi.Column == bandedGridColumn12 || hi.Column == bandedGridColumn13 || hi.Column == bandedGridColumn164)
            {
                Cursor = System.Windows.Forms.Cursors.Hand;
            }
            else
                Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void gv_DelayState_Dist_MouseMove(object sender, MouseEventArgs e)
        {
            GridHitInfo hi = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));
            if (hi.Column == null)
            {
                return;
            }
            if (hi.Column == bandedGridColumn90 || hi.Column == bandedGridColumn92 || hi.Column == bandedGridColumn93
                || hi.Column == bandedGridColumn94 || hi.Column == bandedGridColumn95 || hi.Column == bandedGridColumn96 
                || hi.Column == bandedGridColumn97 || hi.Column == bandedGridColumn98)
            {
                Cursor = System.Windows.Forms.Cursors.Hand;
            }
            else
                Cursor = System.Windows.Forms.Cursors.Default;
        }
        private void gv_ProcState_Dist_Detail_MouseMove(object sender, MouseEventArgs e)
        {
            GridHitInfo hi = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));
            if (hi.Column == null)
            {
                return;
            }
            if (hi.Column == bandedGridColumn43 || hi.Column == bandedGridColumn31 || hi.Column == bandedGridColumn32
                || hi.Column == bandedGridColumn33 || hi.Column == bandedGridColumn34 || hi.Column == bandedGridColumn167)
            {
                Cursor = System.Windows.Forms.Cursors.Hand;
            }
            else
                Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void gv_DelayState_Dist_Detail_MouseMove(object sender, MouseEventArgs e)
        {
            GridHitInfo hi = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));
            if (hi.Column == null)
            {
                return;
            }
            if (hi.Column == bandedGridColumn108 || hi.Column == bandedGridColumn109 || hi.Column == bandedGridColumn110 
                || hi.Column == bandedGridColumn111 || hi.Column == bandedGridColumn112 || hi.Column == bandedGridColumn113 
                || hi.Column == bandedGridColumn114 ||hi.Column == bandedGridColumn115)
            {
                Cursor = System.Windows.Forms.Cursors.Hand;
            }
            else
                Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void gv_ProcState_Part_Detail_MouseMove(object sender, MouseEventArgs e)
        {
            GridHitInfo hi = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));
            if (hi.Column == null)
            {
                return;
            }
            if (hi.Column == bandedGridColumn52 || hi.Column == bandedGridColumn54 || hi.Column == bandedGridColumn55
                || hi.Column == bandedGridColumn56 || hi.Column == bandedGridColumn57 || hi.Column == bandedGridColumn169)
            {
                Cursor = System.Windows.Forms.Cursors.Hand;
            }
            else
                Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void gv_DelayState_Part_Detail_MouseMove(object sender, MouseEventArgs e)
        {
            GridHitInfo hi = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));
            if (hi.Column == null)
            {
                return;
            }
            if (hi.Column == bandedGridColumn126 || hi.Column == bandedGridColumn127 || hi.Column == bandedGridColumn128
                || hi.Column == bandedGridColumn129 || hi.Column == bandedGridColumn130
                || hi.Column == bandedGridColumn131 || hi.Column == bandedGridColumn132 || hi.Column == bandedGridColumn133)
            {
                Cursor = System.Windows.Forms.Cursors.Hand;
            }
            else
                Cursor = System.Windows.Forms.Cursors.Default;
        }
        #endregion

       

        private void VOC_TotalStateMng_SizeChanged(object sender, EventArgs e)
        {
            if (this.Parent == null) return;
            splitContainerControl1.SplitterPosition = this.Parent.Width / 2;
            splitContainerControl2.SplitterPosition = this.Parent.Width / 2;
            splitContainerControl3.SplitterPosition = this.Parent.Width / 2;
            splitContainerControl4.SplitterPosition = this.Parent.Width / 2;
        }

        private void gv_ProcState_User_Detail_DoubleClick(object sender, EventArgs e)
        {
            if (gv_ProcState_User_Detail.FocusedColumn == bandedGridColumn75 || gv_ProcState_User_Detail.FocusedColumn == bandedGridColumn76
                  || gv_ProcState_User_Detail.FocusedColumn == bandedGridColumn77 || gv_ProcState_User_Detail.FocusedColumn == bandedGridColumn78 || gv_ProcState_User_Detail.FocusedColumn == bandedGridColumn171)
            {
                string strDist = gv_ProcState_User_Detail.GetFocusedRowCellValue("파트명").ToString();
                string strUser_Proc = gv_ProcState_User_Detail.GetFocusedRowCellValue("사번").ToString(); //사번
                string strDist_Proc = gv_ProcState_User_Detail.GetFocusedRowCellValue("부서코드").ToString(); //부서코드
                string strState = gv_ProcState_User_Detail.FocusedColumn.Caption;
                string strStateCode = string.Empty;
                string strVOC_Prob = lue_ProblemLv.EditValue.ToString();

                if (strState == "미확인")
                {
                    strStateCode = "미확인";
                }
                else if (strState == "확인")
                {
                    strStateCode = "확인";
                }
                else if (strState == "고객접촉완료")
                {
                    strStateCode = "고객접촉완료";
                }
                else if (strState == "미처리전체")
                {
                    strStateCode = "미처리전체";
                }
                else
                {
                    strStateCode = "처리완료";
                }
                VOC_Form VF = new VOC_Form(strUserID, strDeptCode, strDist, strStateCode, deDate_From.Text, deDate_To.Text, rgVOC_A.Checked == true ? "A" : "P", strUser_Proc, strDist_Proc, "", "", strVOC_Prob);
                VF.StartPosition = FormStartPosition.CenterParent;
                VF.Show();
            }
        }

        private void gv_DelayState_User_Detail_DoubleClick(object sender, EventArgs e)
        {
            if (gv_DelayState_User_Detail.FocusedColumn == bandedGridColumn137 || gv_DelayState_User_Detail.FocusedColumn == bandedGridColumn138
                  || gv_DelayState_User_Detail.FocusedColumn == bandedGridColumn139 || gv_DelayState_User_Detail.FocusedColumn == bandedGridColumn140
                || gv_DelayState_User_Detail.FocusedColumn == bandedGridColumn141 || gv_DelayState_User_Detail.FocusedColumn == bandedGridColumn142
                || gv_DelayState_User_Detail.FocusedColumn == bandedGridColumn143)
            {
                string strMonitoring = string.Empty;
                if (gv_DelayState_User_Detail.FocusedColumn == bandedGridColumn137) //20분 지연
                    strMonitoring = "0";
                else if (gv_DelayState_User_Detail.FocusedColumn == bandedGridColumn138) //1시간 지연
                    strMonitoring = "6";
                else if (gv_DelayState_User_Detail.FocusedColumn == bandedGridColumn140) //1차
                    strMonitoring = "7";
                else if (gv_DelayState_User_Detail.FocusedColumn == bandedGridColumn141) //2차
                    strMonitoring = "5";
                else if (gv_DelayState_User_Detail.FocusedColumn == bandedGridColumn142) //3차
                    strMonitoring = "3";
                else if (gv_DelayState_User_Detail.FocusedColumn == bandedGridColumn143) //4차
                    strMonitoring = "4";


                string strDist = gv_DelayState_User_Detail.GetFocusedRowCellValue("파트명").ToString();
                string strUser_Proc = gv_DelayState_User_Detail.GetFocusedRowCellValue("사번").ToString(); //사번
                string strDist_Proc = gv_DelayState_User_Detail.GetFocusedRowCellValue("부서코드").ToString(); //부서코드
                string strState = gv_DelayState_User_Detail.FocusedColumn.Caption;
                string strVOC_Prob = lue_ProblemLv.EditValue.ToString();
                string strStateCode = string.Empty;

                if (strState == "미처리전체")
                {
                    strStateCode = "고객접촉지연";
                }
                else
                {
                    strStateCode = "";
                }
                VOC_Form VF = new VOC_Form(strUserID, strDeptCode, strDist, strStateCode, deDate_From.Text, deDate_To.Text, rgVOC_A.Checked == true ? "A" : "P", strUser_Proc, strDist_Proc, "", strMonitoring, strVOC_Prob);
                VF.StartPosition = FormStartPosition.CenterParent;
                VF.Show();
            }
        }

        private void gv_DelayState_User_Detail_MouseMove(object sender, MouseEventArgs e)
        {
            GridHitInfo hi = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));
            if (hi.Column == null)
            {
                return;
            }
            if (hi.Column == bandedGridColumn137 || hi.Column == bandedGridColumn138 || hi.Column == bandedGridColumn139
                || hi.Column == bandedGridColumn140 || hi.Column == bandedGridColumn141
                || hi.Column == bandedGridColumn142 || hi.Column == bandedGridColumn143)
            {
                Cursor = System.Windows.Forms.Cursors.Hand;
            }
            else
                Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void rgVOC_P_CheckedChanged(object sender, EventArgs e)
        {
            if (rgVOC_P.Checked == true)
            {
                rgVOC_A.Checked = false;
                lue_ProblemLv.EditValue = "1";
                lue_ProblemLv.Enabled = true;
            }
        }

        private void rgVOC_A_CheckedChanged(object sender, EventArgs e)
        {
            if (rgVOC_A.Checked == true)
            {
                rgVOC_P.Checked = false;
                //lue_ProblemLv.EditValue = "";
                lue_ProblemLv.Enabled = false;
            }
        }
    }
}
