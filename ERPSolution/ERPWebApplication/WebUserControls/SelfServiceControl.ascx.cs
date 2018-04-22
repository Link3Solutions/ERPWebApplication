using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebApplication.WebUserControls
{
    public partial class SelfServiceControl : System.Web.UI.UserControl
    {
        private UserPermissionController _objUserPermissionController;        
        private NodeList _objNodeList;
        private EmployeeSetup _objEmployeeSetup;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _objUserPermissionController = new UserPermissionController();
                    _objEmployeeSetup = new EmployeeSetup();
                    _objEmployeeSetup.CompanyID = LoginUserInformation.CompanyID;
                    _objEmployeeSetup.EntryUserName = LoginUserInformation.UserID;
                    _objNodeList = new NodeList();
                    _objNodeList.ActivityID = 4;                    
                    _objUserPermissionController.PopulateDashBoard(grdFormDashboard, _objEmployeeSetup, _objNodeList);
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void grdFormDashboard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';this.style.color='blue';";
            //    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
            //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grdFormDashboard, "Select$" + e.Row.RowIndex);
            //}
        }
    }
}