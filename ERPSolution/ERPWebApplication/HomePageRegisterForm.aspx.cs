using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;
using System.Data;

namespace ERPWebApplication
{
    public partial class HomePageRegisterForm : System.Web.UI.Page
    {
        private UserList _objUserList;
        private UserListController _objUserListController;
        private CompanySetupController _objCompanySetupController;
        private CompanySetup _objCompanySetup;
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesForRegistration();
                ClearControl();
                //Response.Redirect("~/Default.aspx");
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
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
                txtSecurityCode.Text = string.Empty;
                txtEmail.Text = string.Empty;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void AddValuesForRegistration()
        {
            try
            {
                _objUserList = new UserList();
                _objUserList.UserName = txtUserName.Text == string.Empty ? null : txtUserName.Text;
                _objUserList.UserPassword = txtPassword.Text == string.Empty ? null : txtPassword.Text;
                _objUserList.ConfirmPassword = txtConfirmPassword.Text == string.Empty ? null : txtConfirmPassword.Text;
                _objUserList.SecurityCode = txtSecurityCode.Text == string.Empty ? null : txtSecurityCode.Text;
                _objUserList.UserEmail = txtEmail.Text == string.Empty ? null : txtEmail.Text;
                _objUserListController = new UserListController();
                _objUserListController.Update(_objUserList);
                //DataTable dtUserInformation = new DataTable();
                //dtUserInformation = _objUserListController.GetLoginUserInformation(_objUserList);
                //foreach (DataRow rowNo in dtUserInformation.Rows)
                //{
                //    LoginUserInformation.CompanyID = Convert.ToInt32(rowNo["CompanyID"].ToString());
                //    LoginUserInformation.UserID = rowNo["UserProfileID"].ToString();
                //    LoginUserInformation.EmployeeCode = rowNo["EmployeeID"].ToString();
                //    LoginUserInformation.EmployeeFullName = rowNo["FullName"].ToString();
                //}
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void lnkbtnSigninRegisterForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePageLoginForm.aspx");
        }

        
    }
}