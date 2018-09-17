using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.ModuleName.Organization.MasterPage
{
    public partial class ServiceManagementForm : System.Web.UI.Page
    {
        private ServiceManagementController _objServiceManagementController;
        private NodeList _objNodeList;
        private TwoColumnsTableData _objTwoColumnsTableData;
        private ServiceManagement _objServiceManagement;
        private UserPermission _objUserPermission;
        private PackageSetup _objPackageSetup;
        private PackageSetupController _objPackageSetupController;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    PanelServiceSetup.Visible = false;
                    _objServiceManagementController = new ServiceManagementController();
                    _objServiceManagementController.PopulateRootLevel(treeNodeListOwner);
                    _objTwoColumnsTableData = new TwoColumnsTableData();
                    _objTwoColumnsTableData.CompanyID = LoginUserInformation.CompanyID;
                    _objServiceManagementController.LoadServiceCategoryType(ddlServiceCategory, _objTwoColumnsTableData);
                    _objServiceManagementController.LoadBillingFrequency(ddlBillingFrequency);
                    _objServiceManagementController.LoadPaymentType(ddlPaymentType);
                    _objServiceManagementController.LoadVATCalculationProcess(ddlVATCalculation);
                    _objServiceManagementController.LoadPackages(ddlPackage);
                    LoadServices();
                    _objServiceManagementController.PopulateRootLevel(treeNodeListForAssign);
                    _objServiceManagementController.LoadServicesDDL(ddlservices);
                    treeNodeListForAssign.Attributes.Add("onclick", "OnTreeClick(event)");
                    PanelPackageSetup.Visible = false;

                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void LoadServices()
        {
            try
            {
                _objServiceManagement = new ServiceManagement();
                _objServiceManagementController = new ServiceManagementController();
                _objServiceManagement.DtServices = _objServiceManagementController.GetServices();
                grdServices.DataSource = null;
                grdServices.DataBind();
                if (_objServiceManagement.DtServices != null)
                {
                    grdServices.DataSource = _objServiceManagement.DtServices;
                    grdServices.DataBind();
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnAddNewService_Click(object sender, EventArgs e)
        {
            try
            {
                PanelServiceCreate.Visible = false;
                PanelServiceSetup.Visible = true;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnCancelServiceSetup_Click(object sender, EventArgs e)
        {
            try
            {
                PanelServiceSetup.Visible = false;
                PanelServiceCreate.Visible = true;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                _objServiceManagementController = new ServiceManagementController();
                _objServiceManagementController.ImportDeveloperData();
                _objServiceManagementController.PopulateRootLevel(treeNodeListOwner);
                treeNodeListOwner.ExpandAll();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void treeNodeListOwner_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            try
            {
                _objServiceManagementController = new ServiceManagementController();
                _objServiceManagementController.PopulateSubLevelOwner(Int32.Parse(e.Node.Value), e.Node);
                treeNodeListOwner.ExpandAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void treeNodeListOwner_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                var nodeValue = treeNodeListOwner.SelectedNode.Value;
                lblParentValue.Text = nodeValue;
                txtTitle.Focus();
                if (Convert.ToInt32(nodeValue) == 111)
                {
                    btnUpdate.Visible = false;
                    btnCancelEdit.Visible = false;

                }
                else
                {
                    btnUpdate.Visible = true;
                    btnCancelEdit.Visible = true;
                    ViewNodeDetails(nodeValue);
                }


            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }
        private void ViewNodeDetails(string nodeValue)
        {
            try
            {
                _objNodeList = new NodeList();
                _objNodeList.NodeTypeID = Convert.ToInt32(nodeValue);
                _objServiceManagementController = new ServiceManagementController();
                txtTitle.Text = string.Empty;
                txtDescription.Text = string.Empty;
                DataTable dtNodeDetails = _objServiceManagementController.GetNodeDetails(_objNodeList);
                foreach (DataRow row in dtNodeDetails.Rows)
                {
                    txtTitle.Text = row["ActivityName"].ToString() == null ? string.Empty : row["ActivityName"].ToString();
                    txtDescription.Text = row["FormDescription"].ToString() == null ? string.Empty : row["FormDescription"].ToString();
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesForUpdate();
                treeNodeListOwner.Nodes.Clear();
                _objServiceManagementController = new ServiceManagementController();
                _objServiceManagementController.PopulateRootLevel(treeNodeListOwner);
                ClearControl();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
                treeNodeListOwner.ExpandAll();

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
                txtTitle.Text = string.Empty;
                txtDescription.Text = string.Empty;
                lblParentValue.Text = string.Empty;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private void AddValuesForUpdate()
        {
            try
            {
                _objNodeList = new NodeList();
                _objNodeList.ActivityName = txtTitle.Text == string.Empty ? null : txtTitle.Text;
                _objNodeList.FormDescription = txtDescription.Text == string.Empty ? null : txtDescription.Text;
                _objNodeList.NodeTypeID = lblParentValue.Text == string.Empty ? 0 : Convert.ToInt32(lblParentValue.Text);
                _objNodeList.EntryUserName = LoginUserInformation.UserID;
                _objServiceManagementController = new ServiceManagementController();
                _objServiceManagementController.Update(_objNodeList);


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                _objServiceManagementController = new ServiceManagementController();
                _objServiceManagementController.PopulateRootLevel(treeNodeListOwner);
                treeNodeListOwner.ExpandAll();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnCreateService_Click(object sender, EventArgs e)
        {
            try
            {

                _objServiceManagement = new ServiceManagement();
                _objServiceManagement.ServiceCategoryTypeID = Convert.ToInt32(ddlServiceCategory.SelectedValue);
                _objServiceManagement.ServiceName = txtServiceName.Text == string.Empty ? null : txtServiceName.Text;
                _objServiceManagement.ServiceValue = txtServiceValue.Text == string.Empty ? 0 : Convert.ToDouble(txtServiceValue.Text);
                _objServiceManagement.BillingFrequencyType = Convert.ToInt32(ddlBillingFrequency.SelectedValue);
                _objServiceManagement.PaymentType = Convert.ToInt32(ddlPaymentType.SelectedValue);
                _objServiceManagement.VatCalculationProcessID = Convert.ToInt32(ddlVATCalculation.SelectedValue);
                _objServiceManagement.PackageID = Convert.ToInt32( ddlPackage.SelectedValue);
                _objServiceManagement.ServiceDescription = txtServiceDescription.Text == string.Empty ? null : txtServiceDescription.Text;
                _objServiceManagement.EntryUserName = LoginUserInformation.UserID;
                _objServiceManagementController = new ServiceManagementController();
                if (btnCreateService.Text == "Update")
                {
                    _objServiceManagement.ServiceID = Convert.ToInt32( lblServiceIDValue.Text);
                    _objServiceManagement.ServiceValueID = Convert.ToInt32( lblServiceValueIDValue.Text);
                    _objServiceManagementController.UpdateServiceData(_objServiceManagement);
                }
                else
                {
                    _objServiceManagementController.SaveServiceData(_objServiceManagement);
                }

                ClearControlServiceData();
                this.LoadServices();
                _objServiceManagementController.LoadServicesDDL(ddlservices);
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControlServiceData()
        {
            try
            {
                ddlServiceCategory.SelectedValue = "-1";
                txtServiceName.Text = string.Empty;
                txtServiceValue.Text = string.Empty;
                ddlBillingFrequency.SelectedValue = "-1";
                ddlPaymentType.SelectedValue = "-1";
                ddlVATCalculation.SelectedValue = "-1";
                txtServiceDescription.Text = string.Empty;
                lblServiceIDValue.Text = string.Empty;
                lblServiceValueIDValue.Text = string.Empty;
                btnCreateService.Text = "Save";
                ddlPackage.SelectedValue = "-1";
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void grdServices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
        }

        protected void grdServices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string lblServiceID = ((Label)grdServices.Rows[selectedIndex].FindControl("lblServiceID")).Text;
            string lblServiceValueID = ((Label)grdServices.Rows[selectedIndex].FindControl("lblServiceValueID")).Text;
            if (e.CommandName.Equals("Select"))
            {
                try
                {
                    string lblServiceName = ((Label)grdServices.Rows[selectedIndex].FindControl("lblServiceName")).Text;
                    string lblServiceDescription = ((Label)grdServices.Rows[selectedIndex].FindControl("lblServiceDescription")).Text;
                    string lblBillingFrequencyType = ((Label)grdServices.Rows[selectedIndex].FindControl("lblBillingFrequencyType")).Text;
                    string lblPaymentType = ((Label)grdServices.Rows[selectedIndex].FindControl("lblPaymentType")).Text;
                    string lblServiceValue = ((Label)grdServices.Rows[selectedIndex].FindControl("lblServiceValue")).Text;
                    string lblVATCalculationProcess = ((Label)grdServices.Rows[selectedIndex].FindControl("lblVATCalculationProcess")).Text;
                    string lblServiceCategoryTypeID = ((Label)grdServices.Rows[selectedIndex].FindControl("lblServiceCategoryTypeID")).Text;
                    string lblPackageIDService = ((Label)grdServices.Rows[selectedIndex].FindControl("lblPackageIDService")).Text;
                    ddlServiceCategory.SelectedValue = lblServiceCategoryTypeID;
                    txtServiceName.Text = lblServiceName;
                    txtServiceValue.Text = lblServiceValue;
                    ddlBillingFrequency.SelectedValue = lblBillingFrequencyType;
                    ddlPaymentType.SelectedValue = lblPaymentType;
                    ddlVATCalculation.SelectedValue = lblVATCalculationProcess;
                    txtServiceDescription.Text = lblServiceDescription;
                    lblServiceIDValue.Text = lblServiceID;
                    lblServiceValueIDValue.Text = lblServiceValueID;
                    ddlPackage.SelectedValue = lblPackageIDService;
                    btnCreateService.Text = "Update";
                    
                }
                catch (Exception msgException)
                {

                    clsTopMostMessageBox.Show(msgException.Message);
                }
            }
            else if (e.CommandName.Equals("Delete"))
            {
                try
                {
                    _objServiceManagement = new ServiceManagement();
                    _objServiceManagement.ServiceID = Convert.ToInt32( lblServiceID);
                    _objServiceManagement.ServiceValueID = Convert.ToInt32( lblServiceValueID);
                    _objServiceManagementController = new ServiceManagementController();                    
                    _objServiceManagementController.DeleteService(_objServiceManagement);
                    this.LoadServices();
                    _objServiceManagementController.LoadServicesDDL(ddlservices);

                }
                catch (Exception msgException)
                {

                    clsTopMostMessageBox.Show(msgException.Message);
                }


            }
        }

        protected void grdServices_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnClearServiceData_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearControlServiceData();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void treeNodeListForAssign_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            try
            {
                _objServiceManagementController = new ServiceManagementController();
                _objServiceManagementController.PopulateSubLevelOwner(Int32.Parse(e.Node.Value), e.Node);
                treeNodeListForAssign.ExpandAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnSaveServiceNode_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesForNodeAssign();
                ClearControlNodeAssign();                
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControlNodeAssign()
        {
            try
            {
                ddlservices.SelectedValue = "-1";
                btnSaveServiceNode.Text = "Save";
                while (treeNodeListForAssign.CheckedNodes.Count > 0)
                {
                    treeNodeListForAssign.CheckedNodes[0].Checked = false;
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        List<int> listNode = new List<int>();
        private void AddValuesForNodeAssign()
        {
            try
            {
                _objServiceManagement = new ServiceManagement();
                _objUserPermission = new UserPermission();                
                _objServiceManagement.EntryUserName = LoginUserInformation.UserID;                

                foreach (TreeNode nodeNumber in this.treeNodeListForAssign.Nodes)
                {
                    saveNodePermission(nodeNumber);
                }

                _objUserPermission.nodeList = listNode;

                _objServiceManagement.ServiceID = Convert.ToInt32( ddlservices.SelectedValue);
                _objServiceManagementController = new ServiceManagementController();
                if (btnSaveServiceNode.Text == "Save")
                {
                    _objServiceManagementController.SaveAssignedNode(_objServiceManagement, _objUserPermission);

                }
                else
                {

                    _objServiceManagementController.UpdateAssignedNode(_objServiceManagement, _objUserPermission);
                }

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
                    if (targetNode.Checked)
                    {
                        listNode.Add(Convert.ToInt32(targetNode.Value.ToString()));
                    }
                    foreach (TreeNode targetChildNode in targetNode.ChildNodes)
                    {
                        saveNodePermission(targetChildNode);

                    }
                }
                else
                {
                    if (targetNode.Checked)
                    {
                        listNode.Add(Convert.ToInt32(targetNode.Value.ToString()));
                    }
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void ddlservices_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _objServiceManagement = new ServiceManagement();
                _objServiceManagement.ServiceID = Convert.ToInt32( ddlservices.SelectedValue);
                ShowNodesOfRole(_objServiceManagement);   
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ShowNodesOfRole(ServiceManagement objServiceManagement)
        {
            try
            {
                _objServiceManagementController = new ServiceManagementController();   
                DataTable dtNodes = _objServiceManagementController.GetNodesOfService(objServiceManagement);
                while (treeNodeListForAssign.CheckedNodes.Count > 0)
                {
                    treeNodeListForAssign.CheckedNodes[0].Checked = false;
                }

                foreach (DataRow rowNo in dtNodes.Rows)
                {
                    foreach (TreeNode nodeNumber in this.treeNodeListForAssign.Nodes)
                    {
                        ShowNodeInRole(nodeNumber, rowNo["NodeTypeID"].ToString());
                    }

                }

                if (dtNodes.Rows.Count > 0)
                {
                    btnSaveServiceNode.Text = "Update";
                }
                else
                {
                    btnSaveServiceNode.Text = "Save";
                }
                

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private void ShowNodeInRole(TreeNode targetNode, string nodeValue)
        {
            try
            {
                if (nodeValue == targetNode.Value)
                {
                    targetNode.Checked = true;

                }

                foreach (TreeNode targetChildNode in targetNode.ChildNodes)
                {
                    if (nodeValue == targetChildNode.Value)
                    {
                        targetChildNode.Checked = true;

                    }

                    ShowNodeInRole(targetChildNode, nodeValue);

                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnCancelNodeAssign_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControlNodeAssign();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnAddPackage_Click(object sender, EventArgs e)
        {
            try
            {
                PanelPackageSetup.Visible = true;
                PanelServiceSetup.Visible = false;
                LoadPackages();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void LoadPackages()
        {
            try
            {
                _objPackageSetup = new PackageSetup();
                _objPackageSetupController = new PackageSetupController();
                _objPackageSetup.DtPackages = _objPackageSetupController.GetPackages();
                grdPackageSetup.DataSource = null;
                grdPackageSetup.DataBind();
                if (_objPackageSetup.DtPackages != null)
                {
                    grdPackageSetup.DataSource = _objPackageSetup.DtPackages;
                    grdPackageSetup.DataBind();
                }
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        protected void btnPackageSetupCancel_Click(object sender, EventArgs e)
        {
            try
            {
                PanelPackageSetup.Visible = false;
                PanelServiceSetup.Visible = true;
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnSavePackage_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesPackageSetup();
                ClearControlPackage();
                this.LoadPackages();
                _objServiceManagementController = new ServiceManagementController();
                _objServiceManagementController.LoadPackages(ddlPackage);
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControlPackage()
        {
            try
            {
                txtPackageName.Text = string.Empty;
                txtDescriptionPackage.Text = string.Empty;
                lblPackageIdUpdate.Text = string.Empty;
                btnSavePackage.Text = "Save";
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void AddValuesPackageSetup()
        {
            try
            {
                _objPackageSetup = new PackageSetup();
                _objPackageSetup.PackageName = txtPackageName.Text == string.Empty ? null : txtPackageName.Text;
                _objPackageSetup.PackageDescription = txtDescriptionPackage.Text == string.Empty ? null : txtDescriptionPackage.Text;
                _objPackageSetup.EntryUserName = LoginUserInformation.UserID;
                _objPackageSetupController = new PackageSetupController();
                if (btnSavePackage.Text == "Save")
                {
                    _objPackageSetupController.SavePackage(_objPackageSetup);  
                }
                else
                {
                    _objPackageSetup.PackageID = Convert.ToInt32( lblPackageIdUpdate.Text);
                    _objPackageSetupController.UpdatePackage(_objPackageSetup);
                }
                

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        protected void btnClearPackage_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearControlPackage();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void grdPackageSetup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
        }

        protected void grdPackageSetup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdPackageSetup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string lblPackageID = ((Label)grdPackageSetup.Rows[selectedIndex].FindControl("lblPackageID")).Text;
                if (e.CommandName.Equals("Select"))
                {
                    string lblPackageName = ((Label)grdPackageSetup.Rows[selectedIndex].FindControl("lblPackageName")).Text;
                    string lblPackageDescription = ((Label)grdPackageSetup.Rows[selectedIndex].FindControl("lblPackageDescription")).Text;
                    txtPackageName.Text = lblPackageName;
                    txtDescriptionPackage.Text = lblPackageDescription;
                    lblPackageIdUpdate.Text = lblPackageID;
                    btnSavePackage.Text = "Update";
                    
                }
                else if (e.CommandName.Equals("Delete"))
                {
                    _objPackageSetup = new PackageSetup();
                    _objPackageSetup.PackageID = Convert.ToInt32( lblPackageID);
                    _objPackageSetupController = new PackageSetupController();
                    _objPackageSetupController.DeletePackage(_objPackageSetup);
                    this.LoadPackages();
                    _objServiceManagementController = new ServiceManagementController();
                    _objServiceManagementController.LoadPackages(ddlPackage);
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        
    }
}