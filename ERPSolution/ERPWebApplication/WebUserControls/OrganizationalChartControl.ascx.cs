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
        private BranchSetup _objBranchSetup;
        private DepartmentSetup _objDepartmentSetup;
        private SectionSetup _objSectionSetup;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    UCGetOrganizationElements();
                }
                DropDownList ddlElementDataCompany = (DropDownList)GridViewOrganizationalChart.Rows[0].FindControl("ddlElementData");
                ddlElementDataCompany.Enabled = false;

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
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
            try
            {
                DropDownList ddlElementData = (DropDownList)e.Row.FindControl("ddlElementData");

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    switch (gridRowIndex)
                    {
                        case 0:
                            {
                                UCLoadCompany(ddlElementData);
                                gridRowIndex++;
                                break;
                            }
                        case 1:
                            {
                                UCLoadBranch(ddlElementData);
                                gridRowIndex++; break;
                            }
                        case 2:
                            {
                                UCLoadDepartment(ddlElementData);
                                gridRowIndex++; break;
                            }
                        case 3:
                            {
                                UCLoadSection(ddlElementData);
                                gridRowIndex++; break;
                            }
                        case 4:
                            {
                                UCLoadTeam(ddlElementData);
                                gridRowIndex++; break;
                            }
                        default:
                            break;
                    }
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void UCLoadTeam(DropDownList ddlElementData)
        {
            try
            {
                _objSectionSetup = new SectionSetup();
                DropDownList ddlElementDataCompany = (DropDownList)GridViewOrganizationalChart.Rows[0].FindControl("ddlElementData");
                DropDownList ddlElementDataBranch = (DropDownList)GridViewOrganizationalChart.Rows[1].FindControl("ddlElementData");
                DropDownList ddlElementDataDepartment = (DropDownList)GridViewOrganizationalChart.Rows[2].FindControl("ddlElementData");
                DropDownList ddlElementDataSection = (DropDownList)GridViewOrganizationalChart.Rows[3].FindControl("ddlElementData");
                _objSectionSetup.CompanyID = Convert.ToInt32(ddlElementDataCompany.SelectedValue);
                _objSectionSetup.BranchID = Convert.ToInt32(ddlElementDataBranch.SelectedValue);
                _objSectionSetup.DepartmentID = Convert.ToInt32(ddlElementDataDepartment.SelectedValue);
                _objSectionSetup.SectionID = Convert.ToInt32(ddlElementDataSection.SelectedValue);
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadTeamDDL(ddlElementData, _objSectionSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void UCLoadSection(DropDownList ddlElementData)
        {
            try
            {
                _objDepartmentSetup = new DepartmentSetup();
                DropDownList ddlElementDataCompany = (DropDownList)GridViewOrganizationalChart.Rows[0].FindControl("ddlElementData");
                DropDownList ddlElementDataBranch = (DropDownList)GridViewOrganizationalChart.Rows[1].FindControl("ddlElementData");
                DropDownList ddlElementDataDepartment = (DropDownList)GridViewOrganizationalChart.Rows[2].FindControl("ddlElementData");
                _objDepartmentSetup.CompanyID = Convert.ToInt32(ddlElementDataCompany.SelectedValue);
                _objDepartmentSetup.BranchID = Convert.ToInt32(ddlElementDataBranch.SelectedValue);
                _objDepartmentSetup.DepartmentID = Convert.ToInt32(ddlElementDataDepartment.SelectedValue);
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadSectionDDL(ddlElementData, _objDepartmentSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void UCLoadCompany(DropDownList ddlElementData)
        {
            try
            {
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadCompanyDDL(ddlElementData);
                foreach (ListItem itemNo in ddlElementData.Items)
                {
                    if (Convert.ToInt32(itemNo.Value) == LoginUserInformation.CompanyID)
                    {
                        ddlElementData.SelectedValue = LoginUserInformation.CompanyID.ToString();

                    }

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void UCLoadBranch(DropDownList ddlElementData)
        {
            try
            {
                _objCompanySetup = new CompanySetup();
                DropDownList ddlElementDataCompany = (DropDownList)GridViewOrganizationalChart.Rows[0].FindControl("ddlElementData");
                _objCompanySetup.CompanyID = Convert.ToInt32(ddlElementDataCompany.SelectedValue);
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadBranchDDL(ddlElementData, _objCompanySetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void UCLoadDepartment(DropDownList ddlElementData)
        {
            try
            {
                _objBranchSetup = new BranchSetup();
                DropDownList ddlElementDataCompany = (DropDownList)GridViewOrganizationalChart.Rows[0].FindControl("ddlElementData");
                DropDownList ddlElementDataBranch = (DropDownList)GridViewOrganizationalChart.Rows[1].FindControl("ddlElementData");
                _objBranchSetup.CompanyID = Convert.ToInt32(ddlElementDataCompany.SelectedValue);
                _objBranchSetup.BranchID = Convert.ToInt32(ddlElementDataBranch.SelectedValue);
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadDepartmentDDL(ddlElementData, _objBranchSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void ddlElementData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddlSelected = (DropDownList)sender;
                GridViewRow rowSelected = (GridViewRow)ddlSelected.NamingContainer;
                int selectedIndex = rowSelected.RowIndex;
                switch (selectedIndex)
                {
                    case 0:
                        {
                            DropDownList ddlElementDataBranch = (DropDownList)GridViewOrganizationalChart.Rows[1].FindControl("ddlElementData");
                            this.UCLoadBranch(ddlElementDataBranch);
                            break;
                        }
                    case 1:
                        {
                            DropDownList ddlElementDataDepartment = (DropDownList)GridViewOrganizationalChart.Rows[2].FindControl("ddlElementData");
                            this.UCLoadDepartment(ddlElementDataDepartment);
                            break;
                        }
                    case 2:
                        {
                            DropDownList ddlElementDataSection = (DropDownList)GridViewOrganizationalChart.Rows[3].FindControl("ddlElementData");
                            this.UCLoadSection(ddlElementDataSection);
                            break;
                        }
                    case 3:
                        {
                            DropDownList ddlElementDataTeam = (DropDownList)GridViewOrganizationalChart.Rows[4].FindControl("ddlElementData");
                            this.UCLoadTeam(ddlElementDataTeam);
                            break;
                        }
                    default:
                        break;
                }


            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }


    }
}