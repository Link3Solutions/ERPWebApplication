using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;

namespace ERPWebApplication.ModuleName.Organization.MasterPage
{
    public partial class UserPermissionForm : System.Web.UI.Page
    {
        private UserPermissionController _objUserPermissionController;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Session["companyID"] = 1;
                    _objUserPermissionController = new UserPermissionController();
                    _objUserPermissionController.PopulateRootLevel(TreeViewAllNode);
                    _objUserPermissionController.LoadRoleTypeData(ddlRoleType);

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void TreeViewAllNode_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            try
            {
                _objUserPermissionController = new UserPermissionController();
                _objUserPermissionController.PopulateSubLevel(Int32.Parse(e.Node.Value), e.Node);
                TreeViewAllNode.ExpandAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}