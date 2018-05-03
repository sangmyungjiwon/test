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
    public partial class VOC_TemplateManage : DevExpress.XtraEditors.XtraUserControl
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
        public VOC_TemplateManage(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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
        }
        #endregion

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        #region 대분류에 포커스
        private void gv_Large_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!this.CanFocus)
                return;
            text_L_vocid.Text = gv_Large.GetFocusedRowCellValue(col대분류VOCID.FieldName).ToString();
            text_L_Name.Text = gv_Large.GetFocusedRowCellValue(col대분류.FieldName).ToString();


            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            string strQuery = "";
            strQuery += string.Format("SELECT * FROM CESCOEIS.dbo.TB_VOC_TEMPLATE AS A WITH (NOLOCK) "
                                        + "WHERE VOCID = '" + text_L_vocid.Text + "'"
                                     );

            db.Query.QueryString.Append(strQuery);
            DataSet ds = db.QueryToDataSet();
            if (ds == null || ds.Tables[0].Rows.Count < 1)
            {
                templateText.Text = "";
                return;
            }
            templateText.Text = ds.Tables[0].Rows[0]["Template"].ToString();
        }
        #endregion

        #region 대분류
        private void getLarge()
        {
            Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
            dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CATEGORY_LARGE_SELECT";

            DataSet ds = dbA.ProcedureToDataSetCompress();
            if (ds == null || ds.Tables[0].Rows.Count < 1)
            {
                return;
            }
            gc_Large.DataSource = ds.Tables[0];
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

        #region 새로고침
        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            getLarge();
        }
        #endregion

        #region 저장
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string strID = string.Empty;
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

            string strQuery = "";
            strQuery += string.Format("IF EXISTS (SELECT 1 FROM CESCOEIS.dbo.TB_VOC_TEMPLATE WITH (NOLOCK) "
                                       + "          WHERE VOCID = '" + text_L_vocid.Text + "')"
                                       + " BEGIN"
                                       +  "    UPDATE CESCOEIS.dbo.TB_VOC_TEMPLATE "
                                       + "     SET template = '" + templateText.Text + "' "                        
                                       + "     WHERE VOCID = '" + text_L_vocid.Text + "'"
                                       + " END"
                                       + " ELSE"
                                       + "    BEGIN "
                                       + "    INSERT INTO CESCOEIS.dbo.TB_VOC_TEMPLATE"
                                       + "        (VOCID   ,PARENTID   ,VOCNAME   ,TEMPLATE   ,USEYN)"
                                       + "        Values"
                                       + "         ('" + text_L_vocid.Text + "' "
                                       + "         ,'0' "
                                       + "         ,'" + text_L_Name.Text + "' "
                                       + "         ,'" + templateText.Text + "' "
                                       + "         ,'Y')"
                                       + "END"
                                     );

            db.Query.QueryString.Append(strQuery);

            try
            {
                strID = text_L_vocid.Text;
                int result = db.QueryToNonQuery();
                templateText.Text = "";
                getLarge();

                //저장된 행 선택되어 있도록
                ColumnView view = (ColumnView)gc_Large.FocusedView;
                GridColumn column = view.Columns["대분류VOCID"];
                if (column != null)
                {
                    int rhFound = view.LocateByDisplayText(0, column, strID);
                    if (rhFound != GridControl.InvalidRowHandle)
                    {
                        view.FocusedRowHandle = rhFound;
                    }
                }
                gv_Large_FocusedRowChanged(null, null);
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
                
    }
}
