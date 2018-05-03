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
    public partial class VOC_Form : DevExpress.XtraEditors.XtraForm
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

        string strDist = string.Empty;
        string strStateCode = string.Empty;

        string strDateFrom = string.Empty;
        string strDateTo = string.Empty;
        string strDept = string.Empty;
        string strRgVOC = string.Empty;
        string strPopGubun = string.Empty;
        string strUserID_Proc = string.Empty;
        string strDist_Proc = string.Empty;
        string strUser_Part = string.Empty;
        string strMonitoring = string.Empty;
        string strVoc_Prob = string.Empty;

        #endregion

        public VOC_Form()
        {
            InitializeComponent();
        }

        public VOC_Form(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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
        public VOC_Form(string pUserID, string pDeptCode, string pDist, string pStateCode, string pDateFrom, string pDateTo, string pRgVOC, string pUserID_Proc, string pDist_Proc, string pUser_Part, string pMonitoring, string pVoc_Prob)
        {
            InitializeComponent();
            //VOC_Form.ActiveForm.Text = "VOC_리스트";
            strPopGubun = "1";
            strUserID = pUserID;
            strDeptCode = pDeptCode;
            strDist = pDist;
            strStateCode = pStateCode;
            strDateFrom = pDateFrom;
            strDateTo = pDateTo;
            strRgVOC = pRgVOC;
            strUserID_Proc = pUserID_Proc;
            strDist_Proc = pDist_Proc;
            strUser_Part = pUser_Part;
            strMonitoring = pMonitoring;
            strVoc_Prob = pVoc_Prob;
        }

        private void VOC_Form_Load(object sender, EventArgs e)
        {
            VOC_TotalStatMng_List VTL = new VOC_TotalStatMng_List(strUserID, strDeptCode, strDist, strStateCode, strDateFrom, strDateTo, strRgVOC, strUserID_Proc, strDist_Proc, strUser_Part, strMonitoring, strVoc_Prob);
            VTL.Dock = DockStyle.Fill;
            panelControl.Controls.Add(VTL);
        }

        
    }
}