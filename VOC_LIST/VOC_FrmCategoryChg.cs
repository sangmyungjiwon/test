using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace VOC_LIST
{
    public partial class VOC_FrmCategoryChg : DevExpress.XtraEditors.XtraForm
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
        string strOpenYN = string.Empty;
        string strClaimNum = string.Empty;

        string strRegDate = string.Empty;
        string strRegUserID = string.Empty;
        string strRegNum = string.Empty;

        string strBigCate = string.Empty;
        #endregion

        public VOC_FrmCategoryChg()
        {
            InitializeComponent();
        }

         public VOC_FrmCategoryChg(string pUserID, string pBigCate, string pClaimNum, string pRegDate, string pRegUserID, string pRegNum)
        {
            InitializeComponent();
            strUserID = pUserID;
            strRegDate = pRegDate;
            strRegUserID = pRegUserID;
            
            strRegNum   = pRegNum;
            strClaimNum = pClaimNum;
            strBigCate  = pBigCate;
        }

        public VOC_FrmCategoryChg(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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

        private void VOC_FrmCategoryChg_Load(object sender, EventArgs e)
        {
            setCategoryList();
            strOpenYN = "Y";
        }

        private void setCategoryList()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_CategoryList_SDH";
            db.Procedure.ParamAdd("@RegNum", strRegNum);
            db.Procedure.ParamAdd("@VCNO", strClaimNum);
            db.Procedure.ParamAdd("@VCTP", strBigCate.Trim());
            try
            {
                DataSet ds = db.ProcedureToDataSet();

                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count == 0)
                {
                    XtraMessageBox.Show("조회된 데이터가 없습니다.");
                    return;
                }
                trCategoryList.ParentFieldName = "부모카테고리코드";
                trCategoryList.KeyFieldName = "카테고리코드";
                trCategoryList.ImageIndexFieldName = "IMAGEINDEX";

                if (trCategoryList.Nodes.ParentNode != null)
                {
                    trCategoryList.Nodes.ParentNode.ImageIndex = 0;
                }
                if (trCategoryList.Nodes.LastNode != null)
                {
                    trCategoryList.Nodes.LastNode.ImageIndex = 1;
                }

                trCategoryList.DataSource = ds.Tables[0];
                trCategoryList.ExpandAll();
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

        private void btnOpenYN_Click(object sender, EventArgs e)
        {
            if (strOpenYN != "Y")
            {
                trCategoryList.ExpandAll();
                strOpenYN = "Y";
                btnOpenYN.Text = "접기";
            }
            else
            {
                trCategoryList.CollapseAll();
                strOpenYN = "N";
                btnOpenYN.Text = "펼치기";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = trCategoryList.DataSource as DataTable;
            DataRow[] rows = dt.Select(string.Format("카테고리명 like '%{0}%'", teSearchNm.Text), "카테고리코드");
            if (rows.Length != 0)
            {
                trCategoryList.FocusedNode = trCategoryList.FindNodeByFieldValue("카테고리코드", rows[0]["카테고리코드"]);
            }
            else
            {
                XtraMessageBox.Show("검색결과가 없습니다.", "검색", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void teSearchNm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }


        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string strMidCate = string.Empty;
                string strSmCate = string.Empty;
                DataTable dt = new DataTable();
                //((DataTable)trCategoryList.DataSource).AcceptChanges();
                
                //dt.AcceptChanges();
                btnSearch.Focus();
                dt = ((DataTable)trCategoryList.DataSource);
                DataRow[] dRow_Cate = dt.Select("선택 = 'Y'");
                if (dRow_Cate.Length < 1)
                {
                    MessageBox.Show("선택된 카테고리가 없습니다.", "카테고리 미 선택", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                    db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_CATEGORY_DELETE_SDH";
                    db.Procedure.ParamAdd("@RegNum", strRegNum);
                    db.Procedure.ParamAdd("@VCNO", strClaimNum);
                    db.Procedure.ParamAdd("@VCTP", strBigCate.Trim());

                    DataSet ds = db.ProcedureToDataSet();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                for (int i = 0; i < dRow_Cate.Length; i++)
                {
                    string strGubun = dRow_Cate[i]["IMAGEINDEX"].ToString();
                    if (strGubun == "0")
                    {
                        strMidCate = dRow_Cate[i]["카테고리코드"].ToString();
                        strSmCate = "";
                    }
                    else
                    {
                        strMidCate = dRow_Cate[i]["부모카테고리코드"].ToString();
                        strSmCate = dRow_Cate[i]["카테고리코드"].ToString();
                    }
                    try
                    {
                        Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                        db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_STATE_CATEGORY_SAVE_SDH";
                        db.Procedure.ParamAdd("@RegNum", strRegNum);
                        db.Procedure.ParamAdd("@VCNO", strClaimNum);
                        db.Procedure.ParamAdd("@VCTP", strBigCate.Trim());

                        db.Procedure.ParamAdd("@REGUSER", strUserID);
                        db.Procedure.ParamAdd("@REGDATE", strRegDate);
                        
                        db.Procedure.ParamAdd("@GUBUN", strGubun);

                        db.Procedure.ParamAdd("@MIDCATEGORY", strMidCate);
                        db.Procedure.ParamAdd("@SMCATEGORY", strSmCate);


                        DataSet ds = db.ProcedureToDataSet();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
            MessageBox.Show("저장이 완료되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void trCategoryList_DoubleClick(object sender, EventArgs e)
        {
            btnSave_ItemClick(null, null);
        }

        private void trCategoryList_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            //if (trCategoryList.FocusedNode["선택"].ToString() == "Y")
            //{
            //    if (trCategoryList.FocusedNode["멀티여부"].ToString() == "N")
            //    {
            //        teSearchNm.Focus();
            //        DataTable dt = (DataTable)trCategoryList.DataSource;
            //        dt.AcceptChanges();
            //        DataRow[] dRow_Multi = dt.Select("선택 = 'Y'");
            //        if(dRow_Multi.Length > 0)
            //        {
            //            for(int i = 0; i < dRow_Multi.Length; i++)
            //            {
            //                dRow_Multi[0]["선택"] = "N";
            //            }
            //        }
            //    }
            //}

            

           
        }

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            /*
            DataTable dt = (DataTable)trCategoryList.DataSource;

            if (dt == null)
            {
                return;
            }

            if (trCategoryList.FocusedNode["멀티여부"].ToString() == "N")
            {
                foreach (DataRow dRow in dt.Rows)
                {
                    if (dRow["카테고리코드"].ToString() != trCategoryList.FocusedNode["카테고리코드"].ToString())
                        dRow["선택"] = "N";
                    else
                    {
                        dRow["선택"] = "Y";
                    }
                }
            }*/
        }

        private void repositoryItemCheckEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dt = (DataTable)trCategoryList.DataSource;

            if (dt == null)
            {
                return;
            }

            if (trCategoryList.FocusedNode["멀티여부"].ToString() == "N")
            {
                foreach (DataRow dRow in dt.Rows)
                {
                    if (dRow["카테고리코드"].ToString() != trCategoryList.FocusedNode["카테고리코드"].ToString())
                        dRow["선택"] = "N";
                    else
                    {
                        dRow["선택"] = e.NewValue;
                    }
                }
            }
        }

        private void barBtnOpenYN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

    }
}