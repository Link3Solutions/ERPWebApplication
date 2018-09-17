using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication
{
    public partial class ServiceRequestForm : System.Web.UI.Page
    {
        private ServiceRequest _objServiceRequest;
        private ServiceRequestController _objServiceRequestController;
        private ServiceManagement _objServiceManagement;
        private ServiceManagementController _objServiceManagementController;
        private PackageSetup _objPackageSetup;
        private PackageSetupController _objPackageSetupController;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblNameoftheModule.Text = Session["moduleName"].ToString();
                ControlPanelVisibility(PanelSubModuleLogo, PanelModuleDescription, PanelUserAccount, PanelCreateAccount, PanelUserLogin);
                _objPackageSetup = new PackageSetup();
                _objPackageSetup.PackageName = Session["moduleName"].ToString();
                LoadServices(_objPackageSetup);
                _objServiceManagement = new ServiceManagement();
                _objServiceManagement.ServiceID = lblSelectedSerciceID.Text == string.Empty ? 0 : Convert.ToInt32( lblSelectedSerciceID.Text);                
                LoadServiceDescription(_objServiceManagement);
                LoadNodeCollection(_objServiceManagement);
                LoadServicePricing(_objServiceManagement);
                LoadServicePreviousPricing(_objServiceManagement);

            }

        }

        private void LoadServicePreviousPricing(ServiceManagement objServiceManagement)
        {
            try
            {
                _objServiceManagementController = new ServiceManagementController();
                string previousPrice = "BDT " + (_objServiceManagementController.GetServicePreviousPrice(objServiceManagement) == null ? "0.00" : Convert.ToDouble(_objServiceManagementController.GetServicePrice(objServiceManagement)).ToString("0.00")).ToString() + "&nbsp;&nbsp;";
                lblPreviousPrice.Text = previousPrice;
                //if (lblPreviousPrice.Text.Trim() == "BDT 0.00&nbsp;&nbsp;")
                //{
                //    lblPreviousPrice.Visible = false;
                //}
                //else
                //{
                //    lblPreviousPrice.Visible = true;
                //}

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void LoadServicePricing(ServiceManagement objServiceManagement)
        {
            try
            {
                _objServiceManagementController = new ServiceManagementController();
                string currentPrice = "BDT " + (_objServiceManagementController.GetServicePrice(objServiceManagement) == null ? "0.00" : Convert.ToDouble(_objServiceManagementController.GetServicePrice(objServiceManagement)).ToString("0.00")).ToString() + "&nbsp;&nbsp;";
                lblPrice.Text = currentPrice;
                
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void GetValue(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
                _objServiceManagement = new ServiceManagement();
                _objServiceManagement.ServiceID = Convert.ToInt32((item.FindControl("lblServiceIDReapeter") as Label).Text);
                lblSelectedSerciceID.Text = _objServiceManagement.ServiceID.ToString();
                LoadServicePricing(_objServiceManagement);
                LoadServiceDescription(_objServiceManagement);
                LoadNodeCollection(_objServiceManagement);
                LoadServicePreviousPricing(_objServiceManagement);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void LoadServiceDescription(ServiceManagement objServiceManagement)
        {
            try
            {
                _objServiceManagementController = new ServiceManagementController();

                objServiceManagement.DtServiceDescription = _objServiceManagementController.GetServiceDescription(objServiceManagement);
                RepeaterServiceDescription.DataSource = null;
                RepeaterServiceDescription.DataBind();
                if (objServiceManagement.DtServiceDescription != null)
                {
                    RepeaterServiceDescription.DataSource = objServiceManagement.DtServiceDescription;
                    RepeaterServiceDescription.DataBind();
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void LoadNodeCollection(ServiceManagement objServiceManagement)
        {
            try
            {
                _objServiceManagementController = new ServiceManagementController();
                NodeList objNodeList = new NodeList();
                objNodeList.DtNodeList = _objServiceManagementController.GetNodeOfServices(objServiceManagement);
                RepeateNodeCollection.DataSource = null;
                RepeateNodeCollection.DataBind();
                if (objNodeList.DtNodeList != null)
                {
                    RepeateNodeCollection.DataSource = objNodeList.DtNodeList;
                    RepeateNodeCollection.DataBind();
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void LoadServices(PackageSetup objPackageSetup)
        {
            try
            {
                switch (objPackageSetup.PackageName)
                {
                    case "HRMS": { objPackageSetup.PackageID = 1; break; }
                    case "Accounts": { objPackageSetup.PackageID = 2; break; }
                    case "Inventory": { objPackageSetup.PackageID = 3; break; }
                    default:
                        break;
                }

                LoadPackageDescription(objPackageSetup);


                _objServiceManagement = new ServiceManagement();
                _objServiceManagementController = new ServiceManagementController();
                _objServiceManagement.DtServices = _objServiceManagementController.GetServices(objPackageSetup);
                RepeaterServices.DataSource = null;
                RepeaterServices.DataBind();
                if (_objServiceManagement.DtServices != null)
                {
                    RepeaterServices.DataSource = _objServiceManagement.DtServices;
                    RepeaterServices.DataBind();

                    lblSelectedSerciceID.Text = _objServiceManagement.DtServices.Rows[0].ItemArray[0].ToString();
                    
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }





        private void LoadPackageDescription(PackageSetup objPackageSetup)
        {
            try
            {
                _objPackageSetup = new PackageSetup();
                _objPackageSetupController = new PackageSetupController();
                _objPackageSetup.DtPackages = _objPackageSetupController.GetPackageDescription(objPackageSetup);
                RepeaterModuleDescription.DataSource = null;
                RepeaterModuleDescription.DataBind();
                if (_objPackageSetup.DtPackages != null)
                {
                    RepeaterModuleDescription.DataSource = _objPackageSetup.DtPackages;
                    RepeaterModuleDescription.DataBind();
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        private void ControlPanelVisibility(Panel panelTarget1, Panel panelTarget2, Panel PanelOptional1, Panel PanelOptional2, Panel PanelOptional3)
        {
            try
            {
                panelTarget1.Visible = true;
                panelTarget2.Visible = true;
                PanelOptional1.Visible = false;
                PanelOptional2.Visible = false;
                PanelOptional3.Visible = false;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void ControlPanelVisibility(Panel targetPanel, Panel panelOptional1, Panel panelOptional2, Panel panelOptional3)
        {
            try
            {
                targetPanel.Visible = true;
                panelOptional1.Visible = false;
                panelOptional2.Visible = false;
                panelOptional3.Visible = false;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            try
            {
                ControlPanelVisibilityPlaceOrder(PanelUserAccount, PanelSubModuleLogo, PanelModuleDescription, PanelCreateAccount, PanelUserLogin);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ControlPanelVisibilityPlaceOrder(Panel panelTarget1, Panel PanelOptional1, Panel PanelOptional2, Panel PanelOptional3, Panel PanelOptional4)
        {
            try
            {
                panelTarget1.Visible = true;
                PanelOptional1.Visible = false;
                PanelOptional2.Visible = false;
                PanelOptional3.Visible = false;
                PanelOptional4.Visible = false;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                ControlPanelVisibility(PanelCreateAccount, PanelUserAccount, PanelUserLogin);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ControlPanelVisibility(Panel panelTarget1, Panel PanelOptional1, Panel PanelOptional2)
        {
            try
            {
                panelTarget1.Visible = true;
                PanelOptional1.Visible = false;
                PanelOptional2.Visible = false;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnSigninPanel_Click(object sender, EventArgs e)
        {
            try
            {
                ControlPanelVisibility(PanelUserLogin, PanelCreateAccount, PanelUserAccount);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void lnkbtnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                ControlPanelVisibility(PanelUserLogin, PanelCreateAccount, PanelUserAccount);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void lnkbtnCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                ControlPanelVisibility(PanelCreateAccount, PanelUserAccount, PanelUserLogin);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void btnTakeService_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesTakeService();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void AddValuesTakeService()
        {
            try
            {
                _objServiceManagement = new ServiceManagement();
                _objServiceManagement.ServiceID = Convert.ToInt32( lblSelectedSerciceID.Text);

                _objServiceManagementController = new ServiceManagementController();
                _objServiceManagement.DtServiceDescription = _objServiceManagementController.GetServiceDetails(_objServiceManagement);
               
                //CheckValidation(nameOfDegree);
                foreach (DataRow dr in _objServiceManagement.DtServiceDescription.Rows)
                {
                    var serviceNameTemp = dr["ServiceName"].ToString();
                    var serviceIDTemp = Convert.ToInt32(dr["ServiceID"].ToString());
                    byte[] serviceLogoTemp = (byte[])dr.ItemArray[2]; 
                    var serviceValueTemp = Convert.ToDouble(dr["ServiceValue"].ToString());
                    _objServiceManagement.ServiceName = serviceNameTemp;
                    CheckValidation(_objServiceManagement);
                    this.BindSelectedServicesGrid(serviceLogoTemp,serviceNameTemp,serviceValueTemp,serviceIDTemp);
                    
                }
                
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void CheckValidation(ServiceManagement objServiceManagement)
        {
            try
            {
                if (ViewState["SelectedServices"] != null)
                {
                    var dt = (DataTable)ViewState["SelectedServices"];
                    var any = (from DataRow dr in dt.Rows select dr["colServiceID"].ToString()).Any(columnValue => objServiceManagement.ServiceID.ToString() == columnValue);
                    if (any == true)
                    {
                        throw new Exception(objServiceManagement.ServiceName + " service already exists !");
                    }
                }
                
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
        private void BindSelectedServicesGrid(byte[] serviceLogo, string serviceName, double serviceValue, int serviceID)
        {
            var dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("colServiceID", typeof(int)));
            dt.Columns.Add(new DataColumn("colServiceLogo", typeof(byte[])));
            dt.Columns.Add(new DataColumn("colServiceName", typeof(String)));
            dt.Columns.Add(new DataColumn("colServiceValue", typeof(double)));
            

            if (ViewState["SelectedServices"] != null)
            {
                var dtTable = (DataTable)ViewState["SelectedServices"];
                var count = dtTable.Rows.Count;
                for (var i = 0; i < count + 1; i++)
                {
                    dt = (DataTable)ViewState["SelectedServices"];
                    if (dt.Rows.Count <= 0) continue;
                    dr = dt.NewRow();
                    dr[0] = dt.Rows[0][0].ToString();
                }
                dr = dt.NewRow();
                dr[0] = serviceID ;
                dr[1] = serviceLogo;
                dr[2] = serviceName;
                dr[3] = serviceValue;
               
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = serviceID;
                dr[1] = serviceLogo;
                dr[2] = serviceName;
                dr[3] = serviceValue;
                dt.Rows.Add(dr);
            }
            if (ViewState["SelectedServices"] != null)
            {
                grdSelectedServices.DataSource = ViewState["SelectedServices"];
                grdSelectedServices.DataBind();
            }
            else
            {
                grdSelectedServices.DataSource = dt;
                grdSelectedServices.DataBind();

            }
            ViewState["SelectedServices"] = dt;
        }

        protected void grdSelectedServices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
            
        }

        protected void grdSelectedServices_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        protected void grdSelectedServices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                var con = Convert.ToInt32(e.CommandArgument.ToString());

                if (!e.CommandName.Equals("Delete")) return;
                var dt = (DataTable)ViewState["SelectedServices"];
                dt.Rows[con].Delete();
                dt.AcceptChanges();
                ViewState["SelectedServices"] = dt;
                if (ViewState["SelectedServices"] == null) return;
                grdSelectedServices.DataSource = ViewState["SelectedServices"];
                grdSelectedServices.DataBind();
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


    }
}