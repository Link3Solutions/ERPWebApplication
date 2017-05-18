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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                }

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
                //_objEmployeeDetailsSetup.CompanyID = Convert.ToInt32(ddlCompany.SelectedValue);
                //_objEmployeeDetailsSetup.BranchID = Convert.ToInt32(ddlBranch.SelectedValue);
                //_objEmployeeDetailsSetup.DepartmentID = Convert.ToInt32( ddlDepartment.SelectedValue);
                //_objEmployeeDetailsSetup.SectionID = Convert.ToInt32( ddlSection.SelectedValue);
                //_objEmployeeDetailsSetup.TeamID = Convert.ToInt32( ddlTeam.SelectedValue);
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
    }
}