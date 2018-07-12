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
    public partial class HomePageAboutForm : System.Web.UI.Page
    {
        private UserList _objUserList;
        private UserListController _objUserListController;
        private CompanySetupController _objCompanySetupController;
        private CompanySetup _objCompanySetup;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

    }
}