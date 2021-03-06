﻿using System;
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

namespace ERPWebApplication.ModuleName.Organization.MasterPage
{
    public partial class ServiceServeForm : System.Web.UI.Page
    {
        private ServiceRequest _objServiceRequest;
        private ServiceRequestController _objServiceRequestController;
        private ServiceManagement _objServiceManagement;
        private ServiceManagementController _objServiceManagementController;
        private PackageSetup _objPackageSetup;
        private PackageSetupController _objPackageSetupController;
        private ServiceServe _objServiceServe;
        private ServiceServeController _objServiceServeController;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["moduleName"] = "HRMS";
                lblNameoftheModule.Text = Session["moduleName"].ToString();                
                _objPackageSetup = new PackageSetup();
                _objPackageSetup.PackageName = Session["moduleName"].ToString();
                LoadServices(_objPackageSetup);
                _objServiceManagement = new ServiceManagement();
                _objServiceManagement.ServiceID = lblSelectedSerciceID.Text == string.Empty ? 0 : Convert.ToInt32(lblSelectedSerciceID.Text);
                LoadServiceDescription(_objServiceManagement);
                LoadNodeCollection(_objServiceManagement);
                LoadServicePricing(_objServiceManagement);
                LoadServicePreviousPricing(_objServiceManagement);
                ControlPlaceOrderVisibility();
                _objPackageSetup = new PackageSetup();
                _objPackageSetup.PackageName = Session["moduleName"].ToString();
                LoadPackages(_objPackageSetup);
            }

        }

        private void LoadPackages(PackageSetup objPackageSetup)
        {
            try
            {
                _objPackageSetup = new PackageSetup();
                _objPackageSetupController = new PackageSetupController();
                _objPackageSetup.DtPackages = _objPackageSetupController.GetOtherPackages(objPackageSetup);
                RepeaterOtherPackages.DataSource = null;
                RepeaterOtherPackages.DataBind();
                if (_objPackageSetup.DtPackages != null)
                {
                    RepeaterOtherPackages.DataSource = _objPackageSetup.DtPackages;
                    RepeaterOtherPackages.DataBind();
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void ControlPlaceOrderVisibility()
        {
            try
            {
                if (grdSelectedServices.Rows.Count > 0)
                {
                    PanelSelectedServices.Visible = true;
                    lblTotalTitle.Visible = true;
                    lblTotalVale.Visible = true;
                    btnServe.Visible = true;
                }
                else
                {
                    PanelSelectedServices.Visible = false;
                    lblTotalTitle.Visible = false;
                    lblTotalVale.Visible = false;
                    btnServe.Visible = false;
                }
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void LoadServicePreviousPricing(ServiceManagement objServiceManagement)
        {
            try
            {
                _objServiceManagementController = new ServiceManagementController();
                string previousPrice = "BDT " + (_objServiceManagementController.GetServicePreviousPrice(objServiceManagement) == null ? "0.00" : Convert.ToDouble(_objServiceManagementController.GetServicePrice(objServiceManagement)).ToString("0.00")).ToString() + "&nbsp;&nbsp;";
                lblPreviousPrice.Text = previousPrice;

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
                foreach (RepeaterItem ri in RepeaterServices.Items)
                {
                    LinkButton lnkbtnServiceDetailsTemp = ri.FindControl("lnkbtnServiceDetails") as LinkButton;
                    lnkbtnServiceDetailsTemp.Visible = true;
                }


                RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
                _objServiceManagement = new ServiceManagement();
                _objServiceManagement.ServiceID = Convert.ToInt32((item.FindControl("lblServiceIDReapeter") as Label).Text);
                lblSelectedSerciceID.Text = _objServiceManagement.ServiceID.ToString();
                LoadServicePricing(_objServiceManagement);
                LoadServiceDescription(_objServiceManagement);
                LoadNodeCollection(_objServiceManagement);
                LoadServicePreviousPricing(_objServiceManagement);
                LinkButton lnkbtnServiceDetails = (item.FindControl("lnkbtnServiceDetails") as LinkButton);
                lnkbtnServiceDetails.Visible = false;
                
                Label lblServiceName =(item.FindControl("lblServiceName") as Label);
                lblServiceDescription.Text = "Description of " + lblServiceName.Text;
                
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
                    ControlDetailsVisiability();
                    lblServiceDescription.Text = "Description of " + _objServiceManagement.DtServices.Rows[0].ItemArray[1].ToString(); 
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        private void ControlDetailsVisiability()
        {
            try
            {
                foreach (RepeaterItem ri in RepeaterServices.Items)
                {
                    LinkButton lnkbtnServiceDetailsTemp = ri.FindControl("lnkbtnServiceDetails") as LinkButton;
                    lnkbtnServiceDetailsTemp.Visible = true;
                }

                foreach (RepeaterItem ri in RepeaterServices.Items)
                {
                    Label lblServiceIDReapeter = ri.FindControl("lblServiceIDReapeter") as Label;
                    LinkButton lnkbtnServiceDetailsTemp = ri.FindControl("lnkbtnServiceDetails") as LinkButton;
                    if (lblServiceIDReapeter.Text.Trim() == lblSelectedSerciceID.Text.Trim())
                    {
                        lnkbtnServiceDetailsTemp.Visible = false;
                    }
                }
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void ControlAddedStatusVisiability()
        {
            try
            {
                foreach (RepeaterItem ri in RepeaterServices.Items)
                {
                    Label lblStatusAdded = ri.FindControl("lblStatusAdded") as Label;
                    //LinkButton lnkbtnServiceDetailsTemp = ri.FindControl("lnkbtnServiceDetails") as LinkButton;
                    //lnkbtnServiceDetailsTemp.Visible = true;
                    lblStatusAdded.Visible = false;
                }

                foreach (RepeaterItem ri in RepeaterServices.Items)
                {
                    Label lblServiceIDReapeter = ri.FindControl("lblServiceIDReapeter") as Label;
                    //LinkButton lnkbtnServiceDetailsTemp = ri.FindControl("lnkbtnServiceDetails") as LinkButton;
                    Label lblStatusAdded = ri.FindControl("lblStatusAdded") as Label;

                    foreach (GridViewRow rowNo in grdSelectedServices.Rows)
                    {
                        Label lblcolServiceID = (Label)rowNo.FindControl("lblcolServiceID");
                        if (lblServiceIDReapeter.Text.Trim() == lblcolServiceID.Text.Trim())
                        {
                            //lnkbtnServiceDetailsTemp.Visible = false;
                            lblStatusAdded.Visible = true;
                        }
                    }

                    
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
        protected void btnTakeService_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesTakeService();
                ControlPlaceOrderVisibility();
                ControlAddedStatusVisiability();
                
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
        double serviceValue = 0;
        protected void grdSelectedServices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblcolServiceValue = (e.Row.FindControl("lblcolServiceValue") as Label);
                serviceValue += Convert.ToDouble(lblcolServiceValue.Text);
                lblTotalVale.Text = string.Format("{0:n2}", serviceValue);
            }
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
                ControlAddedStatusVisiability();
                ControlPlaceOrderVisibility();
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        protected void btnOtherModuleName1_Click(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
                _objServiceManagement = new ServiceManagement();
                Session["moduleName"] = (item.FindControl("btnOtherModuleName1") as Button).Text;
                lblNameoftheModule.Text = Session["moduleName"].ToString();
                _objPackageSetup = new PackageSetup();
                _objPackageSetup.PackageName = Session["moduleName"].ToString();
                LoadServices(_objPackageSetup);
                _objServiceManagement = new ServiceManagement();
                _objServiceManagement.ServiceID = lblSelectedSerciceID.Text == string.Empty ? 0 : Convert.ToInt32(lblSelectedSerciceID.Text);
                LoadServiceDescription(_objServiceManagement);
                LoadNodeCollection(_objServiceManagement);
                LoadServicePricing(_objServiceManagement);
                LoadServicePreviousPricing(_objServiceManagement);
                ControlAddedStatusVisiability();
                ControlPlaceOrderVisibility();
                _objPackageSetup = new PackageSetup();
                _objPackageSetup.PackageName = Session["moduleName"].ToString();
                this.LoadPackages(_objPackageSetup);
                
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
            
        }

        protected void btnServe_Click(object sender, EventArgs e)
        {
            try
            {
                _objServiceServe = new ServiceServe();
                _objServiceServe.DtServices = (DataTable)ViewState["SelectedServices"];
                foreach (DataRow rowNo in _objServiceServe.DtServices.Rows)
                {
                    _objServiceServe.ServiceList += rowNo["colServiceID"].ToString()+",";   
                }

                _objServiceServe.ServiceList = _objServiceServe.ServiceList.TrimEnd(',');
                UserList objUserList = new UserList();
                objUserList.UserName = LoginUserInformation.UserName;
                _objServiceServe.EntryUserName = LoginUserInformation.UserID;
                _objServiceServe.CompanyID = LoginUserInformation.CompanyID;
                _objServiceServeController = new ServiceServeController();
                _objServiceServeController.ServeClientNode(_objServiceServe, objUserList);
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }


    }
}