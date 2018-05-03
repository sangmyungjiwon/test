using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CES.DbConnection;

namespace DocManagement
{
    public partial class VOC_UserCheck : DevExpress.XtraEditors.XtraForm
    {
        string str_UserIDNm = string.Empty;
        public string str_CheckedUser = string.Empty;
        public string str_CheckedUserDept = string.Empty;
        public string str_CheckedUserID = string.Empty;
        public string str_CheckedUserDeptCode = string.Empty;
        DataTable dt_Auth_Check = new DataTable();

        public VOC_UserCheck()
        {
            InitializeComponent();
        }
        public VOC_UserCheck(string _strUserID, DataTable dt_Auth)
            :this()
        {
            str_UserIDNm = _strUserID;
            dt_Auth_Check = dt_Auth;
        }

        private void Doc_UserCheck_Load(object sender, EventArgs e)
        {
            setEmpList();
        }

        private void setEmpList()
        {
            this.Cursor = Cursors.WaitCursor;

            DbConn conn = new DbConn();
            conn.ProcedureName = "ASSI.dbo.SP_CategoryMng_AuthMng_Category_AddUser";
            conn.ParamAdd("@UserNmID", str_UserIDNm);
            DataSet ds = conn.ExecProcedure();
           
            if (conn.IsError)
            {
                XtraMessageBox.Show(conn.ErrorMsg);
            }
            else
            {
                gcEmpList.DataSource = ds.Tables[0];
            }

            this.Cursor = Cursors.Default;
        }

        private void gvEmpList_DoubleClick(object sender, EventArgs e)
        {
            if (dt_Auth_Check != null)
            {
                DataRow[] rows_Y = dt_Auth_Check.Select("사번=" + "'" + gvEmpList.GetFocusedRowCellValue("사번").ToString() + "'");
                if (rows_Y.Length > 0)
                {
                    MessageBox.Show("이미 추가된 사원입니다.", "사원 중복", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (gvEmpList.FocusedRowHandle > -1)
            {
                str_CheckedUser = gvEmpList.GetFocusedRowCellValue("한글성명").ToString();
                str_CheckedUserDept = gvEmpList.GetFocusedRowCellValue("부서명").ToString();
                str_CheckedUserID = gvEmpList.GetFocusedRowCellValue("사번").ToString();
                str_CheckedUserDeptCode = gvEmpList.GetFocusedRowCellValue("부서코드").ToString();
            }
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            gvEmpList_DoubleClick(null, null);
        }
    }
}