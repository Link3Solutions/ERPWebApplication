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
        private CompanySetup _objCompanySetup;
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
                    LoadRoleRecordGrid();
                    LoadRoleRecordList();

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void LoadRoleRecordList()
        {
            try
            {
                _objCompanySetup = new CompanySetup();
                _objCompanySetup.CompanyID = LoginUserInformation.CompanyID;
                _objUserPermission = new UserPermission();
                _objUserPermission.RoleType = ddlRoleTypeUser.SelectedValue;
                _objUserPermissionController = new UserPermissionController();
                _objUserPermissionController.GetRoleRecord(_objCompanySetup, _objUserPermission, ListBoxRoles);

            }
            catch (Exception msgException)
            {
                
                throw msgException; 
            }
        }

        private void LoadRoleRecordGrid()
        {
            try
            {
                _objCompanySetup = new CompanySetup();
                _objCompanySetup.CompanyID = LoginUserInformation.CompanyID;
                _objUserPermission = new UserPermission();
                _objUserPermission.RoleType = ddlRoleType.SelectedValue;
                _objUserPermissionController = new UserPermissionController();
                _objUserPermissionController.GetRoleRecord(_objCompanySetup,_objUserPermission,GridViewRoles);
            }
            catch (Exception msgExceptin)
            {
                
                throw msgExceptin;
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
                ClearControl();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControl()
        {
            try
            {
                ddlRoleType.SelectedValue = "-1";
                txtRoleTitle.Text = string.Empty;
                

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
        List<int> list = new List<int>();
        private void AddValuesForRoleSetup()
        {
            try
            {
                _objUserPermission = new UserPermission();
                _objCompanySetup = new CompanySetup();
                _objCompanySetup.CompanyID = LoginUserInformation.CompanyID;
                _objCompanySetup.EntryUserName = LoginUserInformation.UserID;
                _objUserPermission.RoleName = txtRoleTitle.Text == string.Empty ? null : txtRoleTitle.Text;
                
                foreach (TreeNode nodeNumber in this.TreeViewAllNode.Nodes)
                {
                    saveNodePermission(nodeNumber);
                }
                
                _objUserPermission.nodeList = list;
                
                _objUserPermission.RoleType = ddlRoleType.SelectedValue == "-1" ? null : ddlRoleType.SelectedValue;
                _objUserPermissionController = new UserPermissionController();
                _objUserPermissionController.SaveRoleData(_objCompanySetup,_objUserPermission);
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void saveNodePermission(TreeNode targetNode)
        {
            try
            {
                if (targetNode.ChildNodes.Count > 0)
                {
                    foreach (TreeNode targetChildNode in targetNode.ChildNodes)
                    {
                        saveNodePermission(targetChildNode);
                    }
                }
                else
                {
                    if (targetNode.Checked)
                    {
                        list.Add(Convert.ToInt32(targetNode.Value.ToString()));
                    }
                }

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        protected void ddlRoleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadRoleRecordGrid();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void ddlRoleTypeUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadRoleRecordList();

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}