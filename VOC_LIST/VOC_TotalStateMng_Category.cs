using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace VOC_LIST
{
    public partial class VOC_TotalStateMng_Category : DevExpress.XtraEditors.XtraUserControl
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
        string strRgVOC = string.Empty;

        string strGubun = string.Empty;
        string strGubun_Detail = string.Empty;
        string strDeptGubun = string.Empty;
        string strVoc_Prob = string.Empty;

        Cesco.FW.Global.Util.Common.CesnetUserAuthInfo _cesnetUserInfo = new Cesco.FW.Global.Util.Common.CesnetUserAuthInfo();

        #endregion

        public VOC_TotalStateMng_Category()
        {
            InitializeComponent();
        }
        public VOC_TotalStateMng_Category(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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
            strDeptGubun = "Y";
        }

        public VOC_TotalStateMng_Category(string pUserID, string pDeptCode, string pDateFrom, string pDateTo, string pDept, string pRgVOC, string pGubun, string pGubun_Detail, string pVoc_Prob, string pTemp)
        {
            InitializeComponent();

            strUserID = pUserID;
            strDeptCode = pDeptCode;
            strDateFrom = pDateFrom;
            strDateTo = pDateTo;
            strDept = pDept; 
            strRgVOC = pRgVOC;
            strGubun = pGubun;
            strGubun_Detail = pGubun_Detail;
            strDeptGubun = "N";
            strVoc_Prob = pVoc_Prob;
        }

        private void VOC_TotalStateMng_Category_Load(object sender, EventArgs e)
        {
            setDate();
            setDateGubun();
            setlueDept();
            setLueProb();

            lueGubun_Detail.Enabled = false;
            lueDept.EditValue = strDept;
            lueDate_Gubun.EditValue = strGubun == null ? "" : strGubun;
            lueGubun_Detail.EditValue = strGubun_Detail == null ? "" : strGubun_Detail;
            if (lueDate_Gubun.EditValue.ToString() == "")
                lueDate_Gubun.EditValue = "D";
            if (lueGubun_Detail.EditValue.ToString() == "")
                lueGubun_Detail.EditValue = "선택";
            rgVOC1.EditValue = strRgVOC == "" ? "A" : strRgVOC;



            if (strRgVOC == "A")
            {
                rgVOC_A.Checked = true;
                rgVOC_P.Checked = false;
            }
            else if (strRgVOC == "P")
            {
                rgVOC_A.Checked = false;
                rgVOC_P.Checked = true;
            }
            else
            {
                rgVOC_A.Checked = true;
                rgVOC_P.Checked = false;
                lue_ProblemLv.Enabled = false;
            }

            lue_ProblemLv.EditValue = strVoc_Prob;


            if (strDateFrom.Trim() != "")
                deDate_From.EditValue = strDateFrom;
            else
            {
                DateTime mToday = DateTime.Today;
                deDate_From.EditValue = mToday;
            }
            if (strDateTo.Trim() != "")
                deDate_To.EditValue = strDateTo;
            else
            {
                DateTime mToday = DateTime.Today;
                deDate_To.EditValue = mToday;
            }
            if (strDeptGubun == "Y")
            {
                if (Convert.ToInt32(strDeptCode) >= 10280 && Convert.ToInt32(strDeptCode) < 50030)
                {
                    strAuth = "D";
                    
                    lueDept.EditValue = strDeptCode;
                    lueDept.Enabled = false;
                }
                else if (Convert.ToInt32(strDeptCode) >= 51000 && Convert.ToInt32(strDeptCode) <= 59000)
                {
                    strAuth = "D";
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
                    strAuth = "H";
                    lueDept.Enabled = true;
                }
            }
            else
            {
                setBigList();
                gvbigList_FocusedRowChanged(null, null);            
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

        private void setBigList()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_TotalStateCate_Big_SELECT_MULTI"; //  "CESCOEIS.dbo.SP_VOC_TotalStateCate_Big_SELECT_TEMP";
            db.Procedure.ParamAdd("@DATE_FROM", deDate_From.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@DATE_TO", deDate_To.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@DEPTCODE", lueDept.EditValue);
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

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_TotalStateCate_Mid_SELECT_MULTI"; //  "CESCOEIS.dbo.SP_VOC_TotalStateCate_Mid_SELECT_TEMP";
            db.Procedure.ParamAdd("@DATE_FROM", deDate_From.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@DATE_TO", deDate_To.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@BIGCATEGORY", gvbigList.GetFocusedRowCellValue("VOCID") == null ? "" : gvbigList.GetFocusedRowCellValue("VOCID").ToString());
            db.Procedure.ParamAdd("@DEPTCODE", lueDept.EditValue);
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
                gcMidList.DataSource = null;
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

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_TotalStateCate_Sm_SELECT_MULTI"; //"CESCOEIS.dbo.SP_VOC_TotalStateCate_Sm_SELECT_TEMP";
            db.Procedure.ParamAdd("@DATE_FROM", deDate_From.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@DATE_TO", deDate_To.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@MIDCATEGORY", gvMidList.GetFocusedRowCellValue("VOCID") == null ? "" : gvMidList.GetFocusedRowCellValue("VOCID").ToString());
            db.Procedure.ParamAdd("@DEPTCODE", lueDept.EditValue);
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
                gcSmList.DataSource = null;

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
            gvbigList_FocusedRowChanged(null, null);           
        }

        private void gvbigList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (!this.CanFocus)
            //    return;
            if (gvbigList.FocusedColumn.FieldName == "VOCNAME" || gvbigList.FocusedColumn.FieldName == "VOCID")
            {
                setMidList();
                gvMidList_FocusedRowChanged(null, null);
            }
        }

        private void gvMidList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!this.CanFocus)
                return;
            if (gcMidList.DataSource == null)
            {
                return;
            }
            if (gvMidList.FocusedColumn.FieldName != null)
            {
                if (gvMidList.FocusedColumn.FieldName == "VOCNAME" || gvMidList.FocusedColumn.FieldName == "VOCID")
                {
                    setSmList();
                }
            }
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

        private void gvbigList_DoubleClick(object sender, EventArgs e)
        {
            if (gvbigList.FocusedColumn.FieldName != "VOCNAME" && gvbigList.FocusedColumn.FieldName != "VOCID" && gvbigList.FocusedColumn.FieldName != "합계")
            {
                string strDept = gvbigList.FocusedColumn.FieldName;
                string strVOCID_BIG = gvbigList.GetFocusedRowCellValue("VOCID").ToString();
                string strVOCID_MID = gvMidList.GetFocusedRowCellValue("VOCID") == null ? "" : gvMidList.GetFocusedRowCellValue("VOCID").ToString();
                string strVOCID_SM = gvSmList.GetFocusedRowCellValue("VOCID") == null ? "" : gvSmList.GetFocusedRowCellValue("VOCID").ToString();

                string strGubun_date = lueDate_Gubun.EditValue == null ? "" : lueDate_Gubun.EditValue.ToString();
                string strGubun_date_Detail = lueGubun_Detail.EditValue == null ? "" : lueGubun_Detail.EditValue.ToString();
                string strVOC_Prob = lue_ProblemLv.EditValue.ToString();

                VOC_Form_Cate_Detail VFCD = new VOC_Form_Cate_Detail(strUserID, strDeptCode, deDate_From.Text, deDate_To.Text, strDept, rgVOC_A.Checked == true ? "A" : "P", "", strVOCID_BIG, strVOCID_MID, strVOCID_SM, strGubun_date, strGubun_date_Detail, strVOC_Prob);
                //VFCD.StartPosition = FormStartPosition.CenterParent;
                VFCD.ShowDialog();
            }
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

        private void gvMidList_DoubleClick(object sender, EventArgs e)
        {
            if (gvMidList.FocusedColumn.FieldName != "VOCNAME" && gvMidList.FocusedColumn.FieldName != "VOCID" && gvMidList.FocusedColumn.FieldName != "합계")
            {
                string strDept = gvMidList.FocusedColumn.FieldName;
                string strVOCID_BIG = gvbigList.GetFocusedRowCellValue("VOCID").ToString();
                string strVOCID_MID = gvMidList.GetFocusedRowCellValue("VOCID") == null ? "" : gvMidList.GetFocusedRowCellValue("VOCID").ToString();
                string strVOCID_SM = gvSmList.GetFocusedRowCellValue("VOCID") == null ? "" : gvSmList.GetFocusedRowCellValue("VOCID").ToString();

                string strGubun_date = lueDate_Gubun.EditValue == null ? "" : lueDate_Gubun.EditValue.ToString();
                string strGubun_date_Detail = lueGubun_Detail.EditValue == null ? "" : lueGubun_Detail.EditValue.ToString();
                string strVOC_Prob = lue_ProblemLv.EditValue.ToString();

                VOC_Form_Cate_Detail VFCD = new VOC_Form_Cate_Detail(strUserID, strDeptCode, deDate_From.Text, deDate_To.Text, strDept, rgVOC_A.Checked == true ? "A" : "P", "", strVOCID_BIG, strVOCID_MID, strVOCID_SM, strGubun_date, strGubun_date_Detail, strVOC_Prob);
                VFCD.ShowDialog();
            }
        }

        private void gvSmList_DoubleClick(object sender, EventArgs e)
        {
            if (gvSmList.FocusedColumn.FieldName != "VOCNAME" && gvSmList.FocusedColumn.FieldName != "VOCID" && gvSmList.FocusedColumn.FieldName != "합계")
            {
                string strDept = gvSmList.FocusedColumn.FieldName;
                string strVOCID_BIG = gvbigList.GetFocusedRowCellValue("VOCID").ToString();
                string strVOCID_MID = gvMidList.GetFocusedRowCellValue("VOCID") == null ? "" : gvMidList.GetFocusedRowCellValue("VOCID").ToString();
                string strVOCID_SM = gvSmList.GetFocusedRowCellValue("VOCID") == null ? "" : gvSmList.GetFocusedRowCellValue("VOCID").ToString();

                string strGubun_date = lueDate_Gubun.EditValue == null ? "" : lueDate_Gubun.EditValue.ToString();
                string strGubun_date_Detail = lueGubun_Detail.EditValue == null ? "" : lueGubun_Detail.EditValue.ToString();
                string strVOC_Prob = lue_ProblemLv.EditValue.ToString();

                VOC_Form_Cate_Detail VFCD = new VOC_Form_Cate_Detail(strUserID, strDeptCode, deDate_From.Text, deDate_To.Text, strDept, rgVOC_A.Checked == true ? "A" : "P", "", strVOCID_BIG, strVOCID_MID, strVOCID_SM, strGubun_date, strGubun_date_Detail, strVOC_Prob);
                //VFCD.StartPosition = FormStartPosition.CenterParent;                
                VFCD.ShowDialog();
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
            setCursor(sender, e);
        }

        private void gvMidList_MouseMove(object sender, MouseEventArgs e)
        {
            setCursor(sender, e);
        }

        private void gvSmList_MouseMove(object sender, MouseEventArgs e)
        {
            setCursor(sender, e);
        }

        private void VOC_TotalStateMng_Category_SizeChanged(object sender, EventArgs e)
        {
            if (this.Parent == null) return;
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
                //lue_ProblemLv.EditValue = "";
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
