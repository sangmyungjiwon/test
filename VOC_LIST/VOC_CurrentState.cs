using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraGrid.Views.Grid;
using CES.FUNCTION;
using System.Diagnostics;

namespace VOC_LIST
{
    public partial class VOC_CurrentState : DevExpress.XtraEditors.XtraUserControl
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

        public VOC_CurrentState()
        {
            InitializeComponent();
        }

        public VOC_CurrentState(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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

        private void VOC_CurrentState_Load(object sender, EventArgs e)
        {
            setLue(luePro_Dept, 0, "", "부서코드", "부서명", "");

            dtFrom.DateTime = DateTime.Now;
            dtTo.DateTime = DateTime.Now;

            if (Convert.ToInt32(_strDeptCode) >= 10280 && Convert.ToInt32(_strDeptCode) < 50030)
            {
                luePro_Dept.EditValue = _strDeptCode;
                luePro_Dept.Enabled = false;
                luePro_User.Enabled = true;

            }
            else if (Convert.ToInt32(_strDeptCode) >= 51000 && Convert.ToInt32(_strDeptCode) <= 59000)
            {
                Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

                db.Procedure.ProcedureName = "CESNET2.dbo.SP_DEPT_SEARCH_Include";
                db.Procedure.ParamAdd("@부서코드", _strDeptCode);

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
                luePro_Dept.EditValue = _strDeptCode;
                luePro_Part.EditValue = "";
                luePro_User.EditValue = _strUserID;
                luePro_Dept.Enabled = true;
                luePro_User.Enabled = true;
            }
            else
            {
                luePro_Dept.Enabled = true;
                luePro_User.Enabled = true;
            }
        }

        private void setLue(LookUpEdit lueNm, int i, string paramValue, string valMem, string disMem, string paramValuePart)
        {
            Cesco.FW.Global.DBAdapter.DBAdapters db = new Cesco.FW.Global.DBAdapter.DBAdapters(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());

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

        private void luePro_Dept_EditValueChanged(object sender, EventArgs e)
        {
            setLue(luePro_Part, 3, luePro_Dept.EditValue.ToString(), "파트코드", "파트명", "");
           
            luePro_User.EditValue = "";
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_CurrentState_SELECT_MULTI"; //SP_VOC_CurrentState_SELECT_MULTI 다중처리자 적용 프로시저 
                dbA.Procedure.ParamAdd("@From", dtFrom.DateTime.ToString("yyyyMMdd"));
                dbA.Procedure.ParamAdd("@To", dtTo.DateTime.ToString("yyyyMMdd"));
                dbA.Procedure.ParamAdd("@DeptCode", luePro_Dept.EditValue.ToString());
                dbA.Procedure.ParamAdd("@UserID", luePro_User.EditValue.ToString());
                dbA.Procedure.ParamAdd("@PartCode", luePro_Part.EditValue == null ? "" : luePro_Part.EditValue.ToString());

                Cesco.FW.Global.DBAdapter.Utils.DebugingTools debug = new Cesco.FW.Global.DBAdapter.Utils.DebugingTools();
                string sqlQuery = debug.GetExcuteSqlString(dbA.Procedure);

                this.Cursor = Cursors.WaitCursor;
                DataSet ds = dbA.ProcedureToDataSetCompress();
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    pv현황.RefreshData();
                    pv현황.DataSource = null;
                    pv현황.DataSource = ds.Tables[0];
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    pv현황.RefreshData();
                    pv현황.DataSource = null;
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ExportToExcel(pv현황, _strUserID);

            string fileName = string.Empty;
            Cesco.FW.Global.DevExpressUtil.Grid.ConvertExcel ce = new Cesco.FW.Global.DevExpressUtil.Grid.ConvertExcel();
            fileName = ce.GridToExcelReturnName(pv현황, _strUserID);

            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.Start();
        }

        public bool ExportToExcel(DevExpress.XtraPivotGrid.PivotGridControl gridControl, string userId)
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
                        System.IO.FileStream fs = new System.IO.FileStream(oSaveFileDialog.FileName, System.IO.FileMode.Create);

                        if (oSaveFileDialog.FileName.EndsWith(".xls"))
                            gridControl.ExportToXls(fs);
                        else
                            gridControl.ExportToXlsx(fs);

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

        private void luePro_Part_EditValueChanged(object sender, EventArgs e)
        {
            setLue(luePro_User, 1, luePro_Dept.EditValue.ToString(), "사번", "한글성명", Convert.ToString(luePro_Part.EditValue));
        }
    }
}
