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
    public partial class VOC_DivideList : DevExpress.XtraEditors.XtraUserControl
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
        DataTable dt_Work = new DataTable();
        #endregion

        public VOC_DivideList()
        {
            InitializeComponent();
        }
        public VOC_DivideList(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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
            setlueDept();
            setlueWork_Gubun();
            setDate();
            setLue();

            //luePro_Dept.EditValue = strDeptCode;
            //luePro_User.EditValue = strUserID;

            //if (Convert.ToInt32(strDeptCode) >= 10280 && Convert.ToInt32(strDeptCode) < 50030)
            //{
            //    strAuth = "D";
            //    if (_cesnetUserInfo.UserInfo.ResponOfOfficeCode == "B31" || _cesnetUserInfo.UserInfo.ResponOfOfficeCode == "B33")
            //    {
            //        //strAuth = "Y";
            //        luePro_Dept.Enabled = false;
            //        luePro_User.Enabled = true;
            //    }
            //    else
            //    {
            //        luePro_Dept.Enabled = false;
            //        luePro_User.Enabled = false;
            //    }
            //}
            //else if (Convert.ToInt32(strDeptCode) >= 51000 && Convert.ToInt32(strDeptCode) <= 59000)
            //{
            //    strAuth = "D";
            //    Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            //    db.Procedure.ProcedureName = "CESNET2.dbo.SP_DEPT_SEARCH_Include";
            //    db.Procedure.ParamAdd("@부서코드", strDeptCode);

            //    try
            //    {
            //        DataSet ds = db.ProcedureToDataSet();

            //        luePro_Dept.Properties.ValueMember = "부서코드";
            //        luePro_Dept.Properties.DisplayMember = "부서명";
            //        if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
            //        {
            //            // XtraMessageBox.Show("조회된 데이터가 없습니다.");
            //            return;
            //        }
            //        luePro_Dept.Properties.DataSource = ds.Tables[0];
            //    }
            //    catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            //    {
            //        MessageBox.Show(ex.Message, "DB 에러");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "처리되지 않은 에러");
            //    }
            //    luePro_Dept.EditValue = strDeptCode;
            //    luePro_User.EditValue = strUserID;
            //    luePro_Dept.Enabled = true;
            //    luePro_User.Enabled = true;
            //}
            //else
            //{
            //    strAuth = "H";
            //    luePro_Dept.Enabled = true;
            //    luePro_User.Enabled = true;
            //}
        }

        private void setDate()
        {
            DateTime mToday = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-7).Day);
            deStart_Date.EditValue = mToday;
            deEnd_Date.EditValue = DateTime.Now;
        }

        private void setLue()
        {
            luePro_Dept.EditValue = "";
            luePro_User.EditValue = "";
            lue_BigCate.EditValue = "";
            lueDelayTime.EditValue = "";
            lueWork_Gubun.EditValue = "";
        }

        #region 부서/사원 세팅 ★★★★★★★★★★★★★
        /// <summary>
        /// 부서/사원 세팅
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
            setLue(luePro_Dept, 0, "", "부서코드", "부서명");
        }

        private void luePro_Dept_EditValueChanged(object sender, EventArgs e)
        {
            luePro_User.EditValue = "";
            setLue(luePro_User, 1, luePro_Dept.EditValue.ToString(), "사번", "한글성명");
            if (luePro_Dept.EditValue == "")
            {
                luePro_User.EditValue = "";
            }
        }
        #endregion


        #region 업종구분 세팅 ★★★★★★★★★★★★★
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

                lueWork_Gubun.Properties.ValueMember = "업종코드";
                lueWork_Gubun.Properties.DisplayMember = "업종명";

                lue_BigCate.Properties.ValueMember = "대분류코드";
                lue_BigCate.Properties.DisplayMember = "대분류명";

                lueDelayTime.Properties.ValueMember = "지연시간";
                lueDelayTime.Properties.DisplayMember = "지연시간명";

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    return;
                }
                lueWork_Gubun.Properties.DataSource = ds.Tables[0];
                lue_BigCate.Properties.DataSource = ds.Tables[1];
                lueDelayTime.Properties.DataSource = ds.Tables[2];
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


        #region 조회 버튼 ★★★★★★★★★★★★★
        /// <summary>
        /// 조회 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATELIST_SELECT";
            db.Procedure.ParamAdd("@RecvStartDate", deStart_Date.Text.Replace("-", "").Replace("-", ""));
            db.Procedure.ParamAdd("@RecvEndDate", deEnd_Date.Text.Replace("-", "").Replace("-", ""));
            db.Procedure.ParamAdd("@DeptCode", luePro_Dept.EditValue == null ? "" : luePro_Dept.EditValue);
            db.Procedure.ParamAdd("@UserID", luePro_User.EditValue == null ? "" : luePro_User.EditValue);
            db.Procedure.ParamAdd("@Industry", lueWork_Gubun.EditValue == null ? "" : lueWork_Gubun.EditValue);
            db.Procedure.ParamAdd("@DeptCode_Login", strDeptCode);
            db.Procedure.ParamAdd("@Category", lue_BigCate.EditValue == null ? "" : lue_BigCate.EditValue);
            db.Procedure.ParamAdd("@DelayTime", lueDelayTime.EditValue == null ? "" : lueDelayTime.EditValue);

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = db.ProcedureToDataSet();
                this.Cursor = Cursors.Default;

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    XtraMessageBox.Show("조회할 항목이 없습니다.");
                    return;
                }
                ds.Tables[0].DefaultView.Sort = ds.Tables[1].Rows[0]["Sortfield"].ToString();
                dt_Work = ds.Tables[0];
                gcStateList.DataSource = ds.Tables[0];
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

        #region 더블클릭시 상세페이지 이동 ★★★★★★★★★★★★★
        private void gvStateList_DoubleClick(object sender, EventArgs e)
        {
            string strRegDate = gvStateList.GetFocusedRowCellValue("접수일자").ToString();
            string strRegNum = gvStateList.GetFocusedRowCellValue("접수순번").ToString();
            string strRegUser = gvStateList.GetFocusedRowCellValue("접수사원").ToString();

            //VOC_DivideMng VW = new VOC_DivideMng(strUserID, strDeptCode, strCustCode, dt_Work, strRegNum);
            VOC_DivideMng VW = new VOC_DivideMng(strUserID, strDeptCode, strRegDate, strRegNum, strRegUser);
            VW.StartPosition = FormStartPosition.CenterParent;
            VW.ShowDialog();
            int iRow = gvStateList.FocusedRowHandle;
            btnSearch_ItemClick(null, null);
            gvStateList.FocusedRowHandle = iRow;
        }
        #endregion


        #region indicator ★★★★★★★★★★★★★
        private void gvStateList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        #endregion

        private void gvStateList_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridView = ((GridView)sender);
            if (!gridView.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
            SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
            gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 21;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            VOC_StateList _OVOC_StateList = new VOC_StateList();
            _OVOC_StateList.ExportToExcel(gcStateList, strUserID);
           
        }

    }
}
