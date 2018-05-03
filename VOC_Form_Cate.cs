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
    public partial class VOC_Form_Cate : DevExpress.XtraEditors.XtraForm
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
        string strGubun = string.Empty;
        string strGubun_Detail = string.Empty;
        string strVoc_Prob = string.Empty;

        #endregion

        public VOC_Form_Cate()
        {
            InitializeComponent();
        }

        public VOC_Form_Cate(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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

        public VOC_Form_Cate(string pUserID, string pDeptCode, string pDateFrom, string pDateTo, string pDept, string pRgVOC, string pGubun, string pGubun_Detail, string pVoc_Prob, string pTemp)
        {
            InitializeComponent();
            strUserID = pUserID;
            strDeptCode = pDeptCode;
            strDateFrom = pDateFrom;
            strDateTo = pDateTo;
            strDept = pDept;
            strRgVOC = pRgVOC;
            strGubun = pGubun;
            strGubun_Detail = pGubun_Detail;
            strVoc_Prob = pVoc_Prob;
        }


        private void VOC_Form_Load(object sender, EventArgs e)
        {
            VOC_TotalStateMng_Category VTC = new VOC_TotalStateMng_Category(strUserID, strDeptCode, strDateFrom, strDateTo, strDept, strRgVOC, strGubun, strGubun_Detail, strVoc_Prob, "");
            VTC.Dock = DockStyle.Fill;
            panelControl.Controls.Add(VTC);

        }

        
    }
}