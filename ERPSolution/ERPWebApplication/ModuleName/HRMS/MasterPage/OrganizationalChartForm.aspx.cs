using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.AppClass.DataAccess;
using System.Data;

namespace ERPWebApplication.ModuleName.HRMS.MasterPage
{
    public partial class OrganizationalChartForm : System.Web.UI.Page
    {
        private OrganizationalChartSetup _objOrganizationalChartSetup;
        private OrganizationalChartSetupController _objOrganizationalChartSetupController;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    LoadCompany(ddlCompany);
                    LoadStandardOrgElements(ListBoxStandardOrgElements);
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void LoadStandardOrgElements(ListBox listBoxStandardOrgElements)
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.LoadStandardOrgElementsDDL(listBoxStandardOrgElements);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void LoadCompany(DropDownList ddlCompany)
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.LoadCompanyDDL(ddlCompany);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }


        protected void btnForword_Click(object sender, EventArgs e)
        {
            try
            {
                List<ListItem> deletedItems = new List<ListItem>();
                foreach (ListItem item in ListBoxStandardOrgElements.Items)
                {
                    if (item.Selected)
                    {
                        ListBoxOrganizationElements.Items.Add(new ListItem(item.Text, item.Value));
                        ListBoxOrganizationElements.AppendDataBoundItems = true;
                    }
                }
                
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnForwordAll_Click(object sender, EventArgs e)
        {
            try
            {
                ListBoxOrganizationElements.Items.Clear();
                foreach (ListItem item in ListBoxStandardOrgElements.Items)
                {
                    ListBoxOrganizationElements.Items.Add(item);
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                List<ListItem> deletedItems = new List<ListItem>();
                foreach (ListItem item in ListBoxOrganizationElements.Items)
                {
                    if (item.Selected)
                    {
                        deletedItems.Add(item);
                    }
                }

                foreach (ListItem item in deletedItems)
                {
                    ListBoxOrganizationElements.Items.Remove(item);
                }
                
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnBackAll_Click(object sender, EventArgs e)
        {
            try
            {
                ListBoxOrganizationElements.Items.Clear();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrgElements();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void AddOrgElements()
        {
            try
            {
                _objOrganizationalChartSetup = new OrganizationalChartSetup();
                _objOrganizationalChartSetup.CompanyID = Convert.ToInt32( ddlCompany.SelectedValue);
                List<int> list = new List<int>();
                foreach (ListItem  item in ListBoxOrganizationElements.Items)
                {
                    list.Add(Convert.ToInt32( item.Value));
                }
                _objOrganizationalChartSetup.OrgElementIDList = list;

                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.Save(_objOrganizationalChartSetup);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}