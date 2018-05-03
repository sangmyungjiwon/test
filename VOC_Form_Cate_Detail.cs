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
    public partial class VOC_Form_Cate_Detail : DevExpress.XtraEditors.XtraForm
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
        string strVOCID_BIG = string.Empty;
        string strVOCID_MID = string.Empty;
        string strVOCID_SM = string.Empty;

        string strrgVOC = string.Empty;
        string strDeptDetail = string.Empty;

        string strGubun = string.Empty;
        string strGubun_Detail = string.Empty;
        string strVOC_Prob = string.Empty;
        #endregion

        public VOC_Form_Cate_Detail()
        {
            InitializeComponent();
        }

        public VOC_Form_Cate_Detail(string pUserID, string pDeptCode, string pInsertAuth, string pUpdateAuth, string pDeleteAuth, string pSearchAuth, string pPrintAuth, string pExcelAuth, string pDataAuth)
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

        public VOC_Form_Cate_Detail(string pUserID, string pDeptCode, string pDateFrom, string pDateTo, string pDept, string prgVOC, string pDeptDetail, string pVOCID_BIG, string pVOCID_MID, string pVOCID_SM, string pGubun, string pGubun_Detail, string pVoc_Prob)
        {
            InitializeComponent();
            strUserID = pUserID;
            strDeptCode = pDeptCode;
            strDateFrom = pDateFrom;
            strDateTo = pDateTo;
            strDept = pDept;
            strVOCID_BIG = pVOCID_BIG;
            strVOCID_MID = pVOCID_MID;
            strVOCID_SM = pVOCID_SM;
            strDeptDetail = pDeptDetail;
            strrgVOC = prgVOC;
            strGubun = pGubun;
            strGubun_Detail = pGubun_Detail;
            strVOC_Prob = pVoc_Prob;
        }


        private void VOC_Form_Load(object sender, EventArgs e)
        {
            VOC_TotalStateMng_Category_Detail VTC = new VOC_TotalStateMng_Category_Detail(strUserID, strDeptCode, strDateFrom, strDateTo, strDept, strrgVOC, strDeptDetail, strVOCID_BIG, strVOCID_MID, strVOCID_SM, strGubun, strGubun_Detail, strVOC_Prob);
            VTC.Dock = DockStyle.Fill;
            panelControl.Controls.Add(VTC);

        }

        
    }
}