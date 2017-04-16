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
    public partial class HomePageForm : System.Web.UI.Page
    {
        private UserList _objUserList;
        private UserListController _objUserListController;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    PanelRegister.Visible = false;
                    PanelLogin.Visible = false;

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void lnkbtnRegister_Click(object sender, EventArgs e)
        {
            PanelLogin.Visible = false;
            PanelRegister.Visible = true;
        }

        protected void lnkbtnLogin_Click(object sender, EventArgs e)
        {
            PanelRegister.Visible = false;
            PanelLogin.Visible = true;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesForRegistration();
                ClearControl();
                Response.Redirect("~/Default.aspx");

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
                _objUserListController.Save(_objUserList);
                DataTable dtUserInformation = new DataTable();
                dtUserInformation = _objUserListController.GetLoginUserInformation(_objUserList);
                foreach (DataRow rowNo in dtUserInformation.Rows)
                {
                    LoginUserInformation.CompanyID = Convert.ToInt32(rowNo["CompanyID"].ToString());
                    LoginUserInformation.UserID = rowNo["UserProfileID"].ToString();
                    LoginUserInformation.EmployeeCode = rowNo["EmployeeID"].ToString();
                }
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
                    return _objUserList.UserType = 1;
                }

                DataTable dtUserInformation = new DataTable();
                _objUserListController = new UserListController();
                dtUserInformation = _objUserListController.GetLoginUserInformation(_objUserList);
                foreach (DataRow rowNo in dtUserInformation.Rows)
                {
                    LoginUserInformation.CompanyID = Convert.ToInt32(rowNo["CompanyID"].ToString());
                    LoginUserInformation.UserID = rowNo["UserProfileID"].ToString();
                    LoginUserInformation.EmployeeCode = rowNo["EmployeeID"].ToString();
                    return _objUserList.UserType = 2;

                }

                return _objUserList.UserType;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}