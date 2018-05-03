using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using CES.DbConnection;
using DocManagement;
using DevExpress.XtraTreeList;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;

namespace VOC
{
    public partial class VOC_CategoryStandardManage : DevExpress.XtraEditors.XtraUserControl
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

        DataTable dtAuthAdd2 = new DataTable();
        DataTable dtAuthAdd = new DataTable();

        public VOC_CategoryStandardManage(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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

        #region Load
        private void CategoryStandardManage_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //getCategory();
            getDept();
            getJob();
            //setCategoryList_처리기본();
            setCategoryList();
            //getDept2();
           // rdio_Gubun.EditValue = "J";
            tr_stdMng.FocusedNode = tr_stdMng.Nodes[0];
            tr_stdMng2.FocusedNode = tr_stdMng2.Nodes[0];
            //this.repositoryItemCheckEdit3.ValueChecked = Convert.ToByte(1);
            //this.repositoryItemCheckEdit3.ValueUnchecked = Convert.ToByte(0);
            //tr_stdMng_FocusedNodeChanged(null, null);
            //tr_stdMng2_FocusedNodeChanged(null, null);

            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(this.ClientRectangle.Width, 0);

            Cursor = Cursors.Default;
        }
        #endregion

        #region Top Menu
        private void cesSimpleTopMenu2_ButtonClicked(string barItemName, DevExpress.XtraBars.BarItem barItem, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (barItemName)
            {
                case "Refresh":
                    Cursor = Cursors.WaitCursor;
                    stdRefresh();
                    Cursor = Cursors.Default;
                    break;
                case "Save":
                    try
                    {
                        Cursor = Cursors.WaitCursor;

                        if (xtraTabControl1.SelectedTabPageIndex == 0)
                        {
                            int gvDeptRowHandle = gvDept.FocusedRowHandle;

                            DeleteTB("H");
                            Save1();
                            Save2();
                            Save2_1();
                            Save처리기본Gubun();

                            stdRefresh();

                            gvDept.FocusedRowHandle = gvDeptRowHandle;
                        }
                        else
                        {
                            DeleteTB("");
                            if (!SaveMonitoring()) return;
                            if (!SaveJob()) return;
                        }
                        //stdRefresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                    break;
            }
        }
        #endregion

        #region 저장하기 전 삭제
        private void DeleteTB(string sGubun)
        {
            Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
            dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_DELETE_NEW";
            dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_DELETE_NEW";

            dbA.Procedure.ParamAdd("@DEPTCODE", gvDept.GetFocusedRowCellValue(gridColumn9.FieldName).ToString());
            dbA.Procedure.ParamAdd("@VOCID", sGubun == "H" ? tr_stdMng2.FocusedNode["대분류VOCID"].ToString() : tr_stdMng.FocusedNode["대분류VOCID"].ToString());
            dbA.Procedure.ParamAdd("@GUBUN", sGubun);

            DataSet ds = dbA.ProcedureToDataSet();
        }
        #endregion


        /*#region SaveDe
        private void SaveDe()
        {
            try
            {
                //focus 없으면 메시지박스

                DeleteTB(); //삭제


                Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_SAVE";

                dbA.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                //처리담당자 


                for(int i = 0; i < gv_1.DataRowCount; i++)
                {
                    if (gv_1.GetRowCellValue(i, "선택").ToString() == "Y")
                    {
                        dbA.Procedure.ParamAdd("@JobCode1", gv_1.GetRowCellValue(i, "직책코드").ToString());
                            
                    }
                }

                for(int i=0; i < gv_2.DataRowCount; i++)
                {
                    if (gv_2.GetRowCellValue(i, "선택").ToString() == "Y")
                    {
                        dbA.Procedure.ParamAdd("@DeptCode2", gv_2.GetRowCellValue(i, "부서코드").ToString());
                        dbA.Procedure.ParamAdd("@Sabun2", gv_2.GetRowCellValue(i, "사번").ToString());
                    }
                }

                //기본공유자
                for (int i = 0; i < gv_3.DataRowCount; i++)
                {
                    if (gv_3.GetRowCellValue(i, "선택").ToString() == "Y")
                    {
                        dbA.Procedure.ParamAdd("@JobCode3", gv_3.GetRowCellValue(i, "직책코드").ToString());

                    }
                }

                for (int i = 0; i < gv_4.DataRowCount; i++)
                {
                    if (gv_4.GetRowCellValue(i, "선택").ToString() == "Y")
                    {
                        dbA.Procedure.ParamAdd("@DeptCode4", gv_4.GetRowCellValue(i, "부서코드").ToString());
                        dbA.Procedure.ParamAdd("@Sabun4", gv_4.GetRowCellValue(i, "사번").ToString());
                    }
                }

                //모니터링 기준시간
                dbA.Procedure.ParamAdd("@RecmdHdlTime", text_RecmdHdlTime.Text);
                dbA.Procedure.ParamAdd("@MaxHldTime", text_MaxHldTime.Text);

                //모니터링 기준1
                dbA.Procedure.ParamAdd("@StdTime5", text_StdTime5.Text);
                dbA.Procedure.ParamAdd("@SMS5", chk_SMS5.EditValue);
                dbA.Procedure.ParamAdd("@PUSH5", chk_Push5.EditValue);
                for (int i = 0; i < gv_5.DataRowCount; i++)
                {
                    if (gv_4.GetRowCellValue(i, "선택").ToString() == "Y")
                    {
                        dbA.Procedure.ParamAdd("@JobCode5", gv_5.GetRowCellValue(i, "직책코드").ToString());
                    }
                }

                //모니터링기준2
                dbA.Procedure.ParamAdd("@StdTime6", text_StdTime6.Text);
                dbA.Procedure.ParamAdd("@SMS6", chk_SMS6.EditValue);
                dbA.Procedure.ParamAdd("@PUSH6", chk_Push6.EditValue);
                for (int i = 0; i < gv_6.DataRowCount; i++)
                {
                    if (gv_6.GetRowCellValue(i, "선택").ToString() == "Y")
                    {
                        dbA.Procedure.ParamAdd("@JobCode6", gv_6.GetRowCellValue(i, "직책코드").ToString());
                    }
                }

                //모니터링기준3
                dbA.Procedure.ParamAdd("@StdTime7", text_StdTime7.Text);
                dbA.Procedure.ParamAdd("@SMS7", chk_SMS7.EditValue);
                dbA.Procedure.ParamAdd("@PUSH7", chk_Push7.EditValue);
                for (int i = 0; i < gv_7.DataRowCount; i++)
                {
                    if (gv_7.GetRowCellValue(i, "선택").ToString() == "Y")
                    {
                        dbA.Procedure.ParamAdd("@JobCode7", gv_7.GetRowCellValue(i, "직책코드").ToString());
                    }
                }

                //모니터링기준 미해결 기준
                dbA.Procedure.ParamAdd("@StdTime8", text_StdTime8.Text);
                dbA.Procedure.ParamAdd("@SMS8", chk_SMS8.EditValue);
                dbA.Procedure.ParamAdd("@PUSH8", chk_Push8.EditValue);
                for (int i = 0; i < gv_8.DataRowCount; i++)
                {
                    if (gv_8.GetRowCellValue(i, "선택").ToString() == "Y")
                    {
                        dbA.Procedure.ParamAdd("@JobCode8", gv_8.GetRowCellValue(i, "직책코드").ToString());
                    }
                }

                DataSet ds = dbA.ProcedureToDataSetCompress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("저장 완료하였습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion*/

        #region Refresh
        private void stdRefresh()
        {
            getDept();
            getJob();
            //setCategoryList_처리기본();
            setCategoryList();
            //getDept2();
            //rdio_Gubun.EditValue = "J";
        }
        #endregion

        //#region 대분류 로드
        //private void getCategory()
        //{
        //    Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
        //    dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

        //    dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_SELECT";

        //    DataSet ds = dbA.ProcedureToDataSetCompress();
        //    if (ds == null || ds.Tables[0].Rows.Count < 1)
        //    {
        //        return;
        //    }
        //    gc_stdMng.DataSource = ds.Tables[0];
        //}
        //#endregion

        #region 직책 로드
        private void getJob()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
            dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_JOB_SELECT";

            DataSet ds1 = dbA.ProcedureToDataSetCompress();
            DataSet ds3 = dbA.ProcedureToDataSetCompress();
            DataSet ds5 = dbA.ProcedureToDataSetCompress();
            DataSet ds6 = dbA.ProcedureToDataSetCompress();
            DataSet ds7 = dbA.ProcedureToDataSetCompress();
            DataSet ds8 = dbA.ProcedureToDataSetCompress();
            DataSet ds9 = dbA.ProcedureToDataSetCompress();

            gc_1.DataSource = ds1.Tables[1];
            gc_3.DataSource = ds3.Tables[1];
            gc_5.DataSource = ds5.Tables[0];
            gc_6.DataSource = ds6.Tables[0];
            gc_7.DataSource = ds7.Tables[0];
            gc_8.DataSource = ds8.Tables[0];
            gc_9.DataSource = ds9.Tables[0];
            gc_Max.DataSource = ds8.Tables[0];
        }
        #endregion

        #region
        private void getJob2()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
            dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_JOB_SELECT";

            DataSet ds1 = dbA.ProcedureToDataSetCompress();
            //DataSet ds3 = dbA.ProcedureToDataSetCompress();
            //DataSet ds5 = dbA.ProcedureToDataSetCompress();
            //DataSet ds6 = dbA.ProcedureToDataSetCompress();
            //DataSet ds7 = dbA.ProcedureToDataSetCompress();
            //DataSet ds8 = dbA.ProcedureToDataSetCompress();
            gc_1.DataSource = ds1.Tables[0];
        }
        #endregion

        #region 부서 로드
        private void getDept()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
            dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_DEPT_SELECT";
            dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_DEPT_SELECT_NEW";
           
            //DataSet ds2 = dbA.ProcedureToDataSetCompress();
            DataSet ds4 = dbA.ProcedureToDataSetCompress();
            //gc_2.DataSource = ds2.Tables[0];
            //gc_4.DataSource = ds4.Tables[0];

            gcDept.DataSource = ds4.Tables[0];
            gc_4.DataSource = ds4.Tables[1];
        }
        #endregion

        #region
        //#region 부서 로드1
        //private void getDept1()
        //{
        //    Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
        //    dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

        //    dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_PERSON_SELECT";
        //    dbA.Procedure.ParamAdd("@DeptCode", "");

        //    DataSet ds2 = dbA.ProcedureToDataSetCompress();

        //    gc_2.DataSource = ds2.Tables[0];
        //    getDept2();
        //}
        //#endregion


        //#region 부서 로드2
        //private void getDept2()
        //{
        //    Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
        //    dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

        //    dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_PERSON_SELECT";
        //    //dbA.Procedure.ParamAdd("@DeptCode", gv_2.GetFocusedRowCellValue(col부서코드.FieldName).ToString());

        //    DataSet ds2 = dbA.ProcedureToDataSetCompress();
            
        //    gc_2.DataSource = ds2.Tables[0];
            
        //    repositoryItemLookUpEdit1.DisplayMember = "한글성명";
        //    repositoryItemLookUpEdit1.ValueMember = "사번";
        //    repositoryItemLookUpEdit1.DataSource = ds2.Tables[0];

        //}
        //#endregion

        //private void Time(int 시간, int 분)
        //{
        //    //int 입력분 = Convert.ToInt32(txtTime.Text);
        //    //int 시간 = (입력분 / 60);
        //    //int 분 = 입력분 - (입력분 / 60 * 60);

        //    //if (시간.ToString().Length == 1)
        //    //{
        //    //    시간 = 0 + 시간;
        //    //}
        //    //if (분.ToString().Length == 1)
        //    //{
        //    //    분 = 0 + 분;
        //    //}
        //    string tmp1 = string.Empty;
        //    string tmp2 = string.Empty;
        //    tmp1 = Convert.ToString(시간);
        //    tmp2 = Convert.ToString(분);
        //    lb_RecmdHdlHour.Text = tmp1;
        //    lb_RecmdHdlMinute.Text = tmp2;
        //}
        #endregion

        #region 시간 계산
        private void TimeCal1(DevExpress.XtraEditors.TextEdit txtTime)
        {
            int 입력분 = Convert.ToInt32(txtTime.Text);
            int 시간 = (입력분 / 60);
            int 분 = 입력분 - (입력분 / 60 * 60);

            if (시간.ToString().Length == 1)
            {
                시간 = 0 + 시간;
            }
            if (분.ToString().Length == 1)
            {
                분 = 0 + 분;
            }
            string tmp1 = string.Empty;
            string tmp2 = string.Empty;

            tmp1 = Convert.ToString(시간);
            tmp2 = Convert.ToString(분);
            lb_RecmdHdlHour.Text = tmp1;
            lb_RecmdHdlMinute.Text = tmp2;
        }

        private void TimeCal2(DevExpress.XtraEditors.TextEdit txtTime)
        {
            int 입력분 = Convert.ToInt32(txtTime.Text);
            int 시간 = (입력분 / 60);
            int 분 = 입력분 - (입력분 / 60 * 60);

            if (시간.ToString().Length == 1)
            {
                시간 = 0 + 시간;
            }
            if (분.ToString().Length == 1)
            {
                분 = 0 + 분;
            }
            string tmp1 = string.Empty;
            string tmp2 = string.Empty;

            tmp1 = Convert.ToString(시간);
            tmp2 = Convert.ToString(분);
            lb_MaxHdlHour.Text = tmp1;
            lb_MaxHdlTime.Text = tmp2;
        }

        private void TimeCal3(DevExpress.XtraEditors.TextEdit txtTime)
        {
            int 입력분 = Convert.ToInt32(txtTime.Text);
            int 시간 = (입력분 / 60);
            int 분 = 입력분 - (입력분 / 60 * 60);

            if (시간.ToString().Length == 1)
            {
                시간 = 0 + 시간;
            }
            if (분.ToString().Length == 1)
            {
                분 = 0 + 분;
            }
            string tmp1 = string.Empty;
            string tmp2 = string.Empty;

            tmp1 = Convert.ToString(시간);
            tmp2 = Convert.ToString(분);
            lb_HTime5.Text = tmp1;
            lb_MTime5.Text = tmp2;
        }

        private void TimeCal4(DevExpress.XtraEditors.TextEdit txtTime)
        {
            int 입력분 = Convert.ToInt32(txtTime.Text);
            int 시간 = (입력분 / 60);
            int 분 = 입력분 - (입력분 / 60 * 60);

            if (시간.ToString().Length == 1)
            {
                시간 = 0 + 시간;
            }
            if (분.ToString().Length == 1)
            {
                분 = 0 + 분;
            }
            string tmp1 = string.Empty;
            string tmp2 = string.Empty;

            tmp1 = Convert.ToString(시간);
            tmp2 = Convert.ToString(분);
            lb_HTime6.Text = tmp1;
            lb_MTime6.Text = tmp2;
        }

        private void TimeCal5(DevExpress.XtraEditors.TextEdit txtTime)
        {
            int 입력분 = Convert.ToInt32(txtTime.Text);
            int 시간 = (입력분 / 60);
            int 분 = 입력분 - (입력분 / 60 * 60);

            if (시간.ToString().Length == 1)
            {
                시간 = 0 + 시간;
            }
            if (분.ToString().Length == 1)
            {
                분 = 0 + 분;
            }
            string tmp1 = string.Empty;
            string tmp2 = string.Empty;

            tmp1 = Convert.ToString(시간);
            tmp2 = Convert.ToString(분);
            lb_HTime7.Text = tmp1;
            lb_MTime7.Text = tmp2;
        }


        private void TimeCal6(DevExpress.XtraEditors.TextEdit txtTime)
        {
            int 입력분 = Convert.ToInt32(txtTime.Text);
            int 시간 = (입력분 / 60);
            int 분 = 입력분 - (입력분 / 60 * 60);

            if (시간.ToString().Length == 1)
            {
                시간 = 0 + 시간;
            }
            if (분.ToString().Length == 1)
            {
                분 = 0 + 분;
            }
            string tmp1 = string.Empty;
            string tmp2 = string.Empty;

            tmp1 = Convert.ToString(시간);
            tmp2 = Convert.ToString(분);
            lb_HTime8.Text = tmp1;
            lb_MTime8.Text = tmp2;
        }
    #endregion
    
        #region 권장처리시간 시간변환
        private void MinuteToHour()
        {
            TimeCal1(text_RecmdHdlTime);
        }
        #endregion

        #region MAX처리시간 시간변환
        private void MinuteToHour2()
        {
            TimeCal2(text_MaxHldTime);
        }
        #endregion

        #region 모니터링 기준1 시간 변환
        private void MinuteToHour3()
        {
            TimeCal3(text_StdTime5);
        }
        #endregion

        #region 모니터링 기준2 시간 변환
        private void MinuteToHour4()
        {
            TimeCal4(text_StdTime6);
        }
        #endregion

        #region 모니터링 기준3 시간 변환
        private void MinuteToHour5()
        {
            TimeCal5(text_StdTime7);
        }
        #endregion

        #region 모니터링 미해결 시간 변환
        private void MinuteToHour6()
        {
            TimeCal6(text_StdTime8);
        }
        #endregion

        #region 권장처리시간 Enter
        private void text_RecmdHdlTime_KeyDown(object sender, KeyEventArgs e)
        {
            //int 받아온분 = Convert.ToInt32(text_RecmdHdlTime.Text);
            //int 시간 = 받아온분 / 60; //시간
            //int 분 = 받아온분 - (받아온분 / 60 * 60);

            if (e.KeyCode == Keys.Enter)
            {
                MinuteToHour();
            }
        }
        #endregion

        #region MAX처리시간 Enter
        private void text_MaxHldTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MinuteToHour2();
            }
        }
        #endregion

        #region 모니터링 기준1 Enter
        private void text_StdTime5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MinuteToHour3();
            }
        }
        #endregion

        #region 모니터링 기준2 Enter
        private void text_StdTime6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MinuteToHour4();
            }
        }
        #endregion

        #region 모니터링 기준3 Enter
        private void text_StdTime7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MinuteToHour5();
            }
        }
        #endregion

        #region 모니터링 미해결 기준 Enter
        private void text_StdTime8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MinuteToHour6();
            }
        }
        #endregion

        #region 직책, 부서 Radio
        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            //if (rdio_Gubun.EditValue.Equals("J"))
            //{
            //    gc_1.Enabled = true;
            //    gc_2.Enabled = false;
            //    text_SabunName.Enabled = false;
            //    btn_Add.Enabled = false;
            //    btn_Delete.Enabled = false;
            //    getJob();
            //}
            //else
            //{
            //    gc_1.Enabled = false;
            //    gc_2.Enabled = true;
            //    text_SabunName.Enabled = true;
            //    btn_Add.Enabled = true; ;
            //    btn_Delete.Enabled = true;
            //    if (gv_2.RowCount > 0)
            //    {
            //        text_SabunName.Enabled = false;
            //        btn_Add.Enabled = false;
            //    }
            //    else
            //    {
            //        text_SabunName.Enabled = true;
            //        btn_Add.Enabled = true;
            //    }
            //}
        }
        #endregion

        #region textbox Enter
        private void text_SabunName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Add_Click(null, null);
            }
        }
        #endregion

        #region 추가
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //if (gv_2.DataSource != null)
            //{
            //    DataRow[] rows_Y = (gc_2.DataSource as DataTable).Select("사번=" + "'" + text_SabunName.Text + "'");
            //    if (rows_Y.Length > 0)
            //    {
            //        MessageBox.Show("이미 권한이 추가된 사원입니다.", "사원 중복", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //}
            //if (gv_2.RowCount > 0)
            //{
            //    text_SabunName.Enabled = false;
            //    btn_Add.Enabled = false;
            //    return;
            //}
            //else
            //{
            //    text_SabunName.Enabled = true;
            //    btn_Add.Enabled = true;
            //}

            //dtAuthAdd2 = gc_2.DataSource as DataTable;
            //dtAuthAdd = gc_2.DataSource as DataTable;

            //DbConn conn = new DbConn();
            //conn.ProcedureName = "ASSI.dbo.SP_CategoryMng_AuthMng_Category_AddUser";
            //conn.ParamAdd("@UserNmID", text_SabunName.Text);
            //DataSet ds = conn.ExecProcedure();
            //if (ds.Tables[0].Rows.Count > 1)
            //{
            //    VOC_UserCheck UC = new VOC_UserCheck(text_SabunName.Text, gc_2.DataSource as DataTable);
            //    UC.StartPosition = FormStartPosition.CenterParent;
            //    UC.ShowDialog();

            //    if (dtAuthAdd == null)
            //    {
            //        dtAuthAdd = new DataTable("dtAuthAdd");
            //        dtAuthAdd.Columns.Add("한글성명", Type.GetType("System.String"));
            //        dtAuthAdd.Columns.Add("사번", Type.GetType("System.String"));
            //        dtAuthAdd.Columns.Add("부서코드", Type.GetType("System.String"));
            //        dtAuthAdd.Columns.Add("부서명", Type.GetType("System.String"));
            //        //dtAuthAdd.Columns.Add("공유자", Type.GetType("System.String"));
            //    }
            //    DataRow dRow = dtAuthAdd.NewRow();
            //    dRow["한글성명"] = UC.str_CheckedUser;
            //    dRow["사번"] = UC.str_CheckedUserID;
            //    dRow["부서코드"] = UC.str_CheckedUserDeptCode;
            //    dRow["부서명"] = UC.str_CheckedUserDept;
            //    //dRow["공유자"] = strUserNm;


            //    if (dtAuthAdd2 == null)
            //    {
            //        dtAuthAdd.Rows.Add(dRow);
            //        gc_2.DataSource = dtAuthAdd;
            //        text_SabunName.Text = "";
            //    }
            //    else
            //    {
            //        DataRow[] drows = dtAuthAdd2.Select(string.Format("사번 = '" + ds.Tables[0].Rows[0]["사번"].ToString() + "'")); //중복 검사

            //        if (drows != null && drows.Length > 0)
            //        {
            //            dtAuthAdd2.Rows.Remove(drows[0]);
            //        }
            //        dtAuthAdd.Rows.Add(dRow);
            //        dtAuthAdd2.Merge(dtAuthAdd);
            //        gc_2.DataSource = dtAuthAdd2;
            //        text_SabunName.Text = "";
            //    }

            //}
            //else
            //{
            //    if (ds.Tables[0].Rows.Count < 1 || ds == null)
            //    {
            //        MessageBox.Show("조회 가능한 직원이 없습니다.", "조회 불가", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    if (dtAuthAdd == null)
            //    {
            //        dtAuthAdd = new DataTable("dtAuthAdd");
            //        dtAuthAdd.Columns.Add("한글성명", Type.GetType("System.String"));
            //        dtAuthAdd.Columns.Add("사번", Type.GetType("System.String"));
            //        dtAuthAdd.Columns.Add("부서코드", Type.GetType("System.String"));
            //        dtAuthAdd.Columns.Add("부서명", Type.GetType("System.String"));
            //        dtAuthAdd.Columns.Add("공유자", Type.GetType("System.String"));
            //    }

            //    DataRow dRow = dtAuthAdd.NewRow();
            //    dRow["한글성명"] = ds.Tables[0].Rows[0]["한글성명"].ToString();
            //    dRow["사번"] = ds.Tables[0].Rows[0]["사번"].ToString();
            //    dRow["부서코드"] = ds.Tables[0].Rows[0]["부서코드"].ToString();
            //    dRow["부서명"] = ds.Tables[0].Rows[0]["부서명"].ToString();
            //    //dRow["공유자"] = strUserNm;

            //    if (dtAuthAdd2 == null)
            //    {
            //        dtAuthAdd.Rows.Add(dRow);
            //        gc_2.DataSource = dtAuthAdd;
            //    }
            //    else
            //    {
            //        DataRow[] drows = dtAuthAdd2.Select(string.Format("사번 = '" + ds.Tables[0].Rows[0]["사번"].ToString() + "'")); //중복 검사

            //        if (drows != null && drows.Length > 0)
            //        {
            //            dtAuthAdd2.Rows.Remove(drows[0]);
            //        }

            //        dtAuthAdd.Rows.Add(dRow);
            //        dtAuthAdd2.Merge(dtAuthAdd);
            //        gc_2.DataSource = dtAuthAdd2;

            //    }
            //    text_SabunName.Text = "";
            //}
        }
        #endregion

        #region TreeView
        private void setCategoryList()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            //db.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_SELECT_NEW";
            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_SELECT_NEW";
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                db.Procedure.ParamAdd("@DEPTCODE", gvDept.GetFocusedRowCellValue(gridColumn9.FieldName).ToString());
            }

            try
            {
                DataSet ds = db.ProcedureToDataSet();

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    XtraMessageBox.Show("조회된 데이터가 없습니다.");
                    return;
                }

                tr_stdMng.DataSource = null;
                tr_stdMng2.DataSource = null;

                tr_stdMng.ParentFieldName = "대분류PARENTID";
                tr_stdMng.KeyFieldName = "대분류VOCID";

                tr_stdMng.DataSource = ds.Tables[0];
                tr_stdMng.ExpandAll();


                tr_stdMng2.ParentFieldName = "대분류PARENTID";
                tr_stdMng2.KeyFieldName = "대분류VOCID";

                tr_stdMng2.DataSource = ds.Tables[0];
                tr_stdMng2.ExpandAll();
            }
            catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            {
                MessageBox.Show(ex.Message, "DB 에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "처리되지 않은 에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 삭제
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //if (dtAuthAdd2.Rows.Count < 1)
            //{
            //    return;
            //}
            //else
            //{
                //dtAuthAdd2.Rows.Remove(gv_2.GetFocusedDataRow());
                //gc_2.DataSource = null;
                //text_SabunName.Enabled = true;
                //btn_Add.Enabled = true;

            //}
        }
        #endregion

        private void text_SabunName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (gv_2.RowCount > 0)
            //{
            //    text_SabunName.Enabled = false;
            //    btn_Add.Enabled = false;
            //}
            //else
            //{
            //    text_SabunName.Enabled = true;
            //    btn_Add.Enabled = true;
            //}
        }

        #region 처리담당자 저장
        private void Save1()
        {
            labelControl6.Focus();
            try
            {
                gv_1.PostEditor();
                gv_1.UpdateCurrentRow();
               
 
                DataTable dt = gc_1.DataSource as DataTable;
                DataRow[] dRow = (gc_1.DataSource as DataTable).Select("선택=" + "'" + "Y" + "'");

                if (dRow.Length < 1)
                {
                    MessageBox.Show("선택된 처리담당자가 없습니다.");
                    return;
                }
                else
                {
                    //처리담당자 
                    for (int i = 0; i < dRow.Length; i++)
                    {
                        Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                        dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                        //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_1_SAVE_NEW";
                        dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_1_SAVE_NEW";

                        dbA.Procedure.ParamAdd("@DEPTCODE", gvDept.GetFocusedRowCellValue(gridColumn9.FieldName).ToString());
                        dbA.Procedure.ParamAdd("@DEPTNAME", gvDept.GetFocusedRowCellValue(gridColumn8.FieldName).ToString());
                        dbA.Procedure.ParamAdd("@VOCID", tr_stdMng2.FocusedNode["대분류VOCID"].ToString());
                        dbA.Procedure.ParamAdd("@JobCode", dRow[i]["직책코드"].ToString());
                        dbA.Procedure.ParamAdd("@Sabun", "");
                        dbA.Procedure.ParamAdd("@ChkReceipt", dRow[i]["접수알림"].ToString());
                        dbA.Procedure.ParamAdd("@ChkLate", dRow[i]["지연알림"].ToString());
                        DataSet ds = dbA.ProcedureToDataSetCompress();
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region 기본공유자 저장
        private void Save2()
        {
            try
            {
                gv_3.PostEditor();
                gv_3.UpdateCurrentRow();
                DataRow[] dRow = (gc_3.DataSource as DataTable).Select("선택= 'Y'");
                for (int i = 0; i < dRow.Length; i++)
                {
                    Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                    dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                    //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_2_SAVE_NEW";
                    dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_2_SAVE_NEW";

                    //기본공유자
                    dbA.Procedure.ParamAdd("@DEPTCODE", gvDept.GetFocusedRowCellValue(gridColumn9.FieldName).ToString());
                    dbA.Procedure.ParamAdd("@DEPTNAME", gvDept.GetFocusedRowCellValue(gridColumn8.FieldName).ToString());
                    dbA.Procedure.ParamAdd("@VOCID", tr_stdMng2.FocusedNode["대분류VOCID"].ToString());
                    dbA.Procedure.ParamAdd("@JobCode3", dRow[i]["직책코드"].ToString());
                    dbA.Procedure.ParamAdd("@DeptCode4", "");
                    dbA.Procedure.ParamAdd("@Sabun4", "");
                    dbA.Procedure.ParamAdd("@ChkReceipt", dRow[i]["접수알림"].ToString());
                    dbA.Procedure.ParamAdd("@ChkLate", dRow[i]["지연알림"].ToString());

                    DataSet ds = dbA.ProcedureToDataSetCompress();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 기본공유자 저장
        private void Save2_1()
        {
            try
            {
                gv_4.PostEditor();
                gv_4.UpdateCurrentRow();
                DataRow[] dRow2 = (gc_4.DataSource as DataTable).Select("선택=" + "'" + "Y" + "'");

                for (int i = 0; i < dRow2.Length; i++){
                    Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                    dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                    //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_2_SAVE_NEW";
                    dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_2_SAVE_NEW";

                    dbA.Procedure.ParamAdd("@DEPTCODE", gvDept.GetFocusedRowCellValue(gridColumn9.FieldName).ToString());
                    dbA.Procedure.ParamAdd("@DEPTNAME", gvDept.GetFocusedRowCellValue(gridColumn8.FieldName).ToString());
                    dbA.Procedure.ParamAdd("@VOCID", tr_stdMng2.FocusedNode["대분류VOCID"].ToString());
                    dbA.Procedure.ParamAdd("@JobCode3", "");
                    dbA.Procedure.ParamAdd("@DeptCode4", dRow2[i]["부서코드"].ToString());
                    dbA.Procedure.ParamAdd("@Sabun4", dRow2[i]["사번6"].ToString());
                    dbA.Procedure.ParamAdd("@ChkReceipt", dRow2[i]["접수알림"].ToString());
                    dbA.Procedure.ParamAdd("@ChkLate", dRow2[i]["지연알림"].ToString());

                    DataSet ds = dbA.ProcedureToDataSetCompress();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 처리, 기본공유자 세팅 저장
        private void Save처리기본Gubun()
        {
            try
            {
                Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
               
                //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_3_SAVE_NEW";
                dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_3_SAVE_NEW";

                dbA.Procedure.ParamAdd("@DEPTCODE", gvDept.GetFocusedRowCellValue(gridColumn9.FieldName).ToString());
                dbA.Procedure.ParamAdd("@VOCID", tr_stdMng2.FocusedNode["대분류VOCID"].ToString());

                dbA.Procedure.ParamAdd("@접수지연시간", txt접수지연시간.Text);
                dbA.Procedure.ParamAdd("@접수지연내용", memo접수지연내용.Text);

                dbA.Procedure.ParamAdd("@접수지연시간2", txt접수지연시간2.Text);
                dbA.Procedure.ParamAdd("@접수지연내용2", memo접수지연내용2.Text);

                dbA.Procedure.ParamAdd("@접수SMS", chkSMS.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@접수EMAIL", chkEmail.EditValue.Equals(true) ? "Y" : "N");
                //dbA.Procedure.ParamAdd("@접수PUSH", chkPush.EditValue.Equals(true) ? "Y" : "N");

                dbA.Procedure.ParamAdd("@접수SMS2", chkSMS2.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@접수EMAIL2", chkEmail2.EditValue.Equals(true) ? "Y" : "N");
                //dbA.Procedure.ParamAdd("@접수PUSH2", chkPush2.EditValue.Equals(true) ? "Y" : "N");

                // 접수 sms, email 구분값 추가 2017-06-12 이보현
                dbA.Procedure.ParamAdd("@접수등록SMS", chkReSMS.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@접수등록EMAIL", chkReEmail.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@기본공유SMS", chkReSMS2.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@기본공유EMAIL", chkReEmail2.EditValue.Equals(true) ? "Y" : "N");

                DataSet ds = dbA.ProcedureToDataSetCompress();

                MessageBox.Show("저장 완료하였습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 모니터링 기준 시간 및 모니터링들의 시간, SMS, PUSH 저장
        private bool SaveMonitoring()
        {
            try
            {
                //if(!ChkTime()) return false; //체크

                Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_MONITORING_SAVE_NEW";
                dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_MONITORING_SAVE_NEW";

                dbA.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                //모니터링 기준시간
                dbA.Procedure.ParamAdd("@RecmdHdlTime", text_RecmdHdlTime.Text);
                dbA.Procedure.ParamAdd("@권장처리SMS", chk_SMS9.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@권장처리EMAIL", chk_EMAIL9.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@권장처리내용", meProTime9.Text);
                dbA.Procedure.ParamAdd("@MaxHldTime", text_MaxHldTime.Text);
                //모니터링 기준1
                dbA.Procedure.ParamAdd("@StdTime5", text_StdTime5.Text);
                dbA.Procedure.ParamAdd("@SMS5", chk_SMS5.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@PUSH5", chk_Push5.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@EMAIL5", chk_EMAIL5.EditValue.Equals(true) ? "Y" : "N");
                //모니터링 기준2
                dbA.Procedure.ParamAdd("@StdTime6", text_StdTime6.Text);
                dbA.Procedure.ParamAdd("@SMS6", chk_SMS6.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@PUSH6", chk_Push6.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@EMAIL6", chk_EMAIL6.EditValue.Equals(true) ? "Y" : "N");
                //모니터링 기준3
                dbA.Procedure.ParamAdd("@StdTime7", text_StdTime7.Text);
                dbA.Procedure.ParamAdd("@SMS7", chk_SMS7.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@PUSH7", chk_Push7.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@EMAIL7", chk_EMAIL7.EditValue.Equals(true) ? "Y" : "N");
                //모니터링 미해결 기준
                dbA.Procedure.ParamAdd("@StdTime8", text_StdTime8.Text);
                dbA.Procedure.ParamAdd("@SMS8", chk_SMS8.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@PUSH8", chk_Push8.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@EMAIL8", chk_EMAIL8.EditValue.Equals(true) ? "Y" : "N");

                dbA.Procedure.ParamAdd("@지연내용1", meProDelay1.Text);
                dbA.Procedure.ParamAdd("@지연내용2", meProDelay2.Text);
                dbA.Procedure.ParamAdd("@지연내용3", meProDelay3.Text);
                dbA.Procedure.ParamAdd("@지연내용4", meProDelay4.Text);

                dbA.Procedure.ParamAdd("@처리SMS", chk처리SMS.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@처리EMAIL", chk처리EMAIL.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@처리PUSH", chk처리PUSH.EditValue.Equals(true) ? "Y" : "N");
                dbA.Procedure.ParamAdd("@처리내용", meMax.Text);


                //dbA.Procedure.ParamAdd("@접수지연시간", txt접수지연시간.Text);
                //dbA.Procedure.ParamAdd("@접수지연내용", memo접수지연내용.Text);

                //dbA.Procedure.ParamAdd("@접수지연시간2", txt접수지연시간2.Text);
                //dbA.Procedure.ParamAdd("@접수지연내용2", memo접수지연내용2.Text);

                //dbA.Procedure.ParamAdd("@접수SMS", chkSMS.EditValue.Equals(true) ? "Y" : "N");
                //dbA.Procedure.ParamAdd("@접수EMAIL", chkEmail.EditValue.Equals(true) ? "Y" : "N");
                //dbA.Procedure.ParamAdd("@접수PUSH", chkPush.EditValue.Equals(true) ? "Y" : "N");

                //dbA.Procedure.ParamAdd("@접수SMS2", chkSMS2.EditValue.Equals(true) ? "Y" : "N");
                //dbA.Procedure.ParamAdd("@접수EMAIL2", chkEmail2.EditValue.Equals(true) ? "Y" : "N");
                //dbA.Procedure.ParamAdd("@접수PUSH2", chkPush2.EditValue.Equals(true) ? "Y" : "N");

                //// 접수 sms, email 구분값 추가 2017-06-12 이보현
                //dbA.Procedure.ParamAdd("@접수등록SMS", chkReSMS.EditValue.Equals(true) ? "Y" : "N");
                //dbA.Procedure.ParamAdd("@접수등록EMAIL", chkReEmail.EditValue.Equals(true) ? "Y" : "N");
                //dbA.Procedure.ParamAdd("@기본공유SMS", chkReSMS2.EditValue.Equals(true) ? "Y" : "N");
                //dbA.Procedure.ParamAdd("@기본공유EMAIL", chkReEmail2.EditValue.Equals(true) ? "Y" : "N");

                DataSet ds = dbA.ProcedureToDataSetCompress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region 모니터링 부분 직책 저장
        private bool SaveJob()
        {
            try
            {
               // if(!ChkJob()) return false;
                gv_5.PostEditor();
                gv_5.UpdateCurrentRow();
                gv_6.PostEditor();
                gv_6.UpdateCurrentRow();
                gv_7.PostEditor();
                gv_7.UpdateCurrentRow();
                gv_8.PostEditor();
                gv_8.UpdateCurrentRow();
                gv_9.PostEditor();
                gv_9.UpdateCurrentRow();

                string strVOCID = tr_stdMng.FocusedNode["대분류VOCID"].ToString();
                DataRow[] dRow_Max = (gc_Max.DataSource as DataTable).Select("선택 = 'Y'");
                DataRow[] dRow = (gc_5.DataSource as DataTable).Select("선택 = 'Y'");
                DataRow[] dRow2 = (gc_6.DataSource as DataTable).Select("선택=" + "'" + "Y" + "'");
                DataRow[] dRow3 = (gc_7.DataSource as DataTable).Select("선택=" + "'" + "Y" + "'");
                DataRow[] dRow4 = (gc_8.DataSource as DataTable).Select("선택=" + "'" + "Y" + "'");
                DataRow[] dRow5 = (gc_9.DataSource as DataTable).Select("선택=" + "'" + "Y" + "'");

                for (int i = 0; i < dRow_Max.Length; i++)
                {
                    Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                    dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                    //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_JOB_SAVE_NEW";
                    dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_JOB_SAVE";

                    dbA.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                    dbA.Procedure.ParamAdd("@JobCode", dRow_Max[i]["직책코드"].ToString());
                    dbA.Procedure.ParamAdd("@Gubun", "0");

                    DataSet ds = dbA.ProcedureToDataSetCompress();
                }

                for (int i = 0; i < dRow.Length; i++)
                {
                    Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                    dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                    //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_JOB_SAVE_NEW";
                    dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_JOB_SAVE";

                    dbA.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                    dbA.Procedure.ParamAdd("@JobCode", dRow[i]["직책코드"].ToString());
                    dbA.Procedure.ParamAdd("@Gubun", "1");

                    DataSet ds = dbA.ProcedureToDataSetCompress();
                }

                //모니터링 기준2
                for (int i = 0; i < dRow2.Length; i++)
                {
                    Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                    dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                    //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_JOB_SAVE_NEW";
                    dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_JOB_SAVE";

                    dbA.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                    dbA.Procedure.ParamAdd("@JobCode", dRow2[i]["직책코드"].ToString());
                    dbA.Procedure.ParamAdd("@Gubun", "2");

                    DataSet ds = dbA.ProcedureToDataSetCompress();
                }

                //모니터링 기준3
                for (int i = 0; i < dRow3.Length; i++)
                {
                    Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                    dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                    //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_JOB_SAVE_NEW";
                    dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_JOB_SAVE";

                    dbA.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                    dbA.Procedure.ParamAdd("@JobCode", dRow3[i]["직책코드"].ToString());
                    dbA.Procedure.ParamAdd("@Gubun", "3");

                    DataSet ds = dbA.ProcedureToDataSetCompress();
                }

                //모니터링 미해결 기준
                for (int i = 0; i < dRow4.Length; i++)
                {
                    Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                    dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                    //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_JOB_SAVE_NEW";
                    dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_JOB_SAVE";

                    dbA.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                    dbA.Procedure.ParamAdd("@JobCode", dRow4[i]["직책코드"].ToString());
                    dbA.Procedure.ParamAdd("@Gubun", "4");

                    DataSet ds = dbA.ProcedureToDataSetCompress();
                }

                //처리임박시간
                for (int i = 0; i < dRow5.Length; i++)
                {
                    Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                    dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                    //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_JOB_SAVE_NEW";
                    dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_JOB_SAVE";

                    dbA.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                    dbA.Procedure.ParamAdd("@JobCode", dRow5[i]["직책코드"].ToString());
                    dbA.Procedure.ParamAdd("@Gubun", "5");

                    DataSet ds = dbA.ProcedureToDataSetCompress();
                }

                MessageBox.Show("저장 완료하였습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                stdRefresh();
                
                tr_stdMng.FocusedNode = tr_stdMng.FindNodeByFieldValue("대분류VOCID", strVOCID);
                tr_stdMng2.FocusedNode = tr_stdMng2.FindNodeByFieldValue("대분류VOCID", strVOCID);
                //tr_stdMng_FocusedNodeChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        /*
        #region 모니터링 기준시간 저장
        private bool Save3()
        {
            if (text_RecmdHdlTime.Text.Equals("") || text_MaxHldTime.Text.Equals(""))
            {
                MessageBox.Show("모니터링 기준시간에 시간을 입력해주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_3_SAVE";

                dbA.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                //모니터링 기준시간
                dbA.Procedure.ParamAdd("@RecmdHdlTime", text_RecmdHdlTime.Text);
                dbA.Procedure.ParamAdd("@MaxHldTime", text_MaxHldTime.Text);

                DataSet ds = dbA.ProcedureToDataSetCompress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region 모니터링 기준1
        private bool Save4()
        {
            try
            {
                DataRow[] dRow = (gc_5.DataSource as DataTable).Select("선택 = 'Y'");

                if (dRow.Length < 1)
                {
                    MessageBox.Show("모니터링 기준1의 직책을 선택해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (text_StdTime5.Text.Equals(""))
                {
                    MessageBox.Show("모니터링 기준1 기준 시간1에 시간을 입력해주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_StdTime5.Focus();
                    return false;
                }
                else
                {
                    for (int i = 0; i < dRow.Length; i++)
                    {
                        Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                        dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                        dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_4_SAVE";
                        dbA.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                        //모니터링 기준1
                        dbA.Procedure.ParamAdd("@StdTime5", Convert.ToInt16(text_StdTime5.Text));
                        dbA.Procedure.ParamAdd("@SMS5", chk_SMS5.EditValue.Equals(true) ? "Y" : "N");
                        dbA.Procedure.ParamAdd("@PUSH5", chk_Push5.EditValue.Equals(true) ? "Y" : "N");
                        dbA.Procedure.ParamAdd("@JobCode5", dRow[i]["직책코드"].ToString());

                        DataSet ds = dbA.ProcedureToDataSetCompress();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region 모니터링 기준2
        private bool Save5()
        {
            try            
            {
                DataRow[] dRow = (gc_6.DataSource as DataTable).Select("선택=" + "'" + "Y" + "'");
                if (dRow.Length < 1)
                {
                    MessageBox.Show("모니터링 기준2의 직책을 선택해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (text_StdTime6.Text.Equals(""))
                {
                    MessageBox.Show("모니터링 기준2 기준 시간2에 시간을 입력해주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_StdTime6.Focus();
                    return false;
                }
                else
                {
                    for (int i = 0; i < dRow.Length; i++)
                    {
                        Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                        dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                        dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_5_SAVE";

                        dbA.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                        //모니터링기준2
                        dbA.Procedure.ParamAdd("@StdTime6", Convert.ToInt16(text_StdTime6.Text));
                        dbA.Procedure.ParamAdd("@SMS6", chk_SMS6.EditValue.Equals(true) ? "Y" : "N");
                        dbA.Procedure.ParamAdd("@PUSH6", chk_Push6.EditValue.Equals(true) ? "Y" : "N");
                        dbA.Procedure.ParamAdd("@JobCode6", dRow[i]["직책코드"].ToString());
                        DataSet ds = dbA.ProcedureToDataSetCompress();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region 모니터링 기준3
        private bool Save6()
        {
            try
            {
                DataRow[] dRow = (gc_7.DataSource as DataTable).Select("선택=" + "'" + "Y" + "'");

                if (dRow.Length < 1)
                {
                    MessageBox.Show("모니터링 기준3의 직책을 선택해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (text_StdTime7.Text.Equals(""))
                {
                    MessageBox.Show("모니터링 기준3 기준 시간3에 시간을 입력해주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_StdTime7.Focus();
                    return false;
                }
                else
                {
                    for (int i = 0; i < dRow.Length; i++)
                    {
                        Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                        dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                        dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_6_SAVE";

                        dbA.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                        //모니터링기준3
                        dbA.Procedure.ParamAdd("@StdTime7", Convert.ToInt16(text_StdTime7.Text));
                        dbA.Procedure.ParamAdd("@SMS7", chk_SMS7.EditValue.Equals(true) ? "Y" : "N");
                        dbA.Procedure.ParamAdd("@PUSH7", chk_Push7.EditValue.Equals(true) ? "Y" : "N");
                        dbA.Procedure.ParamAdd("@JobCode7", dRow[i]["직책코드"].ToString());
                        DataSet ds = dbA.ProcedureToDataSetCompress();

                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region 모니터링 미해결 기준
        private bool Save7()
        {
            try
            {
                DataRow[] dRow = (gc_8.DataSource as DataTable).Select("선택=" + "'" + "Y" + "'");

                if (dRow.Length < 1)
                {
                    MessageBox.Show("모니터링 기준4의 직책을 선택해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (text_StdTime8.Text.Equals(""))
                {
                    MessageBox.Show("모니터링 미해결 기준 기준 시간1에 시간을 입력해주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_StdTime8.Focus();
                    return false;
                }
                else
                {
                    for (int i = 0; i < dRow.Length; i++)
                    {
                        Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                        dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                        dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_7_SAVE";
                        dbA.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                        //모니터링기준 미해결 기준
                        dbA.Procedure.ParamAdd("@StdTime8", Convert.ToInt16(text_StdTime8.Text));
                        dbA.Procedure.ParamAdd("@SMS8", chk_SMS8.EditValue.Equals(true) ? "Y" : "N");
                        dbA.Procedure.ParamAdd("@PUSH8", chk_Push8.EditValue.Equals(true) ? "Y" : "N");
                        dbA.Procedure.ParamAdd("@JobCode8", dRow[i]["직책코드"].ToString());
                        DataSet ds = dbA.ProcedureToDataSetCompress();
                    }
                    MessageBox.Show("저장 완료하였습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            stdRefresh();
            tr_stdMng.FocusedNode = tr_stdMng.Nodes[0];
            return true;
        }
        #endregion*/

        private void gv_1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!this.CanFocus)
                return;
            DataRow[] dRow = (gc_1.DataSource as DataTable).Select("선택=" + "'" + "Y" + "'");
            if (dRow.Length >= 1)
            {
                dRow[0]["선택"] = "N";
                //MessageBox.Show("하나 이상 선택할 수 없습니다.");
                return;
            }
        }

        #region 시간 관련 TextBox Validation
        private bool ChkTime()
        {
            if (text_RecmdHdlTime.Text.Equals(""))
            {
                MessageBox.Show("처리임박시간을 입력해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                text_RecmdHdlTime.Text = Convert.ToString(0);
                text_RecmdHdlTime.Focus();
                return false;
            }
            if (text_MaxHldTime.Text.Equals(""))
            {
                MessageBox.Show("MAX 처리시간을 입력해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                text_MaxHldTime.Text = Convert.ToString(0);
                text_MaxHldTime.Focus();
                return false;
            }

            if (text_StdTime5.Text.Equals(""))
            {
                MessageBox.Show("처리임박 안내1의 기준 시간을 입력해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                text_StdTime5.Focus();
                return false;
            }
            if (text_StdTime6.Text.Equals(""))
            {
                MessageBox.Show("처리임박 안내2의 기준 시간을 입력해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                text_StdTime6.Focus();
                return false;
            }
            //if (text_StdTime7.Text.Equals(""))
            //{
            //    MessageBox.Show("처리임박 안내3의 기준 시간을 입력해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    text_StdTime7.Focus();
            //    return false;
            //}
            if (text_StdTime8.Text.Equals(""))
            {
                MessageBox.Show("모니터링 미해결 기준의 기준 시간을 입력해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                text_StdTime8.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region 모니터링 직책 선택 Validation
        private bool ChkJob()
        {
            DataRow[] dRow_Max = (gc_Max.DataSource as DataTable).Select("선택 = 'Y'");
            if (dRow_Max.Length < 1)
            {
                MessageBox.Show("MAX 처리시간의 직책을 선택해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //모니터링 기준1
            DataRow[] dRow = (gc_5.DataSource as DataTable).Select("선택 = 'Y'");
            if (dRow.Length < 1)
            {
                MessageBox.Show("처리임박 안내1의 직책을 선택해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (text_StdTime5.Text.Equals(""))
            {
                MessageBox.Show("처리임박 안내1 기준 시간1에 시간을 입력해주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                text_StdTime5.Focus();
                return false;
            }
            DataRow[] dRow2 = (gc_6.DataSource as DataTable).Select("선택=" + "'" + "Y" + "'");
            if (dRow2.Length < 1)
            {
                MessageBox.Show("처리임박 안내2의 직책을 선택해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (text_StdTime6.Text.Equals(""))
            {
                MessageBox.Show("처리임박 안내2 기준 시간2에 시간을 입력해주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                text_StdTime6.Focus();
                return false;
            }
            DataRow[] dRow3 = (gc_7.DataSource as DataTable).Select("선택=" + "'" + "Y" + "'");
            //if (dRow3.Length < 1)
            //{
            //    MessageBox.Show("처리임박 안내3의 직책을 선택해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //if (text_StdTime7.Text.Equals(""))
            //{
            //    MessageBox.Show("처리임박 안내3 기준 시간3에 시간을 입력해주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    text_StdTime7.Focus();
            //    return false;
            //}
            DataRow[] dRow4 = (gc_8.DataSource as DataTable).Select("선택=" + "'" + "Y" + "'");
            if (dRow4.Length < 1)
            {
                MessageBox.Show("모니터링 미해결 기준의 직책을 선택해 주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (text_StdTime8.Text.Equals(""))
            {
                MessageBox.Show("모니터링 미해결 기준 시간에 시간을 입력해주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                text_StdTime8.Focus();
                return false;
            }
            return true;
        }

        #endregion

        private void tr_stdMng_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (!this.CanFocus)
                return;

            Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
            dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORY_ALL_SELECT_NEW_DEATIL";
            dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORY_ALL_SELECT_NEW_DEATIL";

            dbA.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());

            DataSet oDs = dbA.ProcedureToDataSetCompress();

            #region // 2017-07-27 이보현 주석처리 (탭화면 추가로 인한)
            // //처리담당자
            //if (oDs != null && oDs.Tables.Count > 0 && oDs.Tables[0].Rows.Count > 0)
            //{
            //    gc_1.DataSource = oDs.Tables[0];
            //    //if (oDs.Tables[9].Rows[0]["구분"].ToString().Equals("D"))
            //    //{
            //    //    //gc_1.DataSource = null;
            //    //    rdio_Gubun.EditValue = "D";
            //    //    getJob2();
            //    //    gc_2.DataSource = oDs.Tables[1];

            //    //    if (gv_2.RowCount > 0)
            //    //    {
            //    //        text_SabunName.Enabled = false;
            //    //        btn_Add.Enabled = false;
            //    //    }
            //    //    else
            //    //    {
            //    //        text_SabunName.Enabled = true;
            //    //        btn_Add.Enabled = true;
            //    //    }

            //    //}
            //    //else
            //    //{
            //    //    rdio_Gubun.EditValue = "J";
            //    //    gc_1.DataSource = oDs.Tables[0];
            //    //    gc_2.DataSource = null;
            //    //}
            //    //if (oDs.Tables[9].Rows[0]["처리자"].ToString().Equals(""))
            //    //{
            //    //    rdio_Gubun.EditValue = "J";
            //    //    gc_1.DataSource = oDs.Tables[0];
            //    //    gc_2.DataSource = null;
            //    //}
            //}
            //else
            //{
            //    return;
            //    //gc_1.DataSource = null;
            //}

            ////기본공유자
            //if (oDs != null && oDs.Tables.Count > 2 && oDs.Tables[2].Rows.Count > 0)
            //{
            //    gc_3.DataSource = oDs.Tables[2];
            //}
            //else
            //{
            //    return;
            //    //gc_2.DataSource = null;
            //}

            ////기본공유자2
            //if (oDs != null && oDs.Tables.Count > 3 && oDs.Tables[3].Rows.Count > 0)
            //{
            //    gc_4.DataSource = oDs.Tables[3];
            //}
            //else
            //{
            //    return;
            //    //gc_2.DataSource = null;
            //}
            #endregion

            try
            {
                Cursor = Cursors.WaitCursor;

                //모니터링 기준시간 TextBox
                if (oDs != null && oDs.Tables.Count > 4 && oDs.Tables[0].Rows.Count > 0)
                {
                    //모니터링 미해결 기준
                    text_RecmdHdlTime.Text = oDs.Tables[0].Rows[0]["권장처리시간"].ToString();
                    meProTime9.Text = oDs.Tables[0].Rows[0]["권장처리내용"].ToString();
                    text_MaxHldTime.Text = oDs.Tables[0].Rows[0]["MAX처리시간"].ToString();
                    meMax.Text = oDs.Tables[0].Rows[0]["MAX처리내용"].ToString();
                    meProDelay1.Text = oDs.Tables[0].Rows[0]["지연내용1"].ToString();
                    meProDelay2.Text = oDs.Tables[0].Rows[0]["지연내용2"].ToString();
                    meProDelay3.Text = oDs.Tables[0].Rows[0]["지연내용3"].ToString();
                    meProDelay4.Text = oDs.Tables[0].Rows[0]["지연내용4"].ToString();

                    #region 2017-07-27 탭화면 추가로 인한 주석처리
                    //if (oDs.Tables[4].Rows[0]["접수SMS"].ToString() == "Y")
                    //    chkSMS.Checked = true;
                    //else
                    //    chkSMS.Checked = false;
                    //if (oDs.Tables[4].Rows[0]["접수EMAIL"].ToString() == "Y")
                    //    chkEmail.Checked = true;
                    //else
                    //    chkEmail.Checked = false;


                    //if (oDs.Tables[4].Rows[0]["접수SMS2"].ToString() == "Y")
                    //    chkSMS2.Checked = true;
                    //else
                    //    chkSMS2.Checked = false;
                    //if (oDs.Tables[4].Rows[0]["접수EMAIL2"].ToString() == "Y")
                    //    chkEmail2.Checked = true;
                    //else
                    //    chkEmail2.Checked = false;
                    #endregion

                    //if (oDs.Tables[0].Rows[0]["접수PUSH"].ToString() == "Y")
                    //    chkPush.Checked = true;
                    //else
                    //    chkPush.Checked = false;

                    //if (oDs.Tables[0].Rows[0]["접수PUSH2"].ToString() == "Y")
                    //    chkPush2.Checked = true;
                    //else
                    //    chkPush2.Checked = false;

                    if (oDs.Tables[0].Rows[0]["MAX처리SMS"].ToString() == "Y")
                        chk처리SMS.Checked = true;
                    else
                        chk처리SMS.Checked = false;

                    if (oDs.Tables[0].Rows[0]["MAX처리EMAIL"].ToString() == "Y")
                        chk처리EMAIL.Checked = true;
                    else
                        chk처리EMAIL.Checked = false;

                    if (oDs.Tables[0].Rows[0]["MAX처리PUSH"].ToString() == "Y")
                        chk처리PUSH.Checked = true;
                    else
                        chk처리PUSH.Checked = false;
                    if (oDs.Tables[0].Rows[0]["권장처리PUSH"].ToString() == "Y")
                        chk처리PUSH.Checked = true;
                    else
                        chk처리PUSH.Checked = false;
                    if (oDs.Tables[0].Rows[0]["권장처리SMS"].ToString() == "Y")
                        chk_SMS9.Checked = true;
                    else
                        chk_SMS9.Checked = false;
                    if (oDs.Tables[0].Rows[0]["권장처리EMAIL"].ToString() == "Y")
                        chk_EMAIL9.Checked = true;
                    else
                        chk_EMAIL9.Checked = false;

                }
                //else
                //{
                //    text_StdTime5.Text = "";
                //    chk_SMS5.EditValue = false;
                //    chk_Push5.EditValue = false;
                //    text_RecmdHdlTime.Text = "";
                //    text_MaxHldTime.Text = "";
                //    meProTime9.Text = "";
                //    txt접수지연시간.Text = "";
                //    memo접수지연내용.Text = "";
                //    txt접수지연시간2.Text = "";
                //    memo접수지연내용2.Text = "";
                //    meMax.Text = "";
                //    meProDelay1.Text = "";
                //    meProDelay2.Text = "";
                //    meProDelay3.Text = "";
                //    meProDelay4.Text = "";
                //    chkSMS.Checked = false;
                //    chkEmail.Checked = false;
                //    chkPush.Checked = false;
                //    chkSMS2.Checked = false;
                //    chkEmail2.Checked = false;
                //    chkPush2.Checked = false;
                //    chk처리SMS.Checked = false;
                //    chk처리EMAIL.Checked = false;
                //    chk처리PUSH.Checked = false;
                //    chk_SMS9.Checked = false;
                //    chk_EMAIL9.Checked = false;
                //}

                //모니터링 기준 TextBox, CheckBox
                if (oDs != null && oDs.Tables.Count > 4 && oDs.Tables[0].Rows.Count > 0)
                {
                    text_StdTime5.Text =    oDs.Tables[0].Rows[0]["기준시간1"].ToString();
                    chk_SMS5.EditValue =   (oDs.Tables[0].Rows[0]["SMS1"].ToString().Equals("Y") ? true : false);
                    chk_Push5.EditValue =  (oDs.Tables[0].Rows[0]["PUSH1"].ToString().Equals("Y") ? true : false);
                    chk_EMAIL5.EditValue = (oDs.Tables[0].Rows[0]["EMAIL1"].ToString().Equals("Y") ? true : false);

                    text_StdTime6.Text =    oDs.Tables[0].Rows[0]["기준시간2"].ToString();
                    chk_SMS6.EditValue =   (oDs.Tables[0].Rows[0]["SMS2"].ToString().Equals("Y") ? true : false);
                    chk_Push6.EditValue =  (oDs.Tables[0].Rows[0]["PUSh2"].ToString().Equals("Y") ? true : false);
                    chk_EMAIL6.EditValue = (oDs.Tables[0].Rows[0]["EMAIL2"].ToString().Equals("Y") ? true : false);

                    text_StdTime7.Text =    oDs.Tables[0].Rows[0]["기준시간3"].ToString();
                    chk_SMS7.EditValue =   (oDs.Tables[0].Rows[0]["SMS3"].ToString().Equals("Y") ? true : false);
                    chk_Push7.EditValue =  (oDs.Tables[0].Rows[0]["PUSh3"].ToString().Equals("Y") ? true : false);
                    chk_EMAIL7.EditValue = (oDs.Tables[0].Rows[0]["EMAIL3"].ToString().Equals("Y") ? true : false);

                    text_StdTime8.Text =    oDs.Tables[0].Rows[0]["기준시간4"].ToString();
                    chk_SMS8.EditValue =   (oDs.Tables[0].Rows[0]["SMS4"].ToString().Equals("Y") ? true : false);
                    chk_Push8.EditValue =  (oDs.Tables[0].Rows[0]["PUSh4"].ToString().Equals("Y") ? true : false);
                    chk_EMAIL8.EditValue = (oDs.Tables[0].Rows[0]["EMAIL4"].ToString().Equals("Y") ? true : false);
                }
                //else
                //{
                //    text_StdTime5.Text = "";
                //    chk_SMS5.EditValue = false;
                //    chk_Push5.EditValue = false;
                //    chk_EMAIL5.EditValue = false;

                //    text_StdTime6.Text = "";
                //    chk_SMS6.EditValue = false;
                //    chk_Push6.EditValue = false;
                //    chk_EMAIL6.EditValue = false;

                //    text_StdTime7.Text = "";
                //    chk_SMS7.EditValue = false;
                //    chk_Push7.EditValue = false;
                //    chk_EMAIL7.EditValue = false;

                //    text_StdTime8.Text = "";
                //    chk_SMS8.EditValue = false;
                //    chk_Push8.EditValue = false;
                //    chk_EMAIL8.EditValue = false;

                //}

                //모니터링 기준 GridView5
                if (oDs != null && oDs.Tables.Count > 5 && oDs.Tables[1].Rows.Count > 0)
                {
                    gc_5.DataSource = oDs.Tables[1];
                }
                else
                {
                    text_StdTime6.Text = "";
                    chk_SMS6.EditValue = false;
                    chk_Push6.EditValue = false;
                }

                //모니터링 기준 GridView6
                if (oDs != null && oDs.Tables.Count > 6 && oDs.Tables[2].Rows.Count > 0)
                {
                    gc_6.DataSource = oDs.Tables[2];
                }
                else
                {
                    text_StdTime6.Text = "";
                    chk_SMS6.EditValue = false;
                    chk_Push6.EditValue = false;
                }

                //모니터링 기준 GridView7
                if (oDs != null && oDs.Tables.Count > 7 && oDs.Tables[3].Rows.Count > 0)
                {
                    gc_7.DataSource = oDs.Tables[3];
                }
                else
                {
                    text_StdTime6.Text = "";
                    chk_SMS6.EditValue = false;
                    chk_Push6.EditValue = false;
                }

                //모니터링 기준 GridView8
                if (oDs != null && oDs.Tables.Count > 8 && oDs.Tables[4].Rows.Count > 0)
                {
                    gc_8.DataSource = oDs.Tables[4];
                }
                else
                {
                    text_StdTime6.Text = "";
                    chk_SMS6.EditValue = false;
                    chk_Push6.EditValue = false;
                }

                //MAx처리시간 GridView10
                if (oDs != null && oDs.Tables[5].Rows.Count > 0)
                {
                    gc_Max.DataSource = oDs.Tables[5];
                }
                else
                {
                    text_MaxHldTime.Text = "";
                    chk처리SMS.EditValue = false;
                    chk처리PUSH.EditValue = false;
                }

                //처리임박시간
                if (oDs != null && oDs.Tables[6].Rows.Count > 0)
                {
                    gc_9.DataSource = oDs.Tables[6];
                }
                else
                {
                    text_RecmdHdlTime.Text = "";
                    chk_SMS9.EditValue = false;
                    chk_EMAIL9.EditValue = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #region textEdit 마우스 클릭시
        private void text_StdTime5_MouseDown(object sender, MouseEventArgs e)
        {
            SetStdTime(text_StdTime5);
        }
        private void text_StdTime6_MouseDown(object sender, MouseEventArgs e)
        {
            SetStdTime(text_StdTime6);
        }
        private void text_StdTime7_MouseDown(object sender, MouseEventArgs e)
        {
            SetStdTime(text_StdTime7);
        }
        private void text_StdTime8_MouseDown(object sender, MouseEventArgs e)
        {
            SetStdTime(text_StdTime8);
        }
        #endregion

        private void SetStdTime(DevExpress.XtraEditors.TextEdit txtTemp)
        {
            txtTemp.Text = "";
        }

        #region textEdit 마우스 Leave
        private void text_StdTime5_MouseLeave(object sender, EventArgs e)
        {
            setStdTime2(text_StdTime5);
        }
        private void text_StdTime6_MouseLeave(object sender, EventArgs e)
        {
            setStdTime2(text_StdTime6);
        }
        private void text_StdTime7_MouseLeave(object sender, EventArgs e)
        {
            setStdTime2(text_StdTime7);
        }
        private void text_StdTime8_MouseLeave(object sender, EventArgs e)
        {
            setStdTime2(text_StdTime8);
        }
        #endregion

        private void setStdTime2(DevExpress.XtraEditors.TextEdit txtTemp2)
        {
            txtTemp2.Text = "0";
        }

        private void tr_stdMng_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            TreeList tree = sender as DevExpress.XtraTreeList.TreeList;
            IndicatorObjectInfoArgs args = e.ObjectArgs as IndicatorObjectInfoArgs;
            args.DisplayText = (tree.GetVisibleIndexByNode(e.Node) + 1).ToString();
            e.ImageIndex = -1;
        }

        private void tr_stdMng_NodeChanged(object sender, DevExpress.XtraTreeList.NodeChangedEventArgs e)
        {
            Graphics gr = Graphics.FromHwnd(tr_stdMng.Handle);
            SizeF size = gr.MeasureString(tr_stdMng.Nodes.Count.ToString(), tr_stdMng.Appearance.Row.GetFont());
            tr_stdMng.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 21;
        }

        private void gcDept_Click(object sender, EventArgs e)
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_SELECT_NEW";
            db.Procedure.ParamAdd("@DEPTCODE", gvDept.GetFocusedRowCellValue(gridColumn9.FieldName).ToString());

            try
            {
                Cursor = Cursors.Default;

                DataSet ds = db.ProcedureToDataSet();

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    XtraMessageBox.Show("조회된 데이터가 없습니다.");
                    return;
                }

                tr_stdMng2.DataSource = null;
                //gc_4.DataSource = null;

                tr_stdMng2.ParentFieldName = "대분류PARENTID";
                tr_stdMng2.KeyFieldName = "대분류VOCID";

                tr_stdMng2.DataSource = ds.Tables[0];
                tr_stdMng2.ExpandAll();

                //gc_4.DataSource = ds.Tables[1];

                //tr_stdMng2_FocusedNodeChanged(null, null);
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
                Cursor = Cursors.Default;
            }
        }

        private void tr_stdMng2_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (!this.CanFocus)
                return;

            Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
            dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            //dbA.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORY_ALL_SELECT_NEW";
            dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORY_ALL_SELECT_NEW";

            dbA.Procedure.ParamAdd("@DEPTCODE", gvDept.GetFocusedRowCellValue(gridColumn9.FieldName).ToString());
            dbA.Procedure.ParamAdd("@VOCID", tr_stdMng2.FocusedNode["대분류VOCID"].ToString());

            DataSet oDs = dbA.ProcedureToDataSetCompress();

            try
            {
                Cursor = Cursors.WaitCursor;

                //처리담당자
                if (oDs != null && oDs.Tables.Count > 0 && oDs.Tables[0].Rows.Count > 0)
                    gc_1.DataSource = oDs.Tables[0];
                else
                    gc_1.DataSource = null;

                //기본공유자
                if (oDs != null && oDs.Tables.Count > 2 && oDs.Tables[2].Rows.Count > 0)
                    gc_3.DataSource = oDs.Tables[2];
                else
                    gc_3.DataSource = null;

                //기본공유자2
                if (oDs != null && oDs.Tables.Count > 3 && oDs.Tables[3].Rows.Count > 0)
                    gc_4.DataSource = oDs.Tables[3];
                else
                    gc_4.DataSource = null;

                //접수지연
                if (oDs != null && oDs.Tables[4].Rows.Count > 0)
                {
                    txt접수지연시간.Text = oDs.Tables[4].Rows[0]["접수지연시간"].ToString();
                    memo접수지연내용.Text = oDs.Tables[4].Rows[0]["접수지연내용"].ToString();

                    txt접수지연시간2.Text = oDs.Tables[4].Rows[0]["접수지연시간2"].ToString();
                    memo접수지연내용2.Text = oDs.Tables[4].Rows[0]["접수지연내용2"].ToString();

                    if (oDs.Tables[4].Rows[0]["접수SMS"].ToString() == "Y")
                        chkSMS.Checked = true;
                    else chkSMS.Checked = false;

                    if (oDs.Tables[4].Rows[0]["접수EMAIL"].ToString() == "Y")
                        chkEmail.Checked = true;
                    else chkEmail.Checked = false;

                    if (oDs.Tables[4].Rows[0]["접수SMS2"].ToString() == "Y")
                        chkSMS2.Checked = true;
                    else chkSMS2.Checked = false;

                    if (oDs.Tables[4].Rows[0]["접수EMAIL2"].ToString() == "Y")
                        chkEmail2.Checked = true;
                    else chkEmail2.Checked = false;

                    if (oDs.Tables[4].Rows[0]["접수등록SMS"].ToString() == "Y")
                        chkReSMS.Checked = true;
                    else
                        chkReSMS.Checked = false;
                    if (oDs.Tables[4].Rows[0]["접수등록EMAIL"].ToString() == "Y")
                        chkReEmail.Checked = true;
                    else
                        chkReEmail.Checked = false;
                    if (oDs.Tables[4].Rows[0]["기본공유SMS"].ToString() == "Y")
                        chkReSMS2.Checked = true;
                    else
                        chkReSMS2.Checked = false;
                    if (oDs.Tables[4].Rows[0]["기본공유EMAIL"].ToString() == "Y")
                        chkReEmail2.Checked = true;
                    else
                        chkReEmail2.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private void tr_stdMng2_CustomDrawNodeIndicator(object sender, CustomDrawNodeIndicatorEventArgs e)
        {
            TreeList tree = sender as DevExpress.XtraTreeList.TreeList;
            IndicatorObjectInfoArgs args = e.ObjectArgs as IndicatorObjectInfoArgs;
            args.DisplayText = (tree.GetVisibleIndexByNode(e.Node) + 1).ToString();
            e.ImageIndex = -1;
        }

        private void tr_stdMng2_NodeChanged(object sender, NodeChangedEventArgs e)
        {
            Graphics gr = Graphics.FromHwnd(tr_stdMng2.Handle);
            SizeF size = gr.MeasureString(tr_stdMng2.Nodes.Count.ToString(), tr_stdMng2.Appearance.Row.GetFont());
            tr_stdMng2.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 21;
        }

        private void tr_stdMng2_Click(object sender, EventArgs e)
        {
            //SetCount(tr_stdMng2);
        }

        private void SetCount(TreeList tList)
        {
            int iNode = 0;

            foreach (TreeListNode tNode in tList.Nodes)
            {
                iNode++;

                if (tNode.GetValue("대분류VOCID").ToString() == tList.FocusedNode.GetValue("대분류VOCID").ToString())
                {
                    //MessageBox.Show((iNode-1).ToString());
                    tr_stdMng.FocusedNode = tr_stdMng.Nodes[iNode - 1];
                    tr_stdMng2.FocusedNode = tr_stdMng2.Nodes[iNode - 1];
                }
            }
        }

        private void tr_stdMng_Click(object sender, EventArgs e)
        {
            //SetCount(tr_stdMng);
        }
    }
}