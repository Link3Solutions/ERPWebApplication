using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;


namespace ERPWebApplication.ModuleName.HRMS.MasterPage
{
    public partial class EmployeeSetupForm : System.Web.UI.Page
    {
        private EmployeeDetailsSetup _objEmployeeDetailsSetup;
        private EmployeeSetupController _objEmployeeSetupController;
        private EmployeeTypeSetup _objEmployeeTypeSetup;
        private EmployeeCategorySetup _objEmployeeCategorySetup;
        private DesignationSetup _objDesignationSetup;
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
                    LoadAllDDL();
                    LoadDepartment();
                    LoadSection();
                    LoadTeam();

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void LoadAllDDL()
        {
            try
            {
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadCompanyDDL(ddlCompany);
                foreach (ListItem itemNo in ddlCompany.Items)
                {
                    if (Convert.ToInt32( itemNo.Value) == LoginUserInformation.CompanyID )
                    {
                        ddlCompany.SelectedValue = LoginUserInformation.CompanyID.ToString();
                        
                    }
                    
                }

                _objCompanySetup = new CompanySetup();
                _objCompanySetup.CompanyID = Convert.ToInt32( ddlCompany.SelectedValue);
                _objEmployeeSetupController.LoadBranchDDL(ddlBranch,_objCompanySetup);
                //_objEmployeeSetupController.LoadEmployeeType(ddlEmployeeType);
                //_objEmployeeSetupController.LoadEmployeeCategoryDDL(ddlEmployeeCategory);
                //_objEmployeeSetupController.LoadDesignationDDL(ddlDesignation);
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void LoadTeam()
        {
            try
            {
                _objSectionSetup = new SectionSetup();
                _objSectionSetup.CompanyID = Convert.ToInt32(ddlCompany.SelectedValue);
                _objSectionSetup.BranchID = Convert.ToInt32(ddlBranch.SelectedValue);
                _objSectionSetup.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);
                _objSectionSetup.SectionID = Convert.ToInt32(ddlSection.SelectedValue);
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadTeamDDL(ddlTeam, _objSectionSetup);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void LoadSection()
        {
            try
            {
                _objDepartmentSetup = new DepartmentSetup();
                _objDepartmentSetup.CompanyID = Convert.ToInt32(ddlCompany.SelectedValue);
                _objDepartmentSetup.BranchID = Convert.ToInt32(ddlBranch.SelectedValue);
                _objDepartmentSetup.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadSectionDDL(ddlSection, _objDepartmentSetup);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void LoadDepartment()
        {
            try
            {
                _objBranchSetup = new BranchSetup();
                _objBranchSetup.CompanyID = Convert.ToInt32(ddlCompany.SelectedValue);
                _objBranchSetup.BranchID = Convert.ToInt32(ddlBranch.SelectedValue);
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadDepartmentDDL(ddlDepartment, _objBranchSetup);
                int countItem = ddlDepartment.Items.Count;

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AddValues();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void AddValues()
        {
            try
            {
                _objEmployeeDetailsSetup = new EmployeeDetailsSetup();
                _objEmployeeDetailsSetup.CompanyID = Convert.ToInt32(ddlCompany.SelectedValue);
                _objEmployeeDetailsSetup.BranchID = Convert.ToInt32(ddlBranch.SelectedValue);
                _objEmployeeDetailsSetup.DepartmentID = Convert.ToInt32( ddlDepartment.SelectedValue);
                _objEmployeeDetailsSetup.SectionID = Convert.ToInt32( ddlSection.SelectedValue);
                _objEmployeeDetailsSetup.TeamID = Convert.ToInt32( ddlTeam.SelectedValue);
                _objEmployeeDetailsSetup.EmployeeID = txtEmployeeID.Text == string.Empty ? null : txtEmployeeID.Text;
                _objEmployeeTypeSetup = new EmployeeTypeSetup();
                _objEmployeeTypeSetup.EmployeeTypeID = 1;//Convert.ToInt32(ddlEmployeeType.SelectedValue);
                _objEmployeeCategorySetup = new EmployeeCategorySetup();
                _objEmployeeCategorySetup.EmployeeCategoryID = 1; //Convert.ToInt32(ddlEmployeeCategory.SelectedValue);
                _objDesignationSetup = new DesignationSetup();
                _objDesignationSetup.DesignationID = "1";//ddlDesignation.SelectedValue;
                _objEmployeeDetailsSetup.FirstName = txtFirstName.Text == string.Empty ? null : txtFirstName.Text;
                _objEmployeeDetailsSetup.MiddleName = txtMiddleName.Text == string.Empty ? null : txtMiddleName.Text;
                _objEmployeeDetailsSetup.LastName = txtLastName.Text == string.Empty ? null : txtLastName.Text;
                _objEmployeeDetailsSetup.Email = txtEmail.Text == string.Empty ? null : txtEmail.Text;
                _objEmployeeDetailsSetup.EntryUserName = LoginUserInformation.UserID;
                IsUser objIsUser = new IsUser();
                objIsUser.UserPermission = Convert.ToInt32( ddlUserPermission.SelectedValue);
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.Save(_objEmployeeDetailsSetup, _objEmployeeTypeSetup, _objEmployeeCategorySetup, _objDesignationSetup,objIsUser);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadDepartment();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadSection();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadTeam();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }
    }
}