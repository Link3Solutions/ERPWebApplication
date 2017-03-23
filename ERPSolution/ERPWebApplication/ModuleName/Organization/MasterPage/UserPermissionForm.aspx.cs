using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.ModuleName.Organization.MasterPage
{
    public partial class UserPermissionForm : System.Web.UI.Page
    {
        private UserPermissionController _objUserPermissionController;
        private UserPermission _objUserPermission;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _objUserPermissionController = new UserPermissionController();
                    _objUserPermissionController.PopulateRootLevel(TreeViewAllNode);
                    _objUserPermissionController.LoadRoleTypeData(ddlRoleType);
                    _objUserPermissionController.LoadRoleTypeData(ddlRoleTypeUser);

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

        protected void btnRoleSave_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesForRoleSetup();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void AddValuesForRoleSetup()
        {
            try
            {
                _objUserPermission = new UserPermission();
                CompanySetup objCompanySetup = new CompanySetup();
                objCompanySetup.CompanyID = LoginUserInformation.CompanyID;
                objCompanySetup.EntryUserName = LoginUserInformation.UserID;
                _objUserPermission.RoleName = txtRoleTitle.Text == string.Empty ? null : txtRoleTitle.Text;
                
                foreach (TreeNode nodeNumber in TreeViewAllNode.Nodes)
                {
                    if (nodeNumber.Checked == true)
                    {
                        _objUserPermission.NodeID = Convert.ToInt32(nodeNumber.Value.ToString());
                        _objUserPermission.nodeList.Add(_objUserPermission.NodeID);
                        
                    }
                }
                _objUserPermission.RoleType = ddlRoleType.SelectedValue == "-1" ? null : ddlRoleType.SelectedValue;
                _objUserPermissionController = new UserPermissionController();
                _objUserPermissionController.SaveRoleData(objCompanySetup,_objUserPermission);
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}