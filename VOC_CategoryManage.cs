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

namespace VOC
{
    public partial class VOC_CategoryManage : DevExpress.XtraEditors.XtraUserControl
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
        public VOC_CategoryManage(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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

        #region 로드
        private void CategoryManage_Load(object sender, EventArgs e)
        {
            getLarge();
            getMmulty();
            SmallEssen();
            setLueProb();
            setLueCode();
            setLueBugsEquip();
        }
        #endregion

        private void setLueCode()
        {
            DataSet oDs;
            Cesco.FW.Global.DBAdapter.DBAdapters oDBAdapters = new Cesco.FW.Global.DBAdapter.DBAdapters();
            oDBAdapters.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, "고객의소리 카테고리");

            try
            {
                oDBAdapters.Query.QueryString.AppendFormat(@"                
                                    SELECT Gerlcode AS CODE, Gerldesp AS NAME
                                      FROM CESCOEIS.DBO.MKTCGERL 
                                     WHERE GERLCODE LIKE 'BM%'
                                        "
                     );

                oDs = oDBAdapters.QueryToDataSet();

                lu_M_GubunCode.Properties.DisplayMember = "NAME";
                lu_M_GubunCode.Properties.ValueMember = "CODE";
                lu_M_GubunCode.Properties.DataSource = oDs.Tables[0];

                lu_S_GubunCode.Properties.DisplayMember = "NAME";
                lu_S_GubunCode.Properties.ValueMember = "CODE";
                lu_S_GubunCode.Properties.DataSource = oDs.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void setLueProb()
        {
            DataTable dtCb = new DataTable();
            dtCb.Columns.Add("코드", typeof(string));
            dtCb.Columns.Add("선택");

            DataRow dRowCust_0 = dtCb.NewRow();
            DataRow dRowCust_1 = dtCb.NewRow();
            DataRow dRowCust_2 = dtCb.NewRow();
            DataRow dRowCust_3 = dtCb.NewRow();
          
            dRowCust_0["코드"] = "";
            dRowCust_0["선택"] = "";
            dRowCust_1["코드"] = "1";
            dRowCust_1["선택"] = "레벨1";
            dRowCust_2["코드"] = "2";
            dRowCust_2["선택"] = "레벨2";
            dRowCust_3["코드"] = "3";
            dRowCust_3["선택"] = "레벨3";

            dtCb.Rows.Add(dRowCust_0);
            dtCb.Rows.Add(dRowCust_1);
            dtCb.Rows.Add(dRowCust_2);
            dtCb.Rows.Add(dRowCust_3);

            lue_L_ProblemLv.Properties.DisplayMember = "선택";
            lue_L_ProblemLv.Properties.ValueMember = "코드";
            lue_L_ProblemLv.Properties.DataSource = dtCb;

            lue_M_ProblemLv.Properties.DisplayMember = "선택";
            lue_M_ProblemLv.Properties.ValueMember = "코드";
            lue_M_ProblemLv.Properties.DataSource = dtCb;

            lue_S_ProblemLv.Properties.DisplayMember = "선택";
            lue_S_ProblemLv.Properties.ValueMember = "코드";
            lue_S_ProblemLv.Properties.DataSource = dtCb;  


        }


        #region Top Menu 1
        private void ctm_L_ButtonClicked(string barItemName, DevExpress.XtraBars.BarItem barItem, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (barItemName)
            {
                case "Refresh":
                    LRefresh();
                    break;
                case "Save":
                    LSave();
                    break;
                case "New":
                    LNew();
                    break;
            }
        }
        #endregion

        #region Top Menu 2
        private void ctm_M_ButtonClicked(string barItemName, DevExpress.XtraBars.BarItem barItem, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (barItemName)
            {
                case "Refresh":
                    MRefresh();
                    break;
                case "Save":
                    MSave();
                    break;
                case "New":
                    MNew();
                    break;
            }
        }
        #endregion

        #region Top Menu 3
        private void ctm_S_ButtonClicked(string barItemName, DevExpress.XtraBars.BarItem barItem, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (barItemName)
            {
                case "Refresh":
                    SRefresh();
                    break;
                case "Save":
                    SSave();
                    break;
                case "New":
                    SNew();
                    break;
            }
        }
        #endregion

        #region 대분류에 포커스
        private void gv_Large_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!this.CanFocus)
                return;

            if (gv_Large.GetFocusedRowCellValue("대분류VOCID").ToString() == "Q")
            {
                //te_EquipCD.Enabled = true;
                lueEquip.Enabled = true;
            }
            else
            {
                //te_EquipCD.Enabled = false;
                lueEquip.Enabled = false;
            }
            text_L_Code.Text = gv_Large.GetFocusedRowCellValue(col대분류VOCID.FieldName).ToString();
            text_L_LargeName.Text = gv_Large.GetFocusedRowCellValue(col대분류.FieldName).ToString();
            rdio_L_Usegubun.EditValue = gv_Large.GetFocusedRowCellValue(col사용여부.FieldName).ToString();
            lu_M_Multi.EditValue = gv_Large.GetFocusedRowCellValue(col대분류TYPE.FieldName).ToString();
            sp_L_Num.EditValue = gv_Large.GetFocusedRowCellValue(col대분류순서.FieldName).ToString();
            sp_L_Main.EditValue = gv_Large.GetFocusedRowCellValue(colMainOrder).ToString();

            text_L_vocid.Text = gv_Large.GetFocusedRowCellValue(col대분류VOCID.FieldName).ToString();
            text_L_Name.Text = gv_Large.GetFocusedRowCellValue(col대분류.FieldName).ToString();
            lue_L_ProblemLv.EditValue = gv_Large.GetFocusedRowCellValue(col문제VOC_LV.FieldName).ToString();
            lu_L_Kind.EditValue = gv_Large.GetFocusedRowCellValue(col업종구분L).ToString();

            if(gv_Large.GetFocusedRowCellValue(col문제VOC_L.FieldName).ToString() == "Y")
                chkProb_LVOC.Checked = true;
            else
                chkProb_LVOC.Checked = false;
            getMedium();
        }
        #endregion

        #region 중분류에 포커스
        private void gv_Medium_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!this.CanFocus)
                return;
            //if (gv_Medium.GetFocusedRowCellValue(col중분류VOCID.FieldName) == null || gv_Medium.GetFocusedRowCellValue(col중분류명.FieldName) == null)
            if (gv_Medium.RowCount < 1)
            {
                return;
            }
            else
            {
                text_M_vocid.Text = gv_Medium.GetFocusedRowCellValue(col중분류VOCID.FieldName).ToString();
                text_M_Name.Text = gv_Medium.GetFocusedRowCellValue(col중분류명.FieldName).ToString();
            }
            text_M_Code.Text = gv_Medium.GetFocusedRowCellValue(col중분류VOCID.FieldName).ToString();
            text_M_MediumName.Text = gv_Medium.GetFocusedRowCellValue(col중분류명.FieldName).ToString();
            text_M_vocid.Text = gv_Medium.GetFocusedRowCellValue(col중분류VOCID.FieldName).ToString();
            text_M_Name.Text = gv_Medium.GetFocusedRowCellValue(col중분류명.FieldName).ToString();
            rdio_M_Usegubun.EditValue = gv_Medium.GetFocusedRowCellValue(col중분류USEYN.FieldName).ToString();
            sp_M_Num.EditValue = gv_Medium.GetFocusedRowCellValue(col중분류순번.FieldName).ToString();
            lu_S_Multi.EditValue = gv_Medium.GetFocusedRowCellValue(col소분류멀티.FieldName).ToString();
            lu_S_Essen.EditValue = gv_Medium.GetFocusedRowCellValue(col소분류필수.FieldName).ToString();
            lue_M_ProblemLv.EditValue = gv_Medium.GetFocusedRowCellValue(col문제VOC_LV.FieldName).ToString();
            //te_EquipCD.Text = gv_Medium.GetFocusedRowCellValue(col장비코드.FieldName).ToString();
            lueEquip.EditValue = gv_Medium.GetFocusedRowCellValue(col장비코드.FieldName).ToString();
            lueBugs.EditValue = gv_Medium.GetFocusedRowCellValue(col해충코드.FieldName).ToString();
            lu_M_GubunCode.EditValue = gv_Medium.GetFocusedRowCellValue(col타입코드).ToString();
            lu_M_Kind.EditValue = gv_Medium.GetFocusedRowCellValue(col업종구분M).ToString();


            if (gv_Medium.GetFocusedRowCellValue(col문제VOC_M.FieldName).ToString() == "Y")
                chkProb_MVOC.Checked = true;
            else
                chkProb_MVOC.Checked = false;

            if (gv_Medium.GetFocusedRowCellValue(col소분류수.FieldName).Equals(0))
            {
                text_S_Code.Text = "";
                text_S_SmallName.Text = "";
                sp_S_Num.EditValue = "0";
                rdio_S_Usegubun.EditValue = "Y";
                gc_Small.DataSource = null;
                return;
            }

            getSmall();


            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORY_BUGEQUIP_SELECT";
            db.Procedure.ParamAdd("@BUGSCLS", gv_Medium.GetFocusedRowCellValue("해충코드").ToString());
            try
            {
                DataSet ds = db.ProcedureToDataSet();

              
                lueBugs_S.Properties.ValueMember = "코드";
                lueBugs_S.Properties.DisplayMember = "선택";
                if (ds.Tables[2].Rows.Count > 0)
                    lueBugs_S.Properties.DataSource = ds.Tables[2];
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


        #region 소분류 포커스
        private void gv_Small_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!this.CanFocus)
                return;
            if (gv_Small.GetFocusedRowCellValue(col소분류VOCID.FieldName) == null)
            {
                return;
            }
            else
            {
                text_S_Code.Text = gv_Small.GetFocusedRowCellValue(col소분류VOCID.FieldName).ToString();
                text_S_SmallName.Text = gv_Small.GetFocusedRowCellValue(col소분류.FieldName).ToString();
                rdio_S_Usegubun.EditValue = gv_Small.GetFocusedRowCellValue(col소분류USEYN.FieldName).ToString();
                sp_S_Num.EditValue = gv_Small.GetFocusedRowCellValue(col순번.FieldName).ToString();
                lu_S_GubunCode.EditValue = gv_Small.GetFocusedRowCellValue(col타입코드).ToString();
                lu_S_Kind.EditValue = gv_Small.GetFocusedRowCellValue(col업종구분).ToString();
                lueBugs_S.EditValue = gv_Small.GetFocusedRowCellValue(col해충코드S).ToString();
                if (gv_Small.GetFocusedRowCellValue(col문제VOC_S.FieldName).ToString() == "Y")
                    chkProb_SVOC.Checked = true;
                else
                    chkProb_SVOC.Checked = false;
            }

        }
        #endregion

        private void setLueBugsEquip()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            db.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORY_BUGEQUIP_SELECT";
            try
            {
                DataSet ds = db.ProcedureToDataSet();

                lueBugs.Properties.ValueMember = "코드";
                lueBugs.Properties.DisplayMember = "선택";

                lueBugs_S.Properties.ValueMember = "코드";
                lueBugs_S.Properties.DisplayMember = "선택";

                lueEquip.Properties.ValueMember = "코드";
                lueEquip.Properties.DisplayMember = "선택";

                if (ds.Tables[0].Rows.Count > 0)
                    lueEquip.Properties.DataSource = ds.Tables[0];
                if (ds.Tables[1].Rows.Count > 0)
                    lueBugs.Properties.DataSource = ds.Tables[1];
                 if (ds.Tables[2].Rows.Count > 0)
                    lueBugs_S.Properties.DataSource = ds.Tables[2];
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

        #region 대분류
        private void getLarge()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
            dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORY_LARGE_SELECT";

            DataSet ds = dbA.ProcedureToDataSetCompress();
            if (ds == null || ds.Tables[0].Rows.Count < 1)
            {
                text_M_vocid.Text = "";
                text_M_Name.Text = "";
                gc_Medium.DataSource = null;
                return;
            }
            gc_Large.DataSource = ds.Tables[0];
        }
        #endregion
        
        #region 중분류
        private void getMedium()
        {

            Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
            dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORY_MEDIUM_SELECT";
            dbA.Procedure.ParamAdd("@MIDIUMPID", gv_Large.GetFocusedRowCellValue(col대분류VOCID.FieldName).ToString());

            DataSet ds = dbA.ProcedureToDataSetCompress();
            if (ds == null || ds.Tables[0].Rows.Count < 1)
            {
                gc_Medium.DataSource = null;
                gc_Small.DataSource = null;
                text_M_Code.Text = "";
                text_M_MediumName.Text = "";
                text_M_vocid.Text = "";
                text_M_Name.Text = "";
                lueEquip.EditValue = "";
                lueBugs.EditValue = "";
                //te_EquipCD.Text = "";
                return;
            }
            gc_Medium.DataSource = null;
            gc_Small.DataSource = null;
            gc_Medium.DataSource = ds.Tables[0];
        }
        #endregion

        #region 소분류
        private void getSmall()
        {
            if (gv_Medium.GetFocusedRowCellValue(col중분류VOCID.FieldName) == null)
            {
                gc_Small.DataSource = null;
                return;
            }
            else
            {
                gc_Small.DataSource = null;
                Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

                dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORY_SMALL_SELECT";

                dbA.Procedure.ParamAdd("@SMALLPID", gv_Medium.GetFocusedRowCellValue(col중분류VOCID.FieldName).ToString());

                DataSet ds = dbA.ProcedureToDataSetCompress();
                if (ds == null || ds.Tables[0].Rows.Count < 1)
                {
                    text_M_vocid.Text = "";
                    text_M_Name.Text = "";
                    return;
                }
                gc_Small.DataSource = ds.Tables[0];
            }

        }
        #endregion

        #region
        private void getMmulty()
        {
            DataTable dtCb = new DataTable();
            dtCb.Columns.Add("코드", typeof(string));
            dtCb.Columns.Add("선택");

            DataRow dRowCust_1 = dtCb.NewRow();
            DataRow dRowCust_2 = dtCb.NewRow();

            dRowCust_1["코드"] = "Y";
            dRowCust_1["선택"] = "가능";
            dRowCust_2["코드"] = "N";
            dRowCust_2["선택"] = "불가능";

            dtCb.Rows.Add(dRowCust_1);
            dtCb.Rows.Add(dRowCust_2);

            lu_M_Multi.Properties.DisplayMember = "선택";
            lu_M_Multi.Properties.ValueMember = "코드";
            lu_M_Multi.Properties.DataSource = dtCb;

            lu_S_Multi.Properties.DisplayMember = "선택";
            lu_S_Multi.Properties.ValueMember = "코드";
            lu_S_Multi.Properties.DataSource = dtCb;

            DataTable dtCb_Kind = new DataTable();
            dtCb_Kind.Columns.Add("코드", typeof(string));
            dtCb_Kind.Columns.Add("선택");

            DataRow dRowKind_1 = dtCb_Kind.NewRow();
            DataRow dRowKind_2 = dtCb_Kind.NewRow();
            DataRow dRowKind_3 = dtCb_Kind.NewRow();
            DataRow dRowKind_4 = dtCb_Kind.NewRow();

            dRowKind_1["코드"] = "";
            dRowKind_1["선택"] = "";
            dRowKind_2["코드"] = "A";
            dRowKind_2["선택"] = "공통";
            dRowKind_3["코드"] = "B";
            dRowKind_3["선택"] = "산업체/소규모";
            dRowKind_4["코드"] = "C";
            dRowKind_4["선택"] = "가정집";

            dtCb_Kind.Rows.Add(dRowKind_1);
            dtCb_Kind.Rows.Add(dRowKind_2);
            dtCb_Kind.Rows.Add(dRowKind_3);
            dtCb_Kind.Rows.Add(dRowKind_4);


            lu_S_Kind.Properties.DisplayMember = "선택";
            lu_S_Kind.Properties.ValueMember = "코드";
            lu_S_Kind.Properties.DataSource = dtCb_Kind;

            lu_M_Kind.Properties.DisplayMember = "선택";
            lu_M_Kind.Properties.ValueMember = "코드";
            lu_M_Kind.Properties.DataSource = dtCb_Kind;

            lu_L_Kind.Properties.DisplayMember = "선택";
            lu_L_Kind.Properties.ValueMember = "코드";
            lu_L_Kind.Properties.DataSource = dtCb_Kind;

        }
        #endregion

        #region 대분류 저장
        private void LSave()
        {
            string strLCode = text_L_Code.Text;
            try
            {
                Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_LARGE_INSERT_NEW";
                dbA.Procedure.ParamAdd("@VOCID", text_L_Code.Text);
                dbA.Procedure.ParamAdd("@ORDERNO", sp_L_Num.EditValue);
                dbA.Procedure.ParamAdd("@VOCNAME", text_L_LargeName.Text);
                dbA.Procedure.ParamAdd("@USEYN", rdio_L_Usegubun.EditValue);
                dbA.Procedure.ParamAdd("@MULTIYN", lu_M_Multi.EditValue);
                dbA.Procedure.ParamAdd("@PROBLEMYN", chkProb_LVOC.Checked ? "Y" : "N" );
                dbA.Procedure.ParamAdd("@PROBLEMLV", lue_L_ProblemLv.EditValue == null ? "" : lue_L_ProblemLv.EditValue.ToString());
                dbA.Procedure.ParamAdd("@MAINORDER", sp_L_Main.EditValue);
                dbA.Procedure.ParamAdd("@REGID", _strUserID);
                dbA.Procedure.ParamAdd("@KINDGB", lu_L_Kind.EditValue == null ? "" : lu_L_Kind.EditValue.ToString());

                DataSet ds = dbA.ProcedureToDataSetCompress();
                MessageBox.Show("저장 완료하였습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LRefresh();
            LNew();
            //저장된 행 선택되어 있도록
            ColumnView view = (ColumnView)gc_Large.FocusedView;
            GridColumn column = view.Columns["대분류VOCID"];
            if (column != null)
            {
                int rhFound = view.LocateByValue(0, column, strLCode);
                if (rhFound != GridControl.InvalidRowHandle)
                {
                    view.FocusedRowHandle = rhFound;
                }
            }
            gv_Large_FocusedRowChanged(null, null);
        }
        #endregion

        #region 중분류 저장
        private void MSave()
        {
            if (text_M_Code.Text.Equals(""))
            {
                MessageBox.Show("중분류의 신규 버튼을 눌러주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (te_EquipCD.Text.Equals("") && gv_Large.GetFocusedRowCellValue("대분류VOCID").ToString() == "Q")
            //{
            //    MessageBox.Show("장비코드를 입력해주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (lueEquip.EditValue.ToString().Equals("") && gv_Large.GetFocusedRowCellValue("대분류VOCID").ToString() == "Q")
            {
                MessageBox.Show("장비코드를 입력해주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string strLCode = text_L_Code.Text;
            string strMCode = text_M_Code.Text;
            try
            {
                Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_MEDIUM_INSERT_NEW";
                dbA.Procedure.ParamAdd("@VOCID", text_M_Code.Text);
                dbA.Procedure.ParamAdd("@PARENTID", text_L_vocid.Text);
                dbA.Procedure.ParamAdd("@VOCNAME", text_M_MediumName.Text);
                dbA.Procedure.ParamAdd("@MULTIYN", lu_M_Multi.EditValue);
                dbA.Procedure.ParamAdd("@USEYN", rdio_M_Usegubun.EditValue);
                dbA.Procedure.ParamAdd("@ORDERNO", sp_M_Num.EditValue);
                dbA.Procedure.ParamAdd("@SUBCLASSESSEN", lu_S_Essen.EditValue);
                dbA.Procedure.ParamAdd("@PROBLEMYN", chkProb_MVOC.Checked ? "Y" : "N");
                dbA.Procedure.ParamAdd("@PROBLEMLV", lue_M_ProblemLv.EditValue == null ? "" : lue_M_ProblemLv.EditValue.ToString());
                dbA.Procedure.ParamAdd("@EQUICODE", lueEquip.EditValue == null ? "" : lueEquip.EditValue.ToString());
                dbA.Procedure.ParamAdd("@TYPECODE", lu_M_GubunCode.EditValue);
                dbA.Procedure.ParamAdd("@REGID", _strUserID);
                dbA.Procedure.ParamAdd("@KINDGB", lu_M_Kind.EditValue == null ? "" : lu_M_Kind.EditValue.ToString());
                dbA.Procedure.ParamAdd("@BUGCODE", lueBugs.EditValue == null ? "" : lueBugs.EditValue.ToString());

                DataSet ds = dbA.ProcedureToDataSetCompress();
                MessageBox.Show("저장 완료하였습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MRefresh();
            MNew();
            //저장된 행 선택되어 있도록
            ColumnView view = (ColumnView)gc_Large.FocusedView;
            GridColumn column = view.Columns["대분류VOCID"];
            if (column != null)
            {
                int rhFound = view.LocateByValue(0, column, strLCode);
                if (rhFound != GridControl.InvalidRowHandle)
                {
                    view.FocusedRowHandle = rhFound;
                }
            }
            ColumnView view2 = (ColumnView)gc_Medium.FocusedView;
            GridColumn column2 = view2.Columns["중분류VOCID"];
            if (column2 != null)
            {
                int rhFound = view2.LocateByValue(0, column2, strMCode);
                if (rhFound != GridControl.InvalidRowHandle)
                {
                    view2.FocusedRowHandle = rhFound;
                }
            }
         

        }
        #endregion

        #region 소분류 저장
        private void SSave()
        {
            if (text_S_Code.Text.Equals(""))
            {
                MessageBox.Show("소분류의 신규 버튼을 눌러주세요.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
         
            string strLCode = text_L_Code.Text;
            string strMCode = text_M_Code.Text;
            string strSCode = text_S_Code.Text;
            try
            {
                Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_SMALL_INSERT_NEW";
                dbA.Procedure.ParamAdd("@VOCID", text_S_Code.Text);
                dbA.Procedure.ParamAdd("@PARENTID", text_M_Code.Text);
                dbA.Procedure.ParamAdd("@VOCNAME", text_S_SmallName.Text);
                dbA.Procedure.ParamAdd("@USEYN", rdio_S_Usegubun.EditValue);
                dbA.Procedure.ParamAdd("@ORDERNO", sp_S_Num.EditValue);
                dbA.Procedure.ParamAdd("@PROBLEMYN", chkProb_SVOC.Checked ? "Y" : "N");
                dbA.Procedure.ParamAdd("@PROBLEMLV", lue_S_ProblemLv.EditValue == null ? "" : lue_S_ProblemLv.EditValue.ToString());
                dbA.Procedure.ParamAdd("@TYPECODE", lu_S_GubunCode.EditValue == null ? "" : lu_S_GubunCode.EditValue.ToString());
                dbA.Procedure.ParamAdd("@REGID", _strUserID);
                dbA.Procedure.ParamAdd("@KINDGB", lu_S_Kind.EditValue == null ? "" : lu_S_Kind.EditValue.ToString());

                DataSet ds = dbA.ProcedureToDataSetCompress();
                MessageBox.Show("저장 완료하였습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MRefresh();
            SRefresh();
            SNew();
            //저장된 행 선택되어 있도록
            ColumnView view = (ColumnView)gc_Large.FocusedView;
            GridColumn column = view.Columns["대분류VOCID"];
            if (column != null)
            {
                int rhFound = view.LocateByValue(0, column, strLCode);
                if (rhFound != GridControl.InvalidRowHandle)
                {
                    view.FocusedRowHandle = rhFound;
                }
            }
            ColumnView view2 = (ColumnView)gc_Medium.FocusedView;
            GridColumn column2 = view2.Columns["중분류VOCID"];
            if (column2 != null)
            {
                int rhFound = view2.LocateByValue(0, column2, strMCode);
                if (rhFound != GridControl.InvalidRowHandle)
                {
                    view2.FocusedRowHandle = rhFound;
                }
            }
            ColumnView view3 = (ColumnView)gc_Small.FocusedView;
            GridColumn column3 = view3.Columns["소분류VOCID"];
            if (column3 != null)
            {
                int rhFound = view3.LocateByValue(0, column3, strSCode);
                if (rhFound != GridControl.InvalidRowHandle)
                {
                    view3.FocusedRowHandle = rhFound;
                }
            }
            //gv_Large_FocusedRowChanged(null, null);
            //gv_Medium_FocusedRowChanged(null, null);
            //gv_Small_FocusedRowChanged(null, null);
        }
        #endregion

        #region L새로고침
        private void LRefresh()
        {
            getLarge();
        }
        #endregion

        #region M새로고침
        private void MRefresh()
        {
            getMedium();
        }
        #endregion

        #region S새로고침
        private void SRefresh()
        {
            getSmall();
        }
        #endregion

        #region L신규
        private void LNew()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
            dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_LCODE_SELECT";
            DataSet ds = dbA.ProcedureToDataSetCompress();

            text_L_Code.Text = ds.Tables[0].Rows[0]["VOCID"].ToString();


            sp_L_Num.EditValue = "0";
            text_L_LargeName.Text = "";
            rdio_L_Usegubun.EditValue = "Y";
            lu_M_Multi.EditValue = "";
            //text_L_Code.Text = "";
        }
        #endregion

        #region M신규
        private void MNew()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
            dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_MCODE_SELECT";
            DataSet ds = dbA.ProcedureToDataSetCompress();

            text_M_Code.Text = ds.Tables[0].Rows[0]["VOCID"].ToString();

            sp_M_Num.EditValue = "0";
            text_M_MediumName.Text = "";
            rdio_M_Usegubun.EditValue = "Y";
            lu_S_Multi.EditValue = "";
            lu_S_Essen.EditValue = "";
            lueBugs.EditValue = "";
            lueEquip.EditValue = "";
            lu_M_GubunCode.EditValue = "BM01";

        }
        #endregion

        #region S신규
        private void SNew()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
            dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_SCODE_SELECT";
            DataSet ds = dbA.ProcedureToDataSetCompress();

            text_S_Code.Text = ds.Tables[0].Rows[0]["VOCID"].ToString();

            text_S_SmallName.Text = "";
            rdio_S_Usegubun.EditValue = "Y";
            sp_S_Num.EditValue = "0";
            lu_S_GubunCode.EditValue = "BM01";
            lueBugs_S.EditValue = "";
        }
        #endregion

        #region 소분류필수
        private void SmallEssen()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
            dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            try
            {
                dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_SMALLESSEN_SELECT";
                lu_S_Essen.Properties.ValueMember = "코드구분";
                lu_S_Essen.Properties.DisplayMember = "코드명";

                DataSet ds = dbA.ProcedureToDataSetCompress();
                lu_S_Essen.Properties.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Indicator
        private void gv_Large_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gv_Medium_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gv_Small_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        #endregion
        
        private void VOC_CategoryManage_SizeChanged(object sender, EventArgs e)
        {
            if (this.Parent == null) return;
            groupBox1.Width = this.Parent.Width / 3;
            groupBox2.Width = this.Parent.Width / 3;
        }
    }
}
