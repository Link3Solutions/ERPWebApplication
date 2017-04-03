using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.AppClass.DataAccess;

namespace ERPWebApplication.ModuleName.Organization.MasterPage
{
    public partial class UserSecurityCodeForm : System.Web.UI.Page
    {
        private UserSecurityCode _objUserSecurityCode;
        private UserSecurityCodeController _objUserSecurityCodeController;
        private CompanySetup _objCompanySetup;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _objCompanySetup = new CompanySetup();
                _objCompanySetup.CompanyID = LoginUserInformation.CompanyID;
                _objUserSecurityCodeController = new UserSecurityCodeController();
                _objUserSecurityCodeController.LoadUserForSecurityCode(_objCompanySetup, GridViewUsers);


            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }
    }
}