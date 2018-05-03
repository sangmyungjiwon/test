using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CES.DbConnection;
using DocManagement;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraTreeList;
using DevExpress.Utils.Drawing;

namespace VOC_LIST
{////jhkhj
    public partial class VOC_CategoryMngerSet : DevExpress.XtraEditors.XtraUserControl
    {
        string strUserID = string.Empty;
        string strDeptCode = string.Empty;
        string strInsertAuth = string.Empty;
        string strUpdateAuth = string.Empty;
        string strDeleteAuth = string.Empty;
        string strSearchAuth = string.Empty;
        string strPrintAuth = string.Empty;
        string strExcelAuth = string.Empty;
        string strDataAuth = string.Empty;

        DataTable dtAuthAdd2 = new DataTable();
        DataTable dtAuthAdd = new DataTable();
        string strUserNm = string.Empty;

        public VOC_CategoryMngerSet()
        {
            InitializeComponent();
        }

        public VOC_CategoryMngerSet(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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


        private void VOC_CategoryMngerSet_Load(object sender, EventArgs e)
        {
            setCategoryList();
        }

        private void setCategoryList()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
           
            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_Big_SELECT";
            

            try
            {
                DataSet ds = db.ProcedureToDataSet();

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    XtraMessageBox.Show("조회된 데이터가 없습니다.");
                    return;
                }
                tr_stdMng.ParentFieldName = "대분류PARENTID";
                tr_stdMng.KeyFieldName = "대분류VOCID";

                tr_stdMng.DataSource = ds.Tables[0];
                //tr_stdMng.ExpandAll();
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

        private void tr_stdMng_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (!this.CanFocus)
                return;
            gcUserList.DataSource = null;
            teEmp.Text = "";
            meApplyDelay.Text = "";
            meProDelay.Text = "";

            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            //db.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_User_SELECT";
            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_User_SELECT";
            db.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());

            try
            {
                
                DataSet ds = db.ProcedureToDataSet();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gcUserList.DataSource = ds.Tables[0];
                }
                //if (ds.Tables[1].Rows.Count > 0)
                //{
                //    meApplyDelay.Text = ds.Tables[1].Rows[0]["접수지연안내문구"].ToString();
                //    meProDelay.Text = ds.Tables[1].Rows[0]["처리지연안내문구"].ToString();
                //}
            }
            catch (Cesco.FW.Global.DBAdapter.WcfException ex)
            {
                MessageBox.Show(ex.Message, "DB 에러");
                return;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "처리되지 않은 에러");
                return;
            }
        }

        private void btnAuth_Add_Click(object sender, EventArgs e)
        {
            if (gcUserList.DataSource != null)
            {
                DataTable dt_UserList = gcUserList.DataSource as DataTable;

                //if (dt_UserList.Rows.Count > 0)
                //{
                //    MessageBox.Show("최대 한명만 지정할 수 있습니다.", "인원 초과", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    teEmp.Text = "";
                //    return;
                //}
            }
            dtAuthAdd2 = gcUserList.DataSource as DataTable;
            dtAuthAdd = gcUserList.DataSource as DataTable;

            Cesco.FW.Global.DBAdapter.DBAdapters conn = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            conn.Procedure.ProcedureName = "ASSI.dbo.SP_CategoryMng_AuthMng_Category_AddUser";
            conn.Procedure.ParamAdd("@UserNmID", teEmp.Text);
            DataSet ds = conn.ProcedureToDataSet();
            if (ds.Tables[0].Rows.Count > 1)
            {
                VOC_UserCheck UC = new VOC_UserCheck(teEmp.Text, gcUserList.DataSource as DataTable);
                UC.StartPosition = FormStartPosition.CenterParent;
                UC.ShowDialog();

                if (UC.str_CheckedUserID == "")
                {
                    teEmp.Text = "";
                    return;
                }
                
                if (dtAuthAdd == null)
                {
                    dtAuthAdd = new DataTable("dtAuthAdd");
                    dtAuthAdd.Columns.Add("한글성명", Type.GetType("System.String"));
                    dtAuthAdd.Columns.Add("사번", Type.GetType("System.String"));
                    dtAuthAdd.Columns.Add("부서코드", Type.GetType("System.String"));
                    dtAuthAdd.Columns.Add("부서명", Type.GetType("System.String"));
                }
                DataRow dRow = dtAuthAdd.NewRow();
                dRow["한글성명"] = UC.str_CheckedUser;
                dRow["사번"] = UC.str_CheckedUserID;
                dRow["부서코드"] = UC.str_CheckedUserDeptCode;
                dRow["부서명"] = UC.str_CheckedUserDept;


                if (dtAuthAdd2 == null)
                {
                    dtAuthAdd.Rows.Add(dRow);
                    gcUserList.DataSource = dtAuthAdd;
                    teEmp.Text = "";
                }
                else
                {
                    DataRow[] drows = dtAuthAdd2.Select(string.Format("사번 = '" + ds.Tables[0].Rows[0]["사번"].ToString() + "'")); //중복 검사

                    if (drows != null && drows.Length > 0)
                    {
                        dtAuthAdd2.Rows.Remove(drows[0]);
                    }

                    DataRow[] oDRDept = dtAuthAdd2.Select(string.Format("부서코드 = '" + ds.Tables[0].Rows[0]["부서코드"].ToString() + "'")); //중복 검사

                    //if (oDRDept != null && oDRDept.Length > 0)
                    //{
                    //    MessageBox.Show("부서에 1명만 존재가능합니다.", "조회 불가", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}

                    dtAuthAdd.Rows.Add(dRow);
                    dtAuthAdd2.Merge(dtAuthAdd);
                    gcUserList.DataSource = dtAuthAdd2;
                    teEmp.Text = "";
                }

            }
            else
            {
                if (ds.Tables[0].Rows.Count < 1 || ds == null)
                {
                    MessageBox.Show("조회 가능한 직원이 없습니다.", "조회 불가", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dtAuthAdd == null)
                {
                    dtAuthAdd = new DataTable("dtAuthAdd");
                    dtAuthAdd.Columns.Add("한글성명", Type.GetType("System.String"));
                    dtAuthAdd.Columns.Add("사번", Type.GetType("System.String"));
                    dtAuthAdd.Columns.Add("부서코드", Type.GetType("System.String"));
                    dtAuthAdd.Columns.Add("부서명", Type.GetType("System.String"));
                }

                DataRow dRow = dtAuthAdd.NewRow();
                dRow["한글성명"] = ds.Tables[0].Rows[0]["한글성명"].ToString();
                dRow["사번"] = ds.Tables[0].Rows[0]["사번"].ToString();
                dRow["부서코드"] = ds.Tables[0].Rows[0]["부서코드"].ToString();
                dRow["부서명"] = ds.Tables[0].Rows[0]["부서명"].ToString();

                if (dtAuthAdd2 == null)
                {
                    dtAuthAdd.Rows.Add(dRow);
                    gcUserList.DataSource = dtAuthAdd;
                }
                else
                {
                    DataRow[] drows = dtAuthAdd2.Select(string.Format("사번 = '" + ds.Tables[0].Rows[0]["사번"].ToString() + "'")); //중복 검사

                    if (drows != null && drows.Length > 0)
                    {
                        dtAuthAdd2.Rows.Remove(drows[0]);
                    }

                    DataRow[] oDRDept = dtAuthAdd2.Select(string.Format("부서코드 = '" + ds.Tables[0].Rows[0]["부서코드"].ToString() + "'")); //중복 검사

                    //if (oDRDept != null && oDRDept.Length > 0)
                    //{
                    //    MessageBox.Show("부서에 1명만 존재가능합니다.", "조회 불가", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                    dtAuthAdd.Rows.Add(dRow);
                    dtAuthAdd2.Merge(dtAuthAdd);
                    gcUserList.DataSource = dtAuthAdd2;

                }
                teEmp.Text = "";
            }
        }

        private void btnAuth_Del_Click(object sender, EventArgs e)
        {
            //gcUserList.DataSource = null;
            //dtAuthAdd2 = null;
            dtAuthAdd2 = gcUserList.DataSource as DataTable;
            dtAuthAdd2.Rows.Remove(gvUserList.GetFocusedDataRow());
        }

        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string strVocID = string.Empty;
           
            try
            {
                Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                //db.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_Mnger_DELETE";
                db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_Mnger_DELETE";
                db.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                DataSet ds = db.ProcedureToDataSet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            if (gvUserList.DataRowCount > 0)
            {
                try
                {
                    for (int i = 0; i < gvUserList.DataRowCount; i++)
                    {
                        strVocID = tr_stdMng.FocusedNode["대분류VOCID"].ToString();
                        Cesco.FW.Global.DBAdapter.DBAdapters db2 = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                        //db2.Procedure.ProcedureName = "BACKUPDB.dbo.SP_VOC_CATEGORYSTD_Mnger_SAVE";
                        db2.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORYSTD_Mnger_SAVE";
                        db2.Procedure.ParamAdd("@VOCID", tr_stdMng.FocusedNode["대분류VOCID"].ToString());
                        db2.Procedure.ParamAdd("@Sabun", gvUserList.GetRowCellValue(i, "사번").ToString());
                        db2.Procedure.ParamAdd("@DeptCode", gvUserList.GetRowCellValue(i, "부서코드").ToString());
                        db2.Procedure.ParamAdd("@DeptName", gvUserList.GetRowCellValue(i, "부서명").ToString());
                        DataSet ds = db2.ProcedureToDataSet();
                    }
                }
                catch (Cesco.FW.Global.DBAdapter.WcfException ex)
                {
                    MessageBox.Show(ex.Message, "DB 에러");
                    return;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "처리되지 않은 에러");
                    return;
                }
            }
            MessageBox.Show("저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            setCategoryList();

            //저장된 행 선택되어 있도록
            tr_stdMng.FocusedNode = tr_stdMng.FindNodeByFieldValue("대분류VOCID", strVocID);
        }

        private void teEmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAuth_Add_Click(null, null);
            }
        }

        private void barBtnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setCategoryList();
        }

        private void tr_stdMng_NodeChanged(object sender, DevExpress.XtraTreeList.NodeChangedEventArgs e)
        {
            Graphics gr = Graphics.FromHwnd(tr_stdMng.Handle);
            SizeF size = gr.MeasureString(tr_stdMng.Nodes.Count.ToString(), tr_stdMng.Appearance.Row.GetFont());
            tr_stdMng.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 21;
        }

        private void tr_stdMng_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            TreeList tree = sender as DevExpress.XtraTreeList.TreeList;
            IndicatorObjectInfoArgs args = e.ObjectArgs as IndicatorObjectInfoArgs;
            args.DisplayText = (tree.GetVisibleIndexByNode(e.Node) + 1).ToString();
            e.ImageIndex = -1;
        }
    }
}
