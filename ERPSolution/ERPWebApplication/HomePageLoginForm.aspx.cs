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
    public partial class HomePageLoginForm : System.Web.UI.Page
    {
        private UserList _objUserList;
        private UserListController _objUserListController;
        private CompanySetupController _objCompanySetupController;
        private CompanySetup _objCompanySetup;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    LoadCompanyDDL();
                    lblCompanyText.Visible = false;
                    ddlCompany.Visible = false;
                    lblLoginPassword.Visible = false;
                    txtLoginPassword.Visible = false;
                    btnLogin.Visible = false;
                    RememberMe.Visible = false;
                    lblRememberMe.Visible = false;
                    
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void LoadCompanyDDL()
        {
            try
            {
                _objCompanySetupController = new CompanySetupController();
                _objCompanySetupController.LoadCompany(ddlCompany);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                switch (CheckUserValidation())
                {
                    case 1:
                        {
                            Response.Redirect("~/Default.aspx");
                            break;
                        }
                    case 2:
                        {
                            Response.Redirect("~/Default.aspx");
                            break;
                        }
                    default:
                        clsTopMostMessageBox.Show(clsMessages.GLoginFail);
                        break;
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private int CheckUserValidation()
        {
            try
            {
                _objUserList = new UserList();
                _objUserList.UserName = txtLoginUserName.Text == string.Empty ? null : txtLoginUserName.Text;
                _objUserList.UserPassword = txtLoginPassword.Text == string.Empty ? null : txtLoginPassword.Text;

                if (_objUserList.UserName == "ADM" && _objUserList.UserPassword == "ADM123")
                {
                    LoginUserInformation.UserID = "160ea939-7633-46a8-ae49-f661d12abfd5";
                    LoginUserInformation.CompanyID = 1;
                    LoginUserInformation.EmployeeCode = "ADM";
                    LoginUserInformation.EmployeeFullName = "Administrator";
                    LoginUserInformation.UserName = "ADM";
                    LoginUserInformation.BranchID = 0;
                    return _objUserList.UserType = 1;
                }

                DataTable dtUserInformation = new DataTable();
                _objUserListController = new UserListController();
                _objCompanySetup = new CompanySetup();
                _objCompanySetup.CompanyID = Convert.ToInt32(ddlCompany.SelectedValue);
                dtUserInformation = _objUserListController.GetLoginUserProfile(_objUserList, _objCompanySetup);
                foreach (DataRow rowNo in dtUserInformation.Rows)
                {
                    LoginUserInformation.CompanyID = _objCompanySetup.CompanyID;
                    LoginUserInformation.UserID = rowNo["UserProfileID"].ToString();
                    LoginUserInformation.EmployeeCode = null;
                    LoginUserInformation.EmployeeFullName = rowNo["FullName"].ToString();
                    LoginUserInformation.UserName = _objUserList.UserName;
                    LoginUserInformation.BranchID = 0;
                    return _objUserList.UserType = 2;

                }

                return _objUserList.UserType;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void lnkbtnCompany_Click(object sender, EventArgs e)
        {
            try
            {
                LoadAssignCompanyDDL();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
                
            }

        }

        private void LoadAssignCompanyDDL()
        {
            try
            {
                _objUserList = new UserList();
                _objUserList.UserName = txtLoginUserName.Text == string.Empty ? null : txtLoginUserName.Text;
                if (_objUserList.UserName == "ADM")
                {
                    lblCompanyText.Visible = false;
                    ddlCompany.Visible = false;
                    lblLoginPassword.Visible = true;
                    txtLoginPassword.Visible = true;
                    btnLogin.Visible = true;
                    RememberMe.Visible = true;
                    lblRememberMe.Visible = true;
                }
                else
                {
                    _objUserListController = new UserListController();
                    DataTable dtAssignCompany = _objUserListController.GetAssignCompanyUpdate(_objUserList);
                    _objUserListController.LoadCompanyDDL(dtAssignCompany, ddlCompany);
                    if (dtAssignCompany.Rows.Count > 0)
                    {
                        lblCompanyText.Visible = true;
                        ddlCompany.Visible = true;
                        lblLoginPassword.Visible = true;
                        txtLoginPassword.Visible = true;
                        btnLogin.Visible = true;
                        RememberMe.Visible = true;
                        lblRememberMe.Visible = true;
                    }
                    else
                    {
                        lblCompanyText.Visible = false;
                        ddlCompany.Visible = false;
                        lblLoginPassword.Visible = false;
                        txtLoginPassword.Visible = false;
                        btnLogin.Visible = false;
                        RememberMe.Visible = false;
                        lblRememberMe.Visible = false;
                        _objUserListController.CheckUser(_objUserList);

                    }
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void ibtnNext_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                LoadAssignCompanyDDL();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);

            }

        }

        protected void lnkbtnCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePageRegisterForm.aspx");
        }

    }
}