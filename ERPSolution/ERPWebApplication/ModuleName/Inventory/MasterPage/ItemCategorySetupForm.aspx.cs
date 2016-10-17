using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebApplication.ModuleName.Inventory.MasterPage
{
    public partial class ItemCategorySetupForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PanelItemSetup.Visible = false;

            }

        }

        protected void CheckBoxAddItem_CheckedChanged(object sender, EventArgs e)
        {

            if (CheckBoxAddItem.Checked == true)
            {
                PanelItemSetup.Visible = true;
                PanelLeft.Visible = false;
                PanelRight.Visible = false;
                
            }
            else
            {
                PanelLeft.Visible = true;
                PanelRight.Visible = true;
                PanelItemSetup.Visible = false;

            }
        }
    }
}