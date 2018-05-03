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
using DevExpress.XtraGrid.Views.Grid;
using CES.FUNCTION;
using System.Diagnostics;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Cesco.FW.Global.Util;

namespace VOC_LIST
{
    public partial class VOC_StateList : DevExpress.XtraEditors.XtraUserControl
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
        string strPart = "";

        bool bResult = false; // 디테일 그리드 전체 열기 / 닫기를 위한 전역 변수
        bool sResult = false;
  
        Cesco.FW.Global.Util.Common.CesnetUserAuthInfo _cesnetUserInfo = new Cesco.FW.Global.Util.Common.CesnetUserAuthInfo();

        DataSet dsSource = new DataSet();

        DataTable dt_Work = new DataTable();
        DataTable dtListH = new DataTable();
        //DataTable dtListD = new DataTable();
        #endregion

        public VOC_StateList()
        {
            InitializeComponent();
        }
        public VOC_StateList(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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
            _cesnetUserInfo.UserNo = pUserID;
        }

        private void VOC_State_Load(object sender, EventArgs e)
        {

            setlueDept();
            setlueWork_Gubun();
            setDate();
            //setLue();
            luePro_Dept.EditValue = strDeptCode;
            luePro_Part.EditValue = strPart;
            luePro_User.EditValue = strUserID;

            //if (strExcelAuth == "Y")
            //    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //else
            //    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //2017.12.14 전산업무 요청서 처리
            //B31 지사장 B33	지사팀장 B34	지사팀장보 B35 지사파트장 B44 SM
            if (Convert.ToInt32(strDeptCode) >= 10280 && Convert.ToInt32(strDeptCode) < 50030)
            {
                strAuth = "D";
                if (_cesnetUserInfo.UserInfo.ResponOfOfficeCode == "B31" || _cesnetUserInfo.UserInfo.ResponOfOfficeCode == "B33"
                    || _cesnetUserInfo.UserInfo.ResponOfOfficeCode == "B34" || _cesnetUserInfo.UserInfo.ResponOfOfficeCode == "B35"
                    || _cesnetUserInfo.UserInfo.ResponOfOfficeCode == "B44")
                {
                    luePro_Dept.Enabled = false;
                    luePro_User.Enabled = true;
                    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    luePro_Dept.Enabled = false;
                    luePro_User.Enabled = true;
                    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
            else if(Convert.ToInt32(strDeptCode) >= 51000 && Convert.ToInt32(strDeptCode) <= 59000)
            {
                strAuth = "D";
                Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

                db.Procedure.ProcedureName = "CESNET2.dbo.SP_DEPT_SEARCH_Include";
                db.Procedure.ParamAdd("@부서코드", strDeptCode);

                try
                {
                    DataSet ds = db.ProcedureToDataSet();

                    luePro_Dept.Properties.ValueMember = "부서코드";
                    luePro_Dept.Properties.DisplayMember = "부서명";
                    if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                    {
                        // XtraMessageBox.Show("조회된 데이터가 없습니다.");
                        return;
                    }
                    luePro_Dept.Properties.DataSource = ds.Tables[0];
                }
                catch (Cesco.FW.Global.DBAdapter.WcfException ex)
                {
                    MessageBox.Show(ex.Message, "DB 에러");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "처리되지 않은 에러");
                }
                luePro_Dept.EditValue = strDeptCode;
                luePro_User.EditValue = strUserID;
                luePro_Dept.Enabled = true;
                luePro_User.Enabled = true;
            }
            else
            {
                strAuth = "H";
                luePro_Dept.Enabled = true;
                luePro_User.Enabled = true;
            }

            Cesco.FW.Global.DevExpressUtil.Grid.ViewToDataTable vtt = new Cesco.FW.Global.DevExpressUtil.Grid.ViewToDataTable();

            dtListH = vtt.GetDataTable(gvStateList);
            //dtListD = vtt.GetDataTable(gvStateListD);

            //tListD.TableName = "Detail";

            dsSource = new DataSet();
            dsSource.Tables.AddRange(new DataTable[] { dtListH });

            DataColumn[] dColumns = new DataColumn[] { dtListH.Columns[gridColumn21.FieldName] };
            //DataColumn[] dColumns_D = new DataColumn[] { dtListD.Columns[gridColumn27.FieldName]} ;
            //dsSource.Relations.Add("Detail", dColumns, dColumns_D, false);

            DataView dv = new DataView(dtListH);

            gcStateList.DataSource = dv;
        }
       

        private void setDate()
        {
            deStart_Date.EditValue = DateTime.Now;
            deEnd_Date.EditValue = DateTime.Now;
        }

        private void setLue()
        {
            luePro_Dept.EditValue = "";
            luePro_Part.EditValue = "";
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
                   // XtraMessageBox.Show("조회된 데이터가 없습니다.");
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
            setLue(luePro_Dept, 0, "", "부서코드", "부서명", "");
        }

        private void luePro_Dept_EditValueChanged(object sender, EventArgs e)
        {
            if (luePro_Dept.EditValue.ToString() == "")
            {
                luePro_Part.EditValue = "";
                luePro_User.EditValue = "";
            }
            setLue(luePro_Part, 3, luePro_Dept.EditValue.ToString(), "파트코드", "파트명", "");
            luePro_Part_EditValueChanged(null, null);
            luePro_Part.ItemIndex = 0;
        }
        #endregion

        private void luePro_Part_EditValueChanged(object sender, EventArgs e)
        {
            setLue(luePro_User, 1, luePro_Dept.EditValue.ToString(), "사번", "한글성명", Convert.ToString(luePro_Part.EditValue));

            DataTable dtList = luePro_User.Properties.DataSource as DataTable;
            int iCount = 0;

            foreach (DataRow dRow in dtList.Select("사번 = '" + strUserID + "'"))
            {
                iCount++;
            }

            if (iCount > 0)
                luePro_User.EditValue = strUserID;
            else
                luePro_User.ItemIndex = 0;
        }


        #region 업종구분 세팅 ★★★★★★★★★★★★★
        /// <summary>
        /// 업종구분 LUE 세팅
        /// </summary>
        private void setlueWork_Gubun()
        {
           
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_GUBUN_SELECT_SDH";
             try
             {
                DataSet ds = db.ProcedureToDataSet();

                lueWork_Gubun.Properties.ValueMember = "업종코드";
                lueWork_Gubun.Properties.DisplayMember = "업종명";

                lue_BigCate.Properties.ValueMember = "대분류코드";
                lue_BigCate.Properties.DisplayMember = "대분류명";

                //lueDelayTime.Properties.ValueMember = "지연시간";
                //lueDelayTime.Properties.DisplayMember = "지연시간명";

                lueProState.Properties.ValueMember = "코드구분";
                lueProState.Properties.DisplayMember = "코드명";

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    return;
                }
                lueWork_Gubun.Properties.DataSource = ds.Tables[0];
                lue_BigCate.Properties.DataSource = ds.Tables[1];
                //lueDelayTime.Properties.DataSource = ds.Tables[2];
                lueProState.Properties.DataSource = ds.Tables[5];
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
            //db.Procedure.Procedure-Name = "CESCOEIS.dbo.SP_VOC_STATELIST_ADDPROSTATE_SELECT"; //SP_VOC_STATELIST_SELECT -- 지연시간 조회추가된 프로시저
            db.Procedure.ProcedureName = "CESCOEIS.dbo.USP_VOC_PROCESS_Ver1";
            db.Procedure.ParamAdd("@RecvStartDate", deStart_Date.Text.Replace("-", "").Replace("-", ""));
            db.Procedure.ParamAdd("@RecvEndDate", deEnd_Date.Text.Replace("-", "").Replace("-", ""));
            db.Procedure.ParamAdd("@DeptCode", luePro_Dept.EditValue == null ? "" : luePro_Dept.EditValue);
            db.Procedure.ParamAdd("@UserID", luePro_User.EditValue == null ? "" : luePro_User.EditValue);
            db.Procedure.ParamAdd("@Industry", lueWork_Gubun.EditValue == null ? "" : lueWork_Gubun.EditValue);
            db.Procedure.ParamAdd("@DeptCode_Login", strDeptCode);
            db.Procedure.ParamAdd("@Category", lue_BigCate.EditValue == null ? "" : lue_BigCate.EditValue);
            db.Procedure.ParamAdd("@ProState", lueProState.EditValue == null ? "" : lueProState.EditValue);
            db.Procedure.ParamAdd("@PartCode", luePro_Part.EditValue == null ? "" : luePro_Part.EditValue);

            // db.Procedure.ParamAdd("@DelayTime", lueDelayTime.EditValue == null ? "" : lueDelayTime.EditValue);

            try
            {
                this.Cursor = Cursors.WaitCursor;
                //DateTime de = DateTime.Now;
                DataSet ds = db.ProcedureToDataSet();

                if (ds.Tables.Count > 0)
                {
                    dtListH.Clear();
                    dtListH.Merge(ds.Tables[0]);
                    dtListH.AcceptChanges();
                    //dtListD.Clear();
                    //dtListD.Merge(ds.Tables[1]);
                }

                //if (ds.Tables[1].Rows.Count > 0)
                //{
                //    int iCount = 0;
                //    foreach (DataRow dRow in dtListD.Rows)
                //    {
                //        if (dRow["접수번호"].ToString() != "")
                //        {
                //            gvStateList.SetMasterRowExpanded(iCount, true);
                //        }

                //        iCount += 1;
                //    }

                //}


            }
            catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            {
                MessageBox.Show(ex.Message, "DB 에러");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "처리되지 않은 에러");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }
        #endregion



        #region 더블클릭시 상세페이지 이동 ★★★★★★★★★★★★★
        private void gvStateList_DoubleClick(object sender, EventArgs e)
        {
            //e.ToString();
        }
        #endregion

        private void gvStateList_PopUp(DataRow pRow, int iRow)
        {
            string strRegDate = pRow["접수일자"].ToString();
            string strRegNum = pRow["접수번호"].ToString();
            string strRegUser = pRow["접수사원"].ToString();
            string strCustCode = pRow["고객코드"].ToString();
            string strVCNO = pRow["클레임번호"].ToString();
            string strVCTP = pRow["대분류"].ToString();
            string strPartCode = pRow["PartCode"].ToString();
            this.Cursor = Cursors.WaitCursor;
            VOC_ProcessMng VW = new VOC_ProcessMng(strUserID, strDeptCode, strRegDate, strRegNum, strRegUser, strCustCode, strAuth, strVCNO, strVCTP, "");
            VW.StartPosition = FormStartPosition.CenterParent;
            VW.Show();
            this.Cursor = Cursors.Default;
            btnSearch_ItemClick(null, null);
            gvStateList.FocusedRowHandle = iRow;
            //gvStateList.SetMasterRowExpanded(iRow, true);
            //sResult = true;
        }

        #region indicator ★★★★★★★★★★★★★
        private void gvStateList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        #endregion


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


                        CommonFunc.CesnetFasooDrm drm = new CommonFunc.CesnetFasooDrm();

                        //if (fasoo.FSDEncryption(oSaveFileDialog.FileName, oSaveFileDialog.FileName, "DevExpress 엑셀변환 자료", userId))
                        //{
                        if (drm.CESNET2Encryption(oSaveFileDialog.FileName, oSaveFileDialog.FileName, "DevExpress", userId, "0", "", "USP_DRM_CM_FasooDRM_FSN"))
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvStateList.RowCount < 0)
               return;
            Cesco.FW.Global.DevExpressUtil.Grid.ConvertExcel cExcel = new Cesco.FW.Global.DevExpressUtil.Grid.ConvertExcel();

            string cExcelName = string.Empty;

            cExcelName = cExcel.GridToExcelReturnName(gcStateList, strUserID);

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(cExcelName);

            p.StartInfo = psi;
            p.Start();
        }

        private void gvStateList_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridView = ((GridView)sender);
            if (!gridView.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
            SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
            gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 21;
        }

        private void gvStateList_MouseMove(object sender, MouseEventArgs e)
        {
            GridHitInfo hi = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));
            if (hi.InRowCell && hi.Column.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit)
            {
                Cursor = System.Windows.Forms.Cursors.Hand;
            }
            else
                Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void gvStateList_MouseLeave(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            ColumnView detailView = (ColumnView)gvStateList.GetDetailView(gvStateList.FocusedRowHandle, 0);
            int detailRowHandle = detailView.FocusedRowHandle;
            DataRow row = detailView.GetDataRow(detailRowHandle);

            gvStateList_PopUp(row, gvStateList.FocusedRowHandle);
        }

        private void gvStateListD_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvStateListD_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column == gridColumn32)
                e.Value = "->";
        }

        private void gvStateListD_DoubleClick(object sender, EventArgs e)
        {
            bool detailViewHasFocus = gcStateList.FocusedView.IsDetailView;

            if (detailViewHasFocus)
                gvStateList.FocusedRowHandle = gcStateList.FocusedView.SourceRowHandle;

            FocusMainView();

            ColumnView detailView = (ColumnView)gvStateList.GetDetailView(gvStateList.FocusedRowHandle, 0);
            int detailRowHandle = detailView.FocusedRowHandle;
            DataRow row = detailView.GetDataRow(detailRowHandle);

            gvStateList_PopUp(row, gvStateList.FocusedRowHandle);
        }


        private void FocusMainView()
        {
            gcStateList.FocusedView = gvStateList;
            gcStateList.Focus();
        }

        private void gvStateListD_MouseLeave(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void gvStateListD_MouseMove(object sender, MouseEventArgs e)
        {
            GridHitInfo hi = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));
            if (hi.InRowCell && hi.Column.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit)
            {
                Cursor = System.Windows.Forms.Cursors.Hand;
            }
            else
                Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void gvStateListD_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridView = ((GridView)sender);
            if (!gridView.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridView.GridControl.Handle);
            SizeF size = gr.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont());
            gridView.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 21;
        }

        #region 전체 디테일 그리드 열기 / 닫기
        /// <summary>
        /// 전체 디테일 그리드 열기 / 닫기
        /// </summary>
        private void btnOC_Click(object sender, EventArgs e)
        {
            //if (gvStateList.RowCount < 1)
            //    return;

            //int iCount = 0;

            //if (bResult == false)
            //{
            //    foreach (DataRow dRow in dtListD.Rows)
            //    {
            //        if (dRow["접수번호"].ToString() != "")
            //        {
            //            gvStateList.SetMasterRowExpanded(iCount, true);
            //        }

            //        iCount += 1;
            //    }

            //    bResult = true;
            //}

            //else 
            //{
            //    foreach (DataRow dRow in dtListD.Rows)
            //    {
            //        if (dRow["접수번호"].ToString() != "")
            //        {
            //            gvStateList.SetMasterRowExpanded(iCount, false);
            //        }

            //        iCount += 1;
            //    }

            //    bResult = false;
            //}
        }
        #endregion

        #region 더블클릭시 해당 마스터건만 디테일 오픈
        /// <summary>
        /// 더블클릭시 해당 마스터건만 디테일 오픈
        /// </summary>
        private void gvStateList_DoubleClick_1(object sender, EventArgs e)
        {
            if (gvStateList.RowCount < 1)
                return;

            bool detailViewHasFocus = gcStateList.FocusedView.IsFocusedView;

            if (detailViewHasFocus)
                gvStateList.FocusedRowHandle = gcStateList.FocusedView.SourceRowHandle;

            FocusMainView();

            //ColumnView detailView = (ColumnView)gvStateList.GetFOCU(gvStateList.FocusedRowHandle, 0);
            int detailRowHandle = gvStateList.FocusedRowHandle;
            DataRow row = gvStateList.GetDataRow(detailRowHandle);

            gvStateList_PopUp(row, gvStateList.FocusedRowHandle);

            //int iRow = gvStateList.FocusedRowHandle;

            //if (sResult == true)
            //{
            //    gvStateList.SetMasterRowExpanded(iRow, true);
            //    sResult = false;
            //}

            //else
            //{
            //    if (gvStateList.GetMasterRowExpanded(iRow) == true)
            //        gvStateList.SetMasterRowExpanded(iRow, false);
            //    else gvStateList.SetMasterRowExpanded(iRow, true);
            //}
        }
        #endregion


        public void SetColorStyleFormatCondition(GridView gridView, DataTable dt)
        {
            //StyleFormatCondition sfc = new StyleFormatCondition();

            //sfc.Appearance.BackColor2 = Color.CornflowerBlue;
            //sfc.Appearance.BackColor = Color.RoyalBlue;
            //sfc.Appearance.ForeColor = Color.White;

            //sfc.Appearance.Options.UseBackColor = true;
            //sfc.Appearance.Options.UseForeColor = true;
            //sfc.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;

            int iCount = 0;
            int iCnt = 0;

            string[] str = new string[dt.Rows.Count];

            foreach (DataRow row in dt.Rows)
            {
                iCount = 0;
                foreach (DataRow dRow in dt.Rows)
                {
                    if (row["접수번호"].ToString() == dRow["접수번호"].ToString())
                    {
                        iCount++;
                    }
                    if (iCount > 1)
                    {
                        str[iCnt] = row["접수번호"].ToString();
                        iCnt++;
                        break;
                    }
                }
            }

            for (int i = 0; i < iCnt; i++)
            {
                StyleFormatCondition sfc = new StyleFormatCondition();
                sfc.Appearance.BackColor = Color.Yellow;
                sfc.Appearance.Options.UseBackColor = true;
                sfc.Expression = "[" + gridColumn21.FieldName + "] == \'" + str[i] + "\'";
                gridView.FormatConditions.Add(sfc);
            }
        }

        private void luePro_Dept_Click(object sender, EventArgs e)
        {
            luePro_Dept.ShowPopup();
        }

        private void luePro_Part_Click(object sender, EventArgs e)
        {
            luePro_Part.ShowPopup();
        }

        private void luePro_User_Click(object sender, EventArgs e)
        {
            luePro_User.ShowPopup();
        }

        private void lueWork_Gubun_Click(object sender, EventArgs e)
        {
            lueWork_Gubun.ShowPopup();
        }

        private void lue_BigCate_Click(object sender, EventArgs e)
        {
            lue_BigCate.ShowPopup();
        }

        private void lueProState_Click(object sender, EventArgs e)
        {
            lueProState.ShowPopup();
        }
    }
}
