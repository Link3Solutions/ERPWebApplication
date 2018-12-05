using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication
{
    public partial class ThankYouForm : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUserEmail.Text = Request.QueryString["EID"];

        }

        protected void lnkbtnToResigter_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePageRegisterForm.aspx");
        }

        protected void lnkbtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePageLogoForm.aspx");
        }

        protected void lnkbtnServices_Click(object sender, EventArgs e)
        {
            Session["moduleName"] = "HRMS";
            Response.Redirect("~/ServiceRequestForm.aspx");
        }
    }
}