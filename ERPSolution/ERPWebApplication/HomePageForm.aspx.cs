using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebApplication
{
    public partial class HomePageForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PanelRegister.Visible = false;
                PanelLogin.Visible = false;
                
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
    }
}