using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;

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
                _objUserListController = new UserListController();
                _objUserListController.Save(_objUserList);
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
                Response.Redirect("~/Default.aspx");

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }
    }
}