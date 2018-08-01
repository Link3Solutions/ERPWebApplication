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
    public partial class HomePageLogoForm : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnModuleName2_Click(object sender, EventArgs e)
        {
            Session["moduleName"] = this.btnModuleName2.Text;
            Response.Redirect("~/ServiceRequestForm.aspx");
            
            //string passthevalue = UsernameTextbox.Text;
            //Response.Redirect("Step2.aspx?PasstheValue=" + passthevalue);
        }


    }
}