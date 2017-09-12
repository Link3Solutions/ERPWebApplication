using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebApplication
{
    public partial class ChangeCompanyForm : System.Web.UI.Page
    {
        private UserList _objUserList;
        private UserListController _objUserListController;
        private CompanySetup _objCompanySetup;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    lblCompanyText.Visible = false;
                    ddlCompany.Visible = false;
                    lblLoginPassword.Visible = false;
                    txtLoginPassword.Visible = false;
                    btnLogin.Visible = false;

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
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
                }
                else
                {
                    lblCompanyText.Visible = false;
                    ddlCompany.Visible = false;
                    lblLoginPassword.Visible = false;
                    txtLoginPassword.Visible = false;
                    btnLogin.Visible = false;
                    _objUserListController.CheckUser(_objUserList);
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