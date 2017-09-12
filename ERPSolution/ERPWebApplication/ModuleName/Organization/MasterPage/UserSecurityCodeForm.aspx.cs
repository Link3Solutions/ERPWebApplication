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
                _objUserSecurityCodeController = new UserSecurityCodeController();
                _objUserSecurityCodeController.LoadUserForSecurityCode(GridViewUsers);


            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void GridViewUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
                if (e.CommandName.Equals("Select"))
                {
                    _objUserSecurityCode = new UserSecurityCode();
                    _objUserSecurityCode.UserKnownID = ((Label)GridViewUsers.Rows[selectedIndex].FindControl("lblEmployeeID")).Text;
                    UserProfile objUserProfile = new UserProfile();
                    objUserProfile.Email = ((Label)GridViewUsers.Rows[selectedIndex].FindControl("lblEmail")).Text;
                    _objCompanySetup = new CompanySetup();
                    _objCompanySetup.CompanyID = LoginUserInformation.CompanyID;
                    _objCompanySetup.EntryUserName = LoginUserInformation.UserID;
                    _objUserSecurityCodeController = new UserSecurityCodeController();
                    _objUserSecurityCodeController.SendSecurityCode(_objCompanySetup,_objUserSecurityCode,objUserProfile);
                    _objUserSecurityCodeController.LoadUserForSecurityCode(GridViewUsers);
                    clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void GridViewUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }
    }
}