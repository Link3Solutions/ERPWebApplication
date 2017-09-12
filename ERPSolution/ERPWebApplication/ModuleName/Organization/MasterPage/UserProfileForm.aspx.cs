using ERPWebApplication.AppClass.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.AppClass.CommonClass;

namespace ERPWebApplication.ModuleName.Organization.MasterPage
{
    public partial class UserProfileForm : System.Web.UI.Page
    {
        private EmployeeSetupController _objEmployeeSetupController;
        private UserProfile _objUserProfile;
        private UserProfileController _objUserProfileController;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadEmployeeTitle();
                LoadUserProfileTypeDDL();
            }

        }

        private void LoadUserProfileTypeDDL()
        {
            try
            {

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
        private void LoadEmployeeTitle()
        {
            try
            {
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.GetEmployeeTitle(ddlTitle);

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
                AddValuesUserProfile();
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
                ddlTitle.SelectedValue = "-1";
                txtFullName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtDisplayName.Text = string.Empty;
                ddlUserProfileType.SelectedValue = "-1";

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void AddValuesUserProfile()
        {
            try
            {
                _objUserProfile = new UserProfile();
                _objUserProfile.Title = ddlTitle.SelectedValue;
                _objUserProfile.FullName = txtFullName.Text == string.Empty ? null : txtFullName.Text;
                _objUserProfile.Email = txtEmail.Text == string.Empty ? null : txtEmail.Text;
                _objUserProfile.UserProfileTypeID = ddlUserProfileType.SelectedValue;
                _objUserProfile.DisplayName = txtDisplayName.Text == string.Empty ? null : txtDisplayName.Text;
                _objUserProfile.EntryUserName = LoginUserInformation.UserID;
                _objUserProfileController = new UserProfileController();
                _objUserProfileController.Save(_objUserProfile);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearControl();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }
    }
}