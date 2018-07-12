using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebApplication
{
    public partial class SiteHomePage : System.Web.UI.MasterPage
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
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void ImageButtonLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/HomePageLogoForm.aspx");
        }

        protected void lnkbtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePageLoginForm.aspx");
        }

        protected void lnkbtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePageRegisterForm.aspx");
        }

        protected void lnkbtnContactUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePageContactUsForm.aspx");
        }

        protected void lnkbtnAbout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePageAboutForm.aspx");
        }
    }
}