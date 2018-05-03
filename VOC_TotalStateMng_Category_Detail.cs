using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace VOC_LIST
{
    public partial class VOC_TotalStateMng_Category_Detail : DevExpress.XtraEditors.XtraUserControl
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

        string strDateFrom = string.Empty;
        string strDateTo = string.Empty;
        string strDept = string.Empty;
        string strVOCID_BIG = string.Empty;
        string strVOCID_MID = string.Empty;
        string strVOCID_SM = string.Empty;
        string strDeptNm = string.Empty;
        string strrgVOC = string.Empty;
        string strDeptDetail = string.Empty;
        string strGubun = string.Empty;

        string strDateGubun = string.Empty;
        string strGubun_Detail = string.Empty;
        string strVOC_Prob = string.Empty;
        #endregion

        public VOC_TotalStateMng_Category_Detail()
        {
            InitializeComponent();
        }
        public VOC_TotalStateMng_Category_Detail(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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
            strGubun = "1";
        }

        public VOC_TotalStateMng_Category_Detail(string pUserID, string pDeptCode, string pDateFrom, string pDateTo, string pDept, string prgVOC, string pDeptDetail, string pVOCID_BIG, string pVOCID_MID, string pVOCID_SM, string pGubun, string pGubun_Detail, string pVoc_Prob)
        {
            InitializeComponent();

            strUserID = pUserID;
            strDeptCode = pDeptCode;
            strDateFrom = pDateFrom;
            strDateTo = pDateTo;
            strDept = pDept;
            strVOCID_BIG = pVOCID_BIG;
            strVOCID_MID = pVOCID_MID;
            strVOCID_SM = pVOCID_SM;
            strrgVOC = prgVOC;
            strDeptDetail = pDeptDetail;
            strDateGubun = pGubun;
            strGubun_Detail = pGubun_Detail;
            strGubun = "2";
            strVOC_Prob = pVoc_Prob;
        }

        private void VOC_TotalStateMng_Category_Load(object sender, EventArgs e)
        {
            setDate();
            setDateGubun();
            setlueDept();
            setLueProb();

            if (strGubun == "2")
            {
                lueDept.Enabled = false;
                if (strDept == "")
                {
                    lueDept.EditValue = "";
                }
                else
                {
                    if (strDept.Substring(0, 1) == "5")
                        lueDept.EditValue = strDept;
                    else
                    {
                        setDeptNmCheck();
                        lueDept.EditValue = strDeptNm;
                    }
                }
                lueDeptDetail.EditValue = strDeptDetail;
                lueDate_Gubun.EditValue = strDateGubun;
                lueGubun_Detail.EditValue = strGubun_Detail;
                deDate_From.EditValue = strDateFrom;
                deDate_To.EditValue = strDateTo;
               
                if (strrgVOC == "A")
                {
                    rgVOC_A.Checked = true;
                    rgVOC_P.Checked = false;
                }
                else
                {
                    rgVOC_A.Checked = false;
                    rgVOC_P.Checked = true;
                }
                lue_ProblemLv.EditValue = strVOC_Prob;
            }
            else
            {
                lueDeptDetail.EditValue = strDeptDetail;
                 if (Convert.ToInt32(strDeptCode) >= 10280 && Convert.ToInt32(strDeptCode) < 50030)
                {
                    //본부조회
                    Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

                    db.Procedure.ProcedureName = "CESNET2.dbo.SP_DEPT_PARENT_SEARCH";
                    db.Procedure.ParamAdd("@DEPTCODE", strDeptCode);

                    try
                    {
                        object ob = db.ProcedureToScalar();
                        lueDept.EditValue = ob;
                    }
                    catch (Cesco.FW.Global.DBAdapter.WcfException ex)
                    {
                        MessageBox.Show(ex.Message, "DB 에러");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "처리되지 않은 에러");
                    }
                    lueDeptDetail.EditValue = strDeptCode;
                    lueDeptDetail.Enabled = false;
                }
                else if (Convert.ToInt32(strDeptCode) >= 51000 && Convert.ToInt32(strDeptCode) <= 59000)
                {
                    Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

                    db.Procedure.ProcedureName = "CESNET2.dbo.SP_DEPT_SEARCH_Include";
                    db.Procedure.ParamAdd("@부서코드", strDeptCode);

                    try
                    {
                        DataSet ds = db.ProcedureToDataSet();

                        lueDept.Properties.ValueMember = "부서코드";
                        lueDept.Properties.DisplayMember = "부서명";
                        if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                        {
                            // XtraMessageBox.Show("조회된 데이터가 없습니다.");
                            return;
                        }
                        lueDept.Properties.DataSource = ds.Tables[0];
                    }
                    catch (Cesco.FW.Global.DBAdapter.WcfException ex)
                    {
                        MessageBox.Show(ex.Message, "DB 에러");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "처리되지 않은 에러");
                    }
                    lueDept.EditValue = strDeptCode;
                    lueDept.Enabled = true;
                }
                else
                {
                    lueDept.Enabled = true;
                    lueDeptDetail.Enabled = true;
                }
            
            }
            rgVOC1.EditValue = strrgVOC;

           // lue_ProblemLv.EditValue = strVOC_Prob;

            lueGubun_Detail.Enabled = false;
            barButtonItem1_ItemClick(null, null);
            gvbigList_FocusedRowChanged(null, null);

            //저장한 행 선택되어있도록
            ColumnView view = (ColumnView)gcbigList.FocusedView;
            GridColumn column = view.Columns["VOCID"];
            if (column != null)
            {
                int columnFound = view.LocateByDisplayText(0, column, strVOCID_BIG);
                if (columnFound != GridControl.InvalidRowHandle)
                {
                    view.FocusedRowHandle = columnFound;
                }
            }

            if (strVOCID_MID != "")
            {
                //저장한 행 선택되어있도록
                ColumnView view2 = (ColumnView)gcMidList.FocusedView;
                GridColumn column2 = view.Columns["VOCID"];
                if (column2 != null)
                {
                    int columnFound = view2.LocateByDisplayText(0, column2, strVOCID_MID);
                    if (columnFound != GridControl.InvalidRowHandle)
                    {
                        view2.FocusedRowHandle = columnFound;
                    }
                }
            }
            if (strVOCID_SM != "")
            {
                //저장한 행 선택되어있도록
                ColumnView view3 = (ColumnView)gcSmList.FocusedView;
                GridColumn column3 = view.Columns["VOCID"];
                if (column3 != null)
                {
                    int columnFound = view3.LocateByDisplayText(0, column3, strVOCID_SM);
                    if (columnFound != GridControl.InvalidRowHandle)
                    {
                        view3.FocusedRowHandle = columnFound;
                    }
                }
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
                DateTime dt_To = deDate_From.DateTime.AddMonths(+1);
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

        private void setDeptNmCheck()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_TotalStateMng_DeptNM";
            db.Procedure.ParamAdd("@DEPTNM", strDept);

            try
            {
                DataSet ds = db.ProcedureToDataSet();
                strDeptNm = ds.Tables[0].Rows[0]["부서코드"].ToString();
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

        private void setBigList()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_TotalStateCate_Big_Jisa_SELECT_MULTI"; // "CESCOEIS.dbo.SP_VOC_TotalStateCate_Big_Jisa_SELECT_TEMP";
            db.Procedure.ParamAdd("@DATE_FROM", deDate_From.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@DATE_TO", deDate_To.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@DEPTCODE", lueDept.EditValue == null ? "" : lueDept.EditValue);
            db.Procedure.ParamAdd("@DEPTDETAILCODE", lueDeptDetail.EditValue == null ? "" : lueDeptDetail.EditValue);
            db.Procedure.ParamAdd("@PROBLEMYN", rgVOC_A.Checked == true ? "A" : "P");
            db.Procedure.ParamAdd("@PROBLEMLV", rgVOC_A.Checked == true ? "" : lue_ProblemLv.EditValue.ToString());

            try
            {
                DataSet ds = db.ProcedureToDataSet();

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    gcbigList.DataSource = null;

                    return;
                }
                gvbigList.Columns.Clear();
                gcbigList.DataSource = ds.Tables[0];
                gvbigList.BestFitColumns();
                gvbigList.OptionsView.ColumnAutoWidth = false;
                gvbigList.Columns[1].Caption = "대분류";
                gvbigList.Columns[0].Visible = false;
                gvbigList.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                gvbigList.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                gvbigList.Columns[1].Width = 200;

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

        private void setMidList()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_TotalStateCate_Mid_Jisa_SELECT_MULTI"; //"CESCOEIS.dbo.SP_VOC_TotalStateCate_Mid_Jisa_SELECT_TEMP";
            db.Procedure.ParamAdd("@DATE_FROM", deDate_From.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@DATE_TO", deDate_To.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@BIGCATEGORY", gvbigList.GetFocusedRowCellValue("VOCID") == null ? "" : gvbigList.GetFocusedRowCellValue("VOCID").ToString());
            db.Procedure.ParamAdd("@DEPTCODE", lueDept.EditValue == null ? "" : lueDept.EditValue);
            db.Procedure.ParamAdd("@DEPTDETAILCODE", lueDeptDetail.EditValue == null ? "" : lueDeptDetail.EditValue);
            db.Procedure.ParamAdd("@PROBLEMYN", rgVOC_A.Checked == true ? "A" : "P");
            db.Procedure.ParamAdd("@PROBLEMLV", rgVOC_A.Checked == true ? "" : lue_ProblemLv.EditValue.ToString());

            try
            {
                DataSet ds = db.ProcedureToDataSet();

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    gcMidList.DataSource = null;
                    return;
                }
                gvMidList.Columns.Clear();

                gcMidList.DataSource = ds.Tables[0];
                gvMidList.BestFitColumns();
                gvMidList.OptionsView.ColumnAutoWidth = false;
                gvMidList.Columns[1].Caption = "중분류";
                gvMidList.Columns[0].Visible = false;
                gvMidList.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                gvMidList.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                gvMidList.Columns[1].Width = 200;

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

        private void setSmList()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_TotalStateCate_Sm_Jisa_SELECT_MULTI"; // "CESCOEIS.dbo.SP_VOC_TotalStateCate_Sm_Jisa_SELECT_TEMP";
            db.Procedure.ParamAdd("@DATE_FROM", deDate_From.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@DATE_TO", deDate_To.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@MIDCATEGORY", gvMidList.GetFocusedRowCellValue("VOCID") == null ? "" : gvMidList.GetFocusedRowCellValue("VOCID").ToString());
            db.Procedure.ParamAdd("@DEPTCODE", lueDept.EditValue == null ? "" : lueDept.EditValue);
            db.Procedure.ParamAdd("@DEPTDETAILCODE", lueDeptDetail.EditValue == null ? "" : lueDeptDetail.EditValue);
            db.Procedure.ParamAdd("@PROBLEMYN", rgVOC_A.Checked == true ? "A" : "P");
            db.Procedure.ParamAdd("@PROBLEMLV", rgVOC_A.Checked == true ? "" : lue_ProblemLv.EditValue.ToString());

            try
            {
                DataSet ds = db.ProcedureToDataSet();
                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    gcSmList.DataSource = null;
                    return;
                }
                gvSmList.Columns.Clear();

                gcSmList.DataSource = ds.Tables[0];
                gvSmList.BestFitColumns();
                gvSmList.OptionsView.ColumnAutoWidth = false;
                gvSmList.Columns[1].Caption = "소분류";
                gvSmList.Columns[0].Visible = false;
                gvSmList.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                gvSmList.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                gvSmList.Columns[1].Width = 200;

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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setBigList();
        }

        private void gvbigList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (!this.CanFocus)
            //    return;
            setMidList();
            gvMidList_FocusedRowChanged(null, null);
        }

        private void gvMidList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (!this.CanFocus)
            //    return;
            setSmList();
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

        private void setlueDept()
        {
            setLue(lueDept, 0, "", "부서코드", "부서명");
        }

        private void lueDept_EditValueChanged(object sender, EventArgs e)
        {
            setLue(lueDeptDetail, 1, lueDept.EditValue.ToString(), "부서코드", "부서명");
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

        private void deDate_From_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDate_Gubun.EditValue != null)
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
                    DateTime dt_To = deDate_From.DateTime.AddMonths(+1);
                    deDate_To.EditValue = dt_To;
                }
            }
        }

        private void gvbigList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvMidList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvSmList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        #region 커서 설정
        private void setCursor(object sender, MouseEventArgs e)
        {
            GridHitInfo hi = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));
            if (hi.Column == null)
            {
                return;
            }
            if (hi.Column.FieldName != "VOCID" && hi.Column.FieldName != "VOCNAME")
            {
                Cursor = System.Windows.Forms.Cursors.Hand;
            }
            else
                Cursor = System.Windows.Forms.Cursors.Default;
        }
        private void gvbigList_MouseMove(object sender, MouseEventArgs e)
        {
            //setCursor(sender, e);
        }

        private void gvMidList_MouseMove(object sender, MouseEventArgs e)
        {
            //setCursor(sender, e);
        }

        private void gvSmList_MouseMove(object sender, MouseEventArgs e)
        {
            //setCursor(sender, e);
        }
        #endregion

        private void VOC_TotalStateMng_Category_Detail_Paint(object sender, PaintEventArgs e)
        {
            gcbigList.Height = (this.Parent.Height - panelControl2.Height - 30) / 3;
            gcMidList.Height = (this.Parent.Height - panelControl2.Height - 30) / 3;
        }

        private void VOC_TotalStateMng_Category_Detail_SizeChanged(object sender, EventArgs e)
        {
            gcbigList.Height = (this.Parent.Height - panelControl2.Height - 30) / 3;
            gcMidList.Height = (this.Parent.Height - panelControl2.Height - 30) / 3;
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
               // lue_ProblemLv.EditValue = "";
                lue_ProblemLv.Enabled = false;
            }
        }

        private void gvbigList_Click(object sender, EventArgs e)
        {
            gvbigList_FocusedRowChanged(null, null);
        }

        private void gvMidList_Click(object sender, EventArgs e)
        {
            gvMidList_FocusedRowChanged(null, null);
        }
        
    }
}
