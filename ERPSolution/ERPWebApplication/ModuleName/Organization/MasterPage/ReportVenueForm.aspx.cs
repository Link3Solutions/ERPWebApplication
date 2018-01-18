using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebApplication.ModuleName.Organization.MasterPage
{
    public partial class ReportVenueForm : System.Web.UI.Page
    {
        private UserPermissionController _objUserPermissionController;
        private UserPermission _objUserPermission;
        private CompanySetup _objCompanySetup;
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
                    _objNodeList.ActivityID = 5;
                    _objNodeList.ShowPosition = 2;
                    _objUserPermissionController.PopulateRootLevel(TreeViewReportNode,_objEmployeeSetup,_objNodeList);
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void TreeViewReportNode_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            try
            {
                _objUserPermissionController = new UserPermissionController();
                _objEmployeeSetup = new EmployeeSetup();
                _objEmployeeSetup.EntryUserName = LoginUserInformation.UserID;
                _objUserPermissionController.PopulateSubLevelReport(Int32.Parse(e.Node.Value), e.Node,_objEmployeeSetup);
                TreeViewReportNode.ExpandAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}