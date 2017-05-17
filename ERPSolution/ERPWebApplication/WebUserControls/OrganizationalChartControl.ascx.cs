using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.WebUserControls
{
    public partial class OrganizationalChartControl : System.Web.UI.UserControl
    {
        private OrganizationalChartSetup _objOrganizationalChartSetup;
        private UCOrganizationalChartController _objUCOrganizationalChartController;
        private EmployeeSetupController _objEmployeeSetupController;
        private CompanySetup _objCompanySetup;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    UCGetOrganizationElements();

                }
                catch (Exception msgException)
                {

                    clsTopMostMessageBox.Show(msgException.Message);
                }

            }

        }

        private void UCGetOrganizationElements()
        {
            try
            {
                _objOrganizationalChartSetup = new OrganizationalChartSetup();
                _objOrganizationalChartSetup.CompanyID = LoginUserInformation.CompanyID;
                _objUCOrganizationalChartController = new UCOrganizationalChartController();
                _objUCOrganizationalChartController.GetOrganizationElementsGV(GridViewOrganizationalChart, _objOrganizationalChartSetup);


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private int gridRowIndex = 0;
        protected void GridViewOrganizationalChart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList ddlElementData = (DropDownList)e.Row.FindControl("ddlElementData");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (gridRowIndex)
                {
                    case 0:
                        {
                            _objEmployeeSetupController = new EmployeeSetupController();
                            _objEmployeeSetupController.LoadCompanyDDL(ddlElementData);
                            gridRowIndex++;
                            break;
                        }
                    case 1:
                        {
                            _objCompanySetup = new CompanySetup();
                            DropDownList ddlElementDataBranch = (DropDownList)GridViewOrganizationalChart.Rows[0].FindControl("ddlElementData");
                            _objCompanySetup.CompanyID = Convert.ToInt32(ddlElementDataBranch.SelectedValue);
                            _objEmployeeSetupController.LoadBranchDDL(ddlElementData, _objCompanySetup); break;
                        }
                    default:
                        break;
                }
            }
        }

        protected void ddlElementData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        
    }
}