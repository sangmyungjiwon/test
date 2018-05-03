using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace VOC_LIST
{
    public partial class VOC_VoluntaryReport : DevExpress.XtraEditors.XtraForm
    {
        string _strUserID = string.Empty;
        string _CustCode = string.Empty;
        string _ClaimNum = string.Empty;
        public string strYN = string.Empty;
        DataTable dt = new DataTable();

        public VOC_VoluntaryReport()
        {
            InitializeComponent();
        }

        public VOC_VoluntaryReport(string pUserID, string pCustCode, string pClaimNum)
        {
            InitializeComponent();

            _strUserID = pUserID;
            _CustCode = pCustCode;
            _ClaimNum = pClaimNum;

            Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
            dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
            dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_VoluntaryReport_SELECT";
            dbA.Procedure.ParamAdd("@CustCode", _CustCode);
            dbA.Procedure.ParamAdd("@CLAIMNUM", _ClaimNum);

            Cesco.FW.Global.DBAdapter.Utils.DebugingTools debug = new Cesco.FW.Global.DBAdapter.Utils.DebugingTools();
            string sqlQuery = debug.GetExcuteSqlString(dbA.Procedure);

            DataSet ds = dbA.ProcedureToDataSetCompress();

            if (ds.Tables[0].Rows.Count > 0)
            {
                dt= ds.Tables[0];
                txt고객코드.Text = ds.Tables[0].Rows[0]["CUSTCODE"].ToString();
                txt대분류.Text = ds.Tables[0].Rows[0]["대분류"].ToString();
                txt중분류.Text = ds.Tables[0].Rows[0]["중분류"].ToString();
                txt클레임번호.Text = ds.Tables[0].Rows[0]["CLAIMNUM"].ToString();
            }
            else
            {
                MessageBox.Show("Before Voice 건이 없습니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                strYN = "N";
                //this.Close();
                //grd자진신고.DataSource = null;
                //strYN = "N";
            }
        }

        private void VOC_VoluntaryReport_Load(object sender, EventArgs e)
        {
            try
            {
                grd자진신고.DataSource = dt;
                /*
                Cesco.FW.Global.DBAdapter.DBAdapters dbA = new Cesco.FW.Global.DBAdapter.DBAdapters();
                dbA.LocalInfo = new Cesco.FW.Global.DBAdapter.LocalInfo(_strUserID, System.Reflection.MethodBase.GetCurrentMethod());
                dbA.Procedure.ProcedureName = "CESCOEIS.dbo.SP_VOC_VoluntaryReport_SELECT";
                dbA.Procedure.ParamAdd("@CustCode", _CustCode);
                dbA.Procedure.ParamAdd("@CLAIMNUM", _ClaimNum);

                Cesco.FW.Global.DBAdapter.Utils.DebugingTools debug = new Cesco.FW.Global.DBAdapter.Utils.DebugingTools();
                string sqlQuery = debug.GetExcuteSqlString(dbA.Procedure);

                DataSet ds = dbA.ProcedureToDataSetCompress();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grd자진신고.DataSource = ds.Tables[0];
                    txt고객코드.Text = ds.Tables[0].Rows[0]["CUSTCODE"].ToString();
                    txt대분류.Text = ds.Tables[0].Rows[0]["대분류"].ToString();
                    txt중분류.Text = ds.Tables[0].Rows[0]["중분류"].ToString();
                    txt클레임번호.Text = ds.Tables[0].Rows[0]["CLAIMNUM"].ToString();
                }
                else
                {
                    MessageBox.Show("자진신고된 건이 없습니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    //grd자진신고.DataSource = null;
                    //strYN = "N";
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
