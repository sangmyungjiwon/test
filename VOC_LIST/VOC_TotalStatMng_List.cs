using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using CES.FUNCTION;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Base;

namespace VOC_LIST
{
    public partial class VOC_TotalStatMng_List : DevExpress.XtraEditors.XtraUserControl
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
        string strDist = string.Empty;
        string strStateCode = string.Empty;
        string strDateTo = string.Empty;
        string strDateFrom = string.Empty;
        string strDept = string.Empty;
        string strRgVOC = string.Empty;
        string strUserID_Proc = string.Empty;
        string strDist_Proc = string.Empty;
        string strUser_Part = string.Empty;
        string strMonitoring = string.Empty;
        string strGubun = string.Empty;
        string strVoc_Prob = string.Empty;

        Cesco.FW.Global.Util.Common.CesnetUserAuthInfo _cesnetUserInfo = new Cesco.FW.Global.Util.Common.CesnetUserAuthInfo();
        #endregion

        public VOC_TotalStatMng_List()
        {
            InitializeComponent();
        }

        public VOC_TotalStatMng_List(string pUserID, string pDeptCode, string pDist, string pStateCode, string pDateFrom, string pDateTo, string pRgVOC,
            string pUserID_Proc, string pDist_Proc, string pUSer_Part, string pMonitoring, string pVoc_Prob)
        {
            InitializeComponent();

            strGubun = "A";
            strUserID = pUserID;
            strDeptCode = pDeptCode;
            strDist = pDist;
            lueDept.EditValue = strDist;
            lueDept.Enabled = false;
            strStateCode = pStateCode;
            strRgVOC = pRgVOC;
            strDateFrom = pDateFrom;
            strDateTo = pDateTo;
            strUserID_Proc = pUserID_Proc;
            strDist_Proc = pDist_Proc;
            strUser_Part = pUSer_Part;
            luePro_Part.EditValue = strUser_Part;
            strMonitoring = pMonitoring;
            strVoc_Prob = pVoc_Prob;
        }

        public VOC_TotalStatMng_List(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
        {
            InitializeComponent();

            strGubun = "B";
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


        private void VOC_TotalStatMng_List_Load(object sender, EventArgs e)
        {
            setDate();
            setTopList();
            setDateGubun();
            setlueCategory_Big();
            setlueDept();
            setLueProb();

            //if (strExcelAuth == "Y")
            //    btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //else
            //    btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            if (strGubun == "A")
            {
                deDate_From.EditValue = strDateFrom;
                deDate_To.EditValue = strDateTo;
                lueProcState.EditValue = strStateCode;
                if (strDist_Proc != "")
                    lueDept.EditValue = strDist_Proc;
                lueUser.EditValue = strUserID_Proc;

                if (strRgVOC == "A")
                {
                    rgVOC_A.Checked = true;
                    rgVOC_P.Checked = false;
                }
                else
                {
                    rgVOC_A.Checked = false;
                    rgVOC_P.Checked = true;
                    lue_ProblemLv.EditValue = strVoc_Prob;
                }
                //lueDept.EditValue = strDist_Proc;
                setList();
            }
            else
            {
                if (Convert.ToInt32(strDeptCode) >= 10280 && Convert.ToInt32(strDeptCode) < 50030)
                {
                    strAuth = "D";
                    //if (_cesnetUserInfo.UserInfo.ResponOfOfficeCode == "B31" || _cesnetUserInfo.UserInfo.ResponOfOfficeCode == "B33")
                    //{
                    //    //strAuth = "Y";
                    //    lueDept.Enabled = false;
                    //    lueUser.Enabled = true;
                    //}
                    //else
                    //{
                        lueDept.EditValue = strDeptCode;
                        luePro_Part.EditValue = "";
                        lueUser.EditValue = strUserID;
                        lueDept.Enabled = false;
                        lueUser.Enabled = true;
                    //}
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
                    luePro_Part.EditValue = "";
                    lueUser.EditValue = strUserID;
                    lueDept.Enabled = true;
                    lueUser.Enabled = true;
                }
                else
                {
                    strAuth = "H";
                    lueDept.Enabled = true;
                    lueUser.Enabled = true;
                }

                rgVOC_A.Checked = true;
                rgVOC_P.Checked = false;
            }
            lueGubun_Detail.Enabled = false;
            
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
            //DateTime mToday = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-7).Day);
            DateTime mToday_before = DateTime.Today.AddDays(-7);
            deDate_From.EditValue = mToday_before;
            deDate_To.EditValue = DateTime.Now;
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
                deDate_From.Enabled = true;
                deDate_To.EditValue = deDate_From.EditValue;
            }
            else if (lueDate_Gubun.EditValue.ToString() == "W")
            {
                lueGubun_Detail.Enabled = false;
                deDate_From.Enabled = true;
                DateTime dt_To = deDate_From.DateTime.AddDays(+7);
                deDate_To.EditValue = dt_To;
            }
            else if (lueDate_Gubun.EditValue.ToString() == "M")
            {
                lueGubun_Detail.Enabled = false;
                deDate_From.Enabled = true;
                DateTime dt_To = deDate_From.DateTime.AddMonths(+1);
                deDate_To.EditValue = dt_To;
            }
            else if (lueDate_Gubun.EditValue.ToString() == "P")
            {
                deDate_To.Enabled = false;
                deDate_From.Enabled = false;
                DataTable dt_DateGubun_Detail = new DataTable();
                dt_DateGubun_Detail.Columns.Add("CODE");
                dt_DateGubun_Detail.Columns.Add("NAME");
                dt_DateGubun_Detail.Rows.Add("", "전체");
                dt_DateGubun_Detail.Rows.Add("Q1", "1분기");
                dt_DateGubun_Detail.Rows.Add("Q2", "2분기");
                dt_DateGubun_Detail.Rows.Add("Q3", "3분기");
                dt_DateGubun_Detail.Rows.Add("Q4", "4분기");

                lueGubun_Detail.Properties.ValueMember = "CODE";
                lueGubun_Detail.Properties.DisplayMember = "NAME";
                lueGubun_Detail.Properties.DataSource = dt_DateGubun_Detail;
                lueGubun_Detail.Enabled = true;
                lueGubun_Detail.EditValue = "";
            }
            else
            {
                deDate_To.Enabled = false;
                deDate_From.Enabled = false;
                DataTable dt_DateGubun_Detail = new DataTable();
                dt_DateGubun_Detail.Columns.Add("CODE");
                dt_DateGubun_Detail.Columns.Add("NAME");
                dt_DateGubun_Detail.Rows.Add("", "전체");
                dt_DateGubun_Detail.Rows.Add("SB", "상반기");
                dt_DateGubun_Detail.Rows.Add("HB", "하반기");

                lueGubun_Detail.Properties.ValueMember = "CODE";
                lueGubun_Detail.Properties.DisplayMember = "NAME";
                lueGubun_Detail.Properties.DataSource = dt_DateGubun_Detail;
                lueGubun_Detail.Enabled = true;
                lueGubun_Detail.EditValue = "";
            }
        }

        private void setLue(LookUpEdit lueNm, int i, string paramValue, string valMem, string disMem, string paramValuePart)
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESNET2.dbo.SP_DEPT_SEARCH_ALL";
            db.Procedure.ParamAdd("@부서코드", paramValue);
            db.Procedure.ParamAdd("@파트코드", paramValuePart);

            try
            {
                DataSet ds = db.ProcedureToDataSet();

                lueNm.Properties.ValueMember = valMem;
                lueNm.Properties.DisplayMember = disMem;
                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
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
            setLue(lueDept, 0, "", "부서코드", "부서명", "");
            setLue(lueCallDept, 0, "", "부서코드", "부서명", "");
        }

        private void lueDept_EditValueChanged(object sender, EventArgs e)
        {
            setLue(luePro_Part, 3, lueDept.EditValue.ToString(), "파트코드", "파트명", "");
            luePro_Part_EditValueChanged(null, null);
            luePro_Part.ItemIndex = 0;
            //setLue(lueUser, 1, lueDept.EditValue.ToString(), "사번", "한글성명");

            //if (lueDept.EditValue == "")
            //{
            //    lueUser.EditValue = "";
            //}
        }

        #region 카테고리
        private void setlueCategory_Big()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORY_LARGE2_SELECT";

            try
            {
                DataSet ds = db.ProcedureToDataSet();

                lueCategory_Big.Properties.ValueMember = "대분류VOCID";
                lueCategory_Big.Properties.DisplayMember = "대분류명";
                lueCategory_Big.Properties.DataSource = ds.Tables[0];
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

        private void lueCategory_Big_EditValueChanged(object sender, EventArgs e)
        {
            lueCategory_Mid.EditValue = "";
            lueCategory_Sm.EditValue = "";
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORY_MEDIUM2_SELECT";
            db.Procedure.ParamAdd("@MIDIUMPID", lueCategory_Big.EditValue);
            try
            {
                DataSet ds = db.ProcedureToDataSet();

                lueCategory_Mid.Properties.ValueMember = "중분류VOCID";
                lueCategory_Mid.Properties.DisplayMember = "중분류명";
                lueCategory_Mid.Properties.DataSource = ds.Tables[0];

                lueCategory_Mid.ItemIndex = 0;
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

        private void lueCategory_Mid_EditValueChanged(object sender, EventArgs e)
        {
            lueCategory_Sm.EditValue = "";
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORY_SMALL2_SELECT";
            db.Procedure.ParamAdd("@SMALLPID", lueCategory_Mid.EditValue);

            try
            {
                DataSet ds = db.ProcedureToDataSet();

                lueCategory_Sm.Properties.ValueMember = "소분류VOCID";
                lueCategory_Sm.Properties.DisplayMember = "소분류명";
                lueCategory_Sm.Properties.DataSource = ds.Tables[0];
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

        private void setTopList()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_TotalStateMngList_Top_SELECT";
        
            try
            {
                DataSet ds = db.ProcedureToDataSet();

                    
                lueChannel.Properties.ValueMember = "코드";
                lueChannel.Properties.DisplayMember = "경로";
                lueChannel.Properties.DataSource = ds.Tables[1];
            }
            catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            {
                MessageBox.Show(ex.Message, "DB 에러");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "처리되지 않은 에러");
            }

            DataTable dt_DateGubun_Detail = new DataTable();
            dt_DateGubun_Detail.Columns.Add("코드구분");
            dt_DateGubun_Detail.Columns.Add("코드명");
            dt_DateGubun_Detail.Rows.Add("", "전체");
            dt_DateGubun_Detail.Rows.Add("미확인", "미확인");
            dt_DateGubun_Detail.Rows.Add("확인", "확인");
            dt_DateGubun_Detail.Rows.Add("고객접촉완료", "고객접촉완료");
            dt_DateGubun_Detail.Rows.Add("처리완료", "처리완료");
            dt_DateGubun_Detail.Rows.Add("미처리전체", "미처리전체");


            lueProcState.Properties.ValueMember = "코드구분";
            lueProcState.Properties.DisplayMember = "코드명";
            lueProcState.Properties.DataSource = dt_DateGubun_Detail;
        }



        private void setList()
        {
            //strGubun A, B구분

            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_TotalStateMngList_SELECT_MULTI"; //SP_VOC_TotalStateMngList_SELECT_MULTI
            //db.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_TotalStateMngList_SELECT_MULTI"; //SP_VOC_TotalStateMngList_SELECT_MULTI
            db.Procedure.ParamAdd("@DATE_FROM", deDate_From.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@DATE_TO", deDate_To.Text.Replace("-", ""));
            db.Procedure.ParamAdd("@DEPTCODE", lueDept.EditValue == null ? "" : lueDept.EditValue);
            db.Procedure.ParamAdd("@USERID", lueUser.EditValue == null ? "" : lueUser.EditValue);
            db.Procedure.ParamAdd("@PROSTATE", lueProcState.EditValue == null ? "" : lueProcState.EditValue);
            db.Procedure.ParamAdd("@CATEGORY_BIG", lueCategory_Big.EditValue == null ? "" : lueCategory_Big.EditValue);
            db.Procedure.ParamAdd("@CATEGORY_MID", lueCategory_Mid.EditValue == null ? "" : lueCategory_Mid.EditValue);
            db.Procedure.ParamAdd("@CATEGORY_SM", lueCategory_Sm.EditValue == null ? "" : lueCategory_Sm.EditValue);
            db.Procedure.ParamAdd("@DELAYSTATE", lueDelayState.EditValue == null ? "" : lueDelayState.EditValue);
            db.Procedure.ParamAdd("@CUSTNM", teCustNm.Text);
            db.Procedure.ParamAdd("@CHANNEL", lueChannel.EditValue == null ? "" : lueChannel.EditValue);
            db.Procedure.ParamAdd("@PROBLEMYN", rgVOC_A.Checked == true ? "A" : "P");
            db.Procedure.ParamAdd("@PARTCODE", luePro_Part.EditValue == null ? "" : luePro_Part.EditValue.ToString());
            db.Procedure.ParamAdd("@MONITORING_GUBUN", strMonitoring);
            db.Procedure.ParamAdd("@PROBLEMLV", rgVOC_A.Checked == true ? "" : lue_ProblemLv.EditValue.ToString());
            db.Procedure.ParamAdd("@CALLDEPT", lueCallDept.EditValue == null ? "" : lueCallDept.EditValue.ToString());
            db.Procedure.ParamAdd("@CALLEMP", lueCallEmp.EditValue == null ? "" : lueCallEmp.EditValue.ToString());

            try
            {
                DataSet ds = db.ProcedureToDataSet();

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    gcMngList.DataSource = null;
                    return;
                }
                gcMngList.DataSource = ds.Tables[0];
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

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            setList();
            this.Cursor = Cursors.Default;
        }
        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ExportToExcel(gcMngList, strUserID);
            string fileName = string.Empty;
            Cesco.FW.Global.DevExpressUtil.Grid.ConvertExcel ce = new Cesco.FW.Global.DevExpressUtil.Grid.ConvertExcel();
            fileName = ce.GridToExcelReturnName(gcMngList, strUserID);

            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.Start();
        }

         public bool ExportToExcel(DevExpress.XtraGrid.GridControl gridControl, string userId)
        {
            DevExpress.LookAndFeel.UserLookAndFeel lookAndFeel = new DevExpress.LookAndFeel.UserLookAndFeel(gridControl);

            if (XtraMessageBox.Show(lookAndFeel, "엑셀파일로 저장하시겠습니까?", "파일저장", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                return false;

            try
            {
                SaveFileDialog oSaveFileDialog = new SaveFileDialog();
                oSaveFileDialog.Title = "자신의 엑셀 버전에 맞는 버전을 선택해 주세요.";
                oSaveFileDialog.Filter = "엑셀 파일(6만건이상) [2007~2013](*.xlsx)|*.xlsx|엑셀 파일(6만건한계) [~2003](*.xls)|*.xls";
                oSaveFileDialog.FilterIndex = 1;
                oSaveFileDialog.RestoreDirectory = true;

                if (oSaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (oSaveFileDialog.FileName != null)
                    {
                        bool isCellMerge = false;
                        GridView view = (GridView)gridControl.MainView;

                        isCellMerge = view.OptionsView.AllowCellMerge;

                        view.OptionsView.AllowCellMerge = false;
                        System.IO.FileStream fs = new System.IO.FileStream(oSaveFileDialog.FileName, System.IO.FileMode.Create);

                        if (oSaveFileDialog.FileName.EndsWith(".xls"))
                            gridControl.ExportToXls(fs);
                        else
                            gridControl.ExportToXlsx(fs);

                        view.OptionsView.AllowCellMerge = isCellMerge;
                        fs.Close();

                        if (userId == string.Empty)
                        {
                            XtraMessageBox.Show(lookAndFeel, "저장되었습니다.", "저장완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }

                        CESFasoo fasoo = new CESFasoo();


                        if (fasoo.FSDEncryption(oSaveFileDialog.FileName, oSaveFileDialog.FileName, "DevExpress 엑셀변환 자료", userId))
                        {
                            XtraMessageBox.Show(lookAndFeel, "저장되었습니다.", "저장완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Process.Start(oSaveFileDialog.FileName);
                            return true;
                        }
                        else
                            throw new CESException("엑셀파일 변환중 암호화에 실패하였습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new CESException(this, "ConvertExcel", new object[] { }, ex.Message, ex);
            }

            return false;
        }

         private void gvMngList_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
         {
             if (e.Info.IsRowIndicator && e.RowHandle >= 0)
             {
                 e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                 e.Info.DisplayText = (e.RowHandle + 1).ToString();
             }
         }

         private void gvMngList_RowCountChanged(object sender, EventArgs e)
         {
             GridView gridView = ((GridView)sender);
             if (!gridView.GridControl.IsHandleCreated) return;
             Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
             SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
             gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 21;
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

         private void lueCallDept_EditValueChanged(object sender, EventArgs e)
         {
             setLue(lueCallEmp, 1, lueCallDept.EditValueString.Length == 0 ? "" : lueCallDept.EditValue.ToString(), "사번", "한글성명", "");
             lueCallEmp.ItemIndex = 0;
         }

         private void gvMngList_DoubleClick(object sender, EventArgs e)
         {
             DataRow row = gvMngList.GetFocusedDataRow();

             gvStateList_PopUp(row, gvMngList.FocusedRowHandle);
         }

         private void gvStateList_PopUp(DataRow pRow, int iRow)
         {
             string strRegDate = pRow["접수날짜"].ToString();
             string strRegNum = pRow["접수번호"].ToString();
             string strRegUser = pRow["접수사원"].ToString();
             string strCustCode = pRow["고객코드"].ToString();
             string strVCNO = pRow["크레임번호"].ToString();
             string strVCTP = pRow["카테고리대코드"].ToString();
             this.Cursor = Cursors.WaitCursor;
             VOC_ProcessMng VW = new VOC_ProcessMng(strUserID, strDeptCode, strRegDate, strRegNum, strRegUser, strCustCode, strAuth, strVCNO, strVCTP, "");
             VW.StartPosition = FormStartPosition.CenterParent;
             VW.ShowDialog();
             this.Cursor = Cursors.Default;
             btnSearch_ItemClick(null, null);
             gvMngList.FocusedRowHandle = iRow;
         }

         private void luePro_Part_EditValueChanged(object sender, EventArgs e)
         {
             setLue(lueUser, 1, lueDept.EditValue.ToString(), "사번", "한글성명", Convert.ToString(luePro_Part.EditValue));
             lueUser.ItemIndex = 0;
         }

         private void lueDept_Click(object sender, EventArgs e)
         {
             lueDept.ShowPopup();
         }

         private void luePro_Part_Click(object sender, EventArgs e)
         {
             luePro_Part.ShowPopup();
         }

         private void lueUser_Click(object sender, EventArgs e)
         {
             lueUser.ShowPopup();
         }

         private void lueCategory_Big_Click(object sender, EventArgs e)
         {
             lueCategory_Big.ShowPopup();
         }

         private void lueCategory_Mid_Click(object sender, EventArgs e)
         {
             lueCategory_Mid.ShowPopup();
         }

         private void lueCategory_Sm_Click(object sender, EventArgs e)
         {
             lueCategory_Sm.ShowPopup();
         }

         private void lueCallDept_Click(object sender, EventArgs e)
         {
             lueCallDept.ShowPopup();
         }

         private void lueCallEmp_Click(object sender, EventArgs e)
         {
             lueCallEmp.ShowPopup();
         }

       
    }


}
