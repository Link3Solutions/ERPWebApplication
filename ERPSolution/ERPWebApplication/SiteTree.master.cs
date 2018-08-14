using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebApplication
{
    public partial class SiteTree : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TreeViewMenu_SelectedNodeChanged(object sender, EventArgs e)
        {
            var nodePath = TreeViewMenu.SelectedValue.ToString();
            Response.Redirect(nodePath);
        }
    }
}